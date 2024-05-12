using UnityEngine;

namespace MyGameUtility {
    [CreateAssetMenu(fileName = "FrameAnimationEvent", menuName = "纯数据资源/FrameAnimation/FrameAnimationEvent")]
    public class AssetData_FrameAnimationEvent : ScriptableObject {
        public int    InvokeFrameIndex;
        public string InvokeMethodName;
        
        [SerializeField]
        private string _ResourcePath;
        public string ResourcePath => _ResourcePath;

        public SaveData_FrameAnimationEvent GetSaveData() {
            return new SaveData_FrameAnimationEvent(this);
        }
        
        private void OnValidate() {
            setResourcePath();

            void setResourcePath() {
                _ResourcePath = OtherUtility.GetResourcePath(this);
            }
        }
    }
}