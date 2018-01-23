using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFinal.Tokenizer;

namespace TrainingFinal
{
    class DMLParser : IDMLParser
    {
        public List<IElement> Parse(string code)
        {
            var result = new List<IElement>();

            bool isComma(string s) => s == ",";
            bool isSkip(string s) => (s == "\n")||(s == " ")||(s == "/t");
            bool isCurlyBracketOpen(string s) => s == "{";
            bool isCurlyBracketClose(string s) => s == "}";
            bool isBracketOpen(string s) => s == "(";
            bool isBracketClose(string s) => s == ")";
            bool isSymicolon(string s) => s == ";";


            var parser = new StateParser();
            
            var start = new State(); //<- skip
            // V name
            var getName = new State(); // <- name
            // V skip
            var skippsAfterName = new State(); // <- skip
            // V CurlyBracketOpen
            var identifier = new State(); // <- skips
            //
            var take = new State();

            var give = new State();




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
            Assert.AreEqual(acceptanceResult, new DMLParser().Parse(acceptanceStringInput));
        }

        [Test]
        public static void DML_ParseNull()
        {
            Assert.AreEqual(new List<IElement>(), new DMLParser().Parse(""));
        }

        private static string nameOnlyTest = "AX{}";
        private static List<IElement> nameOnlyResult = new List<IElement>()
        {
            new Element("AX")
        };
        [Test]
        public static void DML_ParseNameOnly()
        {
            Assert.AreEqual(nameOnlyResult, new DMLParser().Parse(nameOnlyTest));
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
            Assert.AreEqual(nameGiveTakeResult, new DMLParser().Parse(nameGiveTakeTest));
        }
    }
}
