using System;
using System.Threading;
using System.Threading.Tasks;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateResultHost : StateBase
    {
        private GameHost _host;

        private int totalResponse;
        private int countResponse;
        
        public StateResultHost(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
            totalResponse = _host.Data.GetClientCount();
            countResponse = 0;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _host.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                dispatcher.Event += OnPrivateEvent;

            Task.Delay(100).ContinueWith(AskPlayAgain);
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _host.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
            foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                dispatcher.Event -= OnPrivateEvent;
        }
        
        #endregion

        #region Processes

        private void AskPlayAgain(Task task)
        {
            foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                dispatcher.Dispatch(new GameEventArgs(EventType.PlayAgain));
        }
        
        #endregion
        
        #region EventHandlers

        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.NewGame:
                    // TODO : winner is next leader
                    _host.Data.SetLeader(1);
                    _host.Data.SetTurnCount(0);
                    _host.ChangeState(new StateSettingHost(_host));
                    break;
                case EventType.ExitGame:
                    _host.ChangeState(new StateReadyHost(_host));
                    break;
            }
        }
        
        private void OnPrivateEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.Ok:
                    countResponse++;
                    if (totalResponse == countResponse)
                        _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.NewGame));
                    break;
                case EventType.Cancel:
                    _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.ExitGame));
                    break;
            }
        }
        
        #endregion
    }
}