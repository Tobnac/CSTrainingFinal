using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dic = new AutoDictionary<string>();

            //dic.Register("Tom");
            //dic.Register("Hans");
            //dic.Register("JJ (aka. Aidsvieh)");

            //bool b = dic["Tom"] == 0;

            //int x = 5;

            //Console.WriteLine(x++); // prints 5. increase x to 6
            //Console.WriteLine(++x); // increase x to 7, prints 7










            // file
            // input: code string
            // lexer -> transform long code string into many single tokens for each word/symbol + trim spaces, enter, tab
            // parser -> interprets tokens/words into elementName, identifier, resource name based on context
            // LoadingProcessor -> processes all elements and creates a LoadingSequence as a result
            // quantityStrategy ( + selfProvideStrategy)
            // sequenceVisualizer -> transforms the sequence into a visual picture in the console



            // 1. read input file into string -> string

            // 2. parse+sanitise string into strongList -> List<string>
            // 2.1 write stateParser itself
            // 2.2 define states + rules: skip whitespaces/enter/tab, list 'keywords': ( ) { } ;
            // 2.3 create stringList (+ insert word into each)

            // 3. evaluate strings into elements -> ElementName, syntax (braces, semicolons), resourceName, identifier(gives/takes) -> List<IElement>
            // 3.1 use stateParser from 2.3
            // 3.2 defome states + rules:
            // ROOT -> 0-n GRAMMAR
            // GRAMMAR -> string + { + INNER_ELEMENT + } // --> creates new "currentElement"
            // INNER_ELEMENT -> 1-n COMMAND
            // INNER_ELEMENT -> e
            // COMMAND -> IDENTIFIER + ( + PARAMLIST + ); // --> creates and adds Resources to currentElement (as requirement or provision)
            // IDENTIFIER -> "Gives" | "Takes"
            // PARAMLIST -> PARAM | e
            // PARAM -> string | string , PARAM

            // 4. determine order of elements to load/activate using strategy for quantity + selfSupply
            // var allElements
            //  V filterLoadable():
            //  V var loadedRecourses (modifyed by LoadingSelfProvideStrategys)
            //  V if all Requirements are in loadedRecourses => add element in:
            // var canBeLoaded
            //  V LoadingQuantityStrategy-elements are loaded
            // var currentStepElements
            //  V currentStepElements are saved in haveBeenLoaded
            // var haveBeenLoaded
            // repeat until allElements or canBeLoaded is empty
            // 
            // 
            // 
            // 
            // 
            // 
            // 5. visualize result-order















            // optional modules:
            // - random tree generator
            // -> instead of code string + parser

            // ToDo:

            // basics:
            // - parser
            // - element
            // - resource
            // - loadingSequence -> required elements
            // - selfProvideStrategy -> requires basics
            // - quantityStrategy -> requires selfProvideStrategy
            // - SequenceVisualizer 
            // - loadingProcessor (init, selection of strategies, ...)
            // main Program class -> requires everything
            // optional:
            // - randomTreeGenerator
        }
    }
}
