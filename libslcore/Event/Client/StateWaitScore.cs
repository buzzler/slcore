using System;
using SLCore.Entity;

namespace SLCore.Event.Client
{
    public class StateWaitScore : StateBase
    {
        private GameClient _client;
        
        public StateWaitScore(StateMachineBase stateMachine) : base(stateMachine)
        {
            _client = (GameClient) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            Foo();
        }

        #endregion

        #region Processes
        
        private void Foo()
        {
            Console.WriteLine("FOO: {0}", _client);
        }
        
        #endregion
    }
}