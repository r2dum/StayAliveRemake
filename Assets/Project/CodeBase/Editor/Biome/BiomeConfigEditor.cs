using System.Linq;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.BiomeModule.StaticData;
using CodeBase.Runtime.Features.ProjectileSpawnPointModule;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor.Biome
{
    [CustomEditor(typeof(BiomeConfig))]
    public class BiomeConfigEditor : OdinEditor
    {
        private readonly string _logPrefix = $"<color=#4AF626>[{nameof(BiomeConfig)}]</color>";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            BiomeConfig biomeConfig = (BiomeConfig)target;
            if (SirenixEditorGUI.Button("Collect Projectile Markers", ButtonSizes.Medium))
            {
                BiomeView biomeView = FindFirstObjectByType<BiomeView>();

                if (biomeView == null)
                {
                    Debug.Log($"{_logPrefix} <color=red>BiomeView not found on scene!</color>");
                    return;
                }

                ProjectileSpawnMarker[] projectileSpawnMarkers =
                    FindObjectsByType<ProjectileSpawnMarker>(FindObjectsSortMode.InstanceID);

                biomeConfig.ProjectileSpawnPoints = projectileSpawnMarkers
                    .Select(p =>
                        new ProjectileSpawnPoint(p.SpawnPointType, p.PlatformId,
                            p.ProjectileTypes, p.transform.localPosition))
                    .ToList();

                EditorUtility.SetDirty(target);
            }
        }
    }
}