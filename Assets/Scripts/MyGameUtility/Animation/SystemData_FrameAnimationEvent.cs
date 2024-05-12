using UnityEngine;

namespace MyGameUtility {
    public class SystemData_FrameAnimationEvent {
        public bool HasInvoked;

        private SaveData_FrameAnimationEvent _SaveData;

        public int    InvokeFrameIndex => _SaveData.InvokeFrameIndex;
        public string InvokeMethodName => _SaveData.InvokeMethodName;

        public SystemData_FrameAnimationEvent(SaveData_FrameAnimationEvent saveData) {
            _SaveData = saveData;
        }

        public void Invoke(GameObject obj) {
            obj.SendMessage(InvokeMethodName, SendMessageOptions.RequireReceiver);
        }
    }
}