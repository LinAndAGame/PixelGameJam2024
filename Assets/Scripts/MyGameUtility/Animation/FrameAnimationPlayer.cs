using System;
using System.Collections.Generic;
using MyGameExpand;
using UnityEngine;

namespace MyGameUtility {
    public class FrameAnimationPlayer : MonoBehaviour {
        public SpriteRenderer     TargetSR;

        private List<SystemData_FrameAnimationInfo> _AllFrameAnimationInfos = new List<SystemData_FrameAnimationInfo>();
        private SystemData_FrameAnimationInfo       _CurUsedFrameAnimationInfo;
        private float                               _NextChangeSpriteTime;
        private int                                 _CurIndex;

        public void Init(SaveData_FrameAnimationCollection saveDataFrameAnimationInfo) {
            RefreshData(saveDataFrameAnimationInfo);
        }

        public void RefreshData(SaveData_FrameAnimationCollection saveDataFrameAnimationInfo) {
            _CurUsedFrameAnimationInfo = null;
            _NextChangeSpriteTime      = Time.time;
            _CurIndex                  = 0;
            _AllFrameAnimationInfos.Clear();
            foreach (var frameAnimationInfo in saveDataFrameAnimationInfo.AllFrameAnimationInfos) {
                _AllFrameAnimationInfos.Add(new SystemData_FrameAnimationInfo(frameAnimationInfo));
            }
        }
        
        public SystemData_FrameAnimationInfo Play(SystemData_FrameAnimationInfo frameAnimationInfo, bool setFirstFrameImmediately = true) {
            var lastUsedFrameAnimationInfo = _CurUsedFrameAnimationInfo;
            if (lastUsedFrameAnimationInfo != null) {
                lastUsedFrameAnimationInfo.ClearInvokedEvents();
                lastUsedFrameAnimationInfo.OnAnimationInterrupted.Invoke();
            }
            

            _CurUsedFrameAnimationInfo = frameAnimationInfo;
            if (_CurUsedFrameAnimationInfo == null) {
                _CurIndex = 0;
                return null;
            }
            
            if (_CurUsedFrameAnimationInfo.FrameSprites.IsNullOrEmpty()) {
                _CurIndex = 0;
                return _CurUsedFrameAnimationInfo;
            }
            
            if (_CurUsedFrameAnimationInfo.IsLoop == false) {
                _CurUsedFrameAnimationInfo.OnAnimationStart.Invoke();
            }
            else {
                if (_CurUsedFrameAnimationInfo != lastUsedFrameAnimationInfo) {
                    _CurUsedFrameAnimationInfo.OnAnimationStart.Invoke();
                }
            }

            _CurIndex = -1;
            if (setFirstFrameImmediately) {
                SetToNextSprite();
            }
            
            return _CurUsedFrameAnimationInfo;
        }
        
        public SystemData_FrameAnimationInfo Play(string animationKey, bool setFirstFrameImmediately = true) {
            var frameAnimationInfo = _AllFrameAnimationInfos.Find(data => data.AnimationKey == animationKey);
            if (frameAnimationInfo == null) {
                Debug.LogException(new Exception($"没有名为【{animationKey}】的序列帧数据！"));
            }
            
            return Play(frameAnimationInfo, setFirstFrameImmediately);
        }

        private void Update() {
            if (_CurUsedFrameAnimationInfo != null && _CurUsedFrameAnimationInfo.IgnoreTimeScale == false) {
                if (Time.time >= _NextChangeSpriteTime) {
                    SetToNextSprite();
                }
            }
        }

        private void FixedUpdate() {
            if (_CurUsedFrameAnimationInfo != null && _CurUsedFrameAnimationInfo.IgnoreTimeScale) {
                if (Time.time >= _NextChangeSpriteTime) {
                    SetToNextSprite();
                }
            }
        }

        private void SetToNextSprite() {
            var lastUsedFrameAnimationInfo = _CurUsedFrameAnimationInfo;
            _CurIndex++;
            CheckAnimationEvents(_CurIndex);
            if (_CurIndex >= lastUsedFrameAnimationInfo.FrameSprites.Count) {
                if (lastUsedFrameAnimationInfo.IsLoop) {
                    Play(lastUsedFrameAnimationInfo, false);
                }
                else {
                    _CurUsedFrameAnimationInfo = null;
                    _CurIndex                  = 0;

                    lastUsedFrameAnimationInfo.OnAnimationEnd.Invoke();
                }
            }
            else {
                TargetSR.sprite       = lastUsedFrameAnimationInfo.FrameSprites[_CurIndex];
                _NextChangeSpriteTime = Time.time + lastUsedFrameAnimationInfo.TimeInterval;
            }
        }

        private void CheckAnimationEvents(int curIndex) {
            var allReadyInvokedEvents = _CurUsedFrameAnimationInfo.AllFrameAnimationEvents.FindAll(data => data.HasInvoked == false && curIndex >= data.InvokeFrameIndex);
            foreach (var systemDataFrameAnimationEvent in allReadyInvokedEvents) {
                systemDataFrameAnimationEvent.Invoke(this.gameObject);
            }
        }
    }
}