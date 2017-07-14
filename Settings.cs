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
    public static bool OnlyEnableWithMadVr;


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
        DisableOnStart = reader.GetValueAsBool("HyperionScreenCapture", "disableOnStart", true);
        OnlyEnableWithMadVr = reader.GetValueAsBool("HyperionScreenCapture", "onlyEnableWithMadVr", false);
        RemoteToggleKey = reader.GetValueAsInt("HyperionScreenCapture", "remoteToggleKey", 0);
        ApiPort = reader.GetValueAsInt("HyperionScreenCapture", "apiPort", 29445);
      }
    }

    public static void SaveSettings()
    {

      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        reader.SetValueAsBool("HyperionScreenCapture", "disableOnStart", DisableOnStart);
        reader.SetValueAsBool("HyperionScreenCapture", "onlyEnableWithMadVr", OnlyEnableWithMadVr);
        reader.SetValue("HyperionScreenCapture", "remoteToggleKey", RemoteToggleKey);
        reader.SetValue("HyperionScreenCapture", "apiPort", ApiPort);
      }
    }

    public static void LoadSpecificSetting(string setting, String value)
    {
      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        value = reader.GetValueAsString("HyperionScreenCapture", setting, "");
        reader.SetValue("HyperionScreenCapture", setting, value);
      }
    }

    public static void SaveSpecificSetting(string setting, String value)
    {
      using (
        MediaPortal.Profile.Settings reader =
          new MediaPortal.Profile.Settings(
            MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
      {
        reader.SetValue("HyperionScreenCapture", setting, value);
      }
    }
  }
}
