using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Features.CameraModule.StaticData
{
    [Serializable]
    public class CameraStaticData
    {
        public CameraStateType StateType;
        public Vector3 Position;
        public Vector3 Rotation;
        [Range(1f, 25f)] public float OrthographicSize = 7f;
        [Range(0.1f, 3f)] public float TransitionDuration = 1f;
        public Ease TransitionEase;
    }
}