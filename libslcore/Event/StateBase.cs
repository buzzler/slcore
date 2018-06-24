using System;

namespace SLCore.Event
{
    public class StateBase : IDisposable
    {
        public const int Timeout = 60000;
        public StateMachineBase StateMachine { get; private set; }

        public StateBase(StateMachineBase stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void OnEnterState(StateBase prevState)
        {
        }

        public virtual void OnLoop()
        {
        }

        public virtual void OnExitState(StateBase nextState)
        {
        }

        public virtual void Dispose()
        {
            StateMachine = null;
        }
    }
}