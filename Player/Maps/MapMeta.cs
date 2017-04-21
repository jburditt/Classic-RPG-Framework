using Player.Events;
using System;
using System.Collections.Generic;
using xTile.Dimensions;
using xTile.Layers;

namespace Player.Maps
{
    [Serializable]
    public class MapMeta
    {
        public Size TileSize { get; set; }
        public TileMeta[,] Tiles { get; set; }
        // TODO Make NPC Collection
        public IList<NPC> NPCs { get; set; } = new List<NPC>();
        public EventCollection EventCollection { get; set; }

        public MapMeta(Layer layer)
        {
            TileSize = layer.TileSize;
            Tiles = new TileMeta[layer.LayerWidth, layer.LayerHeight];
            for (var x = 0; x < layer.LayerWidth; x++)
                for (var y = 0; y < layer.LayerHeight; y++)
                    Tiles[x, y] = new TileMeta();
        }

        public NPC GetNPC(Vector pos)
        {
            foreach (var n in NPCs)
            {
                if (n.Pos == pos)
                    return n;
            }

            return null;
        }

        public void RemoveNPC(NPC npc)
        {
            NPCs.Remove(npc);
        }
    }
}