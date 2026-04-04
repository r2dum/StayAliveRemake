using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.StateMachineModule;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule.States
{
    public class BootstrapAppFlowState : IState
    {
        private readonly AppFlowStateMachine _appFlowStateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly ILogService _logService;

        public BootstrapAppFlowState(AppFlowStateMachine appFlowStateMachine, IAssetProvider assetProvider,
            ILogService logService)
        {
            _appFlowStateMachine = appFlowStateMachine;
            _assetProvider = assetProvider;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(BootstrapAppFlowState));
            if (Application.isMobilePlatform)
                Application.targetFrameRate = 120;
            if (Mouse.current.enabled == false)
                InputSystem.EnableDevice(Mouse.current);
            await _assetProvider.InitializeAsync();
            _appFlowStateMachine.Enter<AppLoadProgressState>();
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(BootstrapAppFlowState));
    }
}