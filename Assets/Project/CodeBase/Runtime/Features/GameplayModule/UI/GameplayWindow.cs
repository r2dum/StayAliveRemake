using CodeBase.Runtime.Features.UIModule.Window;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Features.GameplayModule.UI
{
    public class GameplayWindow : WindowBase<GameplayWindowPresenter>
    {
        [SerializeField] private Button _lobbyButton;

        protected override void SubscribeListeners()
        {
            base.SubscribeListeners();
            _lobbyButton.onClick.AddListener(WindowPresenter.OnLobbyButtonClicked);
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            _lobbyButton.onClick.RemoveListener(WindowPresenter.OnLobbyButtonClicked);
        }
    }
}