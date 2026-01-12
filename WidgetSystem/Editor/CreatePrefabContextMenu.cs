using UnityEditor;
using UnityEngine;

namespace UralHedgehog.UI
{
    public static class CreatePrefabContextMenu
    {
        private const string PREFAV_GUID = "13121a87220a15541ac2db931f0066bd";

        [MenuItem("GameObject/Ural Hedgehog/UI/UIRoot", false, 0)]
        private static void CreateCustomPrefab()
        {
            var path = AssetDatabase.GUIDToAssetPath(PREFAV_GUID);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError($"Prefab not found! GUID: {PREFAV_GUID}");
                return;
            }

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null)
            {
                Debug.LogError($"Failed to load prefab at path: {path}");
                return;
            }
            
            var instance = Object.Instantiate(prefab);
            PlaceInScene(instance);
        }

        private static void PlaceInScene(GameObject instance)
        {
            if (Selection.activeTransform != null)
            {
                instance.transform.SetParent(Selection.activeTransform);
            }

            instance.transform.localPosition = Vector3.zero;
            instance.name = instance.name.Replace("(Clone)", "");
            Undo.RegisterCreatedObjectUndo(instance, "Create Prefab");
            Selection.activeObject = instance;
        }
    }
}
