using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal.Tokenizer
{
    public class State
    {
        public List<StateRule> rules = new List<StateRule>();
        public StateParser parent;

        public void EvaluateChar(string s)
        {
            foreach (var rule in this.rules)
            {
                if (rule.Validate(s))
                {
                    rule.StringAction?.Invoke(s);
                    if (rule.TransitionState != null)
                    {
                        this.parent.SetState(rule.TransitionState);
                    }
                }
            }
        }
    }

    public class StateRule
    {
        public Func<string, bool> Validate;
        public State TransitionState;
        public Action<string> StringAction;
    }

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
}
