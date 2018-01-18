using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface IElement
    {
        // element required resource X but also provides it, meaning it can self-provide
        bool IsSelfproviding();

        // list of resources that this Element required to be loaded (and thus provide it's own resources)
        List<IResource> GetRequirements();

        // list of resources that this Element provides
        List<IResource> GetProvision();


    }
}
