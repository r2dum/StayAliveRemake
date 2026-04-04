using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public interface IBiomeFactory
    {
        UniTask<BiomeView> CreateBiome();
    }
}