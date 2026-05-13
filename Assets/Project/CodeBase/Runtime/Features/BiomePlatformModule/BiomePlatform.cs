using UnityEngine;

namespace CodeBase.Runtime.Features.BiomePlatformModule
{
    public class BiomePlatform : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private Transform _hitTransform;

        public int Id => _id;
        public Vector3 HitPosition => _hitTransform.position;
    }
}