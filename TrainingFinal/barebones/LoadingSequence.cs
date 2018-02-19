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

        public override bool Equals(object obj)
        {
            var temp = obj as LoadingSequence;

            if (this.Sequence.Count != temp.Sequence.Count) return false;

            for (int i = 0; i < this.Sequence.Count; i++)
            {
                if (this.Sequence[i].Count != temp.Sequence[i].Count) return false;

                for (int j = 0; j < this.Sequence[i].Count; j++)
                {
                    if (this.Sequence[i][j].Equals(temp.Sequence[i][j]) == false)
                    {
                        return false;
                    }
                }
            }

            var b = this.NotLoadedElements.SequenceEqual(temp.NotLoadedElements);
            return b;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
