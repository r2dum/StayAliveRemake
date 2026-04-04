using System;
using CodeBase.Runtime.Features.GameFlowStateMachineModule.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule.UI
{
    public class GameFlowStateSwitchButton : MonoBehaviour
    {
        [SerializeField] private GameFlowStateType _stateType;
        [SerializeField] private Button _button;

        private GameFlowStateMachine _gameFlowStateMachine;

        [Inject]
        private void Construct(GameFlowStateMachine gameFlowStateMachine) =>
            _gameFlowStateMachine = gameFlowStateMachine;

        private void OnEnable() =>
            _button.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _button.onClick.RemoveAllListeners();

        private void OnClick()
        {
            switch (_stateType)
            {
                case GameFlowStateType.Lobby:
                    _gameFlowStateMachine.Enter<LobbyFlowState>();
                    break;
                case GameFlowStateType.Gameplay:
                    _gameFlowStateMachine.Enter<GameplayFlowState>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}