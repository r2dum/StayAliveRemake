using CodeBase.Runtime.Features.UIModule.Window;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Features.UIModule.PopUp
{
    public abstract class PopUpBase<T> : WindowBase<T> where T : WindowPresenterBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _alternativeCloseButton;

        protected override void SubscribeListeners()
        {
            base.SubscribeListeners();
            _closeButton?.onClick.AddListener(OnCloseButtonClicked);
            _alternativeCloseButton?.onClick.AddListener(OnCloseButtonClicked);
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            _closeButton?.onClick.RemoveListener(OnCloseButtonClicked);
            _alternativeCloseButton?.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked() =>
            WindowPresenter.RequestClose();
    }
}