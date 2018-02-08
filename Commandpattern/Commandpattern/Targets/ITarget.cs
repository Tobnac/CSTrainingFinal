using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Targets
{
    public interface ITarget
    {
        int HP { get;  }
        void IncreaseHP();
        void DecreaseHP();
        void MakeHigh();
    }
}
