using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public interface IAssetDownloadService
    {
        UniTask UpdateCatalogsAsync();
        UniTask UpdateContentAsync(string labelKey, IAssetDownloadReporter assetDownloadReporter);

        UniTask UpdateContentAsync(IEnumerable<string> labelKeys,
            IAssetDownloadReporter assetDownloadReporter);

        UniTask UpdateDownloadSizeAsync(string labelKey);
        UniTask UpdateDownloadSizeAsync(IEnumerable<string> labelKeys);
        float GetDownloadSizeMb();
    }
}