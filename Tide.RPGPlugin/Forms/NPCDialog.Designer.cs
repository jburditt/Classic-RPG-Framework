namespace RPGPlugin
{
    partial class NPCDialog
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
            this.imageLabel = new System.Windows.Forms.Label();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.dialogTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.imageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(25, 43);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(46, 17);
            this.imageLabel.TabIndex = 0;
            this.imageLabel.Text = "Image";
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(73, 105);
            this.imagePictureBox.TabIndex = 1;
            this.imagePictureBox.TabStop = false;
            // 
            // dialogTextBox
            // 
            this.dialogTextBox.Location = new System.Drawing.Point(100, 12);
            this.dialogTextBox.Multiline = true;
            this.dialogTextBox.Name = "dialogTextBox";
            this.dialogTextBox.Size = new System.Drawing.Size(170, 137);
            this.dialogTextBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(119, 155);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(68, 28);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(193, 155);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(77, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // imageButton
            // 
            this.imageButton.Location = new System.Drawing.Point(12, 123);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(73, 26);
            this.imageButton.TabIndex = 5;
            this.imageButton.Text = "Select Charset";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // NPCDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 193);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dialogTextBox);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.imagePictureBox);
            this.Name = "NPCDialog";
            this.Text = "NPCDialog";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.TextBox dialogTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button imageButton;
    }
}