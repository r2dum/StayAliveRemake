using System;
using CodeBase.Runtime.Core.InputModule;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public class CharacterInput : IInitializable, IDisposable
    {
        private readonly ICharacterProvider _characterProvider;
        private readonly IInputListener _inputListener;

        public CharacterInput(ICharacterProvider characterProvider, IInputListener inputListener)
        {
            _characterProvider = characterProvider;
            _inputListener = inputListener;
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
            _characterProvider.Character.Move(direction, angle);
        }
    }
}