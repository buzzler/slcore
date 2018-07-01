using System;
using SLCore.Entity;

namespace SLCore.Event.Client
{
    public class StateWaitScore : StateBase
    {
        private GameClient _client;
        
        public StateWaitScore(StateMachineBase stateMachine) : base(stateMachine)
        {
            _client = (GameClient) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            _client.Dispatcher.PublicDispatcher.Event += OnPublicEvent;
            _client.Dispatcher.PrivateDispatcher.Event += OnPrivateEvent;
        }

        public override void OnExitState(StateBase nextState)
        {
            base.OnExitState(nextState);
            _client.Dispatcher.PublicDispatcher.Event -= OnPublicEvent;
            _client.Dispatcher.PrivateDispatcher.Event -= OnPrivateEvent;
        }
        
        #endregion

        #region EventHandlers

        private void OnPublicEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.GameStop:
                    OnEventGameStop(args);
                    break;
                case EventType.Turn:
                    OnEventTurn(args);
                    break;
            }
        }

        private void OnPrivateEvent(object sender, GameEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.Win:
                    OnEventWin(args);
                    break;
                case EventType.Lose:
                    OnEventLose(args);
                    break;
            }
        }

        private void OnEventTurn(GameEventArgs args)
        {
            if (args.ClientId == _client.Id)
            {
                _client.ChangeState(new StateCheckTurn(_client));
            }
        }

        private void OnEventGameStop(GameEventArgs args)
        {
            _client.ChangeState(new StateResultClient(_client));
        }

        private void OnEventWin(GameEventArgs args)
        {
            Console.WriteLine($"{_client} Win!");
        }

        private void OnEventLose(GameEventArgs args)
        {
            Console.WriteLine($"{_client} Lose..");
        }

        #endregion
    }
}