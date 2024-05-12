namespace MyGameUtility.FSM {
    public abstract class BaseState {
        public    BaseMachine     Machine;
        protected CacheCollection CC = new CacheCollection();
        
        public virtual void OnEnterState() { }
        public virtual void OnStayState() { }

        public virtual void OnExitState() {
            CC.Clear();
        }
    }
}