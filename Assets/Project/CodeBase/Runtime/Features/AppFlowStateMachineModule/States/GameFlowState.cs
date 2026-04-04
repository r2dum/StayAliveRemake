using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.SceneLoaderModule;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Shared;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule.States
{
    public class GameFlowState : IState
    {
        private readonly ISceneLoaderService _sceneLoaderService;
        private readonly ILogService _logService;

        public GameFlowState(ISceneLoaderService sceneLoaderService, ILogService logService)
        {
            _sceneLoaderService = sceneLoaderService;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(GameFlowState));
            await _sceneLoaderService.LoadAsync(Constants.Scene.Game);
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(GameFlowState));
    }
}