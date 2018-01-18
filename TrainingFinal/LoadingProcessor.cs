using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LoadingProcessor : ILoadingProcessor
    {
        public ILoadingQuantityStrategy QuantityStrategy { get; set; }
        public ILoadingSelfProvideStrategy SelfProvideStragegy { get; set; }

        public ILoadingSequence Process(List<IElement> elements)
        {
            return this.QuantityStrategy.ResolveLoadingSequence(elements);
        }
    }
}
