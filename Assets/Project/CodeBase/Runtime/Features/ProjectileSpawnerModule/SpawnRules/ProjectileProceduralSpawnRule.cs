using System;
using CodeBase.Runtime.Features.ProjectileModule;
using Sirenix.OdinInspector;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules
{
    [Serializable]
    public class ProjectileProceduralSpawnRule : ProjectileSpawnRule
    {
        public ProjectileType ProjectileType;
        public bool RandomCountToSpawn;
        [ShowIf("RandomCountToSpawn")] public int MinCountToSpawn;
        [ShowIf("RandomCountToSpawn")] public int MaxCountToSpawn;
        [HideIf("RandomCountToSpawn")] public int CountToSpawn;
        public bool RandomDelayAfterSpawn;
        [ShowIf("RandomDelayAfterSpawn")] public float MinDelayAfterSpawn;
        [ShowIf("RandomDelayAfterSpawn")] public float MaxDelayAfterSpawn;
        [HideIf("RandomDelayAfterSpawn")] public float DelayAfterSpawn;
    }
}