using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace TiledSharp_MonoGame_Example_2
{
    public class Map
    {
        TmxMap tiledMap;
        Tile[,,] tiles;
        Texture2D[] tileset;

        int tileWidth, tileHeight;
        int tilesetTilesWide, tilesetTilesHigh;
        int windowTilesWide, windowTilesHigh;

        public static int Width;
        public static int Height;

        public Map(ContentManager Content, GameWindow Window)
        {
            tiledMap = new TmxMap("Content/world2.tmx");

            tileset = new Texture2D[tiledMap.Tilesets.Count];
            for (var i = 0; i < tiledMap.Tilesets.Count; i++) 
                tileset[i] = Content.Load<Texture2D>(tiledMap.Tilesets[i].Name);

            // TODO
            tileWidth = tiledMap.Tilesets[0].TileWidth;              // width of tile in pixels
            tileHeight = tiledMap.Tilesets[0].TileHeight;            // height of tile

            tilesetTilesWide = tileset[0].Width / tileWidth;       // number of columns in tileset
            tilesetTilesHigh = tileset[0].Height / tileHeight;     // number of rows in tileset

            windowTilesWide = Screen.Width / tileWidth;         // number of columns in window
            windowTilesHigh = Screen.Height / tileHeight;       // number of rows in window

            Width = tiledMap.Width * tileWidth;                      // width of map in pixels
            Height = tiledMap.Height * tileHeight;                   // height of map

            tiles = LoadFromTiledMap(tiledMap);
        }

        private Tile[,,] LoadFromTiledMap(TmxMap tmxMap)
        {
            tiles = new Tile[tmxMap.Width, tmxMap.Width, tmxMap.Layers.Count];

            for (var x = 0; x < tmxMap.TileWidth; x++)
                for (var y = 0; y < tmxMap.TileHeight; y++)
                    for (var layer = 0; layer < tmxMap.Layers.Count; layer++)
                    {
                        int tileIndex = x + y * tmxMap.Width;
                        var tile = tmxMap.Layers[layer].Tiles[tileIndex];

                        int gid = tile.Gid;
                        if (gid == 0)
                            continue;

                        int tilesetIndex = 0;
                        int tileCount = 1;
                        int row = 0, column = 0;

                        for (var i = 0; i < tmxMap.Tilesets.Count; i++)
                        {
                            if (gid < tmxMap.Tilesets[i].TileCount + tileCount)
                            {
                                tilesetIndex = i;
                                int tileFrame = gid - tileCount;
                                column = tileFrame % tilesetTilesWide;
                                row = (tileFrame) / tilesetTilesWide;
                                break;
                            }

                            // make sure we tally the tile count, so we know what to subtract from gid
                            tileCount += tmxMap.Tilesets[i].TileCount ?? 0;
                        }

                        tiles[x, y, layer] = new Tile
                        {
                            SpriteRect = new Rectangle(tileWidth*column, tileHeight*row, tileWidth, tileHeight),
                            Tileset = tilesetIndex
                        };
                    }

            return tiles;
        }

        // TODO Optimize by adding direction
        public bool IsCollision(int x, int y)
        {
            Rectangle playerRect = new Rectangle(x, y, 24, 32);
            Rectangle tileRect;

            // check 4 adjacent tiles around player
            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                {
                    var tileIndex = x / tileWidth + i + (y / tileHeight + j) * tiledMap.Width;

                    for (int layerIndex = 0; layerIndex < tiledMap.Layers.Count; layerIndex++)
                    {
                        var tileId = tiledMap.Layers[layerIndex].Tiles[tileIndex].Gid - 1;

                        foreach (var tile in tiledMap.Tilesets[0].Tiles)
                        {
                            if (tileId == tile.Id && tile.ObjectGroups != null && tile.ObjectGroups.Count > 0)
                            {
                                tileRect = new Rectangle(x + i * tileWidth, y + j * tileHeight, tileWidth, tileHeight);
                                if (playerRect.Intersects(tileRect))
                                    return true;
                            }
                        }
                    }
                }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch, int playerX, int playerY)
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
                    {   // offset player when near the left boundary of the map
                        playerTileX = 0;
                    } else if (playerX > Width - Screen.HalfWidth)
                    {   // offset player when near the right boundary of the map
                        playerTileX = (Width - Screen.Width) / tileWidth;
                    } else
                    {
                        // position the player in the middle of the screen
                        playerTileX = (playerX - Screen.HalfWidth) / tileWidth;
                        offsetX = playerX % tileWidth;
                    }

                    // handle player Y coordinate
                    if (playerY < Screen.HalfHeight)
                    {   // offset player when near the top boundary of the map
                        playerTileY = 0;
                    }
                    else if (playerY > Height - Screen.HalfHeight)
                    {   // offset player when near the bottom boundary of the map
                        playerTileY = (Height - Screen.Height) / tileHeight;
                    }
                    else
                    {   // position the player in the middle of the screen
                        playerTileY = (playerY - Screen.HalfHeight) / tileHeight;
                        offsetY = (playerY + 16) % tileHeight;
                    }

                    // draw all tile layers
                    for (var layer = 0; layer < tiledMap.Layers.Count; layer++)
                    {
                        var tile = tiles[x + playerTileX, y + playerTileY, layer];

                        if (tile != null)
                        {
                            var drawRect = new Rectangle(x * tileWidth - offsetX, y * tileHeight - offsetY, tileWidth, tileHeight);

                            spriteBatch.Draw(tileset[tile.Tileset], drawRect, tile.SpriteRect, Color.White);
                        }
                    }
                }
        }
    }
}