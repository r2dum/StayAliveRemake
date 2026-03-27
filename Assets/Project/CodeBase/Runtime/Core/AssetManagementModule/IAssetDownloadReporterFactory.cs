namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public interface IAssetDownloadReporterFactory
    {
        IAssetDownloadReporter CreateReporter();
    }
}