using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.ProjectileModule;
using CodeBase.Shared.Extensions;
using Zenject;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IBiomeStaticDataService _biomeStaticDataService;
        private readonly IInstantiator _instantiator;

        public ProjectileFactory(IBiomeStaticDataService biomeStaticDataService, IInstantiator instantiator)
        {
            _biomeStaticDataService = biomeStaticDataService;
            _instantiator = instantiator;
        }

        public ProjectileBase CreateProjectile(ProjectileType type)
        {
            ProjectileDefinition projectileDefinition =
                _biomeStaticDataService.ForBiomeConfig().ProjectileDefinitions.Find(p => p.Type == type);
            ProjectileConfig projectileConfig = projectileDefinition.Config;
            ProjectileBase projectileBase =
                _instantiator.InstantiatePrefabForComponent<ProjectileBase>(projectileConfig.Prefab);
            projectileBase.SetAnimationCurve(projectileConfig.AnimationCurves.PickRandom());
            return projectileBase;
        }
    }
}