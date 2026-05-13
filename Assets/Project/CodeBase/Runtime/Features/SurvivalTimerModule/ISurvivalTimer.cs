using System;

namespace CodeBase.Runtime.Features.SurvivalTimerModule
{
    public interface ISurvivalTimer
    {
        float CurrentTime { get; }
        event Action<float> Changed;
        void Start();
        void Pause();
        void Cancel();
    }
}