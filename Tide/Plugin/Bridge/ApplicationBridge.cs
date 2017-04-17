using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tIDE.Commands;
using tIDE.Controls;
using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    internal class ApplicationBridge: ElementBridge, IApplication, IToolBarCollection
    {
        private CommandHistory m_commandHistory;
        private MenuStripBridge m_menuStripBridge;
        private ToolStripContainer m_toolStripContainer;
        private List<ToolBarBridge> m_toolBars;

        private EditorBridge m_editorBridge;
        private MapPanel m_mapPanel;

        private void PopulateToolBars(ToolStripPanel toolStripPanel, MapPanel mapPanel)
        {
            m_mapPanel = mapPanel;

            foreach (var control in toolStripPanel.Controls)
            {
                if (!(control is ToolStrip))
                    continue;
                m_toolBars.Add(new ToolBarBridge((ToolStrip)control, m_mapPanel, false));
            }
        }

        public ApplicationBridge(MenuStrip menuStrip, ToolStripContainer toolStripContainer, MapPanel mapPanel, MapTreeView mapTreeView) : base(false)
        {
            m_commandHistory = CommandHistory.Instance;

            m_menuStripBridge = new MenuStripBridge(menuStrip);

            m_toolStripContainer = toolStripContainer;
            m_toolBars = new List<ToolBarBridge>();
            PopulateToolBars(toolStripContainer.TopToolStripPanel, mapPanel);
            PopulateToolBars(toolStripContainer.BottomToolStripPanel, mapPanel);
            PopulateToolBars(toolStripContainer.LeftToolStripPanel, mapPanel);
            PopulateToolBars(toolStripContainer.RightToolStripPanel, mapPanel);

            m_editorBridge = new EditorBridge(mapPanel, mapTreeView);
        }

        public void Execute(ICommand command)
        {
            m_commandHistory.Do(new CommandBridge(command));
        }

        public IMenuStrip MenuStrip
        {
            get { return m_menuStripBridge; }
        }

        public IToolBarCollection ToolBars
        {
            get { return this; }
        }

        public IEditor Editor
        {
            get { return m_editorBridge; }
        }

        public IToolBar Add(string id)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Text = id;

            ToolStripPanel toolStripPanel = m_toolStripContainer.TopToolStripPanel;

            toolStripPanel.Controls.Add(toolStrip);

            ToolBarBridge toolBarBridge = new ToolBarBridge(toolStrip, m_mapPanel, false);

            m_toolBars.Add(toolBarBridge);
            return toolBarBridge;
        }

        public void Remove(IToolBar toolBar)
        {
            ToolBarBridge toolBarBridge = (ToolBarBridge)toolBar;

            if (!m_toolBars.Contains(toolBarBridge))
                throw new Exception("Cannot remove a toolbar that is not in the tool strip container");

            if (toolBar.ReadOnly)
                throw new Exception("Cannot remove a built-in toolbar");

            ToolStrip toolStrip = toolBarBridge.ToolStrip;
            toolStrip.Parent.Controls.Remove(toolStrip);

            m_toolBars.Remove(toolBarBridge);
        }

        public void Clear()
        {
            ToolStripPanel toolStripPanel = m_toolStripContainer.TopToolStripPanel;
            toolStripPanel.Controls.Clear();
        }

        public IToolBar this[string id]
        {
            get
            {
                foreach (IToolBar toolBar in m_toolBars)
                    if (toolBar.Id == id)
                        return toolBar;
                throw new Exception("Undefined toolbar");
            }
        }

        public IToolBar this[int index]
        {
            get { return m_toolBars[index]; }
        }
    }
}
