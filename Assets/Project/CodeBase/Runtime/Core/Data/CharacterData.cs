using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Core.Data
{
    [Serializable]
    public class CharacterData
    {
        public string SelectedCharacter = "Badger";
        public List<string> UnlockedCharacters = new();
    }
}