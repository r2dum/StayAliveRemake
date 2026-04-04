using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public interface ICharacterProvider
    {
        Character Character { get; }
        UniTask CreateCharacter(Vector3 at);
    }
}