using DataStore;
using Player;
using Player.Maps;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using xTile;

namespace RPGPlugin
{
    public partial class TileSheetForm : Form
    {
        private readonly IDataStore m_dataStore;

        private TileSheetMeta m_tileSheetMeta;
        private Map m_map;
        private Bitmap m_bitmapImageSource;
        private string m_imageSourceErrorMessge;
        private TileCursor m_cursor;
        private Vector m_oldPos;
        private int m_tileWidth, m_tileHeight;
        private Bitmap m_x = (Bitmap)Image.FromFile("../../../Tide.RPGPlugin/Resources/x.png");

        public TileSheetForm(IDataStore dataStore, Map map)
        {
            InitializeComponent();

            m_dataStore = dataStore;
            m_map = map;

            foreach (var tileSheet in m_map.TileSheets)
                tilesetsListBox.Items.Add(tileSheet);

            m_bitmapImageSource = null;
            m_imageSourceErrorMessge = null;
            m_x.MakeTransparent(Color.White);

            if (m_map.TileSheets?.Count == 0)
                return;

            m_tileSheetMeta = m_dataStore.Load<TileSheetMeta>($"{m_map.Id}.TileSheetMeta");

            m_tileWidth = m_map.TileSheets[0].TileWidth;
            m_tileHeight = m_map.TileSheets[0].TileHeight;

            m_cursor = new TileCursor
            {
                Size = new Size(m_tileWidth, m_tileHeight)
            };

            if (m_tileSheetMeta == null)
                LoadTileSheetMeta(0);

            try
            {
                m_bitmapImageSource = new Bitmap(m_map.TileSheets[0].ImageSource);
            }
            catch (Exception exception)
            {
                m_bitmapImageSource = null;
                m_imageSourceErrorMessge = exception.Message;
            }
        }

        //private Bitmap LoadUnlockedBitmap(string filename)
        //{
        //    Bitmap unlockedBitmap = null;

        //    using (Bitmap lockedBitmap = new Bitmap(filename))
        //    {
        //        unlockedBitmap = new Bitmap(lockedBitmap.Width, lockedBitmap.Height, lockedBitmap.PixelFormat);
        //        unlockedBitmap.SetResolution(lockedBitmap.HorizontalResolution, lockedBitmap.VerticalResolution);
        //        using (Graphics graphics = Graphics.FromImage(unlockedBitmap))
        //        {
        //            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        //            graphics.DrawImageUnscaled(lockedBitmap, 0, 0);
        //        }
        //    }

        //    return unlockedBitmap;
        //}

        private void panel_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            var graphics = paintEventArgs.Graphics;

            if (m_bitmapImageSource == null && m_imageSourceErrorMessge == null)
            {
                //graphics.DrawString("No image source selected", this.Font, SystemBrushes.ControlText, 0.0f, 0.0f);
                return;
            }
            else if (m_bitmapImageSource == null)
            {
                //graphics.DrawString("Error loading image source:" + m_imageSourceErrorMessge, this.Font, SystemBrushes.ControlText, 0.0f, 0.0f);
            }
            else
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;

                //graphics.ScaleTransform(m_trackBarZoom.Value, m_trackBarZoom.Value);
                //graphics.TranslateTransform(-m_previewOffset.X, -m_previewOffset.Y);

                int imageWidth = m_bitmapImageSource.Width;
                int imageHeight = m_bitmapImageSource.Height;

                graphics.DrawImage(m_bitmapImageSource, 0, 0, imageWidth, imageHeight);

                // draw blocked tiles
                for (var x = 0; x < m_tileSheetMeta.Tiles.GetLength(0); x++)
                    for (var y = 0; y < m_tileSheetMeta.Tiles.GetLength(1); y++)
                        if (m_tileSheetMeta.Tiles[x, y].IsBlocked)
                            graphics.DrawImage(m_x, x * m_tileWidth, y * m_tileHeight, m_tileWidth, m_tileHeight);

                m_cursor.Draw(graphics);
            }
        }

        private void LoadTileSheetMeta(int index)
        {
            m_tileSheetMeta = new TileSheetMeta();
            m_tileSheetMeta.Tiles = new TileSheetTile[m_map.TileSheets[0].SheetWidth, m_map.TileSheets[0].SheetHeight];

            for (var x = 0; x < m_tileSheetMeta.Tiles.Columns(); x++)
                for (var y = 0; y < m_tileSheetMeta.Tiles.Rows(); y++)
                    m_tileSheetMeta.Tiles[x, y] = new TileSheetTile();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / m_tileWidth;
            int y = e.Y / m_tileHeight;

            m_tileSheetMeta.Tiles[x, y].IsBlocked = !m_tileSheetMeta.Tiles[x, y].IsBlocked;

            panel.Invalidate();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            m_dataStore.Save(m_tileSheetMeta, $"{m_map.Id}.TileSheetMeta");

            DialogResult = DialogResult.OK;

            Close();
        }

        private void tilesetsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fileIndex = filesListBox.SelectedIndex;

            panel.Invalidate();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            m_oldPos = m_cursor.Pos / new Vector(m_tileWidth, m_tileHeight);
            m_cursor.Pos = new Vector(e.X, e.Y);

            // draw map only if cursor has moved
            if (m_cursor.Pos / new Vector(m_tileWidth, m_tileHeight) != m_oldPos)
                panel.Invalidate();
        }
    }
}