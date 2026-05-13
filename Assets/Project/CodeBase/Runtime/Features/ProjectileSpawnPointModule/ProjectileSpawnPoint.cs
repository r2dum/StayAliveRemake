using System;
using System.Collections.Generic;
using CodeBase.Runtime.Features.ProjectileModule;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileSpawnPointModule
{
    [Serializable]
    public class ProjectileSpawnPoint
    {
        public ProjectileSpawnPointType SpawnPointType;
        [ShowIf("IsLinkedToPlatform")] public int PlatformId;
        public List<ProjectileType> ProjectileTypes;
        public Vector3 Position;

        public ProjectileSpawnPoint(ProjectileSpawnPointType spawnPointType, int platformId,
            List<ProjectileType> projectileTypes, Vector3 position)
        {
            SpawnPointType = spawnPointType;
            PlatformId = platformId;
            ProjectileTypes = projectileTypes;
            Position = position;
        }

        private bool IsLinkedToPlatform() =>
            SpawnPointType == ProjectileSpawnPointType.LinkedToPlatform;
    }
}