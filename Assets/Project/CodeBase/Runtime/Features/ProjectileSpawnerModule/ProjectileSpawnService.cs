using CodeBase.Runtime.Features.BiomePlatformModule;
using CodeBase.Runtime.Features.ProjectileModule;
using CodeBase.Runtime.Features.ProjectileSpawnPointModule;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public class ProjectileSpawnService : IProjectileSpawnService
    {
        private readonly IProjectileSpawnPointRegistry _projectileSpawnPointRegistry;
        private readonly IBiomePlatformRegistry _biomePlatformRegistry;
        private readonly IProjectileFactory _projectileFactory;

        public ProjectileSpawnService(IProjectileSpawnPointRegistry projectileSpawnPointRegistry,
            IBiomePlatformRegistry biomePlatformRegistry, IProjectileFactory projectileFactory)
        {
            _projectileSpawnPointRegistry = projectileSpawnPointRegistry;
            _biomePlatformRegistry = biomePlatformRegistry;
            _projectileFactory = projectileFactory;
        }

        public async UniTaskVoid Spawn(ProjectileType projectileType, BiomePlatform biomePlatform, float flightDuration)
        {
            if (_biomePlatformRegistry.IsPlatformAvailable(biomePlatform) == false)
                return;

            ProjectileSpawnPoint spawnPoint =
                _projectileSpawnPointRegistry.GetAvailableSpawnPoint(projectileType, biomePlatform.Id);
            if (spawnPoint == null)
                return;

            _biomePlatformRegistry.SetOccupied(biomePlatform, true);
            _projectileSpawnPointRegistry.SetOccupied(spawnPoint, true);

            ProjectileBase projectile = _projectileFactory.CreateProjectile(projectileType);
            await projectile.Launch(spawnPoint.Position, biomePlatform.HitPosition, flightDuration);

            _biomePlatformRegistry.SetOccupied(biomePlatform, false);
            _projectileSpawnPointRegistry.SetOccupied(spawnPoint, false);
        }
    }
}