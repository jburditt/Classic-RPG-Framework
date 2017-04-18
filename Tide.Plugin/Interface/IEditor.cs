using System.Windows.Forms;
using xTile.Layers;

namespace tIDE.Plugin.Interface
{
    public interface IEditor: IElement
    {
        //Map Map { get; }
        //Layer Layer { get; }
        string ProjectId { get; }

        MouseEditorHandler MouseDown { set; }
        MouseEditorHandler MouseMove { set; }
        MouseEditorHandler MouseUp { set; }
        TileEditorHandler DrawTile { set; }
        LayerEditorHandler LayerNew { set; }
        LayerEditorHandler LayerProperties { set; }
        LayerEditorHandler LayerDelete { set; }
        MapEditorHandler Save { set; }
        MapEditorHandler Load { set; }
    }

    public delegate void MouseEditorHandler(MouseEventArgs mouseEventArgs, MapEventArgs mapEventArgs);
    public delegate void TileEditorHandler(TileEventArgs eventArgs);
    public delegate void LayerEditorHandler(LayerEventArgs eventArgs);
    public delegate void MapEditorHandler(MapEventArgs eventArgs);
}