using System;
using System.Collections;
using System.Collections.Generic;
using MyGameExpand;
using UnityEngine;

namespace Room {
    public class Room_MahJong : BaseRoomCtrl {
        public CustomAction OnAllEnemySetToSky = new CustomAction();

        public bool EditorTest_FightOnStart;
        
        public  float                  SetEnemyToSkyInterval = 0.2f;
        public  List<MahJongEnemyCtrl> AllMahJongEnemyCtrl;
        public  float                  Phase1DownInterval  = 0.5f;
        public  float                  Phase2DownInterval1 = 0.3f;
        public  float                  Phase2DownInterval2 = 0.8f;

        private void Start() {
#if UNITY_EDITOR
            if (EditorTest_FightOnStart) {
                FightStart();
            }
#endif
        }

        public override void FightStart() {
            base.FightStart();
            foreach (MahJongEnemyCtrl mahJongEnemyCtrl in AllMahJongEnemyCtrl) {
                mahJongEnemyCtrl.Init();
            }
            FSM.TransitionToNextState(new MahJongPhase1(this));
        }

        public void SetEnemyToSky(List<MahJongEnemyCtrl> allEnemies) {
            if (allEnemies.IsNullOrEmpty()) {
                OnAllEnemySetToSky.Invoke();
            }
            
            StopAllCoroutines();
            StartCoroutine(setEnemyToSky());

            IEnumerator setEnemyToSky() {
                foreach (MahJongEnemyCtrl mahJongEnemyCtrl in allEnemies) {
                    mahJongEnemyCtrl.JumpToSky();
                    yield return new WaitForSeconds(SetEnemyToSkyInterval);
                }

                OnAllEnemySetToSky.Invoke();
            }
        }
    }
}