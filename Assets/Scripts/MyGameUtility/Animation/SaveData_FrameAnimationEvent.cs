using System;

namespace MyGameUtility {
    [Serializable]
    public class SaveData_FrameAnimationEvent {
        public int    InvokeFrameIndex;
        public string InvokeMethodName;

        public SaveData_FrameAnimationEvent() { }

        public SaveData_FrameAnimationEvent(AssetData_FrameAnimationEvent assetData) {
            InvokeFrameIndex = assetData.InvokeFrameIndex;
            InvokeMethodName = assetData.InvokeMethodName;
        }
    }
}