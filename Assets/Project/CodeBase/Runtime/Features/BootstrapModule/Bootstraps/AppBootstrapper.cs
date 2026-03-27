using CodeBase.Runtime.Features.AppFlowStateMachineModule;
using CodeBase.Runtime.Features.AppFlowStateMachineModule.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.BootstrapModule.Bootstraps
{
    public class AppBootstrapper : MonoBehaviour
    {
        private AppFlowStateMachine _appFlowStateMachine;

        [Inject]
        private void Construct(AppFlowStateMachine appFlowStateMachine) =>
            _appFlowStateMachine = appFlowStateMachine;

        private void Start()
        {
            DontDestroyOnLoad(this);
            _appFlowStateMachine.Enter<BootstrapAppFlowState>();
        }
    }
}