using System;

namespace SLCore.Event
{
    public class GameEventArgs : EventArgs
    {
        public EventType Type { get; }
        public int ClientId { get; }
        public int CardId { get; }
        
        public GameEventArgs(EventType type)
        {
            Type = type;
        }

        public GameEventArgs(EventType type, int clientId)
        {
            Type = type;
            ClientId = clientId;
        }
        
        public GameEventArgs(EventType type, int clientId, int cardId)
        {
            Type = type;
            ClientId = clientId;
            CardId = cardId;
        }
    }
}