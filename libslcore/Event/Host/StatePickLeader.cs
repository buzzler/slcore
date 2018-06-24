using System;
using System.Collections.Generic;
using System.Linq;
using SLCore.Data;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StatePickLeader : StateBase
    {
        private readonly GameHost _host;

        public StatePickLeader(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            ClearCard();
            ShuffleCard();
            FlipCard();
            _host.ChangeState(new StateSettingHost(_host));
        }

        #endregion

        #region Processes

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

        private void FlipCard()
        {
            var highest = 0;
            var leader = 0;

            var known = _host.Data.PublicData.HostKnown;
            var unknown = _host.Data.PrivateData.Unknown;
            var count = _host.Data.GetClientCount();
            for (var i = 0; i < count; i++)
            {
                var last = unknown.Keys.ElementAt(unknown.Count - 1);
                var cardinfo = unknown[last];
                unknown.Remove(last);
                known.Add(cardinfo.Id, cardinfo);

                if (last > highest)
                {
                    highest = last;
                    leader = i;
                }

                _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.FlipNewCard, i, last));
            }

            _host.SetLeader(leader);
            _host.SetTurn(leader);
            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.Leader, leader));
        }

        #endregion
    }
}