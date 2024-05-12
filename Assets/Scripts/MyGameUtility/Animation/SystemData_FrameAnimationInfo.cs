using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    public class SystemData_FrameAnimationInfo {
        public CustomAction OnAnimationStart       = new CustomAction();
        public CustomAction OnAnimationEnd         = new CustomAction();
        public CustomAction OnAnimationInterrupted = new CustomAction();

        public List<Sprite>                         FrameSprites            = new List<Sprite>();
        public List<SystemData_FrameAnimationEvent> AllFrameAnimationEvents = new List<SystemData_FrameAnimationEvent>();

        private SaveData_FrameAnimationInfo _SaveData;

        public string AnimationKey    => _SaveData.AssetData.AnimationKey;
        public bool   IsLoop          => _SaveData.AssetData.Loop;
        public float  TimeInterval    => _SaveData.AssetData.TimeInterval;
        public bool   IgnoreTimeScale => _SaveData.AssetData.IgnoreTimeScale;

        public SystemData_FrameAnimationInfo(SaveData_FrameAnimationInfo saveData) {
            _SaveData = saveData;
            FrameSprites                = saveData.CurFrameSprites;
            foreach (var saveDataFrameAnimationEvent in saveData.AllFrameAnimationEvents) {
                AllFrameAnimationEvents.Add(new SystemData_FrameAnimationEvent(saveDataFrameAnimationEvent));
            }
        }

        public void ClearInvokedEvents() {
            foreach (var systemDataFrameAnimationEvent in AllFrameAnimationEvents) {
                systemDataFrameAnimationEvent.HasInvoked = false;
            }
        }
    }
}