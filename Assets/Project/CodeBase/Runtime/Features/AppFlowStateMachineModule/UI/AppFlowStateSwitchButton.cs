using CodeBase.Runtime.Features.AppFlowStateMachineModule.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule.UI
{
    public class AppFlowStateSwitchButton : MonoBehaviour
    {
        [SerializeField] private AppFlowStateType _type;
        [SerializeField] private Button _button;

        private AppFlowStateMachine _appFlowStateMachine;

        [Inject]
        private void Construct(AppFlowStateMachine appStateMachine) =>
            _appFlowStateMachine = appStateMachine;

        private void OnEnable() =>
            _button.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _button.onClick.RemoveAllListeners();

        private void OnClick()
        {
            _button.onClick.RemoveAllListeners();

            switch (_type)
            {
                case AppFlowStateType.Lobby:
                    _appFlowStateMachine.Enter<LobbyFlowState>();
                    break;
                case AppFlowStateType.Gameplay:
                    _appFlowStateMachine.Enter<GameplayFlowState>();
                    break;
            }
        }
    }
}