namespace CodeBase.Runtime.Features.BiomeModule
{
    public interface IBiomeProvider
    {
        BiomeView BiomeView { get; }
        void CreateBiome();
    }
}