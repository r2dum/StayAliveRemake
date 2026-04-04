using System.Collections.Generic;
using CodeBase.Runtime.Features.GridBlockModule;
using CodeBase.Runtime.Features.ProjectileSpawnPointModule;
using UnityEngine;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public class BiomeView : MonoBehaviour
    {
        [SerializeField] private List<ProjectileSpawnPoint> _projectileSpawnPoints;
        [SerializeField] private List<GridBlock> _gridBlocks;
        [SerializeField] private Transform _characterSpawnPoint;

        public IReadOnlyList<ProjectileSpawnPoint> ProjectileSpawnPoints => _projectileSpawnPoints;
        public IReadOnlyList<GridBlock> GridBlocks => _gridBlocks;
        public Transform CharacterSpawnPoint => _characterSpawnPoint;
    }
}