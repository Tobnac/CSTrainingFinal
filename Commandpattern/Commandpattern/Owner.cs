using ConsoleApp6.Targets;

namespace ConsoleApp6
{
    public class Owner
    {
        public ITarget CurrentTarget { get; set; } = new NeutralMob();
        public Toolbar Toolbar { get; set; }

        public Owner()
        {
            Toolbar = new Toolbar(this);
        }

        public void UseSlot(int index)
        {
            Toolbar.ExecuteSlot(index);
        }
    }
}