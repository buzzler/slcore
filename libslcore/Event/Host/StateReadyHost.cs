using System;
using System.Threading;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateReadyHost : StateBase
    {
        private GameHost _host;
        
        public StateReadyHost(StateMachineBase stateMachine) : base(stateMachine)
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
            AskReady();
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

        private void OnPrivateEvent(object sender, GameEventArgs args)
        {
        }

        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.Join:
                    OnEventJoin(args);
                    break;
                case EventType.Demit:
                    break;
            }
        }

        private void OnEventJoin(GameEventArgs args)
        {
            var clients = _host.Data.GetClientCount();
            if (clients >= 2)
                AskReady();
        }

        #endregion
        
        #region Processes

        private void AskReady()
        {
            var total = _host.Dispatcher.PrivateDispatchers.Count;
            var count = 0;
            using (var autoReset = new AutoResetEvent(false))
            {
                void OnReady(object sender, GameEventArgs e)
                {
                    if (e.Type != EventType.Ok)
                        return;
                    count++;
                    if (count == total)
                        autoReset.Set();
                }

                Console.WriteLine("{0} says R U ready?", _host);
                foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                {
                    dispatcher.Event += OnReady;
                    dispatcher.Dispatch(new GameEventArgs(EventType.IsReady));
                }

                if (!autoReset.WaitOne(Timeout))
                    throw new TimeoutException();
                
                foreach (var dispatcher in _host.Dispatcher.PrivateDispatchers)
                    dispatcher.Event -= OnReady;
            }
            _host.ChangeState(new StatePickLeader(_host));
        }

        #endregion
    }
}