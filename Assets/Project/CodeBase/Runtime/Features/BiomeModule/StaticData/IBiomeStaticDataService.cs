using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    public interface IBiomeStaticDataService
    {
        UniTask LoadAsync();
        BiomeConfig ForBiomeConfig();
    }
}