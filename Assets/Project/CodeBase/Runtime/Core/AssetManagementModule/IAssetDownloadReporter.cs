using System;

namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public interface IAssetDownloadReporter : IProgress<float>
    {
        event Action<float> ProgressUpdated;
        new void Report(float value);
        void Reset();
    }
}