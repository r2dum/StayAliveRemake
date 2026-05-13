using System.Collections.Generic;
using CodeBase.Runtime.Features.ProjectileModule;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.DifficultyLevel;
using CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules;
using CodeBase.Runtime.Features.ProjectileSpawnPointModule;
using UnityEngine;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    [CreateAssetMenu(fileName = nameof(BiomeConfig), menuName = "Configs/Biome/" + nameof(BiomeConfig))]
    public class BiomeConfig : ScriptableObject
    {
        public BiomeView Prefab;
        public List<ProjectileDefinition> ProjectileDefinitions;
        public List<ProjectileSpawnPoint> ProjectileSpawnPoints;
        public List<ProjectileDifficultyLevel> ProjectileDifficultyLevels;
        [SerializeReference] public List<ProjectileSpawnRule> ProjectileSpawnRules;
    }
}