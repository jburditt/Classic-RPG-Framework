using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.IO;
using System.Xml.Serialization;
using TiledSharp;

namespace MonoGame.Manager
{
    public class TilesetManager : ITilesetManager
    {
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int Layers { get; set; }

        private readonly ContentManager _content;
        private readonly SpriteBatch _spriteBatch;
        private Texture2D[] tileset;    // make this a dictionary
        private TmxMap tiledMap;

        public TilesetManager(ContentManager content, SpriteBatch spriteBatch, string map)
        {
            _content = content;
            _spriteBatch = spriteBatch;

            tiledMap = new TmxMap(map);

            TileWidth = tiledMap.Tilesets[0].TileWidth;              // width of tile in pixels
            TileHeight = tiledMap.Tilesets[0].TileHeight;            // height of tile

            Width = tiledMap.Width * TileWidth;                      // width of map in pixels
            Height = tiledMap.Height * TileHeight;                   // height of map

            Columns = tiledMap.Width;
            Rows = tiledMap.Height;
            Layers = tiledMap.Layers.Count;

            var tilesets = tiledMap.Tilesets;

            tileset = new Texture2D[tilesets.Count];
            for (var i = 0; i < tilesets.Count; i++)
                tileset[i] = _content.Load<Texture2D>(tilesets[i].Name);
        }

        public Tile[,,] LoadFromTiledMap()
        {
            var tiles = new Tile[tiledMap.Width, tiledMap.Height, tiledMap.Layers.Count];

            var serializer = new XmlSerializer(typeof(bool[][][]));
            var reader = new StreamReader("../../../../Data/world2.passable.xml");
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

        public void Draw(int i, Rect targetRect, Rect sourceRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(tileset[i], targetRect.ToRectangle(), sourceRect.ToRectangle(), color.ToColor());
        }
    }
}
