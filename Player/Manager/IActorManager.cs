namespace Player.Manager
{
    public interface IActorManager
    {
        void Draw(string actorName, Rect sourceRect, Rect targetRect, ColorStruct? color = null);
        void DrawBattle(string actorName, Rect sourceRect, Rect targetRect, ColorStruct? color = null);
    }
}