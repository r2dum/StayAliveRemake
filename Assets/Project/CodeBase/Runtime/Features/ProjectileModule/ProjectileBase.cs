using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        protected AnimationCurve AnimationCurve;

        public void SetAnimationCurve(AnimationCurve animationCurve) =>
            AnimationCurve = animationCurve;

        public async UniTask Launch(Vector3 from, Vector3 to, float duration)
        {
            transform.position = from;
            await MoveAsync(from, to, duration);
            OnHit();
        }

        protected abstract UniTask MoveAsync(Vector3 from, Vector3 to, float duration);

        protected virtual void OnHit() =>
            Destroy(gameObject);
    }
}