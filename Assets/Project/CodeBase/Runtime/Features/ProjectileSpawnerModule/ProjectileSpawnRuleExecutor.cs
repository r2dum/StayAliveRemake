using System;
using System.Threading;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Features.BiomePlatformModule;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules;
using CodeBase.Shared.Extensions;
using Cysharp.Threading.Tasks;
using Random = UnityEngine.Random;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public class ProjectileSpawnRuleExecutor : IProjectileSpawnRuleExecutor
    {
        private readonly IProjectileSpawnService _projectileSpawnService;
        private readonly IBiomePlatformRegistry _biomePlatformRegistry;
        private readonly ILogService _logService;

        public ProjectileSpawnRuleExecutor(IProjectileSpawnService projectileSpawnService,
            IBiomePlatformRegistry biomePlatformRegistry, ILogService logService)
        {
            _projectileSpawnService = projectileSpawnService;
            _biomePlatformRegistry = biomePlatformRegistry;
            _logService = logService;
        }

        public async UniTask Execute(ProjectileSpawnRule spawnRule, float flightDuration,
            CancellationToken cancellationToken)
        {
            switch (spawnRule)
            {
                case ProjectileProceduralSpawnRule proceduralSpawnRule:
                    await ExecuteProceduralRule(proceduralSpawnRule, flightDuration, cancellationToken);
                    break;
                case ProjectileStepSpawnRule stepSpawnRule:
                    await ExecuteStepRule(stepSpawnRule, flightDuration, cancellationToken);
                    break;
            }
        }

        private async UniTask ExecuteProceduralRule(ProjectileProceduralSpawnRule spawnRule, float flightDuration,
            CancellationToken cancellationToken)
        {
            int count = spawnRule.RandomCountToSpawn
                ? Random.Range(spawnRule.MinCountToSpawn, spawnRule.MaxCountToSpawn + 1)
                : spawnRule.CountToSpawn;

            for (int i = 0; i < count; i++)
            {
                BiomePlatform randomPlatform = _biomePlatformRegistry.Platforms.PickRandom();

                _projectileSpawnService.Spawn(spawnRule.ProjectileType, randomPlatform, flightDuration).Forget();

                float delay = spawnRule.RandomDelayAfterSpawn
                    ? Random.Range(spawnRule.MinDelayAfterSpawn, spawnRule.MaxDelayAfterSpawn)
                    : spawnRule.DelayAfterSpawn;

                await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: cancellationToken);
            }
        }

        private async UniTask ExecuteStepRule(ProjectileStepSpawnRule spawnRule, float flightDuration,
            CancellationToken cancellationToken)
        {
            foreach (ProjectileSpawnStep spawnStep in spawnRule.ProjectileSpawnSteps)
            {
                if (spawnStep.PlatformId < 0 || spawnStep.PlatformId >= _biomePlatformRegistry.Platforms.Count)
                {
                    _logService.WriteError($"Invalid BlockId: {spawnStep.PlatformId}");
                    continue;
                }

                BiomePlatform targetPlatform = _biomePlatformRegistry.Platforms[spawnStep.PlatformId];

                _projectileSpawnService.Spawn(spawnStep.Type, targetPlatform, flightDuration).Forget();

                if (spawnStep.DelayAfterStep > 0f)
                    await UniTask.Delay(TimeSpan.FromSeconds(spawnStep.DelayAfterStep),
                        cancellationToken: cancellationToken);
            }
        }
    }
}