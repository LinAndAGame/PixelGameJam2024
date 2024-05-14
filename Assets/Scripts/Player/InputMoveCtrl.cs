using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player {
    public class InputMoveCtrl : MonoBehaviour {
        public Rigidbody2D    Rigidbody2DRef;
        public float          acceleration       = 10f;  // 加速度
        public float          maxSpeed           = 5f;   // 最大速度
        public float          friction           = 0.1f; // 摩擦力系数
        public float          bounceFactor       = 0.8f; // 弹力系数
        public float          MinScale           = 0.7f;
        public float          ResetScaleDuration = 0.5f;
        public AnimationCurve ResetScaleCurve;

        private Vector2 velocity; // 当前速度
        private Vector2 movement;
        private Vector2 _LastMovement;

        void FixedUpdate() {
            HandleInput();
            ApplyFriction();
            ClampVelocity();
            Move();
            
            ApplyRotation();
            ApplyScale();
            _LastMovement = movement;
        }

        void HandleInput() {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movement      =  new Vector2(moveX, moveY) * acceleration * Time.fixedDeltaTime;
            velocity      += movement;
        }

        void ApplyFriction() {
            if (movement != Vector2.zero) {
                return;
            }
            
            if (velocity.magnitude > 0) {
                Vector2 frictionForce = -velocity.normalized * friction * Time.fixedDeltaTime;
                velocity += frictionForce;

                if (velocity.magnitude < friction * Time.fixedDeltaTime) {
                    velocity = Vector2.zero;
                }
            }
        }

        void ClampVelocity() {
            if (velocity.magnitude > maxSpeed) {
                velocity = velocity.normalized * maxSpeed;
            }
        }

        void Move() {
            transform.position += (Vector3) velocity * Time.fixedDeltaTime;
        }

        void ApplyRotation() {
            if (movement == Vector2.zero) {
                // this.transform.localEulerAngles = Vector3.zero;
            }
            else {
                this.transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);   
            }
        }

        void ApplyScale() {
            if (movement != Vector2.zero) {
                float ratio = velocity.magnitude / maxSpeed;
                this.transform.localScale = new Vector3(1 + (MinScale - 1) * ratio, 1, 1);
            }
            else {
                if (_LastMovement != Vector2.zero) {
                    this.transform.DOScale(Vector3.one, ResetScaleDuration).SetEase(ResetScaleCurve);
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collision) {
            Vector2 normal            = collision.contacts[0].normal;
            Vector2 reflectedVelocity = Vector2.Reflect(velocity, normal) * bounceFactor;
            velocity = reflectedVelocity;
        }
    }
}