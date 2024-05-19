using MyGameUtility;
using MyGameUtility.FSM;
using Player;
using UnityEngine;

namespace Enemy {
    public class RotateCircleEnemyCtrl : MonoBehaviour {
        public PhysicalEventTrigger PET;
        public RotateDashStateData  RotateDashStateDataRef;
        public BeCollisionStateData BeCollisionStateDataRef;

        public BaseMachine AI_FSM { get; private set; }
        
        public void Start() {
            AI_FSM = new DefaultMachine(null);
            AI_FSM.TransitionToNextState(new RotateDashState(this));
            
            PET.OnCollisionEnter2DAct.AddListener(data => {
                if (data.transform.CompareTag("Player")) {
                    PlayerCtrl playerCtrl = data.transform.GetComponent<PlayerCtrl>();
                    playerCtrl.Death();
                }
                
                BeCollisionStateDataRef.ContactPoint2DRef = data.contacts[0];
                AI_FSM.TransitionToNextState(new BeCollisionState(this));
            });
        }

        public void DestroySelf() {
            Destroy(this.gameObject);
        }
    }
}