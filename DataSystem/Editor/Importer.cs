using UnityEditor;
using System.IO;

namespace UralHedgehog.Data
{
    [InitializeOnLoad]
    public static class UHImporter
    {
        private const string packageName = "com.uralhedgehog.datasystem";
        private const string moduleName = "Data System";
    
        private static bool initialized;

        static UHImporter()
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
            var templatePath = Path.Combine(packagePath, "RuntimeEditable~");
            var targetPath = Path.GetFullPath($"Assets/Ural Hedgehog/{moduleName}");

            if (!Directory.Exists(templatePath) || Directory.Exists(targetPath)) return;
        
            CopyDirectory(templatePath, targetPath);
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