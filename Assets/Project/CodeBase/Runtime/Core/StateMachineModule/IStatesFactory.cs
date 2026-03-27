namespace CodeBase.Runtime.Core.StateMachineModule
{
    public interface IStatesFactory
    {
        TState Create<TState>() where TState : IExitState;
    }
}