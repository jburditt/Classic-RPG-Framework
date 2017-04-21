using System;
using System.Drawing;
using xTile.Dimensions;

namespace tIDE.Plugin
{
    public class TileEventArgs : EventArgs
    {
        public Graphics Graphics { get; set; }
        public Location Location { get; set; }
        public Location TileLocation { get; set; }
        public xTile.Dimensions.Size TileSize { get; set; }

        public TileEventArgs(Graphics graphics, Location location, Location tileLocation, xTile.Dimensions.Size tileSize)
        {
            Graphics = graphics;
            Location = location;
            TileLocation = tileLocation;
            TileSize = tileSize;
        }
    }
}