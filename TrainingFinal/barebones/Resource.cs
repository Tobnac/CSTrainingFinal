using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class Resource : IResource
    {
        public string ResourceName { get; set; }

        public Resource(string name)
        {
            this.ResourceName = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Resource)) return false;
            return (obj as Resource).ResourceName == this.ResourceName;
        }

        public override int GetHashCode()
        {
            return -1225225530 + EqualityComparer<string>.Default.GetHashCode(this.ResourceName);
        }
    }
}
