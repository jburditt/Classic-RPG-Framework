namespace Player.Manager
{
    public interface ITilesetManager
    {
        void Draw(string tilesetName, Rect targetRect, Rect sourceRect, ColorStruct? color = null);
    }
}