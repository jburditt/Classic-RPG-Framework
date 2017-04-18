using System.Drawing;
using System.Windows.Forms;
using xTile.Dimensions;
using xTile.Layers;
using tIDE.Controls;
using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    class EditorBridge : ElementBridge, IEditor
    {
        private MapPanel m_mapPanel;
        private MapTreeView m_mapTreeView;

        private MouseEditorHandler m_mouseDown;
        private MouseEditorHandler m_mouseMove;
        private MouseEditorHandler m_mouseUp;
        private TileEditorHandler m_drawTile;
        private LayerEditorHandler m_layerProperties;
        private LayerEditorHandler m_layerNew;
        private LayerEditorHandler m_layerDelete;
        private MapEditorHandler m_save;
        private MapEditorHandler m_load;

        private void OnMapPanelMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseDown == null || m_mapPanel.SelectedLayer == null)
                return;

            var tileLocation = GetTileLocation(mouseEventArgs.Location);

            m_mouseDown(mouseEventArgs, new MapEventArgs(m_mapPanel.Map, m_mapPanel.SelectedLayer, tileLocation.X, tileLocation.Y));
        }

        private void OnMapPanelMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseMove == null || m_mapPanel.SelectedLayer == null)
                return;

            var tileLocation = GetTileLocation(mouseEventArgs.Location);

            m_mouseMove(mouseEventArgs, new MapEventArgs(m_mapPanel.Map, m_mapPanel.SelectedLayer, tileLocation.X, tileLocation.Y));
        }

        private void OnMapPanelMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseUp == null || m_mapPanel.SelectedLayer == null)
                return;

            var tileLocation = GetTileLocation(mouseEventArgs.Location);

            m_mouseUp(mouseEventArgs, new MapEventArgs(m_mapPanel.Map, m_mapPanel.SelectedLayer, tileLocation.X, tileLocation.Y));
        }

        private void OnDrawTile(object sender, TileEventArgs e)
        {
            if (m_drawTile == null)
                return;

            m_drawTile(e);
        }

        private void OnLayerProperties(object sender, LayerEventArgs e)
        {
            if (m_layerProperties == null)
                return;

            m_layerProperties(e);
        }

        private void OnLayerNew(object sender, LayerEventArgs e)
        {
            if (m_layerNew == null)
                return;

            m_layerNew(e);
        }

        private void OnLayerDelete(object sender, LayerEventArgs e)
        {
            if (m_layerDelete == null)
                return;

            m_layerDelete(e);
        }

        private void OnLoad(object sender, MapEventArgs e)
        {
            if (m_load == null)
                return;

            m_load(e);
        }

        private void OnSave(object sender, MapEventArgs e)
        {
            if (m_save == null)
                return;

            m_save(e);
        }

        public EditorBridge(MapPanel mapPanel, MapTreeView mapTreeView)
            : base(false)
        {
            m_mapPanel = mapPanel;
            m_mapTreeView = mapTreeView;

            Panel innerPanel = m_mapPanel.InnerPanel;
            innerPanel.MouseDown += OnMapPanelMouseDown;
            innerPanel.MouseMove += OnMapPanelMouseMove;
            innerPanel.MouseUp += OnMapPanelMouseUp;
            m_mapPanel.DrawTileEvent += OnDrawTile;
            m_mapPanel.SaveEvent += OnSave;
            m_mapPanel.LoadEvent += OnLoad;
            m_mapTreeView.LayerNewAction += OnLayerNew;
            m_mapTreeView.LayerPropertiesAction += OnLayerProperties;
            m_mapTreeView.LayerDeleteAction += OnLayerDelete;
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

        //public Map Map { get { return m_mapPanel.Map; } }
        //public Layer Layer { get { return m_mapPanel.SelectedLayer; } }
        public string ProjectId { get { return m_mapPanel.ProjectId; } }

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

        public LayerEditorHandler LayerNew
        {
            set { m_layerNew = value; }
        }

        public LayerEditorHandler LayerProperties
        {
            set { m_layerProperties = value; }
        }

        public LayerEditorHandler LayerDelete
        {
            set { m_layerDelete = value; }
        }

        public MapEditorHandler Save
        {
            set { m_save = value; }
        }

        public MapEditorHandler Load
        {
            set { m_load = value; }
        }
    }
}