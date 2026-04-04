using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    [CreateAssetMenu(fileName = nameof(BiomeDatabaseConfig), menuName = "Configs/Biome/" + nameof(BiomeDatabaseConfig))]
    public class BiomeDatabaseConfig : ScriptableObject
    {
        public List<BiomeDefinition> BiomeDefinitions;
    }
}