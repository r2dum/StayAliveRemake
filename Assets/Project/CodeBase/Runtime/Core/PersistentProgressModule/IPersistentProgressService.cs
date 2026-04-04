using CodeBase.Runtime.Core.Data;

namespace CodeBase.Runtime.Core.PersistentProgressModule
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}