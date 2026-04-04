using CodeBase.Runtime.Core.Data;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.PersistentProgressModule;
using CodeBase.Runtime.Core.SaveLoadModule;
using CodeBase.Runtime.Core.StateMachineModule;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule.States
{
    public class AppLoadProgressState : IState
    {
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly AppFlowStateMachine _appFlowStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ILogService _logService;

        public AppLoadProgressState(IPersistentProgressService persistentProgressService,
            AppFlowStateMachine appFlowStateMachine, ISaveLoadService saveLoadService,
            ILogService logService)
        {
            _persistentProgressService = persistentProgressService;
            _appFlowStateMachine = appFlowStateMachine;
            _saveLoadService = saveLoadService;
            _logService = logService;
        }

        public void Enter()
        {
            _logService.Write("Enter " + nameof(AppLoadProgressState));
            LoadProgressOrCreateNew();
            _appFlowStateMachine.Enter<GameFlowState>();
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(AppLoadProgressState));

        private void LoadProgressOrCreateNew() =>
            _persistentProgressService.Progress =
                _saveLoadService.LoadOrCreateProgress(CreateNewProgress());

        private PlayerProgress CreateNewProgress()
        {
            PlayerProgress progress = new()
            {
                BiomeData = new BiomeData(),
                CharacterData = new CharacterData()
            };

            return progress;
        }
    }
}