using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;
using Player;
using Editor.Manager;

namespace Editor
{
    public partial class editorForm : Form
    {
        private TilesetManager _tilesetManager;
        Map map;
        private Graphics _graphics;

        private int fileIndex = 0;
        private List<Image> filesImages = new List<Image>();
        private Bitmap _x = (Bitmap)Image.FromFile("../../x.png");
        private Bitmap _passable;
        private bool[][][] passable;

        public editorForm()
        {
            InitializeComponent();

            _x.MakeTransparent(Color.White);

            _graphics = Graphics.FromImage(new Bitmap(1024, 1024));
            _tilesetManager = new TilesetManager(_graphics);
            map = new Map(_tilesetManager, "../../../MonoGame/Content/world2.tmx");

            passable = new bool[map.tiledMap.Tilesets.Count][][];
            
            for (var i = 0; i < map.tiledMap.Tilesets.Count; i++)
            {
                filesListBox.Items.Add(map.tiledMap.Tilesets[i].Name);
                filesImages.Add(Image.FromFile(map.tiledMap.Tilesets[i].Image.Source));
                //passable[i] = new bool[tiledMap.Tilesets[i].Columns.Value][(tiledMap.Tilesets[i].TileCount ?? 0) / tiledMap.Tilesets[i].Columns.Value];
                passable[i] = new bool[map.tiledMap.Tilesets[i].Columns.Value][];

                for (var x = 0; x < map.tiledMap.Tilesets[i].Columns.Value; x++)
                {
                    passable[i][x] = new bool[(map.tiledMap.Tilesets[i].TileCount ?? 0) / map.tiledMap.Tilesets[i].Columns.Value];
                    for (var y = 0; y < (map.tiledMap.Tilesets[i].TileCount ?? 0)/ map.tiledMap.Tilesets[i].Columns.Value; y++)
                        passable[i][x][y] = true;
                }
            }

            filePictureBox.Image = filesImages[0];
            _passable = new Bitmap(filePictureBox.Image.Width, filePictureBox.Image.Height);
            _passable.MakeTransparent(Color.White);

            mapPictureBox.Image = new Bitmap(map.Width, map.Height);
            using (var g = Graphics.FromImage(mapPictureBox.Image))
            {
                _tilesetManager._graphics = g;
                map.Draw(0, 0);
            }
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
            Serializer.XmlSerialize(passable, "../../../Data/world2.passable.xml");
        }

        private void filesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fileIndex = filesListBox.SelectedIndex;
            Draw();
        }
    }
}
