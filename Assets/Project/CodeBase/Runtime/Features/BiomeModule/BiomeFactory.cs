using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Features.BiomeModule.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public class BiomeFactory : IBiomeFactory
    {
        private readonly IBiomeStaticDataService _biomeStaticDataService;
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public BiomeFactory(IBiomeStaticDataService biomeStaticDataService, IAssetProvider assetProvider,
            IInstantiator instantiator)
        {
            _biomeStaticDataService = biomeStaticDataService;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public async UniTask<BiomeView> CreateBiome()
        {
            BiomeConfig biomeConfig = _biomeStaticDataService.ForBiomeConfig();
            GameObject prefab = await _assetProvider.Load<GameObject>(biomeConfig.BiomeReference);
            return _instantiator.InstantiatePrefabForComponent<BiomeView>(prefab);
        }
    }
}