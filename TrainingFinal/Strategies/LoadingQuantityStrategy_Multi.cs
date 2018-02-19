using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LQS_Multi : ILoadingQuantityStrategy
    {
        public List<IElement> ResolveLoadingSequence(List<IElement> elements, ILoadingSequence resultSequence)
        {
            resultSequence.AddLoadingStep(elements);
            return elements;
        }
    }
}
