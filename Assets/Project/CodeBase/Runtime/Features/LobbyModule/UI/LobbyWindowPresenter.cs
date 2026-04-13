using CodeBase.Runtime.Features.GameFlowStateMachineModule;
using CodeBase.Runtime.Features.GameFlowStateMachineModule.States;
using CodeBase.Runtime.Features.SettingsModule.UI;
using CodeBase.Runtime.Features.UIModule;
using CodeBase.Runtime.Features.UIModule.Window;
using CodeBase.Shared;

namespace CodeBase.Runtime.Features.LobbyModule.UI
{
    public class LobbyWindowPresenter : WindowPresenterBase
    {
        private readonly GameFlowStateMachine _gameFlowStateMachine;
        private readonly IUIService _uiService;

        public LobbyWindowPresenter(GameFlowStateMachine gameFlowStateMachine, IUIService uiService)
        {
            _gameFlowStateMachine = gameFlowStateMachine;
            _uiService = uiService;
        }

        public void OnPlayButtonClicked() =>
            _gameFlowStateMachine.Enter<GameplayFlowState>();

        public async void OnSettingsButtonClicked() =>
            await _uiService.OpenPopUp<SettingsPopUpPresenter>(AssetAddress.UI.SettingsPopUp);
    }
}