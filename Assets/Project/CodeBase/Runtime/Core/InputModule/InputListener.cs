using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CodeBase.Runtime.Core.InputModule
{
    public class InputListener : IInputListener, IInitializable, IDisposable
    {
        private const string PlayerActionMap = "Player";
        private const string PrimaryContactAction = "PrimaryContact";
        private const string PrimaryPositionAction = "PrimaryPosition";
        private const float SwipeThreshold = 50f;

        private readonly InputActionAsset _inputActionAsset;

        private InputActionMap _playerInputActionMap;
        private InputAction _primaryContactAction;
        private InputAction _primaryPositionAction;
        private Vector2 _startPosition;

        public event Action<DirectionType> Swiped;

        public InputListener(InputActionAsset inputActionAsset) =>
            _inputActionAsset = inputActionAsset;

        public void Initialize()
        {
            _inputActionAsset.Enable();
            _playerInputActionMap = _inputActionAsset.FindActionMap(PlayerActionMap);
            _primaryContactAction = _playerInputActionMap.FindAction(PrimaryContactAction);
            _primaryPositionAction = _playerInputActionMap.FindAction(PrimaryPositionAction);
            _primaryContactAction.started += OnStartTouch;
            _primaryContactAction.canceled += OnEndTouch;
        }

        public void Dispose()
        {
            _primaryContactAction.started -= OnStartTouch;
            _primaryContactAction.canceled -= OnEndTouch;
            _inputActionAsset.Disable();
        }

        public void EnablePlayerActionMap() =>
            _playerInputActionMap.Enable();

        public void DisablePlayerActionMap() =>
            _playerInputActionMap.Disable();

        private void OnStartTouch(InputAction.CallbackContext context) =>
            _startPosition = _primaryPositionAction.ReadValue<Vector2>();

        private void OnEndTouch(InputAction.CallbackContext context)
        {
            Vector2 endPosition = _primaryPositionAction.ReadValue<Vector2>();
            Vector2 swipeDelta = endPosition - _startPosition;
            if (swipeDelta.magnitude > SwipeThreshold)
                DetectSwipe(swipeDelta);
        }

        private void DetectSwipe(Vector2 delta)
        {
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                Swiped?.Invoke(delta.x > 0 ? DirectionType.Right : DirectionType.Left);
            else
                Swiped?.Invoke(delta.y > 0 ? DirectionType.Forward : DirectionType.Backward);
        }
    }
}