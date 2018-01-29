using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class DMLParser : IDMLParser
    {
        public List<IElement> Parse(List<string> tokenList)
        {
            var result = new List<IElement>();
            var keySymbols = new string[] { ",", ";", "(", ")", "{", "}" };

            // element creation
            IElement currentEle = new Element();
            string currentTarget = ""; // "Gives" or "Takes"
            void newEle(string s) => currentEle = new Element(s);
            void addReq(string s)
            {
                if (currentTarget == "Gives")
                {
                    if (!currentEle.Provisions.Contains(new Resource(s)))
                    {
                        currentEle.Provisions.Add(new Resource(s));
                    }
                }
                else if (currentTarget == "Takes")
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
            void setTarget(string s) => currentTarget = s;
            void saveEle(string s) => result.Add(currentEle);

            // validate functions
            bool isWord(string s) => !keySymbols.Contains(s);
            bool isIdent(string s) => s == "Gives" || s == "Takes";
            Func<string, bool> isChar(string target) => new Func<string, bool>(input => input == target);

            // parser + states
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
            root.Rules.Add(new StateRule()
            {
                Validate = isWord,
                TransitionState = eleOpenBraceExp,
                StringAction = newEle
            });

            eleOpenBraceExp.Rules.Add(new StateRule()
            {
                Validate = isChar("{"),
                TransitionState = eleRoot,
                StringAction = null
            });

            eleRoot.Rules.Add(new StateRule()
            {
                Validate = isIdent,
                TransitionState = paramStart,
                StringAction = setTarget
            });

            eleRoot.Rules.Add(new StateRule()
            {
                Validate = isChar("}"),
                TransitionState = root,
                StringAction = saveEle
            });

            paramStart.Rules.Add(new StateRule()
            {
                Validate = isChar("("),
                TransitionState = firstParam,
                StringAction = null
            });

            firstParam.Rules.Add(new StateRule()
            {
                Validate = isChar(")"),
                TransitionState = expSemicolon,
                StringAction = null
            });

            firstParam.Rules.Add(new StateRule()
            {
                Validate = isWord,
                TransitionState = afterParam,
                StringAction = addReq
            });

            afterParam.Rules.Add(new StateRule()
            {
                Validate = isChar(","),
                TransitionState = param,
                StringAction = null
            });

            afterParam.Rules.Add(new StateRule()
            {
                Validate = isChar(")"),
                TransitionState = expSemicolon,
                StringAction = null
            });

            param.Rules.Add(new StateRule()
            {
                Validate = isWord,
                TransitionState = afterParam,
                StringAction = addReq
            });

            expSemicolon.Rules.Add(new StateRule()
            {
                Validate = isChar(";"),
                TransitionState = eleRoot,
                StringAction = null
            });

            parser.SetState(root);

            tokenList.ForEach(x => parser.Parse(x));

            return result;
        }
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
