namespace Player.Manager
{
    public interface ITilesetManager
    {
        void Load(string[] tilesetNames);
        void Draw(int i, Rect targetRect, Rect sourceRect, ColorStruct? color = null);
    }
}