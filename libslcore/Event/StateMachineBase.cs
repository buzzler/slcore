using System.Collections.Generic;

namespace SLCore.Event
{
    public class StateMachineBase
    {
        internal StateBase CurrentState;

        internal void StartState(StateBase newState)
        {
            CurrentState = newState;
            CurrentState.OnEnterState(null);
        }

        internal void LoopState()
        {
            CurrentState?.OnLoop();
        }

        internal void ChangeState(StateBase newState)
        {
            CurrentState?.OnExitState(newState);
            var prev = CurrentState;
            CurrentState = newState;
            CurrentState?.OnEnterState(prev);
        }
    }
}