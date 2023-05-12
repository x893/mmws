namespace AR1xController
{
	public partial class RFDataCaptureCard : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_ChkPacketSequenceEnaDisable = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_cboEthernetDataCaptureMode = new System.Windows.Forms.ComboBox();
            this.m_nudPacketDelayConfig = new System.Windows.Forms.NumericUpDown();
            this.m_cboEthernetTransferMode = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.f00022c = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtHostSystemIPAddress3 = new System.Windows.Forms.TextBox();
            this.m_txtHostSystemIPAddress2 = new System.Windows.Forms.TextBox();
            this.m_cboEthernetDataLogMode = new System.Windows.Forms.ComboBox();
            this.m_txtHostSystemIPAddress1 = new System.Windows.Forms.TextBox();
            this.m_txtHostSystemIPAddress0 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtMacAddress5 = new System.Windows.Forms.TextBox();
            this.m_txtMacAddress4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtMacAddress3 = new System.Windows.Forms.TextBox();
            this.m_txtMacAddress2 = new System.Windows.Forms.TextBox();
            this.m_txtMacAddress1 = new System.Windows.Forms.TextBox();
            this.m_txtMacAddress0 = new System.Windows.Forms.TextBox();
            this.m_txtIPAddress3 = new System.Windows.Forms.TextBox();
            this.m_txtIPAddress2 = new System.Windows.Forms.TextBox();
            this.m_txtIPAddress1 = new System.Windows.Forms.TextBox();
            this.m_txtIPAddress0 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_nudConfigPort = new System.Windows.Forms.NumericUpDown();
            this.m_nudRecordPlayBackPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnRFDataCaptureSystemConfigSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cboEtherneDataForamtMode = new System.Windows.Forms.ComboBox();
            this.m_cboEthernetDeviceLVDSSelectMode = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_btnEtherNetModeConfigSet = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.f00022d = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.f00022e = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_btnPacketDelayConfigSet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPacketDelayConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudConfigPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRecordPlayBackPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_ChkPacketSequenceEnaDisable);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.m_cboEthernetDataCaptureMode);
            this.groupBox1.Controls.Add(this.m_nudPacketDelayConfig);
            this.groupBox1.Controls.Add(this.m_cboEthernetTransferMode);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.f00022c);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.m_txtHostSystemIPAddress3);
            this.groupBox1.Controls.Add(this.m_txtHostSystemIPAddress2);
            this.groupBox1.Controls.Add(this.m_cboEthernetDataLogMode);
            this.groupBox1.Controls.Add(this.m_txtHostSystemIPAddress1);
            this.groupBox1.Controls.Add(this.m_txtHostSystemIPAddress0);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.m_txtMacAddress5);
            this.groupBox1.Controls.Add(this.m_txtMacAddress4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_txtMacAddress3);
            this.groupBox1.Controls.Add(this.m_txtMacAddress2);
            this.groupBox1.Controls.Add(this.m_txtMacAddress1);
            this.groupBox1.Controls.Add(this.m_txtMacAddress0);
            this.groupBox1.Controls.Add(this.m_txtIPAddress3);
            this.groupBox1.Controls.Add(this.m_txtIPAddress2);
            this.groupBox1.Controls.Add(this.m_txtIPAddress1);
            this.groupBox1.Controls.Add(this.m_txtIPAddress0);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.m_nudConfigPort);
            this.groupBox1.Controls.Add(this.m_nudRecordPlayBackPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_btnRFDataCaptureSystemConfigSet);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Configuration";
            // 
            // m_ChkPacketSequenceEnaDisable
            // 
            this.m_ChkPacketSequenceEnaDisable.AutoSize = true;
            this.m_ChkPacketSequenceEnaDisable.Checked = true;
            this.m_ChkPacketSequenceEnaDisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ChkPacketSequenceEnaDisable.Location = new System.Drawing.Point(128, 275);
            this.m_ChkPacketSequenceEnaDisable.Name = "m_ChkPacketSequenceEnaDisable";
            this.m_ChkPacketSequenceEnaDisable.Size = new System.Drawing.Size(15, 14);
            this.m_ChkPacketSequenceEnaDisable.TabIndex = 50;
            this.m_ChkPacketSequenceEnaDisable.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 275);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "Packet Seq Enable";
            // 
            // m_cboEthernetDataCaptureMode
            // 
            this.m_cboEthernetDataCaptureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEthernetDataCaptureMode.Enabled = false;
            this.m_cboEthernetDataCaptureMode.FormattingEnabled = true;
            this.m_cboEthernetDataCaptureMode.Items.AddRange(new object[] {
            "Ethernet Stream",
            "SD Card Storage"});
            this.m_cboEthernetDataCaptureMode.Location = new System.Drawing.Point(128, 247);
            this.m_cboEthernetDataCaptureMode.Name = "m_cboEthernetDataCaptureMode";
            this.m_cboEthernetDataCaptureMode.Size = new System.Drawing.Size(121, 21);
            this.m_cboEthernetDataCaptureMode.TabIndex = 23;
            // 
            // m_nudPacketDelayConfig
            // 
            this.m_nudPacketDelayConfig.Location = new System.Drawing.Point(128, 298);
            this.m_nudPacketDelayConfig.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.m_nudPacketDelayConfig.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudPacketDelayConfig.Name = "m_nudPacketDelayConfig";
            this.m_nudPacketDelayConfig.Size = new System.Drawing.Size(79, 20);
            this.m_nudPacketDelayConfig.TabIndex = 1;
            this.m_nudPacketDelayConfig.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // m_cboEthernetTransferMode
            // 
            this.m_cboEthernetTransferMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEthernetTransferMode.Enabled = false;
            this.m_cboEthernetTransferMode.FormattingEnabled = true;
            this.m_cboEthernetTransferMode.Items.AddRange(new object[] {
            "LVDS Mode",
            "DMM Mode"});
            this.m_cboEthernetTransferMode.Location = new System.Drawing.Point(128, 213);
            this.m_cboEthernetTransferMode.Name = "m_cboEthernetTransferMode";
            this.m_cboEthernetTransferMode.Size = new System.Drawing.Size(121, 21);
            this.m_cboEthernetTransferMode.TabIndex = 24;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 302);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Packet Delay (µs)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 220);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Data Transfer Mode";
            // 
            // f00022c
            // 
            this.f00022c.Location = new System.Drawing.Point(294, 326);
            this.f00022c.Name = "f00022c";
            this.f00022c.Size = new System.Drawing.Size(112, 32);
            this.f00022c.TabIndex = 2;
            this.f00022c.Text = "Reset and Configure";
            this.f00022c.UseVisualStyleBackColor = true;
            this.f00022c.Click += new System.EventHandler(this.m00006d);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(258, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = ".";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(209, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data Capture Mode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(161, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = ".";
            // 
            // m_txtHostSystemIPAddress3
            // 
            this.m_txtHostSystemIPAddress3.Enabled = false;
            this.m_txtHostSystemIPAddress3.Location = new System.Drawing.Point(271, 21);
            this.m_txtHostSystemIPAddress3.Name = "m_txtHostSystemIPAddress3";
            this.m_txtHostSystemIPAddress3.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress3.TabIndex = 45;
            this.m_txtHostSystemIPAddress3.Text = "30";
            // 
            // m_txtHostSystemIPAddress2
            // 
            this.m_txtHostSystemIPAddress2.Enabled = false;
            this.m_txtHostSystemIPAddress2.Location = new System.Drawing.Point(221, 22);
            this.m_txtHostSystemIPAddress2.Name = "m_txtHostSystemIPAddress2";
            this.m_txtHostSystemIPAddress2.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress2.TabIndex = 44;
            this.m_txtHostSystemIPAddress2.Text = "33";
            // 
            // m_cboEthernetDataLogMode
            // 
            this.m_cboEthernetDataLogMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEthernetDataLogMode.Enabled = false;
            this.m_cboEthernetDataLogMode.FormattingEnabled = true;
            this.m_cboEthernetDataLogMode.Items.AddRange(new object[] {
            "Raw Mode",
            "Multi Mode"});
            this.m_cboEthernetDataLogMode.Location = new System.Drawing.Point(128, 183);
            this.m_cboEthernetDataLogMode.Name = "m_cboEthernetDataLogMode";
            this.m_cboEthernetDataLogMode.Size = new System.Drawing.Size(121, 21);
            this.m_cboEthernetDataLogMode.TabIndex = 12;
            // 
            // m_txtHostSystemIPAddress1
            // 
            this.m_txtHostSystemIPAddress1.Enabled = false;
            this.m_txtHostSystemIPAddress1.Location = new System.Drawing.Point(174, 22);
            this.m_txtHostSystemIPAddress1.Name = "m_txtHostSystemIPAddress1";
            this.m_txtHostSystemIPAddress1.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress1.TabIndex = 43;
            this.m_txtHostSystemIPAddress1.Text = "168";
            // 
            // m_txtHostSystemIPAddress0
            // 
            this.m_txtHostSystemIPAddress0.Enabled = false;
            this.m_txtHostSystemIPAddress0.Location = new System.Drawing.Point(128, 22);
            this.m_txtHostSystemIPAddress0.Name = "m_txtHostSystemIPAddress0";
            this.m_txtHostSystemIPAddress0.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress0.TabIndex = 42;
            this.m_txtHostSystemIPAddress0.Text = "192";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "System IP Address";
            // 
            // m_txtMacAddress5
            // 
            this.m_txtMacAddress5.Enabled = false;
            this.m_txtMacAddress5.Location = new System.Drawing.Point(368, 89);
            this.m_txtMacAddress5.Name = "m_txtMacAddress5";
            this.m_txtMacAddress5.Size = new System.Drawing.Size(30, 20);
            this.m_txtMacAddress5.TabIndex = 40;
            this.m_txtMacAddress5.Text = "12";
            // 
            // m_txtMacAddress4
            // 
            this.m_txtMacAddress4.Enabled = false;
            this.m_txtMacAddress4.Location = new System.Drawing.Point(318, 89);
            this.m_txtMacAddress4.Name = "m_txtMacAddress4";
            this.m_txtMacAddress4.Size = new System.Drawing.Size(30, 20);
            this.m_txtMacAddress4.TabIndex = 39;
            this.m_txtMacAddress4.Text = "90";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Data Logging Mode";
            // 
            // m_txtMacAddress3
            // 
            this.m_txtMacAddress3.Enabled = false;
            this.m_txtMacAddress3.Location = new System.Drawing.Point(271, 89);
            this.m_txtMacAddress3.Name = "m_txtMacAddress3";
            this.m_txtMacAddress3.Size = new System.Drawing.Size(30, 20);
            this.m_txtMacAddress3.TabIndex = 38;
            this.m_txtMacAddress3.Text = "78";
            // 
            // m_txtMacAddress2
            // 
            this.m_txtMacAddress2.Enabled = false;
            this.m_txtMacAddress2.Location = new System.Drawing.Point(221, 89);
            this.m_txtMacAddress2.Name = "m_txtMacAddress2";
            this.m_txtMacAddress2.Size = new System.Drawing.Size(30, 20);
            this.m_txtMacAddress2.TabIndex = 37;
            this.m_txtMacAddress2.Text = "56";
            // 
            // m_txtMacAddress1
            // 
            this.m_txtMacAddress1.Enabled = false;
            this.m_txtMacAddress1.Location = new System.Drawing.Point(174, 89);
            this.m_txtMacAddress1.Name = "m_txtMacAddress1";
            this.m_txtMacAddress1.Size = new System.Drawing.Size(30, 20);
            this.m_txtMacAddress1.TabIndex = 36;
            this.m_txtMacAddress1.Text = "34";
            // 
            // m_txtMacAddress0
            // 
            this.m_txtMacAddress0.Enabled = false;
            this.m_txtMacAddress0.Location = new System.Drawing.Point(128, 89);
            this.m_txtMacAddress0.Name = "m_txtMacAddress0";
            this.m_txtMacAddress0.Size = new System.Drawing.Size(30, 20);
            this.m_txtMacAddress0.TabIndex = 35;
            this.m_txtMacAddress0.Text = "12";
            // 
            // m_txtIPAddress3
            // 
            this.m_txtIPAddress3.Enabled = false;
            this.m_txtIPAddress3.Location = new System.Drawing.Point(271, 57);
            this.m_txtIPAddress3.Name = "m_txtIPAddress3";
            this.m_txtIPAddress3.Size = new System.Drawing.Size(30, 20);
            this.m_txtIPAddress3.TabIndex = 34;
            this.m_txtIPAddress3.Text = "180";
            // 
            // m_txtIPAddress2
            // 
            this.m_txtIPAddress2.Enabled = false;
            this.m_txtIPAddress2.Location = new System.Drawing.Point(221, 57);
            this.m_txtIPAddress2.Name = "m_txtIPAddress2";
            this.m_txtIPAddress2.Size = new System.Drawing.Size(30, 20);
            this.m_txtIPAddress2.TabIndex = 33;
            this.m_txtIPAddress2.Text = "33";
            // 
            // m_txtIPAddress1
            // 
            this.m_txtIPAddress1.Enabled = false;
            this.m_txtIPAddress1.Location = new System.Drawing.Point(174, 57);
            this.m_txtIPAddress1.Name = "m_txtIPAddress1";
            this.m_txtIPAddress1.Size = new System.Drawing.Size(30, 20);
            this.m_txtIPAddress1.TabIndex = 32;
            this.m_txtIPAddress1.Text = "168";
            // 
            // m_txtIPAddress0
            // 
            this.m_txtIPAddress0.Enabled = false;
            this.m_txtIPAddress0.Location = new System.Drawing.Point(128, 57);
            this.m_txtIPAddress0.Name = "m_txtIPAddress0";
            this.m_txtIPAddress0.Size = new System.Drawing.Size(30, 20);
            this.m_txtIPAddress0.TabIndex = 31;
            this.m_txtIPAddress0.Text = "192";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(353, 89);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(10, 13);
            this.label29.TabIndex = 30;
            this.label29.Text = ".";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(305, 90);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(10, 13);
            this.label32.TabIndex = 27;
            this.label32.Text = ".";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(257, 89);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(10, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = ".";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(209, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(10, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = ".";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(161, 89);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(10, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = ".";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(257, 57);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(10, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = ".";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(209, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = ".";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(161, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = ".";
            // 
            // m_nudConfigPort
            // 
            this.m_nudConfigPort.Enabled = false;
            this.m_nudConfigPort.Location = new System.Drawing.Point(128, 120);
            this.m_nudConfigPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_nudConfigPort.Name = "m_nudConfigPort";
            this.m_nudConfigPort.Size = new System.Drawing.Size(54, 20);
            this.m_nudConfigPort.TabIndex = 10;
            this.m_nudConfigPort.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // m_nudRecordPlayBackPort
            // 
            this.m_nudRecordPlayBackPort.Enabled = false;
            this.m_nudRecordPlayBackPort.Location = new System.Drawing.Point(128, 153);
            this.m_nudRecordPlayBackPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_nudRecordPlayBackPort.Name = "m_nudRecordPlayBackPort";
            this.m_nudRecordPlayBackPort.Size = new System.Drawing.Size(55, 20);
            this.m_nudRecordPlayBackPort.TabIndex = 9;
            this.m_nudRecordPlayBackPort.Value = new decimal(new int[] {
            4098,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Record Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Config Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "FPGA MAC Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPGA IP Address";
            // 
            // m_btnRFDataCaptureSystemConfigSet
            // 
            this.m_btnRFDataCaptureSystemConfigSet.Location = new System.Drawing.Point(123, 326);
            this.m_btnRFDataCaptureSystemConfigSet.Name = "m_btnRFDataCaptureSystemConfigSet";
            this.m_btnRFDataCaptureSystemConfigSet.Size = new System.Drawing.Size(165, 32);
            this.m_btnRFDataCaptureSystemConfigSet.TabIndex = 0;
            this.m_btnRFDataCaptureSystemConfigSet.Text = "Connect, Reset and Configure";
            this.m_btnRFDataCaptureSystemConfigSet.UseVisualStyleBackColor = true;
            this.m_btnRFDataCaptureSystemConfigSet.Click += new System.EventHandler(this.m_btnRFDataCaptureSystemConfigSet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cboEtherneDataForamtMode);
            this.groupBox2.Controls.Add(this.m_cboEthernetDeviceLVDSSelectMode);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.m_btnEtherNetModeConfigSet);
            this.groupBox2.Location = new System.Drawing.Point(294, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ModeCfg";
            this.groupBox2.Visible = false;
            // 
            // m_cboEtherneDataForamtMode
            // 
            this.m_cboEtherneDataForamtMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEtherneDataForamtMode.FormattingEnabled = true;
            this.m_cboEtherneDataForamtMode.Items.AddRange(new object[] {
            "12 bit",
            "14 bit",
            "16 bit"});
            this.m_cboEtherneDataForamtMode.Location = new System.Drawing.Point(76, 14);
            this.m_cboEtherneDataForamtMode.Name = "m_cboEtherneDataForamtMode";
            this.m_cboEtherneDataForamtMode.Size = new System.Drawing.Size(48, 21);
            this.m_cboEtherneDataForamtMode.TabIndex = 22;
            this.m_cboEtherneDataForamtMode.Visible = false;
            // 
            // m_cboEthernetDeviceLVDSSelectMode
            // 
            this.m_cboEthernetDeviceLVDSSelectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboEthernetDeviceLVDSSelectMode.FormattingEnabled = true;
            this.m_cboEthernetDeviceLVDSSelectMode.Items.AddRange(new object[] {
            "AR1243",
            "AR1642"});
            this.m_cboEthernetDeviceLVDSSelectMode.Location = new System.Drawing.Point(73, 33);
            this.m_cboEthernetDeviceLVDSSelectMode.Name = "m_cboEthernetDeviceLVDSSelectMode";
            this.m_cboEthernetDeviceLVDSSelectMode.Size = new System.Drawing.Size(42, 21);
            this.m_cboEthernetDeviceLVDSSelectMode.TabIndex = 21;
            this.m_cboEthernetDeviceLVDSSelectMode.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Data Formt";
            this.label17.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-619, 573);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Data Transfer Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "LVDSMode";
            this.label7.Visible = false;
            // 
            // m_btnEtherNetModeConfigSet
            // 
            this.m_btnEtherNetModeConfigSet.Location = new System.Drawing.Point(9, 120);
            this.m_btnEtherNetModeConfigSet.Name = "m_btnEtherNetModeConfigSet";
            this.m_btnEtherNetModeConfigSet.Size = new System.Drawing.Size(48, 20);
            this.m_btnEtherNetModeConfigSet.TabIndex = 1;
            this.m_btnEtherNetModeConfigSet.Text = "Set";
            this.m_btnEtherNetModeConfigSet.UseVisualStyleBackColor = true;
            this.m_btnEtherNetModeConfigSet.Click += new System.EventHandler(this.m_btnEtherNetModeConfigSet_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "FPGA Version:";
            // 
            // f00022d
            // 
            this.f00022d.AutoSize = true;
            this.f00022d.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f00022d.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.f00022d.Location = new System.Drawing.Point(129, 13);
            this.f00022d.Name = "f00022d";
            this.f00022d.Size = new System.Drawing.Size(51, 15);
            this.f00022d.TabIndex = 4;
            this.f00022d.Text = "0.0.0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "DLL Version:";
            // 
            // f00022e
            // 
            this.f00022e.AutoSize = true;
            this.f00022e.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f00022e.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.f00022e.Location = new System.Drawing.Point(129, 33);
            this.f00022e.Name = "f00022e";
            this.f00022e.Size = new System.Drawing.Size(51, 15);
            this.f00022e.TabIndex = 6;
            this.f00022e.Text = "0.0.0.0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_btnPacketDelayConfigSet);
            this.groupBox3.Location = new System.Drawing.Point(23, 436);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(83, 40);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PktDelayCfg";
            this.groupBox3.Visible = false;
            // 
            // m_btnPacketDelayConfigSet
            // 
            this.m_btnPacketDelayConfigSet.Location = new System.Drawing.Point(15, 16);
            this.m_btnPacketDelayConfigSet.Name = "m_btnPacketDelayConfigSet";
            this.m_btnPacketDelayConfigSet.Size = new System.Drawing.Size(35, 21);
            this.m_btnPacketDelayConfigSet.TabIndex = 2;
            this.m_btnPacketDelayConfigSet.Text = "Set";
            this.m_btnPacketDelayConfigSet.UseVisualStyleBackColor = true;
            this.m_btnPacketDelayConfigSet.Click += new System.EventHandler(this.m_btnPacketDelayConfigSet_Click);
            // 
            // RFDataCaptureCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 485);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.f00022e);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.f00022d);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RFDataCaptureCard";
            this.Text = "RFDataCaptureCard";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPacketDelayConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudConfigPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRecordPlayBackPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.GroupBox groupBox1;

		private global::System.Windows.Forms.GroupBox groupBox2;

		private global::System.Windows.Forms.Label label4;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Button m_btnRFDataCaptureSystemConfigSet;

		private global::System.Windows.Forms.Button m_btnEtherNetModeConfigSet;

		private global::System.Windows.Forms.Label label5;

		private global::System.Windows.Forms.Label label6;

		private global::System.Windows.Forms.Label label7;

		private global::System.Windows.Forms.Label label8;

		private global::System.Windows.Forms.NumericUpDown m_nudConfigPort;

		private global::System.Windows.Forms.NumericUpDown m_nudRecordPlayBackPort;

		private global::System.Windows.Forms.Label label29;

		private global::System.Windows.Forms.Label label32;

		private global::System.Windows.Forms.Label label27;

		private global::System.Windows.Forms.Label label21;

		private global::System.Windows.Forms.Label label23;

		private global::System.Windows.Forms.Label label19;

		private global::System.Windows.Forms.Label label16;

		private global::System.Windows.Forms.Label label14;

		private global::System.Windows.Forms.Label label17;

		private global::System.Windows.Forms.ComboBox m_cboEthernetDataLogMode;

		private global::System.Windows.Forms.ComboBox m_cboEthernetDataCaptureMode;

		private global::System.Windows.Forms.ComboBox m_cboEtherneDataForamtMode;

		private global::System.Windows.Forms.ComboBox m_cboEthernetDeviceLVDSSelectMode;

		private global::System.Windows.Forms.ComboBox m_cboEthernetTransferMode;

		private global::System.Windows.Forms.TextBox m_txtIPAddress0;

		private global::System.Windows.Forms.TextBox m_txtMacAddress5;

		private global::System.Windows.Forms.TextBox m_txtMacAddress4;

		private global::System.Windows.Forms.TextBox m_txtMacAddress3;

		private global::System.Windows.Forms.TextBox m_txtMacAddress2;

		private global::System.Windows.Forms.TextBox m_txtMacAddress1;

		private global::System.Windows.Forms.TextBox m_txtMacAddress0;

		private global::System.Windows.Forms.TextBox m_txtIPAddress3;

		private global::System.Windows.Forms.TextBox m_txtIPAddress2;

		private global::System.Windows.Forms.TextBox m_txtIPAddress1;

		private global::System.Windows.Forms.Button f00022c;

		private global::System.Windows.Forms.Label label9;

		private global::System.Windows.Forms.Label f00022d;

		private global::System.Windows.Forms.Label label11;

		private global::System.Windows.Forms.Label f00022e;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label15;

		private global::System.Windows.Forms.Label label13;

		private global::System.Windows.Forms.Label label12;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress3;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress2;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress1;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress0;

		private global::System.Windows.Forms.Label label10;

		private global::System.Windows.Forms.GroupBox groupBox3;

		private global::System.Windows.Forms.Label label18;

		private global::System.Windows.Forms.Button m_btnPacketDelayConfigSet;

		private global::System.Windows.Forms.NumericUpDown m_nudPacketDelayConfig;

		private global::System.Windows.Forms.Label label20;

		private global::System.Windows.Forms.CheckBox m_ChkPacketSequenceEnaDisable;

		private global::System.Windows.Forms.Label label22;
	}
}
