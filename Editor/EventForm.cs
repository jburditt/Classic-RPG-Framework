using Player;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Editor
{
    public partial class EventForm : Form
    {
        public NPC Selected { get; set; } = new NPC();

        public EventForm()
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
                    pictureBox.Image = new Bitmap(form.Selected.FilePath);

                    Selected.Name = form.Selected.Name;
                    Selected.CharSet = form.Selected.FilePath;
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
