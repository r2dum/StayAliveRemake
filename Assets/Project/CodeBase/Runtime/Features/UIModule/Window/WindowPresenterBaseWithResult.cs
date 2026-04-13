using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.UIModule.Window
{
    public abstract class WindowPresenterBaseWithResult<TResult> : WindowPresenterBase
    {
        private UniTaskCompletionSource<TResult> _taskCompletionSource;

        public UniTask<TResult> AwaitResult()
        {
            _taskCompletionSource = new UniTaskCompletionSource<TResult>();
            return _taskCompletionSource.Task;
        }

        protected void SetResult(TResult result) =>
            _taskCompletionSource?.TrySetResult(result);
    }
}