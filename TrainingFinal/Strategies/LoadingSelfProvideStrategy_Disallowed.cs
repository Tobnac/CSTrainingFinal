using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LSPS_Disallowed : ILoadingSelfProvideStrategy
    {
        public List<IResource> ExpandAvailableResources(List<IResource> availableResoucres, IElement element)
        {
            return availableResoucres;
        }
    }
}
