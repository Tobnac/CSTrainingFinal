using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class Element : IElement
    {
        public string Name { get; set; }
        public List<IResource> Requirements { get; set; }
        public List<IResource> Provisions { get; set; }

        public Element()
        {

        }

        public Element(string name)
        {
            this.Name = name;
        }

        public Element(string name, List<IResource> requirements, List<IResource> provisions)
        {
            this.Name = name;
            this.Requirements = requirements;
            this.Provisions = provisions;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Element)) return false;
            var temp = obj as Element;
            return
                (
                    this.Name.Equals(temp.Name) &&
                    this.Requirements.Equals(temp.Requirements) &&
                    this.Provisions.Equals(temp.Provisions)
                );
        }
    }
}
