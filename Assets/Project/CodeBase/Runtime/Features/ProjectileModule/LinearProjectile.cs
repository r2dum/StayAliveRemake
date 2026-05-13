using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    public class LinearProjectile : ProjectileBase
    {
        protected override async UniTask MoveAsync(Vector3 from, Vector3 to, float duration)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float progress = elapsed / duration;
                transform.position = Vector3.Lerp(from, to, AnimationCurve.Evaluate(progress));
                await UniTask.Yield(PlayerLoopTiming.Update, destroyCancellationToken);
            }

            transform.position = to;
        }
    }
}