using System;
using CodeBase.Runtime.Features.ProjectileModule;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules
{
    [Serializable]
    public class ProjectileSpawnStep
    {
        public ProjectileType Type;
        public int PlatformId;
        public float DelayAfterStep;
    }
}