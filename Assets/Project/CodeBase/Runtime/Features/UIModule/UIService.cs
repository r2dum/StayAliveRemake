using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Features.UIModule.Window;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.UIModule
{
    public class UIService : IUIService, IDisposable
    {
        private readonly IUIFactory _uiFactory;
        private readonly ILogService _logService;

        private readonly List<WindowPresenterBase> _openedPopUps = new();
        private WindowPresenterBase _openedWindow;

        public event Action<WindowPresenterBase, IWindowBase> WindowOpened;
        public event Action<WindowPresenterBase, IWindowBase> PopUpOpened;
        public event Action<WindowPresenterBase> PopUpClosed;
        public event Action WindowClosed;

        public UIService(IUIFactory uiFactory, ILogService logService)
        {
            _uiFactory = uiFactory;
            _logService = logService;
        }

        public void Dispose()
        {
            CloseOpenedWindow();
            CloseAllPopUps();
        }

        public async UniTask OpenWindow<T>(string address) where T : WindowPresenterBase
        {
            if (_openedWindow?.Name == address)
            {
                _logService.Write($"{address} is already open");
                return;
            }

            CloseOpenedWindow();
            WindowPresenterBase windowPresenterBase = _uiFactory.CreateWindowPresenter<T>(address);
            IWindowBase window = await _uiFactory.CreateWindow(address);
            WindowOpened?.Invoke(windowPresenterBase, window);
            _openedWindow = windowPresenterBase;
            _logService.Write($"Opened Window: {_openedWindow.Name}");
        }

        public void CloseOpenedWindow()
        {
            if (_openedWindow == null)
                return;

            WindowClosed?.Invoke();
            _openedWindow.Dispose();
            _logService.Write($"Closed Window: {_openedWindow.Name}");
            _openedWindow = null;
        }

        public async UniTask OpenPopUp<T>(string address) where T : WindowPresenterBase
        {
            if (_openedPopUps.Exists(p => p.Name == address))
            {
                _logService.Write($"{address} is already open");
                return;
            }

            WindowPresenterBase windowPresenterBase = _uiFactory.CreateWindowPresenter<T>(address);
            IWindowBase popUp = await _uiFactory.CreatePopUp(address);
            windowPresenterBase.CloseRequested += ClosePopUp;
            _openedPopUps.Add(windowPresenterBase);
            PopUpOpened?.Invoke(windowPresenterBase, popUp);
            WriteOpenedPopUps();
        }

        public void ClosePopUp(string name)
        {
            WindowPresenterBase windowPresenterBase = _openedPopUps.Find(p => p.Name == name);
            ClosePopUp(windowPresenterBase);
        }

        public void CloseAllPopUps()
        {
            List<WindowPresenterBase> openedPopUps = new(_openedPopUps);
            foreach (WindowPresenterBase openedPopUp in openedPopUps)
                ClosePopUp(openedPopUp);
        }

        private void ClosePopUp(WindowPresenterBase windowPresenterBase)
        {
            if (_openedPopUps.Contains(windowPresenterBase) == false)
                return;

            windowPresenterBase.CloseRequested -= ClosePopUp;
            PopUpClosed?.Invoke(windowPresenterBase);
            windowPresenterBase.Dispose();
            _openedPopUps.Remove(windowPresenterBase);
            WriteOpenedPopUps();
        }

        private void WriteOpenedPopUps()
        {
            if (_openedPopUps.Count == 0)
            {
                _logService.Write("Opened PopUps: [0]");
                return;
            }

            string popUpNames = string.Join(", ", _openedPopUps.Select(p => p.Name));
            _logService.Write($"Opened PopUps: [{popUpNames}]");
        }
    }
}