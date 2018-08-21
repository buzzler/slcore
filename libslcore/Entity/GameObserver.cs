using SLCore.Data;
using SLCore.Event;

namespace SLCore.Entity
{
    public class GameObserver : StateMachineBase
    {
        private Dispatcher _dispatcher;
        private ObserverData _data;

        public int Id { get; }
        
        internal GameObserver(int id, Dispatcher dispatcher, ObserverData data)
        {
            Id = id;
            _dispatcher = dispatcher;
            _data = data;
        }
        
        public override string ToString()
        {
            return $"Observer({Id})";
        }
    }
}