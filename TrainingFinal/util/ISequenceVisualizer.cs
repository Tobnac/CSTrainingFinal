using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public interface ISequenceVisualizer
    {
        // prints the order + elements into the console
        // (which element first, maybe info about this element, ...)
        void Visualize(ILoadingSequence sequence);
    }
}
