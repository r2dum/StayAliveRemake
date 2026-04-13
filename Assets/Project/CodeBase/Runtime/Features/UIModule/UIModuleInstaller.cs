using Zenject;

namespace CodeBase.Runtime.Features.UIModule
{
    public class UIModuleInstaller : Installer<UIModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<UIFactory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<UIService>()
                .AsSingle();
        }
    }
}