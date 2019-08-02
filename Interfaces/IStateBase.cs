namespace Assets.Code.Interfaces
{
    public interface IStateBase 
    // Inyección
    // estos son todos los métododos que StateManage va a usar en vez de los de Unity. 
    {
        void StateUpdate();
        
        void StateFixedUpdate();

        void ShowIt();
    }
}