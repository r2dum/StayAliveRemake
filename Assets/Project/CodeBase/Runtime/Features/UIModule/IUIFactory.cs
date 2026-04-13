using CodeBase.Runtime.Features.UIModule.Window;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.UIModule
{
    public interface IUIFactory
    {
        UniTask CreateUIRoot();
        WindowPresenterBase CreateWindowPresenter<T>(string name) where T : WindowPresenterBase;
        UniTask<IWindowBase> CreateWindow(string address);
        UniTask<IWindowBase> CreatePopUp(string address);
    }
}