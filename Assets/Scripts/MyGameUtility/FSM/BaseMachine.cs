namespace MyGameUtility.FSM {
    public abstract class BaseMachine {
        public CustomAction OnStateChanged = new CustomAction(); 
        
        public BaseState CurState { get; private set; }

        public BaseMachine(BaseState curState) {
            TransitionToNextState(curState);
        }

        public void Update() {
            if (CurState!= null) {
                CurState.OnStayState();
            }
        }

        public void TransitionToNextState(BaseState state) {
            if (CurState != null) {
                CurState.OnExitState();
                CurState.Machine = null;
            }

            CurState = state;

            if (CurState != null) {
                CurState.Machine = this;
                CurState.OnEnterState();
            }
        }
    }
}