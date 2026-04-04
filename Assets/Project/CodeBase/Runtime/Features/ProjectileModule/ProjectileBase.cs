using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        protected Vector3 TargetPosition;
        protected float Speed;
        protected bool IsInitialized;

        public virtual void Initialize(Vector3 target, float speed)
        {
            TargetPosition = target;
            Speed = speed;
            IsInitialized = true;
        }

        private void Update()
        {
            if (IsInitialized)
                Move();
        }

        protected abstract void Move();

        protected virtual void OnHit()
        {
            IsInitialized = false;
            gameObject.SetActive(false);
        }
    }
}