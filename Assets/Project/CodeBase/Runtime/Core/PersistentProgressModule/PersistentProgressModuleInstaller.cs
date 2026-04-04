using Zenject;

namespace CodeBase.Runtime.Core.PersistentProgressModule
{
    public class PersistentProgressModuleInstaller : Installer<PersistentProgressModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PersistentProgressService>()
                .AsSingle();
        }
    }
}