namespace CodeBase.Runtime.Core.StateMachineModule
{
    public interface IPayLoadState<TPayLoad> : IExitState
    {
        void Enter(TPayLoad payLoad);
    }
}