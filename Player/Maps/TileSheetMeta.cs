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
}