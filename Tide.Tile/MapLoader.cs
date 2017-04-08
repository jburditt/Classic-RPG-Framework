using xTile.Format;

namespace xTile
{
    public class MapLoader
    {
        public static Map LoadMap(string filename)
        {
            return FormatManager.Instance.LoadMap(filename);
        }
    }
}