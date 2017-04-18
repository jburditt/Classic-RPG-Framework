using DataStore;
using Player.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace RPGPlugin.Forms
{
    public partial class ProjectSettingsForm : Form
    {
        public ProjectSettings ProjectSettings { get; set; }

        private IDataStore m_dataStore;
        private string m_oldProjectName;

        public ProjectSettingsForm(IDataStore dataStore, string projectName)
        {
            InitializeComponent();

            m_dataStore = dataStore;
            if (!string.IsNullOrEmpty(projectName))
                m_dataStore.Load<ProjectSettings>(projectName);
            else
                ProjectSettings = new ProjectSettings();

            m_oldProjectName = projectName;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            ProjectSettings = new ProjectSettings
            {
                Name = nameTextBox.Text,
                Author = authorTextBox.Text,
                StartMapId = startingMapDropDown.SelectedValue + "",
                MenuBgId = menuBgDropDown.SelectedValue + "",
                SongId = menuSongDropDown.SelectedValue + ""
            };

            if (ProjectSettings.Name != m_oldProjectName)
            {
                Directory.Move(m_oldProjectName, ProjectSettings.Name);
                m_dataStore.FilePath = $"{Settings.ProjectFilePath}{ProjectSettings.Name}\\";
            }

            m_dataStore.Save(ProjectSettings, $"{ProjectSettings.Name}.Settings");

            Close();
        }
    }
}
