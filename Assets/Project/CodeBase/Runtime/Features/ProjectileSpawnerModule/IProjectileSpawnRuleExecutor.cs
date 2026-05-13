using System.Threading;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public interface IProjectileSpawnRuleExecutor
    {
        UniTask Execute(ProjectileSpawnRule spawnRule, float flightDuration, CancellationToken cancellationToken);
    }
}