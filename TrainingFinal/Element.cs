using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class Element : IElement
    {
        public List<IResource> GetProvision()
        {
            throw new NotImplementedException();
        }

        public List<IResource> GetRequirements()
        {
            throw new NotImplementedException();
        }

        public bool IsSelfproviding()
        {
            throw new NotImplementedException();
        }
    }
}
