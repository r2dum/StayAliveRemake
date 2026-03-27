using Zenject;

namespace CodeBase.Runtime.Core.SceneLoaderModule
{
    public class SceneLoaderModuleInstaller : Installer<SceneLoaderModuleInstaller>
    {
        public override void InstallBindings() =>
            Container.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle();
    }
}