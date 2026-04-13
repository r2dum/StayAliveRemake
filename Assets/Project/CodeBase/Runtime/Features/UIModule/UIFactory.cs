using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Features.UIModule.Window;
using CodeBase.Shared;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.UIModule
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        private UIRoot _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public async UniTask CreateUIRoot()
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(AssetAddress.UI.UIRoot);
            _uiRoot = _instantiator.InstantiatePrefabForComponent<UIRoot>(prefab);
        }

        public WindowPresenterBase CreateWindowPresenter<T>(string name) where T : WindowPresenterBase
        {
            T windowPresenterBase = _instantiator.Instantiate<T>();
            windowPresenterBase.Name = name;
            return windowPresenterBase;
        }

        public async UniTask<IWindowBase> CreateWindow(string address) =>
            await CreateWindow(address, _uiRoot.WindowLayer);

        public async UniTask<IWindowBase> CreatePopUp(string address) =>
            await CreateWindow(address, _uiRoot.PopUpLayer);

        private async UniTask<IWindowBase> CreateWindow(string address, Transform parent)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(address);
            return _instantiator.InstantiatePrefabForComponent<IWindowBase>(prefab, parent);
        }
    }
}