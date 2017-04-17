using System;
using Common;
using xTile.Dimensions;
using xTile.Layers;

namespace Player.Maps
{
    [Serializable]
    public class LayerMeta
    {
        public string Id { get; set; }
        public Size TileSize { get; set; }
        public TileMeta[,] Tiles { get; set; }

        public LayerMeta(Layer layer)
        {
            Id = layer.Id;
            TileSize = layer.TileSize;
            Tiles = new TileMeta[layer.LayerWidth, layer.LayerHeight];
            for (var x = 0; x < layer.LayerWidth; x++)
                for (var y = 0; y < layer.LayerHeight; y++)
                    Tiles[x, y] = new TileMeta();
        }

        public void Resize(Layer layer)
        {
            Tiles = Tiles.Resize(layer.TileWidth, layer.TileHeight);
        }
    }
}