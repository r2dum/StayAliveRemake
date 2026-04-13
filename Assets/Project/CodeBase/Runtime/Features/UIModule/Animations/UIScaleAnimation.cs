using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.UIModule.Animations
{
    public class UIScaleAnimation : UITweenAnimation
    {
        [SerializeField] private RectTransform _uiTransform;
        [SerializeField] private Vector3 _showScaleValue = Vector3.one;
        [SerializeField] private Vector3 _hideScaleValue;

        public override async UniTask Show(CancellationToken cancellationToken)
        {
            _uiTransform.localScale = _hideScaleValue;
            await _uiTransform.DOScale(_showScaleValue, _showDuration)
                .SetEase(_showEaseType)
                .ToUniTask(cancellationToken: cancellationToken);
        }

        public override async UniTask Hide(CancellationToken cancellationToken) =>
            await _uiTransform.DOScale(_hideScaleValue, _hideDuration)
                .SetEase(_hideEaseType)
                .ToUniTask(cancellationToken: cancellationToken);
    }
}