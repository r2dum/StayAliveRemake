using CodeBase.Runtime.Features.GameFlowStateMachineModule;
using CodeBase.Runtime.Features.GameFlowStateMachineModule.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.BootstrapModule.Bootstraps
{
    public class GameSceneBootstrapper : MonoBehaviour
    {
        private GameFlowStateMachine _gameFlowStateMachine;

        [Inject]
        private void Construct(GameFlowStateMachine gameFlowStateMachine) =>
            _gameFlowStateMachine = gameFlowStateMachine;

        private void Start() =>
            _gameFlowStateMachine.Enter<BootstrapGameFlowState>();
    }
}