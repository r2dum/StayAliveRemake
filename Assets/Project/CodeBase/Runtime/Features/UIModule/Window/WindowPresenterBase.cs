using System;

namespace CodeBase.Runtime.Features.UIModule.Window
{
    public abstract class WindowPresenterBase : IDisposable
    {
        public event Action<WindowPresenterBase> CloseRequested;

        public string Name { get; set; }

        public void RequestClose() =>
            CloseRequested?.Invoke(this);

        public virtual void Dispose()
        {
        }
    }
}