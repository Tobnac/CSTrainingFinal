using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LQS_Single : ILoadingQuantityStrategy
    {
        public ILoadingSelfProvideStrategy SelfProvideStrategy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IElement> ElementList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ILoadingSequence ResolveLoadingSequence(List<IElement> elements)
        {
            throw new NotImplementedException();
        }
    }
}
