namespace Player.StateStack
{
    public interface IState
    {
        bool Update(float elapsedTime);
        void Draw();
        void OnLoad();
        void OnClose();
    }
}