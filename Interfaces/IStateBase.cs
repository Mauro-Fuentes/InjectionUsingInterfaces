namespace Assets.Code.Interfaces
{
    public interface IStateBase 
    // Injection
    // These are the method (contracts) that StateManager will use instead of Unity's
    {
        void StateUpdate();
        
        void StateFixedUpdate();

        void ShowIt();
    }
}