using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.UIModule.Animations
{
    public abstract class UIAnimationBase : MonoBehaviour
    {
        public abstract UniTask Show(CancellationToken cancellationToken);
        public abstract UniTask Hide(CancellationToken cancellationToken);

        private void OnDestroy() =>
            transform.DOKill();
    }
}