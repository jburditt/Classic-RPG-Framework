using Common;
using System.Drawing;
using System.Windows.Forms;

namespace RPGPlugin
{
    public partial class ImagePickerForm : Form
    {
        public Asset Selected { get; set; }

        public ImagePickerForm(string folder)
        {
            InitializeComponent();

            var filepaths = FileManager.GetFilepaths($"C:/Users/jebbb/OneDrive/Documents/GitHub/Classic-RPG-Framework/MonoGame/Content/{folder}").ToFileList();
            
            listBox.Items.AddRange(filepaths.ToArray());
            listBox.DisplayMember = "Name";
            listBox.ValueMember = "FilePath";
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var filePath = ((Asset)listBox.Items[listBox.SelectedIndex]).FilePath;

            pictureBox.Image = new Bitmap(filePath);
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void selectButton_Click(object sender, System.EventArgs e)
        {
            Selected = ((Asset)listBox.Items[listBox.SelectedIndex]);

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}