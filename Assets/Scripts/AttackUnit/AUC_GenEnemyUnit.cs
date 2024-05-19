using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace AttackUnit {
    public class AUC_GenEnemyUnit : BaseAttackUnitCtrl {
        public Transform             Trans_GenPos;
        public RotateCircleEnemyCtrl RotateCircleEnemyCtrlPrefab;

        private List<RotateCircleEnemyCtrl> _AllIns = new List<RotateCircleEnemyCtrl>();

        public override void Attack() {
            base.Attack();
            var ins = Instantiate(RotateCircleEnemyCtrlPrefab);
            ins.transform.position = Trans_GenPos.position;
            _AllIns.Add(ins);
        }

        public override void Clear() {
            base.Clear();
            foreach (RotateCircleEnemyCtrl rotateCircleEnemyCtrl in _AllIns) {
                rotateCircleEnemyCtrl.DestroySelf();
            }
            _AllIns.Clear();
        }
    }
}