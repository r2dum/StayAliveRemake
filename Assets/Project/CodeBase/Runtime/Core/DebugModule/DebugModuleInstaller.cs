using CodeBase.Runtime.Core.DebugModule.Log;
using Zenject;

namespace CodeBase.Runtime.Core.DebugModule
{
    public class DebugModuleInstaller : Installer<DebugModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<LogService>()
                .AsSingle();
        }
    }
}