using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    public class StateParser
    {
        private State state;
        public void Parse(string s)
        {
            this.state.EvaluateChar(s);
        }

        public void SetState(State state)
        {
            state.parent = this;
            this.state = state;
        }
    }

    public class State
    {
        public List<StateRule> Rules = new List<StateRule>();
        public StateParser parent;

        public void EvaluateChar(string s)
        {
            foreach (var rule in this.Rules)
            {
                if (rule.Validate(s))
                {
                    if (rule.TransitionState != null)
                    {
                        this.parent.SetState(rule.TransitionState);
                    }

                    rule.StringAction?.Invoke(s);
                    return;
                }
            }

            Console.WriteLine("Error, couldnt match to rule");
        }
    }

    public class StateRule
    {
        public Func<string, bool> Validate; // do I match to this input string?
        public State TransitionState; // if i match it. i'll change the state to this
        public Action<string> StringAction; // if i match, i'll do this with the input
    }
}
