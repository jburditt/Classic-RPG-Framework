using System.Windows.Forms;
using xTile;
using xTile.Dimensions;
using xTile.Layers;

namespace tIDE.Plugin.Interface
{
    public interface IEditor: IElement
    {
        Map Map { get; }
        Layer Layer { get; }

        MouseEditorHandler MouseDown { set; }
        MouseEditorHandler MouseMove { set; }
        MouseEditorHandler MouseUp { set; }
        TileEditorHandler DrawTile { set; }
    }

    public delegate void MouseEditorHandler(MouseEventArgs mouseEventArgs, Location tileLocation);
    public delegate void TileEditorHandler(TileEventArgs eventArgs);
}