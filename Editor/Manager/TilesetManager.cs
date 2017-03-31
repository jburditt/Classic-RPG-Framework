using Player;
using Player.Manager;
using System.Drawing;

namespace Editor.Manager
{
    public class TilesetManager : ITilesetManager
    {
        private Graphics _graphics;
        private Bitmap[] tileset;    // make this a dictionary

        public TilesetManager(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void Load(string[] tilesets)
        {
            tileset = new Bitmap[tilesets.Length];

            for (var i = 0; i < tilesets.Length; i++)
                tileset[i] = (Bitmap)Image.FromFile(tilesets[i]);
        }

        public void Draw(int i, Rect targetRect, Rect sourceRect, ColorStruct? color = null)
        {
            _graphics.DrawImage(tileset[i], targetRect.ToRectangle(), sourceRect.ToRectangle(), GraphicsUnit.Pixel);
        }
    }
}