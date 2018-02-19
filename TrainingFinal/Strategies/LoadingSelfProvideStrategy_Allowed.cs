using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LSPS_Allowed : ILoadingSelfProvideStrategy
    {
        public List<IResource> ExpandAvailableResources(List<IResource> availableResoucres, IElement element)
        {
            element.Provisions.ForEach(x => availableResoucres.Add(x));
            return availableResoucres;
        }
    }
}
