using System;
using CodeBase.Shared;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules
{
    [Serializable]
    public abstract class ProjectileSpawnRule
    {
        [Range(Constants.MinDifficultyLevel, Constants.MaxDifficultyLevel)]
        public int MinDifficultyLevel = Constants.MinDifficultyLevel;

        [Range(Constants.MinDifficultyLevel, Constants.MaxDifficultyLevel)]
        public int MaxDifficultyLevel = Constants.MaxDifficultyLevel;
    }
}