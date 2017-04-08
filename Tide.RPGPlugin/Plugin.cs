using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;

using tIDE.Plugin;
using tIDE.Plugin.Interface;
using Player;
using xTile.Layers;

namespace RPGPlugin
{
    public class RPGPlugin : IPlugin
    {
        private TideMap m_map;
        private Layer m_layer;

        private IMenuItem m_myDropDownMenu;
        private IMenuItem m_myMenuItem;
        private IToolBar m_myToolBar;
        private IToolBarButton m_npcToolBarButton, m_eventToolBarButton;

        #region IPlugin Members

        public string Name
        {
            get { return "MonoRPG Plugin"; }
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
            get {return "MonoRPG plugin"; }
        }

        public System.Drawing.Bitmap SmallIcon
        {
            get
            {
                return Properties.Resources.SmallIcon;
            }
        }

        public System.Drawing.Bitmap LargeIcon
        {
            get
            {
                return Properties.Resources.LargeIcon;
            }
        }

        public void Initialise(IApplication application)
        {
            m_myDropDownMenu = application.MenuStrip.DropDownMenus.Add("RPG");
            m_myDropDownMenu.Image = Properties.Resources.Menu;

            m_myMenuItem = application.MenuStrip.DropDownMenus["RPG"].SubItems.Add("NPC");
            m_myMenuItem.Image = Properties.Resources.Action;
            m_myMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            m_myMenuItem.EventHandler = NPCAction;

            m_myToolBar = application.ToolBars.Add("RPG ToolBar");

            m_npcToolBarButton = m_myToolBar.Buttons.Add("Button1", Properties.Resources.Action);
            m_npcToolBarButton.ToolTipText = "Place NPC";
            m_npcToolBarButton.Checked = true;
            m_npcToolBarButton.EventHandler = NPCAction;

            m_eventToolBarButton = m_myToolBar.Buttons.Add("Button2", Properties.Resources.Action);
            m_eventToolBarButton.ToolTipText = "Place Event";
            m_eventToolBarButton.EventHandler = EventAction;

            m_eventToolBarButton = m_myToolBar.Buttons.Add("Button3", Properties.Resources.Action);
            m_eventToolBarButton.ToolTipText = "TileSheets";
            m_eventToolBarButton.EventHandler = TileSheetsAction;

            m_map = application.Editor.Map;
            m_layer = application.Editor.Layer;

            application.Editor.MouseDown = OnEditorMouseDown;
        }

        public void Shutdown(IApplication application)
        {
            m_npcToolBarButton = m_eventToolBarButton = null;

            application.ToolBars.Remove(m_myToolBar);
            m_myToolBar = null;

            m_myMenuItem = null;

            application.MenuStrip.DropDownMenus.Remove(m_myDropDownMenu);
            m_myDropDownMenu = null;
        }

        public void NPCAction(object sender, EventArgs eventArgs)
        {
            m_npcToolBarButton.Checked = !m_npcToolBarButton.Checked;
        }

        public void EventAction(object sender, EventArgs eventArgs)
        {
            m_eventToolBarButton.Checked = !m_eventToolBarButton.Checked;
        }

        public void TileSheetsAction(object sender, EventArgs eventArgs)
        {
            using (var form = new TileSheetForm(m_map))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                }
            }
        }

        public void OnEditorMouseDown(MouseEventArgs mouseEventArgs, Location tileLocation)
        {
            if (m_npcToolBarButton.Checked)
            {
                using (var form = new NPCDialog())
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        form.Selected.Pos = new Vector(tileLocation.X * m_layer.TileWidth, tileLocation.Y * m_layer.TileHeight);

                        // TODO Check if NPC exists before adding
                        //m_map.NPC.Add(form.Selected);

                        // TODO load image
                    }
                }
            }
        }

        #endregion
    }
}