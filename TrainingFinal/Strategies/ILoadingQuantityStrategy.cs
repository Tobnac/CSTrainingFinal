using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface ILoadingQuantityStrategy
    {
        List<IElement> ResolveLoadingSequence(List<IElement> elements, ILoadingSequence resultSequence);
    }
}
