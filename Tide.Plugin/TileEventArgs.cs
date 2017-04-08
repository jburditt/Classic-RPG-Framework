using System;
using xTile.Dimensions;

namespace tIDE.Plugin
{
    public class TileEventArgs : EventArgs
    {
        private Location m_location;

        public TileEventArgs(Location location)
        {
            m_location = location;
        }

        public Location Location
        {
            get { return m_location; }
        }
    }
}