using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface ILoadingSelfProvideStrategy
    {
        // evaluated if the specified element can be loaded with the currently availabel resources.
        // Depending on the selected strategy, an element can use its own provision-resources to load itself or not.
        bool CanBeLoaded(IElement element, List<IResource> availableResources);
    }
}
