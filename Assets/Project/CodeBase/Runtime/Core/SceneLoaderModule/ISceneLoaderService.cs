using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Core.SceneLoaderModule
{
    public interface ISceneLoaderService
    {
        UniTask LoadAsync(string nextScene);
    }
}