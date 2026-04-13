using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.CameraModule.StaticData;
using CodeBase.Runtime.Features.CharacterModule.StaticData;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.StaticDataModule.GameScene
{
    public class GameSceneStaticDataService : IGameSceneStaticDataService
    {
        private readonly ICharacterStaticDataService _characterStaticDataService;
        private readonly ICameraStaticDataService _cameraStaticDataService;
        private readonly IBiomeStaticDataService _biomeStaticDataService;

        public GameSceneStaticDataService(ICharacterStaticDataService characterStaticDataService,
            ICameraStaticDataService cameraStaticDataService, IBiomeStaticDataService biomeStaticDataService)
        {
            _characterStaticDataService = characterStaticDataService;
            _cameraStaticDataService = cameraStaticDataService;
            _biomeStaticDataService = biomeStaticDataService;
        }

        public async UniTask LoadAsync()
        {
            await _cameraStaticDataService.LoadAsync();
            await _biomeStaticDataService.LoadAsync();
            await _characterStaticDataService.LoadAsync();
        }
    }
}