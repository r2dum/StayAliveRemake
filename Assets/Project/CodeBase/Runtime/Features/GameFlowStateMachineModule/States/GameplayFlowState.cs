using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.InputModule;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.CameraModule;
using CodeBase.Runtime.Features.GameplayModule.UI;
using CodeBase.Runtime.Features.ProjectileSpawnerModule;
using CodeBase.Runtime.Features.SurvivalTimerModule;
using CodeBase.Runtime.Features.UIModule;
using CodeBase.Shared;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.States
{
    public class GameplayFlowState : IState
    {
        private readonly IProjectileSpawner _projectileSpawner;
        private readonly ISurvivalTimer _survivalTimer;
        private readonly ICameraService _cameraService;
        private readonly IInputListener _inputListener;
        private readonly IUIService _uiService;
        private readonly ILogService _logService;

        public GameplayFlowState(IProjectileSpawner projectileSpawner, ISurvivalTimer survivalTimer,
            ICameraService cameraService, IInputListener inputListener,
            IUIService uiService, ILogService logService)
        {
            _projectileSpawner = projectileSpawner;
            _survivalTimer = survivalTimer;
            _cameraService = cameraService;
            _inputListener = inputListener;
            _uiService = uiService;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(GameplayFlowState));
            _inputListener.EnablePlayerActionMap();
            _projectileSpawner.Start();
            _survivalTimer.Start();
            await _uiService.OpenWindow<GameplayWindowPresenter>(AssetAddress.UI.GameplayWindow);
            await _cameraService.SwitchState(CameraStateType.Gameplay);
        }

        public void Exit()
        {
            _logService.Write("Exit " + nameof(GameplayFlowState));
            _inputListener.DisablePlayerActionMap();
            _projectileSpawner.Stop();
            _survivalTimer.Pause();
            _uiService.CloseOpenedWindow();
        }
    }
}