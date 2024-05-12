using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MyGameUtility {
    [CreateAssetMenu(fileName = "SpriteImporter", menuName = "纯数据资源/Mod/SpriteImporter")]
    public class AssetData_SpriteImporter : ScriptableObject {
        public List<AssetData_SpriteImporterPrefab> AllPrefabObjectPaths = new List<AssetData_SpriteImporterPrefab>();

        [Button]
        public void AddPrefab(GameObject obj) {
#if UNITY_EDITOR
            var prefabAssetType = PrefabUtility.GetPrefabAssetType(obj);
            if (prefabAssetType == PrefabAssetType.Regular || prefabAssetType == PrefabAssetType.Variant) {
                var assetDataSpriteImporterPrefab = CreateInstance<AssetData_SpriteImporterPrefab>();
                assetDataSpriteImporterPrefab.SetPrefab(obj);
                string assetPath       = AssetDatabase.GetAssetPath(this);
                string createAssetPath = assetPath.Replace(this.name, obj.name);
                AssetDatabase.CreateAsset(assetDataSpriteImporterPrefab, createAssetPath);
            }
#endif
        }
    }
}