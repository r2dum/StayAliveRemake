using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.CharacterModule.StaticData
{
    public interface ICharacterStaticDataService
    {
        UniTask LoadAsync();
        CharacterConfig ForCharacterConfig();
    }
}