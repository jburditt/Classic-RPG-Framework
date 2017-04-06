using xTile;
using xTile.Format;

namespace tIDEReader
{
    public class TideReader
    {
        public TideMap m_map { get; set; }

        public TideReader(string filename)
        {
            LoadMap(filename);
        }

        private void LoadMap(string filename)
        {
            m_map = FormatManager.Instance.LoadMap(filename);
        }
    }
}