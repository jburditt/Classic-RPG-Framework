using DataStore;
using Player;
using Player.Maps;
using RPGPlugin.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using tIDE.Plugin;
using tIDE.Plugin.Interface;
using xTile.Layers;

namespace RPGPlugin
{
    public class RPGPlugin : IPlugin
    {
        private MapMeta m_mapMeta;
        private string m_projectId;

        private IDataStore m_dataStore;
        private IMenuItem m_myDropDownMenu;
        private IMenuItem m_myMenuItem;
        private IToolBar m_myToolBar;
        private IToolBarButton m_npcToolBarButton, m_eventToolBarButton, m_projectSettingsToolBarButton, m_tilesheetToolBarButton;

        #region IPlugin Members

        public string Name
        {
            get { return "RPG Editor"; }
        }

        public Version Version
        {
            get { return new Version(1, 0); }
        }

        public string Author
        {
            get { return "Jebb Burditt"; }
        }

        public string Description
        {
            get {return "RPG Editor"; }
        }

        public System.Drawing.Bitmap SmallIcon
        {
            get
            {
                return Properties.Resources.Sword_16;
            }
        }

        public Bitmap LargeIcon
        {
            get
            {
                return Properties.Resources.Sword_32;
            }
        }

        #endregion

        #region plugin methods

        public void Initialise(IApplication application)
        {
            application.ToolBars.Clear();

            m_myDropDownMenu = application.MenuStrip.DropDownMenus.Add("RPG");
            m_myDropDownMenu.Image = Properties.Resources.Sword_32;

            m_myMenuItem = application.MenuStrip.DropDownMenus["RPG"].SubItems.Add("Project Settings");
            m_myMenuItem.Image = Properties.Resources.ProjectSettings_32;
            m_myMenuItem.EventHandler = ProjectSettings;

            m_myMenuItem = application.MenuStrip.DropDownMenus["RPG"].SubItems.Add("Place NPC");
            m_myMenuItem.Image = Properties.Resources.NPC_32;
            m_myMenuItem.EventHandler = NPCAction;

            m_myMenuItem = application.MenuStrip.DropDownMenus["RPG"].SubItems.Add("Place Event");
            m_myMenuItem.Image = Properties.Resources.Event_32;
            m_myMenuItem.EventHandler = EventAction;

            //m_myMenuItem = application.MenuStrip.DropDownMenus["RPG"].SubItems.Add("TileSheet Meta");
            //m_myMenuItem.Image = Properties.Resources.TileSheetMeta_32;
            //m_myMenuItem.ToolBarButtonHandler = TileSheetsAction;

            m_myToolBar = application.ToolBars.Add("RPG ToolBar");

            m_projectSettingsToolBarButton = m_myToolBar.Buttons.Add("projectSettingsButton", Properties.Resources.ProjectSettings_16);
            m_projectSettingsToolBarButton.ToolTipText = "Project Settings";
            m_projectSettingsToolBarButton.EventHandler = ProjectSettings;

            m_npcToolBarButton = m_myToolBar.Buttons.Add("Button1", Properties.Resources.NPC_16);
            m_npcToolBarButton.ToolTipText = "Place NPC";
            m_npcToolBarButton.EventHandler = NPCAction;

            m_eventToolBarButton = m_myToolBar.Buttons.Add("Button2", Properties.Resources.Event_16);
            m_eventToolBarButton.ToolTipText = "Place Event";
            m_eventToolBarButton.EventHandler = EventAction;

            m_tilesheetToolBarButton = m_myToolBar.Buttons.Add("Button3", Properties.Resources.TileSheetMeta_16);
            m_tilesheetToolBarButton.ToolTipText = "TileSheets";
            m_tilesheetToolBarButton.ToolBarButtonHandler = TileSheetsAction;

            // pass application map to plugin
            m_projectId = application.Editor.ProjectId;

            if (string.IsNullOrEmpty(m_projectId))
                m_projectId = Prompt.ShowDialog("Project Name", "New Project");

            // load map meta data
            //var map = application.Editor.Map;
            //m_dataStore = new BinaryDataStore($"{Settings.ProjectFilePath}{m_projectId}\\");
            m_dataStore = new BinaryDataStore();
            //m_mapMeta = m_dataStore.Load<MapMeta>($"{map.Id}.MapMeta");
            //if (m_mapMeta == null)
            //    m_mapMeta = new MapMeta(map);

            // add plugin events to application
            application.Editor.MouseDown = OnEditorMouseDown;
            application.Editor.DrawTile = OnDrawTile;
            application.Editor.LayerNew = OnLayerNew;
            application.Editor.LayerDelete = OnLayerDelete;
            application.Editor.LayerProperties = OnLayerProperties;
            application.Editor.Save = OnSave;
            application.Editor.Load = OnLoad;
        }

        public void Shutdown(IApplication application)
        {
            // TODO
            m_npcToolBarButton = m_eventToolBarButton = null;

            application.ToolBars.Remove(m_myToolBar);
            m_myToolBar = null;

            m_myMenuItem = null;

            application.MenuStrip.DropDownMenus.Remove(m_myDropDownMenu);
            m_myDropDownMenu = null;
        }

        public void OnLoad(MapEventArgs e)
        {
            e.Map.FileName = Path.GetFileNameWithoutExtension(e.FilePath);
            string filePath = Directory.GetParent(e.FilePath).ToString();

            m_mapMeta = m_dataStore.Load<MapMeta>($"{filePath}\\{e.Map.FileName}.MapMeta");
        }

        public void OnSave(MapEventArgs e)
        {
            e.Map.FileName = Path.GetFileNameWithoutExtension(e.FilePath);
            string filePath = Directory.GetParent(e.FilePath).ToString();

            m_dataStore.Save(m_mapMeta, $"{filePath}\\{e.Map.FileName}.MapMeta");
        }

        public void ProjectSettings(object sender, EventArgs eventArgs)
        {
            // TODO should load from datastore on save and load of map only, otherwise store in plugin
            using (var form = new ProjectSettingsForm(m_dataStore, m_projectId))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    m_dataStore.Save(form.ProjectSettings, $"{form.ProjectSettings.Name}.Settings");
                }
            }
        }

        public void NPCAction(object sender, EventArgs eventArgs)
        {
            m_npcToolBarButton.Checked = !m_npcToolBarButton.Checked;
            m_eventToolBarButton.Checked = false;
        }

        public void EventAction(object sender, EventArgs eventArgs)
        {
            m_eventToolBarButton.Checked = !m_eventToolBarButton.Checked;
            m_npcToolBarButton.Checked = false;
        }

        public void TileSheetsAction(object sender, MapEventArgs e)
        {
            //// TODO m_map is only as recent as when plugin was Initialized
            using (var form = new TileSheetForm(m_dataStore, e.Map))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                }
            }
        }

        public void OnEditorMouseDown(MouseEventArgs mouseEventArgs, MapEventArgs mapEventArgs)
        {
            if (m_npcToolBarButton.Checked)
            {
                using (var form = new NPCDialog())
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        form.Selected.Pos = new Vector(mapEventArgs.X * mapEventArgs.Layer.TileWidth, mapEventArgs.Y * mapEventArgs.Layer.TileHeight);

                        //m_mapMeta.Resize(mapEventArgs.Map);
                        m_mapMeta.NPCs.Add(form.Selected);                      
                    }
                }
            }
        }

        private void OnDrawTile(TileEventArgs e)
        {
            var tileWidth = e.TileSize.Width;
            var tileHeight = e.TileSize.Height;

            var tileBitmap = (Bitmap)Image.FromFile("../../../Tide.RPGPlugin/Resources/x.png");

            var destRect = new Rectangle(e.Location.X, e.Location.Y, tileWidth, tileHeight);

            var npc = m_mapMeta.GetNPC(e.TileLocation.ToVector() * new Vector(tileWidth, tileHeight));
            if (npc != null)
                e.Graphics.DrawImage(tileBitmap, destRect, 0, 0, tileWidth, tileHeight, GraphicsUnit.Pixel, new System.Drawing.Imaging.ImageAttributes());
        }

        private void OnLayerNew(LayerEventArgs e)
        {
        }

        private void OnLayerProperties(LayerEventArgs e)
        {
        }

        private void OnLayerDelete(LayerEventArgs e)
        {
        }

        #endregion
    }
}