using SLCore.Data;
using SLCore.Event;
using SLCore.Event.Host;

namespace SLCore.Entity
{
    public class GameHost : StateMachineBase
    {
        internal int Id { get; }
        internal readonly HostData Data;
        internal readonly HostDispatcher Dispatcher;

        internal GameHost(HostData data, HostDispatcher dispatcher)
        {
            Id = -1;
            Dispatcher = dispatcher;
            Data = data;
        }

        public void Start()
        {
            StartState(new StateReadyHost(this));
        }
        
        public override string ToString()
        {
            return $"Host({Id})";
        }
    }
}