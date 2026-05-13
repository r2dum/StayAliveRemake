using CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.DifficultyLevel
{
    public interface IProjectileDifficultyService
    {
        float CurrentFlightDuration { get; }
        ProjectileSpawnRule GetProjectileSpawnRule();
    }
}