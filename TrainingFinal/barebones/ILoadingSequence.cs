using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public interface ILoadingSequence
    {
        // first index = loaded first, ...
        // every index can load multiple elements simultaniously
        List<List<IElement>> Sequence { get; set; }

        void AddLoadingStep(List<IElement> elements);
        void AddLoadingStep(IElement element);

        // Sequence.Length
    }
}
