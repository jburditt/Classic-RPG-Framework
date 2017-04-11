using System;

namespace Player.Maps
{
    [Serializable]
    public class TileSheetMeta
    {
        public ColorStruct TransparencyColor { get; set; }
        public TileSheetTile[,] Tiles { get; set; }
    }

    [Serializable]
    public class TileSheetTile
    {
        public bool IsBlocked { get; set; }
    }

    public static class TileSheetExtensions
    {
        public static int Rows(this TileSheetTile[,] tiles)
        {
            return tiles.Rank > 1 ? tiles.GetLength(1) : 0;
        }

        public static int Columns(this TileSheetTile[,] tiles)
        {
            return tiles.Rank > 0 ? tiles.GetLength(0) : 0;
        }
    }
}