using System;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateResultHost : StateBase
    {
        private GameHost _host;
        
        public StateResultHost(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _host.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                dispatcher.Event += OnPrivateEvent;
            
            Console.WriteLine($"{_host} result");
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _host.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
            foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                dispatcher.Event -= OnPrivateEvent;
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