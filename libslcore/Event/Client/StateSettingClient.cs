using System;
using SLCore.Data;
using SLCore.Entity;

namespace SLCore.Event.Client
{
    public class StateSettingClient : StateBase
    {
        public GameClient _client;
        
        public StateSettingClient(StateMachineBase stateMachine) : base(stateMachine)
        {
            _client = (GameClient) stateMachine;
        }
        
        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);

            var dispatcher = _client.Dispatcher;
            dispatcher.PublicDispatcher.Event += OnPublicEvent;
            dispatcher.PrivateDispatcher.Event += OnPrivateEvent;
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            
            var dispatcher = _client.Dispatcher;
            dispatcher.PublicDispatcher.Event -= OnPublicEvent;
            dispatcher.PrivateDispatcher.Event -= OnPrivateEvent;
        }

        #endregion
        
        #region Event Handlers

        private void OnPrivateEvent(object sender, GameEventArgs gameEventArgs)
        {
            switch (gameEventArgs.Type)
            {
                case EventType.TakeNewCard:
                    OnEventTakeNewCard(gameEventArgs);
                    break;
            }
        }

        private void OnPublicEvent(object sender, GameEventArgs gameEventArgs)
        {
            switch (gameEventArgs.Type)
            {
                case EventType.ClearCard:
                    break;
                case EventType.ShuffleCard:
                    break;
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

        private void OnEventFlipNewCard(GameEventArgs gameEventArgs)
        {
        }

        private void OnEventTakeNewCard(GameEventArgs gameEventArgs)
        {
            var id = gameEventArgs.ClientId;
            if (_client.Id == id)
            {
                var cardInfo = CardInfo.Get(gameEventArgs.CardId);
                Console.WriteLine("{0} got {1}", _client, cardInfo);
            }
        }

        private void OnEventGameStart(GameEventArgs gameEventArgs)
        {
            _client.ChangeState(new StateWaitScore(_client));
        }

        #endregion
    }
}