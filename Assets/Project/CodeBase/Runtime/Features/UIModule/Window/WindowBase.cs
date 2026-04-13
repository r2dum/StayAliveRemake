using CodeBase.Runtime.Features.UIModule.Animations;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.UIModule.Window
{
    public abstract class WindowBase<T> : MonoBehaviour, IWindowBase where T : WindowPresenterBase
    {
        [SerializeField] protected UIAnimationBase _uiAnimation;
        protected T WindowPresenter;

        public void Open(WindowPresenterBase windowPresenterBase)
        {
            WindowPresenter = (T)windowPresenterBase;
            OnStart();
            SubscribeListeners();
            _uiAnimation?.Show(destroyCancellationToken).Forget();
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void SubscribeListeners()
        {
        }

        protected virtual void CleanUp()
        {
        }

        public async void Close()
        {
            CleanUp();
            if (_uiAnimation != null)
                await _uiAnimation.Hide(destroyCancellationToken);
            Destroy(gameObject);
        }
    }
}