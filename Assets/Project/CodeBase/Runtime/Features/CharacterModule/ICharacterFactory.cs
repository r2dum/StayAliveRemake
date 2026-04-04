using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public interface ICharacterFactory
    {
        UniTask<Character> CreateCharacter(Vector3 at);
    }
}