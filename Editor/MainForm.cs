using DataStore;
using Editor.Manager;
using Player;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Editor
{
    public partial class MainForm : Form
    {
        private readonly TilesetManager _tilesetManager;
        private readonly Map _map;
        private readonly Graphics _graphics;
        private readonly XmlDataStore _dataStore;

        private int fileIndex = 0;
        private List<Image> filesImages = new List<Image>();
        private Bitmap _x = (Bitmap)Image.FromFile("../../x.png");
        private Bitmap _passable;

        private int mouseOldX, mouseOldY;

        public MainForm()
        {
            InitializeComponent();

            _x.MakeTransparent(Color.White);
            _graphics = Graphics.FromImage(new Bitmap(1024, 1024));
            _tilesetManager = new TilesetManager(_graphics);
            _dataStore = new XmlDataStore();

            _map = new Map(_dataStore, _tilesetManager, "../../../MonoGame/Content/world2.tmx");
            _map.Passable = LoadPassable();

            filePictureBox.Image = filesImages[0];
            _passable = new Bitmap(filePictureBox.Image.Width, filePictureBox.Image.Height);
            _passable.MakeTransparent(Color.White);

            mapPictureBox.Image = new Bitmap(_map.Width, _map.Height);
            using (var g = Graphics.FromImage(mapPictureBox.Image))
            {
                _tilesetManager.Graphics = g;
                _map.DrawWorld();
            }
        }

        private bool[][][] LoadPassable()
        {
            var isLoaded = _map.Passable != null;

            if (!isLoaded)
                _map.Passable = new bool[_map.TiledMap.Tilesets.Count][][];

            for (var i = 0; i < _map.TiledMap.Tilesets.Count; i++)
            {
                filesListBox.Items.Add(_map.TiledMap.Tilesets[i].Name);
                filesImages.Add(Image.FromFile(_map.TiledMap.Tilesets[i].Image.Source));

                if (!isLoaded) {
                    _map.Passable[i] = new bool[_map.TiledMap.Tilesets[i].Columns.Value][];

                    for (var x = 0; x < _map.TiledMap.Tilesets[i].Columns.Value; x++)
                    {
                        _map.Passable[i][x] = new bool[(_map.TiledMap.Tilesets[i].TileCount ?? 0) / _map.TiledMap.Tilesets[i].Columns.Value];
                            for (var y = 0; y < (_map.TiledMap.Tilesets[i].TileCount ?? 0) / _map.TiledMap.Tilesets[i].Columns.Value; y++)
                            _map.Passable[i][x][y] = true;
                    }
                }
            }

            return _map.Passable;
        }

        private void filePictureBox_Click(object sender, System.EventArgs e)
        {
            var me = (MouseEventArgs)e;
            var coordinates = me.Location;

            var x = coordinates.X/32;
            var y = coordinates.Y/32;
            _map.Passable[fileIndex][x][y] = !_map.Passable[fileIndex][x][y];

            //debugLabel.Text = "X: " + x + " Y: " + y + "P: " + _map.Passable[fileIndex][x][y];

            Draw();
        }

        private void Draw()
        {
            var overlay = new Bitmap(filePictureBox.Image.Width, filePictureBox.Image.Height);
            overlay.MakeTransparent(Color.White);

            var bitmap = new Bitmap(overlay);
            using (var g = Graphics.FromImage(bitmap))
            {
                for (var i = 0; i < filesImages[fileIndex].Width / 32; i++)
                    for (var j = 0; j < filesImages[fileIndex].Height / 32; j++)
                        if (!_map.Passable[fileIndex][i][j])
                            g.DrawImage(_x, i * 32, j * 32);
            }
            _passable = bitmap;

            bitmap = new Bitmap(filesImages[fileIndex]);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(filesImages[fileIndex], 0, 0);
                g.DrawImage(_passable, 0, 0);
            }
            filePictureBox.Image = bitmap;
        }

        private void DrawTile(int x, int y)
        {
            using (var g = Graphics.FromImage(mapPictureBox.Image))
            {
                _tilesetManager.Graphics = g;
                _map.DrawTile(x, y);
            }
        }

        private void DrawCursor(int x, int y)
        {
            var bitmap = mapPictureBox.Image;

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Color.White, 1), x * _map.TileWidth + 1, y * _map.TileHeight, _map.TileWidth - 2, _map.TileHeight - 2);
            }

            mapPictureBox.Image = bitmap;
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            _dataStore.Save(_map.Passable, "world2.passable");
        }

        private void filesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fileIndex = filesListBox.SelectedIndex;
            Draw();
        }

        private void mapPictureBox_Click(object sender, System.EventArgs e)
        {
            using (var form = new EventForm())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _map.Tiles[mouseOldX, mouseOldY, 0].NPC = form.Selected;

                    // load image
                }
            }
        }

        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            var x = e.X / _map.TileWidth;
            var y = e.Y / _map.TileHeight;

            // mouse moved to different tile
            if (x != mouseOldX || y != mouseOldY)
            {
                // cleanup old cursor
                DrawTile(mouseOldX, mouseOldY);
                DrawCursor(x, y);
            }

            mouseOldX = x;
            mouseOldY = y;
        }
    }
}
