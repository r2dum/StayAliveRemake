using CodeBase.Runtime.Features.GameFlowStateMachineModule;
using CodeBase.Runtime.Features.GameFlowStateMachineModule.States;
using CodeBase.Runtime.Features.UIModule.Window;

namespace CodeBase.Runtime.Features.GameplayModule.UI
{
    public class GameplayWindowPresenter : WindowPresenterBase
    {
        private readonly GameFlowStateMachine _gameFlowStateMachine;

        public GameplayWindowPresenter(GameFlowStateMachine gameFlowStateMachine) =>
            _gameFlowStateMachine = gameFlowStateMachine;

        public void OnLobbyButtonClicked() =>
            _gameFlowStateMachine.Enter<LobbyFlowState>();
    }
}