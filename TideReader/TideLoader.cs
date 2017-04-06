using xTile;
using xTile.Format;

namespace tIDEReader
{
    public class TideLoader
    {
        public TideMap m_map { get; set; }

        public TideLoader(string filename)
        {
            LoadMap(filename);
        }

        private void LoadMap(string filename)
        {
            m_map = FormatManager.Instance.LoadMap(filename);
        }
    }
}