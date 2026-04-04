using CodeBase.Runtime.Core.Data;

namespace CodeBase.Runtime.Core.SaveLoadModule
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadOrCreateProgress(PlayerProgress newProgress);
    }
}