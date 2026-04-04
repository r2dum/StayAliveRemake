using System;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Features.CharacterModule.StaticData
{
    [Serializable]
    public class CharacterDefinition
    {
        public string Id;
        public AssetReference ConfigReference;
    }
}