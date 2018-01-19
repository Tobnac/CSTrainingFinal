using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface IElement
    {
        string Name { get; set; }
        // list of resources that this Element required to be loaded (and thus provide it's own resources)
        List<IResource> Requirements { get; set; }
        // list of resources that this Element provides
        List<IResource> Provisions { get; set; }

    }
}
