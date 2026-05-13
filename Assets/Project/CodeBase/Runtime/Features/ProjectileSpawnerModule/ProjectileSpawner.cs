using System;
using System.Threading;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.DifficultyLevel;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public class ProjectileSpawner : IProjectileSpawner, IDisposable
    {
        private readonly IProjectileSpawnRuleExecutor _projectileSpawnRuleExecutor;
        private readonly IProjectileDifficultyService _projectileDifficultyService;
        private readonly ILogService _logService;

        private CancellationTokenSource _cancellationTokenSource;

        public ProjectileSpawner(IProjectileSpawnRuleExecutor projectileSpawnRuleExecutor,
            IProjectileDifficultyService projectileDifficultyService, ILogService logService)
        {
            _projectileSpawnRuleExecutor = projectileSpawnRuleExecutor;
            _projectileDifficultyService = projectileDifficultyService;
            _logService = logService;
        }

        public void Dispose() =>
            Stop();

        public void Start()
        {
            if (_cancellationTokenSource != null)
                return;

            _cancellationTokenSource = new CancellationTokenSource();
            ExecuteSpawnAsync(_cancellationTokenSource.Token).Forget();
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }

        private async UniTaskVoid ExecuteSpawnAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    ProjectileSpawnRule projectileSpawnRule = _projectileDifficultyService.GetProjectileSpawnRule();
                    float flightDuration = _projectileDifficultyService.CurrentFlightDuration;
                    await _projectileSpawnRuleExecutor.Execute(projectileSpawnRule, flightDuration, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logService.Write("Projectile Spawner stopped");
            }
        }
    }
}