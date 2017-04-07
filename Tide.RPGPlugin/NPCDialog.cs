using Player;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPGPlugin
{
    public partial class NPCDialog : Form
    {
        public NPC Selected { get; set; } = new NPC();

        public NPCDialog()
        {
            InitializeComponent();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            using (var form = new ImagePickerForm("charset"))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    imageLabel.Text = form.Selected.Name;
                    imagePictureBox.Image = new Bitmap(form.Selected.FilePath);

                    Selected.Name = form.Selected.Name;
                    Selected.CharSet = form.Selected.Name;
                    Selected.Direction = Direction.Down;
                    Selected.Movement = Movement.Walking;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Selected.Dialog = dialogTextBox.Text;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}