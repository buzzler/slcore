using SLCore.Data;
using SLCore.Event;
using SLCore.Event.Client;

namespace SLCore.Entity
{
    public class GameClient : StateMachineBase
    {
        internal int Id { get; set; }
        internal readonly ClientData Data;
        internal readonly ClientDispatcher Dispatcher;

        internal GameClient(int id, ClientData data, ClientDispatcher dispatcher)
        {
            Id = id;
            Data = data;
            Dispatcher = dispatcher;

            StartState(new StateReadyClient(this));
        }

        public override string ToString()
        {
            return $"Client({Id})";
        }
    }
}