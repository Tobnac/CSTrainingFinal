using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface ILoadingProcessor
    {
        // specifies if multiple elements can be loaded within one step
        ILoadingQuantityStrategy QuantityStrategy { get; set; }

        // specifies if an element can self-provide (if it only requires resources that are given and ones it provides itself)
        ILoadingSelfProvideStrategy SelfProvideStragegy { get; set; }

        ILoadingSequence Process(List<IElement> elements);
    }
}
