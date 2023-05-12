namespace AR1xController
{
	public partial class frmAR1Main : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAR1Main));
            this.m_Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_chbTDABoard = new System.Windows.Forms.RadioButton();
            this.m_chbTSW1400Ena = new System.Windows.Forms.RadioButton();
            this.m_chbRFDataCaptureCard = new System.Windows.Forms.RadioButton();
            this.m_btnDisplayTDAStats = new System.Windows.Forms.Button();
            this.m_grpRadarSystemMode = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.m_RadarMode = new System.Windows.Forms.ComboBox();
            this.JsonConfigMainButton = new System.Windows.Forms.Button();
            this.m_grpRadarDeviceMode = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.m_DeviceMode = new System.Windows.Forms.ComboBox();
            this.m_grpRadarDeviceSelection = new System.Windows.Forms.GroupBox();
            this.m_chkRadarDevice1 = new System.Windows.Forms.CheckBox();
            this.m_chkRadarDevice4 = new System.Windows.Forms.CheckBox();
            this.m_chkRadarDevice2 = new System.Windows.Forms.CheckBox();
            this.m_chkRadarDevice3 = new System.Windows.Forms.CheckBox();
            this.m_btnStupHsdcPro = new System.Windows.Forms.Button();
            this.LoadConfig = new System.Windows.Forms.Button();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.m_lblConnection = new System.Windows.Forms.Label();
            this.m_Tbc = new System.Windows.Forms.TabControl();
            this.m_tabConnectionHolder = new System.Windows.Forms.TabPage();
            this.m_tabStaticConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabDataConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabTestSourceHolder = new System.Windows.Forms.TabPage();
            this.m_tabChirpConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabInterChirpBlockControlsConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabRegOpeHolder = new System.Windows.Forms.TabPage();
            this.m_tabProtocolHolder = new System.Windows.Forms.TabPage();
            this.m_tabContStreamHolder = new System.Windows.Forms.TabPage();
            this.m_tabBpmConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabRFStatusConfigHolder = new System.Windows.Forms.TabPage();
            this.f0001a9 = new System.Windows.Forms.TabPage();
            this.m_tabClibConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabAdvanceFrameConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabRampTimingsConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabLoopBackConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabExternalFilterProgConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabRFMonCalibrationConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabRFMonitoringConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabAnalogMonitoringConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabAnalogMonitoring2ConfigHolder = new System.Windows.Forms.TabPage();
            this.f0001aa = new System.Windows.Forms.TabPage();
            this.m_tabTxRxGainTempLutConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabMSSModuleMonitoringConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabDynamicChirpConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabClockOutConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabCalibDataRestoreConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabImportExportTabConfigHolder = new System.Windows.Forms.TabPage();
            this.m_tabTxHolder = new System.Windows.Forms.TabPage();
            this.m_tabRxHolder = new System.Windows.Forms.TabPage();
            this.m_tabCalibrationsHolder = new System.Windows.Forms.TabPage();
            this.m_tabOverHolder = new System.Windows.Forms.TabPage();
            this.m_tabBIP = new System.Windows.Forms.TabPage();
            this.m_timerChkOvfBtnEnabl = new System.Windows.Forms.Timer(this.components);
            this.m_timerCheckConnection = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printDocument3 = new System.Drawing.Printing.PrintDocument();
            this.printDocument4 = new System.Drawing.Printing.PrintDocument();
            this.printDocument5 = new System.Drawing.Printing.PrintDocument();
            this.m_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_grpRadarSystemMode.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.m_grpRadarDeviceMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_grpRadarDeviceSelection.SuspendLayout();
            this.m_Tbc.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Panel
            // 
            this.m_Panel.AutoScroll = true;
            this.m_Panel.AutoSize = true;
            this.m_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_Panel.Controls.Add(this.panel1);
            this.m_Panel.Controls.Add(this.m_btnDisplayTDAStats);
            this.m_Panel.Controls.Add(this.m_grpRadarSystemMode);
            this.m_Panel.Controls.Add(this.JsonConfigMainButton);
            this.m_Panel.Controls.Add(this.m_grpRadarDeviceMode);
            this.m_Panel.Controls.Add(this.m_grpRadarDeviceSelection);
            this.m_Panel.Controls.Add(this.m_btnStupHsdcPro);
            this.m_Panel.Controls.Add(this.LoadConfig);
            this.m_Panel.Controls.Add(this.SaveConfig);
            this.m_Panel.Controls.Add(this.m_lblConnection);
            this.m_Panel.Controls.Add(this.m_Tbc);
            this.m_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Panel.Location = new System.Drawing.Point(0, 0);
            this.m_Panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_Panel.Name = "m_Panel";
            this.m_Panel.Size = new System.Drawing.Size(1027, 700);
            this.m_Panel.TabIndex = 33;
            this.m_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.m_Panel_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_chbTDABoard);
            this.panel1.Controls.Add(this.m_chbTSW1400Ena);
            this.panel1.Controls.Add(this.m_chbRFDataCaptureCard);
            this.panel1.Location = new System.Drawing.Point(10, 219);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 74);
            this.panel1.TabIndex = 97;
            // 
            // m_chbTDABoard
            // 
            this.m_chbTDABoard.AutoSize = true;
            this.m_chbTDABoard.Location = new System.Drawing.Point(2, 50);
            this.m_chbTDABoard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chbTDABoard.Name = "m_chbTDABoard";
            this.m_chbTDABoard.Size = new System.Drawing.Size(46, 18);
            this.m_chbTDABoard.TabIndex = 2;
            this.m_chbTDABoard.Text = "TDA";
            this.m_chbTDABoard.UseVisualStyleBackColor = true;
            this.m_chbTDABoard.CheckedChanged += new System.EventHandler(this.m_chbTDABoard_CheckedChanged_1);
            // 
            // m_chbTSW1400Ena
            // 
            this.m_chbTSW1400Ena.AutoSize = true;
            this.m_chbTSW1400Ena.Location = new System.Drawing.Point(2, 30);
            this.m_chbTSW1400Ena.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chbTSW1400Ena.Name = "m_chbTSW1400Ena";
            this.m_chbTSW1400Ena.Size = new System.Drawing.Size(72, 18);
            this.m_chbTSW1400Ena.TabIndex = 1;
            this.m_chbTSW1400Ena.Text = "TSW1400";
            this.m_chbTSW1400Ena.UseVisualStyleBackColor = true;
            this.m_chbTSW1400Ena.CheckedChanged += new System.EventHandler(this.m_chbTSW1400Ena_CheckedChanged);
            // 
            // m_chbRFDataCaptureCard
            // 
            this.m_chbRFDataCaptureCard.AutoSize = true;
            this.m_chbRFDataCaptureCard.Checked = true;
            this.m_chbRFDataCaptureCard.Location = new System.Drawing.Point(2, 9);
            this.m_chbRFDataCaptureCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chbRFDataCaptureCard.Name = "m_chbRFDataCaptureCard";
            this.m_chbRFDataCaptureCard.Size = new System.Drawing.Size(71, 18);
            this.m_chbRFDataCaptureCard.TabIndex = 0;
            this.m_chbRFDataCaptureCard.TabStop = true;
            this.m_chbRFDataCaptureCard.Text = "DCA1000";
            this.m_chbRFDataCaptureCard.UseVisualStyleBackColor = true;
            this.m_chbRFDataCaptureCard.CheckedChanged += new System.EventHandler(this.m_chbRFDataCaptureCard_CheckedChanged);
            // 
            // m_btnDisplayTDAStats
            // 
            this.m_btnDisplayTDAStats.ForeColor = System.Drawing.Color.Blue;
            this.m_btnDisplayTDAStats.Location = new System.Drawing.Point(10, 567);
            this.m_btnDisplayTDAStats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnDisplayTDAStats.Name = "m_btnDisplayTDAStats";
            this.m_btnDisplayTDAStats.Size = new System.Drawing.Size(86, 34);
            this.m_btnDisplayTDAStats.TabIndex = 96;
            this.m_btnDisplayTDAStats.TabStop = false;
            this.m_btnDisplayTDAStats.Text = "Display TDA Statistics";
            this.m_btnDisplayTDAStats.UseVisualStyleBackColor = true;
            this.m_btnDisplayTDAStats.Click += new System.EventHandler(this.m_btnDisplayTDAStats_Click);
            // 
            // m_grpRadarSystemMode
            // 
            this.m_grpRadarSystemMode.Controls.Add(this.groupBox3);
            this.m_grpRadarSystemMode.Controls.Add(this.m_RadarMode);
            this.m_grpRadarSystemMode.Location = new System.Drawing.Point(5, 161);
            this.m_grpRadarSystemMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_grpRadarSystemMode.Name = "m_grpRadarSystemMode";
            this.m_grpRadarSystemMode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_grpRadarSystemMode.Size = new System.Drawing.Size(102, 54);
            this.m_grpRadarSystemMode.TabIndex = 93;
            this.m_grpRadarSystemMode.TabStop = false;
            this.m_grpRadarSystemMode.Text = "Radar System";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Location = new System.Drawing.Point(6, -165);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(102, 54);
            this.groupBox3.TabIndex = 92;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Radar System";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Two device",
            "Four Device"});
            this.comboBox2.Location = new System.Drawing.Point(6, 20);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 22);
            this.comboBox2.TabIndex = 0;
            // 
            // m_RadarMode
            // 
            this.m_RadarMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_RadarMode.FormattingEnabled = true;
            this.m_RadarMode.Items.AddRange(new object[] {
            "Single Chip",
            "Cascade"});
            this.m_RadarMode.Location = new System.Drawing.Point(6, 20);
            this.m_RadarMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_RadarMode.Name = "m_RadarMode";
            this.m_RadarMode.Size = new System.Drawing.Size(84, 22);
            this.m_RadarMode.TabIndex = 0;
            this.m_RadarMode.SelectedIndexChanged += new System.EventHandler(this.m_RadarMode_SelectedIndexChanged);
            // 
            // JsonConfigMainButton
            // 
            this.JsonConfigMainButton.Location = new System.Drawing.Point(10, 109);
            this.JsonConfigMainButton.Margin = new System.Windows.Forms.Padding(2);
            this.JsonConfigMainButton.Name = "JsonConfigMainButton";
            this.JsonConfigMainButton.Size = new System.Drawing.Size(86, 40);
            this.JsonConfigMainButton.TabIndex = 94;
            this.JsonConfigMainButton.Text = "JSON Import/Export";
            this.JsonConfigMainButton.UseVisualStyleBackColor = true;
            this.JsonConfigMainButton.Click += new System.EventHandler(this.JsonConfigMainButton_Click);
            // 
            // m_grpRadarDeviceMode
            // 
            this.m_grpRadarDeviceMode.Controls.Add(this.groupBox1);
            this.m_grpRadarDeviceMode.Controls.Add(this.m_DeviceMode);
            this.m_grpRadarDeviceMode.Location = new System.Drawing.Point(6, 355);
            this.m_grpRadarDeviceMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_grpRadarDeviceMode.Name = "m_grpRadarDeviceMode";
            this.m_grpRadarDeviceMode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_grpRadarDeviceMode.Size = new System.Drawing.Size(102, 54);
            this.m_grpRadarDeviceMode.TabIndex = 91;
            this.m_grpRadarDeviceMode.TabStop = false;
            this.m_grpRadarDeviceMode.Text = "Cascade";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, -165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(102, 54);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Radar System";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Two device",
            "Four Device"});
            this.comboBox1.Location = new System.Drawing.Point(6, 20);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 22);
            this.comboBox1.TabIndex = 0;
            // 
            // m_DeviceMode
            // 
            this.m_DeviceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_DeviceMode.Enabled = false;
            this.m_DeviceMode.FormattingEnabled = true;
            this.m_DeviceMode.Items.AddRange(new object[] {
            "Two device",
            "Four Device"});
            this.m_DeviceMode.Location = new System.Drawing.Point(6, 20);
            this.m_DeviceMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_DeviceMode.Name = "m_DeviceMode";
            this.m_DeviceMode.Size = new System.Drawing.Size(84, 22);
            this.m_DeviceMode.TabIndex = 0;
            this.m_DeviceMode.SelectedIndexChanged += new System.EventHandler(this.m_nudRadarDeviceSystem_ValueChanged);
            // 
            // m_grpRadarDeviceSelection
            // 
            this.m_grpRadarDeviceSelection.Controls.Add(this.m_chkRadarDevice1);
            this.m_grpRadarDeviceSelection.Controls.Add(this.m_chkRadarDevice4);
            this.m_grpRadarDeviceSelection.Controls.Add(this.m_chkRadarDevice2);
            this.m_grpRadarDeviceSelection.Controls.Add(this.m_chkRadarDevice3);
            this.m_grpRadarDeviceSelection.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpRadarDeviceSelection.Location = new System.Drawing.Point(6, 420);
            this.m_grpRadarDeviceSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_grpRadarDeviceSelection.Name = "m_grpRadarDeviceSelection";
            this.m_grpRadarDeviceSelection.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_grpRadarDeviceSelection.Size = new System.Drawing.Size(102, 134);
            this.m_grpRadarDeviceSelection.TabIndex = 90;
            this.m_grpRadarDeviceSelection.TabStop = false;
            this.m_grpRadarDeviceSelection.Text = "Device Selection";
            // 
            // m_chkRadarDevice1
            // 
            this.m_chkRadarDevice1.AutoSize = true;
            this.m_chkRadarDevice1.Location = new System.Drawing.Point(8, 26);
            this.m_chkRadarDevice1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chkRadarDevice1.Name = "m_chkRadarDevice1";
            this.m_chkRadarDevice1.Size = new System.Drawing.Size(94, 18);
            this.m_chkRadarDevice1.TabIndex = 86;
            this.m_chkRadarDevice1.Text = "RadarDevice1";
            this.m_chkRadarDevice1.UseVisualStyleBackColor = true;
            this.m_chkRadarDevice1.CheckedChanged += new System.EventHandler(this.m_nudRadarDevice1Id_Changed);
            // 
            // m_chkRadarDevice4
            // 
            this.m_chkRadarDevice4.AutoSize = true;
            this.m_chkRadarDevice4.Location = new System.Drawing.Point(8, 102);
            this.m_chkRadarDevice4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chkRadarDevice4.Name = "m_chkRadarDevice4";
            this.m_chkRadarDevice4.Size = new System.Drawing.Size(94, 18);
            this.m_chkRadarDevice4.TabIndex = 89;
            this.m_chkRadarDevice4.Text = "RadarDevice4";
            this.m_chkRadarDevice4.UseVisualStyleBackColor = true;
            this.m_chkRadarDevice4.CheckedChanged += new System.EventHandler(this.m_nudRadarDevice4Id_Changed);
            // 
            // m_chkRadarDevice2
            // 
            this.m_chkRadarDevice2.AutoSize = true;
            this.m_chkRadarDevice2.Location = new System.Drawing.Point(8, 50);
            this.m_chkRadarDevice2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chkRadarDevice2.Name = "m_chkRadarDevice2";
            this.m_chkRadarDevice2.Size = new System.Drawing.Size(94, 18);
            this.m_chkRadarDevice2.TabIndex = 87;
            this.m_chkRadarDevice2.Text = "RadarDevice2";
            this.m_chkRadarDevice2.UseVisualStyleBackColor = true;
            this.m_chkRadarDevice2.CheckedChanged += new System.EventHandler(this.m_nudRadarDevice2Id_Changed);
            // 
            // m_chkRadarDevice3
            // 
            this.m_chkRadarDevice3.AutoSize = true;
            this.m_chkRadarDevice3.Location = new System.Drawing.Point(8, 78);
            this.m_chkRadarDevice3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_chkRadarDevice3.Name = "m_chkRadarDevice3";
            this.m_chkRadarDevice3.Size = new System.Drawing.Size(94, 18);
            this.m_chkRadarDevice3.TabIndex = 88;
            this.m_chkRadarDevice3.Text = "RadarDevice3";
            this.m_chkRadarDevice3.UseVisualStyleBackColor = true;
            this.m_chkRadarDevice3.CheckedChanged += new System.EventHandler(this.m_nudRadarDevice3Id_Changed);
            // 
            // m_btnStupHsdcPro
            // 
            this.m_btnStupHsdcPro.ForeColor = System.Drawing.Color.Blue;
            this.m_btnStupHsdcPro.Location = new System.Drawing.Point(10, 302);
            this.m_btnStupHsdcPro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnStupHsdcPro.Name = "m_btnStupHsdcPro";
            this.m_btnStupHsdcPro.Size = new System.Drawing.Size(86, 40);
            this.m_btnStupHsdcPro.TabIndex = 83;
            this.m_btnStupHsdcPro.TabStop = false;
            this.m_btnStupHsdcPro.Text = "SetUp DCA1000";
            this.m_btnStupHsdcPro.UseVisualStyleBackColor = true;
            this.m_btnStupHsdcPro.Click += new System.EventHandler(this.m_btnStupHsdcPro_Click);
            // 
            // LoadConfig
            // 
            this.LoadConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadConfig.Location = new System.Drawing.Point(10, 16);
            this.LoadConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadConfig.Name = "LoadConfig";
            this.LoadConfig.Size = new System.Drawing.Size(81, 24);
            this.LoadConfig.TabIndex = 80;
            this.LoadConfig.TabStop = false;
            this.LoadConfig.Text = "LoadConfig";
            this.LoadConfig.UseVisualStyleBackColor = true;
            this.LoadConfig.Click += new System.EventHandler(this.LoadConfig_Click);
            // 
            // SaveConfig
            // 
            this.SaveConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveConfig.Location = new System.Drawing.Point(10, 58);
            this.SaveConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(82, 26);
            this.SaveConfig.TabIndex = 82;
            this.SaveConfig.TabStop = false;
            this.SaveConfig.Text = "SaveConfig";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // m_lblConnection
            // 
            this.m_lblConnection.AutoSize = true;
            this.m_lblConnection.BackColor = System.Drawing.Color.Red;
            this.m_lblConnection.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblConnection.Location = new System.Drawing.Point(10, 14);
            this.m_lblConnection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_lblConnection.Name = "m_lblConnection";
            this.m_lblConnection.Size = new System.Drawing.Size(70, 16);
            this.m_lblConnection.TabIndex = 35;
            this.m_lblConnection.Text = "Not Connected";
            this.m_lblConnection.Visible = false;
            // 
            // m_Tbc
            // 
            this.m_Tbc.Controls.Add(this.m_tabConnectionHolder);
            this.m_Tbc.Controls.Add(this.m_tabStaticConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabDataConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabTestSourceHolder);
            this.m_Tbc.Controls.Add(this.m_tabChirpConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabInterChirpBlockControlsConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabRegOpeHolder);
            this.m_Tbc.Controls.Add(this.m_tabProtocolHolder);
            this.m_Tbc.Controls.Add(this.m_tabContStreamHolder);
            this.m_Tbc.Controls.Add(this.m_tabBpmConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabRFStatusConfigHolder);
            this.m_Tbc.Controls.Add(this.f0001a9);
            this.m_Tbc.Controls.Add(this.m_tabClibConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabAdvanceFrameConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabRampTimingsConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabLoopBackConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabExternalFilterProgConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabRFMonCalibrationConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabRFMonitoringConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabAnalogMonitoringConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabAnalogMonitoring2ConfigHolder);
            this.m_Tbc.Controls.Add(this.f0001aa);
            this.m_Tbc.Controls.Add(this.m_tabTxRxGainTempLutConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabMSSModuleMonitoringConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabDynamicChirpConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabClockOutConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabCalibDataRestoreConfigHolder);
            this.m_Tbc.Controls.Add(this.m_tabImportExportTabConfigHolder);
            this.m_Tbc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Tbc.Location = new System.Drawing.Point(114, 2);
            this.m_Tbc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_Tbc.Multiline = true;
            this.m_Tbc.Name = "m_Tbc";
            this.m_Tbc.SelectedIndex = 0;
            this.m_Tbc.Size = new System.Drawing.Size(1620, 720);
            this.m_Tbc.TabIndex = 33;
            this.m_Tbc.SelectedIndexChanged += new System.EventHandler(this.m_Tbc_SelectedIndexChanged);
            // 
            // m_tabConnectionHolder
            // 
            this.m_tabConnectionHolder.AutoScroll = true;
            this.m_tabConnectionHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabConnectionHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabConnectionHolder.Name = "m_tabConnectionHolder";
            this.m_tabConnectionHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabConnectionHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabConnectionHolder.TabIndex = 0;
            this.m_tabConnectionHolder.Text = "Connection";
            this.m_tabConnectionHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabStaticConfigHolder
            // 
            this.m_tabStaticConfigHolder.AutoScroll = true;
            this.m_tabStaticConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabStaticConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabStaticConfigHolder.Name = "m_tabStaticConfigHolder";
            this.m_tabStaticConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabStaticConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabStaticConfigHolder.TabIndex = 2;
            this.m_tabStaticConfigHolder.Text = "StaticConfig";
            this.m_tabStaticConfigHolder.UseVisualStyleBackColor = true;
            this.m_tabStaticConfigHolder.Click += new System.EventHandler(this.m_tabStaticConfigHolder_Click);
            // 
            // m_tabDataConfigHolder
            // 
            this.m_tabDataConfigHolder.AccessibleName = "";
            this.m_tabDataConfigHolder.AutoScroll = true;
            this.m_tabDataConfigHolder.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_tabDataConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabDataConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabDataConfigHolder.Name = "m_tabDataConfigHolder";
            this.m_tabDataConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabDataConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabDataConfigHolder.TabIndex = 3;
            this.m_tabDataConfigHolder.Text = "DataConfig";
            this.m_tabDataConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabTestSourceHolder
            // 
            this.m_tabTestSourceHolder.AutoScroll = true;
            this.m_tabTestSourceHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabTestSourceHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabTestSourceHolder.Name = "m_tabTestSourceHolder";
            this.m_tabTestSourceHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabTestSourceHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabTestSourceHolder.TabIndex = 5;
            this.m_tabTestSourceHolder.Text = "TestSource";
            this.m_tabTestSourceHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabChirpConfigHolder
            // 
            this.m_tabChirpConfigHolder.AutoScroll = true;
            this.m_tabChirpConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabChirpConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabChirpConfigHolder.Name = "m_tabChirpConfigHolder";
            this.m_tabChirpConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabChirpConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabChirpConfigHolder.TabIndex = 4;
            this.m_tabChirpConfigHolder.Text = "SensorConfig";
            this.m_tabChirpConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabInterChirpBlockControlsConfigHolder
            // 
            this.m_tabInterChirpBlockControlsConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabInterChirpBlockControlsConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabInterChirpBlockControlsConfigHolder.Name = "m_tabInterChirpBlockControlsConfigHolder";
            this.m_tabInterChirpBlockControlsConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabInterChirpBlockControlsConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabInterChirpBlockControlsConfigHolder.TabIndex = 27;
            this.m_tabInterChirpBlockControlsConfigHolder.Text = "IntChirpBlkCtlCfg";
            this.m_tabInterChirpBlockControlsConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabRegOpeHolder
            // 
            this.m_tabRegOpeHolder.AutoScroll = true;
            this.m_tabRegOpeHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabRegOpeHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRegOpeHolder.Name = "m_tabRegOpeHolder";
            this.m_tabRegOpeHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRegOpeHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabRegOpeHolder.TabIndex = 6;
            this.m_tabRegOpeHolder.Text = "RegOp";
            this.m_tabRegOpeHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabProtocolHolder
            // 
            this.m_tabProtocolHolder.AutoScroll = true;
            this.m_tabProtocolHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabProtocolHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabProtocolHolder.Name = "m_tabProtocolHolder";
            this.m_tabProtocolHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabProtocolHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabProtocolHolder.TabIndex = 7;
            this.m_tabProtocolHolder.Text = "Protocol";
            this.m_tabProtocolHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabContStreamHolder
            // 
            this.m_tabContStreamHolder.AutoScroll = true;
            this.m_tabContStreamHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabContStreamHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabContStreamHolder.Name = "m_tabContStreamHolder";
            this.m_tabContStreamHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabContStreamHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabContStreamHolder.TabIndex = 8;
            this.m_tabContStreamHolder.Text = "ContStream";
            this.m_tabContStreamHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabBpmConfigHolder
            // 
            this.m_tabBpmConfigHolder.AutoScroll = true;
            this.m_tabBpmConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabBpmConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabBpmConfigHolder.Name = "m_tabBpmConfigHolder";
            this.m_tabBpmConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabBpmConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabBpmConfigHolder.TabIndex = 9;
            this.m_tabBpmConfigHolder.Text = "BPMConfig";
            this.m_tabBpmConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabRFStatusConfigHolder
            // 
            this.m_tabRFStatusConfigHolder.AutoScroll = true;
            this.m_tabRFStatusConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabRFStatusConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRFStatusConfigHolder.Name = "m_tabRFStatusConfigHolder";
            this.m_tabRFStatusConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRFStatusConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabRFStatusConfigHolder.TabIndex = 10;
            this.m_tabRFStatusConfigHolder.Text = "BssChar";
            this.m_tabRFStatusConfigHolder.UseVisualStyleBackColor = true;
            // 
            // f0001a9
            // 
            this.f0001a9.AutoScroll = true;
            this.f0001a9.Location = new System.Drawing.Point(4, 44);
            this.f0001a9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f0001a9.Name = "f0001a9";
            this.f0001a9.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f0001a9.Size = new System.Drawing.Size(1612, 672);
            this.f0001a9.TabIndex = 11;
            this.f0001a9.Text = "PMICConfig";
            this.f0001a9.UseVisualStyleBackColor = true;
            // 
            // m_tabClibConfigHolder
            // 
            this.m_tabClibConfigHolder.AutoScroll = true;
            this.m_tabClibConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabClibConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabClibConfigHolder.Name = "m_tabClibConfigHolder";
            this.m_tabClibConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabClibConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabClibConfigHolder.TabIndex = 12;
            this.m_tabClibConfigHolder.Text = "EventMonitor";
            this.m_tabClibConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabAdvanceFrameConfigHolder
            // 
            this.m_tabAdvanceFrameConfigHolder.AutoScroll = true;
            this.m_tabAdvanceFrameConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabAdvanceFrameConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabAdvanceFrameConfigHolder.Name = "m_tabAdvanceFrameConfigHolder";
            this.m_tabAdvanceFrameConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabAdvanceFrameConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabAdvanceFrameConfigHolder.TabIndex = 13;
            this.m_tabAdvanceFrameConfigHolder.Text = "AdvFrameConfig";
            this.m_tabAdvanceFrameConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabRampTimingsConfigHolder
            // 
            this.m_tabRampTimingsConfigHolder.AutoScroll = true;
            this.m_tabRampTimingsConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabRampTimingsConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRampTimingsConfigHolder.Name = "m_tabRampTimingsConfigHolder";
            this.m_tabRampTimingsConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRampTimingsConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabRampTimingsConfigHolder.TabIndex = 14;
            this.m_tabRampTimingsConfigHolder.Text = "RampTimingCalculator";
            this.m_tabRampTimingsConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabLoopBackConfigHolder
            // 
            this.m_tabLoopBackConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabLoopBackConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabLoopBackConfigHolder.Name = "m_tabLoopBackConfigHolder";
            this.m_tabLoopBackConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabLoopBackConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabLoopBackConfigHolder.TabIndex = 15;
            this.m_tabLoopBackConfigHolder.Text = "LoopBack";
            this.m_tabLoopBackConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabExternalFilterProgConfigHolder
            // 
            this.m_tabExternalFilterProgConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabExternalFilterProgConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabExternalFilterProgConfigHolder.Name = "m_tabExternalFilterProgConfigHolder";
            this.m_tabExternalFilterProgConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabExternalFilterProgConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabExternalFilterProgConfigHolder.TabIndex = 16;
            this.m_tabExternalFilterProgConfigHolder.Text = "ExtFilterProg";
            this.m_tabExternalFilterProgConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabRFMonCalibrationConfigHolder
            // 
            this.m_tabRFMonCalibrationConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabRFMonCalibrationConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRFMonCalibrationConfigHolder.Name = "m_tabRFMonCalibrationConfigHolder";
            this.m_tabRFMonCalibrationConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRFMonCalibrationConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabRFMonCalibrationConfigHolder.TabIndex = 17;
            this.m_tabRFMonCalibrationConfigHolder.Text = "CalibConfig";
            this.m_tabRFMonCalibrationConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabRFMonitoringConfigHolder
            // 
            this.m_tabRFMonitoringConfigHolder.AutoScroll = true;
            this.m_tabRFMonitoringConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabRFMonitoringConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRFMonitoringConfigHolder.Name = "m_tabRFMonitoringConfigHolder";
            this.m_tabRFMonitoringConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabRFMonitoringConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabRFMonitoringConfigHolder.TabIndex = 18;
            this.m_tabRFMonitoringConfigHolder.Text = "DigitalMon";
            this.m_tabRFMonitoringConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabAnalogMonitoringConfigHolder
            // 
            this.m_tabAnalogMonitoringConfigHolder.AutoScroll = true;
            this.m_tabAnalogMonitoringConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabAnalogMonitoringConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabAnalogMonitoringConfigHolder.Name = "m_tabAnalogMonitoringConfigHolder";
            this.m_tabAnalogMonitoringConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabAnalogMonitoringConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabAnalogMonitoringConfigHolder.TabIndex = 19;
            this.m_tabAnalogMonitoringConfigHolder.Text = "AnalogTxMon";
            this.m_tabAnalogMonitoringConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabAnalogMonitoring2ConfigHolder
            // 
            this.m_tabAnalogMonitoring2ConfigHolder.AutoScroll = true;
            this.m_tabAnalogMonitoring2ConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabAnalogMonitoring2ConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabAnalogMonitoring2ConfigHolder.Name = "m_tabAnalogMonitoring2ConfigHolder";
            this.m_tabAnalogMonitoring2ConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabAnalogMonitoring2ConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabAnalogMonitoring2ConfigHolder.TabIndex = 20;
            this.m_tabAnalogMonitoring2ConfigHolder.Text = "AnalogRxMon";
            this.m_tabAnalogMonitoring2ConfigHolder.UseVisualStyleBackColor = true;
            // 
            // f0001aa
            // 
            this.f0001aa.Location = new System.Drawing.Point(4, 44);
            this.f0001aa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f0001aa.Name = "f0001aa";
            this.f0001aa.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f0001aa.Size = new System.Drawing.Size(1612, 672);
            this.f0001aa.TabIndex = 22;
            this.f0001aa.Text = "DCBISTMon";
            this.f0001aa.UseVisualStyleBackColor = true;
            // 
            // m_tabTxRxGainTempLutConfigHolder
            // 
            this.m_tabTxRxGainTempLutConfigHolder.AutoScroll = true;
            this.m_tabTxRxGainTempLutConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabTxRxGainTempLutConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabTxRxGainTempLutConfigHolder.Name = "m_tabTxRxGainTempLutConfigHolder";
            this.m_tabTxRxGainTempLutConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabTxRxGainTempLutConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabTxRxGainTempLutConfigHolder.TabIndex = 21;
            this.m_tabTxRxGainTempLutConfigHolder.Text = "TxRxGainTemp";
            this.m_tabTxRxGainTempLutConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabMSSModuleMonitoringConfigHolder
            // 
            this.m_tabMSSModuleMonitoringConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabMSSModuleMonitoringConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabMSSModuleMonitoringConfigHolder.Name = "m_tabMSSModuleMonitoringConfigHolder";
            this.m_tabMSSModuleMonitoringConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabMSSModuleMonitoringConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabMSSModuleMonitoringConfigHolder.TabIndex = 23;
            this.m_tabMSSModuleMonitoringConfigHolder.Text = "MSSMon";
            this.m_tabMSSModuleMonitoringConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabDynamicChirpConfigHolder
            // 
            this.m_tabDynamicChirpConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabDynamicChirpConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabDynamicChirpConfigHolder.Name = "m_tabDynamicChirpConfigHolder";
            this.m_tabDynamicChirpConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabDynamicChirpConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabDynamicChirpConfigHolder.TabIndex = 24;
            this.m_tabDynamicChirpConfigHolder.Text = "DynamicChirpCfg";
            this.m_tabDynamicChirpConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabClockOutConfigHolder
            // 
            this.m_tabClockOutConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabClockOutConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabClockOutConfigHolder.Name = "m_tabClockOutConfigHolder";
            this.m_tabClockOutConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabClockOutConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabClockOutConfigHolder.TabIndex = 25;
            this.m_tabClockOutConfigHolder.Text = "ClockOutCfg";
            this.m_tabClockOutConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabCalibDataRestoreConfigHolder
            // 
            this.m_tabCalibDataRestoreConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabCalibDataRestoreConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabCalibDataRestoreConfigHolder.Name = "m_tabCalibDataRestoreConfigHolder";
            this.m_tabCalibDataRestoreConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabCalibDataRestoreConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabCalibDataRestoreConfigHolder.TabIndex = 26;
            this.m_tabCalibDataRestoreConfigHolder.Text = "CalibDataCfg";
            this.m_tabCalibDataRestoreConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabImportExportTabConfigHolder
            // 
            this.m_tabImportExportTabConfigHolder.Location = new System.Drawing.Point(4, 44);
            this.m_tabImportExportTabConfigHolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabImportExportTabConfigHolder.Name = "m_tabImportExportTabConfigHolder";
            this.m_tabImportExportTabConfigHolder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_tabImportExportTabConfigHolder.Size = new System.Drawing.Size(1612, 672);
            this.m_tabImportExportTabConfigHolder.TabIndex = 29;
            this.m_tabImportExportTabConfigHolder.Text = "Import_Export";
            this.m_tabImportExportTabConfigHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabTxHolder
            // 
            this.m_tabTxHolder.Location = new System.Drawing.Point(4, 22);
            this.m_tabTxHolder.Name = "m_tabTxHolder";
            this.m_tabTxHolder.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabTxHolder.Size = new System.Drawing.Size(790, 305);
            this.m_tabTxHolder.TabIndex = 1;
            this.m_tabTxHolder.Text = "TX";
            this.m_tabTxHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabRxHolder
            // 
            this.m_tabRxHolder.Location = new System.Drawing.Point(4, 22);
            this.m_tabRxHolder.Name = "m_tabRxHolder";
            this.m_tabRxHolder.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabRxHolder.Size = new System.Drawing.Size(790, 305);
            this.m_tabRxHolder.TabIndex = 2;
            this.m_tabRxHolder.Text = "RX";
            this.m_tabRxHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabCalibrationsHolder
            // 
            this.m_tabCalibrationsHolder.Location = new System.Drawing.Point(4, 22);
            this.m_tabCalibrationsHolder.Name = "m_tabCalibrationsHolder";
            this.m_tabCalibrationsHolder.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabCalibrationsHolder.Size = new System.Drawing.Size(790, 305);
            this.m_tabCalibrationsHolder.TabIndex = 4;
            this.m_tabCalibrationsHolder.Text = "Calibrations";
            this.m_tabCalibrationsHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabOverHolder
            // 
            this.m_tabOverHolder.Location = new System.Drawing.Point(4, 22);
            this.m_tabOverHolder.Name = "m_tabOverHolder";
            this.m_tabOverHolder.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabOverHolder.Size = new System.Drawing.Size(790, 305);
            this.m_tabOverHolder.TabIndex = 5;
            this.m_tabOverHolder.Text = "Overrides";
            this.m_tabOverHolder.UseVisualStyleBackColor = true;
            // 
            // m_tabBIP
            // 
            this.m_tabBIP.Location = new System.Drawing.Point(4, 22);
            this.m_tabBIP.Name = "m_tabBIP";
            this.m_tabBIP.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabBIP.Size = new System.Drawing.Size(790, 305);
            this.m_tabBIP.TabIndex = 6;
            this.m_tabBIP.Text = "Bip";
            this.m_tabBIP.UseVisualStyleBackColor = true;
            // 
            // m_timerChkOvfBtnEnabl
            // 
            this.m_timerChkOvfBtnEnabl.Interval = 10000;
            this.m_timerChkOvfBtnEnabl.Tick += new System.EventHandler(this.m_timerChkOvfBtnEnabl_Tick);
            // 
            // m_timerCheckConnection
            // 
            this.m_timerCheckConnection.Interval = 3000;
            this.m_timerCheckConnection.Tick += new System.EventHandler(this.m_timerCheckConnection_Tick);
            // 
            // frmAR1Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1027, 700);
            this.CloseButton = false;
            this.Controls.Add(this.m_Panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAR1Main";
            this.Text = "RadarAPI";
            this.TopMost = true;
            this.DockStateChanged += new System.EventHandler(this.frmAR1Main_DockStateChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAR1Main_FormClosing);
            this.Load += new System.EventHandler(this.frmAR1Main_Load);
            this.m_Panel.ResumeLayout(false);
            this.m_Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_grpRadarSystemMode.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.m_grpRadarDeviceMode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.m_grpRadarDeviceSelection.ResumeLayout(false);
            this.m_grpRadarDeviceSelection.PerformLayout();
            this.m_Tbc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Panel m_Panel;

		private global::System.Windows.Forms.TabPage m_tabRxHolder;

		private global::System.Windows.Forms.TabPage m_tabOverHolder;

		private global::System.Windows.Forms.TabPage m_tabBIP;

		private global::System.Windows.Forms.TabPage m_tabCalibrationsHolder;

		private global::System.Windows.Forms.Label m_lblConnection;

		private global::System.Windows.Forms.TabPage m_tabTxHolder;

		private global::System.Windows.Forms.Button LoadConfig;

		private global::System.Windows.Forms.Button SaveConfig;

		private global::System.Windows.Forms.Timer m_timerChkOvfBtnEnabl;

		private global::System.Windows.Forms.Timer m_timerCheckConnection;

		private global::System.Windows.Forms.Button m_btnStupHsdcPro;

		private global::System.Windows.Forms.CheckBox m_chkRadarDevice4;

		private global::System.Windows.Forms.CheckBox m_chkRadarDevice3;

		private global::System.Windows.Forms.CheckBox m_chkRadarDevice2;

		private global::System.Windows.Forms.CheckBox m_chkRadarDevice1;

		private global::System.Windows.Forms.GroupBox m_grpRadarDeviceSelection;

		private global::System.Windows.Forms.GroupBox m_grpRadarDeviceMode;

		private global::System.Windows.Forms.ComboBox m_DeviceMode;

		private global::System.Drawing.Printing.PrintDocument printDocument1;

		private global::System.Drawing.Printing.PrintDocument printDocument2;

		private global::System.Drawing.Printing.PrintDocument printDocument3;

		private global::System.Drawing.Printing.PrintDocument printDocument4;

		private global::System.Drawing.Printing.PrintDocument printDocument5;

		private global::System.Windows.Forms.Button JsonConfigMainButton;

		private global::System.Windows.Forms.TabControl m_Tbc;

		private global::System.Windows.Forms.TabPage m_tabConnectionHolder;

		private global::System.Windows.Forms.TabPage m_tabStaticConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabDataConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabTestSourceHolder;

		private global::System.Windows.Forms.TabPage m_tabChirpConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabInterChirpBlockControlsConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabRegOpeHolder;

		private global::System.Windows.Forms.TabPage m_tabProtocolHolder;

		private global::System.Windows.Forms.TabPage m_tabContStreamHolder;

		private global::System.Windows.Forms.TabPage m_tabBpmConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabRFStatusConfigHolder;

		private global::System.Windows.Forms.TabPage f0001a9;

		private global::System.Windows.Forms.TabPage m_tabClibConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabAdvanceFrameConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabRampTimingsConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabLoopBackConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabExternalFilterProgConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabRFMonCalibrationConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabRFMonitoringConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabAnalogMonitoringConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabAnalogMonitoring2ConfigHolder;

		private global::System.Windows.Forms.TabPage f0001aa;

		private global::System.Windows.Forms.TabPage m_tabTxRxGainTempLutConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabMSSModuleMonitoringConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabDynamicChirpConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabClockOutConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabCalibDataRestoreConfigHolder;

		private global::System.Windows.Forms.TabPage m_tabImportExportTabConfigHolder;

		private global::System.Windows.Forms.GroupBox m_grpRadarSystemMode;

		private global::System.Windows.Forms.GroupBox groupBox3;

		private global::System.Windows.Forms.ComboBox comboBox2;

		private global::System.Windows.Forms.ComboBox m_RadarMode;

		private global::System.Windows.Forms.GroupBox groupBox1;

		private global::System.Windows.Forms.ComboBox comboBox1;

		private global::System.Windows.Forms.Button m_btnDisplayTDAStats;

		private global::System.Windows.Forms.Panel panel1;

		private global::System.Windows.Forms.RadioButton m_chbRFDataCaptureCard;

		private global::System.Windows.Forms.RadioButton m_chbTDABoard;

		private global::System.Windows.Forms.RadioButton m_chbTSW1400Ena;
	}
}
