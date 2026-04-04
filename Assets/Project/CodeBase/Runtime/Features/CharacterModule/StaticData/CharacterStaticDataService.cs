using System.Collections.Generic;
using CodeBase.Runtime.Core.AssetManagementModule;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.PersistentProgressModule;
using CodeBase.Shared;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.CharacterModule.StaticData
{
    public class CharacterStaticDataService : ICharacterStaticDataService
    {
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IAssetProvider _assetProvider;
        private readonly ILogService _logService;

        private readonly Dictionary<string, CharacterDefinition> _characterDefinitions = new();

        private CharacterDatabaseConfig _characterDatabaseConfig;
        private CharacterConfig _characterConfig;

        public CharacterStaticDataService(IPersistentProgressService persistentProgressService,
            IAssetProvider assetProvider, ILogService logService)
        {
            _persistentProgressService = persistentProgressService;
            _assetProvider = assetProvider;
            _logService = logService;
        }

        public async UniTask InitializeAsync()
        {
            await InitializeDatabaseAsync();
            await LoadSelectedCharacterAsync();
        }

        public CharacterConfig ForCharacterConfig() =>
            _characterConfig;

        private async UniTask InitializeDatabaseAsync()
        {
            _characterDatabaseConfig =
                await _assetProvider.Load<CharacterDatabaseConfig>(AssetAddress.CharacterDatabaseConfig);

            foreach (CharacterDefinition characterDefinition in _characterDatabaseConfig.CharacterDefinitions)
                _characterDefinitions[characterDefinition.Id] = characterDefinition;
        }

        private async UniTask LoadSelectedCharacterAsync()
        {
            string selectedCharacterId = _persistentProgressService.Progress.CharacterData.SelectedCharacter;
            if (_characterDefinitions.TryGetValue(selectedCharacterId, out CharacterDefinition definition) == false)
            {
                _logService.WriteError($"Character ID '{selectedCharacterId}' not found in DatabaseConfig");
                return;
            }

            _characterConfig = await _assetProvider.Load<CharacterConfig>(definition.ConfigReference);
        }
    }
}