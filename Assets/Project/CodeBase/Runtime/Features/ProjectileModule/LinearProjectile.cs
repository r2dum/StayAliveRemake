using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    public class LinearProjectile : ProjectileBase
    {
        protected override void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, TargetPosition) < 0.1f)
                OnHit();
        }
    }
}