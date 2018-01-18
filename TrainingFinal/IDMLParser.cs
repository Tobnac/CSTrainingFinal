using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    interface IDMLParser
    {
        List<IElement> Parse(string code);
    }
}
