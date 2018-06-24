using System;
using SLCore.Entity;

namespace SLCore.Event.Host
{
    public class StateCheckScore : StateBase
    {
        private readonly GameHost _host;
        
        public StateCheckScore(StateMachineBase stateMachine) : base(stateMachine)
        {
            _host = (GameHost) stateMachine;
        }

        #region Overrides

        public override void OnEnterState(StateBase prevState)
        {
            base.OnEnterState(prevState);
            Foo();
        }

        #endregion

        #region Processes

        private void Foo()
        {
            Console.WriteLine("FOO: {0}", _host);
        }

        private bool IsPresident(int id)
        {
            return false;
        }

        private bool Is5Kwang(int id)
        {
            return false;
        }

        private bool Is4Kwang(int id)
        {
            return false;
        }

        private bool Is3Kwang(int id)
        {
            return false;
        }

        private bool IsB3Kwang(int id)
        {
            return false;
        }

        private bool IsGodori(int id)
        {
            return false;
        }

        private bool IsHongDan(int id)
        {
            return false;
        }

        private bool IsChoDan(int id)
        {
            return false;
        }

        private bool IsChungDan(int id)
        {
            return false;
        }

        private bool IsFuck(int id)
        {
            return false;
        }

        private bool IsZock(int id)
        {
            return false;
        }

        #endregion
    }
}