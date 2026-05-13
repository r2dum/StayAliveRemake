using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.SurvivalTimerModule
{
    public class SurvivalTimer : ISurvivalTimer, ITickable
    {
        private bool _enabled;

        public float CurrentTime { get; private set; }

        public event Action<float> Changed;

        public void Start() =>
            _enabled = true;

        public void Pause() =>
            _enabled = false;

        public void Cancel()
        {
            _enabled = false;
            CurrentTime = 0f;
        }

        public void Tick()
        {
            if (_enabled == false)
                return;
            CurrentTime += Time.deltaTime;
            Changed?.Invoke(CurrentTime);
        }
    }
}