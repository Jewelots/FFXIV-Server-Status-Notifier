using System;
using System.Drawing;
using System.Windows.Forms;

using FFXIVServerStatusNotifier.Properties;

namespace FFXIVServerStatusNotifier
{
    class SysTrayApp : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        private MenuItem settingsItem;
        private MenuItem runningCheckItem;

        private SettingsForm settingsForm;

        private StatusChecker statusChecker;

        public SysTrayApp()
        {
            settingsForm = null;

            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();

            //Add Settings
            settingsItem = new MenuItem();
            settingsItem.Index = 0;
            settingsItem.Text = "&Settings";
            settingsItem.Click += new System.EventHandler(SettingsClick);
            trayMenu.MenuItems.Add(settingsItem);

            //Add Running checkbox
            runningCheckItem = new MenuItem();
            runningCheckItem.Index = 1;
            runningCheckItem.Click += new System.EventHandler(runningCheckItem_Click);
            trayMenu.MenuItems.Add(runningCheckItem);

            //Add Exit
            trayMenu.MenuItems.Add("E&xit", OnExit);

            //Add notify icon
            trayIcon = new NotifyIcon();
            trayIcon.Text = "FFXIV Server Status Notifier";
            trayIcon.Icon = Properties.Resources.smallicon;

            trayIcon.DoubleClick += new System.EventHandler(SettingsClick);

            //Add menu to tray icon and show it
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            //Initialise Status Checker
            statusChecker = new StatusChecker();
            statusChecker.OnServerOnline += ServerStatusCheckComplete;

            EnableServerStatusChecking();
        }
        
        /// <summary>
        /// Occurs when a user clicks the Settings context menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsClick(object sender, EventArgs e)
        {
            //If there's already a settings open set focus to it
            if (settingsForm != null && !settingsForm.IsDisposed)
            {
                settingsForm.WindowState = FormWindowState.Normal;
                settingsForm.Settings_Load();
                settingsForm.BringToFront();
                settingsForm.Focus();
                return;
            }

            //Create a new settings form, and show it
            settingsForm = new SettingsForm(OnSettingsChanged);
            settingsForm.Show();
            settingsForm.Settings_Load();
        }

        /// <summary>
        /// Create a notification that the server is online
        /// </summary>
        private void NotifyServerStatusOnline(string serverName)
        {
            //Play a notification sound
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.chime);
            player.Play();

            trayIcon.ShowBalloonTip(1000, "Server Status", "Server '" + serverName + "' is now online!\nDisabling Check.", ToolTipIcon.None);

            DisableServerStatusChecking();
        }

        /// <summary>
        /// Occurs when a user clicks the Running context menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runningCheckItem_Click(object sender, EventArgs e)
        {
            if (runningCheckItem.Checked)
            {
                DisableServerStatusChecking();
            }
            else
            {
                EnableServerStatusChecking();
            }
        }

        /// <summary>
        /// Enable checking for server status
        /// </summary>
        private void EnableServerStatusChecking()
        {
            runningCheckItem.Checked = true;
            runningCheckItem.Text = "&Running";

            statusChecker.BeginCheckForStatus(Settings.Default.ServerName, Settings.Default.CheckDelay);
        }

        /// <summary>
        /// Disable checking for server status
        /// </summary>
        private void DisableServerStatusChecking()
        {
            runningCheckItem.Checked = false;
            runningCheckItem.Text = "&Run";

            statusChecker.StopCheckForStatus();
        }

        /// <summary>
        /// Callback for when settings are changed
        /// </summary>
        private void OnSettingsChanged()
        {
            if (runningCheckItem.Checked)
            {
                RestartServerStatusChecking();
            }
        }

        /// <summary>
        /// Restart checking for server status
        /// </summary>
        private void RestartServerStatusChecking()
        {
            statusChecker.StopCheckForStatus();
            statusChecker.BeginCheckForStatus(Settings.Default.ServerName, Settings.Default.CheckDelay);
        }

        /// <summary>
        /// Event called on status checking complete
        /// </summary>
        /// <param name="serverName">Name of the server that was checked</param>
        private void ServerStatusCheckComplete(string serverName)
        {
            NotifyServerStatusOnline(serverName);
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; //Hide the form
            ShowInTaskbar = false; //Remove from taskbar

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
