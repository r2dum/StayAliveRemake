using CodeBase.Runtime.Features.ProjectileSpawnerModule.DifficultyLevel;
using CodeBase.Runtime.Features.ProjectileSpawnPointModule;
using Zenject;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public class ProjectileSpawnerModuleInstaller : Installer<ProjectileSpawnerModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ProjectileSpawnPointRegistry>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProjectileFactory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProjectileSpawnService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProjectileSpawnRuleExecutor>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProjectileDifficultyService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProjectileSpawner>()
                .AsSingle();
        }
    }
}