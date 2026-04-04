using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.GameFlowStateMachineModule.States;
using Zenject;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule
{
    public class GameFlowStateMachine : StateMachine, IInitializable
    {
        private readonly IStatesFactory _statesFactory;

        public GameFlowStateMachine(IStatesFactory statesFactory) =>
            _statesFactory = statesFactory;

        public void Initialize()
        {
            RegisterState(_statesFactory.Create<BootstrapGameFlowState>());
            RegisterState(_statesFactory.Create<LobbyFlowState>());
            RegisterState(_statesFactory.Create<GameplayFlowState>());
        }
    }
}