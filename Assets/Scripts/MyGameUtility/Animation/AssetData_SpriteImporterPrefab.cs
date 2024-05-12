using System;
using System.Collections.Generic;
using MyGameExpand;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MyGameUtility {
    public class AssetData_SpriteImporterPrefab : ScriptableObject {
        public GameObject          PrefabObject;
        public List<ImagePathInfo> AllImagePathInfos = new List<ImagePathInfo>();

        public void SetPrefab(GameObject prefabObject) {
#if UNITY_EDITOR
            PrefabObject = prefabObject;

            HashSet<Transform> ignoredTrans = new HashSet<Transform>();
            
            foreach (var componentsInChild in PrefabObject.GetComponentsInChildren<Transform>()) {
                if (PrefabUtility.IsAnyPrefabInstanceRoot(componentsInChild.gameObject)) {
                    foreach (var inChild in componentsInChild.GetComponentsInChildren<Transform>()) {
                        ignoredTrans.Add(inChild);
                    }
                }
            }
            
            foreach (var componentsInChild in PrefabObject.GetComponentsInChildren<Transform>()) {
                if (componentsInChild.GetComponent<Image>() != null && ignoredTrans.Contains(componentsInChild) == false) {
                    ImagePathInfo imagePathInfo = new ImagePathInfo();
                    imagePathInfo.ImgPath = componentsInChild.GetPathToRoot();
                    AllImagePathInfos.Add(imagePathInfo);
                }
            }
#endif
        }
        
        [Serializable]
        public class ImagePathInfo {
            [HorizontalGroup()]
            public bool   IsIgnore;
            [HorizontalGroup()]
            public string ImgPath;
        }
    }
}