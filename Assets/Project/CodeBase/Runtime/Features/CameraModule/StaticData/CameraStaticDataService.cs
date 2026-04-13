using System.Linq;
using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Shared;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.CameraModule.StaticData
{
    public class CameraStaticDataService : ICameraStaticDataService
    {
        private readonly IAssetProvider _assetProvider;

        private CameraConfig _cameraConfig;

        public CameraStaticDataService(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public async UniTask LoadAsync() =>
            _cameraConfig = await _assetProvider.Load<CameraConfig>(AssetAddress.Configs.CameraConfig);

        public CameraStaticData ForCameraStaticData(CameraStateType cameraStateType) =>
            _cameraConfig.CameraStaticsData.FirstOrDefault(c => cameraStateType == c.StateType);
    }
}