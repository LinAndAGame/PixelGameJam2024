using System.Collections;
using DG.Tweening;
using MyGameUtility.FSM;
using UnityEngine;

namespace Enemy {
    public class RotateDashState : BaseStateWithOwner<RotateCircleEnemyCtrl> {
        private RotateDashStateData _Data;

        public RotateDashState(RotateCircleEnemyCtrl owner) : base(owner) {
            _Data = owner.RotateDashStateDataRef;
        }

        public override void OnEnterState() {
            base.OnEnterState();
            Owner.StartCoroutine(behavior());
            
            IEnumerator behavior() {
                while (true) {
                    _Data.TransformTarget
                        .DOLocalRotate(new Vector3(0,0,UnityEngine.Random.Range(_Data.MinRotateZ, _Data.MaxRotateZ)), _Data.RotateDuration, RotateMode.LocalAxisAdd)
                        .SetEase(_Data.RotateCurve);
                    yield return new WaitForSeconds(_Data.RotateDuration);
                    // _Data.SpriteRendererRef.color = Color.clear;
                    // _Data.SpriteRendererRef
                    //     .DOColor(Color.red, _Data.FlashDuration / _Data.FlashTimes * 2)
                    //     .SetLoops(_Data.FlashTimes, LoopType.Yoyo)
                    //     .SetEase(_Data.FlashCurve);
                    // yield return new WaitForSeconds(_Data.FlashDuration);
                    // _Data.SpriteRendererRef.color = Color.red;
                    _Data.Rigidbody2DRef
                        .DOMove(_Data.TransformTarget.position + _Data.TransformTarget.right * _Data.DashDistance, _Data.DashDuration)
                        .SetEase(_Data.DashCurve);
                    yield return new WaitForSeconds(_Data.DashDuration);
                }
            }
        }

        public override void OnExitState() {
            base.OnExitState();
            DOTween.Kill(this);
            Owner.StopAllCoroutines();
        }
    }
}