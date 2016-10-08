using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace TiledSharp_MonoGame_Example_2
{
    public class Map
    {
        TmxMap map;
        Texture2D tileset;
        TmxList<TmxObject> objects;

        int tileWidth, tileHeight;
        int tilesetTilesWide, tilesetTilesHigh;
        int windowTilesWide, windowTilesHigh;

        public static int Width;
        public static int Height;

        public Map(ContentManager Content, GameWindow Window)
        {
            map = new TmxMap("Content/world.tmx");
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
            objects = map.ObjectGroups[0].Objects;

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;

            windowTilesWide = Screen.Width / tileWidth;
            windowTilesHigh = Screen.Height / tileHeight;

            Width = map.Width * tileWidth;
            Height = map.Height * tileHeight;
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

                    if (playerX < Screen.HalfWidth)
                    {
                        playerTileX = 0;
                    } else if (playerX > Width - Screen.HalfWidth)
                    {
                        playerTileX = (Width - Screen.Width) / tileWidth;
                    } else
                    {
                        playerTileX = (playerX - Screen.HalfWidth) / tileWidth;
                        offsetX = playerX % tileWidth;
                    }

                    if (playerY < Screen.HalfHeight)
                    {
                        playerTileY = 0;
                    }
                    else if (playerY > Height - Screen.HalfHeight)
                    {
                        playerTileY = (Height - Screen.Height) / tileHeight;
                    }
                    else
                    {
                        playerTileY = (playerY - Screen.HalfHeight) / tileHeight;
                        offsetY = (playerY + 16) % tileHeight;
                    }

                    int i = x + playerTileX + (y + playerTileY) * map.Width;

                    for (int z = 0; z < map.Layers.Count; z++)
                    {
                        int gid = map.Layers[z].Tiles[i].Gid;
                        if (gid == 0)
                            continue;

                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (tileFrame) / tilesetTilesWide;

                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                        spriteBatch.Draw(tileset, new Rectangle(x * tileWidth - offsetX, y * tileHeight - offsetY, tileWidth, tileHeight), tilesetRec, Color.White);
                    }
                }
        }
    }
}