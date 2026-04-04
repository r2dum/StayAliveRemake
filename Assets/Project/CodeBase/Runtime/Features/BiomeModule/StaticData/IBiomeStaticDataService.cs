using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    public interface IBiomeStaticDataService
    {
        UniTask InitializeAsync();
        BiomeConfig ForBiomeConfig();
    }
}