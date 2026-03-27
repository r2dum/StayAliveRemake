namespace CodeBase.Runtime.Core.StateMachineModule
{
    public interface IState : IExitState
    {
        void Enter();
    }
}