using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.UIModule.Animations
{
    public class UIPositionAnimation : UITweenAnimation
    {
        [SerializeField] private RectTransform _uiTransform;
        [SerializeField] private Vector2 _showPosition = Vector2.one;
        [SerializeField] private Vector2 _hidePosition;

        public override async UniTask Show(CancellationToken cancellationToken)
        {
            _uiTransform.anchoredPosition = _hidePosition;
            await _uiTransform.DOAnchorPos(_showPosition, _showDuration)
                .SetEase(_showEaseType)
                .ToUniTask(cancellationToken: cancellationToken);
        }

        public override async UniTask Hide(CancellationToken cancellationToken) =>
            await _uiTransform.DOAnchorPos(_hidePosition, _hideDuration)
                .SetEase(_hideEaseType)
                .ToUniTask(cancellationToken: cancellationToken);
    }
}