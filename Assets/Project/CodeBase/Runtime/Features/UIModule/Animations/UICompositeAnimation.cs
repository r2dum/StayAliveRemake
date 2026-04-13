using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.UIModule.Animations
{
    public class UICompositeAnimation : UIAnimationBase
    {
        [SerializeField] private UIAnimationBase[] _animations;

        public override async UniTask Show(CancellationToken cancellationToken)
        {
            IEnumerable<UniTask> uniTasks = _animations.Select(a => a.Show(cancellationToken));
            await UniTask.WhenAll(uniTasks);
        }

        public override async UniTask Hide(CancellationToken cancellationToken)
        {
            IEnumerable<UniTask> uniTasks = _animations.Select(a => a.Hide(cancellationToken));
            await UniTask.WhenAll(uniTasks);
        }
    }
}