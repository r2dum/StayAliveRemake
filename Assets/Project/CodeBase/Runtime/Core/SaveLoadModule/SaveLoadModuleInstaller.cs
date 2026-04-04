using Zenject;

namespace CodeBase.Runtime.Core.SaveLoadModule
{
    public class SaveLoadModuleInstaller : Installer<SaveLoadModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
        }
    }
}