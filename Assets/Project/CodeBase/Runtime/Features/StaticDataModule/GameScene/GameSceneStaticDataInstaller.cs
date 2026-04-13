using Zenject;

namespace CodeBase.Runtime.Features.StaticDataModule.GameScene
{
    public class GameSceneStaticDataInstaller : Installer<GameSceneStaticDataInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameSceneStaticDataService>()
                .AsSingle();
        }
    }
}