using AttackUnit;
using DG.Tweening;
using GameData;
using MyGameUtility.FSM;

namespace Enemy {
    public class TriggerAttackUnitCtrlState : BaseStateWithOwner<TriggerAttackUnitCtrlStateData> {
        public CustomAction OnStateExit = new CustomAction();
        
        public TriggerAttackUnitCtrlState(TriggerAttackUnitCtrlStateData owner) : base(owner) { }

        public override void OnEnterState() {
            base.OnEnterState();
            foreach (BaseAttackUnitCtrl attackUnitCtrl in Owner.AllAttackUnitCtrls) {
                attackUnitCtrl.Attack();
            }

            var tweenerCore = DOTween.To(() => 0, data => { }, 0, Owner.ExitStateDelay);
            tweenerCore.onComplete += () => {
                OnStateExit.Invoke();
            };
        }
    }
}