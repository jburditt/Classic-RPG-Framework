namespace Player.Manager
{
    public interface ITilesetManager
    {
        int TileWidth { get; set; }
        int TileHeight { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Columns { get; set; }
        int Rows { get; set; }
        int Layers { get; set; }

        Tile[,,] LoadFromTiledMap();
        void Draw(int i, Rect targetRect, Rect sourceRect, ColorStruct? color = null);
    }
}