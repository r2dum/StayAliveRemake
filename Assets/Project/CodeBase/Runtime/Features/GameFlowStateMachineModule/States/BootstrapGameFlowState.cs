using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.CameraModule.StaticData;
using CodeBase.Runtime.Features.CharacterModule;
using CodeBase.Runtime.Features.CharacterModule.StaticData;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.States
{
    public class BootstrapGameFlowState : IState
    {
        private readonly ICharacterStaticDataService _characterStaticDataService;
        private readonly ICameraStaticDataService _cameraStaticDataService;
        private readonly IBiomeStaticDataService _biomeStaticDataService;
        private readonly GameFlowStateMachine _gameFlowStateMachine;
        private readonly ICharacterProvider _characterProvider;
        private readonly IBiomeProvider _biomeProvider;
        private readonly ILogService _logService;

        public BootstrapGameFlowState(ICharacterStaticDataService characterStaticDataService,
            ICameraStaticDataService cameraStaticDataService, IBiomeStaticDataService biomeStaticDataService,
            GameFlowStateMachine gameFlowStateMachine, ICharacterProvider characterProvider,
            IBiomeProvider biomeProvider, ILogService logService)
        {
            _characterStaticDataService = characterStaticDataService;
            _cameraStaticDataService = cameraStaticDataService;
            _biomeStaticDataService = biomeStaticDataService;
            _gameFlowStateMachine = gameFlowStateMachine;
            _characterProvider = characterProvider;
            _biomeProvider = biomeProvider;
            _logService = logService;
        }

        public async void Enter()
        {
            _logService.Write("Enter " + nameof(BootstrapGameFlowState));
            await _cameraStaticDataService.InitializeAsync();
            await _biomeStaticDataService.InitializeAsync();
            await _characterStaticDataService.InitializeAsync();
            await _biomeProvider.CreateBiome();
            await _characterProvider.CreateCharacter(_biomeProvider.BiomeView.CharacterSpawnPoint.position);
            _gameFlowStateMachine.Enter<LobbyFlowState>();
        }

        public void Exit() =>
            _logService.Write("Exit " + nameof(BootstrapGameFlowState));
    }
}