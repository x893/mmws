namespace AR1xController
{
	public partial class TDAxxCaptureCard : global::System.Windows.Forms.Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtHostSystemIPAddress0 = new System.Windows.Forms.TextBox();
            this.m_txtHostSystemIPAddress1 = new System.Windows.Forms.TextBox();
            this.m_txtHostSystemIPAddress2 = new System.Windows.Forms.TextBox();
            this.m_txtHostSystemIPAddress3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_nudConfigPort = new System.Windows.Forms.NumericUpDown();
            this.m_btnRFDataCaptureSystemConfigSet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_boxMasterEnable = new System.Windows.Forms.CheckBox();
            this.m_boxSlave1Enable = new System.Windows.Forms.CheckBox();
            this.m_boxSlave2Enable = new System.Windows.Forms.CheckBox();
            this.m_boxSlave3Enable = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudConfigPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TDAxx IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Configuration Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TDAxx Capture Card Configuration";
            // 
            // m_txtHostSystemIPAddress0
            // 
            this.m_txtHostSystemIPAddress0.Location = new System.Drawing.Point(139, 43);
            this.m_txtHostSystemIPAddress0.Name = "m_txtHostSystemIPAddress0";
            this.m_txtHostSystemIPAddress0.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress0.TabIndex = 43;
            this.m_txtHostSystemIPAddress0.Text = "0";
            // 
            // m_txtHostSystemIPAddress1
            // 
            this.m_txtHostSystemIPAddress1.Location = new System.Drawing.Point(188, 43);
            this.m_txtHostSystemIPAddress1.Name = "m_txtHostSystemIPAddress1";
            this.m_txtHostSystemIPAddress1.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress1.TabIndex = 44;
            this.m_txtHostSystemIPAddress1.Text = "0";
            // 
            // m_txtHostSystemIPAddress2
            // 
            this.m_txtHostSystemIPAddress2.Location = new System.Drawing.Point(238, 43);
            this.m_txtHostSystemIPAddress2.Name = "m_txtHostSystemIPAddress2";
            this.m_txtHostSystemIPAddress2.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress2.TabIndex = 45;
            this.m_txtHostSystemIPAddress2.Text = "0";
            // 
            // m_txtHostSystemIPAddress3
            // 
            this.m_txtHostSystemIPAddress3.Location = new System.Drawing.Point(289, 43);
            this.m_txtHostSystemIPAddress3.Name = "m_txtHostSystemIPAddress3";
            this.m_txtHostSystemIPAddress3.Size = new System.Drawing.Size(30, 20);
            this.m_txtHostSystemIPAddress3.TabIndex = 46;
            this.m_txtHostSystemIPAddress3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = ".";
            // 
            // m_nudConfigPort
            // 
            this.m_nudConfigPort.Enabled = false;
            this.m_nudConfigPort.Location = new System.Drawing.Point(139, 76);
            this.m_nudConfigPort.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.m_nudConfigPort.Name = "m_nudConfigPort";
            this.m_nudConfigPort.Size = new System.Drawing.Size(54, 20);
            this.m_nudConfigPort.TabIndex = 50;
            this.m_nudConfigPort.Value = new decimal(new int[] {
            5001,
            0,
            0,
            0});
            // 
            // m_btnRFDataCaptureSystemConfigSet
            // 
            this.m_btnRFDataCaptureSystemConfigSet.Location = new System.Drawing.Point(93, 223);
            this.m_btnRFDataCaptureSystemConfigSet.Name = "m_btnRFDataCaptureSystemConfigSet";
            this.m_btnRFDataCaptureSystemConfigSet.Size = new System.Drawing.Size(165, 32);
            this.m_btnRFDataCaptureSystemConfigSet.TabIndex = 51;
            this.m_btnRFDataCaptureSystemConfigSet.Text = "Connect and Configure";
            this.m_btnRFDataCaptureSystemConfigSet.UseVisualStyleBackColor = true;
            this.m_btnRFDataCaptureSystemConfigSet.Click += new System.EventHandler(this.m_btnRFDataCaptureSystemConfigSet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Devices to be enabled by TDAxx";
            // 
            // m_boxMasterEnable
            // 
            this.m_boxMasterEnable.AutoSize = true;
            this.m_boxMasterEnable.Checked = true;
            this.m_boxMasterEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_boxMasterEnable.Location = new System.Drawing.Point(35, 141);
            this.m_boxMasterEnable.Margin = new System.Windows.Forms.Padding(2);
            this.m_boxMasterEnable.Name = "m_boxMasterEnable";
            this.m_boxMasterEnable.Size = new System.Drawing.Size(58, 17);
            this.m_boxMasterEnable.TabIndex = 53;
            this.m_boxMasterEnable.Text = "Master";
            this.m_boxMasterEnable.UseVisualStyleBackColor = true;
            // 
            // m_boxSlave1Enable
            // 
            this.m_boxSlave1Enable.AutoSize = true;
            this.m_boxSlave1Enable.Checked = true;
            this.m_boxSlave1Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_boxSlave1Enable.Location = new System.Drawing.Point(104, 141);
            this.m_boxSlave1Enable.Margin = new System.Windows.Forms.Padding(2);
            this.m_boxSlave1Enable.Name = "m_boxSlave1Enable";
            this.m_boxSlave1Enable.Size = new System.Drawing.Size(62, 17);
            this.m_boxSlave1Enable.TabIndex = 54;
            this.m_boxSlave1Enable.Text = "Slave 1";
            this.m_boxSlave1Enable.UseVisualStyleBackColor = true;
            this.m_boxSlave1Enable.CheckedChanged += new System.EventHandler(this.m_boxSlave1Enable_CheckedChanged);
            // 
            // m_boxSlave2Enable
            // 
            this.m_boxSlave2Enable.AutoSize = true;
            this.m_boxSlave2Enable.Checked = true;
            this.m_boxSlave2Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_boxSlave2Enable.Location = new System.Drawing.Point(182, 141);
            this.m_boxSlave2Enable.Margin = new System.Windows.Forms.Padding(2);
            this.m_boxSlave2Enable.Name = "m_boxSlave2Enable";
            this.m_boxSlave2Enable.Size = new System.Drawing.Size(62, 17);
            this.m_boxSlave2Enable.TabIndex = 55;
            this.m_boxSlave2Enable.Text = "Slave 2";
            this.m_boxSlave2Enable.UseVisualStyleBackColor = true;
            // 
            // m_boxSlave3Enable
            // 
            this.m_boxSlave3Enable.AutoSize = true;
            this.m_boxSlave3Enable.Checked = true;
            this.m_boxSlave3Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_boxSlave3Enable.Location = new System.Drawing.Point(260, 141);
            this.m_boxSlave3Enable.Margin = new System.Windows.Forms.Padding(2);
            this.m_boxSlave3Enable.Name = "m_boxSlave3Enable";
            this.m_boxSlave3Enable.Size = new System.Drawing.Size(62, 17);
            this.m_boxSlave3Enable.TabIndex = 56;
            this.m_boxSlave3Enable.Text = "Slave 3";
            this.m_boxSlave3Enable.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 173);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "TDA Binary Version/ Build Time";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_version.Location = new System.Drawing.Point(33, 199);
            this.label_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(10, 13);
            this.label_version.TabIndex = 58;
            this.label_version.Text = "-";
            // 
            // TDAxxCaptureCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 265);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_boxSlave3Enable);
            this.Controls.Add(this.m_boxSlave2Enable);
            this.Controls.Add(this.m_boxSlave1Enable);
            this.Controls.Add(this.m_boxMasterEnable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnRFDataCaptureSystemConfigSet);
            this.Controls.Add(this.m_nudConfigPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_txtHostSystemIPAddress3);
            this.Controls.Add(this.m_txtHostSystemIPAddress2);
            this.Controls.Add(this.m_txtHostSystemIPAddress1);
            this.Controls.Add(this.m_txtHostSystemIPAddress0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TDAxxCaptureCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TDAxxCaptureCard";
            ((System.ComponentModel.ISupportInitialize)(this.m_nudConfigPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress0;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress1;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress2;

		private global::System.Windows.Forms.TextBox m_txtHostSystemIPAddress3;

		private global::System.Windows.Forms.Label label4;

		private global::System.Windows.Forms.Label label5;

		private global::System.Windows.Forms.Label label6;

		private global::System.Windows.Forms.NumericUpDown m_nudConfigPort;

		private global::System.Windows.Forms.Button m_btnRFDataCaptureSystemConfigSet;

		private global::System.Windows.Forms.Label label7;

		private global::System.Windows.Forms.CheckBox m_boxMasterEnable;

		private global::System.Windows.Forms.CheckBox m_boxSlave1Enable;

		private global::System.Windows.Forms.CheckBox m_boxSlave2Enable;

		private global::System.Windows.Forms.CheckBox m_boxSlave3Enable;

		private global::System.Windows.Forms.Label label8;

		private global::System.Windows.Forms.Label label_version;
	}
}
