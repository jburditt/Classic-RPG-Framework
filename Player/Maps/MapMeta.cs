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
        public IList<NPC> NPCs { get; set; }
        public IList<EventId> Events { get; set; }

        public MapMeta(Layer layer)
        {
            TileSize = layer.TileSize;
            Tiles = new TileMeta[layer.LayerWidth, layer.LayerHeight];
            for (var x = 0; x < layer.LayerWidth; x++)
                for (var y = 0; y < layer.LayerHeight; y++)
                    Tiles[x, y] = new TileMeta();
        }

        public void AddNPC(NPC n)
        {
            if (NPCs == null)
                NPCs = new List<NPC>();

            NPCs.Add(n);
        }

        public void AddEvent(EventId n)
        {
            if (Events == null)
                Events = new List<EventId>();

            Events.Add(n);
        }

        public NPC GetNPC(Vector pos)
        {
            if (NPCs == null)
                return null;

            foreach (var n in NPCs)
            {
                if (n.Pos == pos)
                    return n;
            }

            return null;
        }

        public EventId GetEventId(Vector pos)
        {
            if (Events == null)
                return null;

            foreach (var n in Events)
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