using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LSPS_Disallowed : ILoadingSelfProvideStrategy
    {
        public bool CanBeLoaded(IElement element, List<IResource> availableResources)
        {
            throw new NotImplementedException();
        }
    }
}
