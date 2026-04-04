using System.Collections.Generic;
using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.PersistentProgressModule;
using CodeBase.Shared;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.BiomeModule.StaticData
{
    public class BiomeStaticDataService : IBiomeStaticDataService
    {
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IAssetProvider _assetProvider;
        private readonly ILogService _logService;

        private readonly Dictionary<string, BiomeDefinition> _biomeDefinitions = new();
        private BiomeDatabaseConfig _biomeDatabaseConfig;
        private BiomeConfig _biomeConfig;

        public BiomeStaticDataService(IPersistentProgressService persistentProgressService,
            IAssetProvider assetProvider, ILogService logService)
        {
            _persistentProgressService = persistentProgressService;
            _assetProvider = assetProvider;
            _logService = logService;
        }

        public async UniTask InitializeAsync()
        {
            await InitializeDatabaseAsync();
            await LoadSelectedBiomeAsync();
        }

        public BiomeConfig ForBiomeConfig() =>
            _biomeConfig;

        private async UniTask InitializeDatabaseAsync()
        {
            _biomeDatabaseConfig = await _assetProvider.Load<BiomeDatabaseConfig>(AssetAddress.BiomeDatabaseConfig);
            foreach (BiomeDefinition biomeDefinition in _biomeDatabaseConfig.BiomeDefinitions)
                _biomeDefinitions[biomeDefinition.Id] = biomeDefinition;
        }

        private async UniTask LoadSelectedBiomeAsync()
        {
            string selectedBiomeId = _persistentProgressService.Progress.BiomeData.SelectedBiome;
            if (_biomeDefinitions.TryGetValue(selectedBiomeId, out BiomeDefinition definition) == false)
            {
                _logService.WriteError($"Biome ID '{selectedBiomeId}' not found in DatabaseConfig");
                return;
            }

            _biomeConfig = await _assetProvider.Load<BiomeConfig>(definition.ConfigReference);
        }
    }
}