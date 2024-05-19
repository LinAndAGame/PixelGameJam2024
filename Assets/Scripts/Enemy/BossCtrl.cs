using System;
using System.Collections.Generic;
using AttackUnit;
using MyGameUtility.FSM;
using UnityEngine;

namespace Enemy {
    public class BossCtrl : MonoBehaviour {
        public BossDashStateData              BossDashStateDataRef;
        public RotateLockStateData            RotateLockStateDataRef;
        public TriggerAttackUnitCtrlStateData TriggerAttackUnitCtrlStateDataRef;

        public List<BaseAttackUnitCtrl> AllAttackUnitCtrls;

        private List<BaseState> _AllStates = new List<BaseState>();

        public BaseMachine FSM { get; private set; }

        public void Init() {
            var state  = new BossDashState(BossDashStateDataRef);
            var state2 = new TriggerAttackUnitCtrlState(TriggerAttackUnitCtrlStateDataRef);
            var state3 = new RotateLockState(RotateLockStateDataRef);
            state.OnStateExit.AddListener(() => { FSM.TransitionToNextState(state2); });
            state3.OnStateExit.AddListener(() => { FSM.TransitionToNextState(state); });
            state2.OnStateExit.AddListener(() => { FSM.TransitionToNextState(state3); });

            _AllStates.Add(state);
            _AllStates.Add(state2);
            _AllStates.Add(state3);
        }

        public void Restart() {
            if (FSM != null) {
                FSM.TransitionToNextState(null);
            }
            foreach (BaseAttackUnitCtrl baseAttackUnitCtrl in AllAttackUnitCtrls) {
                baseAttackUnitCtrl.Clear();
            }

            this.transform.rotation = Quaternion.LookRotation(this.transform.forward, Vector3.up);
            FSM                     = new DefaultMachine(null);
            FSM.TransitionToNextState(_AllStates[1]);
        }

        private void Update() {
            FSM.Update();
        }
    }
}