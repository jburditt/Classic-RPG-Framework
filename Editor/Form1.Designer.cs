namespace Editor
{
    partial class editorForm
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
            this.charsetTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.debugLabel = new System.Windows.Forms.Label();
            this.filePanel = new System.Windows.Forms.Panel();
            this.filePictureBox = new System.Windows.Forms.PictureBox();
            this.fileRemoveButton = new System.Windows.Forms.Button();
            this.fileAddButton = new System.Windows.Forms.Button();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tilesetRemoveButton = new System.Windows.Forms.Button();
            this.tilesetAddButton = new System.Windows.Forms.Button();
            this.tilesetsListBox = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.charsetTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // charsetTab
            // 
            this.charsetTab.Controls.Add(this.tabPage1);
            this.charsetTab.Controls.Add(this.tabPage2);
            this.charsetTab.Location = new System.Drawing.Point(1, 1);
            this.charsetTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.charsetTab.Name = "charsetTab";
            this.charsetTab.SelectedIndex = 0;
            this.charsetTab.Size = new System.Drawing.Size(1177, 640);
            this.charsetTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.debugLabel);
            this.tabPage1.Controls.Add(this.filePanel);
            this.tabPage1.Controls.Add(this.fileRemoveButton);
            this.tabPage1.Controls.Add(this.fileAddButton);
            this.tabPage1.Controls.Add(this.filesListBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.nameLabel);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.tilesetRemoveButton);
            this.tabPage1.Controls.Add(this.tilesetAddButton);
            this.tabPage1.Controls.Add(this.tilesetsListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1169, 611);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tilesets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(507, 574);
            this.debugLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(48, 17);
            this.debugLabel.TabIndex = 12;
            this.debugLabel.Text = "debug";
            // 
            // filePanel
            // 
            this.filePanel.AutoScroll = true;
            this.filePanel.Controls.Add(this.filePictureBox);
            this.filePanel.Location = new System.Drawing.Point(503, 16);
            this.filePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(653, 549);
            this.filePanel.TabIndex = 11;
            // 
            // filePictureBox
            // 
            this.filePictureBox.Location = new System.Drawing.Point(4, 4);
            this.filePictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filePictureBox.Name = "filePictureBox";
            this.filePictureBox.Size = new System.Drawing.Size(490, 446);
            this.filePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.filePictureBox.TabIndex = 10;
            this.filePictureBox.TabStop = false;
            this.filePictureBox.Click += new System.EventHandler(this.filePictureBox_Click);
            // 
            // fileRemoveButton
            // 
            this.fileRemoveButton.Location = new System.Drawing.Point(371, 574);
            this.fileRemoveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileRemoveButton.Name = "fileRemoveButton";
            this.fileRemoveButton.Size = new System.Drawing.Size(100, 28);
            this.fileRemoveButton.TabIndex = 9;
            this.fileRemoveButton.Text = "Remove";
            this.fileRemoveButton.UseVisualStyleBackColor = true;
            // 
            // fileAddButton
            // 
            this.fileAddButton.Location = new System.Drawing.Point(265, 574);
            this.fileAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileAddButton.Name = "fileAddButton";
            this.fileAddButton.Size = new System.Drawing.Size(100, 28);
            this.fileAddButton.TabIndex = 8;
            this.fileAddButton.Text = "Add";
            this.fileAddButton.UseVisualStyleBackColor = true;
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.ItemHeight = 16;
            this.filesListBox.Location = new System.Drawing.Point(265, 144);
            this.filesListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(204, 420);
            this.filesListBox.TabIndex = 7;
            this.filesListBox.SelectedIndexChanged += new System.EventHandler(this.filesListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "File";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(265, 91);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 5;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(261, 16);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 17);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(265, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 3;
            // 
            // tilesetRemoveButton
            // 
            this.tilesetRemoveButton.Location = new System.Drawing.Point(135, 574);
            this.tilesetRemoveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tilesetRemoveButton.Name = "tilesetRemoveButton";
            this.tilesetRemoveButton.Size = new System.Drawing.Size(100, 28);
            this.tilesetRemoveButton.TabIndex = 2;
            this.tilesetRemoveButton.Text = "Remove";
            this.tilesetRemoveButton.UseVisualStyleBackColor = true;
            // 
            // tilesetAddButton
            // 
            this.tilesetAddButton.Location = new System.Drawing.Point(9, 574);
            this.tilesetAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tilesetAddButton.Name = "tilesetAddButton";
            this.tilesetAddButton.Size = new System.Drawing.Size(100, 28);
            this.tilesetAddButton.TabIndex = 1;
            this.tilesetAddButton.Text = "Add";
            this.tilesetAddButton.UseVisualStyleBackColor = true;
            // 
            // tilesetsListBox
            // 
            this.tilesetsListBox.FormattingEnabled = true;
            this.tilesetsListBox.ItemHeight = 16;
            this.tilesetsListBox.Location = new System.Drawing.Point(9, 16);
            this.tilesetsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tilesetsListBox.Name = "tilesetsListBox";
            this.tilesetsListBox.Size = new System.Drawing.Size(224, 548);
            this.tilesetsListBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(1061, 647);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(945, 647);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1169, 611);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Charsets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // editorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 690);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.charsetTab);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "editorForm";
            this.Text = "RPG Editor";
            this.charsetTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl charsetTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button fileRemoveButton;
        private System.Windows.Forms.Button fileAddButton;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button tilesetRemoveButton;
        private System.Windows.Forms.Button tilesetAddButton;
        private System.Windows.Forms.ListBox tilesetsListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox filePictureBox;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

