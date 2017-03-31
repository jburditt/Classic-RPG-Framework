using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Player;
using Editor.Manager;
using DataStore;

namespace Editor
{
    public partial class EditorForm : Form
    {
        private readonly TilesetManager _tilesetManager;
        private readonly Map _map;
        private readonly Graphics _graphics;
        private readonly XmlDataStore _dataStore;

        private int fileIndex = 0;
        private List<Image> filesImages = new List<Image>();
        private Bitmap _x = (Bitmap)Image.FromFile("../../x.png");
        private Bitmap _passable;
        private bool[][][] passable;

        public EditorForm()
        {
            InitializeComponent();

            _x.MakeTransparent(Color.White);
            _graphics = Graphics.FromImage(new Bitmap(1024, 1024));
            _tilesetManager = new TilesetManager(_graphics);
            _dataStore = new XmlDataStore();
            _map = new Map(_dataStore, _tilesetManager, "../../../MonoGame/Content/world2.tmx");

            // TODO Remove this
            passable = LoadPassable("world2.passable");

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

        private bool[][][] LoadPassable(string mapName)
        {
            //var temp = _dataStore.Load<bool[][][]>(mapName);

            //if (temp == null)
            //{
                var temp = new bool[_map.tiledMap.Tilesets.Count][][];

                for (var i = 0; i < _map.tiledMap.Tilesets.Count; i++)
                {
                    filesListBox.Items.Add(_map.tiledMap.Tilesets[i].Name);
                    filesImages.Add(Image.FromFile(_map.tiledMap.Tilesets[i].Image.Source));
                    passable[i] = new bool[_map.tiledMap.Tilesets[i].Columns.Value][];

                    for (var x = 0; x < _map.tiledMap.Tilesets[i].Columns.Value; x++)
                    {
                        passable[i][x] = new bool[(_map.tiledMap.Tilesets[i].TileCount ?? 0) / _map.tiledMap.Tilesets[i].Columns.Value];
                        for (var y = 0; y < (_map.tiledMap.Tilesets[i].TileCount ?? 0) / _map.tiledMap.Tilesets[i].Columns.Value; y++)
                            passable[i][x][y] = true;
                    }
                }
            //}

            return temp;
        }

        private void filePictureBox_Click(object sender, System.EventArgs e)
        {
            var me = (MouseEventArgs)e;
            var coordinates = me.Location;

            var x = coordinates.X/32;
            var y = coordinates.Y/32;
            passable[fileIndex][x][y] = !passable[fileIndex][x][y];

            debugLabel.Text = "X: " + x + " Y: " + y + "P: " + passable[fileIndex][x][y];

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
                        if (!passable[fileIndex][i][j])
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

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            _dataStore.Save(passable, "world2.passable");
        }

        private void filesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fileIndex = filesListBox.SelectedIndex;
            Draw();
        }
    }
}
