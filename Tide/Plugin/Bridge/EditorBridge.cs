using System.Drawing;
using System.Windows.Forms;
using xTile;
using xTile.Dimensions;
using xTile.Layers;
using tIDE.Controls;
using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    class EditorBridge : ElementBridge, IEditor
    {
        private MapPanel m_mapPanel;

        private MouseEditorHandler m_mouseDown;
        private MouseEditorHandler m_mouseMove;
        private MouseEditorHandler m_mouseUp;
        private TileEditorHandler m_drawTile;

        private void OnMapPanelMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseDown == null || m_mapPanel.SelectedLayer == null)
                return;

            var tileLocation = GetTileLocation(mouseEventArgs.Location);

            m_mouseDown(mouseEventArgs, tileLocation);
        }

        private void OnMapPanelMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseMove == null || m_mapPanel.SelectedLayer == null)
                return;

            var tileLocation = GetTileLocation(mouseEventArgs.Location);

            m_mouseMove(mouseEventArgs, tileLocation);
        }

        private void OnMapPanelMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseUp == null || m_mapPanel.SelectedLayer == null)
                return;

            var tileLocation = GetTileLocation(mouseEventArgs.Location);

            m_mouseUp(mouseEventArgs, tileLocation);
        }

        private void OnDrawTile(object sender, TileEventArgs e)
        {
            if (m_drawTile == null)
                return;

            m_drawTile(e);
        }

        public EditorBridge(MapPanel mapPanel)
            : base(false)
        {
            m_mapPanel = mapPanel;
            Panel innerPanel = m_mapPanel.InnerPanel;
            innerPanel.MouseDown += OnMapPanelMouseDown;
            innerPanel.MouseMove += OnMapPanelMouseMove;
            innerPanel.MouseUp += OnMapPanelMouseUp;
            mapPanel.DrawTileEvent += OnDrawTile;
        }

        private Location GetTileLocation(Point mapLocation)
        {
            var layer = m_mapPanel.SelectedLayer;
            var layerDisplayLocation = layer.ConvertMapToLayerLocation(
                new Location(mapLocation.X, mapLocation.Y), m_mapPanel.MapViewport.Size);

            if (m_mapPanel.Zoom > 1.0f)
                layerDisplayLocation /= (int)m_mapPanel.Zoom;
            else if (m_mapPanel.Zoom < 1.0f)
                layerDisplayLocation *= (int)(1.0f / m_mapPanel.Zoom);

            return layer.GetTileLocation(layerDisplayLocation);
        }

        public Map Map { get { return m_mapPanel.Map; } }
        public Layer Layer { get { return m_mapPanel.SelectedLayer; } }

        public MouseEditorHandler MouseDown
        {
            set { m_mouseDown = value; }
        }

        public MouseEditorHandler MouseMove
        {
            set { m_mouseMove = value; }
        }

        public MouseEditorHandler MouseUp
        {
            set { m_mouseUp = value; }
        }

        public TileEditorHandler DrawTile
        {
            set { m_drawTile = value; }
        }
    }
}