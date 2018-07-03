using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLCore.Data;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateSettingHost : StateBase
    {
        private readonly GameHost _host;

        public StateSettingHost(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _host.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            Task.Delay(100).ContinueWith(Setting);
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _host.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
        }

        #endregion

        #region EventHandlers

        private void OnPublicEvent(object sender, GameEventArgs gameEventArgs)
        {
            switch (gameEventArgs.Type)
            {
                case EventType.FlipNewCard:
                    OnEventFlipNewCard(gameEventArgs);
                    break;
                case EventType.GameStart:
                    OnEventGameStart(gameEventArgs);
                    break;
            }
        }
        
        #endregion

        #region Processes

        private void Setting(Task task)
        {
            ClearCard();
            ShuffleCard();
            PassingCard();
            
            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.GameStart));
        }

        private void ClearCard()
        {
            var pubdata = _host.Data.PublicData;
            pubdata.HostKnown.Clear();
            foreach (var clientKnown in pubdata.ClientKnowns)
                clientKnown.Clear();
            foreach (var clientUknown in _host.Data.ClientsDatas)
                clientUknown.Unknown.Clear();
            var pridata = _host.Data.PrivateData;
            pridata.Unknown.Clear();

            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.ClearCard));
        }

        private void ShuffleCard()
        {
            var count = CardInfo.Count;
            var list = new List<int>(count);
            for (var i = 1; i <= count; i++)
                list.Add(i);

            var rnd = new Random();
            var shuffle = list.OrderBy(a => rnd.Next());
            var pridata = _host.Data.PrivateData;
            foreach (var i in shuffle)
                pridata.Unknown.Add(i, CardInfo.Get(i));

            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.ShuffleCard));
        }

        private void PassingCard()
        {
            int GetLastCardInfo()
            {
                var unknown = _host.Data.PrivateData.Unknown;
                return unknown.Keys.ElementAt(unknown.Count - 1);
            }

            int GetNextId(int current, bool forward)
            {
                var c = _host.Data.GetClientCount();
                if (forward)
                {
                    current++;
                    return current == c ? 0 : current;
                }

                if (current == 0)
                    return c - 1;
                return current - 1;
            }

            void Flip(int num)
            {
                for (var i = 0; i < num; i++)
                {
                    var id = GetLastCardInfo();
                    _host.Data.PrivateData.Unknown.Remove(id);
                    _host.Data.PublicData.HostKnown.Add(id, CardInfo.Get(id));
                    _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.FlipNewCard, -1, id));
                }
            }

            void Take(int client, int num)
            {
                for (var i = 0; i < num; i++)
                {
                    var id = GetLastCardInfo();
                    _host.Data.PrivateData.Unknown.Remove(id);
                    _host.Data.GetClientData(client).Unknown.Add(id, CardInfo.Get(id));
                    _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.TakeNewCard, client));
                    _host.Dispatcher.PrivateDispatchers[client].Dispatch(new GameEventArgs(EventType.TakeNewCard, client, id));
                }
            }

            var count = _host.Data.GetClientCount();
            var leader = _host.Data.Leader;
            var order = (count == 2) ? new[] {4,5,4,5} : new[] {3,4,3,3};

            Flip(order[0]);
            
            var turn = GetNextId(leader, false);
            for (var j = 0 ; j < count ; j++)
            {
                Take(turn, order[1]);
                turn = GetNextId(turn, false);
            }
            
            Flip(order[2]);
            
            turn = leader;
            for (var j = 0 ; j < count ; j++)
            {
                Take(turn, order[3]);
                turn = GetNextId(turn, true);
            }
        }
        
        private void OnEventFlipNewCard(GameEventArgs gameEventArgs)
        {
            var id = gameEventArgs.ClientId;
            if (id == _host.Id)
            {
                var cardInfo = CardInfo.Get(gameEventArgs.CardId);
                Console.WriteLine("{0} open {1}", _host, cardInfo);
            }
        }

        private void OnEventGameStart(GameEventArgs gameEventArgs)
        {
            _host.ChangeState(new StateCheckScore(_host));
        }

        #endregion
    }
}