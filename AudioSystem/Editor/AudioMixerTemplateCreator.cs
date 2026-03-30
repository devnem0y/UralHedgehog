using System.IO;
using UnityEditor;
using UnityEngine;

namespace UralHedgehog.Audio
{
    public static class AudioMixerTemplateCreator
    {
        private const string MIXER_TEMPLATE_GUID = "70070b889148280428fab128b1e4fc53";
        private const string DefaultName = "NewUHAudioMixer";

        [MenuItem("Assets/Create/Ural Hedgehog/Audio System/Audio Mixer", priority = 302)]
        private static void CreateMixerFromTemplate()
        {
            var templatePath = AssetDatabase.GUIDToAssetPath(MIXER_TEMPLATE_GUID);
            
            if (string.IsNullOrEmpty(templatePath))
            {
                Debug.LogError($"Mixer template with GUID {MIXER_TEMPLATE_GUID} not found!");
                return;
            }

            var targetPath = GetTargetPath();
            var uniqueName = GenerateUniqueName(targetPath);
            var newPath = Path.Combine(targetPath, uniqueName + ".mixer");

            CreateMixerAsset(templatePath, newPath);
        }

        private static string GetTargetPath()
        {
            return AssetDatabase.GetAssetPath(Selection.activeObject) != "" 
                ? AssetDatabase.GetAssetPath(Selection.activeObject) 
                : "Assets";
        }

        private static string GenerateUniqueName(string targetPath)
        {
            var baseName = DefaultName;
            var counter = 0;
        
            while (File.Exists(Path.Combine(targetPath, $"{baseName}{(counter > 0 ? " " + counter : "")}.mixer")))
            {
                counter++;
            }

            return counter > 0 ? $"{baseName} {counter}" : baseName;
        }

        private static void CreateMixerAsset(string templatePath, string newPath)
        {
            if (!File.Exists(templatePath))
            {
                Debug.LogError($"Mixer template at path {templatePath} does not exist!");
                return;
            }

            AssetDatabase.CopyAsset(templatePath, newPath);
            AssetDatabase.Refresh();
            
            var createdAsset = AssetDatabase.LoadAssetAtPath<UnityEngine.Audio.AudioMixer>(newPath);
            Selection.activeObject = createdAsset;
            EditorGUIUtility.PingObject(createdAsset);
        }
    }
}
