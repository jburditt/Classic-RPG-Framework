namespace Player.Manager
{
    public interface IIconManager
    {
        void Draw(string iconName, int x, int y, ColorStruct? color = null);
    }
}