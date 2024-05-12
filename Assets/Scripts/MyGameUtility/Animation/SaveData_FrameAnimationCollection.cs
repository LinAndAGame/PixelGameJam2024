using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    [Serializable]
    public class SaveData_FrameAnimationCollection {
        public string                             ResourcePath;
        public List<SaveData_FrameAnimationInfo>  AllFrameAnimationInfos = new List<SaveData_FrameAnimationInfo>();
        
        public AssetData_FrameAnimationCollection AssetData => Resources.Load<AssetData_FrameAnimationCollection>(ResourcePath);

        public SaveData_FrameAnimationCollection() { }

        public SaveData_FrameAnimationCollection(AssetData_FrameAnimationCollection assetData) {
            ResourcePath = assetData.ResourcePath;
            foreach (var assetDataAllFrameAnimationInfo in assetData.AllFrameAnimationInfos) {
                AllFrameAnimationInfos.Add(assetDataAllFrameAnimationInfo.GetSaveData());
            }
        }
    }
}