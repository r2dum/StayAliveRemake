using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.InputModule;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.CharacterModule;
using CodeBase.Runtime.Features.StaticDataModule.GameScene;
using CodeBase.Runtime.Features.UIModule;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.States
{
    public class BootstrapGameFlowState : IState
    {
        private readonly IGameSceneStaticDataLoader _gameSceneStaticDataLoader;
        private readonly GameFlowStateMachine _gameFlowStateMachine;
        private readonly ICharacterProvider _characterProvider;
        private readonly IBiomeProvider _biomeProvider;
        private readonly IInputListener _inputListener;
        private readonly IUIFactory _uiFactory;
        private readonly ILogService _logService;

        public BootstrapGameFlowState(IGameSceneStaticDataLoader gameSceneStaticDataLoader,
            GameFlowStateMachine gameFlowStateMachine, ICharacterProvider characterProvider,
            IBiomeProvider biomeProvider, IInputListener inputListener,
            IUIFactory uiFactory, ILogService logService)
        {
            _gameSceneStaticDataLoader = gameSceneStaticDataLoader;
            _gameFlowStateMachine = gameFlowStateMachine;
            _characterProvider = characterProvider;
            _biomeProvider = biomeProvider;
            _inputListener = inputListener;
            _uiFactory = uiFactory;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(BootstrapGameFlowState));
            _inputListener.DisablePlayerActionMap();
            await _gameSceneStaticDataLoader.LoadAsync();
            _biomeProvider.CreateBiome();
            await _characterProvider.CreateCharacter(_biomeProvider.BiomeView.CharacterSpawnPoint.position);
            await _uiFactory.CreateUIRoot();
            _gameFlowStateMachine.Enter<LobbyFlowState>();
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(BootstrapGameFlowState));
    }
}