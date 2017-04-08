using System.Collections.Generic;
using xTile;
using xTile.Dimensions;
using xTile.Layers;

namespace Player.Maps
{
    public class MapMeta
    {
        public IList<LayerMeta> Layers { get; set; }

        public MapMeta(Map map)
        {
            foreach (var layer in map.Layers)
                Layers.Add(new LayerMeta(layer));
        }
    }

    public class LayerMeta
    {
        public Size TileSize { get; set; }
        public TileMeta[,] Tiles { get; set; }

        public LayerMeta(Layer layer)
        {
            TileSize = layer.TileSize;
            Tiles = new TileMeta[layer.LayerWidth, layer.LayerHeight];
        }
    }
}