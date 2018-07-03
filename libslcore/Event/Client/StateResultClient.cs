using System;
using System.Threading.Tasks;
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
            switch (args.Type)
            {
                case EventType.NewGame:
                    _client.ChangeState(new StateSettingClient(_client));
                    break;
                case EventType.ExitGame:
                    _client.ChangeState(new StateReadyClient(_client));
                    break;
            }
        }

        private void OnPrivateEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.PlayAgain:
                    Task.Delay(100).ContinueWith(task =>
                    {
                        _client.Dispatcher.PrivateDispatcher.Dispatch(new GameEventArgs(EventType.Ok, _client.Id));
                    });
                    break;
            }
        }

        #endregion
    }
}