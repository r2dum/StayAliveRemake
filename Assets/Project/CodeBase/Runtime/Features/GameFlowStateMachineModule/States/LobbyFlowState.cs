using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.CameraModule;
using CodeBase.Runtime.Features.LobbyModule.UI;
using CodeBase.Runtime.Features.UIModule;
using CodeBase.Shared;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.States
{
    public class LobbyFlowState : IState
    {
        private readonly ICameraService _cameraService;
        private readonly IUIService _uiService;
        private readonly ILogService _logService;

        public LobbyFlowState(ICameraService cameraService, IUIService uiService, ILogService logService)
        {
            _cameraService = cameraService;
            _uiService = uiService;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(LobbyFlowState));
            await _cameraService.SwitchState(CameraStateType.Lobby);
            await _uiService.OpenWindow<LobbyWindowPresenter>(AssetAddress.UI.LobbyWindow);
        }

        public void Exit()
        {
            _logService.Write("Exit " + nameof(LobbyFlowState));
            _uiService.CloseOpenedWindow();
        }
    }
}