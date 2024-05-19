using DG.Tweening;
using MyGameUtility.FSM;
using UnityEngine;

namespace Enemy {
    public class BossDashState : BaseStateWithOwner<BossDashStateData> {
        public CustomAction OnStateExit = new CustomAction();
        
        public BossDashState(BossDashStateData owner) : base(owner) { }
        
        public override void OnEnterState() {
            base.OnEnterState();
            var dir = Owner.Trans_DashTarget.position - Owner.TransTarget.position;
            dir = dir.normalized;
            var tweenerCore = Owner.Rigidbody2DRef
                .DOMove(Owner.TransTarget.position + dir * Owner.DashDistance, Owner.DashDuration)
                .SetEase(Owner.DashCurve);
            tweenerCore.onComplete += () => {
                OnStateExit.Invoke();
            };
        }


        public override void OnExitState() {
            base.OnExitState();
            DOTween.Kill(this);
        }
    }
}