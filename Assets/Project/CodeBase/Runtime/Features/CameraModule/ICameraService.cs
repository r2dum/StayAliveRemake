using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.CameraModule
{
    public interface ICameraService
    {
        UniTask SwitchState(CameraStateType to);
    }
}