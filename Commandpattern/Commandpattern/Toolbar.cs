using ConsoleApp6.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Toolbar
    {
        public Owner Owner { get; set; }
        public List<ICommand> Slots { get; set; } = new List<ICommand>();

        public Toolbar(Owner owner)
        {
            Owner = owner;
            InitToolbar();
        }

        public void ExecuteSlot(int index)
        {
            if ((index < 0) || (index > Slots.Count - 1))
            {
                (new NullCommand()).Execute();
                return;
            }

            this.Slots[index].Execute();
        }

        public void InitToolbar()
        {
            Slots.Add(new CommandIncHP(Owner.CurrentTarget));
            Slots.Add(new CommandDecHP(Owner.CurrentTarget));  
        }
    }
}
