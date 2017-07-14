using System;
using MediaPortal.Profile;
using System.Globalization;

namespace MP1_HyperionScreenCapture
{
  public class Settings
  {
    #region Config variables

    // Generic
    public static bool DisableOnStart;

    // Remote settings
    public static int RemoteToggleKey;

    // API
    public static int ApiPort;

    #endregion

    public static void LoadSettings()
    {
      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        DisableOnStart = reader.GetValueAsBool("AudioSwitcher", "disableOnStart", true);
        RemoteToggleKey = reader.GetValueAsInt("AudioSwitcher", "remoteToggleKey", 0);
        ApiPort = reader.GetValueAsInt("AudioSwitcher", "apiPort", 29445);
      }
    }

    public static void SaveSettings()
    {

      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        reader.SetValueAsBool("AudioSwitcher", "disableOnStart", DisableOnStart);
        reader.SetValue("AudioSwitcher", "remoteToggleKey", RemoteToggleKey);
        reader.SetValue("AudioSwitcher", "apiPort", ApiPort);
      }
    }

    public static void LoadSpecificSetting(string setting, String value)
    {
      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        value = reader.GetValueAsString("AudioSwitcher", setting, "");
        reader.SetValue("AudioSwitcher", setting, value);
      }
    }

    public static void SaveSpecificSetting(string setting, String value)
    {
      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        reader.SetValue("AudioSwitcher", setting, value);
      }
    }
  }
}
