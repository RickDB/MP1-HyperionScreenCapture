using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MediaPortal.Common.Utils.Logger;
using MediaPortal.Configuration;
using MediaPortal.GUI.Library;
using MediaPortal.Player;
using Action = MediaPortal.GUI.Library.Action;

namespace MP1_HyperionScreenCapture
{
    [PluginIcons("MP1_HyperionScreenCapture.Resources.enabled.png", "MP1_HyperionScreenCapture.Resources.disabled.png")]
    public class Class1 : GUIWindow, ISetupForm
    {
        // Variables
        public static string ApiBaseUrl = $"http://localhost:{Settings.ApiPort}/API";

        // With GetID it will be an window-plugin / otherwise a process-plugin
        // Enter the id number here again
        public override int GetID
        {
            get { return 16300; }
            set { }
        }

        public string Author()
        {
            return "Rick164";
        }

        public void ShowPlugin()
        {
            Form settings = new SetupForm();
            settings.Show();
        }

        // Indicates whether plugin can be enabled/disabled
        public bool CanEnable()
        {
            return true;
        }

        // Indicates if plugin is enabled by default;
        public bool DefaultEnabled()
        {
            return true;
        }

        // Returns the description of the plugin is shown in the plugin menu
        public string PluginName()
        {
            return "HyperionScreenCapture";
        }

        public string Description()
        {
            return "Controls HyperionScreenCapture capture via its API.";
        }

        public bool GetHome(out string strButtonText, out string strButtonImage,
            out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonText = string.Empty;
            strButtonImage = string.Empty;
            strButtonImageFocus = string.Empty;
            strPictureImage = string.Empty;
            return false;
        }

        // Get Windows-ID
        public int GetWindowId()
        {
            // WindowID of windowplugin belonging to this setup
            // enter your own unique code
            return 16300;
        }

        // indicates if a plugin has it's own setup screen
        public bool HasSetup()
        {
            return true;
        }

        public override bool Init()
        {
            Logger("HyperionScreenCapture - Starting...", CommonLogLevel.Information);

            Settings.LoadSettings();

            // g_Player Handler
            g_Player.PlayBackStarted += g_Player_PlayBackStarted;
            g_Player.PlayBackStopped += g_Player_PlayBackStopped;
            g_Player.PlayBackEnded += g_Player_PlayBackEnded;

            // Button Handler
            GUIWindowManager.OnNewAction += OnNewAction;

            if (Settings.DisableOnStart)
                ToggleHyperionScreenCapture(false, true);
            else
                ToggleHyperionScreenCapture(true, true);

            Logger("HyperionScreenCapture - Startup completed", CommonLogLevel.Information);

            return true;
        }

        public void Start()
        {
            // Not used
        }

        public void Stop()
        {
            ToggleHyperionScreenCapture(false);
        }

        /// <summary>
        /// Playback started event handler.
        /// This event handler gets called when playback starts.
        /// </summary>
        /// <param name="type">Media type</param>
        /// <param name="filename">Media filename</param>
        private void g_Player_PlayBackStarted(g_Player.MediaType type, string filename)
        {
            if (Settings.OnlyEnableWithMadVr &&
                GUIGraphicsContext.VideoRenderer == GUIGraphicsContext.VideoRendererType.madVR)
            {
                ToggleHyperionScreenCapture(true);
            }
            else if (!Settings.OnlyEnableWithMadVr)
            {
                ToggleHyperionScreenCapture(true);
            }
        }

        /// <summary>
        /// Checks what to do when playback is ended.
        /// </summary>
        /// <param name="type">Media type.</param>
        /// <param name="filename">Media filename.</param>
        private void g_Player_PlayBackEnded(g_Player.MediaType type, string filename)
        {
            if (Settings.OnlyEnableWithMadVr &&
                GUIGraphicsContext.VideoRenderer == GUIGraphicsContext.VideoRendererType.madVR)
            {
                ToggleHyperionScreenCapture(false);
            }
            else if (!Settings.OnlyEnableWithMadVr)
            {
                ToggleHyperionScreenCapture(false);
            }
        }

        /// <summary>
        /// Checks what to do when playback is stopped.
        /// </summary>
        /// <param name="type">Media type.</param>
        /// <param name="stoptime">Media stoptime.</param>
        /// <param name="filename">Media filename.</param>
        private void g_Player_PlayBackStopped(g_Player.MediaType type, int stoptime, string filename)
        {
            ToggleHyperionScreenCapture(false);
        }

        public void OnNewAction(Action action)
        {
            // Remote Key to open Menu
            if ((action.wID == Action.ActionType.ACTION_REMOTE_RED_BUTTON && Settings.RemoteToggleKey == 1) ||
                (action.wID == Action.ActionType.ACTION_REMOTE_GREEN_BUTTON && Settings.RemoteToggleKey == 2) ||
                (action.wID == Action.ActionType.ACTION_REMOTE_BLUE_BUTTON && Settings.RemoteToggleKey == 3) ||
                (action.wID == Action.ActionType.ACTION_REMOTE_YELLOW_BUTTON && Settings.RemoteToggleKey == 4) ||
                (action.wID == Action.ActionType.ACTION_DVD_MENU && Settings.RemoteToggleKey == 5) ||
                (action.wID == Action.ActionType.ACTION_REMOTE_SUBPAGE_DOWN && Settings.RemoteToggleKey == 6) ||
                (action.wID == Action.ActionType.ACTION_REMOTE_SUBPAGE_UP && Settings.RemoteToggleKey == 7))
            {
                if (HyperionScreenCaptureEnabled())
                    ToggleHyperionScreenCapture(false, true);
                else
                    ToggleHyperionScreenCapture(true, true);
            }
        }

        private void ToggleHyperionScreenCapture(bool on, bool force = false)
        {
            try
            {
                string requestUrl;
                if (on)
                {
                    requestUrl = $"{ApiBaseUrl}?command=ON&force={force}";
                    Logger($"HyperionScreenCapture - Enabling capture [force = {force}]", CommonLogLevel.Information);
                }
                else
                {
                    requestUrl = $"{ApiBaseUrl}?command=OFF&force={force}";
                    Logger($"HyperionScreenCapture - Disabling capture [force = {force}]", CommonLogLevel.Information);
                }

                Logger($"HyperionScreenCapture - toggle request URL: {requestUrl}", CommonLogLevel.Debug);
                WebRequest request = WebRequest.Create(requestUrl);
                request.Method = "GET";
                request.GetResponse();
            }
            catch (Exception ex)
            {
                Logger($"HyperionScreenCapture - Error occured during ToggleHyperionScreenCapture(): {ex.Message}", CommonLogLevel.Error);
            }
        }
        private bool HyperionScreenCaptureEnabled()
        {
            bool isEnabled = false;
            try
            {
                string requestUrl = $"{ApiBaseUrl}?command=STATE";

                WebRequest request = WebRequest.Create(requestUrl);
                request.Method = "GET";
                var response = request.GetResponse();
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string responseText = reader.ReadToEnd();
                    bool.TryParse(responseText, out isEnabled);
                }

                Logger($"HyperionScreenCapture - capture is enabled = {isEnabled}", CommonLogLevel.Debug);
            }
            catch (Exception ex)
            {
                Logger($"HyperionScreenCapture - Error occured during HyperionScreenCaptureEnabled(): {ex.Message}", CommonLogLevel.Error);
            }

            return isEnabled;
        }

        private void Logger(string message, CommonLogLevel logLevel)
        {
            switch (logLevel)
            {
                case CommonLogLevel.Debug:
                    Log.Debug(message);
                    break;
                case CommonLogLevel.Error:
                    Log.Error(message);
                    break;
                case CommonLogLevel.Information:
                    Log.Info(message);
                    break;
                default:
                    Log.Info(message);
                    break;
            }
        }
    }
}
