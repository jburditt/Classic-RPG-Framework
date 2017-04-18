using System;
using System.Windows.Forms;
using tIDE.Controls;
using tIDE.Plugin.Interface;
using xTile.Dimensions;

namespace tIDE.Plugin.Bridge
{
    internal class ToolBarButtonBridge: ElementBridge, IToolBarButton
    {
        private ToolStripButton m_toolStripButton;
        private MapPanel m_mapPanel;
        private ToolBarButtonHandler m_toolBarButtonHandler;

        internal ToolStripButton ToolStripButton
        {
            get { return m_toolStripButton; }
        }

        public ToolBarButtonBridge(ToolStripButton toolStripButton, MapPanel mapPanel, bool readOnly)
            : base(readOnly)
        {
            m_toolStripButton = toolStripButton;
            m_mapPanel = mapPanel;
            m_toolStripButton.Click += (sender, EventArgs) => {
                OnToolStripButtonClick(sender, new MapEventArgs(m_mapPanel.Map, m_mapPanel.SelectedLayer, m_mapPanel.Location.X, m_mapPanel.Location.Y));
            };
        }

        public string Id
        {
            get { return m_toolStripButton.Name; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Name = value;
            }
        }

        public System.Drawing.Image Image
        {
            get { return m_toolStripButton.Image; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Image = value;
            }
        }

        public string ToolTipText
        {
            get { return m_toolStripButton.ToolTipText; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.ToolTipText = value;
            }
        }

        public bool Enabled
        {
            get { return m_toolStripButton.Enabled; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Enabled = value;
            }
        }

        public bool Checked
        {
            get { return m_toolStripButton.Checked; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Checked = value;
            }
        }

        public object Tag
        {
            get { return m_toolStripButton.Tag; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Tag = value;
            }
        }

        public EventHandler EventHandler
        {
            set { m_toolStripButton.Click += value; }
        }

        public ToolBarButtonHandler ToolBarButtonHandler
        {
            set { m_toolBarButtonHandler += value; }
        }

        private void OnToolStripButtonClick(object sender, MapEventArgs e)
        {
            if (m_toolBarButtonHandler == null)
                return;

            m_toolBarButtonHandler(sender, e);
        }
    }
}
