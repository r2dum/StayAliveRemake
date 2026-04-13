using Zenject;

namespace CodeBase.Runtime.Features.AppFlowStateMachineModule
{
    public class AppFlowStateMachineInstaller : Installer<AppFlowStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<AppFlowStateMachine>()
                .AsSingle();
        }
    }
}