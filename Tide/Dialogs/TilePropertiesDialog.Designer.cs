﻿namespace tIDE.Dialogs
{
    partial class TilePropertiesDialog
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
            System.Windows.Forms.Label m_labelTileIndex;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilePropertiesDialog));
            System.Windows.Forms.Label m_labelTileSheet;
            System.Windows.Forms.Label m_labelBlendMode;
            System.Windows.Forms.Label m_labelId;
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.m_tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_customTabControl = new tIDE.Controls.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_textBoxTileIndex = new System.Windows.Forms.TextBox();
            this.m_textBoxTileSheet = new System.Windows.Forms.TextBox();
            this.m_comboBoxBlendMode = new System.Windows.Forms.ComboBox();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new tIDE.Controls.CustomPropertyGrid();
            m_labelTileIndex = new System.Windows.Forms.Label();
            m_labelTileSheet = new System.Windows.Forms.Label();
            m_labelBlendMode = new System.Windows.Forms.Label();
            m_labelId = new System.Windows.Forms.Label();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.m_tabCustomProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelTileIndex
            // 
            m_labelTileIndex.AccessibleDescription = null;
            m_labelTileIndex.AccessibleName = null;
            resources.ApplyResources(m_labelTileIndex, "m_labelTileIndex");
            m_labelTileIndex.Font = null;
            m_labelTileIndex.Name = "m_labelTileIndex";
            // 
            // m_labelTileSheet
            // 
            m_labelTileSheet.AccessibleDescription = null;
            m_labelTileSheet.AccessibleName = null;
            resources.ApplyResources(m_labelTileSheet, "m_labelTileSheet");
            m_labelTileSheet.Font = null;
            m_labelTileSheet.Name = "m_labelTileSheet";
            // 
            // m_labelBlendMode
            // 
            m_labelBlendMode.AccessibleDescription = null;
            m_labelBlendMode.AccessibleName = null;
            resources.ApplyResources(m_labelBlendMode, "m_labelBlendMode");
            m_labelBlendMode.Font = null;
            m_labelBlendMode.Name = "m_labelBlendMode";
            // 
            // m_labelId
            // 
            m_labelId.AccessibleDescription = null;
            m_labelId.AccessibleName = null;
            resources.ApplyResources(m_labelId, "m_labelId");
            m_labelId.Font = null;
            m_labelId.Name = "m_labelId";
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.AccessibleDescription = null;
            this.m_buttonOk.AccessibleName = null;
            resources.ApplyResources(this.m_buttonOk, "m_buttonOk");
            this.m_buttonOk.BackgroundImage = null;
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonOk.Font = null;
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.AccessibleDescription = null;
            this.m_buttonCancel.AccessibleName = null;
            resources.ApplyResources(this.m_buttonCancel, "m_buttonCancel");
            this.m_buttonCancel.BackgroundImage = null;
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Font = null;
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AccessibleDescription = null;
            this.checkBox1.AccessibleName = null;
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.BackgroundImage = null;
            this.checkBox1.Font = null;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.AccessibleDescription = null;
            this.m_buttonApply.AccessibleName = null;
            resources.ApplyResources(this.m_buttonApply, "m_buttonApply");
            this.m_buttonApply.BackgroundImage = null;
            this.m_buttonApply.Font = null;
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_buttonClose
            // 
            this.m_buttonClose.AccessibleDescription = null;
            this.m_buttonClose.AccessibleName = null;
            resources.ApplyResources(this.m_buttonClose, "m_buttonClose");
            this.m_buttonClose.BackgroundImage = null;
            this.m_buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonClose.Font = null;
            this.m_buttonClose.Name = "m_buttonClose";
            this.m_buttonClose.UseVisualStyleBackColor = true;
            // 
            // m_tabImageList
            // 
            this.m_tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_tabImageList.ImageStream")));
            this.m_tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_tabImageList.Images.SetKeyName(0, "TileProperties.png");
            this.m_tabImageList.Images.SetKeyName(1, "CustomProperties.png");
            // 
            // m_customTabControl
            // 
            this.m_customTabControl.AccessibleDescription = null;
            this.m_customTabControl.AccessibleName = null;
            resources.ApplyResources(this.m_customTabControl, "m_customTabControl");
            this.m_customTabControl.BackgroundImage = null;
            this.m_customTabControl.Controls.Add(this.m_tabGeneral);
            this.m_customTabControl.Controls.Add(this.m_tabCustomProperties);
            this.m_customTabControl.DisplayStyle = tIDE.Controls.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.m_customTabControl.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.m_customTabControl.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.m_customTabControl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.m_customTabControl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.m_customTabControl.DisplayStyleProvider.FocusTrack = false;
            this.m_customTabControl.DisplayStyleProvider.HotTrack = true;
            this.m_customTabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_customTabControl.DisplayStyleProvider.Opacity = 1F;
            this.m_customTabControl.DisplayStyleProvider.Overlap = 7;
            this.m_customTabControl.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            this.m_customTabControl.DisplayStyleProvider.ShowTabCloser = false;
            this.m_customTabControl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.m_customTabControl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.m_customTabControl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.m_customTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.m_customTabControl.Font = null;
            this.m_customTabControl.HotTrack = true;
            this.m_customTabControl.ImageList = this.m_tabImageList;
            this.m_customTabControl.Name = "m_customTabControl";
            this.m_customTabControl.SelectedIndex = 0;
            // 
            // m_tabGeneral
            // 
            this.m_tabGeneral.AccessibleDescription = null;
            this.m_tabGeneral.AccessibleName = null;
            resources.ApplyResources(this.m_tabGeneral, "m_tabGeneral");
            this.m_tabGeneral.BackColor = System.Drawing.Color.Transparent;
            this.m_tabGeneral.BackgroundImage = null;
            this.m_tabGeneral.Controls.Add(this.m_textBoxTileIndex);
            this.m_tabGeneral.Controls.Add(m_labelTileIndex);
            this.m_tabGeneral.Controls.Add(m_labelTileSheet);
            this.m_tabGeneral.Controls.Add(this.m_textBoxTileSheet);
            this.m_tabGeneral.Controls.Add(this.m_comboBoxBlendMode);
            this.m_tabGeneral.Controls.Add(m_labelBlendMode);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(m_labelId);
            this.m_tabGeneral.Font = null;
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.UseVisualStyleBackColor = true;
            // 
            // m_textBoxTileIndex
            // 
            this.m_textBoxTileIndex.AccessibleDescription = null;
            this.m_textBoxTileIndex.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxTileIndex, "m_textBoxTileIndex");
            this.m_textBoxTileIndex.BackgroundImage = null;
            this.m_textBoxTileIndex.Font = null;
            this.m_textBoxTileIndex.Name = "m_textBoxTileIndex";
            this.m_textBoxTileIndex.ReadOnly = true;
            // 
            // m_textBoxTileSheet
            // 
            this.m_textBoxTileSheet.AccessibleDescription = null;
            this.m_textBoxTileSheet.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxTileSheet, "m_textBoxTileSheet");
            this.m_textBoxTileSheet.BackgroundImage = null;
            this.m_textBoxTileSheet.Font = null;
            this.m_textBoxTileSheet.Name = "m_textBoxTileSheet";
            this.m_textBoxTileSheet.ReadOnly = true;
            // 
            // m_comboBoxBlendMode
            // 
            this.m_comboBoxBlendMode.AccessibleDescription = null;
            this.m_comboBoxBlendMode.AccessibleName = null;
            resources.ApplyResources(this.m_comboBoxBlendMode, "m_comboBoxBlendMode");
            this.m_comboBoxBlendMode.BackgroundImage = null;
            this.m_comboBoxBlendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxBlendMode.Font = null;
            this.m_comboBoxBlendMode.FormattingEnabled = true;
            this.m_comboBoxBlendMode.Items.AddRange(new object[] {
            resources.GetString("m_comboBoxBlendMode.Items"),
            resources.GetString("m_comboBoxBlendMode.Items1")});
            this.m_comboBoxBlendMode.Name = "m_comboBoxBlendMode";
            this.m_comboBoxBlendMode.SelectedIndexChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_textBoxId
            // 
            this.m_textBoxId.AccessibleDescription = null;
            this.m_textBoxId.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxId, "m_textBoxId");
            this.m_textBoxId.BackgroundImage = null;
            this.m_textBoxId.Font = null;
            this.m_textBoxId.Name = "m_textBoxId";
            this.m_textBoxId.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_tabCustomProperties
            // 
            this.m_tabCustomProperties.AccessibleDescription = null;
            this.m_tabCustomProperties.AccessibleName = null;
            resources.ApplyResources(this.m_tabCustomProperties, "m_tabCustomProperties");
            this.m_tabCustomProperties.BackColor = System.Drawing.Color.Transparent;
            this.m_tabCustomProperties.BackgroundImage = null;
            this.m_tabCustomProperties.Controls.Add(this.m_customPropertyGrid);
            this.m_tabCustomProperties.Font = null;
            this.m_tabCustomProperties.Name = "m_tabCustomProperties";
            this.m_tabCustomProperties.UseVisualStyleBackColor = true;
            // 
            // m_customPropertyGrid
            // 
            this.m_customPropertyGrid.AccessibleDescription = null;
            this.m_customPropertyGrid.AccessibleName = null;
            resources.ApplyResources(this.m_customPropertyGrid, "m_customPropertyGrid");
            this.m_customPropertyGrid.BackgroundImage = null;
            this.m_customPropertyGrid.Font = null;
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.PropertyChanged += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // TilePropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_buttonCancel;
            this.Controls.Add(this.m_buttonClose);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_customTabControl);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.Font = null;
            this.MinimizeBox = false;
            this.Name = "TilePropertiesDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.m_customTabControl.ResumeLayout(false);
            this.m_tabGeneral.ResumeLayout(false);
            this.m_tabGeneral.PerformLayout();
            this.m_tabCustomProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private tIDE.Controls.CustomTabControl m_customTabControl;
        private System.Windows.Forms.TabPage m_tabGeneral;
        private System.Windows.Forms.TabPage m_tabCustomProperties;
        private System.Windows.Forms.TextBox m_textBoxId;
        private tIDE.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.TextBox m_textBoxTileIndex;
        private System.Windows.Forms.TextBox m_textBoxTileSheet;
        private System.Windows.Forms.ComboBox m_comboBoxBlendMode;
        private System.Windows.Forms.Button m_buttonClose;
        private System.Windows.Forms.ImageList m_tabImageList;
    }
}