using Zenject;

namespace CodeBase.Runtime.Core.StateMachineModule
{
    public class CoreStateMachineInstaller : Installer<CoreStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle();
        }
    }
}