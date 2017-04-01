namespace Player.Graphics
{
    public interface IDialogManager
    {
        void Draw(Rect targetRect, int index = 0);
        void Draw(Rect sourceRet, Rect targetRect, ColorStruct? color = null);
        void DrawMessage(NPC npc, int index = 0);
    }
}