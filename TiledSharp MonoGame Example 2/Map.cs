using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace TiledSharp_MonoGame_Example_2
{
    public class Map
    {
        TmxMap map;
        Texture2D[] tileset;

        int tileWidth, tileHeight;
        int tilesetTilesWide, tilesetTilesHigh;
        int windowTilesWide, windowTilesHigh;

        public static int Width;
        public static int Height;

        public Map(ContentManager Content, GameWindow Window)
        {
            map = new TmxMap("Content/world2.tmx");

            tileset = new Texture2D[map.Tilesets.Count];
            for (var i = 0; i < map.Tilesets.Count; i++) 
                tileset[i] = Content.Load<Texture2D>(map.Tilesets[i].Name);

            // TODO
            tileWidth = map.Tilesets[0].TileWidth;              // width of tile in pixels
            tileHeight = map.Tilesets[0].TileHeight;            // height of tile

            tilesetTilesWide = tileset[0].Width / tileWidth;       // number of columns in tileset
            tilesetTilesHigh = tileset[0].Height / tileHeight;     // number of rows in tileset

            windowTilesWide = Screen.Width / tileWidth;         // number of columns in window
            windowTilesHigh = Screen.Height / tileHeight;       // number of rows in window

            Width = map.Width * tileWidth;                      // width of map in pixels
            Height = map.Height * tileHeight;                   // height of map
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
                    var tileIndex = x / tileWidth + i + (y / tileHeight + j) * map.Width;

                    for (int layerIndex = 0; layerIndex < map.Layers.Count; layerIndex++)
                    {
                        var tileId = map.Layers[layerIndex].Tiles[tileIndex].Gid - 1;

                        foreach (var tile in map.Tilesets[0].Tiles)
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

                    // calculate tile index
                    int tileIndex = x + playerTileX + (y + playerTileY) * map.Width;

                    // draw all tile layers
                    for (int z = 0; z < map.Layers.Count; z++)
                    {
                        var tile = map.Layers[z].Tiles[tileIndex];

                        int gid = tile.Gid;
                        if (gid == 0)
                            continue;

                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (tileFrame) / tilesetTilesWide;

                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);
                        
                        spriteBatch.Draw(tileset[0], new Rectangle(x * tileWidth - offsetX, y * tileHeight - offsetY, tileWidth, tileHeight), tilesetRec, Color.White);
                    }
                }
        }
    }
}