using System;

namespace SLCore.Event
{
    public class Dispatcher
    {
        public event EventHandler<GameEventArgs> Event;

        public void Dispatch(GameEventArgs args)
        {
            Event?.Invoke(this, args ?? (GameEventArgs) EventArgs.Empty);
        }
    }
}