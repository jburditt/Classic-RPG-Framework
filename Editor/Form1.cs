using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TiledSharp;

namespace Editor
{
    public partial class editorForm : Form
    {
        private TmxMap tiledMap;
        private List<Image> filesImages = new List<Image>();
        private Bitmap _x = (Bitmap)Image.FromFile("../../x.png");
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
            }

            filePictureBox.Image = filesImages[0];
        }

        private void filePictureBox_Click(object sender, System.EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            int x = coordinates.X/32;
            int y = coordinates.Y/32;

            debugLabel.Text = "X: " + x + " Y: " + y;

            // toggle passable
            if (passable[0][x, y] = !passable[0][x, y])
                DrawX(x, y);
        }

        private void DrawX(int x, int y)
        {
            var bitmap = new Bitmap(filePictureBox.Image);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(_x, new Point(x*32, y*32));
            }
            filePictureBox.Image = bitmap;
        }
    }
}
