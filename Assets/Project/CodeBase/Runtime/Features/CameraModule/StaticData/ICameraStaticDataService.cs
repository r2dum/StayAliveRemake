using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.CameraModule.StaticData
{
    public interface ICameraStaticDataService
    {
        UniTask LoadAsync();
        CameraStaticData ForCameraStaticData(CameraStateType cameraStateType);
    }
}