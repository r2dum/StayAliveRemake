using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public interface IBiomeProvider
    {
        BiomeView BiomeView { get; }
        UniTask CreateBiome();
    }
}