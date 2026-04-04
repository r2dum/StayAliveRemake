using System;
using CodeBase.Runtime.Features.CameraModule.StaticData;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.CameraModule
{
    public class CameraService : ICameraService
    {
        private readonly ICameraStaticDataService _cameraStaticDataService;
        private readonly CamerasHolder _camerasHolder;

        public CameraService(ICameraStaticDataService cameraStaticDataService, CamerasHolder camerasHolder)
        {
            _cameraStaticDataService = cameraStaticDataService;
            _camerasHolder = camerasHolder;
        }

        public async UniTask SwitchState(CameraStateType to)
        {
            CameraStaticData cameraStaticData = _cameraStaticDataService.ForCameraStaticData(to);
            Camera mainCamera = _camerasHolder.MainCamera;

            mainCamera.transform.DOMove(cameraStaticData.Position, cameraStaticData.TransitionDuration)
                .SetEase(cameraStaticData.TransitionEase);
            mainCamera.transform.DORotate(cameraStaticData.Rotation, cameraStaticData.TransitionDuration)
                .SetEase(cameraStaticData.TransitionEase);
            mainCamera.DOOrthoSize(cameraStaticData.OrthographicSize, cameraStaticData.TransitionDuration);
            await UniTask.Delay(TimeSpan.FromSeconds(cameraStaticData.TransitionDuration));
        }
    }
}