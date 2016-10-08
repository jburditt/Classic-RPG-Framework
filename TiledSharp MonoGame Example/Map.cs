using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace TiledSharp_MonoGame_Example
{
    public class Map
    {
        TmxMap map;
        Texture2D tileset;

        int tileWidth, tileHeight;
        int tilesetTilesWide, tilesetTilesHigh;
        int windowTilesWide, windowTilesHigh;

        public int Width { get { return map.Width; } }
        public int Height { get { return map.Height; } }

        public Map(ContentManager Content, GameWindow Window)
        {
            map = new TmxMap("Content/world.tmx");
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;

            windowTilesWide = Window.ClientBounds.Width / tileWidth;
            windowTilesHigh = Window.ClientBounds.Height / tileHeight;
        }

        public void Draw(SpriteBatch spriteBatch, int playerX, int playerY)
        {
            for (var y = 0; y <= windowTilesHigh + 1; y++)
                for (var x = 0; x <= windowTilesWide + 1; x++)
                {
                    int playerTileX = playerX / tileWidth;
                    int playerTileY = playerY / tileHeight;

                    int i = x + playerTileX + (y + playerTileY) * map.Width;

                    int gid = map.Layers[0].Tiles[i].Gid;
                    if (gid == 0)
                        continue;

                    int offsetX = playerX % tileWidth;
                    int offsetY = playerY % tileHeight;

                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (tileFrame) / tilesetTilesWide;

                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                    spriteBatch.Draw(tileset, new Rectangle(x * tileWidth - offsetX, y * tileHeight - offsetY, tileWidth, tileHeight), tilesetRec, Color.White);
                }
        }
    }
}