namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public class AssetDownloadReporterFactory : IAssetDownloadReporterFactory
    {
        public IAssetDownloadReporter CreateReporter() => 
            new AssetDownloadReporter();
    }
}