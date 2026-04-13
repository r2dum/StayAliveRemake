using CodeBase.Runtime.Features.UIModule.Window;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Features.LobbyModule.UI
{
    public class LobbyWindow : WindowBase<LobbyWindowPresenter>
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        protected override void SubscribeListeners()
        {
            base.SubscribeListeners();
            _playButton.onClick.AddListener(WindowPresenter.OnPlayButtonClicked);
            _settingsButton.onClick.AddListener(WindowPresenter.OnSettingsButtonClicked);
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            _playButton.onClick.RemoveListener(WindowPresenter.OnPlayButtonClicked);
            _settingsButton.onClick.RemoveListener(WindowPresenter.OnSettingsButtonClicked);
        }
    }
}