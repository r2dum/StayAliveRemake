using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace CodeBase.Runtime.Core.SceneLoaderModule
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask LoadAsync(string nextScene)
        {
            AsyncOperationHandle<SceneInstance> handler =
                Addressables.LoadSceneAsync(nextScene, LoadSceneMode.Single, false);
            await handler.ToUniTask();
            await handler.Result.ActivateAsync().ToUniTask();
        }
    }
}