using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.BiomePlatformModule;
using CodeBase.Runtime.Features.ProjectileSpawnPointModule;
using Zenject;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public class BiomeFactory : IBiomeFactory
    {
        private readonly IProjectileSpawnPointRegistry _projectileSpawnPointRegistry;
        private readonly IBiomeStaticDataService _biomeStaticDataService;
        private readonly IBiomePlatformRegistry _biomePlatformRegistry;
        private readonly IInstantiator _instantiator;

        public BiomeFactory(IProjectileSpawnPointRegistry projectileSpawnPointRegistry,
            IBiomeStaticDataService biomeStaticDataService, IBiomePlatformRegistry biomePlatformRegistry,
            IInstantiator instantiator)
        {
            _projectileSpawnPointRegistry = projectileSpawnPointRegistry;
            _biomeStaticDataService = biomeStaticDataService;
            _biomePlatformRegistry = biomePlatformRegistry;
            _instantiator = instantiator;
        }

        public BiomeView CreateBiome()
        {
            BiomeConfig biomeConfig = _biomeStaticDataService.ForBiomeConfig();
            BiomeView biomeView = _instantiator.InstantiatePrefabForComponent<BiomeView>(biomeConfig.Prefab);
            _projectileSpawnPointRegistry.RegisterSpawnPoints(biomeConfig.ProjectileSpawnPoints);
            _biomePlatformRegistry.RegisterPlatforms(biomeView.Platforms);
            return biomeView;
        }
    }
}