using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.BiomePlatformModule;
using Zenject;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public class BiomeModuleInstaller : Installer<BiomeModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<BiomeStaticDataService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BiomePlatformRegistry>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BiomeFactory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BiomeProvider>()
                .AsSingle();
        }
    }
}