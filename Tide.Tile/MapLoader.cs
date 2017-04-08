using xTile.Format;

namespace xTile
{
    public class MapLoader
    {
        public static TideMap LoadMap(string filename)
        {
            return FormatManager.Instance.LoadMap(filename);
        }
    }
}