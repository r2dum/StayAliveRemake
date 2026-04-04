using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public class CharacterProvider : ICharacterProvider
    {
        private readonly ICharacterFactory _characterFactory;

        public Character Character { get; private set; }

        public CharacterProvider(ICharacterFactory characterFactory) =>
            _characterFactory = characterFactory;

        public async UniTask CreateCharacter(Vector3 at) =>
            Character = await _characterFactory.CreateCharacter(at);
    }
}