using System;
using DefaultNamespace;
using GameData;
using MyGameUtility;
using UnityEngine;

namespace Player {
    public class PlayerCtrl : MonoSingletonSimple<PlayerCtrl> {
        public Transform   Trans_Model;
        public Rigidbody2D Rigidbody2DRef;
        public float       DashForce = 10;
        public float       DashCD;

        private float _NextDashTime;
        private bool  CanDash => Time.time >= _NextDashTime;
        
        private void Update() {
            if (CanDash && Input.GetKeyDown(Save_GlobalData.I.KeyCodeConfig.Dash)) {
                this.Rigidbody2DRef.AddForce(this.transform.up * DashForce, ForceMode2D.Impulse);
                _NextDashTime = Time.time + DashCD;
            }
        }

        public void Death() {
            GameManager.I.Defeat();
        }
    }
}