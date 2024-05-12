using System.Collections;
using System.Collections.Generic;
using MyGameUtility.FSM;
using UnityEngine;

namespace Room {
    public class MahJongPhase1 : BaseStateWithOwner<Room_MahJong> {
        public MahJongPhase1(Room_MahJong owner) : base(owner) { }

        public override void OnEnterState() {
            base.OnEnterState();
            var allGroundEnemies = Owner.AllMahJongEnemyCtrl.FindAll(data => data.CurState == MahJongEnemyState.OnGround);
            Owner.OnAllEnemySetToSky.AddListener(() => {
                Owner.StartCoroutine(setEnemyToAttack());

                IEnumerator setEnemyToAttack() {
                    foreach (MahJongEnemyCtrl mahJongEnemyCtrl in Owner.AllMahJongEnemyCtrl) {
                        mahJongEnemyCtrl.DownToAttack();
                        yield return new WaitForSeconds(Owner.Phase1DownInterval);
                    }
                    
                    Machine.TransitionToNextState(new MahJongPhase2(Owner));
                }
            }, CC.Event);
            Owner.SetEnemyToSky(allGroundEnemies);

        }
    }
}