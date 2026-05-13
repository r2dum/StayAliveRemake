using CodeBase.Runtime.Core.StateMachineModule;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.CharacterModule;
using CodeBase.Runtime.Features.GameFlowStateMachineModule;
using CodeBase.Runtime.Features.ProjectileSpawnerModule;
using CodeBase.Runtime.Features.StaticDataModule.GameScene;
using CodeBase.Runtime.Features.SurvivalTimerModule;
using CodeBase.Runtime.Features.UIModule;
using Zenject;

namespace CodeBase.Runtime.Features.BootstrapModule.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            CoreStateMachineInstaller.Install(Container);
            BiomeModuleInstaller.Install(Container);
            CharacterInstaller.Install(Container);
            GameSceneStaticDataInstaller.Install(Container);
            SurvivalTimerModuleInstaller.Install(Container);
            UIModuleInstaller.Install(Container);
            GameFlowStateMachineInstaller.Install(Container);
            ProjectileSpawnerModuleInstaller.Install(Container);
        }
    }
}