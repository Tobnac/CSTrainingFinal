using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface ILoadingSequence
    {
        // first index = loaded first, ...
        // every index can load multiple elements simultaniously
        List<List<IElement>> Sequence { get; set; }

        // Sequence.Length
    }
}
