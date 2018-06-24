using System.Collections.Generic;
using SLCore.Event;

namespace SLCore.Data
{
    public class HostDispatcher
    {
        public Dispatcher PublicDispatcher { get; }
        public List<Dispatcher> PrivateDispatchers { get; }

        public HostDispatcher(Dispatcher publicDispatcher, List<Dispatcher> privateDispatchers)
        {
            PublicDispatcher = publicDispatcher;
            PrivateDispatchers = privateDispatchers;
        }
    }
}