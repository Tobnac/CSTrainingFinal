using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class DMLParser : IDMLParser
    {
        public List<IElement> Parse(string code)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    class DMLParserTests
    {
        private static string acceptanceStringInput = System.IO.File.ReadAllText(@"D:\TobiTutorialC\TrainingFinal\TestResources\DML_AcceptanceTestInput.txt");
        private static List<IElement> acceptanceResult = new List<IElement>()
        {
            new Element("AS", ConvertResource("X", "B"), ConvertResource("Y")),
            new Element("GB", ConvertResource("X", "Y", "D"), ConvertResource("R")),
            new Element("M5", ConvertResource("B"), ConvertResource("R")),
            new Element("MR", ConvertResource(), ConvertResource("A","B")),
            new Element("M2", ConvertResource("B"), ConvertResource("X")),
            new Element("NN", ConvertResource("R"), ConvertResource("F")),
            new Element("AFEF", ConvertResource("A", "B","X","Y","R"), ConvertResource()),
            new Element("XA", ConvertResource(), ConvertResource("B")),
            new Element("XB", ConvertResource(), ConvertResource("R"))
        };

        [Test]
        public static void AcceptanceTest()
        {
            Assert.AreEqual(acceptanceResult, new DMLParser().Parse(acceptanceStringInput));
        }



        private static List<IResource> ConvertResource(params string[] input)
        {
            var result = new List<IResource>();
            for (var i = 0; i < input.Length; i++)
            {
                result.Add(new Resource(input[i]));
            }
            return result;
        }
    }
}
