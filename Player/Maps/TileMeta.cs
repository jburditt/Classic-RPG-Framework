using System.Collections.Generic;

namespace Player.Maps
{
    public class TileMeta
    {
        public IList<NPC> NPCs { get; set; }
    }

    public static class TileExtensions
    {
        public static int Rows(this TileMeta[,] tiles)
        {
            return tiles.Rank > 0 ? tiles.GetLength(0) : 0;
        }

        public static int Columns(this TileMeta[,] tiles)
        {
            return tiles.Rank > 1 ? tiles.GetLength(1) : 0;
        }
    }
}
