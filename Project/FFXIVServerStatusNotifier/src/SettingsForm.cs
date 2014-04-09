using System;
using System.Windows.Forms;

using FFXIVServerStatusNotifier.Properties;

namespace FFXIVServerStatusNotifier
{
    /// <summary>
    /// The settings form
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Initialises the form
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();

            //Populate the Server Selection dropdown
            foreach (string str in DataValues.serverNameValues)
            {
                serverSelectBox.Items.Add(str);
            }

            //Populate the Check Delay Selection dropdown
            foreach (var pair in DataValues.checkDelayValues)
            {
                checkDelayBox.Items.Add(pair.Key);
            }
        }

        /// <summary>
        /// Save the current settings
        /// </summary>
        private void Settings_Save()
        {
            //Save server name from server select dropdown
            Settings.Default.ServerName = (string)serverSelectBox.SelectedItem;

            //Save check delay from check delay select dropdown
            Settings.Default.CheckDelay = DataValues.checkDelayValues[(string)checkDelayBox.SelectedItem];

            Settings.Default.Save();
        }

        /// <summary>
        /// Load the saved settings
        /// </summary>
        public void Settings_Load()
        {
            //Load the location of the window
            this.Location = Settings.Default.WindowPosition;

            //Set the server select dropdown index to the saved server name
            serverSelectBox.SelectedIndex = serverSelectBox.Items.IndexOf(Settings.Default.ServerName);

            //Set the check delay select dropdown index to the saved check delay
            checkDelayBox.SelectedIndex = checkDelayBox.Items.IndexOf(DataValues.GetStringFromCheckDelay(Settings.Default.CheckDelay));
        }

        /// <summary>
        /// Occurs when a user presses the Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Save the settings and close the form
            Settings_Save();
            this.Close();
        }

        /// <summary>
        /// Occurs when the form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Closed(object sender, FormClosedEventArgs e)
        {
            //Save the location of the window
            Settings.Default.WindowPosition = this.Location;

            Settings.Default.Save();
        }
    }
}
