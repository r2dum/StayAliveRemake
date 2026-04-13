using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Features.UIModule.Animations
{
    public class UIFadeImageAnimation : UITweenAnimation
    {
        [SerializeField] private Image _fadedImage;
        [SerializeField] private float _fadeValue = 0.5f;

        public override async UniTask Show(CancellationToken cancellationToken)
        {
            _fadedImage.DOFade(0f, 0f);
            await _fadedImage.DOFade(_fadeValue, _showDuration)
                .ToUniTask(cancellationToken: cancellationToken);
        }

        public override async UniTask Hide(CancellationToken cancellationToken) =>
            await _fadedImage.DOFade(0f, _hideDuration)
                .ToUniTask(cancellationToken: cancellationToken);
    }
}