using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal.Parser
{
    public class DMLParser
    {
        private string[] keySymbols = new string[] { ",", ";", "(", ")", "{", "}" };
        private IElement currentEle = new Element();
        private string currentTarget = ""; // "Gives" or "Takes"
        private List<IElement> result = new List<IElement>();

        public List<IElement> Parse(List<string> tokenList)
        {
            var parser = CreateStateParser();

            tokenList.ForEach(x => parser.Parse(x));

            return result;
        }

        private StateParser CreateStateParser()
        {
            // parser + states
            // states depend on each other. first initialisation, rules after that
            var parser = new StateParser();

            var eleOpenBraceExp = new State();
            var eleRoot = new State();
            var root = new State();
            var paramStart = new State();
            var firstParam = new State();
            var param = new State();
            var paramComma = new State();
            var paramClose = new State();
            var expSemicolon = new State();
            var afterParam = new State();

            // adding rules
            root.Rules.Add(new StateRule() {            Validate = IsWord,      TransitionState = eleOpenBraceExp,  StringAction = NewEle       });

            eleOpenBraceExp.Rules.Add(new StateRule(){  Validate = IsChar("{"), TransitionState = eleRoot,          StringAction = null         });

            eleRoot.Rules.Add(new StateRule(){          Validate = IsIdent,     TransitionState = paramStart,       StringAction = SetTarget    });
            eleRoot.Rules.Add(new StateRule(){          Validate = IsChar("}"), TransitionState = root,             StringAction = SaveEle      });

            paramStart.Rules.Add(new StateRule(){       Validate = IsChar("("), TransitionState = firstParam,       StringAction = null         });

            firstParam.Rules.Add(new StateRule(){       Validate = IsChar(")"), TransitionState = expSemicolon,     StringAction = null         });
            firstParam.Rules.Add(new StateRule(){       Validate = IsWord,      TransitionState = afterParam,       StringAction = AddReq       });

            afterParam.Rules.Add(new StateRule(){       Validate = IsChar(","), TransitionState = param,            StringAction = null         });
            afterParam.Rules.Add(new StateRule(){       Validate = IsChar(")"), TransitionState = expSemicolon,     StringAction = null         });

            param.Rules.Add(new StateRule(){            Validate = IsWord,      TransitionState = afterParam,       StringAction = AddReq       });

            expSemicolon.Rules.Add(new StateRule(){     Validate = IsChar(";"), TransitionState = eleRoot,          StringAction = null         });

            // set initial state
            parser.SetState(root);
            return parser;
        }

        // local State modification Methods
        void NewEle(string s) => currentEle = new Element(s);

        void AddReq(string s)
        {
            if (this.currentTarget == "Gives")
            {
                if (!currentEle.Provisions.Contains(new Resource(s)))
                {
                    currentEle.Provisions.Add(new Resource(s));
                }
            }
            else if (this.currentTarget == "Takes")
            {
                if (!currentEle.Requirements.Contains(new Resource(s)))
                {
                    currentEle.Requirements.Add(new Resource(s));
                }
            }
            else
            {
                Console.WriteLine("Error, unknown target");
            }
        }

        void SetTarget(string s) => currentTarget = s;

        void SaveEle(string s) => result.Add(currentEle);

        // validate functions
        bool IsWord(string s) => !keySymbols.Contains(s);

        bool IsIdent(string s) => s == "Gives" || s == "Takes";

        Func<string, bool> IsChar(string target) => new Func<string, bool>(input => input == target);

    }

    [TestFixture]
    class DMLParserTests
    {
        private static string acceptanceStringInput = System.IO.File.ReadAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + @"..\..\..\..\TestResources\DML_AcceptanceTestInput.txt");
        private static List<IElement> acceptanceResult = new List<IElement>()
        {
            new Element("AS", Helper.ConvertToResourceList("X", "B"), Helper.ConvertToResourceList("Y")),
            new Element("GB", Helper.ConvertToResourceList("X", "Y", "D"), Helper.ConvertToResourceList("R")),
            new Element("M5", Helper.ConvertToResourceList("B"), Helper.ConvertToResourceList("R")),
            new Element("MR", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("A","B")),
            new Element("M2", Helper.ConvertToResourceList("B"), Helper.ConvertToResourceList("X")),
            new Element("NN", Helper.ConvertToResourceList("R"), Helper.ConvertToResourceList("F")),
            new Element("AFEF", Helper.ConvertToResourceList("A","B","X","Y","R"), Helper.ConvertToResourceList()),
            new Element("XA", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("B")),
            new Element("XB", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("R"))
        };

        [Test]
        public static void DMLParserAcceptanceTest()
        {
            var input = new DMLParser().Parse(new Tokenizer().Tokenize(acceptanceStringInput));
            Assert.AreEqual(acceptanceResult, input);
        }

        [Test]
        public static void DML_ParseNull()
        {
            var input = new DMLParser().Parse(new Tokenizer().Tokenize(""));
            Assert.AreEqual(new List<IElement>(), input);
        }

        private static string nameOnlyTest = "AX{}";
        private static List<IElement> nameOnlyResult = new List<IElement>()
        {
            new Element("AX")
        };
        [Test]
        public static void DML_ParseNameOnly()
        {
            var input = new DMLParser().Parse(new Tokenizer().Tokenize(nameOnlyTest));
            Assert.AreEqual(nameOnlyResult, input);
        }

        private static string filePath = System.Reflection.Assembly.GetExecutingAssembly().Location + @"..\..\..\..\TestResources\DML_NameGiveTakeTestInput1.txt";
        private static string nameGiveTakeTest = System.IO.File.ReadAllText(DMLParserTests.filePath);
        private static List<IElement> nameGiveTakeResult = new List<IElement>()
        {
            new Element("GB", Helper.ConvertToResourceList("X", "Y", "D"), Helper.ConvertToResourceList("R"))
        };
        [Test]
        public static void DML_ParseNameGiveTake()
        {
            var input = new DMLParser().Parse(new Tokenizer().Tokenize(nameGiveTakeTest));
            Assert.AreEqual(nameGiveTakeResult, input);
        }
    }
}
