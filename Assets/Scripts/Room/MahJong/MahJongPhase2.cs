using System.Collections;
using System.Collections.Generic;
using MyGameUtility.FSM;
using UnityEngine;

namespace Room {
    public class MahJongPhase2 : BaseStateWithOwner<Room_MahJong> {
        public MahJongPhase2(Room_MahJong owner) : base(owner) { }

        public override void OnEnterState() {
            base.OnEnterState();
            var allGroundEnemies = Owner.AllMahJongEnemyCtrl.FindAll(data => data.CurState == MahJongEnemyState.OnGround);
            Owner.OnAllEnemySetToSky.AddListener(() => {
                Owner.StartCoroutine(setEnemyToAttack());

                IEnumerator setEnemyToAttack() {
                    yield return setEnemyGroupToAttack(0, 1, 2);
                    yield return new WaitForSeconds(Owner.Phase2DownInterval2);
                    yield return setEnemyGroupToAttack(3, 4, 5);
                    yield return new WaitForSeconds(Owner.Phase2DownInterval2);
                    yield return setEnemyGroupToAttack(6, 7, 8);
                    yield return new WaitForSeconds(Owner.Phase2DownInterval2);
                    yield return setEnemyGroupToAttack(9, 10, 11);
                    yield return new WaitForSeconds(Owner.Phase2DownInterval2);
                    yield return setEnemyGroupToAttack(12, 13);
                    
                    Machine.TransitionToNextState(new MahJongPhase1(Owner));

                    IEnumerator setEnemyGroupToAttack(params int[] indexs) {
                        List<MahJongEnemyCtrl> allMahJongEnemyCtrls = new List<MahJongEnemyCtrl>();
                        foreach (int i in indexs) {
                            allMahJongEnemyCtrls.Add(Owner.AllMahJongEnemyCtrl[i]);
                        }

                        foreach (MahJongEnemyCtrl mahJongEnemyCtrl in allMahJongEnemyCtrls) {
                            mahJongEnemyCtrl.DownToAttack();
                            yield return new WaitForSeconds(Owner.Phase2DownInterval1);
                        }
                    }
                }
            }, CC.Event);
            Owner.SetEnemyToSky(allGroundEnemies);
        }
    }
}