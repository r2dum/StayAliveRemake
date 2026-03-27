using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Core.DebugModule;
using CodeBase.Runtime.Core.SceneLoaderModule;
using CodeBase.Runtime.Features.AppFlowStateMachineModule;
using Zenject;

namespace CodeBase.Runtime.Features.BootstrapModule.Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            DebugModuleInstaller.Install(Container);
            AssetManagementModuleInstaller.Install(Container);
            SceneLoaderModuleInstaller.Install(Container);
            AppFlowStateMachineInstaller.Install(Container);
        }
    }
}