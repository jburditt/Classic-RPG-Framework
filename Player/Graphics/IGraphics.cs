namespace Player.Graphics
{
    public interface IGraphics
    {
        void DrawSprite(string spriteName, int x, int y, ColorStruct? color = null);
        void DrawSprite(string spriteName, Rect sourceRect, Rect targetRect, ColorStruct? color = null);
        void DrawString(string text, int x, int y);
    }
}