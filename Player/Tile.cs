using System.Collections.Generic;

namespace Player
{
    public class Tile
    {
        public Rect SpriteRect { get; set; }
        public int Tileset { get; set; }
        public bool IsPassable { get; set; }
        public List<NPC> NPC { get; set; }
    }
}