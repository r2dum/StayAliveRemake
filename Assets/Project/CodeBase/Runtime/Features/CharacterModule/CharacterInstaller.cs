using CodeBase.Runtime.Features.CharacterModule.StaticData;
using Zenject;

namespace CodeBase.Runtime.Features.CharacterModule
{
    public class CharacterInstaller : Installer<CharacterInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CharacterStaticDataService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CharacterFactory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CharacterProvider>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CharacterInput>()
                .AsSingle();
        }
    }
}