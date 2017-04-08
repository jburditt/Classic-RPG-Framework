using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using xTile;

namespace RPGPlugin
{
    public partial class TileSheetForm : Form
    {
        private TideMap m_map;
        private Bitmap m_bitmapImageSource;
        private string m_imageSourceErrorMessge;

        public TileSheetForm(TideMap map)
        {
            InitializeComponent();

            m_map = map;

            foreach (var tileSheet in m_map.TileSheets)
                tilesetsListBox.Items.Add(tileSheet);

            m_bitmapImageSource = null;
            m_imageSourceErrorMessge = null;

            if (m_map.TileSheets?.Count == 0)
                return;

            try
            {
                m_bitmapImageSource = LoadUnlockedBitmap(m_map.TileSheets[0].ImageSource);
            }
            catch (Exception exception)
            {
                m_bitmapImageSource = null;
                m_imageSourceErrorMessge = exception.Message;
            }
        }

        private Bitmap LoadUnlockedBitmap(string filename)
        {
            Bitmap unlockedBitmap = null;
            using (Bitmap lockedBitmap = new Bitmap(filename))
            {
                unlockedBitmap = new Bitmap(lockedBitmap.Width, lockedBitmap.Height, lockedBitmap.PixelFormat);
                unlockedBitmap.SetResolution(lockedBitmap.HorizontalResolution, lockedBitmap.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(unlockedBitmap))
                {
                    graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    graphics.DrawImageUnscaled(lockedBitmap, 0, 0);
                }
            }
            return unlockedBitmap;
        }

        private void panel_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            Graphics graphics = paintEventArgs.Graphics;

            if (m_bitmapImageSource == null && m_imageSourceErrorMessge == null)
            {
                graphics.DrawString("No image source selected", this.Font, SystemBrushes.ControlText, 0.0f, 0.0f);
                return;
            }
            else if (m_bitmapImageSource == null)
            {
                graphics.DrawString("Error loading image source:" + m_imageSourceErrorMessge, this.Font, SystemBrushes.ControlText, 0.0f, 0.0f);
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
            }
        }
    }
}