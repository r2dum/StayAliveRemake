using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    public class ArcProjectile : ProjectileBase
    {
        [SerializeField] private float _arcHeight = 2f;

        protected override async UniTask MoveAsync(Vector3 from, Vector3 to, float duration)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float progress = elapsed / duration;

                Vector3 currentPosition = Vector3.Lerp(from, to, AnimationCurve.Evaluate(progress));
                float yOffset = Mathf.Sin(progress * Mathf.PI) * _arcHeight;
                currentPosition.y += yOffset;
                transform.position = currentPosition;

                await UniTask.Yield(PlayerLoopTiming.Update, destroyCancellationToken);
            }
        }
    }
}