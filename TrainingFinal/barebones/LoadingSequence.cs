using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LoadingSequence : ILoadingSequence
    {
        public List<List<IElement>> Sequence { get; set; } = new List<List<IElement>>();

        public void AddLoadingStep(List<IElement> elements)
        {
            this.Sequence.Add(elements);
        }

        public void AddLoadingStep(IElement element)
        {
            this.AddLoadingStep(new List<IElement>() { element });
        }
    }
}
