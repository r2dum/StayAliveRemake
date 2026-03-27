using System.Runtime.CompilerServices;

namespace CodeBase.Runtime.Core.DebugModule.Log
{
    public interface ILogService
    {
        void Write(string massage, [CallerMemberName] string member = "",
            [CallerFilePath] string file = "", [CallerLineNumber] int line = 0);

        void WriteError(string massage, [CallerMemberName] string member = "",
            [CallerFilePath] string file = "", [CallerLineNumber] int line = 0);

        void WriteWarning(string massage, [CallerMemberName] string member = "",
            [CallerFilePath] string file = "", [CallerLineNumber] int line = 0);
    }
}