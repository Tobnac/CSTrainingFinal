using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface ILoadingQuantityStrategy
    {
        ILoadingSelfProvideStrategy SelfProvideStrategy { get; set; }
        List<IElement> ElementList { get; set; }

        ILoadingSequence ResolveLoadingSequence(List<IElement> elements);
    }
}
