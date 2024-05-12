using GameData;
using MyGameUtility.FSM;
using UnityEngine;

namespace Room {
    public class BaseRoomCtrl : MonoBehaviour {
        public RoomData CurRoomData;

        protected BaseMachine FSM = new DefaultMachine(null);
        
        private void Update() {
            FSM.Update();
        }
        
        public virtual void OpenAnimationStart(){ }
        public virtual void OpenAnimationEnd(){ }
        public virtual void FightStart(){ }
        public virtual void FightEnd(){ }
    }
}