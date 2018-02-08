using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Command
{
    class NullCommand : ICommand
    {
        public void Execute( ) 
        { 
            Console.WriteLine("hab kein Befehl gefunden :(");
        }
    }
}
