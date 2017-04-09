using System;
using System.Collections.Generic;
using xTile;
using xTile.Dimensions;
using xTile.Layers;

namespace Player.Maps
{
    [Serializable]
    public class MapMeta
    {
        public IList<LayerMeta> Layers { get; set; } = new List<LayerMeta>();

        public MapMeta(Map map)
        {
            foreach (var layer in map.Layers)
                Layers.Add(new LayerMeta(layer));
        }
    }

    [Serializable]
    public class LayerMeta
    {
        public Size TileSize { get; set; }
        public TileMeta[,] Tiles { get; set; }

        public LayerMeta(Layer layer)
        {
            TileSize = layer.TileSize;
            Tiles = new TileMeta[layer.LayerWidth, layer.LayerHeight];
            for (var x = 0; x < layer.LayerWidth; x++)
                for (var y = 0; y < layer.LayerHeight; y++)
                    Tiles[x, y] = new TileMeta();
        }

        public IEnumerable<TileMeta> TileEnumerator
        {
            get
            {
                for (var x = 0; x < Tiles.Columns(); x++)
                    for (var y = 0; y < Tiles.Rows(); y++)
                        if (Tiles[x, y] != null)
                            yield return Tiles[x, y];
            }
        }

        public IEnumerable<NPC> NPCEnumerator
        {
            get
            {
                foreach (var tile in TileEnumerator)
                    if (tile.NPC != null)
                        yield return tile.NPC;
            }
        }

        public IList<NPC> NPCs
        {
            get
            {
                var list = new List<NPC>();

                foreach (var npc in NPCEnumerator)
                    list.Add(npc);

                return list;
            }
        }
    }
}