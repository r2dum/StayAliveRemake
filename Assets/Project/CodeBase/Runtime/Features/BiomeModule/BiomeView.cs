using System.Collections.Generic;
using CodeBase.Runtime.Features.BiomePlatformModule;
using UnityEngine;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public class BiomeView : MonoBehaviour
    {
        [SerializeField] private List<BiomePlatform> _platforms;
        [SerializeField] private Transform _characterSpawnPoint;

        public IReadOnlyList<BiomePlatform> Platforms => _platforms;
        public Transform CharacterSpawnPoint => _characterSpawnPoint;
    }
}