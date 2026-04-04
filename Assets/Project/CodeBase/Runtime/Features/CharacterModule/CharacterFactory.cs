using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Features.CharacterModule.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly ICharacterStaticDataService _characterStaticDataService;
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public CharacterFactory(ICharacterStaticDataService characterStaticDataService, IAssetProvider assetProvider,
            IInstantiator instantiator)
        {
            _characterStaticDataService = characterStaticDataService;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public async UniTask<Character> CreateCharacter(Vector3 at)
        {
            CharacterConfig characterConfig = _characterStaticDataService.ForCharacterConfig();
            GameObject prefab = await _assetProvider.Load<GameObject>(characterConfig.CharacterReference);
            return _instantiator.InstantiatePrefabForComponent<Character>(prefab, at, Quaternion.identity, null);
        }
    }
}