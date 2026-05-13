using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule.SpawnRules
{
    [Serializable]
    public class ProjectileStepSpawnRule : ProjectileSpawnRule
    {
        public List<ProjectileSpawnStep> ProjectileSpawnSteps;
    }
}