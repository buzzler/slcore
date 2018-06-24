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
            AskReady();
            _host.ChangeState(new StatePickLeader(_host));
        }

        public override void Dispose()
        {
            base.Dispose();
            _host = null;
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
        }

        #endregion
    }
}