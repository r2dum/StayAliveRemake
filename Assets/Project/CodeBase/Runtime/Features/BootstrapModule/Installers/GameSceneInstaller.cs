using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.CharacterModule;
using CodeBase.Runtime.Features.GameFlowStateMachineModule;
using CodeBase.Runtime.Features.ProjectileSpawnerFlowStateMachineModule;
using Zenject;

namespace CodeBase.Runtime.Features.BootstrapModule.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle();

            BiomeModuleInstaller.Install(Container);
            CharacterInstaller.Install(Container);
            GameFlowStateMachineInstaller.Install(Container);
            ProjectileSpawnerFlowStateMachineInstaller.Install(Container);
        }
    }
}