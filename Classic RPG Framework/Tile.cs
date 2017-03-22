using Microsoft.Xna.Framework;

namespace Player
{
    public class Tile
    {
        public Rectangle SpriteRect { get; set; }
        public int Tileset { get; set; }
        public bool IsPassable { get; set; }
    }
}