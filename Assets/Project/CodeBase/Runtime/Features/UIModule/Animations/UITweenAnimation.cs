using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.UIModule.Animations
{
    public abstract class UITweenAnimation : UIAnimationBase
    {
        [SerializeField] protected float _showDuration = 0.25f;
        [SerializeField] protected float _hideDuration = 0.25f;
        [SerializeField] protected Ease _showEaseType;
        [SerializeField] protected Ease _hideEaseType;
    }
}