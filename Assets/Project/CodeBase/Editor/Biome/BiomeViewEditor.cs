using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Features.BiomeModule;
using CodeBase.Runtime.Features.BiomePlatformModule;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor.Biome
{
    [CustomEditor(typeof(BiomeView))]
    public class BiomeViewEditor : OdinEditor
    {
        private readonly string _logPrefix = $"<color=#4AF626>[{nameof(BiomeView)}]</color>";

        private SerializedProperty _platformsProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            _platformsProperty = serializedObject.FindProperty("_platforms");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            BiomeView biomeView = (BiomeView)target;
            if (SirenixEditorGUI.Button("Collect Platforms", ButtonSizes.Medium))
            {
                List<BiomePlatform> foundPlatforms = biomeView.GetComponentsInChildren<BiomePlatform>().ToList();

                if (foundPlatforms.Count == 0)
                {
                    Debug.LogWarning($"{_logPrefix} No BiomePlatforms found in children!");
                    return;
                }

                List<BiomePlatform> sortedPlatforms = foundPlatforms
                    .OrderByDescending(p => p.transform.position.z)
                    .ThenBy(p => p.transform.position.x)
                    .ToList();

                _platformsProperty.ClearArray();
                _platformsProperty.arraySize = sortedPlatforms.Count;

                for (int i = 0; i < sortedPlatforms.Count; i++)
                {
                    _platformsProperty.GetArrayElementAtIndex(i).objectReferenceValue = sortedPlatforms[i];
                    SerializedObject platformSerializedObject = new(sortedPlatforms[i]);
                    platformSerializedObject.FindProperty("_id").intValue = i;
                    platformSerializedObject.ApplyModifiedProperties();
                }

                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(target);
            }
        }
    }
}