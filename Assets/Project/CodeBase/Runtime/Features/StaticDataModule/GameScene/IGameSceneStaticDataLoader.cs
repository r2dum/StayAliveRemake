using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.StaticDataModule.GameScene
{
    public interface IGameSceneStaticDataLoader
    {
        UniTask LoadAsync();
    }
}