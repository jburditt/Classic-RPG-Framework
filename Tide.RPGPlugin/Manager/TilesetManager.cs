using Player;
using Player.Manager;
using System.Collections.Generic;
using System.Drawing;
using TiledSharp;

namespace Editor.Manager
{
    public class TilesetManager : ITilesetManager
    {
        public Graphics Graphics { get; set; }

        private Dictionary<string, Bitmap> _tilesets = new Dictionary<string, Bitmap>();

        public TilesetManager(Graphics graphics, TmxList<TmxTileset> tilesets)
        {
            Graphics = graphics;
            foreach (var tileset in tilesets)
                _tilesets.Add(tileset.Name, (Bitmap)Image.FromFile(tileset.Image.Source));
        }

        public void Draw(string tilesetName, Rect targetRect, Rect sourceRect, ColorStruct? color = null)
        {
            Graphics.DrawImage(_tilesets[tilesetName], targetRect.ToRectangle(), sourceRect.ToRectangle(), GraphicsUnit.Pixel);
        }
    }
}