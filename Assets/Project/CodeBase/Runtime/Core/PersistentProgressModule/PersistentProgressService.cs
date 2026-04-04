using CodeBase.Runtime.Core.Data;

namespace CodeBase.Runtime.Core.PersistentProgressModule
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}