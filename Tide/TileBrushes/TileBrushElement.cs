﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Dimensions;
using xTile.Tiles;

using tIDE.Controls;

namespace tIDE.TileBrushes
{
    [Serializable]
    public struct TileBrushElement
    {
        private Tile m_tile;
        private Location m_location;

        public TileBrushElement(Tile tile, Location location)
        {
            m_tile = tile;
            m_location = location;
        }

        public Tile Tile { get { return m_tile; } }

        public Location Location { get { return m_location; } }
    }
}
