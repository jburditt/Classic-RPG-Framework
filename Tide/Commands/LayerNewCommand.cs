using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Layers;

namespace tIDE.Commands
{
    internal class LayerNewCommand: Command
    {
        private TideMap m_map;
        private Layer m_newLayer;

        public LayerNewCommand(TideMap map, Layer newLayer)
        {
            m_map = map;
            m_newLayer = newLayer;
            m_description = "Add new layer \"" + newLayer.Id + "\"";
        }

        public override void Do()
        {
            m_map.AddLayer(m_newLayer);
        }

        public override void Undo()
        {
            m_map.RemoveLayer(m_newLayer);
        }
    }
}
