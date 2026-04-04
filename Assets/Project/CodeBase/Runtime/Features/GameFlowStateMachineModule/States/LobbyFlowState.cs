using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.InputModule;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.CameraModule;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.States
{
    public class LobbyFlowState : IState
    {
        private readonly ICameraService _cameraService;
        private readonly IInputListener _inputListener;
        private readonly ILogService _logService;

        public LobbyFlowState(ICameraService cameraService, IInputListener inputListener, ILogService logService)
        {
            _cameraService = cameraService;
            _inputListener = inputListener;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(LobbyFlowState));
            _inputListener.DisablePlayerActionMap();
            await _cameraService.SwitchState(CameraStateType.Lobby);
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(LobbyFlowState));
    }
}