using System.Collections.Generic;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules;
using CodeBase.Runtime.Features.SurvivalTimerModule;
using CodeBase.Shared.Extensions;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.DifficultyLevel
{
    public class ProjectileDifficultyService : IProjectileDifficultyService
    {
        private readonly IBiomeStaticDataService _biomeStaticDataService;
        private readonly ISurvivalTimer _survivalTimer;
        private readonly ILogService _logService;

        private int _lastLevel;

        private BiomeConfig BiomeConfig => _biomeStaticDataService.ForBiomeConfig();

        private ProjectileDifficultyLevel CurrentProjectileDifficulty =>
            BiomeConfig.ProjectileDifficultyLevels[GetCurrentLevel()];

        private int CurrentLevel => CurrentProjectileDifficulty.Level;

        public float CurrentFlightDuration => CurrentProjectileDifficulty.ProjectileFlightDuration;

        public ProjectileDifficultyService(IBiomeStaticDataService biomeStaticDataService,
            ISurvivalTimer survivalTimer, ILogService logService)
        {
            _biomeStaticDataService = biomeStaticDataService;
            _survivalTimer = survivalTimer;
            _logService = logService;
        }

        public ProjectileSpawnRule GetProjectileSpawnRule()
        {
            int currentLevel = GetCurrentLevel();
            bool isNewLevel = currentLevel > _lastLevel;

            if (isNewLevel)
            {
                _logService.Write($"Difficulty Up! Level: [{CurrentLevel}], Flight: [{CurrentFlightDuration}]s");
                _lastLevel = currentLevel;

                List<ProjectileSpawnRule> newRules =
                    BiomeConfig.ProjectileSpawnRules.FindAll(r => r.MinDifficultyLevel == CurrentLevel);
                if (newRules.Count > 0)
                    return newRules.PickRandom();
            }

            return BiomeConfig.ProjectileSpawnRules
                .FindAll(r => CurrentLevel >= r.MinDifficultyLevel && CurrentLevel <= r.MaxDifficultyLevel)
                .PickRandom();
        }

        private int GetCurrentLevel()
        {
            List<ProjectileDifficultyLevel> difficultyLevels = BiomeConfig.ProjectileDifficultyLevels;
            float currentTime = _survivalTimer.CurrentTime;
            float accumulatedTime = 0;

            for (int i = 0; i < difficultyLevels.Count; i++)
            {
                accumulatedTime += difficultyLevels[i].Duration;
                if (currentTime < accumulatedTime)
                    return i;
            }

            return difficultyLevels.Count - 1;
        }
    }
}