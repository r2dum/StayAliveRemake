using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.BiomeModule
{
    public class BiomeProvider : IBiomeProvider
    {
        private readonly IBiomeFactory _biomeFactory;

        public BiomeView BiomeView { get; private set; }

        public BiomeProvider(IBiomeFactory biomeFactory) =>
            _biomeFactory = biomeFactory;

        public async UniTask CreateBiome() =>
            BiomeView = await _biomeFactory.CreateBiome();
    }
}