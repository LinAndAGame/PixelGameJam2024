using System;
using GameData;
using MyGameUtility;
using UnityEngine;

namespace Player {
    public class PlayerCtrl : MonoSingletonSimple<PlayerCtrl> {
        public Transform Trans_Model;
        public float     MaxFireDuration = 1;
        public float     FireForce       = 20;
        public Transform Trans_OtherModel;

        private float _Timer;
        
        private void Update() {
            if (Input.GetKeyDown(Save_GlobalData.I.KeyCodeConfig.Interrupt)) {
                _Timer = Time.time;
            }else if (Input.GetKeyUp(Save_GlobalData.I.KeyCodeConfig.Interrupt)) {
                var duration = Time.time - _Timer;
                var force    = FireForce * Mathf.Min(MaxFireDuration, duration) / MaxFireDuration;
                Trans_OtherModel.SetParent(null);
                // Trans_OtherModel.
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            
        }

        public void EnterRoom() {
            
        }
    }
}