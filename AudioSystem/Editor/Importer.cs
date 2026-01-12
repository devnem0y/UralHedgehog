using System;
using UnityEditor;
using System.IO;
using UnityEngine;

namespace UralHedgehog.Audio
{
    [InitializeOnLoad]
    public static class Importer
    {
        private const string packageName = "com.uralhedgehog.audiosystem";
        private const string moduleName = "Audio System";
    
        private static bool initialized;

        static Importer()
        {
            EditorApplication.delayCall += InitializeOnProjectLoad;
            EditorApplication.projectChanged += HandleProjectChange;
        }

        private static void HandleProjectChange()
        {
            if(!initialized) InitializeOnProjectLoad();
        }

        private static void InitializeOnProjectLoad()
        {
            if(initialized || EditorApplication.isPlayingOrWillChangePlaymode) return;

            initialized = true;

            var packagePath = Path.GetFullPath($"Packages/{packageName}");
            var templatePath = Path.Combine(packagePath, "RuntimeEditable");
            var targetPath = Path.GetFullPath($"Assets/Ural Hedgehog/{moduleName}");
            
            if (!Directory.Exists(templatePath) || Directory.Exists(targetPath)) return;

            try
            {
                CopyDirectory(templatePath, targetPath);
                
                var renamedTemplatePath = templatePath + "~";
                
                if (Directory.Exists(renamedTemplatePath))
                {
                    Directory.Delete(renamedTemplatePath, true);
                }
                
                Directory.Move(templatePath, renamedTemplatePath);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error when copying/renaming: {e.Message}");
                return;
            }
            
            EditorApplication.delayCall += AssetDatabase.Refresh;
        }

        private static void CopyDirectory(string source, string dest)
        {
            Directory.CreateDirectory(dest);
            foreach(var file in Directory.GetFiles(source))
            {
                var destFile = Path.Combine(dest, Path.GetFileName(file));
                File.Copy(file, destFile, false);
            }
            foreach(var dir in Directory.GetDirectories(source))
            {
                var destDir = Path.Combine(dest, Path.GetFileName(dir));
                CopyDirectory(dir, destDir);
            }
        }
    }
}