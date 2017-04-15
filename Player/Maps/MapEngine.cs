using DataStore;
using Player.Events;
using Player.Manager;
using Player.Maps;

namespace Player
{
    public class MapEngine
    {
        private readonly EventService _eventService;
        private readonly IIconManager _iconManager;
        private readonly ITilesetManager _tilesetManager;
        private readonly IDataStore _dataStore;

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int Layers { get; set; }
        public string MapFilePath { get; set; }
        public string MapName { get; set; }

        public MapMeta MapMeta { get; set; }
        public TileSheetMeta TileSheetMeta { get; set; }

        public Vector Camera, Start;
        public int WindowColumns, WindowRows;

        public MapEngine(IDataStore dataStore, EventService eventService, IIconManager iconManager, ITilesetManager tilesetManager, string mapFilePath, string mapName)
        {
            _dataStore = dataStore;
            _eventService = eventService;
            _iconManager = iconManager;
            _tilesetManager = tilesetManager;

            MapFilePath = mapFilePath;
            MapName = mapName;

            Load(MapName);
        }

        public void Load(string mapName)
        {
            TileSheetMeta = _dataStore.Load<TileSheetMeta>($"{mapName}.TileSheetMeta");
            MapMeta = _dataStore.Load<MapMeta>($"{mapName}.MapMeta");

            //map.Tiles[x + 1][y - 1][0].EventCollection = _eventService.Find(eventId);


            TideReader.Load(_eventService, this, $"{MapFilePath}{mapName}.tide");

            //new TiledReader().Load(_eventService, this, $"{MapFilePath + mapName}.tmx");
        }

        public bool IsCollision(Vector pos, Direction direction)
        {
            var x = pos.X / TileWidth;
            var y = pos.Y / TileHeight;

            var isCollision = false;

            switch (direction)
            {
                case Direction.Up:
                    isCollision = IsTileCollision(pos.X, pos.Y, x, y) || (pos.X % TileWidth != 0 && IsTileCollision(pos.X, pos.Y, x + 1, y));
                    return isCollision;
                case Direction.Right:
                    isCollision = IsTileCollision(pos.X, pos.Y, x + 1, y) || (pos.X % TileHeight != 0 && IsTileCollision(pos.X, pos.Y, x + 1, y + 1));
                    return isCollision;
                case Direction.Down:
                    isCollision = IsTileCollision(pos.X, pos.Y, x, y + 1) || (pos.X % TileWidth != 0 && IsTileCollision(pos.X, pos.Y, x + 1, y + 1));
                    return isCollision;
                case Direction.Left:
                    isCollision = IsTileCollision(pos.X, pos.Y, x, y) || (pos.Y % TileHeight != 0 && IsTileCollision(pos.X, pos.Y, x, y + 1));
                    return isCollision;
            }

            return false;
        }

        public bool IsTileCollision(int playerX, int playerY, int x, int y)
        {
            // don't check tiles out of bounds
            if (OutBounds(x, y))
                return true;

            for (int layerIndex = 0; layerIndex < Layers; layerIndex++)
            {
                var tile = MapMeta.Layers[layerIndex].Tiles[x, y];

                if (tile != null && tile.IsBlocked)
                {
                    var playerRect = new Rect(playerX, playerY + 8, 24, 24);
                    var tileRect = new Rect(x * TileWidth, y * TileHeight, TileWidth, TileHeight);

                    if (playerRect.Intersects(tileRect))
                        return true;
                }
            }

            return false;
        }

        public void Draw(Vector pos)
        {
            for (var y = 0; y <= WindowRows; y++)
                for (var x = 0; x <= WindowColumns; x++)
                {
                    // don't draw extra tile if on the boundary
                    if (pos.Y >= Height - Screen.HalfHeight && y == WindowRows)
                        break;
                    if (pos.X >= Width - Screen.HalfWidth && x == WindowColumns)
                        continue;

                    int playerTileX, playerTileY;
                    int offsetX = 0, offsetY = 0;

                    // handle player X coordinate
                    if (pos.X < Screen.HalfWidth)
                    {
                        // offset player when near the left boundary of the map
                        playerTileX = 0;
                    }
                    else if (pos.X > Width - Screen.HalfWidth)
                    {
                        // offset player when near the right boundary of the map
                        playerTileX = (Width - Screen.Width) / TileWidth;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileX = (pos.X - Screen.HalfWidth) / TileWidth;
                        offsetX = pos.X % TileWidth;
                    }

                    // handle player Y coordinate
                    if (pos.Y < Screen.HalfHeight)
                    {
                        // offset player when near the top boundary of the map
                        playerTileY = 0;
                    }
                    else if (pos.Y > Height - Screen.HalfHeight)
                    {
                        // offset player when near the bottom boundary of the map
                        playerTileY = (Height - Screen.Height) / TileHeight;
                    }
                    else
                    {
                        // position the player in the middle of the screen
                        playerTileY = (pos.Y - Screen.HalfHeight) / TileHeight;
                        offsetY = (pos.Y + TileHeight / 2) % TileHeight;
                    }

                    // draw all tile layers
                    for (var layer = 0; layer < Layers; layer++)
                    {
                        var tile = MapMeta.Layers[layer].Tiles[x + playerTileX, y + playerTileY];

                        if (tile != null)
                        {
                            var drawRect = new Rect(x * TileWidth - offsetX, y * TileHeight - offsetY, TileWidth, TileHeight);

                            _tilesetManager.Draw(tile.Tileset, drawRect, tile.SpriteRect);

                            if (layer == 0)
                                DrawEventCollection(_eventService.Get(x + playerTileX, y + playerTileY), new Vector(x * TileWidth - offsetX, y * TileHeight - offsetY));
                        }
                    }
                }
        }

        public void DrawTile(int x, int y)
        {
            for (var layer = 0; layer < Layers; layer++)
            {
                var tile = MapMeta.Layers[layer].Tiles[x, y];

                if (tile != null)
                {
                    var drawRect = new Rect(x * TileWidth, y * TileHeight, TileWidth, TileHeight);

                    _tilesetManager.Draw(tile.Tileset, drawRect, tile.SpriteRect);
                }
            }
        }

        // TODO IsTriggered is calculated every screen update when in view. Could be optimized by adding listeners instead.
        public void DrawEventCollection(EventCollection n, Vector pos)
        {
            if (n == null)
                return;

            foreach (var e in n)
            {
                foreach (var eventPage in e.EventPages)
                {
                    if (eventPage.TriggerCollection == null || eventPage.TriggerCollection.IsTriggered(eventPage))
                        DrawEvent(eventPage, pos);
                }
            }
        }

        public void DrawEvent(EventPage eventPage, Vector pos)
        {
            if (string.IsNullOrEmpty(eventPage.ImageKey))
                return;

            switch (eventPage.ImageType)
            {
                case ImageType.Icon:
                    _iconManager.Draw(eventPage.ImageKey, eventPage.TilesetSource, new Rect(pos.X, pos.Y, eventPage.TilesetSource.Width, eventPage.TilesetSource.Height));
                    break;
                //case ImageType.Tileset:
                //    _tilesetManager.Draw(eventPage.ImageKey, )
            }
        }

        public void DrawWorld()
        {
            for (var x = 0; x < Columns; x++)
                for (var y = 0; y < Rows; y++)
                    DrawTile(x, y);
        }

        public VectorF Transform(VectorF p)
        {
            float x = Screen.HalfWidth;
            if (p.X < Screen.HalfWidth) x = p.X;
            if (p.X > Width - Screen.HalfWidth)
                x = p.X - Width + Screen.Width;

            float y = Screen.HalfHeight;
            if (p.Y < Screen.HalfHeight) y = p.Y;
            if (p.Y > Height - Screen.HalfHeight)
                y = p.Y - Height + Screen.Height;

            return new VectorF(x, y);
        }

        public void UpdateCamera(Vector pos)
        {
            if (pos.X < Screen.HalfWidth)
                Camera.X = 0;
            else if (pos.X > Width - Screen.HalfWidth)
                Camera.X = Width - Screen.Width;
            else
                Camera.X = pos.X - Screen.HalfWidth;

            if (pos.Y < Screen.HalfHeight)
                Camera.Y = 0;
            else if (pos.Y > Height - Screen.HalfHeight)
                Camera.Y = Height - Screen.Height;
            else
                Camera.Y = pos.Y - Screen.HalfHeight;
        }

        public bool OutBounds(int x, int y)
        {
            return x < 0 || x >= Columns || y < 0 || y >= Rows;
        }
    }
}