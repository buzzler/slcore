using System;
using System.Linq;
using System.Threading.Tasks;
using SLCore.Data;
using SLCore.Entity;

namespace SLCore.Event.Client
{
    public class StateCheckTurn : StateBase
    {
        private GameClient _client;
        
        public StateCheckTurn(StateMachineBase stateMachine) : base(stateMachine)
        {
            _client = (GameClient) stateMachine;
        }
        
        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _client.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            
            Task.Delay(100).ContinueWith(Check);
        }

        private void Check(Task task)
        {
            if (_client.Data.PrivateData.Unknown.Count <= 0)
                throw new Exception();
            var cardId = _client.Data.PrivateData.Unknown.ElementAt(0).Key;
            
            Console.WriteLine($"{_client} open {CardInfo.Get(cardId)}" );
            _client.Dispatcher.PublicDispatcher.Dispatch(new GameEventArgs(EventType.OpenCard, _client.Id, cardId));
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _client.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
        }
        
        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.FlipNewCard:
                    OnEventFlipNewCard(args);
                    break;
            }
        }

        private void OnEventFlipNewCard(GameEventArgs args)
        {
            _client.ChangeState(new StateWaitScore(_client));
        }
    }
}