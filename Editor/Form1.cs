using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TiledSharp;

namespace Editor
{
    public partial class editorForm : Form
    {
        private TmxMap tiledMap;
        private int fileIndex = 0;
        private List<Image> filesImages = new List<Image>();
        private Bitmap _x = (Bitmap)Image.FromFile("../../x.png");
        private Bitmap _passable;
        private bool[][,] passable;

        public editorForm()
        {
            InitializeComponent();

            _x.MakeTransparent(Color.White);

            tiledMap = new TmxMap("../../../Classic RPG Framework/Content/world2.tmx");
            passable = new bool[tiledMap.Tilesets.Count][,];
            
            for (var i = 0; i < tiledMap.Tilesets.Count; i++)
            {
                filesListBox.Items.Add(tiledMap.Tilesets[i].Name);
                filesImages.Add(Image.FromFile(tiledMap.Tilesets[i].Image.Source));
                passable[i] = new bool[tiledMap.Tilesets[i].Columns.Value, (tiledMap.Tilesets[i].TileCount ?? 0) / tiledMap.Tilesets[i].Columns.Value];
                for (var x = 0; x < passable[i].GetLength(0); x++)
                    for (var y = 0; y < passable[i].GetLength(1); y++)
                        passable[i][x, y] = true;
            }

            filePictureBox.Image = filesImages[0];
            _passable = new Bitmap(filePictureBox.Image.Width, filePictureBox.Image.Height);
            _passable.MakeTransparent(Color.White);
        }

        private void filePictureBox_Click(object sender, System.EventArgs e)
        {
            var me = (MouseEventArgs)e;
            var coordinates = me.Location;

            var x = coordinates.X/32;
            var y = coordinates.Y/32;
            passable[fileIndex][x, y] = !passable[fileIndex][x, y];

            debugLabel.Text = "X: " + x + " Y: " + y + "P: " + passable[fileIndex][x, y];

            Draw();
        }

        private void Draw()
        {
            var overlay = new Bitmap(filePictureBox.Image.Width, filePictureBox.Image.Height);
            overlay.MakeTransparent(Color.White);

            var bitmap = new Bitmap(overlay);
            using (var g = Graphics.FromImage(bitmap))
            {
                for (var i = 0; i < passable[fileIndex].GetLength(0); i++)
                    for (var j = 0; j < passable[fileIndex].GetLength(1); j++)
                        if (!passable[fileIndex][i, j])
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
            
        }

        private void filesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fileIndex = filesListBox.SelectedIndex;
            Draw();
        }
    }
}
