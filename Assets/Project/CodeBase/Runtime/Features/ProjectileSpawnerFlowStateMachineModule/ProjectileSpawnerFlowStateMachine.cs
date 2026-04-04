using CodeBase.Runtime.Core.StateMachineModule;
using Zenject;

namespace CodeBase.Runtime.Features.ProjectileSpawnerFlowStateMachineModule
{
    public class ProjectileSpawnerFlowStateMachine : StateMachine, IInitializable
    {
        private readonly IStatesFactory _statesFactory;

        public ProjectileSpawnerFlowStateMachine(IStatesFactory statesFactory) =>
            _statesFactory = statesFactory;

        public void Initialize()
        {
        }
    }
}