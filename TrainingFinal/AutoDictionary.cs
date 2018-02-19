using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public class AutoDictionary<T>
    {
        public Dictionary<T, int> ValueDictionary { get; set; } = new Dictionary<T, int>();

        public int this[T key]
        {
            get
            {
                if (!this.ValueDictionary.ContainsKey(key)) return 0;
                return this.ValueDictionary[key];
            }

            set
            {
                if (!this.ValueDictionary.ContainsKey(key))
                {
                    this.ValueDictionary.Add(key, value);
                }
                else
                {
                    this.ValueDictionary[key] = value;
                }
            }
            
        }

        public int Register(T key)
        {
            return ++this.ValueDictionary[key];
        }

        public void RegisterRange(IEnumerable<T> keys)
        {
            keys.ToList().ForEach(x => this.Register(x));
        }

    }
}
