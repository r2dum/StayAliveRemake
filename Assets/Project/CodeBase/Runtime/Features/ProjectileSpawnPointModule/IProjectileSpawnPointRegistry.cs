using System.Collections.Generic;
using CodeBase.Runtime.Features.ProjectileModule;

namespace CodeBase.Runtime.Features.ProjectileSpawnPointModule
{
    public interface IProjectileSpawnPointRegistry
    {
        void RegisterSpawnPoints(IEnumerable<ProjectileSpawnPoint> spawnPoints);
        ProjectileSpawnPoint GetAvailableSpawnPoint(ProjectileType type, int platformId);
        void SetOccupied(ProjectileSpawnPoint spawnPoint, bool isOccupied);
    }
}