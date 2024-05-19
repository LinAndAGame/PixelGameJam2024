using DG.Tweening;
using MyGameUtility.FSM;
using UnityEngine;

namespace Enemy {
    public class RotateLockState : BaseStateWithOwner<RotateLockStateData> {
        public CustomAction OnStateExit = new CustomAction();
        
        public RotateLockState(RotateLockStateData owner) : base(owner) { }

        public override void OnEnterState() {
            base.OnEnterState();
            var tweenerCore = DOTween.To(() => 0, data => { },0, Owner.RotateLockDuration);
            tweenerCore.onComplete += () => {
                OnStateExit.Invoke();
            };
        }

        public override void OnStayState() {
            Vector3 dir = Owner.Trans_Target.position - Owner.Trans_Self.position;
            Owner.Trans_Self.rotation = Quaternion.LookRotation(Owner.Trans_Self.forward, dir);
        }
    }
}