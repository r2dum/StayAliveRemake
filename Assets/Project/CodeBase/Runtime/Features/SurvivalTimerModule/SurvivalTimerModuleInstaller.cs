using Zenject;

namespace CodeBase.Runtime.Features.SurvivalTimerModule
{
    public class SurvivalTimerModuleInstaller : Installer<SurvivalTimerModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SurvivalTimer>()
                .AsSingle();
        }
    }
}