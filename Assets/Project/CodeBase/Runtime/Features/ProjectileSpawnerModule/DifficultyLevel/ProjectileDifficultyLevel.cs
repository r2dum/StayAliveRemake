using System;
using CodeBase.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.DifficultyLevel
{
    [Serializable]
    public class ProjectileDifficultyLevel
    {
        [Range(Constants.MinDifficultyLevel, Constants.MaxDifficultyLevel)] [LabelWidth(60)]
        public int Level = Constants.MinDifficultyLevel;

        [Range(1f, 300f)] [Tooltip("Duration in seconds"), LabelWidth(60)]
        public float Duration = 60f;

        [Range(0.1f, 5f)] [Tooltip("Duration in seconds"), LabelWidth(150)]
        public float ProjectileFlightDuration = 3f;
    }
}