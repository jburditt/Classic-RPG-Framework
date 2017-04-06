﻿/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Public License (Ms-PL)                            //
//             http://www.opensource.org/licenses/ms-pl.html               //
//                                                                         //
//  AUTHOR     Colin Vella                                                 //
//                                                                         //
//  CODEBASE   http://tide.codeplex.com                                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using xTile.Dimensions;
using xTile.Display;
using xTile.ObjectModel;
using xTile.Tiles;

namespace xTile.Layers
{
    /// <summary>
    /// Represents a layer within an xTile map
    /// </summary>
    public class Layer : DescribedComponent
    {
        #region Public Methods

        /// <summary>
        /// Constructs a new layer with the given ID, parent map,
        /// layer dimensions and tile dimensions
        /// </summary>
        /// <param name="id">ID to assign to the layer</param>
        /// <param name="map">map containing the new layer</param>
        /// <param name="layerSize">width and height of the layer in tiles</param>
        /// <param name="tileSize">tile width and height in pixels</param>
        public Layer(string id, TideMap map, Size layerSize, Size tileSize)
            : base(id)
        {
            m_map = map;
            m_tileSheets = map.TileSheets;
            m_layerSize = layerSize;
            m_tileSize = tileSize;
            m_tiles = new Tile[layerSize.Width, layerSize.Height];
            m_tileArray = new TileArray(this, m_tiles);
            m_visible = true;
        }

        /// <summary>
        /// Tests if the layer contains at least one tile that references
        /// the given tile sheet
        /// </summary>
        /// <param name="tileSheet">Tile sheet to test</param>
        /// <returns>True if the layer depends on the given tile sheet, false otherwise</returns>
        public bool DependsOnTileSheet(TileSheet tileSheet)
        {
            for (int y = 0; y < m_layerSize.Height; y++)
                for (int x = 0; x < m_layerSize.Width; x++)
                {
                    Tile tile = m_tiles[x, y];
                    if (tile != null && tile.DependsOnTileSheet(tileSheet))
                        return true;
                }
            return false;
        }

        /// <summary>
        /// Returns the coordinates in tile units, given a location
        /// in pixels within the layer
        /// </summary>
        /// <param name="layerDisplayLocation">pixel location within the layer</param>
        /// <returns>Location in tile coordinates</returns>
        public Location GetTileLocation(Location layerDisplayLocation)
        {
            return new Location(
                layerDisplayLocation.X / m_tileSize.Width,
                layerDisplayLocation.Y / m_tileSize.Height);
        }

        /// <summary>
        /// Tests if the given tile location is within the layer bounds
        /// </summary>
        /// <param name="tileLocation">tile coordinates to test</param>
        /// <returns>True if the location is within the layer, False otherwise</returns>
        public bool IsValidTileLocation(Location tileLocation)
        {
            return tileLocation.X >= 0 && tileLocation.X < m_layerSize.Width
                && tileLocation.Y >= 0 && tileLocation.Y < m_layerSize.Height;
        }

        /// <summary>
        /// Tests if the given tile location is within the layer bounds
        /// </summary>
        /// <param name="tileX">horizontal tile coordiate to test</param>
        /// <param name="tileY">vertical tile coordinate to test</param>
        /// <returns>True if the location is within the layer, False otherwise</returns>
        public bool IsValidTileLocation(int tileX, int tileY)
        {
            return tileX >= 0 && tileX < m_layerSize.Width
                && tileY >= 0 && tileY < m_layerSize.Height;
        }

        /// <summary>
        /// Converts the viewport given in map pixel coordinates to layer
        /// coordinates taking into account parallax effects
        /// </summary>
        /// <param name="mapViewport">Viewport in map pixel coordinates</param>
        /// <returns>Viewport in layer pixel coordinates</returns>
        public Rectangle ConvertMapToLayerViewport(Rectangle mapViewport)
        {
            return new Rectangle(
                ConvertMapToLayerLocation(
                    mapViewport.Location, mapViewport.Size),
                    mapViewport.Size);
        }

        /// <summary>
        /// Convers the map location given in pixels to a layer location in
        /// pixels taking into account parallax effects given the viewport size
        /// </summary>
        /// <param name="mapDisplayLocation">Location in map pixel coordinates</param>
        /// <param name="viewportSize">Viewport dimensions in pixels</param>
        /// <returns>Location in layer pixel coordinates</returns>
        public Location ConvertMapToLayerLocation(Location mapDisplayLocation, Size viewportSize)
        {
            Size mapDisplaySize = m_map.DisplaySize;
            Size layerDisplaySize = DisplaySize;

            int viewportWidth = viewportSize.Width;
            int viewportHeight = viewportSize.Height;

            int layerWidthDifference = layerDisplaySize.Width - viewportWidth;
            int layerHeightDifference = layerDisplaySize.Height - viewportHeight;

            int mapWidthDifference = mapDisplaySize.Width - viewportWidth;
            int mapHeightDifference = mapDisplaySize.Height - viewportHeight;

            int layerLocationX = mapWidthDifference > 0
                ? mapDisplayLocation.X * layerWidthDifference / mapWidthDifference
                : 0;

            int layerLocationY = mapHeightDifference > 0
                ? mapDisplayLocation.Y * layerHeightDifference / mapHeightDifference
                : 0;

            return new Location(layerLocationX, layerLocationY);
        }

        /// <summary>
        /// Convers the layer location given in pixels to a map location in
        /// pixels taking into account parallax effects given the viewport size
        /// </summary>
        /// <param name="layerDisplayLocation">Location in layer pixel coordinates</param>
        /// <param name="viewportSize">Viewport dimensions in pixels</param>
        /// <returns>Location in map pixel coordinates</returns>
        public Location ConvertLayerToMapLocation(Location layerDisplayLocation, Size viewportSize)
        {
            Size mapDisplaySize = m_map.DisplaySize;
            Size layerDisplaySize = DisplaySize;

            return new Location(
                (layerDisplayLocation.X * (mapDisplaySize.Width - viewportSize.Width)) / (layerDisplaySize.Width - viewportSize.Width),
                (layerDisplayLocation.Y * (mapDisplaySize.Height - viewportSize.Height)) / (layerDisplaySize.Height - viewportSize.Height));
        }

        /// <summary>
        /// Computes and returns a rectangle representing a tile's bounadaries
        /// given the map viewport and location in tile coordinates, taking into
        /// account parallax effects. The rectangle coordinates are computed
        /// relative to the viewport origin
        /// </summary>
        /// <param name="mapViewport">Map viewport in pixels</param>
        /// <param name="tileLocation">Location in tile coordinates</param>
        /// <returns>Rectangle representing the bounadries of the tile</returns>
        public Rectangle GetTileDisplayRectangle(Rectangle mapViewport, Location tileLocation)
        {
            Location layerViewportLocation = ConvertMapToLayerLocation(mapViewport.Location, mapViewport.Size);

            Location tileDisplayLocation = new Location(
                tileLocation.X * m_tileSize.Width, tileLocation.Y * m_tileSize.Height);

            Location tileDisplayOffset = tileDisplayLocation - layerViewportLocation;

            return new Rectangle(tileDisplayOffset, m_tileSize);
        }

        /// <summary>
        /// Returns a reference to a tile given a pixel location within the
        /// map and the viewport size taking into account parallax effects.
        /// If no tile is assigned a at the computed location, null is
        /// returned
        /// </summary>
        /// <param name="mapDisplayLocation">pixel location where to pick the tile</param>
        /// <param name="viewportSize">viewport size to compute parallax for this layer</param>
        /// <returns>Tile picked at the location, or null if one present</returns>
        public Tile PickTile(Location mapDisplayLocation, Size viewportSize)
        {
            Location tileLocation = ConvertMapToLayerLocation(mapDisplayLocation, viewportSize);
            if (IsValidTileLocation(tileLocation))
                return m_tiles[tileLocation.X, tileLocation.Y];
            else
                return null;
        }

        /// <summary>
        /// Eliminates any tiles that refer to the given tile sheet
        /// </summary>
        /// <param name="tileSheet">tile sheet to test</param>
        public void RemoveTileSheetDependency(TileSheet tileSheet)
        {
            for (int y = 0; y < m_layerSize.Height; y++)
                for (int x = 0; x < m_layerSize.Width; x++)
                {
                    Tile tile = m_tiles[x, y];
                    if (tile != null && tile.DependsOnTileSheet(tileSheet))
                        m_tiles[x, y] = null;
                }
        }

        /// <summary>
        /// Visually renders the layer using the given display device,
        /// pixel offset from the map origin and display viewport. If
        /// wrapAround is set to True, the layer wraps around at the
        /// edges across and / or down.
        /// </summary>
        /// <param name="displayDevice">Display device on which to render layer</param>
        /// <param name="mapViewport">viewport on the dipslay device</param>
        /// <param name="displayOffset">offset in pixel coordinates into the map from the top left</param>
        /// <param name="wrapAround">Flag indicating if layer wrap-around is performed</param>
        public void Draw(IDisplayDevice displayDevice, Rectangle mapViewport, Location displayOffset, bool wrapAround)
        {
            if (wrapAround)
                DrawWrapped(displayDevice, mapViewport, displayOffset);
            else
                DrawNormal(displayDevice, mapViewport, displayOffset);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Map containing this layer
        /// </summary>
        public TideMap Map { get { return m_map; } }

        /// <summary>
        /// Width and height of this layer in tiles
        /// </summary>
        public Size LayerSize
        {
            get { return m_layerSize; }
            set
            {
                if (m_layerSize == value)
                    return;

                Tile[,] tiles = new Tile[value.Width, value.Height];

                int commonWidth = Math.Min(m_layerSize.Width, value.Width);
                int commonHeight = Math.Min(m_layerSize.Height, value.Height);
                for (int tileY = 0; tileY < commonHeight; tileY++)
                    for (int tileX = 0; tileX < commonWidth; tileX++)
                        tiles[tileX, tileY] = m_tiles[tileX, tileY];
                m_tiles = tiles;
                m_tileArray = new TileArray(this, m_tiles);

                m_layerSize = value;

                m_map.UpdateDisplaySize();
            }
        }

        /// <summary>
        /// Width of this layer in tiles
        /// </summary>
        public int LayerWidth
        {
            get { return m_layerSize.Width; }
            set { LayerSize = new Size(value, m_layerSize.Height); }
        }

        /// <summary>
        /// Height of this layer in tiles
        /// </summary>
        public int LayerHeight
        {
            get { return m_layerSize.Height; }
            set { LayerSize = new Size(m_layerSize.Width, value); }
        }

        /// <summary>
        /// Width and height of the tiles used in this layer
        /// </summary>
        public Size TileSize
        {
            get { return m_tileSize; }
            set { m_tileSize = value; }
        }

        /// <summary>
        /// Width of the tiles used in this layer
        /// </summary>
        public int TileWidth
        {
            get { return m_tileSize.Width; }
            set { m_tileSize.Width = value; }
        }

        /// <summary>
        /// Height of the tiles used in this layer
        /// </summary>
        public int TileHeight
        {
            get { return m_tileSize.Height; }
            set { m_tileSize.Height = value; }
        }

        /// <summary>
        /// Width and height of this layer in pixels
        /// </summary>
        public Size DisplaySize
        {
            get
            {
                return new Size(
                    m_layerSize.Width * m_tileSize.Width,
                    m_layerSize.Height * m_tileSize.Height);
            }
        }

        /// <summary>
        /// Width of this layer in pixels
        /// </summary>
        public int DisplayWidth
        {
            get { return m_layerSize.Width * m_tileSize.Width; }
        }

        /// <summary>
        /// Height of this layer in pixels
        /// </summary>
        public int DisplayHeight
        {
            get { return m_layerSize.Height * m_tileSize.Height; }
        }

        /// <summary>
        /// Visibilty flag to control rendering of this layer
        /// </summary>
        public bool Visible
        {
            get { return m_visible; }
            set { m_visible = value; }
        }

        /// <summary>
        /// Doubly-indexed accessor to this layer's tiles
        /// </summary>
        public TileArray Tiles { get { return m_tileArray; } }

        #endregion

        #region Public Events

        /// <summary>
        /// Raised before this layer is rendered
        /// </summary>
        public event LayerEventHandler BeforeDraw;

        /// <summary>
        /// Raised after this layer is rendered
        /// </summary>
        public event LayerEventHandler AfterDraw;

        #endregion

        #region Private Methods

        private int Wrap(int value, int span)
        {
            value = value % span;
            if (value < 0)
                value += span;
            return value;
        }

        private void DrawNormal(IDisplayDevice displayDevice, Rectangle mapViewport, Location displayOffset)
        {
            if (BeforeDraw != null)
                BeforeDraw(this, new LayerEventArgs(this, mapViewport));

            int tileWidth = m_tileSize.Width;
            int tileHeight = m_tileSize.Height;

            // determine internal tile offset
            Location tileInternalOffset = new Location(
                Wrap(mapViewport.X, tileWidth),
                Wrap(mapViewport.Y, tileHeight));

            // determine tile-level viewport location
            int tileXMin = mapViewport.X >= 0 ? mapViewport.X / tileWidth : (mapViewport.X - tileWidth + 1) / tileWidth;
            int tileYMin = mapViewport.Y >= 0 ? mapViewport.Y / tileHeight : (mapViewport.Y - tileHeight + 1) / tileHeight;

            // determine tile-level viewport location limits
            if (tileXMin < 0)
            {
                displayOffset.X -= tileXMin * tileWidth;
                tileXMin = 0;
            }
            if (tileYMin < 0)
            {
                displayOffset.Y -= tileYMin * tileHeight;
                tileYMin = 0;
            }

            // determine tile-level viewport size
            int tileColumns = 1 + (mapViewport.Size.Width - 1) / tileWidth;
            int tileRows = 1 + (mapViewport.Size.Height - 1) / tileHeight;

            // increment tile-level viewport size if display not tile-aligned
            if (tileInternalOffset.X != 0)
                ++tileColumns;
            if (tileInternalOffset.Y != 0)
                ++tileRows;

            // determine tile-level viewport size limits
            int tileXMax = Math.Min(tileXMin + tileColumns, m_layerSize.Width);
            int tileYMax = Math.Min(tileYMin + tileRows, m_layerSize.Height);

            Location tileLocation = displayOffset - tileInternalOffset;

            for (int tileY = tileYMin; tileY < tileYMax; tileY++)
            {
                tileLocation.X = displayOffset.X - tileInternalOffset.X;
                for (int tileX = tileXMin; tileX < tileXMax; tileX++)
                {
                    Tile tile = m_tiles[tileX, tileY];

                    if (tile != null)
                        displayDevice.DrawTile(tile, tileLocation);

                    tileLocation.X += tileWidth;
                }
                tileLocation.Y += tileHeight;
            }

            if (AfterDraw != null)
                AfterDraw(this, new LayerEventArgs(this, mapViewport));
        }

        private void DrawWrapped(IDisplayDevice displayDevice, Rectangle mapViewport, Location displayOffset)
        {
            if (BeforeDraw != null)
                BeforeDraw(this, new LayerEventArgs(this, mapViewport));

            // store local values for performance
            int tileWidth = m_tileSize.Width;
            int tileHeight = m_tileSize.Height;
            int layerWidth = m_layerSize.Width;
            int layerHeight = m_layerSize.Height;

            // determine internal tile offset
            Location tileInternalOffset = new Location(
                Wrap(mapViewport.X, tileWidth),
                Wrap(mapViewport.Y, tileHeight));

            // determine tile-level viewport location
            int tileXMin = mapViewport.X >= 0 ? mapViewport.X / tileWidth : (mapViewport.X - tileWidth + 1) / tileWidth;
            int tileYMin = mapViewport.Y >= 0 ? mapViewport.Y / tileHeight : (mapViewport.Y - tileHeight + 1) / tileHeight;

            // determine tile-level viewport size
            int tileColumns = 1 + (mapViewport.Size.Width - 1) / tileWidth;
            int tileRows = 1 + (mapViewport.Size.Height - 1) / tileHeight;

            // increment tile-level viewport size if display not tile-aligned
            if (tileInternalOffset.X != 0)
                ++tileColumns;
            if (tileInternalOffset.Y != 0)
                ++tileRows;

            // determine tile-level viewport size limits
            int tileXMax = tileXMin + tileColumns;
            int tileYMax = tileYMin + tileRows;

            Location tileLocation = displayOffset - tileInternalOffset;

            for (int tileY = tileYMin; tileY < tileYMax; tileY++)
            {
                tileLocation.X = displayOffset.X - tileInternalOffset.X;
                for (int tileX = tileXMin; tileX < tileXMax; tileX++)
                {
                    Tile tile = m_tiles[Wrap(tileX, layerWidth), Wrap(tileY, layerHeight)];

                    if (tile != null)
                        displayDevice.DrawTile(tile, tileLocation);

                    tileLocation.X += tileWidth;
                }
                tileLocation.Y += tileHeight;
            }

            if (AfterDraw != null)
                AfterDraw(this, new LayerEventArgs(this, mapViewport));
        }

        #endregion

        #region Private Variables

        private TideMap m_map;
        private ReadOnlyCollection<TileSheet> m_tileSheets;
        private Size m_layerSize;
        private Size m_tileSize;
        private Tile[,] m_tiles;
        private TileArray m_tileArray;
        private bool m_visible;

        #endregion
    }
}
