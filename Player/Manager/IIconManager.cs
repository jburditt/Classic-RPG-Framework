namespace Player.Manager
{
    public interface IIconManager
    {
        void Draw(string iconName, Vector vector, ColorStruct? color = null);
        void Draw(string iconName, Rect sourceRect, Rect targetRect, ColorStruct? color = null);
    }
}