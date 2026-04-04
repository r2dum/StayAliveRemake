using CodeBase.Runtime.Core.Data;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Runtime.Core.PersistentProgressModule;
using CodeBase.Shared.Extensions;
using UnityEngine;

namespace CodeBase.Runtime.Core.SaveLoadModule
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "PlayerProgress";

        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ILogService _logService;

        public SaveLoadService(IPersistentProgressService persistentProgressService, ILogService logService)
        {
            _persistentProgressService = persistentProgressService;
            _logService = logService;
        }

        public void SaveProgress() =>
            PlayerPrefs.SetString(ProgressKey, _persistentProgressService.Progress.ToJson());

        public PlayerProgress LoadOrCreateProgress(PlayerProgress newProgress)
        {
            string playerProgress = PlayerPrefs.GetString(ProgressKey);

            if (playerProgress.IsNullOrEmpty())
            {
                _logService.Write($"Created Data: {newProgress.ToJson()}");
                return newProgress;
            }

            PlayerProgress progress = playerProgress.FromJson<PlayerProgress>();
            _logService.Write($"Loaded Data: {progress.ToJson()}");
            return progress;
        }
    }
}