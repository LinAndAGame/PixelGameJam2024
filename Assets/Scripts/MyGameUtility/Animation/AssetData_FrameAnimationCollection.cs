using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    [CreateAssetMenu(fileName = "AnimationCollection", menuName = "纯数据资源/FrameAnimation/AnimationCollection", order = 0)]
    public class AssetData_FrameAnimationCollection : ScriptableObject {
        public AssetData_PngLimit                 PngLimit;
        public List<AssetData_FrameAnimationInfo> AllFrameAnimationInfos;
        
        [SerializeField]
        private string _ResourcePath;
        public string ResourcePath => _ResourcePath;

        public SaveData_FrameAnimationCollection GetSaveData() {
            return new SaveData_FrameAnimationCollection(this);
        }
        
        private void OnValidate() {
            setResourcePath();

            void setResourcePath() {
                _ResourcePath = OtherUtility.GetResourcePath(this);
            }
        }
    }
}