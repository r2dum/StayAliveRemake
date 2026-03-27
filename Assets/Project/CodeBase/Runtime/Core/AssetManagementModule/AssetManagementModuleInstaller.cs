using Zenject;

namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public class AssetManagementModuleInstaller : Installer<AssetManagementModuleInstaller>
    {
        public override void InstallBindings() =>
            Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
    }
}