using System;
using System.Drawing;

namespace tIDE.Plugin.Interface
{
    public interface IToolBarButton : IElement
    {
        string Id { get; set; }
        Image Image { get; set; }
        string ToolTipText { get; set; }
        bool Enabled { get; set; }
        bool Checked { get; set; }
        object Tag { get; set; }

        EventHandler EventHandler { set; }
        ToolBarButtonHandler ToolBarButtonHandler { set; }
    }

    public delegate void ToolBarButtonHandler(object sender, MapEventArgs e);
}