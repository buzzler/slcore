using System;
using System.Linq;
using SLCore.Data;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateWaitTurn : StateBase
    {
        private GameHost _host;
        
        public StateWaitTurn(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _host.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _host.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
        }

        #endregion

        #region EventHandlers

        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.OpenCard:
                    OnEventOpenCard(args);
                    break;
                case EventType.FlipNewCard:
                    OnEventFlipNewCard(args);
                    break;
            }
        }

        private void OnEventOpenCard(GameEventArgs args)
        {
            var cardId = args.CardId;
            var clientId = args.ClientId;
            
            var pubdata = _host.Data.PublicData;
            var pridata = _host.Data.PrivateData;
            var clientdata = _host.Data.GetClientData(clientId);
            
            if (!clientdata.Unknown.ContainsKey(cardId))
                throw new ArgumentException();

            clientdata.Unknown.Remove(cardId);
            pubdata.HostKnown.Add(cardId, CardInfo.Get(cardId));

            var flip = pridata.Unknown.ElementAt(pridata.Unknown.Count - 1).Value;
            pridata.Unknown.Remove(flip.Id);
            pubdata.HostKnown.Add(flip.Id, flip);
            
            _host.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.FlipNewCard, clientId, flip.Id));
        }

        private void OnEventFlipNewCard(GameEventArgs args)
        {
            Console.WriteLine($"{_host} flip {CardInfo.Get(args.CardId)}");
            _host.ChangeState(new StateCheckScore(_host));
        }

        #endregion
    }
}