using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    [CreateAssetMenu(fileName = nameof(BiomeConfig), menuName = "Configs/Biome/" + nameof(BiomeConfig))]
    public class BiomeConfig : ScriptableObject
    {
        public AssetReference BiomeReference;
    }
}