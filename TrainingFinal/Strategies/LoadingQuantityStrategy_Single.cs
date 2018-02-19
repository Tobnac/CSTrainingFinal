using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LQS_Single : ILoadingQuantityStrategy
    {
        public List<IElement> ResolveLoadingSequence(List<IElement> elements, ILoadingSequence resultSequence)
        {
            var ele = elements.First();
            resultSequence.AddLoadingStep(ele);
            return new List<IElement>() { ele };
        }
    }

}
