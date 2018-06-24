using System;
using SLCore.Data;
using SLCore.Entity;

namespace SLCore.Event.Client
{
    public class StateReadyClient : StateBase
    {
        public GameClient _client;
        
        public StateReadyClient(StateMachineBase stateMachine) : base(stateMachine)
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
                case EventType.IsReady:
                    OnEventIsReady(gameEventArgs);
                    break;
            }
        }

        private void OnPublicEvent(object sender, GameEventArgs gameEventArgs)
        {
            switch (gameEventArgs.Type)
            {
                case EventType.ClearCard:
                    OnEventClear(gameEventArgs);
                    break;
                case EventType.ShuffleCard:
                    OnEventShuffleCard(gameEventArgs);
                    break;
                case EventType.FlipNewCard:
                    OnEventFlipNewCard(gameEventArgs);
                    break;
                case EventType.Leader:
                    OnEventLeader(gameEventArgs);
                    break;
            }
        }

        #endregion

        #region Processes

        private void OnEventIsReady(GameEventArgs gameEventArgs)
        {
            Console.WriteLine("{0} Ok, I'm ready.", _client);
            _client.Dispatcher.PrivateDispatcher.Dispatch(new GameEventArgs(EventType.Ok, _client.Id));
        }

        private void OnEventClear(GameEventArgs gameEventArgs)
        {
        }

        private void OnEventShuffleCard(GameEventArgs gameEventArgs)
        {
        }

        private void OnEventFlipNewCard(GameEventArgs gameEventArgs)
        {
            
            if (_client.Id == gameEventArgs.ClientId)
            {
                var cardInfo = CardInfo.Get(gameEventArgs.CardId);
                Console.WriteLine("{0} open {1}", _client, cardInfo);
            }
        }

        private void OnEventLeader(GameEventArgs gameEventArgs)
        {
            var leader = gameEventArgs.ClientId;
            if (_client.Id == leader)
                Console.WriteLine("{0} is the Leader.", _client);
            
            _client.ChangeState(new StateSettingClient(_client));
        }

        #endregion
    }
}