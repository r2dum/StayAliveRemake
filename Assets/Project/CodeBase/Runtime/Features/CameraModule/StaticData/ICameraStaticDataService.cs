using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.CameraModule.StaticData
{
    public interface ICameraStaticDataService
    {
        UniTask InitializeAsync();
        CameraStaticData ForCameraStaticData(CameraStateType cameraStateType);
    }
}