using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Features.ProjectileModule
{
    [CreateAssetMenu(fileName = nameof(ProjectileConfig), menuName = "Configs/Projectile/" + nameof(ProjectileConfig))]
    public class ProjectileConfig : ScriptableObject
    {
        public List<AnimationCurve> AnimationCurves;
        public ProjectileBase Prefab;
    }
}