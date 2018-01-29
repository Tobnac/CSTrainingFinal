using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public class Tokenizer
    {
        // 2. parse+sanitise string into strongList -> List<string>
        // 2.1 write stateParser itself
        // 2.2 define states + rules: skip whitespaces/enter/tab, list 'keywords': ( ) { } , ;
        // 2.3 create stringList (+ insert word into each)

        public List<string> Tokenize(string code)
        {
            string whiteSpaceRemovedCode = RemoveWhiteSpaces(code);
            List<string> result = PerformSplit(whiteSpaceRemovedCode);
            return result;
        }

        private List<string> PerformSplit(string whiteSpaceRemovedCode)
        {
            var result = new List<string>();
            var buffer = "";
            var splitChars = new char[] { ',', ';', '(', ')', '{', '}' };

            foreach (var c in whiteSpaceRemovedCode)
            {
                if (splitChars.Contains(c))
                {
                    if (buffer != "")
                    {
                        result.Add(buffer);
                    }
                    
                    buffer = "";
                    result.Add(c.ToString());
                }

                else
                {
                    buffer += c;
                }
            }

            return result;
        }

        public static string RemoveWhiteSpaces(string whiteString)
        {
            whiteString = whiteString.Replace(" ", "");

            whiteString = whiteString.Replace("\t", "");

            return whiteString.Replace("\r\n", "");
        }
    }

    [TestFixture]
    public class TokenizerTests
    {
        private static string acceptanceStringInput = System.IO.File.ReadAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + @"..\..\..\..\TestResources\DML_AcceptanceTestInput.txt");

        private static List<string> acceptanceTestResult = new List<string>()
        {
            "AS","{","Gives","(","Y",")",";","Takes","(","X",",","B",")",";","}",
            "GB","{","Gives","(","R",")",";","Takes","(","X",",","Y",",","D",")",";","}",
            "M5","{","Gives","(","R",")",";", "Takes","(","B",")",";","}",
            "MR","{","Gives","(","A",",","B",")",";","}",
            "M2","{","Gives","(","X",")",";","Takes","(","B",")",";","}",
            "NN","{","Gives","(","F",")",";","Takes","(","R",")",";","}",
            "AFEF","{","Takes","(","A",",","B",")",";","Takes","(","A",",","X",",","Y",",","R",")",";","}",
            "XA","{","Gives","(","B",")",";","}",
            "XB","{","Gives","(","R",")",";","}"
        };

        [Test]
        public void AcceptanceTokenizerTest()
        {
            Assert.AreEqual(acceptanceTestResult, new Tokenizer().Tokenize(acceptanceStringInput));
        }

        [Test]
        public void SkipWhiteTest()
        {
            Assert.AreEqual("BACKMIHERO", Tokenizer.RemoveWhiteSpaces("BACK MI HERO")); 
        }



    }
    

}


