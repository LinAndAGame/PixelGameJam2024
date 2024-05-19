using DG.Tweening;
using MyGameUtility.FSM;
using UnityEngine;

namespace Enemy {
    public class BeCollisionState : BaseStateWithOwner<RotateCircleEnemyCtrl> {
        private BeCollisionStateData _Data;

        public BeCollisionState(RotateCircleEnemyCtrl owner) : base(owner) {
            _Data = owner.BeCollisionStateDataRef;
        }

        public override void OnEnterState() {
            base.OnEnterState();
            Vector3 normal   = _Data.ContactPoint2DRef.normal;
            Vector3 inputDir = _Data.TransTarget.right;
            Vector3 reflecltDir   = Vector2.Reflect(inputDir, normal);
            reflecltDir = normal;
            var tweenerCore = _Data.Rigidbody2DRef
                .DOMove(_Data.TransTarget.position + reflecltDir * _Data.ReflectDashDistance, _Data.ReflectDashDuration)
                .SetEase(_Data.ReflectDashAnimationCurve);
            tweenerCore.onComplete += () => { Owner.AI_FSM.TransitionToNextState(new RotateDashState(Owner)); };
        }

        public override void OnExitState() {
            base.OnExitState();
            DOTween.Kill(this);
        }
    }
}