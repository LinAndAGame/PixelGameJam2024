using System;
using Player;
using UnityEngine;

namespace AttackUnit {
    public class AttackUnit : MonoBehaviour {
        public Vector3 MoveDir;
        public float   MoveSpeed;

        public bool CanMove { get; set; }

        private void Update() {
            if (CanMove) {
                this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + MoveDir * 100, MoveSpeed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.transform.CompareTag("Player")) {
                PlayerCtrl playerCtrl = other.transform.GetComponent<PlayerCtrl>();
                playerCtrl.Death();
            }
            else if (other.transform.CompareTag("Wall")) {
                DestroySelf();
            }
        }

        public void DestroySelf() {
            Destroy(this.gameObject);
        }
    }
}