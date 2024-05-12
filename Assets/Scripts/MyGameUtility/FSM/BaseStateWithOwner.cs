namespace MyGameUtility.FSM {
    public abstract class BaseStateWithOwner<TOwner> : BaseState {
        protected TOwner Owner;

        protected BaseStateWithOwner(TOwner owner) {
            Owner = owner;
        }
    }
}