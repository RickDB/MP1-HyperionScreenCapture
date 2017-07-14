using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP1_HyperionScreenCapture
{
  public partial class SetupForm : Form
  {
    public static int MinPortValue = 1024;
    public static int MaxPortValue = 65535;

    public SetupForm()
    {
      InitializeComponent();
      Settings.LoadSettings();
      LoadSettings();
    }

    public void LoadSettings()
    {
      tbApiPort.Text = Settings.ApiPort.ToString();
      cbRemoteToggle.SelectedIndex = Settings.RemoteToggleKey;
      chkDisableOnStart.Checked = Settings.DisableOnStart;
    }

    private void SaveSettings()
    {
      if (!ValidatorInt(tbApiPort.Text, MinPortValue, MaxPortValue, false) == false)
      {
        Settings.ApiPort = int.Parse(tbApiPort.Text);
      }

      Settings.RemoteToggleKey = cbRemoteToggle.SelectedIndex;
      Settings.DisableOnStart = chkDisableOnStart.Checked;
      Settings.SaveSettings();
    }

    private static bool ValidatorInt(string input, int minValue, int maxValue, bool validateMaxValue)
    {
      bool isValid = false;
      int value;
      bool isInteger = int.TryParse(input, out value);

      if (isInteger)
      {
        //Only check minValue
        if (validateMaxValue == false && value >= minValue)
        {
          isValid = true;
        }
        //Check both min/max values
        else
        {
          if (value >= minValue && value <= maxValue)
          {
            isValid = true;
          }
        }
      }
      return isValid;
    }

    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
      SaveSettings();
      Close();
    }

    private void tbApiPort_Validating(object sender, CancelEventArgs e)
    {
      if (ValidatorInt(tbApiPort.Text, MinPortValue, MaxPortValue, false) == false)
      {
        MessageBox.Show(@"Invalid integer filled for port");
      }
    }
  }
}
