using System;
using UnityEngine;

namespace CodeBase.Runtime.Core.AssetManagementModule
{
    public class AssetDownloadReporter : IAssetDownloadReporter
    {
        private const float UpdateThreshold = 0.01f;
        
        private float _progress;
        
        public event Action<float> ProgressUpdated;

        public void Report(float value)
        {
            if (Mathf.Abs(_progress - value) < UpdateThreshold)
                return;

            _progress = value;
            ProgressUpdated?.Invoke(_progress);
        }

        public void Reset() =>
            _progress = 0;
    }
}