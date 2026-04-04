using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Features.CameraModule.StaticData
{
    [CreateAssetMenu(fileName = nameof(CameraConfig), menuName = "Configs/Camera/" + nameof(CameraConfig))]
    public class CameraConfig : ScriptableObject
    {
        public List<CameraStaticData> CameraStaticsData;
    }
}