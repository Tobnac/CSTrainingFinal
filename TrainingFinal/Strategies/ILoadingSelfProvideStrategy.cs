using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public interface ILoadingSelfProvideStrategy
    {
        // based on SelfProvideStrat:
        // - add the resources the current element provides to the currently available resources
        // - or not 
        List<IResource> ExpandAvailableResources(List<IResource> availableResoucres, IElement element);
    }
}
