﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;
using xTile.Layers;

using tIDE.Commands;

namespace tIDE.Dialogs
{
    public partial class LayerPropertiesDialog : Form
    {
        #region Private Variables

        private Layer m_layer;
        private bool m_isNewLayer;

        #endregion

        #region Private Methods

        private void MarkAsModified()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = true;
            m_buttonClose.Visible = false;
            m_buttonCancel.Visible = true;
        }

        private void MarkAsApplied()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = false;
            m_buttonClose.Visible = true;
            m_buttonCancel.Visible = false;
        }

        private void OnFieldChanged(object sender, EventArgs e)
        {
            MarkAsModified();

            Size newLayerSize = new Size((int)m_numericLayerWidth.Value, (int)m_numericLayerHeight.Value);
            m_lblAlignment.Visible = m_alignmentButton.Visible = 
                !m_isNewLayer && m_layer.LayerSize != newLayerSize;
        }

        private void OnPropertyChangedOrDeleted(object sender,
            tIDE.Controls.CustomPropertyEventArgs customPropertyEventArgs)
        {
            MarkAsModified();
        }

        private bool IsDuplicateLayerId(string newLayerId)
        {
            foreach (Layer layer in m_layer.Map.Layers)
            {
                if (layer == m_layer)
                    continue;
                if (newLayerId == layer.Id)
                    return true;
            }
            return false;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_layer.Id;
            m_textBoxDescription.Text = m_layer.Description;

            m_numericLayerWidth.Value = m_layer.LayerWidth;
            m_numericLayerHeight.Value = m_layer.LayerHeight;
            m_numericTileWidth.Value = m_layer.TileWidth;
            m_numericTileHeight.Value = m_layer.TileHeight;

            m_checkBoxVisible.Checked = m_layer.Visible;

            m_customPropertyGrid.LoadProperties(m_layer);

            if (m_isNewLayer)
                MarkAsModified();
            else
                MarkAsApplied();
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            string newLayerId = m_textBoxId.Text;

            if (IsDuplicateLayerId(newLayerId))
            {
                m_duplicateIdMessageBox.Show();
                return;
            }

            OnDialogApply(sender, eventArgs);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnDialogApply(object sender, EventArgs e)
        {
            string newLayerId = m_textBoxId.Text;

            if (IsDuplicateLayerId(newLayerId))
            {
                m_duplicateIdMessageBox.Show();
                return;
            }

            Size newLayerSize = new Size((int)m_numericLayerWidth.Value, (int)m_numericLayerHeight.Value);
            Size newTileSize = new Size((int)m_numericTileWidth.Value, (int)m_numericTileHeight.Value);

            Command command = null;

            if (m_isNewLayer)
            {
                m_layer.Id = newLayerId;
                m_layer.Description = m_textBoxDescription.Text;
                m_layer.LayerSize = newLayerSize;
                m_layer.TileSize = newTileSize;
                command = new LayerNewCommand(m_layer.Map, m_layer);

                m_isNewLayer = false;
            }
            else
                command = new LayerPropertiesCommand(m_layer, newLayerId, m_textBoxDescription.Text,
                    newLayerSize, newTileSize, m_checkBoxVisible.Checked,
                    m_customPropertyGrid.NewProperties, m_alignmentButton.Alignment);

            CommandHistory.Instance.Do(command);

            MarkAsApplied();
        }

        #endregion

        #region Public Methods

        public LayerPropertiesDialog(Layer layer, bool isNewLayer)
        {
            InitializeComponent();

            m_layer = layer;
            m_isNewLayer = isNewLayer;
        }

        #endregion
    }
}
