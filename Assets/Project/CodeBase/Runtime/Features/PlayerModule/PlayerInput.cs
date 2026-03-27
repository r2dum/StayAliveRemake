using System;
using CodeBase.Runtime.Core.InputModule;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.PlayerModule
{
    public class PlayerInput : IInitializable, IDisposable
    {
        private readonly IInputListener _inputListener;
        private readonly Player _player;

        public PlayerInput(IInputListener inputListener, Player player)
        {
            _inputListener = inputListener;
            _player = player;
        }

        public void Initialize() =>
            _inputListener.Swiped += OnSwiped;

        public void Dispose() =>
            _inputListener.Swiped -= OnSwiped;

        private void OnSwiped(DirectionType directionType)
        {
            (Vector3 direction, float angle) = directionType switch
            {
                DirectionType.Forward => (new Vector3(0, 0, 1.25f), -90f),
                DirectionType.Backward => (new Vector3(0, 0, -1.25f), 90f),
                DirectionType.Left => (new Vector3(-1.25f, 0, 0), 180f),
                DirectionType.Right => (new Vector3(1.25f, 0, 0), 0f),
                _ => throw new ArgumentOutOfRangeException(nameof(directionType), directionType, null)
            };
            _player.Move(direction, angle);
        }
    }
}