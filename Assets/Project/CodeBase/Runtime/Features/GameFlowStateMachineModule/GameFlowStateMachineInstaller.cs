using Zenject;

namespace CodeBase.Runtime.Features.GameFlowStateMachineModule
{
    public class GameFlowStateMachineInstaller : Installer<GameFlowStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameFlowStateMachine>()
                .AsSingle();
        }
    }
}