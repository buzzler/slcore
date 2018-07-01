using System;
using SLCore.Entity;

namespace SLCore.Event.Client
{
    public class StateResultClient : StateBase
    {
        private GameClient _client;
        
        public StateResultClient(StateMachineBase stateMachine) : base(stateMachine)
        {
            _client = (GameClient) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _client.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            _client.Dispatcher.PrivateDispatcher.Event += OnPrivateEvent;
            
            Console.WriteLine($"{_client} result");
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _client.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
            _client.Dispatcher.PrivateDispatcher.Event -= OnPrivateEvent;

        }
        
        #endregion

        #region EventHandlers

        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        private void OnPrivateEvent(object sender, GameEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}