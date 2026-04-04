using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Features.CharacterModule.StaticData
{
    [CreateAssetMenu(fileName = nameof(CharacterConfig), menuName = "Configs/Character/" + nameof(CharacterConfig))]
    public class CharacterConfig : ScriptableObject
    {
        public AssetReference CharacterReference;
    }
}