using xTile;
using xTile.Dimensions;
using xTile.Layers;

namespace tIDE.Plugin
{
    public class MapEventArgs
    {
        public Map Map { get; set; }
        public Layer Layer { get; set; }
        public Location Location { get; set; }

        public MapEventArgs(Map map, Layer layer, Location location)
        {
            Map = map;
            Layer = layer;
            Location = Location;
        }
    }
}