using System;
using System.Collections.Generic;
using AttackUnit;

namespace Enemy {
    [Serializable]
    public class TriggerAttackUnitCtrlStateData {
        public BossCtrl                 Boss;
        public List<BaseAttackUnitCtrl> AllAttackUnitCtrls;
        public float                    ExitStateDelay = 3;
    }
}