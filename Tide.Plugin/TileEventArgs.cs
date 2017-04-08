using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
