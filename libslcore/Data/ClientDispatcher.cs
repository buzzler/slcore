using SLCore.Event;

namespace SLCore.Data
{
    public class ClientDispatcher
    {
        public Dispatcher PublicDispatcher { get; }
        public Dispatcher PrivateDispatcher { get; }

        public ClientDispatcher(Dispatcher publicDispatcher, Dispatcher privateDispatcher)
        {
            PublicDispatcher = publicDispatcher;
            PrivateDispatcher = privateDispatcher;
        }
    }
}