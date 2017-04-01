using Player;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Editor
{
    public partial class EventForm : Form
    {
        public List<NPC> Selected { get; set; } = new List<NPC>();

        public NPC Active {
            get
            {
                return Selected[(int)eventNumericUpDown.Value];
            }
        }

        public EventForm()
        {
            InitializeComponent();

            Selected.Add(new NPC());
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

                    Active.Name = form.Selected.Name;
                    Active.CharSet = form.Selected.Name;
                    Active.Direction = Direction.Down;
                    Active.Movement = Movement.Walking;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Active.Dialog = dialogTextBox.Text;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}