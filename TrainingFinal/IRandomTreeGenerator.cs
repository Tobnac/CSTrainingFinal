using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface IRandomTreeGenerator
    {
        List<IElement> GenerateTree(int nodeCount, int dependancyCount, float averageDependancyCount);
    }
}
