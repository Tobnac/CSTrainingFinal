using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public static class Helper
    {
        public static List<IResource> ConvertToResourceList(params string[] input)
        {
            var result = new List<IResource>();

            foreach (var res in input)
            {
                result.Add(new Resource(res));
            }

            return result;
        }
    }
}
