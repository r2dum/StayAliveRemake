using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.AppFlowStateMachineModule.States;
using Zenject;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule
{
    public class AppFlowStateMachine : StateMachine, IInitializable
    {
        private readonly IStatesFactory _statesFactory;

        public AppFlowStateMachine(IStatesFactory statesFactory) =>
            _statesFactory = statesFactory;

        public void Initialize()
        {
            RegisterState(_statesFactory.Create<BootstrapAppFlowState>());
            RegisterState(_statesFactory.Create<AppLoadProgressState>());
            RegisterState(_statesFactory.Create<GameFlowState>());
        }
    }
}