using System;
using UnityEngine;

namespace MyGameUtility {
    [Serializable]
    public class BaseSaveData<T> where T : BaseAssetData {
        [SerializeField]
        private string AssetDataPath;
        public T AssetData => Resources.Load<T>(AssetDataPath);

        public BaseSaveData() { }

        public BaseSaveData(T assetData) {
            AssetDataPath = assetData.ResourcePath;
        }
    }
}