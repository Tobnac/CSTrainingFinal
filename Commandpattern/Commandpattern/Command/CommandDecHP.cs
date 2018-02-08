using ConsoleApp6.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Command
{
    class CommandDecHP : ICommand
    {
        private ITarget target;

        public CommandDecHP(ITarget target)
        {
            this.target = target;
        }

        public void Execute()
        {
            Console.WriteLine("Greife Ziel an!");
            target.DecreaseHP();
        }
    }
}
