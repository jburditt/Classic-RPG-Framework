using Microsoft.Xna.Framework;

namespace TiledSharp_MonoGame_Example_2
{
    public class Tile
    {
        public Rectangle SpriteRect { get; set; }
        public int Tileset { get; set; }
        public bool IsPassable { get; set; }
    }
}