using System.IO;
using UnityEditor;
using UnityEngine;

namespace UralHedgehog.Audio
{
    public static class AudioEnumsTemplateCreator
    {
        private const string SCRIPT_TEMPLATE_GUID = "c2e54df3b64171d498e78b1c39e385ad";
        private const string DefaultName = "AudioEnums";
        private const string ScriptExtension = ".cs";

        [MenuItem("Assets/Create/Ural Hedgehog/Audio System/AudioEnums Script", priority = 302)]
        private static void CreateScriptFromTemplate()
        {
            var templatePath = AssetDatabase.GUIDToAssetPath(SCRIPT_TEMPLATE_GUID);
            
            if (string.IsNullOrEmpty(templatePath))
            {
                Debug.LogError($"Script template with GUID {SCRIPT_TEMPLATE_GUID} not found!");
                return;
            }
            
            var targetPath = GetTargetPath();
            var uniqueName = GenerateUniqueName(targetPath);
            var newPath = Path.Combine(targetPath, uniqueName + ScriptExtension);
            
            CreateScriptAsset(templatePath, newPath);
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
        
            while (File.Exists(Path.Combine(targetPath, $"{baseName}{(counter > 0 ? " " + counter : "")}{ScriptExtension}")))
            {
                counter++;
            }

            return counter > 0 ? $"{baseName} {counter}" : baseName;
        }
        
        private static void CreateScriptAsset(string templatePath, string newPath)
        {
            if (!File.Exists(templatePath))
            {
                Debug.LogError($"Script template at path {templatePath} does not exist!");
                return;
            }

            try
            {
                File.Copy(templatePath, newPath);
                ProcessScriptTemplate(newPath);
                AssetDatabase.Refresh();
                
                var createdAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(newPath);
                Selection.activeObject = createdAsset;
                EditorGUIUtility.PingObject(createdAsset);
            }
            catch (IOException e)
            {
                Debug.LogError($"Failed to create script: {e.Message}");
            }
        }
        
        private static void ProcessScriptTemplate(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var content = File.ReadAllText(filePath);
            
            content = content.Replace("#SCRIPTNAME#", fileName);
            File.WriteAllText(filePath, content);
        }
    }
}