using ConsoleApp6.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Command
{
    class CommandIncHP : ICommand
    {
        private ITarget target;

        public CommandIncHP(ITarget target)
        {
            this.target = target; 
        }

        public void Execute()
        {
            Console.WriteLine("Heale Mob!");
            target.IncreaseHP();
        }
    }
}
