using Player.Events;
using xTile;

namespace Player.Maps
{
    public class TideReader
    {
        public void Load(EventService eventService, Map map, string mapFilePath)
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
            map.Layers = TiledMap.Layers.Count;

            //var tilesets = TiledMap.Tilesets;

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
            LoadObjects(eventService, TiledMap, map);
        }

        private void LoadTiles(TideMap TiledMap, Map map)
        {
            map.Tiles = new Tile[map.Rows][][];

            for (var x = 0; x < map.Rows; x++)
            {
                map.Tiles[x] = new Tile[map.Columns][];

                for (var y = 0; y < map.Columns; y++)
                {
                    map.Tiles[x][y] = new Tile[TiledMap.Layers.Count];

                    for (var layer = 0; layer < TiledMap.Layers.Count; layer++)
                    {
                        //int tileIndex = x + y * map.Rows;

                        int gid = TiledMap.Layers[layer].Tiles[x, y].TileIndex;
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
                        
                        map.Tiles[x][y][layer] = new Tile
                        {
                            SpriteRect = new Rect(tileWidth * column, tileHeight * row, tileWidth, tileHeight),
                            Tileset = TiledMap.Layers[layer].Tiles[x, y].TileSheet.Id,
                            IsPassable = map.Passable == null ? true : map.Passable[tilesetIndex][column][row]
                        };
                    }
                }
            }
        }

        public void LoadObjects(EventService _eventService, TideMap TiledMap, Map map)
        {
            if (_eventService == null)
                return;

            //foreach (var objLayer in TiledMap.ObjectGroups)
            //{
            //    foreach (var obj in objLayer.Objects)
            //    {
            //        var x = (int)obj.X / map.TileWidth;
            //        var y = (int)obj.Y / map.TileWidth;

            //        if (obj.Properties.ContainsKey("Start"))
            //        {
            //            map.Start = new Vector((int)obj.X, (int)obj.Y);
            //        }
            //        else if (obj.Properties.ContainsKey("EventId"))
            //        {
            //            // compensate for bug in Tiled (+1, -1)
            //            map.Tiles[x + 1][y - 1][0].EventCollection = _eventService.Find(obj.Properties["EventId"].ToInt());
            //        }
            //    }
            //}
        }
    }
}
