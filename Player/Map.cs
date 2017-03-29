using Player;
using Player.Manager;

namespace MonoGame
{
    public class Map
    {
        private readonly ITilesetManager _tilesetManager;

        public int Width { get { return _tilesetManager.Width; } }
        public int Height { get { return _tilesetManager.Height; } }

        Tile[,,] tiles;

        int windowTilesWide, windowTilesHigh;

        public Map(ITilesetManager tilesetManager)
        {
            _tilesetManager = tilesetManager;

            windowTilesWide = Screen.Width / _tilesetManager.TileWidth;         // number of columns in window
            windowTilesHigh = Screen.Height / _tilesetManager.TileHeight;       // number of rows in window

            tiles = _tilesetManager.LoadFromTiledMap();
        }

        // TODO Optimize by adding direction
        public bool IsCollision(int playerX, int playerY, Direction direction)
        {
            var x = playerX / _tilesetManager.TileWidth;
            var y = playerY / _tilesetManager.TileHeight;

            var isCollision = false;

            switch (direction)
            {
                case Direction.Up:
                    isCollision = IsTileCollision(playerX, playerY, x, y) || (playerX % _tilesetManager.TileWidth != 0 && IsTileCollision(playerX, playerY, x + 1, y));
                    return isCollision;
                case Direction.Right:
                    isCollision = IsTileCollision(playerX, playerY, x + 1, y) || (playerY % _tilesetManager.TileHeight != 0 && IsTileCollision(playerX, playerY, x + 1, y + 1));
                    return isCollision;
                case Direction.Down:
                    isCollision = IsTileCollision(playerX, playerY, x, y + 1) || (playerX % _tilesetManager.TileWidth != 0 && IsTileCollision(playerX, playerY, x + 1, y + 1));
                    return isCollision;
                case Direction.Left:
                    isCollision = IsTileCollision(playerX, playerY, x, y) || (playerY % _tilesetManager.TileHeight != 0 && IsTileCollision(playerX, playerY, x, y + 1));
                    return isCollision;
            }

            return false;
        }

        public bool IsTileCollision(int playerX, int playerY, int x, int y)
        {
            // don't check tiles out of bounds
            if (x < 0 || x >= _tilesetManager.Columns || y < 0 || y >= _tilesetManager.Height)
                return true;

            for (int layerIndex = 0; layerIndex < _tilesetManager.Layers; layerIndex++)
            {
                var tile = tiles[x, y, layerIndex];

                if (tile != null && !tile.IsPassable)
                {
                    var playerRect = new Rect(playerX, playerY + 8, 24, 24);
                    var tileRect = new Rect(x * _tilesetManager.TileWidth, y * _tilesetManager.TileHeight, _tilesetManager.TileWidth, _tilesetManager.TileHeight);

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
                    if (playerY >= _tilesetManager.Height - Screen.HalfHeight && y == windowTilesHigh)
                        break;
                    if (playerX >= _tilesetManager.Width - Screen.HalfWidth && x == windowTilesWide)
                        continue;

                    int playerTileX, playerTileY;
                    int offsetX = 0, offsetY = 0;

                    // handle player X coordinate
                    if (playerX < Screen.HalfWidth)
                    {
                        // offset player when near the left boundary of the map
                        playerTileX = 0;
                    }
                    else if (playerX > _tilesetManager.Width - Screen.HalfWidth)
                    {
                        // offset player when near the right boundary of the map
                        playerTileX = (_tilesetManager.Width - Screen.Width) / _tilesetManager.TileWidth;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileX = (playerX - Screen.HalfWidth) / _tilesetManager.TileWidth;
                        offsetX = playerX % _tilesetManager.TileWidth;
                    }

                    // handle player Y coordinate
                    if (playerY < Screen.HalfHeight)
                    {
                        // offset player when near the top boundary of the map
                        playerTileY = 0;
                    }
                    else if (playerY > _tilesetManager.Height - Screen.HalfHeight)
                    {
                        // offset player when near the bottom boundary of the map
                        playerTileY = (_tilesetManager.Height - Screen.Height) / _tilesetManager.TileHeight;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileY = (playerY - Screen.HalfHeight) / _tilesetManager.TileHeight;
                        offsetY = (playerY + 16) % _tilesetManager.TileHeight;
                    }

                    // draw all tile layers
                    for (var layer = 0; layer < _tilesetManager.Layers; layer++)
                    {
                        var tile = tiles[x + playerTileX, y + playerTileY, layer];

                        if (tile != null)
                        {
                            var drawRect = new Rect(x * _tilesetManager.TileWidth - offsetX, y * _tilesetManager.TileHeight - offsetY, _tilesetManager.TileWidth, _tilesetManager.TileHeight);

                            _tilesetManager.Draw(tile.Tileset, drawRect, tile.SpriteRect);
                        }
                    }
                }
        }
    }
}