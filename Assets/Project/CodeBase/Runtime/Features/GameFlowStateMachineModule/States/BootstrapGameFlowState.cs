using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.CharacterModule;
using CodeBase.Runtime.Features.StaticDataModule.GameScene;
using CodeBase.Runtime.Features.UIModule;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.States
{
    public class BootstrapGameFlowState : IState
    {
        private readonly IGameSceneStaticDataService _gameSceneStaticDataService;
        private readonly GameFlowStateMachine _gameFlowStateMachine;
        private readonly ICharacterProvider _characterProvider;
        private readonly IBiomeProvider _biomeProvider;
        private readonly IUIFactory _uiFactory;
        private readonly ILogService _logService;

        public BootstrapGameFlowState(IGameSceneStaticDataService gameSceneStaticDataService,
            GameFlowStateMachine gameFlowStateMachine, ICharacterProvider characterProvider,
            IBiomeProvider biomeProvider, IUIFactory uiFactory,
            ILogService logService)
        {
            _gameSceneStaticDataService = gameSceneStaticDataService;
            _gameFlowStateMachine = gameFlowStateMachine;
            _characterProvider = characterProvider;
            _biomeProvider = biomeProvider;
            _uiFactory = uiFactory;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(BootstrapGameFlowState));
            await _gameSceneStaticDataService.LoadAsync();
            await _uiFactory.CreateUIRoot();
            await _biomeProvider.CreateBiome();
            await _characterProvider.CreateCharacter(_biomeProvider.BiomeView.CharacterSpawnPoint.position);
            _gameFlowStateMachine.Enter<LobbyFlowState>();
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(BootstrapGameFlowState));
    }
}