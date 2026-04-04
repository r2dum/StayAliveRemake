using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _jumpTime = 0.35f;
        [SerializeField] private float _jumpHeight = 1.0f;

        private bool _isMoving;

        private void Start() =>
            _rigidbody.isKinematic = true;

        public async void Move(Vector3 direction, float angle)
        {
            if (_isMoving)
                await UniTask.WaitUntil(() => _isMoving == false, cancellationToken: destroyCancellationToken);

            Vector3 position = transform.position;
            Vector3 finalPosition = position + direction;

            if (Physics.CheckSphere(finalPosition + Vector3.up * 0.5f, 0.1f))
                return;

            _isMoving = true;
            _transform.DORotate(new Vector3(0f, angle, 0f), 0.15f).SetEase(Ease.OutQuad);
            await _transform.DOJump(finalPosition, _jumpHeight, 1, _jumpTime)
                .ToUniTask(cancellationToken: destroyCancellationToken);
            _isMoving = false;
        }
    }
}