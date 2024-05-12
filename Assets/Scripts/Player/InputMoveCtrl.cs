using UnityEngine;

namespace Player {
    public class InputMoveCtrl : MonoBehaviour {
        public Rigidbody2D Rigidbody2DRef;
        public float       MoveSpeed;
        
        private void Update() {
            var inputValue = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Rigidbody2DRef.velocity = inputValue * MoveSpeed;
            // this.transform.position += inputValue * MoveSpeed * Time.deltaTime;
        }
    }
}