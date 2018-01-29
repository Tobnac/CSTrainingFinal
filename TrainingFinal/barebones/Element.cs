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
        public List<IResource> Requirements { get; set; } = new List<IResource>();
        public List<IResource> Provisions { get; set; } = new List<IResource>();

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

            if (this.Name != temp.Name) return false;
            if (this.Requirements.Count != temp.Requirements.Count) return false;
            if (this.Provisions.Count != temp.Provisions.Count) return false;

            for (var i = 0; i < this.Requirements.Count; i++)
            {
                if (!this.Requirements[i].Equals(temp.Requirements[i])) return false;
            }
            for (var i = 0; i < this.Provisions.Count; i++)
            {
                if (!this.Provisions[i].Equals(temp.Provisions[i])) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -1741313576;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<IResource>>.Default.GetHashCode(Requirements);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<IResource>>.Default.GetHashCode(Provisions);
            return hashCode;
        }
    }
}
