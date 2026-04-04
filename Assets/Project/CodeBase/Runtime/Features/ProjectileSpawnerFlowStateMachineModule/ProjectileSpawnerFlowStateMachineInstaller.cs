using Zenject;

namespace CodeBase.Runtime.Features.ProjectileSpawnerFlowStateMachineModule
{
    public class ProjectileSpawnerFlowStateMachineInstaller : Installer<ProjectileSpawnerFlowStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ProjectileSpawnerFlowStateMachine>()
                .AsSingle();
        }
    }
}