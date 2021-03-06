﻿using Player.Events;
using xTile;

namespace Player.Maps
{
    public class TideReader
    {
        public static void Load(IEventService eventService, MapEngine map, string mapFilePath)
        {
            var TiledMap = MapLoader.LoadMap(mapFilePath);

            map.TileWidth = TiledMap.Layers[0].TileWidth;                 // width of tile in pixels
            map.TileHeight = TiledMap.Layers[0].TileHeight;               // height of tile

            map.WindowColumns = Screen.Width / map.TileWidth;               // number of columns in window
            map.WindowRows = Screen.Height / map.TileHeight;                // number of rows in window

            map.Width = TiledMap.DisplayWidth;                      // width of map in pixels
            map.Height = TiledMap.DisplayHeight;                   // height of map

            map.Columns = TiledMap.Layers[0].LayerWidth;
            map.Rows = TiledMap.Layers[0].LayerHeight;

            var tilesets = TiledMap.TileSheets;

            // TODO
            // Leaving this here for now
            // At some point we will probably want to load only the textures we need (below) instead of all (current)

            //string[] tilesetNames;
            //if (isMonoGame)
            //    tilesetNames = tilesets.Select(n => n.Image.Source).ToList().ToFileList().Select(n => n.Name).ToArray();
            //else
            //    tilesetNames = tilesets.Select(n => n.Image.Source).ToArray();
            //_tilesetManager.Load(tilesetNames);

            LoadTiles(TiledMap, map);
        }

        private static void LoadTiles(Map TiledMap, MapEngine map)
        {
            if (map.MapMeta == null)
                map.MapMeta = new MapMeta();

            // add layers
            map.Layers = new LayerMeta[TiledMap.Layers.Count];

            for (var i = 0; i < map.Layers.Length; i++)
                map.Layers[i] = new LayerMeta(TiledMap.Layers[i]);

            // load layers
            for (var z = 0; z < TiledMap.Layers.Count; z++)
            for (var x = 0; x < map.Columns; x++)
            {
                for (var y = 0; y < map.Rows; y++)
                {
                    for (var layer = 0; layer < TiledMap.Layers.Count; layer++)
                    {
                        int gid = TiledMap.Layers[layer].Tiles[x, y]?.TileIndex ?? 0;
                        if (gid == 0)
                            continue;

                        int tilesetIndex = 0;
                        int tileCount = 0;
                        int row = 0, column = 0;

                        // get tilesetIndex and position in tileset from gid
                        for (var i = 0; i < TiledMap.TileSheets.Count; i++)
                        {
                            if (gid < TiledMap.TileSheets[i].TileCount + tileCount)
                            {
                                tilesetIndex = i;
                                int tileFrame = gid - tileCount;
                                int columns = TiledMap.TileSheets[i].SheetWidth;
                                column = tileFrame % columns;
                                row = (tileFrame) / columns;
                                break;
                            }

                            // make sure we tally the tile count, so we know what to subtract from gid
                            tileCount += TiledMap.TileSheets[i].TileCount;
                        }

                        var tileWidth = TiledMap.Layers[layer].TileWidth;
                        var tileHeight = TiledMap.Layers[layer].TileHeight;

                        map.Layers[layer].Tiles[x, y] = new TileMeta
                        {
                            SpriteRect = new Rect(tileWidth * column, tileHeight * row, tileWidth, tileHeight),
                            Tileset = TiledMap.Layers[layer].Tiles[x, y].TileSheet.Id,
                            IsBlocked = map.TileSheetMeta == null ? false : map.TileSheetMeta.Tiles[column, row].IsBlocked,
                        };
                    }
                }
            }
        }
    }
}