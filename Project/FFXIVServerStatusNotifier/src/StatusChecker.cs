using System;
using System.Timers;
using System.Net;
using Newtonsoft.Json.Linq;

namespace FFXIVServerStatusNotifier
{
    /// <summary>
    /// A class to check server status in the background
    /// </summary>
    class StatusChecker
    {
        /// <summary>
        /// Background worker timer to check server status
        /// </summary>
        private Timer statusCheckerTimer;

        public delegate void ServerStatusFoundEvent(string serverName);

        /// <summary>
        /// Event fired when server is online
        /// </summary>
        public event ServerStatusFoundEvent OnServerOnline;

        private WebClient webClient;

        private string serverName;
        private string worldStatusURL = "http://frontier.ffxiv.com/worldStatus/current_status.json";
        private string lobbyStatusURL = "http://frontier.ffxiv.com/worldStatus/gate_status.json";

        public StatusChecker()
        {
            statusCheckerTimer = null;

            webClient = new WebClient();
        }

        /// <summary>
        /// Begin to check for server status
        /// </summary>
        /// <param name="serverName">The name of the server to check status of</param>
        /// <param name="checkInterval">The interval (in milliseconds) between checks</param>
        public void BeginCheckForStatus(string serverName, int checkInterval)
        {
            this.serverName = serverName;

            //If the background worker timer exists, stop it
            if (statusCheckerTimer != null)
            {
                statusCheckerTimer.Stop();
            }

            //Create a new background worker timer
            statusCheckerTimer = new Timer(checkInterval);
            statusCheckerTimer.AutoReset = true;
            statusCheckerTimer.Elapsed += CheckAndReportStatus;
            statusCheckerTimer.Start();

            //Force check once immediately
            CheckAndReportStatus(this, EventArgs.Empty as ElapsedEventArgs);
        }

        /// <summary>
        /// Stop the server status check
        /// </summary>
        public void StopCheckForStatus()
        {
            serverName = "NO_SERVER";

            //If there's no timer, there's nothing to stop
            if (statusCheckerTimer == null) return;

            statusCheckerTimer.Stop();
        }

        /// <summary>
        /// Get the server status from the FFXIV servers
        /// </summary>
        /// <param name="serverName">Name of the server to get the status of</param>
        /// <returns>Server status (0/3 is offline, 1 is online)</returns>
        private int GetServerStatus(string serverName)
        {
            //Get the json from the server status page
            string jsonData = webClient.DownloadString(worldStatusURL);
            JObject root = JObject.Parse(jsonData);

            //Get the server status from the json
            return (int)root[serverName];
        }

        /// <summary>
        /// Get the lobby status from the FFXIV servers
        /// </summary>
        /// <returns>Lobby status (0/3 is offline, 1 is online)</returns>
        private int GetLobbyStatus()
        {
            //Get the json from the lobby status page
            string jsonData = webClient.DownloadString(lobbyStatusURL);
            JObject root = JObject.Parse(jsonData);

            //Get the lobby status from the json
            return (int)root["status"];
        }

        /// <summary>
        /// Checks for server status and reports if online
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAndReportStatus(object sender, ElapsedEventArgs e)
        {
            int serverStatus = GetServerStatus(serverName);
            int lobbyStatus = GetLobbyStatus();

            //If both the server and lobby are online
            if (serverStatus == 1 && lobbyStatus == 1)
            {
                //Raise OnServerOnline event
                if (OnServerOnline != null)
                {
                    OnServerOnline(serverName);
                }
            }
        }
    }
}
