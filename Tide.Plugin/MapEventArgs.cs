using System;
using xTile;
using xTile.Dimensions;
using xTile.Layers;

namespace tIDE.Plugin
{
    public class MapEventArgs : EventArgs
    {
        public Map Map { get; set; }
        public Layer Layer { get; set; }
        //public Location Location { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string FilePath { get; set; }

        public MapEventArgs(Map map, string filePath)
        {
            Map = map;
            FilePath = filePath;
        }

        public MapEventArgs(Map map, Layer layer, int x, int y)
        {
            Map = map;
            Layer = layer;
            X = x;
            Y = y;
        }
    }
}