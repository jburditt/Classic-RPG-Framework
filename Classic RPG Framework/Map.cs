using System;
using System.IO;
using System.Xml.Serialization;
using Common;
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
        int mapTilesWide, mapTilesHigh;
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

            mapTilesWide = tileset[0].Width / tileWidth;       // number of columns in tileset
            mapTilesHigh = tileset[0].Height / tileHeight;     // number of rows in tileset

            windowTilesWide = Screen.Width / tileWidth;         // number of columns in window
            windowTilesHigh = Screen.Height / tileHeight;       // number of rows in window

            Width = tiledMap.Width * tileWidth;                      // width of map in pixels
            Height = tiledMap.Height * tileHeight;                   // height of map

            tiles = LoadFromTiledMap(tiledMap);
        }

        private Tile[,,] LoadFromTiledMap(TmxMap tmxMap)
        {
            tiles = new Tile[tmxMap.Width, tmxMap.Height, tmxMap.Layers.Count];

            var serializer = new XmlSerializer(typeof(bool[][][]));
            var reader = new StreamReader("../../../../Data/world2.passable.xml");
            var passable = (bool[][][])serializer.Deserialize(reader);

            for (var x = 0; x < tmxMap.Width; x++)
                for (var y = 0; y < tmxMap.Height; y++)
                    for (var layer = 0; layer < tmxMap.Layers.Count; layer++)
                    {
                        int tileIndex = x + y * tmxMap.Width;

                        int gid = tmxMap.Layers[layer].Tiles[tileIndex].Gid;
                        if (gid == 0)
                            continue;

                        int tilesetIndex = 0;
                        int tileCount = 0;
                        int row = 0, column = 0;

                        // get tilesetIndex and position in tileset from gid
                        for (var i = 0; i < tmxMap.Tilesets.Count; i++)
                        {
                            if (gid < tmxMap.Tilesets[i].TileCount + tileCount)
                            {
                                tilesetIndex = i;
                                int tileFrame = gid - tileCount - 1;
                                int columns = tmxMap.Tilesets[i].Columns ?? 1;
                                column = tileFrame % columns;
                                row = (tileFrame) / columns;
                                break;
                            }

                            // make sure we tally the tile count, so we know what to subtract from gid
                            tileCount += tmxMap.Tilesets[i].TileCount ?? 0;
                        }

                        tiles[x, y, layer] = new Tile
                        {
                            SpriteRect = new Rectangle(tileWidth*column, tileHeight*row, tileWidth, tileHeight),
                            Tileset = tilesetIndex,
                            IsPassable = passable[tilesetIndex][column][row]
                        };
                    }

            return tiles;
        }

        // TODO Optimize by adding direction
        public bool IsCollision(int playerX, int playerY, Direction direction)
        {
            var x = playerX / tileWidth;
            var y = playerY / tileHeight;

            var isCollision = false;
            
            switch (direction)
            {
                case Direction.Up:
                    isCollision = IsTileCollision(playerX, playerY, x, y) || (playerX % tileWidth != 0 && IsTileCollision(playerX, playerY, x + 1, y));
                    return isCollision;
                case Direction.Right:
                    isCollision = IsTileCollision(playerX, playerY, x + 1, y) || (playerY % tileHeight != 0 && IsTileCollision(playerX, playerY, x + 1, y + 1));
                    return isCollision;
                case Direction.Down:
                    isCollision = IsTileCollision(playerX, playerY, x, y + 1) || (playerX % tileWidth != 0 && IsTileCollision(playerX, playerY, x + 1, y + 1));
                    return isCollision;
                case Direction.Left:
                    isCollision = IsTileCollision(playerX, playerY, x, y) || (playerY % tileHeight != 0 && IsTileCollision(playerX, playerY, x, y + 1));
                    return isCollision;
            }

            return false;
        }

        public bool IsTileCollision(int playerX, int playerY, int x, int y)
        {
            // don't check tiles out of bounds
            if (x < 0 || x > mapTilesWide || y < 0 || y > mapTilesHigh)
                return true;

            for (int layerIndex = 0; layerIndex < tiledMap.Layers.Count; layerIndex++)
            {
                var tile = tiles[x, y, layerIndex];

                if (tile != null && !tile.IsPassable)
                {
                    var playerRect = new Rectangle(playerX, playerY + 8, 24, 24);
                    var tileRect = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);

                    if (playerRect.Intersects(tileRect))
                        return true;
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
                    {
                        // offset player when near the left boundary of the map
                        playerTileX = 0;
                    }
                    else if (playerX > Width - Screen.HalfWidth)
                    {
                        // offset player when near the right boundary of the map
                        playerTileX = (Width - Screen.Width)/tileWidth;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileX = (playerX - Screen.HalfWidth)/tileWidth;
                        offsetX = playerX%tileWidth;
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
                        playerTileY = (Height - Screen.Height)/tileHeight;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileY = (playerY - Screen.HalfHeight)/tileHeight;
                        offsetY = (playerY + 16)%tileHeight;
                    }

                    // draw all tile layers
                    for (var layer = 0; layer < tiledMap.Layers.Count; layer++)
                    {
                        var tile = tiles[x + playerTileX, y + playerTileY, layer];

                        if (tile != null)
                        {
                            var drawRect = new Rectangle(x*tileWidth - offsetX, y*tileHeight - offsetY, tileWidth, tileHeight);

                            spriteBatch.Draw(tileset[tile.Tileset], drawRect, tile.SpriteRect, Color.White);
                        }
                    }
                }
        }
    }
}