namespace MP1_HyperionScreenCapture
{
  partial class SetupForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
      this.lblRemoteToggle = new System.Windows.Forms.Label();
      this.lblApiPort = new System.Windows.Forms.Label();
      this.chkDisableOnStart = new System.Windows.Forms.CheckBox();
      this.tbApiPort = new System.Windows.Forms.TextBox();
      this.cbRemoteToggle = new System.Windows.Forms.ComboBox();
      this.btnSaveSettings = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblRemoteToggle
      // 
      this.lblRemoteToggle.AutoSize = true;
      this.lblRemoteToggle.Location = new System.Drawing.Point(12, 49);
      this.lblRemoteToggle.Name = "lblRemoteToggle";
      this.lblRemoteToggle.Size = new System.Drawing.Size(60, 13);
      this.lblRemoteToggle.TabIndex = 1;
      this.lblRemoteToggle.Text = "Toggle key";
      // 
      // lblApiPort
      // 
      this.lblApiPort.AutoSize = true;
      this.lblApiPort.Location = new System.Drawing.Point(12, 19);
      this.lblApiPort.Name = "lblApiPort";
      this.lblApiPort.Size = new System.Drawing.Size(43, 13);
      this.lblApiPort.TabIndex = 2;
      this.lblApiPort.Text = "Api port";
      // 
      // chkDisableOnStart
      // 
      this.chkDisableOnStart.AutoSize = true;
      this.chkDisableOnStart.Location = new System.Drawing.Point(15, 81);
      this.chkDisableOnStart.Name = "chkDisableOnStart";
      this.chkDisableOnStart.Size = new System.Drawing.Size(150, 17);
      this.chkDisableOnStart.TabIndex = 3;
      this.chkDisableOnStart.Text = "Disable capture on startup";
      this.chkDisableOnStart.UseVisualStyleBackColor = true;
      // 
      // tbApiPort
      // 
      this.tbApiPort.Location = new System.Drawing.Point(81, 19);
      this.tbApiPort.Name = "tbApiPort";
      this.tbApiPort.Size = new System.Drawing.Size(84, 20);
      this.tbApiPort.TabIndex = 4;
      this.tbApiPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbApiPort_Validating);
      // 
      // cbRemoteToggle
      // 
      this.cbRemoteToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRemoteToggle.FormattingEnabled = true;
      this.cbRemoteToggle.Items.AddRange(new object[] {
            "None",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "DVD menu",
            "Sub page down",
            "Sub page Up"});
      this.cbRemoteToggle.Location = new System.Drawing.Point(81, 46);
      this.cbRemoteToggle.Name = "cbRemoteToggle";
      this.cbRemoteToggle.Size = new System.Drawing.Size(121, 21);
      this.cbRemoteToggle.TabIndex = 5;
      // 
      // btnSaveSettings
      // 
      this.btnSaveSettings.Location = new System.Drawing.Point(15, 110);
      this.btnSaveSettings.Name = "btnSaveSettings";
      this.btnSaveSettings.Size = new System.Drawing.Size(333, 32);
      this.btnSaveSettings.TabIndex = 6;
      this.btnSaveSettings.Text = "Save and close";
      this.btnSaveSettings.UseVisualStyleBackColor = true;
      this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
      // 
      // SetupForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(360, 146);
      this.Controls.Add(this.btnSaveSettings);
      this.Controls.Add(this.cbRemoteToggle);
      this.Controls.Add(this.tbApiPort);
      this.Controls.Add(this.chkDisableOnStart);
      this.Controls.Add(this.lblApiPort);
      this.Controls.Add(this.lblRemoteToggle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "SetupForm";
      this.Text = "HyperionScreenCapture - setup";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblRemoteToggle;
    private System.Windows.Forms.Label lblApiPort;
    private System.Windows.Forms.CheckBox chkDisableOnStart;
    private System.Windows.Forms.TextBox tbApiPort;
    private System.Windows.Forms.ComboBox cbRemoteToggle;
    private System.Windows.Forms.Button btnSaveSettings;
  }
}