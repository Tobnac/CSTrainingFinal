using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Targets
{
    public class NeutralMob : ITarget
    {
        private int hp = 10;

        public int HP
        {
            get { return hp; }
            private set
            {
                if (this.IsDead())
                {
                    Console.WriteLine("Target is dead.");
                    return;
                }
                    
                if (value >= 10)
                {
                    value = 10; 
                }
                if (value <= 0)
                {
                    value = 0;  
                }

                hp = value;
                Console.WriteLine($"Target has {value} HP");
 
            }
        }

        private bool IsDead()
        {
            return (this.HP <= 0);
        }

        public void DecreaseHP()
        {
            HP--;
        }

        public void IncreaseHP()
        {
            HP++;
        }

        public void MakeHigh()
        { 
        }
    }
}
