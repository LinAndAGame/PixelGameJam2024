using System.Collections.Generic;
using UnityEngine;

namespace AttackUnit {
    public class AUC_CirclePush : BaseAttackUnitCtrl {
        public AttackUnit       AttackUnitPrefab;
        public int              Count;

        private List<AttackUnit> _AllIns = new List<AttackUnit>();

        public override void Attack() {
            base.Attack();
            float anglePerUnit = 360f / Count;
            for (int i = 0; i < Count; i++) {
                var curUnit = Instantiate(AttackUnitPrefab);
                curUnit.transform.position         = this.transform.position;
                curUnit.transform.localEulerAngles = new Vector3(0, 0, i * anglePerUnit);
                curUnit.MoveDir                    = curUnit.transform.up;
                curUnit.CanMove                    = true;
                _AllIns.Add(curUnit);
            }
        }

        public override void Clear() {
            base.Clear();
            foreach (AttackUnit attackUnit in _AllIns) {
                if (attackUnit == null) {
                    continue;
                }
                
                attackUnit.DestroySelf();
            }
            _AllIns.Clear();
        }
    }
}