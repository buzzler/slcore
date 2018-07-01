using System;
using System.Threading.Tasks;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateCheckScore : StateBase
    {
        private readonly GameHost _host;
        
        public StateCheckScore(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _host.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            Task.Delay(100).ContinueWith(Check);
        }

        private void Check(Task task)
        {
            var data = _host.Data;
            if (data.TurnCount == 0)
            {
                FirstOfGame();
            }
            else
            {
                // check score...
            }
            
            if (data.TurnCount == data.TotalTurnCount)
            {
                LastOfGame();
            }
            else
            {
                NextTurn();
            }
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _host.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
        }

        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.Turn:
                    OnEventTurn(args);
                    break;
                case EventType.GameStop:
                    OnEventGameStop(args);
                    break;
            }
        }

        private void OnEventTurn(GameEventArgs args)
        {
            _host.ChangeState(new StateWaitTurn(_host));
        }
        
        private void OnEventGameStop(GameEventArgs args)
        {
            _host.ChangeState(new StateResultHost(_host));
        }

        #endregion

        #region EventHandlers

        private void FirstOfGame()
        {
            var data = _host.Data;
            var clients = data.GetClientCount();
            
            _host.Data.SetTotalTurnCount(clients * (clients == 2 ? 10 : 7));
            _host.Data.SetTurnCount(0);
                
            if (IsPresident(-1) || IsPresident(data.Leader))
                Console.WriteLine($"WIN:{data.Leader}");
            else
            {
                for (var i = 1; i < clients; i++)
                {
                    var id = (data.Leader + i) % clients;
                    if (IsPresident(id))
                        Console.WriteLine($"WIN:{id}");
                }
            }
        }

        private void LastOfGame()
        {
            Console.WriteLine("WIN:...");
            
            // TODO : check real winner
            // test
            var winner = 1;
            // test
            
            for (var i = 0; i < _host.Dispatcher.PrivateDispatchers.Count; i++)
            {
                var dispatcher = _host.Dispatcher.PrivateDispatchers[i];
                dispatcher.Dispatch(new GameEventArgs(i == winner ? EventType.Win : EventType.Lose, i));
            }
            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.GameStop, winner));
        }

        private void NextTurn()
        {
            var data = _host.Data;
            var clients = data.GetClientCount();
            var next = data.Turn < 0 ? data.Leader : (data.Turn + 1) % clients;
            data.SetTurn(next);
            data.SetTurnCount(data.TurnCount+1);
            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.Turn, data.Turn));
        }

        #endregion
        
        #region Processes

        private bool IsPresident(int id)
        {
            return false;
        }

        private bool Is5Kwang(int id)
        {
            return false;
        }

        private bool Is4Kwang(int id)
        {
            return false;
        }

        private bool Is3Kwang(int id)
        {
            return false;
        }

        private bool IsB3Kwang(int id)
        {
            return false;
        }

        private bool IsGodori(int id)
        {
            return false;
        }

        private bool IsHongDan(int id)
        {
            return false;
        }

        private bool IsChoDan(int id)
        {
            return false;
        }

        private bool IsChungDan(int id)
        {
            return false;
        }

        private bool IsFuck(int id)
        {
            return false;
        }

        private bool IsZock(int id)
        {
            return false;
        }

        #endregion
    }
}