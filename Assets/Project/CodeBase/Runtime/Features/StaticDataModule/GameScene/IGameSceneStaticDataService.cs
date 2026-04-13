using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.StaticDataModule.GameScene
{
    public interface IGameSceneStaticDataService
    {
        UniTask LoadAsync();
    }
}