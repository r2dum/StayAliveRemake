using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Features.CharacterModule.StaticData
{
    [CreateAssetMenu(fileName = nameof(CharacterDatabaseConfig),
        menuName = "Configs/Character/" + nameof(CharacterDatabaseConfig))]
    public class CharacterDatabaseConfig : ScriptableObject
    {
        public List<CharacterDefinition> CharacterDefinitions;
    }
}