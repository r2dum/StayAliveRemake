using System;
using CodeBase.Runtime.Features.UIModule.Window;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.UIModule
{
    public interface IUIService
    {
        event Action<WindowPresenterBase, IWindowBase> WindowOpened;
        event Action<WindowPresenterBase, IWindowBase> PopUpOpened;
        event Action<WindowPresenterBase> PopUpClosed;
        event Action WindowClosed;

        UniTask OpenWindow<T>(string address) where T : WindowPresenterBase;
        void CloseOpenedWindow();
        UniTask OpenPopUp<T>(string address) where T : WindowPresenterBase;
        void ClosePopUp(string name);
        void CloseAllPopUps();
    }
}