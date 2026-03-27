using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Core.DebugModule.Log;
using CodeBase.Shared.Extensions;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public class AssetDownloadService : IAssetDownloadService
    {
        private readonly ILogService _logService;
        private long _downloadSize;

        public AssetDownloadService(ILogService logService) =>
            _logService = logService;

        public async UniTask UpdateCatalogsAsync()
        {
            List<string> catalogsToUpdate = await Addressables.CheckForCatalogUpdates().ToUniTask();

            if (catalogsToUpdate.IsNullOrEmpty())
                return;

            _logService.Write($"Updated catalogs: {string.Join(", ", catalogsToUpdate)}");
            await Addressables.UpdateCatalogs(catalogsToUpdate).ToUniTask();
        }

        public async UniTask UpdateContentAsync(string labelKey, IAssetDownloadReporter assetDownloadReporter) =>
            await DownloadContentAsync(new[] { labelKey }, assetDownloadReporter);

        public async UniTask UpdateContentAsync(IEnumerable<string> labelKeys,
            IAssetDownloadReporter assetDownloadReporter) =>
            await DownloadContentAsync(labelKeys, assetDownloadReporter);

        public async UniTask UpdateDownloadSizeAsync(string labelKey)
        {
            _downloadSize = 0;
            _downloadSize = await Addressables
                .GetDownloadSizeAsync(labelKey)
                .ToUniTask();
        }

        public async UniTask UpdateDownloadSizeAsync(IEnumerable<string> labelKeys)
        {
            _downloadSize = 0;
            foreach (string label in labelKeys)
                _downloadSize += await Addressables.GetDownloadSizeAsync(label).ToUniTask();
        }

        public float GetDownloadSizeMb() =>
            SizeToMb(_downloadSize);

        private async UniTask DownloadContentAsync(IEnumerable<string> labelKeys,
            IAssetDownloadReporter assetDownloadReporter)
        {
            try
            {
                List<string> labels = labelKeys.ToList();
                if (labels.IsNullOrEmpty())
                {
                    assetDownloadReporter.Report(1f);
                    return;
                }

                List<AsyncOperationHandle> downloadHandles =
                    labels.Select(label => Addressables.DownloadDependenciesAsync(label)).ToList();

                while (downloadHandles.Any(h => !h.IsDone && h.IsValid()))
                {
                    await UniTask.Delay(100);
                    float totalProgress = downloadHandles
                        .Where(h => h.IsValid())
                        .Average(h => h.GetDownloadStatus().Percent);
                    assetDownloadReporter.Report(totalProgress);
                }

                assetDownloadReporter.Report(1f);

                foreach (AsyncOperationHandle handle in downloadHandles)
                {
                    if (handle.Status == AsyncOperationStatus.Failed)
                        _logService.WriteError($"Error while downloading dependencies for label: {handle.DebugName}");
                    if (handle.IsValid())
                        Addressables.Release(handle);
                }

                assetDownloadReporter.Reset();
            }
            catch (Exception e)
            {
                _logService.WriteError($"{e}");
            }
        }

        private float SizeToMb(long downloadSize) =>
            downloadSize * 1f / 1048576;
    }
}