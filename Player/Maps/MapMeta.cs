using System;
using System.Collections.Generic;
using xTile;
using xTile.Layers;

namespace Player.Maps
{
    [Serializable]
    public class MapMeta
    {
        public IList<NPC> NPCs { get; set; } = new List<NPC>();
        public IList<LayerMeta> Layers { get; set; } = new List<LayerMeta>();

        public MapMeta(Map map)
        {
            foreach (var layer in map.Layers)
                Layers.Add(new LayerMeta(layer));
        }

        //public void Resize(Map map)
        //{
        //    // add any missing layers
        //    if (map.Layers.Count < Layers.Count)
        //        Layers.Add(FindMissingLayer(map));

        //    // reorder layers to match
        //    for (var i = 0; i < map.Layers.Count; i++)
        //    {
        //        if (map.Layers[i].Id != Layers[i].Id)
        //        {

        //        }
        //    }

        //    // delete any extra layers

        //    // resize all layers
        //}

        //private Layer FindMissingLayer(Map map)
        //{
        //    for (var i = 0; i < Layers.Count)
        //        if (Layers[i].Id )
        //}

        public LayerMeta FindLayer(Layer layer)
        {
            foreach (var layerMeta in Layers)
                if (layerMeta.Id == layer.Id)
                    return layerMeta;

            return null;
        }

        public void DeleteLayer(Layer layer)
        {
            Layers.Remove(FindLayer(layer));
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
    }
}