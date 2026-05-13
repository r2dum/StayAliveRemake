using System.Collections.Generic;
using CodeBase.Runtime.Features.ProjectileModule;

namespace CodeBase.Runtime.Features.ProjectileSpawnPointModule
{
    public class ProjectileSpawnPointRegistry : IProjectileSpawnPointRegistry
    {
        private readonly List<ProjectileSpawnPoint> _spawnPoints = new();
        private readonly Dictionary<ProjectileSpawnPoint, bool> _occupationSpawnPoints = new();

        public void RegisterSpawnPoints(IEnumerable<ProjectileSpawnPoint> spawnPoints)
        {
            foreach (ProjectileSpawnPoint spawnPoint in spawnPoints)
            {
                _spawnPoints.Add(spawnPoint);
                _occupationSpawnPoints[spawnPoint] = false;
            }
        }

        public ProjectileSpawnPoint GetAvailableSpawnPoint(ProjectileType type, int platformId)
        {
            ProjectileSpawnPoint globalCandidate = null;

            foreach (ProjectileSpawnPoint spawnPoint in _spawnPoints)
            {
                if (_occupationSpawnPoints[spawnPoint] || spawnPoint.ProjectileTypes.Contains(type) == false)
                    continue;

                if (spawnPoint.SpawnPointType == ProjectileSpawnPointType.LinkedToPlatform &&
                    spawnPoint.PlatformId == platformId)
                    return spawnPoint;

                if (spawnPoint.SpawnPointType == ProjectileSpawnPointType.Global && globalCandidate == null)
                    globalCandidate = spawnPoint;
            }

            return globalCandidate;
        }

        public void SetOccupied(ProjectileSpawnPoint spawnPoint, bool isOccupied) =>
            _occupationSpawnPoints[spawnPoint] = isOccupied;
    }
}