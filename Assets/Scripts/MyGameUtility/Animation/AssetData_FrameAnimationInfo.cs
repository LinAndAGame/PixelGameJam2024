using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    [CreateAssetMenu(fileName = "FrameAnimationInfo", menuName = "纯数据资源/FrameAnimation/FrameAnimationInfo")]
    public class AssetData_FrameAnimationInfo : ScriptableObject {
        public  string                              AnimationKey;
        public  List<Sprite>                        FrameSprites;
        public  int                                 FPS = 24;
        public  bool                                Loop;
        public  bool                                IgnoreTimeScale;
        public  List<AssetData_FrameAnimationEvent> AllAnimationEvents;
        
        [SerializeField]
        private string _ResourcePath;
        public string ResourcePath => _ResourcePath;

        public float TimeInterval      => 1f / FPS;

        public SaveData_FrameAnimationInfo GetSaveData() {
            return new SaveData_FrameAnimationInfo(this);
        }

        private void OnValidate() {
            setResourcePath();
            setAnimationKey();

            void setAnimationKey() {
                if (string.IsNullOrEmpty(AnimationKey) == false) {
                    return;
                }

                if (this.name.Contains("_") == false) {
                    return;
                }

                var stringValues = this.name.Split("_");
                if (stringValues.Length <= 1) {
                    return;
                }

                AnimationKey = stringValues[1];
            }

            void setResourcePath() {
                _ResourcePath = OtherUtility.GetResourcePath(this);
            }
        }
    }
}