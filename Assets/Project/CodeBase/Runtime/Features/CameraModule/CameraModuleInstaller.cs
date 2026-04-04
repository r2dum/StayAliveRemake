using CodeBase.Runtime.Features.CameraModule.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.CameraModule
{
    public class CameraModuleInstaller : MonoInstaller
    {
        [SerializeField] private CamerasHolder _camerasHolder;

        public override void InstallBindings()
        {
            Container
                .Bind<CamerasHolder>()
                .FromInstance(_camerasHolder)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CameraStaticDataService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CameraService>()
                .AsSingle();
        }
    }
}