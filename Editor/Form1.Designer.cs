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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.debugLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(883, 520);
            this.tabControl1.TabIndex = 0;
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(875, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tilesets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // filePanel
            // 
            this.filePanel.AutoScroll = true;
            this.filePanel.Controls.Add(this.filePictureBox);
            this.filePanel.Location = new System.Drawing.Point(377, 13);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(490, 446);
            this.filePanel.TabIndex = 11;
            // 
            // filePictureBox
            // 
            this.filePictureBox.Location = new System.Drawing.Point(3, 3);
            this.filePictureBox.Name = "filePictureBox";
            this.filePictureBox.Size = new System.Drawing.Size(490, 446);
            this.filePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.filePictureBox.TabIndex = 10;
            this.filePictureBox.TabStop = false;
            this.filePictureBox.Click += new System.EventHandler(this.filePictureBox_Click);
            // 
            // fileRemoveButton
            // 
            this.fileRemoveButton.Location = new System.Drawing.Point(278, 466);
            this.fileRemoveButton.Name = "fileRemoveButton";
            this.fileRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.fileRemoveButton.TabIndex = 9;
            this.fileRemoveButton.Text = "Remove";
            this.fileRemoveButton.UseVisualStyleBackColor = true;
            // 
            // fileAddButton
            // 
            this.fileAddButton.Location = new System.Drawing.Point(199, 466);
            this.fileAddButton.Name = "fileAddButton";
            this.fileAddButton.Size = new System.Drawing.Size(75, 23);
            this.fileAddButton.TabIndex = 8;
            this.fileAddButton.Text = "Add";
            this.fileAddButton.UseVisualStyleBackColor = true;
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.Location = new System.Drawing.Point(199, 117);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(154, 342);
            this.filesListBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(199, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(196, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // tilesetRemoveButton
            // 
            this.tilesetRemoveButton.Location = new System.Drawing.Point(101, 466);
            this.tilesetRemoveButton.Name = "tilesetRemoveButton";
            this.tilesetRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.tilesetRemoveButton.TabIndex = 2;
            this.tilesetRemoveButton.Text = "Remove";
            this.tilesetRemoveButton.UseVisualStyleBackColor = true;
            // 
            // tilesetAddButton
            // 
            this.tilesetAddButton.Location = new System.Drawing.Point(7, 466);
            this.tilesetAddButton.Name = "tilesetAddButton";
            this.tilesetAddButton.Size = new System.Drawing.Size(75, 23);
            this.tilesetAddButton.TabIndex = 1;
            this.tilesetAddButton.Text = "Add";
            this.tilesetAddButton.UseVisualStyleBackColor = true;
            // 
            // tilesetsListBox
            // 
            this.tilesetsListBox.FormattingEnabled = true;
            this.tilesetsListBox.Location = new System.Drawing.Point(7, 13);
            this.tilesetsListBox.Name = "tilesetsListBox";
            this.tilesetsListBox.Size = new System.Drawing.Size(169, 446);
            this.tilesetsListBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(380, 466);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(37, 13);
            this.debugLabel.TabIndex = 12;
            this.debugLabel.Text = "debug";
            // 
            // editorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "editorForm";
            this.Text = "RPG Editor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
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
    }
}

