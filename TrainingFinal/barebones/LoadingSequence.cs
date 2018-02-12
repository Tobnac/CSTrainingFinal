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
        public List<IElement> NotLoadedElements { get; set; } = new List<IElement>();

        public LoadingSequence()
        {
                
        }

        public LoadingSequence(List<List<IElement>> sequence , List<IElement> notLoadedElements)
        {
            this.Sequence = sequence;
            this.NotLoadedElements = notLoadedElements;
        }

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
