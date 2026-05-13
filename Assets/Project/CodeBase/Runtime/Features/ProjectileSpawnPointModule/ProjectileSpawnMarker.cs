using System.Collections.Generic;
using CodeBase.Runtime.Features.ProjectileModule;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileSpawnPointModule
{
    public class ProjectileSpawnMarker : MonoBehaviour
    {
        [SerializeField] private ProjectileSpawnPointType _spawnPointType;

        [ShowIf("IsLinkedToPlatform")] [SerializeField]
        private int _platformId;

        [SerializeField] private List<ProjectileType> _projectileTypes;

        public ProjectileSpawnPointType SpawnPointType => _spawnPointType;
        public int PlatformId => _platformId;
        public List<ProjectileType> ProjectileTypes => _projectileTypes;

        private bool IsLinkedToPlatform() =>
            _spawnPointType == ProjectileSpawnPointType.LinkedToPlatform;
    }
}