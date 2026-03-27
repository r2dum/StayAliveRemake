using CodeBase.Runtime.Core.StateMachineModule;
using Zenject;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule
{
    public class AppFlowStateMachineInstaller : Installer<AppFlowStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<AppFlowStateMachine>()
                .AsSingle();
        }
    }
}