using System.Collections.Generic;
using CodeBase.Runtime.Features.UIModule.Window;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.UIModule
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private RectTransform _windowLayer;
        [SerializeField] private RectTransform _popUpLayer;

        private readonly Dictionary<WindowPresenterBase, IWindowBase> _openedPopUps = new();
        private IWindowBase _openedWindow;

        private IUIService _uiService;

        public RectTransform WindowLayer => _windowLayer;
        public RectTransform PopUpLayer => _popUpLayer;

        [Inject]
        private void Construct(IUIService uiService) =>
            _uiService = uiService;

        private void Start()
        {
            _uiService.WindowOpened += OnWindowOpened;
            _uiService.WindowClosed += OnWindowClosed;
            _uiService.PopUpOpened += OnPopUpOpened;
            _uiService.PopUpClosed += OnPopUpClosed;
        }

        private void OnDestroy()
        {
            _uiService.WindowOpened -= OnWindowOpened;
            _uiService.WindowClosed -= OnWindowClosed;
            _uiService.PopUpOpened -= OnPopUpOpened;
            _uiService.PopUpClosed -= OnPopUpClosed;
        }

        private void OnWindowOpened(WindowPresenterBase windowPresenterBase, IWindowBase windowBase)
        {
            _openedWindow?.Close();
            windowBase.Open(windowPresenterBase);
            _openedWindow = windowBase;
        }

        private void OnWindowClosed()
        {
            _openedWindow?.Close();
            _openedWindow = null;
        }

        private void OnPopUpOpened(WindowPresenterBase windowPresenterBase, IWindowBase windowBase)
        {
            windowBase.Open(windowPresenterBase);
            _openedPopUps.Add(windowPresenterBase, windowBase);
        }

        private void OnPopUpClosed(WindowPresenterBase windowPresenterBase)
        {
            IWindowBase openedPopUp = _openedPopUps[windowPresenterBase];
            openedPopUp?.Close();
            _openedPopUps.Remove(windowPresenterBase);
        }
    }
}