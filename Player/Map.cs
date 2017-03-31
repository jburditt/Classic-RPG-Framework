using Common;
using Player.Manager;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TiledSharp;

namespace Player
{
    public class Map
    {
        private readonly ITilesetManager _tilesetManager;

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int Layers { get; set; }

        public TmxMap tiledMap { get; set; }
        Tile[,,] tiles;

        int windowTilesWide, windowTilesHigh;

        public Map(ITilesetManager tilesetManager, string map)
        {
            _tilesetManager = tilesetManager;

            tiledMap = new TmxMap(map);

            TileWidth = tiledMap.Tilesets[0].TileWidth;              // width of tile in pixels
            TileHeight = tiledMap.Tilesets[0].TileHeight;            // height of tile

            windowTilesWide = Screen.Width / TileWidth;         // number of columns in window
            windowTilesHigh = Screen.Height / TileHeight;       // number of rows in window

            Width = tiledMap.Width * TileWidth;                      // width of map in pixels
            Height = tiledMap.Height * TileHeight;                   // height of map

            Columns = tiledMap.Width;
            Rows = tiledMap.Height;
            Layers = tiledMap.Layers.Count;

            var tilesets = tiledMap.Tilesets;
            var tilesetNames = tilesets.Select(n => n.Image.Source).ToArray();

            tilesetManager.Load(tilesetNames);

            tiles = Load();
        }

        public Tile[,,] Load()
        {
            var tiles = new Tile[tiledMap.Width, tiledMap.Height, tiledMap.Layers.Count];

            var serializer = new XmlSerializer(typeof(bool[][][]));
            var reader = new StreamReader("../../../Data/world2.passable.xml");
            var passable = (bool[][][])serializer.Deserialize(reader);

            for (var x = 0; x < tiledMap.Width; x++)
                for (var y = 0; y < tiledMap.Height; y++)
                    for (var layer = 0; layer < tiledMap.Layers.Count; layer++)
                    {
                        int tileIndex = x + y * tiledMap.Width;

                        int gid = tiledMap.Layers[layer].Tiles[tileIndex].Gid;
                        if (gid == 0)
                            continue;

                        int tilesetIndex = 0;
                        int tileCount = 0;
                        int row = 0, column = 0;

                        // get tilesetIndex and position in tileset from gid
                        for (var i = 0; i < tiledMap.Tilesets.Count; i++)
                        {
                            if (gid < tiledMap.Tilesets[i].TileCount + tileCount)
                            {
                                tilesetIndex = i;
                                int tileFrame = gid - tileCount - 1;
                                int columns = tiledMap.Tilesets[i].Columns ?? 1;
                                column = tileFrame % columns;
                                row = (tileFrame) / columns;
                                break;
                            }

                            // make sure we tally the tile count, so we know what to subtract from gid
                            tileCount += tiledMap.Tilesets[i].TileCount ?? 0;
                        }

                        var tileWidth = tiledMap.Tilesets[0].TileWidth;
                        var tileHeight = tiledMap.Tilesets[0].TileHeight;

                        tiles[x, y, layer] = new Tile
                        {
                            SpriteRect = new Rect(tileWidth * column, tileHeight * row, tileWidth, tileHeight),
                            Tileset = tilesetIndex,
                            IsPassable = passable[tilesetIndex][column][row]
                        };
                    }

            return tiles;
        }

        // TODO Optimize by adding direction
        public bool IsCollision(int playerX, int playerY, Direction direction)
        {
            var x = playerX / TileWidth;
            var y = playerY / TileHeight;

            var isCollision = false;

            switch (direction)
            {
                case Direction.Up:
                    isCollision = IsTileCollision(playerX, playerY, x, y) || (playerX % TileWidth != 0 && IsTileCollision(playerX, playerY, x + 1, y));
                    return isCollision;
                case Direction.Right:
                    isCollision = IsTileCollision(playerX, playerY, x + 1, y) || (playerY % TileHeight != 0 && IsTileCollision(playerX, playerY, x + 1, y + 1));
                    return isCollision;
                case Direction.Down:
                    isCollision = IsTileCollision(playerX, playerY, x, y + 1) || (playerX % TileWidth != 0 && IsTileCollision(playerX, playerY, x + 1, y + 1));
                    return isCollision;
                case Direction.Left:
                    isCollision = IsTileCollision(playerX, playerY, x, y) || (playerY % TileHeight != 0 && IsTileCollision(playerX, playerY, x, y + 1));
                    return isCollision;
            }

            return false;
        }

        public bool IsTileCollision(int playerX, int playerY, int x, int y)
        {
            // don't check tiles out of bounds
            if (x < 0 || x >= Columns || y < 0 || y >= Height)
                return true;

            for (int layerIndex = 0; layerIndex < Layers; layerIndex++)
            {
                var tile = tiles[x, y, layerIndex];

                if (tile != null && !tile.IsPassable)
                {
                    var playerRect = new Rect(playerX, playerY + 8, 24, 24);
                    var tileRect = new Rect(x * TileWidth, y * TileHeight, TileWidth, TileHeight);

                    if (playerRect.Intersects(tileRect))
                        return true;
                }
            }

            return false;
        }

        public void Draw(int playerX, int playerY)
        {
            for (var y = 0; y <= windowTilesHigh; y++)
                for (var x = 0; x <= windowTilesWide; x++)
                {
                    // don't draw extra tile if on the boundary
                    if (playerY >= Height - Screen.HalfHeight && y == windowTilesHigh)
                        break;
                    if (playerX >= Width - Screen.HalfWidth && x == windowTilesWide)
                        continue;

                    int playerTileX, playerTileY;
                    int offsetX = 0, offsetY = 0;

                    // handle player X coordinate
                    if (playerX < Screen.HalfWidth)
                    {
                        // offset player when near the left boundary of the map
                        playerTileX = 0;
                    }
                    else if (playerX > Width - Screen.HalfWidth)
                    {
                        // offset player when near the right boundary of the map
                        playerTileX = (Width - Screen.Width) / TileWidth;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileX = (playerX - Screen.HalfWidth) / TileWidth;
                        offsetX = playerX % TileWidth;
                    }

                    // handle player Y coordinate
                    if (playerY < Screen.HalfHeight)
                    {
                        // offset player when near the top boundary of the map
                        playerTileY = 0;
                    }
                    else if (playerY > Height - Screen.HalfHeight)
                    {
                        // offset player when near the bottom boundary of the map
                        playerTileY = (Height - Screen.Height) / TileHeight;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileY = (playerY - Screen.HalfHeight) / TileHeight;
                        offsetY = (playerY + 16) % TileHeight;
                    }

                    // draw all tile layers
                    for (var layer = 0; layer < Layers; layer++)
                    {
                        var tile = tiles[x + playerTileX, y + playerTileY, layer];

                        if (tile != null)
                        {
                            var drawRect = new Rect(x * TileWidth - offsetX, y * TileHeight - offsetY, TileWidth, TileHeight);

                            _tilesetManager.Draw(tile.Tileset, drawRect, tile.SpriteRect);
                        }
                    }
                }
        }
    }
}