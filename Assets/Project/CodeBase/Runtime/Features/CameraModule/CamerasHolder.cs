using UnityEngine;

namespace CodeBase.Runtime.Features.CameraModule
{
    public class CamerasHolder : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;

        public Camera MainCamera => _mainCamera;
    }
}