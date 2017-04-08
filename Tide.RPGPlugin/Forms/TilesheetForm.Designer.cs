namespace RPGPlugin
{
    partial class TileSheetForm
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
            this.tilesetsListBox = new System.Windows.Forms.ListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tilesetsListBox
            // 
            this.tilesetsListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.tilesetsListBox.FormattingEnabled = true;
            this.tilesetsListBox.ItemHeight = 16;
            this.tilesetsListBox.Location = new System.Drawing.Point(0, 0);
            this.tilesetsListBox.Margin = new System.Windows.Forms.Padding(4);
            this.tilesetsListBox.Name = "tilesetsListBox";
            this.tilesetsListBox.Size = new System.Drawing.Size(224, 448);
            this.tilesetsListBox.TabIndex = 1;
            this.tilesetsListBox.SelectedIndexChanged += new System.EventHandler(this.tilesetsListBox_SelectedIndexChanged);
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(224, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(678, 448);
            this.panel.TabIndex = 2;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(797, 413);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(716, 413);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TileSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 448);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tilesetsListBox);
            this.Name = "TileSheetForm";
            this.Text = "TilesheetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox tilesetsListBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}