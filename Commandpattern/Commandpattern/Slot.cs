using ConsoleApp6.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Slot
    {
        public Owner Owner { get; set; }
        public ICommand Command { get; set; }
       
        
        
    }
}
