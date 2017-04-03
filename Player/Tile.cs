using Player.Events;

namespace Player
{
    public class Tile
    {
        public Rect SpriteRect { get; set; }
        public string Tileset { get; set; }
        public bool IsPassable { get; set; }
        public EventCollection EventCollection { get; set; }
    }
}