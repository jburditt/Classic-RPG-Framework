﻿namespace tIDE
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripSeparator m_fileSeparator1;
            System.Windows.Forms.ToolStripSeparator m_fileSeparator2;
            System.Windows.Forms.ToolStripSeparator m_fileSeparator4;
            System.Windows.Forms.ToolStripSeparator m_fileSeparator5;
            System.Windows.Forms.ToolStripSeparator m_layerSeparator1;
            System.Windows.Forms.ToolStripSeparator m_layerSeparator2;
            System.Windows.Forms.ToolStripSeparator m_layerSeparator3;
            System.Windows.Forms.ToolStripSeparator m_layerToolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator m_layerToolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator m_layerToolStripSeparator3;
            this.m_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.m_splitContainerLeftRight = new System.Windows.Forms.SplitContainer();
            this.m_splitContainerVertical = new System.Windows.Forms.SplitContainer();
            this.m_mapTreeView = new tIDE.Controls.MapTreeView();
            this.m_tilePicker = new tIDE.Controls.TilePicker();
            this.m_toolStripContainerInner = new System.Windows.Forms.ToolStripContainer();
            this.m_statusStrip = new System.Windows.Forms.StatusStrip();
            this.m_tileLocationStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_tileSheetStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_tileIndexStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_tilePropertiesStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_mapPanel = new tIDE.Controls.MapPanel();
            this.m_toolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_toolsSelectButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsSingleTileButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsTileBlockButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsFloodFillButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsEraserButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsDropperButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsTextureButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsTileBrushButton = new tIDE.Controls.CustomToolStripSplitButton();
            this.m_editToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_editUndoButton = new System.Windows.Forms.ToolStripButton();
            this.m_editRedoButton = new System.Windows.Forms.ToolStripButton();
            this.m_editHistoryButton = new System.Windows.Forms.ToolStripButton();
            this.m_editToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editCutButton = new System.Windows.Forms.ToolStripButton();
            this.m_editCopyButton = new System.Windows.Forms.ToolStripButton();
            this.m_editPasteButton = new System.Windows.Forms.ToolStripButton();
            this.m_editDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.m_editToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editSelectAllButton = new System.Windows.Forms.ToolStripButton();
            this.m_editClearSelectionButton = new System.Windows.Forms.ToolStripButton();
            this.m_editInvertSelectionButton = new System.Windows.Forms.ToolStripButton();
            this.m_editToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editMakeTileBrushButton = new System.Windows.Forms.ToolStripButton();
            this.m_editManageTileBrushesButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_tileSheetNewButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetAutoTilesButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_tileSheetAutoUpdateEnableButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetAutoUpdateDisableButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetEditImageSourceButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_tileSheetRemoveDependenciesButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_viewZoomLabel = new System.Windows.Forms.ToolStripLabel();
            this.m_viewZoomComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.m_viewZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_viewFullScreenButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewWindowedButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_viewLayersShowAllButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewLayersHighlightSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewShowTileGuidesButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewHideTileGuidesButton = new System.Windows.Forms.ToolStripButton();
            this.m_mapToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_mapPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.m_mapStatisticsButton = new System.Windows.Forms.ToolStripButton();
            this.m_fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_fileNewButton = new System.Windows.Forms.ToolStripButton();
            this.m_fileOpenButton = new System.Windows.Forms.ToolStripButton();
            this.m_fileToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_fileSaveButton = new System.Windows.Forms.ToolStripButton();
            this.m_fileSaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.m_fileToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_filePageSetupButton = new System.Windows.Forms.ToolStripButton();
            this.m_filePrintPreviewButton = new System.Windows.Forms.ToolStripButton();
            this.m_filePrintButton = new System.Windows.Forms.ToolStripButton();
            this.m_fileOptionsButton = new System.Windows.Forms.ToolStripButton();
            this.m_menuStrip = new System.Windows.Forms.MenuStrip();
            this.m_fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_filePageSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_filePrintPreviewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_filePrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_fileOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileRecentFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editUndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editRedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editHistoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editCutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editPasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editSelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editClearSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editInvertSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editMakeTileBrushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editManageTileBrushesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy5MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy6MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy7MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy9MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy10MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_viewFullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewWindowedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_viewLayersShowAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewLayersHighlightSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewShowTileGuidesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewHideTileGuidesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewportScaleToWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport320x200MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport320x240MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport640x480MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport800x600MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport848x480MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1024x768MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1280x720MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1280x768MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1280x1024MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1600x1200MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1920x1080MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewViewport1920x1200MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapStatisticsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerOffsetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerMakeInvisibleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerMakeVisibleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerBringForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerSendBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetAutoTilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_tileSheetAutoUpdateEnableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetAutoUpdateDisableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetEditImageSourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_tileSheetRemoveDependenciesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pluginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pluginReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_pluginNoneLoadedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_helpContentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_helpIndexMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_helpSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_layerNewButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerOffsetButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerMakeInvisibileButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerMakeVisibileButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerBringForwardButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerSendBackwardButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.m_loadErrorMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_saveErrorMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_unsavedMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_hasDependencyMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_dependencyRemovedMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            m_fileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_fileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_fileSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            m_fileSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            m_layerSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_layerSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_layerSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            m_layerToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_layerToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_layerToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolStripContainer.ContentPanel.SuspendLayout();
            this.m_toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.m_toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainerLeftRight)).BeginInit();
            this.m_splitContainerLeftRight.Panel1.SuspendLayout();
            this.m_splitContainerLeftRight.Panel2.SuspendLayout();
            this.m_splitContainerLeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainerVertical)).BeginInit();
            this.m_splitContainerVertical.Panel1.SuspendLayout();
            this.m_splitContainerVertical.Panel2.SuspendLayout();
            this.m_splitContainerVertical.SuspendLayout();
            this.m_toolStripContainerInner.BottomToolStripPanel.SuspendLayout();
            this.m_toolStripContainerInner.ContentPanel.SuspendLayout();
            this.m_toolStripContainerInner.RightToolStripPanel.SuspendLayout();
            this.m_toolStripContainerInner.SuspendLayout();
            this.m_statusStrip.SuspendLayout();
            this.m_toolsToolStrip.SuspendLayout();
            this.m_editToolStrip.SuspendLayout();
            this.m_tileSheetToolStrip.SuspendLayout();
            this.m_viewToolStrip.SuspendLayout();
            this.m_mapToolStrip.SuspendLayout();
            this.m_fileToolStrip.SuspendLayout();
            this.m_menuStrip.SuspendLayout();
            this.m_layerToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_toolStripContainer
            // 
            this.m_toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // m_toolStripContainer.ContentPanel
            // 
            this.m_toolStripContainer.ContentPanel.Controls.Add(this.m_splitContainerLeftRight);
            resources.ApplyResources(this.m_toolStripContainer.ContentPanel, "m_toolStripContainer.ContentPanel");
            resources.ApplyResources(this.m_toolStripContainer, "m_toolStripContainer");
            this.m_toolStripContainer.Name = "m_toolStripContainer";
            this.m_toolStripContainer.RightToolStripPanelVisible = false;
            // 
            // m_toolStripContainer.TopToolStripPanel
            // 
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_tileSheetToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_editToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_viewToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_mapToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_fileToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_menuStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_layerToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.OnCustomToolStripAdded);
            // 
            // m_splitContainerLeftRight
            // 
            resources.ApplyResources(this.m_splitContainerLeftRight, "m_splitContainerLeftRight");
            this.m_splitContainerLeftRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.m_splitContainerLeftRight.Name = "m_splitContainerLeftRight";
            // 
            // m_splitContainerLeftRight.Panel1
            // 
            this.m_splitContainerLeftRight.Panel1.Controls.Add(this.m_splitContainerVertical);
            // 
            // m_splitContainerLeftRight.Panel2
            // 
            this.m_splitContainerLeftRight.Panel2.Controls.Add(this.m_toolStripContainerInner);
            // 
            // m_splitContainerVertical
            // 
            resources.ApplyResources(this.m_splitContainerVertical, "m_splitContainerVertical");
            this.m_splitContainerVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.m_splitContainerVertical.Name = "m_splitContainerVertical";
            // 
            // m_splitContainerVertical.Panel1
            // 
            this.m_splitContainerVertical.Panel1.Controls.Add(this.m_mapTreeView);
            // 
            // m_splitContainerVertical.Panel2
            // 
            this.m_splitContainerVertical.Panel2.Controls.Add(this.m_tilePicker);
            // 
            // m_mapTreeView
            // 
            resources.ApplyResources(this.m_mapTreeView, "m_mapTreeView");
            this.m_mapTreeView.Map = null;
            this.m_mapTreeView.Name = "m_mapTreeView";
            this.m_mapTreeView.SelectedComponent = null;
            this.m_mapTreeView.ComponentChanged += new tIDE.Controls.MapTreeViewEventHandler(this.OnTreeComponentChanged);
            this.m_mapTreeView.MapProperties += new System.EventHandler(this.OnMapProperties);
            this.m_mapTreeView.MapStatistics += new System.EventHandler(this.OnMapStatistics);
            this.m_mapTreeView.NewLayer += new System.EventHandler(this.OnLayerNew);
            this.m_mapTreeView.LayerProperties += new System.EventHandler(this.OnLayerProperties);
            this.m_mapTreeView.LayerVisibility += new System.EventHandler(this.OnLayerVisibility);
            this.m_mapTreeView.BringLayerForward += new System.EventHandler(this.OnLayerBringForward);
            this.m_mapTreeView.SendLayerBackward += new System.EventHandler(this.OnLayerSendBackward);
            this.m_mapTreeView.DeleteLayer += new System.EventHandler(this.OnLayerDelete);
            this.m_mapTreeView.NewTileSheet += new System.EventHandler(this.OnTileSheetNew);
            this.m_mapTreeView.TileSheetProperties += new System.EventHandler(this.OnTileSheetProperties);
            this.m_mapTreeView.TileSheetAutoTiles += new System.EventHandler(this.OnTileSheetAutoTiles);
            this.m_mapTreeView.EditImageSource += new System.EventHandler(this.OnTileSheetEditImageSource);
            this.m_mapTreeView.RemoveDependencies += new System.EventHandler(this.OnTileSheetRemoveDependencies);
            this.m_mapTreeView.DeleteTileSheet += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // m_tilePicker
            // 
            resources.ApplyResources(this.m_tilePicker, "m_tilePicker");
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.TileSelected += new tIDE.Controls.TilePickerEventHandler(this.OnPickerTileSelected);
            this.m_tilePicker.TileBrushSelected += new tIDE.Controls.TilePickerEventHandler(this.OnPickerTileBrushSelected);
            this.m_tilePicker.TileIndexPropertiesChanged += new tIDE.Controls.TilePickerEventHandler(this.OnPickerTileIndexPropertiesChanged);
            // 
            // m_toolStripContainerInner
            // 
            // 
            // m_toolStripContainerInner.BottomToolStripPanel
            // 
            this.m_toolStripContainerInner.BottomToolStripPanel.Controls.Add(this.m_statusStrip);
            // 
            // m_toolStripContainerInner.ContentPanel
            // 
            this.m_toolStripContainerInner.ContentPanel.Controls.Add(this.m_mapPanel);
            resources.ApplyResources(this.m_toolStripContainerInner.ContentPanel, "m_toolStripContainerInner.ContentPanel");
            resources.ApplyResources(this.m_toolStripContainerInner, "m_toolStripContainerInner");
            this.m_toolStripContainerInner.Name = "m_toolStripContainerInner";
            // 
            // m_toolStripContainerInner.RightToolStripPanel
            // 
            this.m_toolStripContainerInner.RightToolStripPanel.Controls.Add(this.m_toolsToolStrip);
            this.m_toolStripContainerInner.TopToolStripPanelVisible = false;
            // 
            // m_statusStrip
            // 
            this.m_statusStrip.AllowMerge = false;
            resources.ApplyResources(this.m_statusStrip, "m_statusStrip");
            this.m_statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileLocationStatusLabel,
            this.m_tileSheetStatusLabel,
            this.m_tileIndexStatusLabel,
            this.m_tilePropertiesStatusLabel});
            this.m_statusStrip.Name = "m_statusStrip";
            // 
            // m_tileLocationStatusLabel
            // 
            this.m_tileLocationStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.m_tileLocationStatusLabel.Name = "m_tileLocationStatusLabel";
            resources.ApplyResources(this.m_tileLocationStatusLabel, "m_tileLocationStatusLabel");
            // 
            // m_tileSheetStatusLabel
            // 
            this.m_tileSheetStatusLabel.Margin = new System.Windows.Forms.Padding(64, 3, 0, 2);
            this.m_tileSheetStatusLabel.Name = "m_tileSheetStatusLabel";
            resources.ApplyResources(this.m_tileSheetStatusLabel, "m_tileSheetStatusLabel");
            // 
            // m_tileIndexStatusLabel
            // 
            this.m_tileIndexStatusLabel.Margin = new System.Windows.Forms.Padding(32, 3, 0, 2);
            this.m_tileIndexStatusLabel.Name = "m_tileIndexStatusLabel";
            resources.ApplyResources(this.m_tileIndexStatusLabel, "m_tileIndexStatusLabel");
            // 
            // m_tilePropertiesStatusLabel
            // 
            this.m_tilePropertiesStatusLabel.Image = global::tIDE.Properties.Resources.TilePropertiesIndicator;
            this.m_tilePropertiesStatusLabel.Margin = new System.Windows.Forms.Padding(32, 3, 0, 2);
            this.m_tilePropertiesStatusLabel.Name = "m_tilePropertiesStatusLabel";
            resources.ApplyResources(this.m_tilePropertiesStatusLabel, "m_tilePropertiesStatusLabel");
            // 
            // m_mapPanel
            // 
            this.m_mapPanel.AutoScaleViewport = true;
            this.m_mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.m_mapPanel, "m_mapPanel");
            this.m_mapPanel.EditTool = tIDE.Controls.EditTool.SingleTile;
            this.m_mapPanel.Map = null;
            this.m_mapPanel.Name = "m_mapPanel";
            this.m_mapPanel.SelectedLayer = null;
            this.m_mapPanel.SelectedTileIndex = 0;
            this.m_mapPanel.SelectedTileSheet = null;
            this.m_mapPanel.ZoomIndex = 5;
            this.m_mapPanel.TilePicked += new tIDE.Controls.MapPanelEventHandler(this.OnMapTilePicked);
            this.m_mapPanel.MapChanged += new System.EventHandler(this.OnMapChanged);
            this.m_mapPanel.TileHover += new tIDE.Controls.MapPanelEventHandler(this.OnTileHover);
            this.m_mapPanel.SelectionChanged += new System.EventHandler(this.OnTileSelectionChanged);
            this.m_mapPanel.TilePropertiesChanged += new tIDE.Controls.MapPanelEventHandler(this.OnTilePropertiesChanged);
            this.m_mapPanel.ZoomChanged += new System.EventHandler(this.OnZoomChanged);
            // 
            // m_toolsToolStrip
            // 
            resources.ApplyResources(this.m_toolsToolStrip, "m_toolsToolStrip");
            this.m_toolsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolsSelectButton,
            this.m_toolsSingleTileButton,
            this.m_toolsTileBlockButton,
            this.m_toolsFloodFillButton,
            this.m_toolsEraserButton,
            this.m_toolsDropperButton,
            this.m_toolsTextureButton,
            this.m_toolsTileBrushButton});
            this.m_toolsToolStrip.Name = "m_toolsToolStrip";
            // 
            // m_toolsSelectButton
            // 
            this.m_toolsSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsSelectButton.Image = global::tIDE.Properties.Resources.ToolsSelect;
            resources.ApplyResources(this.m_toolsSelectButton, "m_toolsSelectButton");
            this.m_toolsSelectButton.Name = "m_toolsSelectButton";
            this.m_toolsSelectButton.Click += new System.EventHandler(this.OnToolsSelect);
            // 
            // m_toolsSingleTileButton
            // 
            this.m_toolsSingleTileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsSingleTileButton.Image = global::tIDE.Properties.Resources.ToolsSingleTile;
            resources.ApplyResources(this.m_toolsSingleTileButton, "m_toolsSingleTileButton");
            this.m_toolsSingleTileButton.Name = "m_toolsSingleTileButton";
            this.m_toolsSingleTileButton.Click += new System.EventHandler(this.OnToolsSingleTile);
            // 
            // m_toolsTileBlockButton
            // 
            this.m_toolsTileBlockButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsTileBlockButton.Image = global::tIDE.Properties.Resources.ToolsTileBlock;
            resources.ApplyResources(this.m_toolsTileBlockButton, "m_toolsTileBlockButton");
            this.m_toolsTileBlockButton.Name = "m_toolsTileBlockButton";
            this.m_toolsTileBlockButton.Click += new System.EventHandler(this.OnToolsTileBlock);
            // 
            // m_toolsFloodFillButton
            // 
            this.m_toolsFloodFillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsFloodFillButton.Image = global::tIDE.Properties.Resources.ToolsFloodFill;
            resources.ApplyResources(this.m_toolsFloodFillButton, "m_toolsFloodFillButton");
            this.m_toolsFloodFillButton.Name = "m_toolsFloodFillButton";
            this.m_toolsFloodFillButton.Click += new System.EventHandler(this.OnToolsFloodFill);
            // 
            // m_toolsEraserButton
            // 
            this.m_toolsEraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsEraserButton.Image = global::tIDE.Properties.Resources.ToolsEraser;
            resources.ApplyResources(this.m_toolsEraserButton, "m_toolsEraserButton");
            this.m_toolsEraserButton.Name = "m_toolsEraserButton";
            this.m_toolsEraserButton.Click += new System.EventHandler(this.OnToolsEraser);
            // 
            // m_toolsDropperButton
            // 
            this.m_toolsDropperButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsDropperButton.Image = global::tIDE.Properties.Resources.ToolsDropper;
            resources.ApplyResources(this.m_toolsDropperButton, "m_toolsDropperButton");
            this.m_toolsDropperButton.Name = "m_toolsDropperButton";
            this.m_toolsDropperButton.Click += new System.EventHandler(this.OnToolsDropper);
            // 
            // m_toolsTextureButton
            // 
            this.m_toolsTextureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsTextureButton.Image = global::tIDE.Properties.Resources.ToolsTexture;
            resources.ApplyResources(this.m_toolsTextureButton, "m_toolsTextureButton");
            this.m_toolsTextureButton.Name = "m_toolsTextureButton";
            this.m_toolsTextureButton.Click += new System.EventHandler(this.OnToolsTexture);
            // 
            // m_toolsTileBrushButton
            // 
            this.m_toolsTileBrushButton.Checked = false;
            this.m_toolsTileBrushButton.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.m_toolsTileBrushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsTileBrushButton.Image = global::tIDE.Properties.Resources.ToolsTileBrush;
            resources.ApplyResources(this.m_toolsTileBrushButton, "m_toolsTileBrushButton");
            this.m_toolsTileBrushButton.Name = "m_toolsTileBrushButton";
            this.m_toolsTileBrushButton.ButtonClick += new System.EventHandler(this.OnToolsTileBrush);
            // 
            // m_editToolStrip
            // 
            resources.ApplyResources(this.m_editToolStrip, "m_editToolStrip");
            this.m_editToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_editToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_editUndoButton,
            this.m_editRedoButton,
            this.m_editHistoryButton,
            this.m_editToolStripSeparator1,
            this.m_editCutButton,
            this.m_editCopyButton,
            this.m_editPasteButton,
            this.m_editDeleteButton,
            this.m_editToolStripSeparator2,
            this.m_editSelectAllButton,
            this.m_editClearSelectionButton,
            this.m_editInvertSelectionButton,
            this.m_editToolStripSeparator3,
            this.m_editMakeTileBrushButton,
            this.m_editManageTileBrushesButton});
            this.m_editToolStrip.Name = "m_editToolStrip";
            // 
            // m_editUndoButton
            // 
            this.m_editUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editUndoButton, "m_editUndoButton");
            this.m_editUndoButton.Image = global::tIDE.Properties.Resources.EditUndo;
            this.m_editUndoButton.Name = "m_editUndoButton";
            this.m_editUndoButton.Click += new System.EventHandler(this.OnEditUndo);
            // 
            // m_editRedoButton
            // 
            this.m_editRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editRedoButton, "m_editRedoButton");
            this.m_editRedoButton.Image = global::tIDE.Properties.Resources.EditRedo;
            this.m_editRedoButton.Name = "m_editRedoButton";
            this.m_editRedoButton.Click += new System.EventHandler(this.OnEditRedo);
            // 
            // m_editHistoryButton
            // 
            this.m_editHistoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editHistoryButton, "m_editHistoryButton");
            this.m_editHistoryButton.Image = global::tIDE.Properties.Resources.EditHistory;
            this.m_editHistoryButton.Name = "m_editHistoryButton";
            this.m_editHistoryButton.Click += new System.EventHandler(this.OnEditHistory);
            // 
            // m_editToolStripSeparator1
            // 
            this.m_editToolStripSeparator1.Name = "m_editToolStripSeparator1";
            resources.ApplyResources(this.m_editToolStripSeparator1, "m_editToolStripSeparator1");
            // 
            // m_editCutButton
            // 
            this.m_editCutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editCutButton, "m_editCutButton");
            this.m_editCutButton.Image = global::tIDE.Properties.Resources.EditCut;
            this.m_editCutButton.Name = "m_editCutButton";
            this.m_editCutButton.Click += new System.EventHandler(this.OnEditCut);
            // 
            // m_editCopyButton
            // 
            this.m_editCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editCopyButton, "m_editCopyButton");
            this.m_editCopyButton.Image = global::tIDE.Properties.Resources.EditCopy;
            this.m_editCopyButton.Name = "m_editCopyButton";
            this.m_editCopyButton.Click += new System.EventHandler(this.OnEditCopy);
            // 
            // m_editPasteButton
            // 
            this.m_editPasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editPasteButton, "m_editPasteButton");
            this.m_editPasteButton.Image = global::tIDE.Properties.Resources.EditPaste;
            this.m_editPasteButton.Name = "m_editPasteButton";
            this.m_editPasteButton.Click += new System.EventHandler(this.OnEditPaste);
            // 
            // m_editDeleteButton
            // 
            this.m_editDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editDeleteButton, "m_editDeleteButton");
            this.m_editDeleteButton.Image = global::tIDE.Properties.Resources.EditDelete;
            this.m_editDeleteButton.Name = "m_editDeleteButton";
            this.m_editDeleteButton.Click += new System.EventHandler(this.OnEditDelete);
            // 
            // m_editToolStripSeparator2
            // 
            this.m_editToolStripSeparator2.Name = "m_editToolStripSeparator2";
            resources.ApplyResources(this.m_editToolStripSeparator2, "m_editToolStripSeparator2");
            // 
            // m_editSelectAllButton
            // 
            this.m_editSelectAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editSelectAllButton.Image = global::tIDE.Properties.Resources.EditSelectAll;
            resources.ApplyResources(this.m_editSelectAllButton, "m_editSelectAllButton");
            this.m_editSelectAllButton.Name = "m_editSelectAllButton";
            this.m_editSelectAllButton.Click += new System.EventHandler(this.OnEditSelectAll);
            // 
            // m_editClearSelectionButton
            // 
            this.m_editClearSelectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editClearSelectionButton.Image = global::tIDE.Properties.Resources.EditClearSelection;
            resources.ApplyResources(this.m_editClearSelectionButton, "m_editClearSelectionButton");
            this.m_editClearSelectionButton.Name = "m_editClearSelectionButton";
            this.m_editClearSelectionButton.Click += new System.EventHandler(this.OnEditClearSelection);
            // 
            // m_editInvertSelectionButton
            // 
            this.m_editInvertSelectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editInvertSelectionButton.Image = global::tIDE.Properties.Resources.EditInvertSelection;
            resources.ApplyResources(this.m_editInvertSelectionButton, "m_editInvertSelectionButton");
            this.m_editInvertSelectionButton.Name = "m_editInvertSelectionButton";
            this.m_editInvertSelectionButton.Click += new System.EventHandler(this.OnEditInvertSelection);
            // 
            // m_editToolStripSeparator3
            // 
            this.m_editToolStripSeparator3.Name = "m_editToolStripSeparator3";
            resources.ApplyResources(this.m_editToolStripSeparator3, "m_editToolStripSeparator3");
            // 
            // m_editMakeTileBrushButton
            // 
            this.m_editMakeTileBrushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editMakeTileBrushButton, "m_editMakeTileBrushButton");
            this.m_editMakeTileBrushButton.Image = global::tIDE.Properties.Resources.EditMakeTileBrush;
            this.m_editMakeTileBrushButton.Name = "m_editMakeTileBrushButton";
            this.m_editMakeTileBrushButton.Click += new System.EventHandler(this.OnEditMakeTileBrush);
            // 
            // m_editManageTileBrushesButton
            // 
            this.m_editManageTileBrushesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_editManageTileBrushesButton, "m_editManageTileBrushesButton");
            this.m_editManageTileBrushesButton.Image = global::tIDE.Properties.Resources.EditManageTileBrushes;
            this.m_editManageTileBrushesButton.Name = "m_editManageTileBrushesButton";
            this.m_editManageTileBrushesButton.Click += new System.EventHandler(this.OnEditManageTileBrushes);
            // 
            // m_tileSheetToolStrip
            // 
            resources.ApplyResources(this.m_tileSheetToolStrip, "m_tileSheetToolStrip");
            this.m_tileSheetToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_tileSheetToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewButton,
            this.m_tileSheetPropertiesButton,
            this.m_tileSheetAutoTilesButton,
            this.m_tileSheetToolStripSeparator1,
            this.m_tileSheetAutoUpdateEnableButton,
            this.m_tileSheetAutoUpdateDisableButton,
            this.m_tileSheetEditImageSourceButton,
            this.m_tileSheetToolStripSeparator2,
            this.m_tileSheetRemoveDependenciesButton,
            this.m_tileSheetDeleteButton});
            this.m_tileSheetToolStrip.Name = "m_tileSheetToolStrip";
            // 
            // m_tileSheetNewButton
            // 
            this.m_tileSheetNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_tileSheetNewButton.Image = global::tIDE.Properties.Resources.TileSheetNew;
            resources.ApplyResources(this.m_tileSheetNewButton, "m_tileSheetNewButton");
            this.m_tileSheetNewButton.Name = "m_tileSheetNewButton";
            this.m_tileSheetNewButton.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetPropertiesButton
            // 
            this.m_tileSheetPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_tileSheetPropertiesButton, "m_tileSheetPropertiesButton");
            this.m_tileSheetPropertiesButton.Image = global::tIDE.Properties.Resources.TileSheetProperties;
            this.m_tileSheetPropertiesButton.Name = "m_tileSheetPropertiesButton";
            this.m_tileSheetPropertiesButton.Click += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // m_tileSheetAutoTilesButton
            // 
            this.m_tileSheetAutoTilesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_tileSheetAutoTilesButton, "m_tileSheetAutoTilesButton");
            this.m_tileSheetAutoTilesButton.Image = global::tIDE.Properties.Resources.TileSheetAutoTiles;
            this.m_tileSheetAutoTilesButton.Name = "m_tileSheetAutoTilesButton";
            this.m_tileSheetAutoTilesButton.Click += new System.EventHandler(this.OnTileSheetAutoTiles);
            // 
            // m_tileSheetToolStripSeparator1
            // 
            this.m_tileSheetToolStripSeparator1.Name = "m_tileSheetToolStripSeparator1";
            resources.ApplyResources(this.m_tileSheetToolStripSeparator1, "m_tileSheetToolStripSeparator1");
            // 
            // m_tileSheetAutoUpdateEnableButton
            // 
            this.m_tileSheetAutoUpdateEnableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_tileSheetAutoUpdateEnableButton.Image = global::tIDE.Properties.Resources.TileSheetAutoUpdateEnable;
            resources.ApplyResources(this.m_tileSheetAutoUpdateEnableButton, "m_tileSheetAutoUpdateEnableButton");
            this.m_tileSheetAutoUpdateEnableButton.Name = "m_tileSheetAutoUpdateEnableButton";
            this.m_tileSheetAutoUpdateEnableButton.Click += new System.EventHandler(this.OnTileSheetAutoUpdate);
            // 
            // m_tileSheetAutoUpdateDisableButton
            // 
            this.m_tileSheetAutoUpdateDisableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_tileSheetAutoUpdateDisableButton.Image = global::tIDE.Properties.Resources.TileSheetAutoUpdateDisable;
            resources.ApplyResources(this.m_tileSheetAutoUpdateDisableButton, "m_tileSheetAutoUpdateDisableButton");
            this.m_tileSheetAutoUpdateDisableButton.Name = "m_tileSheetAutoUpdateDisableButton";
            this.m_tileSheetAutoUpdateDisableButton.Click += new System.EventHandler(this.OnTileSheetAutoUpdate);
            // 
            // m_tileSheetEditImageSourceButton
            // 
            this.m_tileSheetEditImageSourceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_tileSheetEditImageSourceButton, "m_tileSheetEditImageSourceButton");
            this.m_tileSheetEditImageSourceButton.Image = global::tIDE.Properties.Resources.TileSheetEditImageSource;
            this.m_tileSheetEditImageSourceButton.Name = "m_tileSheetEditImageSourceButton";
            this.m_tileSheetEditImageSourceButton.Click += new System.EventHandler(this.OnTileSheetEditImageSource);
            // 
            // m_tileSheetToolStripSeparator2
            // 
            this.m_tileSheetToolStripSeparator2.Name = "m_tileSheetToolStripSeparator2";
            resources.ApplyResources(this.m_tileSheetToolStripSeparator2, "m_tileSheetToolStripSeparator2");
            // 
            // m_tileSheetRemoveDependenciesButton
            // 
            this.m_tileSheetRemoveDependenciesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_tileSheetRemoveDependenciesButton, "m_tileSheetRemoveDependenciesButton");
            this.m_tileSheetRemoveDependenciesButton.Image = global::tIDE.Properties.Resources.TileSheetRemoveDependencies;
            this.m_tileSheetRemoveDependenciesButton.Name = "m_tileSheetRemoveDependenciesButton";
            this.m_tileSheetRemoveDependenciesButton.Click += new System.EventHandler(this.OnTileSheetRemoveDependencies);
            // 
            // m_tileSheetDeleteButton
            // 
            this.m_tileSheetDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_tileSheetDeleteButton, "m_tileSheetDeleteButton");
            this.m_tileSheetDeleteButton.Image = global::tIDE.Properties.Resources.TileSheetDelete;
            this.m_tileSheetDeleteButton.Name = "m_tileSheetDeleteButton";
            this.m_tileSheetDeleteButton.Click += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // m_viewToolStrip
            // 
            resources.ApplyResources(this.m_viewToolStrip, "m_viewToolStrip");
            this.m_viewToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_viewZoomLabel,
            this.m_viewZoomComboBox,
            this.m_viewZoomInButton,
            this.m_viewZoomOutButton,
            this.m_viewSeparator1,
            this.m_viewFullScreenButton,
            this.m_viewWindowedButton,
            this.m_viewSeparator2,
            this.m_viewLayersShowAllButton,
            this.m_viewLayersHighlightSelectedButton,
            this.m_viewShowTileGuidesButton,
            this.m_viewHideTileGuidesButton});
            this.m_viewToolStrip.Name = "m_viewToolStrip";
            // 
            // m_viewZoomLabel
            // 
            this.m_viewZoomLabel.Image = global::tIDE.Properties.Resources.ViewZoom;
            this.m_viewZoomLabel.Name = "m_viewZoomLabel";
            resources.ApplyResources(this.m_viewZoomLabel, "m_viewZoomLabel");
            // 
            // m_viewZoomComboBox
            // 
            this.m_viewZoomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_viewZoomComboBox.DropDownWidth = 60;
            this.m_viewZoomComboBox.Items.AddRange(new object[] {
            resources.GetString("m_viewZoomComboBox.Items"),
            resources.GetString("m_viewZoomComboBox.Items1"),
            resources.GetString("m_viewZoomComboBox.Items2"),
            resources.GetString("m_viewZoomComboBox.Items3"),
            resources.GetString("m_viewZoomComboBox.Items4"),
            resources.GetString("m_viewZoomComboBox.Items5"),
            resources.GetString("m_viewZoomComboBox.Items6"),
            resources.GetString("m_viewZoomComboBox.Items7"),
            resources.GetString("m_viewZoomComboBox.Items8"),
            resources.GetString("m_viewZoomComboBox.Items9")});
            this.m_viewZoomComboBox.Name = "m_viewZoomComboBox";
            resources.ApplyResources(this.m_viewZoomComboBox, "m_viewZoomComboBox");
            this.m_viewZoomComboBox.SelectedIndexChanged += new System.EventHandler(this.OnViewZoomComboBox);
            // 
            // m_viewZoomInButton
            // 
            this.m_viewZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewZoomInButton.Image = global::tIDE.Properties.Resources.ViewZoomIn;
            resources.ApplyResources(this.m_viewZoomInButton, "m_viewZoomInButton");
            this.m_viewZoomInButton.Name = "m_viewZoomInButton";
            this.m_viewZoomInButton.Click += new System.EventHandler(this.OnViewZoomIn);
            // 
            // m_viewZoomOutButton
            // 
            this.m_viewZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_viewZoomOutButton, "m_viewZoomOutButton");
            this.m_viewZoomOutButton.Image = global::tIDE.Properties.Resources.ViewZoomOut;
            this.m_viewZoomOutButton.Name = "m_viewZoomOutButton";
            this.m_viewZoomOutButton.Click += new System.EventHandler(this.OnViewZoomOut);
            // 
            // m_viewSeparator1
            // 
            this.m_viewSeparator1.Name = "m_viewSeparator1";
            resources.ApplyResources(this.m_viewSeparator1, "m_viewSeparator1");
            // 
            // m_viewFullScreenButton
            // 
            this.m_viewFullScreenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewFullScreenButton.Image = global::tIDE.Properties.Resources.ViewFullScreen;
            resources.ApplyResources(this.m_viewFullScreenButton, "m_viewFullScreenButton");
            this.m_viewFullScreenButton.Name = "m_viewFullScreenButton";
            this.m_viewFullScreenButton.Click += new System.EventHandler(this.OnViewWindowMode);
            // 
            // m_viewWindowedButton
            // 
            this.m_viewWindowedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewWindowedButton.Image = global::tIDE.Properties.Resources.ViewWindowed;
            resources.ApplyResources(this.m_viewWindowedButton, "m_viewWindowedButton");
            this.m_viewWindowedButton.Name = "m_viewWindowedButton";
            this.m_viewWindowedButton.Click += new System.EventHandler(this.OnViewWindowMode);
            // 
            // m_viewSeparator2
            // 
            this.m_viewSeparator2.Name = "m_viewSeparator2";
            resources.ApplyResources(this.m_viewSeparator2, "m_viewSeparator2");
            // 
            // m_viewLayersShowAllButton
            // 
            this.m_viewLayersShowAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewLayersShowAllButton.Image = global::tIDE.Properties.Resources.ViewLayerCompositingShowAll;
            resources.ApplyResources(this.m_viewLayersShowAllButton, "m_viewLayersShowAllButton");
            this.m_viewLayersShowAllButton.Name = "m_viewLayersShowAllButton";
            this.m_viewLayersShowAllButton.Click += new System.EventHandler(this.OnViewLayerCompositing);
            // 
            // m_viewLayersHighlightSelectedButton
            // 
            this.m_viewLayersHighlightSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewLayersHighlightSelectedButton.Image = global::tIDE.Properties.Resources.ViewLayerCompositingDimUnselected;
            resources.ApplyResources(this.m_viewLayersHighlightSelectedButton, "m_viewLayersHighlightSelectedButton");
            this.m_viewLayersHighlightSelectedButton.Name = "m_viewLayersHighlightSelectedButton";
            this.m_viewLayersHighlightSelectedButton.Click += new System.EventHandler(this.OnViewLayerCompositing);
            // 
            // m_viewShowTileGuidesButton
            // 
            this.m_viewShowTileGuidesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewShowTileGuidesButton.Image = global::tIDE.Properties.Resources.VewTileGuidesShow;
            resources.ApplyResources(this.m_viewShowTileGuidesButton, "m_viewShowTileGuidesButton");
            this.m_viewShowTileGuidesButton.Name = "m_viewShowTileGuidesButton";
            this.m_viewShowTileGuidesButton.Click += new System.EventHandler(this.OnViewTileGuides);
            // 
            // m_viewHideTileGuidesButton
            // 
            this.m_viewHideTileGuidesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewHideTileGuidesButton.Image = global::tIDE.Properties.Resources.VewTileGuidesHide;
            resources.ApplyResources(this.m_viewHideTileGuidesButton, "m_viewHideTileGuidesButton");
            this.m_viewHideTileGuidesButton.Name = "m_viewHideTileGuidesButton";
            this.m_viewHideTileGuidesButton.Click += new System.EventHandler(this.OnViewTileGuides);
            // 
            // m_mapToolStrip
            // 
            resources.ApplyResources(this.m_mapToolStrip, "m_mapToolStrip");
            this.m_mapToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_mapToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mapPropertiesButton,
            this.m_mapStatisticsButton});
            this.m_mapToolStrip.Name = "m_mapToolStrip";
            // 
            // m_mapPropertiesButton
            // 
            this.m_mapPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_mapPropertiesButton.Image = global::tIDE.Properties.Resources.MapProperties;
            resources.ApplyResources(this.m_mapPropertiesButton, "m_mapPropertiesButton");
            this.m_mapPropertiesButton.Name = "m_mapPropertiesButton";
            this.m_mapPropertiesButton.Click += new System.EventHandler(this.OnMapProperties);
            // 
            // m_mapStatisticsButton
            // 
            this.m_mapStatisticsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_mapStatisticsButton.Image = global::tIDE.Properties.Resources.MapStatistics;
            resources.ApplyResources(this.m_mapStatisticsButton, "m_mapStatisticsButton");
            this.m_mapStatisticsButton.Name = "m_mapStatisticsButton";
            this.m_mapStatisticsButton.Click += new System.EventHandler(this.OnMapStatistics);
            // 
            // m_fileToolStrip
            // 
            resources.ApplyResources(this.m_fileToolStrip, "m_fileToolStrip");
            this.m_fileToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_fileNewButton,
            this.m_fileOpenButton,
            this.m_fileToolStripSeparator1,
            this.m_fileSaveButton,
            this.m_fileSaveAsButton,
            this.m_fileToolStripSeparator2,
            this.m_filePageSetupButton,
            this.m_filePrintPreviewButton,
            this.m_filePrintButton,
            this.m_fileOptionsButton});
            this.m_fileToolStrip.Name = "m_fileToolStrip";
            // 
            // m_fileNewButton
            // 
            this.m_fileNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_fileNewButton.Image = global::tIDE.Properties.Resources.FileNew;
            resources.ApplyResources(this.m_fileNewButton, "m_fileNewButton");
            this.m_fileNewButton.Name = "m_fileNewButton";
            this.m_fileNewButton.Click += new System.EventHandler(this.OnFileNew);
            // 
            // m_fileOpenButton
            // 
            this.m_fileOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_fileOpenButton.Image = global::tIDE.Properties.Resources.FileOpen;
            resources.ApplyResources(this.m_fileOpenButton, "m_fileOpenButton");
            this.m_fileOpenButton.Name = "m_fileOpenButton";
            this.m_fileOpenButton.Click += new System.EventHandler(this.OnFileOpen);
            // 
            // m_fileToolStripSeparator1
            // 
            this.m_fileToolStripSeparator1.Name = "m_fileToolStripSeparator1";
            resources.ApplyResources(this.m_fileToolStripSeparator1, "m_fileToolStripSeparator1");
            // 
            // m_fileSaveButton
            // 
            this.m_fileSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_fileSaveButton, "m_fileSaveButton");
            this.m_fileSaveButton.Image = global::tIDE.Properties.Resources.FileSave;
            this.m_fileSaveButton.Name = "m_fileSaveButton";
            this.m_fileSaveButton.Click += new System.EventHandler(this.OnFileSave);
            // 
            // m_fileSaveAsButton
            // 
            this.m_fileSaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_fileSaveAsButton.Image = global::tIDE.Properties.Resources.FileSaveAs;
            resources.ApplyResources(this.m_fileSaveAsButton, "m_fileSaveAsButton");
            this.m_fileSaveAsButton.Name = "m_fileSaveAsButton";
            this.m_fileSaveAsButton.Click += new System.EventHandler(this.OnFileSaveAs);
            // 
            // m_fileToolStripSeparator2
            // 
            this.m_fileToolStripSeparator2.Name = "m_fileToolStripSeparator2";
            resources.ApplyResources(this.m_fileToolStripSeparator2, "m_fileToolStripSeparator2");
            // 
            // m_filePageSetupButton
            // 
            this.m_filePageSetupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_filePageSetupButton.Image = global::tIDE.Properties.Resources.FilePageSetup;
            resources.ApplyResources(this.m_filePageSetupButton, "m_filePageSetupButton");
            this.m_filePageSetupButton.Name = "m_filePageSetupButton";
            this.m_filePageSetupButton.Click += new System.EventHandler(this.OnFilePageSetup);
            // 
            // m_filePrintPreviewButton
            // 
            this.m_filePrintPreviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_filePrintPreviewButton.Image = global::tIDE.Properties.Resources.FilePrintPreview;
            resources.ApplyResources(this.m_filePrintPreviewButton, "m_filePrintPreviewButton");
            this.m_filePrintPreviewButton.Name = "m_filePrintPreviewButton";
            this.m_filePrintPreviewButton.Click += new System.EventHandler(this.OnFilePrintPreview);
            // 
            // m_filePrintButton
            // 
            this.m_filePrintButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_filePrintButton.Image = global::tIDE.Properties.Resources.FilePrint;
            resources.ApplyResources(this.m_filePrintButton, "m_filePrintButton");
            this.m_filePrintButton.Name = "m_filePrintButton";
            this.m_filePrintButton.Click += new System.EventHandler(this.OnFilePrint);
            // 
            // m_fileOptionsButton
            // 
            this.m_fileOptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_fileOptionsButton.Image = global::tIDE.Properties.Resources.FileOptions;
            resources.ApplyResources(this.m_fileOptionsButton, "m_fileOptionsButton");
            this.m_fileOptionsButton.Name = "m_fileOptionsButton";
            this.m_fileOptionsButton.Click += new System.EventHandler(this.OnFileOptions);
            // 
            // m_menuStrip
            // 
            resources.ApplyResources(this.m_menuStrip, "m_menuStrip");
            this.m_menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.m_menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_fileMenuItem,
            this.m_editMenuItem,
            this.m_viewMenuItem,
            this.m_mapMenuItem,
            this.m_layerMenuItem,
            this.m_tileSheetMenuItem,
            this.m_pluginMenuItem,
            this.m_helpMenuItem});
            this.m_menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.m_menuStrip.Name = "m_menuStrip";
            // 
            // m_fileMenuItem
            // 
            this.m_fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_fileNewMenuItem,
            this.m_fileOpenMenuItem,
            m_fileSeparator1,
            this.m_fileSaveMenuItem,
            this.m_fileSaveAsMenuItem,
            m_fileSeparator2,
            this.m_filePageSetupMenuItem,
            this.m_filePrintPreviewMenuItem,
            this.m_filePrintMenuItem,
            this.m_fileSeparator3,
            this.m_fileOptionsMenuItem,
            m_fileSeparator4,
            this.m_fileRecentFilesMenuItem,
            m_fileSeparator5,
            this.m_fileExitMenuItem});
            this.m_fileMenuItem.Image = global::tIDE.Properties.Resources.File;
            this.m_fileMenuItem.Name = "m_fileMenuItem";
            resources.ApplyResources(this.m_fileMenuItem, "m_fileMenuItem");
            // 
            // m_fileNewMenuItem
            // 
            this.m_fileNewMenuItem.Image = global::tIDE.Properties.Resources.FileNew;
            resources.ApplyResources(this.m_fileNewMenuItem, "m_fileNewMenuItem");
            this.m_fileNewMenuItem.Name = "m_fileNewMenuItem";
            this.m_fileNewMenuItem.Click += new System.EventHandler(this.OnFileNew);
            // 
            // m_fileOpenMenuItem
            // 
            this.m_fileOpenMenuItem.Image = global::tIDE.Properties.Resources.FileOpen;
            resources.ApplyResources(this.m_fileOpenMenuItem, "m_fileOpenMenuItem");
            this.m_fileOpenMenuItem.Name = "m_fileOpenMenuItem";
            this.m_fileOpenMenuItem.Click += new System.EventHandler(this.OnFileOpen);
            // 
            // m_fileSeparator1
            // 
            m_fileSeparator1.Name = "m_fileSeparator1";
            resources.ApplyResources(m_fileSeparator1, "m_fileSeparator1");
            // 
            // m_fileSaveMenuItem
            // 
            resources.ApplyResources(this.m_fileSaveMenuItem, "m_fileSaveMenuItem");
            this.m_fileSaveMenuItem.Image = global::tIDE.Properties.Resources.FileSave;
            this.m_fileSaveMenuItem.Name = "m_fileSaveMenuItem";
            this.m_fileSaveMenuItem.Click += new System.EventHandler(this.OnFileSave);
            // 
            // m_fileSaveAsMenuItem
            // 
            this.m_fileSaveAsMenuItem.Image = global::tIDE.Properties.Resources.FileSaveAs;
            this.m_fileSaveAsMenuItem.Name = "m_fileSaveAsMenuItem";
            resources.ApplyResources(this.m_fileSaveAsMenuItem, "m_fileSaveAsMenuItem");
            this.m_fileSaveAsMenuItem.Click += new System.EventHandler(this.OnFileSaveAs);
            // 
            // m_fileSeparator2
            // 
            m_fileSeparator2.Name = "m_fileSeparator2";
            resources.ApplyResources(m_fileSeparator2, "m_fileSeparator2");
            // 
            // m_filePageSetupMenuItem
            // 
            this.m_filePageSetupMenuItem.Image = global::tIDE.Properties.Resources.FilePageSetup;
            this.m_filePageSetupMenuItem.Name = "m_filePageSetupMenuItem";
            resources.ApplyResources(this.m_filePageSetupMenuItem, "m_filePageSetupMenuItem");
            this.m_filePageSetupMenuItem.Click += new System.EventHandler(this.OnFilePageSetup);
            // 
            // m_filePrintPreviewMenuItem
            // 
            this.m_filePrintPreviewMenuItem.Image = global::tIDE.Properties.Resources.FilePrintPreview;
            this.m_filePrintPreviewMenuItem.Name = "m_filePrintPreviewMenuItem";
            resources.ApplyResources(this.m_filePrintPreviewMenuItem, "m_filePrintPreviewMenuItem");
            this.m_filePrintPreviewMenuItem.Click += new System.EventHandler(this.OnFilePrintPreview);
            // 
            // m_filePrintMenuItem
            // 
            this.m_filePrintMenuItem.Image = global::tIDE.Properties.Resources.FilePrint;
            this.m_filePrintMenuItem.Name = "m_filePrintMenuItem";
            resources.ApplyResources(this.m_filePrintMenuItem, "m_filePrintMenuItem");
            this.m_filePrintMenuItem.Click += new System.EventHandler(this.OnFilePrint);
            // 
            // m_fileSeparator3
            // 
            this.m_fileSeparator3.Name = "m_fileSeparator3";
            resources.ApplyResources(this.m_fileSeparator3, "m_fileSeparator3");
            // 
            // m_fileOptionsMenuItem
            // 
            this.m_fileOptionsMenuItem.Image = global::tIDE.Properties.Resources.FileOptions;
            this.m_fileOptionsMenuItem.Name = "m_fileOptionsMenuItem";
            resources.ApplyResources(this.m_fileOptionsMenuItem, "m_fileOptionsMenuItem");
            this.m_fileOptionsMenuItem.Click += new System.EventHandler(this.OnFileOptions);
            // 
            // m_fileSeparator4
            // 
            m_fileSeparator4.Name = "m_fileSeparator4";
            resources.ApplyResources(m_fileSeparator4, "m_fileSeparator4");
            // 
            // m_fileRecentFilesMenuItem
            // 
            resources.ApplyResources(this.m_fileRecentFilesMenuItem, "m_fileRecentFilesMenuItem");
            this.m_fileRecentFilesMenuItem.Image = global::tIDE.Properties.Resources.FileOpenRecent;
            this.m_fileRecentFilesMenuItem.Name = "m_fileRecentFilesMenuItem";
            // 
            // m_fileSeparator5
            // 
            m_fileSeparator5.Name = "m_fileSeparator5";
            resources.ApplyResources(m_fileSeparator5, "m_fileSeparator5");
            // 
            // m_fileExitMenuItem
            // 
            this.m_fileExitMenuItem.Name = "m_fileExitMenuItem";
            resources.ApplyResources(this.m_fileExitMenuItem, "m_fileExitMenuItem");
            this.m_fileExitMenuItem.Click += new System.EventHandler(this.OnFileExit);
            // 
            // m_editMenuItem
            // 
            this.m_editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_editUndoMenuItem,
            this.m_editRedoMenuItem,
            this.m_editHistoryMenuItem,
            this.m_editMenuSeparator1,
            this.m_editCutMenuItem,
            this.m_editCopyMenuItem,
            this.m_editPasteMenuItem,
            this.m_editDeleteMenuItem,
            this.m_editMenuSeparator2,
            this.m_editSelectAllMenuItem,
            this.m_editClearSelectionMenuItem,
            this.m_editInvertSelectionMenuItem,
            this.m_editMenuSeparator3,
            this.m_editMakeTileBrushMenuItem,
            this.m_editManageTileBrushesMenuItem});
            this.m_editMenuItem.Image = global::tIDE.Properties.Resources.Edit;
            this.m_editMenuItem.Name = "m_editMenuItem";
            resources.ApplyResources(this.m_editMenuItem, "m_editMenuItem");
            // 
            // m_editUndoMenuItem
            // 
            resources.ApplyResources(this.m_editUndoMenuItem, "m_editUndoMenuItem");
            this.m_editUndoMenuItem.Image = global::tIDE.Properties.Resources.EditUndo;
            this.m_editUndoMenuItem.Name = "m_editUndoMenuItem";
            this.m_editUndoMenuItem.Click += new System.EventHandler(this.OnEditUndo);
            // 
            // m_editRedoMenuItem
            // 
            resources.ApplyResources(this.m_editRedoMenuItem, "m_editRedoMenuItem");
            this.m_editRedoMenuItem.Image = global::tIDE.Properties.Resources.EditRedo;
            this.m_editRedoMenuItem.Name = "m_editRedoMenuItem";
            this.m_editRedoMenuItem.Click += new System.EventHandler(this.OnEditRedo);
            // 
            // m_editHistoryMenuItem
            // 
            resources.ApplyResources(this.m_editHistoryMenuItem, "m_editHistoryMenuItem");
            this.m_editHistoryMenuItem.Image = global::tIDE.Properties.Resources.EditHistory;
            this.m_editHistoryMenuItem.Name = "m_editHistoryMenuItem";
            this.m_editHistoryMenuItem.Click += new System.EventHandler(this.OnEditHistory);
            // 
            // m_editMenuSeparator1
            // 
            this.m_editMenuSeparator1.Name = "m_editMenuSeparator1";
            resources.ApplyResources(this.m_editMenuSeparator1, "m_editMenuSeparator1");
            // 
            // m_editCutMenuItem
            // 
            resources.ApplyResources(this.m_editCutMenuItem, "m_editCutMenuItem");
            this.m_editCutMenuItem.Image = global::tIDE.Properties.Resources.EditCut;
            this.m_editCutMenuItem.Name = "m_editCutMenuItem";
            this.m_editCutMenuItem.Click += new System.EventHandler(this.OnEditCut);
            // 
            // m_editCopyMenuItem
            // 
            resources.ApplyResources(this.m_editCopyMenuItem, "m_editCopyMenuItem");
            this.m_editCopyMenuItem.Image = global::tIDE.Properties.Resources.EditCopy;
            this.m_editCopyMenuItem.Name = "m_editCopyMenuItem";
            this.m_editCopyMenuItem.Click += new System.EventHandler(this.OnEditCopy);
            // 
            // m_editPasteMenuItem
            // 
            resources.ApplyResources(this.m_editPasteMenuItem, "m_editPasteMenuItem");
            this.m_editPasteMenuItem.Image = global::tIDE.Properties.Resources.EditPaste;
            this.m_editPasteMenuItem.Name = "m_editPasteMenuItem";
            this.m_editPasteMenuItem.Click += new System.EventHandler(this.OnEditPaste);
            // 
            // m_editDeleteMenuItem
            // 
            resources.ApplyResources(this.m_editDeleteMenuItem, "m_editDeleteMenuItem");
            this.m_editDeleteMenuItem.Image = global::tIDE.Properties.Resources.EditDelete;
            this.m_editDeleteMenuItem.Name = "m_editDeleteMenuItem";
            this.m_editDeleteMenuItem.Click += new System.EventHandler(this.OnEditDelete);
            // 
            // m_editMenuSeparator2
            // 
            this.m_editMenuSeparator2.Name = "m_editMenuSeparator2";
            resources.ApplyResources(this.m_editMenuSeparator2, "m_editMenuSeparator2");
            // 
            // m_editSelectAllMenuItem
            // 
            resources.ApplyResources(this.m_editSelectAllMenuItem, "m_editSelectAllMenuItem");
            this.m_editSelectAllMenuItem.Image = global::tIDE.Properties.Resources.EditSelectAll;
            this.m_editSelectAllMenuItem.Name = "m_editSelectAllMenuItem";
            this.m_editSelectAllMenuItem.Click += new System.EventHandler(this.OnEditSelectAll);
            // 
            // m_editClearSelectionMenuItem
            // 
            resources.ApplyResources(this.m_editClearSelectionMenuItem, "m_editClearSelectionMenuItem");
            this.m_editClearSelectionMenuItem.Image = global::tIDE.Properties.Resources.EditClearSelection;
            this.m_editClearSelectionMenuItem.Name = "m_editClearSelectionMenuItem";
            this.m_editClearSelectionMenuItem.Click += new System.EventHandler(this.OnEditClearSelection);
            // 
            // m_editInvertSelectionMenuItem
            // 
            resources.ApplyResources(this.m_editInvertSelectionMenuItem, "m_editInvertSelectionMenuItem");
            this.m_editInvertSelectionMenuItem.Image = global::tIDE.Properties.Resources.EditInvertSelection;
            this.m_editInvertSelectionMenuItem.Name = "m_editInvertSelectionMenuItem";
            this.m_editInvertSelectionMenuItem.Click += new System.EventHandler(this.OnEditInvertSelection);
            // 
            // m_editMenuSeparator3
            // 
            this.m_editMenuSeparator3.Name = "m_editMenuSeparator3";
            resources.ApplyResources(this.m_editMenuSeparator3, "m_editMenuSeparator3");
            // 
            // m_editMakeTileBrushMenuItem
            // 
            resources.ApplyResources(this.m_editMakeTileBrushMenuItem, "m_editMakeTileBrushMenuItem");
            this.m_editMakeTileBrushMenuItem.Image = global::tIDE.Properties.Resources.EditMakeTileBrush;
            this.m_editMakeTileBrushMenuItem.Name = "m_editMakeTileBrushMenuItem";
            this.m_editMakeTileBrushMenuItem.Click += new System.EventHandler(this.OnEditMakeTileBrush);
            // 
            // m_editManageTileBrushesMenuItem
            // 
            resources.ApplyResources(this.m_editManageTileBrushesMenuItem, "m_editManageTileBrushesMenuItem");
            this.m_editManageTileBrushesMenuItem.Image = global::tIDE.Properties.Resources.EditManageTileBrushes;
            this.m_editManageTileBrushesMenuItem.Name = "m_editManageTileBrushesMenuItem";
            this.m_editManageTileBrushesMenuItem.Click += new System.EventHandler(this.OnEditManageTileBrushes);
            // 
            // m_viewMenuItem
            // 
            this.m_viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_viewZoomMenuItem,
            this.m_viewZoomInMenuItem,
            this.m_viewZoomOutMenuItem,
            this.m_viewMenuSeparator1,
            this.m_viewFullScreenMenuItem,
            this.m_viewWindowedMenuItem,
            this.m_viewMenuSeparator2,
            this.m_viewLayersShowAllMenuItem,
            this.m_viewLayersHighlightSelectedMenuItem,
            this.m_viewShowTileGuidesMenuItem,
            this.m_viewHideTileGuidesMenuItem,
            this.m_viewViewportMenuItem});
            this.m_viewMenuItem.Image = global::tIDE.Properties.Resources.View;
            this.m_viewMenuItem.Name = "m_viewMenuItem";
            resources.ApplyResources(this.m_viewMenuItem, "m_viewMenuItem");
            // 
            // m_viewZoomMenuItem
            // 
            this.m_viewZoomMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_viewZoomBy1MenuItem,
            this.m_viewZoomBy2MenuItem,
            this.m_viewZoomBy3MenuItem,
            this.m_viewZoomBy4MenuItem,
            this.m_viewZoomBy5MenuItem,
            this.m_viewZoomBy6MenuItem,
            this.m_viewZoomBy7MenuItem,
            this.m_viewZoomBy8MenuItem,
            this.m_viewZoomBy9MenuItem,
            this.m_viewZoomBy10MenuItem});
            this.m_viewZoomMenuItem.Image = global::tIDE.Properties.Resources.ViewZoom;
            this.m_viewZoomMenuItem.Name = "m_viewZoomMenuItem";
            resources.ApplyResources(this.m_viewZoomMenuItem, "m_viewZoomMenuItem");
            // 
            // m_viewZoomBy1MenuItem
            // 
            this.m_viewZoomBy1MenuItem.Name = "m_viewZoomBy1MenuItem";
            resources.ApplyResources(this.m_viewZoomBy1MenuItem, "m_viewZoomBy1MenuItem");
            this.m_viewZoomBy1MenuItem.Tag = "1";
            this.m_viewZoomBy1MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy2MenuItem
            // 
            this.m_viewZoomBy2MenuItem.Name = "m_viewZoomBy2MenuItem";
            resources.ApplyResources(this.m_viewZoomBy2MenuItem, "m_viewZoomBy2MenuItem");
            this.m_viewZoomBy2MenuItem.Tag = "2";
            this.m_viewZoomBy2MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy3MenuItem
            // 
            this.m_viewZoomBy3MenuItem.Name = "m_viewZoomBy3MenuItem";
            resources.ApplyResources(this.m_viewZoomBy3MenuItem, "m_viewZoomBy3MenuItem");
            this.m_viewZoomBy3MenuItem.Tag = "";
            this.m_viewZoomBy3MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy4MenuItem
            // 
            this.m_viewZoomBy4MenuItem.Name = "m_viewZoomBy4MenuItem";
            resources.ApplyResources(this.m_viewZoomBy4MenuItem, "m_viewZoomBy4MenuItem");
            this.m_viewZoomBy4MenuItem.Tag = "";
            this.m_viewZoomBy4MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy5MenuItem
            // 
            this.m_viewZoomBy5MenuItem.Name = "m_viewZoomBy5MenuItem";
            resources.ApplyResources(this.m_viewZoomBy5MenuItem, "m_viewZoomBy5MenuItem");
            this.m_viewZoomBy5MenuItem.Tag = "5";
            this.m_viewZoomBy5MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy6MenuItem
            // 
            this.m_viewZoomBy6MenuItem.Checked = true;
            this.m_viewZoomBy6MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_viewZoomBy6MenuItem.Name = "m_viewZoomBy6MenuItem";
            resources.ApplyResources(this.m_viewZoomBy6MenuItem, "m_viewZoomBy6MenuItem");
            this.m_viewZoomBy6MenuItem.Tag = "6";
            this.m_viewZoomBy6MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy7MenuItem
            // 
            this.m_viewZoomBy7MenuItem.Name = "m_viewZoomBy7MenuItem";
            resources.ApplyResources(this.m_viewZoomBy7MenuItem, "m_viewZoomBy7MenuItem");
            this.m_viewZoomBy7MenuItem.Tag = "7";
            this.m_viewZoomBy7MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy8MenuItem
            // 
            this.m_viewZoomBy8MenuItem.Name = "m_viewZoomBy8MenuItem";
            resources.ApplyResources(this.m_viewZoomBy8MenuItem, "m_viewZoomBy8MenuItem");
            this.m_viewZoomBy8MenuItem.Tag = "8";
            this.m_viewZoomBy8MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy9MenuItem
            // 
            this.m_viewZoomBy9MenuItem.Name = "m_viewZoomBy9MenuItem";
            resources.ApplyResources(this.m_viewZoomBy9MenuItem, "m_viewZoomBy9MenuItem");
            this.m_viewZoomBy9MenuItem.Tag = "9";
            this.m_viewZoomBy9MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy10MenuItem
            // 
            this.m_viewZoomBy10MenuItem.Name = "m_viewZoomBy10MenuItem";
            resources.ApplyResources(this.m_viewZoomBy10MenuItem, "m_viewZoomBy10MenuItem");
            this.m_viewZoomBy10MenuItem.Tag = "10";
            this.m_viewZoomBy10MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomInMenuItem
            // 
            this.m_viewZoomInMenuItem.Image = global::tIDE.Properties.Resources.ViewZoomIn;
            this.m_viewZoomInMenuItem.Name = "m_viewZoomInMenuItem";
            resources.ApplyResources(this.m_viewZoomInMenuItem, "m_viewZoomInMenuItem");
            this.m_viewZoomInMenuItem.Click += new System.EventHandler(this.OnViewZoomIn);
            // 
            // m_viewZoomOutMenuItem
            // 
            this.m_viewZoomOutMenuItem.Image = global::tIDE.Properties.Resources.ViewZoomOut;
            this.m_viewZoomOutMenuItem.Name = "m_viewZoomOutMenuItem";
            resources.ApplyResources(this.m_viewZoomOutMenuItem, "m_viewZoomOutMenuItem");
            this.m_viewZoomOutMenuItem.Click += new System.EventHandler(this.OnViewZoomOut);
            // 
            // m_viewMenuSeparator1
            // 
            this.m_viewMenuSeparator1.Name = "m_viewMenuSeparator1";
            resources.ApplyResources(this.m_viewMenuSeparator1, "m_viewMenuSeparator1");
            // 
            // m_viewFullScreenMenuItem
            // 
            this.m_viewFullScreenMenuItem.Image = global::tIDE.Properties.Resources.ViewFullScreen;
            this.m_viewFullScreenMenuItem.Name = "m_viewFullScreenMenuItem";
            resources.ApplyResources(this.m_viewFullScreenMenuItem, "m_viewFullScreenMenuItem");
            this.m_viewFullScreenMenuItem.Click += new System.EventHandler(this.OnViewWindowMode);
            // 
            // m_viewWindowedMenuItem
            // 
            this.m_viewWindowedMenuItem.Image = global::tIDE.Properties.Resources.ViewWindowed;
            this.m_viewWindowedMenuItem.Name = "m_viewWindowedMenuItem";
            resources.ApplyResources(this.m_viewWindowedMenuItem, "m_viewWindowedMenuItem");
            this.m_viewWindowedMenuItem.Click += new System.EventHandler(this.OnViewWindowMode);
            // 
            // m_viewMenuSeparator2
            // 
            this.m_viewMenuSeparator2.Name = "m_viewMenuSeparator2";
            resources.ApplyResources(this.m_viewMenuSeparator2, "m_viewMenuSeparator2");
            // 
            // m_viewLayersShowAllMenuItem
            // 
            this.m_viewLayersShowAllMenuItem.Image = global::tIDE.Properties.Resources.ViewLayerCompositingShowAll;
            this.m_viewLayersShowAllMenuItem.Name = "m_viewLayersShowAllMenuItem";
            resources.ApplyResources(this.m_viewLayersShowAllMenuItem, "m_viewLayersShowAllMenuItem");
            this.m_viewLayersShowAllMenuItem.Click += new System.EventHandler(this.OnViewLayerCompositing);
            // 
            // m_viewLayersHighlightSelectedMenuItem
            // 
            this.m_viewLayersHighlightSelectedMenuItem.Image = global::tIDE.Properties.Resources.ViewLayerCompositingDimUnselected;
            this.m_viewLayersHighlightSelectedMenuItem.Name = "m_viewLayersHighlightSelectedMenuItem";
            resources.ApplyResources(this.m_viewLayersHighlightSelectedMenuItem, "m_viewLayersHighlightSelectedMenuItem");
            this.m_viewLayersHighlightSelectedMenuItem.Click += new System.EventHandler(this.OnViewLayerCompositing);
            // 
            // m_viewShowTileGuidesMenuItem
            // 
            this.m_viewShowTileGuidesMenuItem.Image = global::tIDE.Properties.Resources.VewTileGuidesShow;
            this.m_viewShowTileGuidesMenuItem.Name = "m_viewShowTileGuidesMenuItem";
            resources.ApplyResources(this.m_viewShowTileGuidesMenuItem, "m_viewShowTileGuidesMenuItem");
            this.m_viewShowTileGuidesMenuItem.Click += new System.EventHandler(this.OnViewTileGuides);
            // 
            // m_viewHideTileGuidesMenuItem
            // 
            this.m_viewHideTileGuidesMenuItem.Image = global::tIDE.Properties.Resources.VewTileGuidesHide;
            this.m_viewHideTileGuidesMenuItem.Name = "m_viewHideTileGuidesMenuItem";
            resources.ApplyResources(this.m_viewHideTileGuidesMenuItem, "m_viewHideTileGuidesMenuItem");
            this.m_viewHideTileGuidesMenuItem.Click += new System.EventHandler(this.OnViewTileGuides);
            // 
            // m_viewViewportMenuItem
            // 
            this.m_viewViewportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_viewViewportScaleToWindowMenuItem,
            this.m_viewViewport320x200MenuItem,
            this.m_viewViewport320x240MenuItem,
            this.m_viewViewport640x480MenuItem,
            this.m_viewViewport800x600MenuItem,
            this.m_viewViewport848x480MenuItem,
            this.m_viewViewport1024x768MenuItem,
            this.m_viewViewport1280x720MenuItem,
            this.m_viewViewport1280x768MenuItem,
            this.m_viewViewport1280x1024MenuItem,
            this.m_viewViewport1600x1200MenuItem,
            this.m_viewViewport1920x1080MenuItem,
            this.m_viewViewport1920x1200MenuItem});
            this.m_viewViewportMenuItem.Image = global::tIDE.Properties.Resources.ViewViewport;
            this.m_viewViewportMenuItem.Name = "m_viewViewportMenuItem";
            resources.ApplyResources(this.m_viewViewportMenuItem, "m_viewViewportMenuItem");
            // 
            // m_viewViewportScaleToWindowMenuItem
            // 
            this.m_viewViewportScaleToWindowMenuItem.Checked = true;
            this.m_viewViewportScaleToWindowMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_viewViewportScaleToWindowMenuItem.Name = "m_viewViewportScaleToWindowMenuItem";
            resources.ApplyResources(this.m_viewViewportScaleToWindowMenuItem, "m_viewViewportScaleToWindowMenuItem");
            this.m_viewViewportScaleToWindowMenuItem.Tag = "Scale";
            this.m_viewViewportScaleToWindowMenuItem.Click += new System.EventHandler(this.OnViewViewportScaleToWindow);
            // 
            // m_viewViewport320x200MenuItem
            // 
            this.m_viewViewport320x200MenuItem.Name = "m_viewViewport320x200MenuItem";
            resources.ApplyResources(this.m_viewViewport320x200MenuItem, "m_viewViewport320x200MenuItem");
            this.m_viewViewport320x200MenuItem.Tag = "320 x 200";
            this.m_viewViewport320x200MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport320x240MenuItem
            // 
            this.m_viewViewport320x240MenuItem.Name = "m_viewViewport320x240MenuItem";
            resources.ApplyResources(this.m_viewViewport320x240MenuItem, "m_viewViewport320x240MenuItem");
            this.m_viewViewport320x240MenuItem.Tag = "320 x 240";
            this.m_viewViewport320x240MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport640x480MenuItem
            // 
            this.m_viewViewport640x480MenuItem.Name = "m_viewViewport640x480MenuItem";
            resources.ApplyResources(this.m_viewViewport640x480MenuItem, "m_viewViewport640x480MenuItem");
            this.m_viewViewport640x480MenuItem.Tag = "640 x 480";
            this.m_viewViewport640x480MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport800x600MenuItem
            // 
            this.m_viewViewport800x600MenuItem.Name = "m_viewViewport800x600MenuItem";
            resources.ApplyResources(this.m_viewViewport800x600MenuItem, "m_viewViewport800x600MenuItem");
            this.m_viewViewport800x600MenuItem.Tag = "800 x 600";
            this.m_viewViewport800x600MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport848x480MenuItem
            // 
            this.m_viewViewport848x480MenuItem.Name = "m_viewViewport848x480MenuItem";
            resources.ApplyResources(this.m_viewViewport848x480MenuItem, "m_viewViewport848x480MenuItem");
            this.m_viewViewport848x480MenuItem.Tag = "848 x 480";
            this.m_viewViewport848x480MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1024x768MenuItem
            // 
            this.m_viewViewport1024x768MenuItem.Name = "m_viewViewport1024x768MenuItem";
            resources.ApplyResources(this.m_viewViewport1024x768MenuItem, "m_viewViewport1024x768MenuItem");
            this.m_viewViewport1024x768MenuItem.Tag = "1024 x 768";
            this.m_viewViewport1024x768MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1280x720MenuItem
            // 
            this.m_viewViewport1280x720MenuItem.Name = "m_viewViewport1280x720MenuItem";
            resources.ApplyResources(this.m_viewViewport1280x720MenuItem, "m_viewViewport1280x720MenuItem");
            this.m_viewViewport1280x720MenuItem.Tag = "1280 x 720";
            this.m_viewViewport1280x720MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1280x768MenuItem
            // 
            this.m_viewViewport1280x768MenuItem.Name = "m_viewViewport1280x768MenuItem";
            resources.ApplyResources(this.m_viewViewport1280x768MenuItem, "m_viewViewport1280x768MenuItem");
            this.m_viewViewport1280x768MenuItem.Tag = "1280 x 768";
            this.m_viewViewport1280x768MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1280x1024MenuItem
            // 
            this.m_viewViewport1280x1024MenuItem.Name = "m_viewViewport1280x1024MenuItem";
            resources.ApplyResources(this.m_viewViewport1280x1024MenuItem, "m_viewViewport1280x1024MenuItem");
            this.m_viewViewport1280x1024MenuItem.Tag = "1280 x 1024";
            this.m_viewViewport1280x1024MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1600x1200MenuItem
            // 
            this.m_viewViewport1600x1200MenuItem.Name = "m_viewViewport1600x1200MenuItem";
            resources.ApplyResources(this.m_viewViewport1600x1200MenuItem, "m_viewViewport1600x1200MenuItem");
            this.m_viewViewport1600x1200MenuItem.Tag = "1600 x 1200";
            this.m_viewViewport1600x1200MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1920x1080MenuItem
            // 
            this.m_viewViewport1920x1080MenuItem.Name = "m_viewViewport1920x1080MenuItem";
            resources.ApplyResources(this.m_viewViewport1920x1080MenuItem, "m_viewViewport1920x1080MenuItem");
            this.m_viewViewport1920x1080MenuItem.Tag = "1920 x 1080";
            this.m_viewViewport1920x1080MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_viewViewport1920x1200MenuItem
            // 
            this.m_viewViewport1920x1200MenuItem.Name = "m_viewViewport1920x1200MenuItem";
            resources.ApplyResources(this.m_viewViewport1920x1200MenuItem, "m_viewViewport1920x1200MenuItem");
            this.m_viewViewport1920x1200MenuItem.Tag = "1920 x 1200";
            this.m_viewViewport1920x1200MenuItem.Click += new System.EventHandler(this.OnViewViewportSetSize);
            // 
            // m_mapMenuItem
            // 
            this.m_mapMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mapPropertiesMenuItem,
            this.m_mapStatisticsMenuItem});
            this.m_mapMenuItem.Image = global::tIDE.Properties.Resources.Map;
            this.m_mapMenuItem.Name = "m_mapMenuItem";
            resources.ApplyResources(this.m_mapMenuItem, "m_mapMenuItem");
            // 
            // m_mapPropertiesMenuItem
            // 
            this.m_mapPropertiesMenuItem.Image = global::tIDE.Properties.Resources.MapProperties;
            this.m_mapPropertiesMenuItem.Name = "m_mapPropertiesMenuItem";
            resources.ApplyResources(this.m_mapPropertiesMenuItem, "m_mapPropertiesMenuItem");
            this.m_mapPropertiesMenuItem.Click += new System.EventHandler(this.OnMapProperties);
            // 
            // m_mapStatisticsMenuItem
            // 
            this.m_mapStatisticsMenuItem.Image = global::tIDE.Properties.Resources.MapStatistics;
            this.m_mapStatisticsMenuItem.Name = "m_mapStatisticsMenuItem";
            resources.ApplyResources(this.m_mapStatisticsMenuItem, "m_mapStatisticsMenuItem");
            this.m_mapStatisticsMenuItem.Click += new System.EventHandler(this.OnMapStatistics);
            // 
            // m_layerMenuItem
            // 
            this.m_layerMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerNewMenuItem,
            this.m_layerPropertiesMenuItem,
            this.m_layerOffsetMenuItem,
            m_layerSeparator1,
            this.m_layerMakeInvisibleMenuItem,
            this.m_layerMakeVisibleMenuItem,
            m_layerSeparator2,
            this.m_layerBringForwardMenuItem,
            this.m_layerSendBackwardMenuItem,
            m_layerSeparator3,
            this.m_layerDeleteMenuItem});
            this.m_layerMenuItem.Image = global::tIDE.Properties.Resources.Layer;
            this.m_layerMenuItem.Name = "m_layerMenuItem";
            resources.ApplyResources(this.m_layerMenuItem, "m_layerMenuItem");
            // 
            // m_layerNewMenuItem
            // 
            this.m_layerNewMenuItem.Image = global::tIDE.Properties.Resources.LayerNew;
            this.m_layerNewMenuItem.Name = "m_layerNewMenuItem";
            resources.ApplyResources(this.m_layerNewMenuItem, "m_layerNewMenuItem");
            this.m_layerNewMenuItem.Click += new System.EventHandler(this.OnLayerNew);
            // 
            // m_layerPropertiesMenuItem
            // 
            resources.ApplyResources(this.m_layerPropertiesMenuItem, "m_layerPropertiesMenuItem");
            this.m_layerPropertiesMenuItem.Image = global::tIDE.Properties.Resources.LayerProperties;
            this.m_layerPropertiesMenuItem.Name = "m_layerPropertiesMenuItem";
            this.m_layerPropertiesMenuItem.Click += new System.EventHandler(this.OnLayerProperties);
            // 
            // m_layerOffsetMenuItem
            // 
            resources.ApplyResources(this.m_layerOffsetMenuItem, "m_layerOffsetMenuItem");
            this.m_layerOffsetMenuItem.Image = global::tIDE.Properties.Resources.LayerOffset;
            this.m_layerOffsetMenuItem.Name = "m_layerOffsetMenuItem";
            this.m_layerOffsetMenuItem.Click += new System.EventHandler(this.OnLayerOffset);
            // 
            // m_layerSeparator1
            // 
            m_layerSeparator1.Name = "m_layerSeparator1";
            resources.ApplyResources(m_layerSeparator1, "m_layerSeparator1");
            // 
            // m_layerMakeInvisibleMenuItem
            // 
            resources.ApplyResources(this.m_layerMakeInvisibleMenuItem, "m_layerMakeInvisibleMenuItem");
            this.m_layerMakeInvisibleMenuItem.Image = global::tIDE.Properties.Resources.LayerInvisible;
            this.m_layerMakeInvisibleMenuItem.Name = "m_layerMakeInvisibleMenuItem";
            this.m_layerMakeInvisibleMenuItem.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerMakeVisibleMenuItem
            // 
            resources.ApplyResources(this.m_layerMakeVisibleMenuItem, "m_layerMakeVisibleMenuItem");
            this.m_layerMakeVisibleMenuItem.Image = global::tIDE.Properties.Resources.LayerVisible;
            this.m_layerMakeVisibleMenuItem.Name = "m_layerMakeVisibleMenuItem";
            this.m_layerMakeVisibleMenuItem.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerSeparator2
            // 
            m_layerSeparator2.Name = "m_layerSeparator2";
            resources.ApplyResources(m_layerSeparator2, "m_layerSeparator2");
            // 
            // m_layerBringForwardMenuItem
            // 
            resources.ApplyResources(this.m_layerBringForwardMenuItem, "m_layerBringForwardMenuItem");
            this.m_layerBringForwardMenuItem.Image = global::tIDE.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardMenuItem.Name = "m_layerBringForwardMenuItem";
            this.m_layerBringForwardMenuItem.Click += new System.EventHandler(this.OnLayerBringForward);
            // 
            // m_layerSendBackwardMenuItem
            // 
            resources.ApplyResources(this.m_layerSendBackwardMenuItem, "m_layerSendBackwardMenuItem");
            this.m_layerSendBackwardMenuItem.Image = global::tIDE.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardMenuItem.Name = "m_layerSendBackwardMenuItem";
            this.m_layerSendBackwardMenuItem.Click += new System.EventHandler(this.OnLayerSendBackward);
            // 
            // m_layerSeparator3
            // 
            m_layerSeparator3.Name = "m_layerSeparator3";
            resources.ApplyResources(m_layerSeparator3, "m_layerSeparator3");
            // 
            // m_layerDeleteMenuItem
            // 
            resources.ApplyResources(this.m_layerDeleteMenuItem, "m_layerDeleteMenuItem");
            this.m_layerDeleteMenuItem.Image = global::tIDE.Properties.Resources.LayerDelete;
            this.m_layerDeleteMenuItem.Name = "m_layerDeleteMenuItem";
            this.m_layerDeleteMenuItem.Click += new System.EventHandler(this.OnLayerDelete);
            // 
            // m_tileSheetMenuItem
            // 
            this.m_tileSheetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewMenuItem,
            this.m_tileSheetPropertiesMenuItem,
            this.m_tileSheetAutoTilesMenuItem,
            this.m_tileSheetSeparator1,
            this.m_tileSheetAutoUpdateEnableMenuItem,
            this.m_tileSheetAutoUpdateDisableMenuItem,
            this.m_tileSheetEditImageSourceMenuItem,
            this.m_tileSheetSeparator2,
            this.m_tileSheetRemoveDependenciesMenuItem,
            this.m_tileSheetDeleteMenuItem});
            this.m_tileSheetMenuItem.Image = global::tIDE.Properties.Resources.TileSheet;
            this.m_tileSheetMenuItem.Name = "m_tileSheetMenuItem";
            resources.ApplyResources(this.m_tileSheetMenuItem, "m_tileSheetMenuItem");
            // 
            // m_tileSheetNewMenuItem
            // 
            this.m_tileSheetNewMenuItem.Image = global::tIDE.Properties.Resources.TileSheetNew;
            this.m_tileSheetNewMenuItem.Name = "m_tileSheetNewMenuItem";
            resources.ApplyResources(this.m_tileSheetNewMenuItem, "m_tileSheetNewMenuItem");
            this.m_tileSheetNewMenuItem.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetPropertiesMenuItem
            // 
            resources.ApplyResources(this.m_tileSheetPropertiesMenuItem, "m_tileSheetPropertiesMenuItem");
            this.m_tileSheetPropertiesMenuItem.Image = global::tIDE.Properties.Resources.TileSheetProperties;
            this.m_tileSheetPropertiesMenuItem.Name = "m_tileSheetPropertiesMenuItem";
            this.m_tileSheetPropertiesMenuItem.Click += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // m_tileSheetAutoTilesMenuItem
            // 
            resources.ApplyResources(this.m_tileSheetAutoTilesMenuItem, "m_tileSheetAutoTilesMenuItem");
            this.m_tileSheetAutoTilesMenuItem.Image = global::tIDE.Properties.Resources.TileSheetAutoTiles;
            this.m_tileSheetAutoTilesMenuItem.Name = "m_tileSheetAutoTilesMenuItem";
            this.m_tileSheetAutoTilesMenuItem.Click += new System.EventHandler(this.OnTileSheetAutoTiles);
            // 
            // m_tileSheetSeparator1
            // 
            this.m_tileSheetSeparator1.Name = "m_tileSheetSeparator1";
            resources.ApplyResources(this.m_tileSheetSeparator1, "m_tileSheetSeparator1");
            // 
            // m_tileSheetAutoUpdateEnableMenuItem
            // 
            this.m_tileSheetAutoUpdateEnableMenuItem.Image = global::tIDE.Properties.Resources.TileSheetAutoUpdateEnable;
            this.m_tileSheetAutoUpdateEnableMenuItem.Name = "m_tileSheetAutoUpdateEnableMenuItem";
            resources.ApplyResources(this.m_tileSheetAutoUpdateEnableMenuItem, "m_tileSheetAutoUpdateEnableMenuItem");
            this.m_tileSheetAutoUpdateEnableMenuItem.Click += new System.EventHandler(this.OnTileSheetAutoUpdate);
            // 
            // m_tileSheetAutoUpdateDisableMenuItem
            // 
            this.m_tileSheetAutoUpdateDisableMenuItem.Image = global::tIDE.Properties.Resources.TileSheetAutoUpdateDisable;
            this.m_tileSheetAutoUpdateDisableMenuItem.Name = "m_tileSheetAutoUpdateDisableMenuItem";
            resources.ApplyResources(this.m_tileSheetAutoUpdateDisableMenuItem, "m_tileSheetAutoUpdateDisableMenuItem");
            this.m_tileSheetAutoUpdateDisableMenuItem.Click += new System.EventHandler(this.OnTileSheetAutoUpdate);
            // 
            // m_tileSheetEditImageSourceMenuItem
            // 
            resources.ApplyResources(this.m_tileSheetEditImageSourceMenuItem, "m_tileSheetEditImageSourceMenuItem");
            this.m_tileSheetEditImageSourceMenuItem.Image = global::tIDE.Properties.Resources.TileSheetEditImageSource;
            this.m_tileSheetEditImageSourceMenuItem.Name = "m_tileSheetEditImageSourceMenuItem";
            this.m_tileSheetEditImageSourceMenuItem.Click += new System.EventHandler(this.OnTileSheetEditImageSource);
            // 
            // m_tileSheetSeparator2
            // 
            this.m_tileSheetSeparator2.Name = "m_tileSheetSeparator2";
            resources.ApplyResources(this.m_tileSheetSeparator2, "m_tileSheetSeparator2");
            // 
            // m_tileSheetRemoveDependenciesMenuItem
            // 
            resources.ApplyResources(this.m_tileSheetRemoveDependenciesMenuItem, "m_tileSheetRemoveDependenciesMenuItem");
            this.m_tileSheetRemoveDependenciesMenuItem.Image = global::tIDE.Properties.Resources.TileSheetRemoveDependencies;
            this.m_tileSheetRemoveDependenciesMenuItem.Name = "m_tileSheetRemoveDependenciesMenuItem";
            this.m_tileSheetRemoveDependenciesMenuItem.Click += new System.EventHandler(this.OnTileSheetRemoveDependencies);
            // 
            // m_tileSheetDeleteMenuItem
            // 
            resources.ApplyResources(this.m_tileSheetDeleteMenuItem, "m_tileSheetDeleteMenuItem");
            this.m_tileSheetDeleteMenuItem.Image = global::tIDE.Properties.Resources.TileSheetDelete;
            this.m_tileSheetDeleteMenuItem.Name = "m_tileSheetDeleteMenuItem";
            this.m_tileSheetDeleteMenuItem.Click += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // m_pluginMenuItem
            // 
            this.m_pluginMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_pluginReloadMenuItem,
            this.toolStripSeparator1,
            this.m_pluginNoneLoadedMenuItem});
            this.m_pluginMenuItem.Image = global::tIDE.Properties.Resources.Plugin;
            this.m_pluginMenuItem.Name = "m_pluginMenuItem";
            resources.ApplyResources(this.m_pluginMenuItem, "m_pluginMenuItem");
            // 
            // m_pluginReloadMenuItem
            // 
            this.m_pluginReloadMenuItem.Image = global::tIDE.Properties.Resources.PluginReload;
            this.m_pluginReloadMenuItem.Name = "m_pluginReloadMenuItem";
            resources.ApplyResources(this.m_pluginReloadMenuItem, "m_pluginReloadMenuItem");
            this.m_pluginReloadMenuItem.Click += new System.EventHandler(this.OnPluginsReload);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // m_pluginNoneLoadedMenuItem
            // 
            resources.ApplyResources(this.m_pluginNoneLoadedMenuItem, "m_pluginNoneLoadedMenuItem");
            this.m_pluginNoneLoadedMenuItem.Name = "m_pluginNoneLoadedMenuItem";
            // 
            // m_helpMenuItem
            // 
            this.m_helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_helpContentsMenuItem,
            this.m_helpIndexMenuItem,
            this.m_helpSearchMenuItem,
            this.toolStripSeparator5,
            this.m_helpAboutMenuItem});
            this.m_helpMenuItem.Image = global::tIDE.Properties.Resources.Help;
            this.m_helpMenuItem.Name = "m_helpMenuItem";
            resources.ApplyResources(this.m_helpMenuItem, "m_helpMenuItem");
            // 
            // m_helpContentsMenuItem
            // 
            this.m_helpContentsMenuItem.Image = global::tIDE.Properties.Resources.HelpContents;
            this.m_helpContentsMenuItem.Name = "m_helpContentsMenuItem";
            resources.ApplyResources(this.m_helpContentsMenuItem, "m_helpContentsMenuItem");
            this.m_helpContentsMenuItem.Click += new System.EventHandler(this.OnHelpContents);
            // 
            // m_helpIndexMenuItem
            // 
            this.m_helpIndexMenuItem.Image = global::tIDE.Properties.Resources.HelpIndex;
            this.m_helpIndexMenuItem.Name = "m_helpIndexMenuItem";
            resources.ApplyResources(this.m_helpIndexMenuItem, "m_helpIndexMenuItem");
            this.m_helpIndexMenuItem.Click += new System.EventHandler(this.OnHelpIndex);
            // 
            // m_helpSearchMenuItem
            // 
            this.m_helpSearchMenuItem.Image = global::tIDE.Properties.Resources.HelpSearch;
            this.m_helpSearchMenuItem.Name = "m_helpSearchMenuItem";
            resources.ApplyResources(this.m_helpSearchMenuItem, "m_helpSearchMenuItem");
            this.m_helpSearchMenuItem.Click += new System.EventHandler(this.OnHelpSearch);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // m_helpAboutMenuItem
            // 
            this.m_helpAboutMenuItem.Image = global::tIDE.Properties.Resources.HelpAbout;
            this.m_helpAboutMenuItem.Name = "m_helpAboutMenuItem";
            resources.ApplyResources(this.m_helpAboutMenuItem, "m_helpAboutMenuItem");
            this.m_helpAboutMenuItem.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // m_layerToolStrip
            // 
            resources.ApplyResources(this.m_layerToolStrip, "m_layerToolStrip");
            this.m_layerToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_layerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerNewButton,
            this.m_layerPropertiesButton,
            this.m_layerOffsetButton,
            m_layerToolStripSeparator1,
            this.m_layerMakeInvisibileButton,
            this.m_layerMakeVisibileButton,
            m_layerToolStripSeparator2,
            this.m_layerBringForwardButton,
            this.m_layerSendBackwardButton,
            m_layerToolStripSeparator3,
            this.m_layerDeleteButton});
            this.m_layerToolStrip.Name = "m_layerToolStrip";
            // 
            // m_layerNewButton
            // 
            this.m_layerNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerNewButton.Image = global::tIDE.Properties.Resources.LayerNew;
            resources.ApplyResources(this.m_layerNewButton, "m_layerNewButton");
            this.m_layerNewButton.Name = "m_layerNewButton";
            this.m_layerNewButton.Click += new System.EventHandler(this.OnLayerNew);
            // 
            // m_layerPropertiesButton
            // 
            this.m_layerPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerPropertiesButton, "m_layerPropertiesButton");
            this.m_layerPropertiesButton.Image = global::tIDE.Properties.Resources.LayerProperties;
            this.m_layerPropertiesButton.Name = "m_layerPropertiesButton";
            this.m_layerPropertiesButton.Click += new System.EventHandler(this.OnLayerProperties);
            // 
            // m_layerOffsetButton
            // 
            this.m_layerOffsetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerOffsetButton, "m_layerOffsetButton");
            this.m_layerOffsetButton.Image = global::tIDE.Properties.Resources.LayerOffset;
            this.m_layerOffsetButton.Name = "m_layerOffsetButton";
            this.m_layerOffsetButton.Click += new System.EventHandler(this.OnLayerOffset);
            // 
            // m_layerToolStripSeparator1
            // 
            m_layerToolStripSeparator1.Name = "m_layerToolStripSeparator1";
            resources.ApplyResources(m_layerToolStripSeparator1, "m_layerToolStripSeparator1");
            // 
            // m_layerMakeInvisibileButton
            // 
            this.m_layerMakeInvisibileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerMakeInvisibileButton, "m_layerMakeInvisibileButton");
            this.m_layerMakeInvisibileButton.Image = global::tIDE.Properties.Resources.LayerInvisible;
            this.m_layerMakeInvisibileButton.Name = "m_layerMakeInvisibileButton";
            this.m_layerMakeInvisibileButton.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerMakeVisibileButton
            // 
            this.m_layerMakeVisibileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerMakeVisibileButton, "m_layerMakeVisibileButton");
            this.m_layerMakeVisibileButton.Image = global::tIDE.Properties.Resources.LayerVisible;
            this.m_layerMakeVisibileButton.Name = "m_layerMakeVisibileButton";
            this.m_layerMakeVisibileButton.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerToolStripSeparator2
            // 
            m_layerToolStripSeparator2.Name = "m_layerToolStripSeparator2";
            resources.ApplyResources(m_layerToolStripSeparator2, "m_layerToolStripSeparator2");
            // 
            // m_layerBringForwardButton
            // 
            this.m_layerBringForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerBringForwardButton, "m_layerBringForwardButton");
            this.m_layerBringForwardButton.Image = global::tIDE.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardButton.Name = "m_layerBringForwardButton";
            this.m_layerBringForwardButton.Click += new System.EventHandler(this.OnLayerBringForward);
            // 
            // m_layerSendBackwardButton
            // 
            this.m_layerSendBackwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerSendBackwardButton, "m_layerSendBackwardButton");
            this.m_layerSendBackwardButton.Image = global::tIDE.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardButton.Name = "m_layerSendBackwardButton";
            this.m_layerSendBackwardButton.Click += new System.EventHandler(this.OnLayerSendBackward);
            // 
            // m_layerToolStripSeparator3
            // 
            m_layerToolStripSeparator3.Name = "m_layerToolStripSeparator3";
            resources.ApplyResources(m_layerToolStripSeparator3, "m_layerToolStripSeparator3");
            // 
            // m_layerDeleteButton
            // 
            this.m_layerDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.m_layerDeleteButton, "m_layerDeleteButton");
            this.m_layerDeleteButton.Image = global::tIDE.Properties.Resources.LayerDelete;
            this.m_layerDeleteButton.Name = "m_layerDeleteButton";
            this.m_layerDeleteButton.Click += new System.EventHandler(this.OnLayerDelete);
            // 
            // m_loadErrorMessageBox
            // 
            resources.ApplyResources(this.m_loadErrorMessageBox, "m_loadErrorMessageBox");
            this.m_loadErrorMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_loadErrorMessageBox.Owner = this;
            // 
            // m_saveErrorMessageBox
            // 
            resources.ApplyResources(this.m_saveErrorMessageBox, "m_saveErrorMessageBox");
            this.m_saveErrorMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_saveErrorMessageBox.Owner = this;
            // 
            // m_unsavedMessageBox
            // 
            this.m_unsavedMessageBox.Buttons = System.Windows.Forms.MessageBoxButtons.YesNoCancel;
            resources.ApplyResources(this.m_unsavedMessageBox, "m_unsavedMessageBox");
            this.m_unsavedMessageBox.Icon = tIDE.Controls.MessageIcon.Warning;
            this.m_unsavedMessageBox.Owner = this;
            // 
            // m_hasDependencyMessageBox
            // 
            resources.ApplyResources(this.m_hasDependencyMessageBox, "m_hasDependencyMessageBox");
            this.m_hasDependencyMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_hasDependencyMessageBox.Owner = this;
            // 
            // m_dependencyRemovedMessageBox
            // 
            resources.ApplyResources(this.m_dependencyRemovedMessageBox, "m_dependencyRemovedMessageBox");
            this.m_dependencyRemovedMessageBox.Icon = tIDE.Controls.MessageIcon.Information;
            this.m_dependencyRemovedMessageBox.Owner = this;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_toolStripContainer);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.m_menuStrip;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormClosing);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.ResizeEnd += new System.EventHandler(this.OnMainFormResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.m_toolStripContainer.ContentPanel.ResumeLayout(false);
            this.m_toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.m_toolStripContainer.TopToolStripPanel.PerformLayout();
            this.m_toolStripContainer.ResumeLayout(false);
            this.m_toolStripContainer.PerformLayout();
            this.m_splitContainerLeftRight.Panel1.ResumeLayout(false);
            this.m_splitContainerLeftRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainerLeftRight)).EndInit();
            this.m_splitContainerLeftRight.ResumeLayout(false);
            this.m_splitContainerVertical.Panel1.ResumeLayout(false);
            this.m_splitContainerVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainerVertical)).EndInit();
            this.m_splitContainerVertical.ResumeLayout(false);
            this.m_toolStripContainerInner.BottomToolStripPanel.ResumeLayout(false);
            this.m_toolStripContainerInner.BottomToolStripPanel.PerformLayout();
            this.m_toolStripContainerInner.ContentPanel.ResumeLayout(false);
            this.m_toolStripContainerInner.RightToolStripPanel.ResumeLayout(false);
            this.m_toolStripContainerInner.RightToolStripPanel.PerformLayout();
            this.m_toolStripContainerInner.ResumeLayout(false);
            this.m_toolStripContainerInner.PerformLayout();
            this.m_statusStrip.ResumeLayout(false);
            this.m_statusStrip.PerformLayout();
            this.m_toolsToolStrip.ResumeLayout(false);
            this.m_toolsToolStrip.PerformLayout();
            this.m_editToolStrip.ResumeLayout(false);
            this.m_editToolStrip.PerformLayout();
            this.m_tileSheetToolStrip.ResumeLayout(false);
            this.m_tileSheetToolStrip.PerformLayout();
            this.m_viewToolStrip.ResumeLayout(false);
            this.m_viewToolStrip.PerformLayout();
            this.m_mapToolStrip.ResumeLayout(false);
            this.m_mapToolStrip.PerformLayout();
            this.m_fileToolStrip.ResumeLayout(false);
            this.m_fileToolStrip.PerformLayout();
            this.m_menuStrip.ResumeLayout(false);
            this.m_menuStrip.PerformLayout();
            this.m_layerToolStrip.ResumeLayout(false);
            this.m_layerToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer m_toolStripContainer;
        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileSaveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editUndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editRedoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editCutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editPasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editSelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpContentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpIndexMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpAboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerDeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetDeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerBringForwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerSendBackwardMenuItem;
        private Controls.MapTreeView m_mapTreeView;
        private System.Windows.Forms.ToolStrip m_editToolStrip;
        private System.Windows.Forms.ToolStripButton m_editCutButton;
        private System.Windows.Forms.ToolStripButton m_editCopyButton;
        private System.Windows.Forms.ToolStripButton m_editPasteButton;
        private System.Windows.Forms.ToolStripButton m_editUndoButton;
        private System.Windows.Forms.ToolStripButton m_editRedoButton;
        private System.Windows.Forms.ToolStripSeparator m_editToolStripSeparator1;
        private System.Windows.Forms.SplitContainer m_splitContainerLeftRight;
        private tIDE.Controls.TilePicker m_tilePicker;
        private tIDE.Controls.MapPanel m_mapPanel;
        private System.Windows.Forms.ToolStrip m_mapToolStrip;
        private System.Windows.Forms.ToolStripButton m_mapPropertiesButton;
        private System.Windows.Forms.ToolStrip m_tileSheetToolStrip;
        private System.Windows.Forms.ToolStripButton m_tileSheetNewButton;
        private System.Windows.Forms.ToolStripButton m_tileSheetPropertiesButton;
        private System.Windows.Forms.ToolStripButton m_tileSheetDeleteButton;
        private System.Windows.Forms.ToolStrip m_layerToolStrip;
        private System.Windows.Forms.ToolStripButton m_layerNewButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy3MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy4MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy5MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy6MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy7MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy8MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy9MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy10MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomInMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomOutMenuItem;
        private System.Windows.Forms.ToolStrip m_viewToolStrip;
        private System.Windows.Forms.ToolStripButton m_viewZoomInButton;
        private System.Windows.Forms.ToolStripButton m_viewZoomOutButton;
        private System.Windows.Forms.ToolStripButton m_layerPropertiesButton;
        private System.Windows.Forms.ToolStripButton m_layerBringForwardButton;
        private System.Windows.Forms.ToolStripButton m_layerSendBackwardButton;
        private System.Windows.Forms.ToolStripButton m_layerDeleteButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_viewSeparator1;
        private System.Windows.Forms.ToolStripButton m_viewShowTileGuidesButton;
        private System.Windows.Forms.ToolStripButton m_viewLayersShowAllButton;
        private System.Windows.Forms.ToolStripComboBox m_viewZoomComboBox;
        private System.Windows.Forms.ToolStripMenuItem m_editClearSelectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editInvertSelectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editDeleteMenuItem;
        private System.Windows.Forms.ToolStripButton m_editDeleteButton;
        private System.Windows.Forms.ToolStripSeparator m_editToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_editSelectAllButton;
        private System.Windows.Forms.ToolStripButton m_editClearSelectionButton;
        private System.Windows.Forms.ToolStripButton m_editInvertSelectionButton;
        private System.Windows.Forms.ToolStripMenuItem m_pluginMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_pluginReloadMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip m_toolsToolStrip;
        private System.Windows.Forms.ToolStripButton m_toolsSelectButton;
        private System.Windows.Forms.ToolStripButton m_toolsSingleTileButton;
        private System.Windows.Forms.ToolStripButton m_toolsTileBlockButton;
        private System.Windows.Forms.ToolStripButton m_toolsEraserButton;
        private System.Windows.Forms.ToolStripButton m_toolsDropperButton;
        private tIDE.Controls.CustomToolStripSplitButton m_toolsTileBrushButton;
        private System.Windows.Forms.ToolStripContainer m_toolStripContainerInner;
        private System.Windows.Forms.ToolStripMenuItem m_editMakeTileBrushMenuItem;
        private System.Windows.Forms.ToolStripButton m_editMakeTileBrushButton;
        private System.Windows.Forms.ToolStripMenuItem m_editManageTileBrushesMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_editToolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_editManageTileBrushesButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewFullScreenMenuItem;
        private System.Windows.Forms.ToolStripButton m_viewFullScreenButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewLayersShowAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewShowTileGuidesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerMakeInvisibleMenuItem;
        private System.Windows.Forms.ToolStripButton m_layerMakeInvisibileButton;
        private System.Windows.Forms.ToolStrip m_fileToolStrip;
        private System.Windows.Forms.ToolStripButton m_fileNewButton;
        private System.Windows.Forms.ToolStripButton m_fileOpenButton;
        private System.Windows.Forms.ToolStripButton m_fileSaveButton;
        private System.Windows.Forms.ToolStripButton m_fileSaveAsButton;
        private System.Windows.Forms.StatusStrip m_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel m_tileLocationStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel m_tileSheetStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewportScaleToWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1920x1080MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport320x200MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport320x240MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1280x1024MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport640x480MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport848x480MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1024x768MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1280x720MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1280x768MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1920x1200MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport1600x1200MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewViewport800x600MenuItem;
        private System.Windows.Forms.ToolStripStatusLabel m_tileIndexStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel m_tilePropertiesStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetAutoUpdateEnableMenuItem;
        private System.Windows.Forms.ToolStripButton m_tileSheetAutoUpdateEnableButton;
        private System.Windows.Forms.ToolStripMenuItem m_mapStatisticsMenuItem;
        private System.Windows.Forms.ToolStripButton m_mapStatisticsButton;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetRemoveDependenciesMenuItem;
        private System.Windows.Forms.ToolStripButton m_tileSheetRemoveDependenciesButton;
        private System.Windows.Forms.ToolStripMenuItem m_filePageSetupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_filePrintMenuItem;
        private System.Windows.Forms.ToolStripButton m_filePageSetupButton;
        private System.Windows.Forms.ToolStripButton m_filePrintButton;
        private System.Windows.Forms.ToolStripMenuItem m_filePrintPreviewMenuItem;
        private System.Windows.Forms.ToolStripButton m_filePrintPreviewButton;
        private System.Windows.Forms.ToolStripMenuItem m_fileRecentFilesMenuItem;
        private System.Windows.Forms.ToolStripButton m_toolsTextureButton;
        private System.Windows.Forms.SplitContainer m_splitContainerVertical;
        private System.Windows.Forms.ToolStripSeparator m_tileSheetToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator m_viewSeparator2;
        private System.Windows.Forms.ToolStripSeparator m_fileToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator m_editMenuSeparator1;
        private System.Windows.Forms.ToolStripSeparator m_editMenuSeparator2;
        private System.Windows.Forms.ToolStripSeparator m_editMenuSeparator3;
        private System.Windows.Forms.ToolStripSeparator m_viewMenuSeparator1;
        private System.Windows.Forms.ToolStripSeparator m_viewMenuSeparator2;
        private System.Windows.Forms.ToolStripSeparator m_tileSheetSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel m_viewZoomLabel;
        private System.Windows.Forms.ToolStripSeparator m_tileSheetSeparator2;
        private System.Windows.Forms.ToolStripSeparator m_tileSheetToolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator m_fileSeparator3;
        private System.Windows.Forms.ToolStripSeparator m_fileToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_editHistoryButton;
        private System.Windows.Forms.ToolStripMenuItem m_editHistoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetAutoTilesMenuItem;
        private System.Windows.Forms.ToolStripButton m_tileSheetAutoTilesButton;
        private System.Windows.Forms.ToolStripMenuItem m_fileOptionsMenuItem;
        private System.Windows.Forms.ToolStripButton m_fileOptionsButton;
        private System.Windows.Forms.ToolStripMenuItem m_layerMakeVisibleMenuItem;
        private System.Windows.Forms.ToolStripButton m_layerMakeVisibileButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewWindowedMenuItem;
        private System.Windows.Forms.ToolStripButton m_viewWindowedButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewLayersHighlightSelectedMenuItem;
        private System.Windows.Forms.ToolStripButton m_viewLayersHighlightSelectedButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewHideTileGuidesMenuItem;
        private System.Windows.Forms.ToolStripButton m_viewHideTileGuidesButton;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetAutoUpdateDisableMenuItem;
        private System.Windows.Forms.ToolStripButton m_tileSheetAutoUpdateDisableButton;
        private System.Windows.Forms.ToolStripMenuItem m_pluginNoneLoadedMenuItem;
        private tIDE.Controls.CustomMessageBox m_loadErrorMessageBox;
        private tIDE.Controls.CustomMessageBox m_saveErrorMessageBox;
        private tIDE.Controls.CustomMessageBox m_unsavedMessageBox;
        private tIDE.Controls.CustomMessageBox m_hasDependencyMessageBox;
        private tIDE.Controls.CustomMessageBox m_dependencyRemovedMessageBox;
        private System.Windows.Forms.ToolStripMenuItem m_layerOffsetMenuItem;
        private System.Windows.Forms.ToolStripButton m_layerOffsetButton;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetEditImageSourceMenuItem;
        private System.Windows.Forms.ToolStripButton m_tileSheetEditImageSourceButton;
        private System.Windows.Forms.ToolStripButton m_toolsFloodFillButton;
    }
}