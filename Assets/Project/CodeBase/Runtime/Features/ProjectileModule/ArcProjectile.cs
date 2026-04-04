using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    public class ArcProjectile : ProjectileBase
    {
        [SerializeField] private float _arcHeight = 2f;
        private Vector3 _startPosition;
        private float _progress;

        public override void Initialize(Vector3 target, float speed)
        {
            base.Initialize(target, speed);
            _startPosition = transform.position;
        }

        protected override void Move()
        {
            _progress += Time.deltaTime * Speed;

            Vector3 currentPosition = Vector3.Lerp(_startPosition, TargetPosition, _progress);

            float yOffset = Mathf.Sin(_progress * Mathf.PI) * _arcHeight;
            currentPosition.y += yOffset;

            transform.position = currentPosition;

            if (_progress >= 1f)
                OnHit();
        }
    }
}