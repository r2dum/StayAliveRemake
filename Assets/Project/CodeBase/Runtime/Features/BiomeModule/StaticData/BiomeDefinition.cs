using System;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    [Serializable]
    public class BiomeDefinition
    {
        public string Id;
        public AssetReference ConfigReference;
    }
}