using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AR1xController
{
	public class CalibDataReStore : UserControl
	{
		public CalibDataReStore()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_CalibDataRestoreSaveConfigParams = this.m_GuiManager.TsParams.CalibDataRestoreSaveConfigParams;
			this.m_CalibDataRestoreConfigParams = this.m_GuiManager.TsParams.CalibDataRestoreConfigParams;
			this.m_PhaseShiftAndCalibFilePathParams = this.m_GuiManager.TsParams.PhaseShiftAndCalibFilePathParams;
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			string text = string.Concat(new string[]
			{
				directoryName + "\\PostProc\\CalibData.txt"
			});
			this.m_cboCalibDataCHunkID0FilePath.Text = text;
			string text2 = string.Concat(new string[]
			{
				directoryName + "\\PostProc\\PhaseShiftCalibData.txt"
			});
			this.m_cboPhaseShiftCalibTxFilePath.Text = text2;
		}

		private int iSetCalibDataRestoreAndSaveConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iCalibDataRestoreAndSaveConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetCalibDataRestoreAndSaveConfig()
		{
			this.iSetCalibDataRestoreAndSaveConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetCalibDataRestoreAndSaveConfigAsync()
		{
			new del_v_v(this.iSetCalibDataRestoreAndSaveConfig).BeginInvoke(null, null);
		}

		private void m_btnCalibDataRestoreAndSaveCfg_Click(object sender, EventArgs p1)
		{
			this.iSetCalibDataRestoreAndSaveConfigAsync();
		}

		public bool UpdateCalibDataRestoreAndSaveConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateCalibDataRestoreAndSaveConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_CalibDataRestoreSaveConfigParams.ChunkID = 0;
				this.m_CalibDataRestoreSaveConfigParams.Reserved = 0;
				this.m_PhaseShiftAndCalibFilePathParams.CalibStoreRestorePath = this.m_cboCalibDataCHunkID0FilePath.Text;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateCalibDataRestoreAndSaveConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateCalibDataRestoreAndSaveConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_CalibDataRestoreSaveConfigParams.Reserved = 0;
				this.m_cboCalibDataCHunkID0FilePath.Text = this.m_PhaseShiftAndCalibFilePathParams.CalibStoreRestorePath;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetCalibDataRestoreConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iCalibDataRestoreConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetCalibDataRestoreConfig()
		{
			this.iSetCalibDataRestoreConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetCalibDataRestoreConfigAsync()
		{
			new del_v_v(this.iSetCalibDataRestoreConfig).BeginInvoke(null, null);
		}

		private void m_btnCalibDataRestoreCfg_Click(object sender, EventArgs p1)
		{
			this.iSetCalibDataRestoreConfigAsync();
		}

		public bool UpdateCalibDataRestoreConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateCalibDataRestoreConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.ReadCalibData(this.m_CalibDataRestoreConfigParams.ChunkID);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateCalibDataRestoreConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateCalibDataRestoreConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_cboCalibDataCHunkID0FilePath.Text = this.m_PhaseShiftAndCalibFilePathParams.CalibStoreRestorePath;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public int ReadCalibData(ushort ChunkId)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			Path.GetDirectoryName(Application.StartupPath);
			text2 = this.m_cboCalibDataCHunkID0FilePath.Text;
			this.m_PhaseShiftAndCalibFilePathParams.CalibStoreRestorePath = text2;
			StreamReader streamReader = new StreamReader(text2, true);
			int num = 0;
			while ((text = streamReader.ReadLine()) != null)
			{
				string[] array = text.Split(new char[]
				{
					'x'
				});
				array[0].Trim();
				string value = array[1].Trim();
				GlobalRef.CalibData_chunkID_0[num] = Convert.ToUInt32(value, 16);
				if (num == 170)
				{
					break;
				}
				num++;
			}
			streamReader.Close();
			streamReader.Dispose();
			return 0;
		}

		public int WriteCalibData(ushort ChunkId)
		{
			string empty = string.Empty;
			Path.GetDirectoryName(Application.StartupPath);
			StreamWriter streamWriter = new StreamWriter(this.m_PhaseShiftAndCalibFilePathParams.CalibStoreRestorePath, false);
			for (int i = 0; i < 171; i++)
			{
				string text = GlobalRef.CalibData_chunkID_0[i].ToString("X");
				string text2 = "";
				int num = 8;
				while (num - text.Length != 0)
				{
					text2 += "0";
					num--;
				}
				streamWriter.WriteLine("0x" + text2 + Convert.ToString((long)((ulong)GlobalRef.CalibData_chunkID_0[i]), 16));
			}
			streamWriter.Close();
			streamWriter.Dispose();
			return 0;
		}

		private int iSetPhaseShifterCalibConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iPhaseShifterCalibGetConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPhaseShifterCalibConfig()
		{
			this.iSetPhaseShifterCalibConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetPhaseShifterCalibConfigAsync()
		{
			new del_v_v(this.iSetPhaseShifterCalibConfig).BeginInvoke(null, null);
		}

		private void m_btnPhaseShifterCalibGetCfg_Click(object sender, EventArgs p1)
		{
			this.iSetPhaseShifterCalibConfigAsync();
		}

		private int iSetPhaseShifterCalibRestoreConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iPhaseShifterCalibDataRestoreConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPhaseShifterCalibRestoreConfig()
		{
			this.iSetPhaseShifterCalibRestoreConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetPhaseShifterCalibRestoreConfigAsync()
		{
			new del_v_v(this.iSetPhaseShifterCalibRestoreConfig).BeginInvoke(null, null);
		}

		private void m_btnPhaseShifterCalibSetCfg_Click(object sender, EventArgs p1)
		{
			this.iSetPhaseShifterCalibRestoreConfigAsync();
		}

		public int WritePhaseShifterCalibData(ushort ChunkId)
		{
			string empty = string.Empty;
			Path.GetDirectoryName(Application.StartupPath);
			StreamWriter streamWriter = new StreamWriter(this.m_PhaseShiftAndCalibFilePathParams.PhaseShifterCalibStoreRestorePath, false);
			for (int i = 0; i < 201; i++)
			{
				string text = GlobalRef.PhaseShitCalibData[i].ToString("X");
				string text2 = "";
				int num = 8;
				while (num - text.Length != 0)
				{
					text2 += "0";
					num--;
				}
				streamWriter.WriteLine("0x" + text2 + Convert.ToString((int)GlobalRef.PhaseShitCalibData[i], 16));
			}
			streamWriter.Close();
			streamWriter.Dispose();
			return 0;
		}

		public bool UpdatePhaseShifterCalibDataRestoreConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePhaseShifterCalibDataRestoreConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_CalibDataRestoreConfigParams.ChunkID = 0;
				this.m_CalibDataRestoreConfigParams.NumChunks = 0;
				this.ReadPhaseShifterCalibData(this.m_CalibDataRestoreConfigParams.ChunkID);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public int ReadPhaseShifterCalibData(ushort ChunkId)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			Path.GetDirectoryName(Application.StartupPath);
			text2 = this.m_cboPhaseShiftCalibTxFilePath.Text;
			this.m_PhaseShiftAndCalibFilePathParams.PhaseShifterCalibStoreRestorePath = text2;
			StreamReader streamReader = new StreamReader(text2, true);
			int num = 0;
			while ((text = streamReader.ReadLine()) != null)
			{
				string[] array = text.Split(new char[]
				{
					'x'
				});
				array[0].Trim();
				string value = array[1].Trim();
				GlobalRef.PhaseShitCalibData[num] = Convert.ToUInt16(value, 16);
				if (num == 200)
				{
					break;
				}
				num++;
			}
			streamReader.Close();
			streamReader.Dispose();
			return 0;
		}

		public bool UpdatePhaseShifterCalibDataRestoreConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePhaseShifterCalibDataRestoreConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_cboPhaseShiftCalibTxFilePath.Text = this.m_PhaseShiftAndCalibFilePathParams.PhaseShifterCalibStoreRestorePath;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePhaseShifterCalibDataSaveConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePhaseShifterCalibDataSaveConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_PhaseShiftAndCalibFilePathParams.PhaseShifterCalibStoreRestorePath = this.m_cboPhaseShiftCalibTxFilePath.Text;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void m_btnCalibStoreRestoreData_Click(object sender, EventArgs p1)
		{
			this.m_fdCalibStoreRestoreData.InitialDirectory = "C:";
			this.m_fdCalibStoreRestoreData.RestoreDirectory = true;
			string text = this.iHandleBrowseFiles("bin", this.m_cboCalibDataCHunkID0FilePath.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_cboCalibDataCHunkID0FilePath);
			}
		}

		private string iHandleBrowseFiles(string file_type, string current_path)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (!(file_type == "FW") && !(file_type == "BIN"))
			{
				if (!(file_type == "INI"))
				{
					if (file_type == "DLL")
					{
						openFileDialog.Title = "Browse for DLL file";
						openFileDialog.Filter = "DLL File (*.dll)|*.dll";
					}
				}
				else
				{
					openFileDialog.Title = "Browse for INI file";
					openFileDialog.Filter = "INI File (*.ini)|*.ini";
				}
			}
			else
			{
				openFileDialog.Title = "Browse for bin file";
				openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
			}
			openFileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(current_path) && File.Exists(current_path))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(current_path);
			}
			openFileDialog.ShowDialog();
			return openFileDialog.FileName;
		}

		private void iSetPathInCombo(string path, ComboBox combo)
		{
			if (base.InvokeRequired)
			{
				del_SetPathInCombo method = new del_SetPathInCombo(this.iSetPathInCombo);
				base.Invoke(method, new object[]
				{
					path,
					combo
				});
				return;
			}
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			if (!combo.Items.Contains(path))
			{
				if (combo.Items.Count >= Constants.MaxPaths)
				{
					combo.Items.Remove(combo.Items[combo.Items.Count - 1]);
				}
				combo.Items.Insert(0, path);
			}
			else
			{
				combo.Items.Remove(path);
				combo.Items.Insert(0, path);
			}
			combo.SelectedIndex = combo.FindStringExact(path);
		}

		private void m_btnPhaseShfterCalibStoreRestoreData_Click(object sender, EventArgs p1)
		{
			this.m_fdPhaseShifterCalibStoreRestoreData.InitialDirectory = "C:";
			this.m_fdPhaseShifterCalibStoreRestoreData.RestoreDirectory = true;
			string text = this.iHandleBrowseFiles("bin", this.m_cboPhaseShiftCalibTxFilePath.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_cboPhaseShiftCalibTxFilePath);
			}
		}

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
			this.m_btnCalibDataRestoreAndSaveCfg = new Button();
			this.groupBox2 = new GroupBox();
			this.m_btnCalibStoreRestoreData = new Button();
			this.m_cboCalibDataCHunkID0FilePath = new ComboBox();
			this.m_btnCalibDataRestoreCfg = new Button();
			this.label4 = new Label();
			this.openFileDialog4 = new OpenFileDialog();
			this.m_btnPhaseShifterCalibGetCfg = new Button();
			this.groupBox4 = new GroupBox();
			this.m_btnPhaseShfterCalibStoreRestoreData = new Button();
			this.m_cboPhaseShiftCalibTxFilePath = new ComboBox();
			this.label1 = new Label();
			this.m_btnPhaseShifterCalibSetCfg = new Button();
			this.m_fdCalibStoreRestoreData = new SaveFileDialog();
			this.m_fdPhaseShifterCalibStoreRestoreData = new SaveFileDialog();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.m_btnCalibDataRestoreAndSaveCfg.Location = new Point(428, 64);
			this.m_btnCalibDataRestoreAndSaveCfg.Margin = new Padding(4);
			this.m_btnCalibDataRestoreAndSaveCfg.Name = "m_btnCalibDataRestoreAndSaveCfg";
			this.m_btnCalibDataRestoreAndSaveCfg.Size = new Size(100, 39);
			this.m_btnCalibDataRestoreAndSaveCfg.TabIndex = 2;
			this.m_btnCalibDataRestoreAndSaveCfg.Text = "Save";
			this.m_btnCalibDataRestoreAndSaveCfg.UseVisualStyleBackColor = true;
			this.m_btnCalibDataRestoreAndSaveCfg.Click += this.m_btnCalibDataRestoreAndSaveCfg_Click;
			this.groupBox2.Controls.Add(this.m_btnCalibDataRestoreAndSaveCfg);
			this.groupBox2.Controls.Add(this.m_btnCalibStoreRestoreData);
			this.groupBox2.Controls.Add(this.m_cboCalibDataCHunkID0FilePath);
			this.groupBox2.Controls.Add(this.m_btnCalibDataRestoreCfg);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new Point(19, 23);
			this.groupBox2.Margin = new Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(4);
			this.groupBox2.Size = new Size(784, 133);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Calib Data Save and Restore Configuration";
			this.m_btnCalibStoreRestoreData.Location = new Point(669, 25);
			this.m_btnCalibStoreRestoreData.Margin = new Padding(4);
			this.m_btnCalibStoreRestoreData.Name = "m_btnCalibStoreRestoreData";
			this.m_btnCalibStoreRestoreData.Size = new Size(100, 36);
			this.m_btnCalibStoreRestoreData.TabIndex = 8;
			this.m_btnCalibStoreRestoreData.Text = "Browse";
			this.m_btnCalibStoreRestoreData.UseVisualStyleBackColor = true;
			this.m_btnCalibStoreRestoreData.Click += this.m_btnCalibStoreRestoreData_Click;
			this.m_cboCalibDataCHunkID0FilePath.FormattingEnabled = true;
			this.m_cboCalibDataCHunkID0FilePath.Location = new Point(159, 31);
			this.m_cboCalibDataCHunkID0FilePath.Margin = new Padding(4);
			this.m_cboCalibDataCHunkID0FilePath.Name = "m_cboCalibDataCHunkID0FilePath";
			this.m_cboCalibDataCHunkID0FilePath.Size = new Size(476, 24);
			this.m_cboCalibDataCHunkID0FilePath.TabIndex = 7;
			this.m_cboCalibDataCHunkID0FilePath.Text = "C:\\RadarStudio\\PostProc\\CalibData.txt";
			this.m_btnCalibDataRestoreCfg.Location = new Point(536, 64);
			this.m_btnCalibDataRestoreCfg.Margin = new Padding(4);
			this.m_btnCalibDataRestoreCfg.Name = "m_btnCalibDataRestoreCfg";
			this.m_btnCalibDataRestoreCfg.Size = new Size(100, 39);
			this.m_btnCalibDataRestoreCfg.TabIndex = 6;
			this.m_btnCalibDataRestoreCfg.Text = "Restore";
			this.m_btnCalibDataRestoreCfg.UseVisualStyleBackColor = true;
			this.m_btnCalibDataRestoreCfg.Click += this.m_btnCalibDataRestoreCfg_Click;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(12, 36);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(121, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Cal Data File Path";
			this.m_btnPhaseShifterCalibGetCfg.Location = new Point(427, 65);
			this.m_btnPhaseShifterCalibGetCfg.Margin = new Padding(4);
			this.m_btnPhaseShifterCalibGetCfg.Name = "m_btnPhaseShifterCalibGetCfg";
			this.m_btnPhaseShifterCalibGetCfg.Size = new Size(100, 38);
			this.m_btnPhaseShifterCalibGetCfg.TabIndex = 3;
			this.m_btnPhaseShifterCalibGetCfg.Text = "Save";
			this.m_btnPhaseShifterCalibGetCfg.UseVisualStyleBackColor = true;
			this.m_btnPhaseShifterCalibGetCfg.Click += this.m_btnPhaseShifterCalibGetCfg_Click;
			this.groupBox4.Controls.Add(this.m_btnPhaseShifterCalibGetCfg);
			this.groupBox4.Controls.Add(this.m_btnPhaseShfterCalibStoreRestoreData);
			this.groupBox4.Controls.Add(this.m_cboPhaseShiftCalibTxFilePath);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.m_btnPhaseShifterCalibSetCfg);
			this.groupBox4.Location = new Point(19, 169);
			this.groupBox4.Margin = new Padding(4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new Padding(4);
			this.groupBox4.Size = new Size(784, 137);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Phase Shifter Calib Data Save and Restore Configuration";
			this.m_btnPhaseShfterCalibStoreRestoreData.Location = new Point(668, 26);
			this.m_btnPhaseShfterCalibStoreRestoreData.Margin = new Padding(4);
			this.m_btnPhaseShfterCalibStoreRestoreData.Name = "m_btnPhaseShfterCalibStoreRestoreData";
			this.m_btnPhaseShfterCalibStoreRestoreData.Size = new Size(100, 36);
			this.m_btnPhaseShfterCalibStoreRestoreData.TabIndex = 10;
			this.m_btnPhaseShfterCalibStoreRestoreData.Text = "Browse";
			this.m_btnPhaseShfterCalibStoreRestoreData.UseVisualStyleBackColor = true;
			this.m_btnPhaseShfterCalibStoreRestoreData.Click += this.m_btnPhaseShfterCalibStoreRestoreData_Click;
			this.m_cboPhaseShiftCalibTxFilePath.FormattingEnabled = true;
			this.m_cboPhaseShiftCalibTxFilePath.Location = new Point(167, 32);
			this.m_cboPhaseShiftCalibTxFilePath.Margin = new Padding(4);
			this.m_cboPhaseShiftCalibTxFilePath.Name = "m_cboPhaseShiftCalibTxFilePath";
			this.m_cboPhaseShiftCalibTxFilePath.Size = new Size(467, 24);
			this.m_cboPhaseShiftCalibTxFilePath.TabIndex = 9;
			this.m_cboPhaseShiftCalibTxFilePath.Text = "C:\\RadarStudio\\PostProc\\PhaseShiftCalibData.txt";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(11, 38);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(151, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Ph Shift Calib File Path";
			this.m_btnPhaseShifterCalibSetCfg.Location = new Point(535, 65);
			this.m_btnPhaseShifterCalibSetCfg.Margin = new Padding(4);
			this.m_btnPhaseShifterCalibSetCfg.Name = "m_btnPhaseShifterCalibSetCfg";
			this.m_btnPhaseShifterCalibSetCfg.Size = new Size(100, 38);
			this.m_btnPhaseShifterCalibSetCfg.TabIndex = 4;
			this.m_btnPhaseShifterCalibSetCfg.Text = "Restore";
			this.m_btnPhaseShifterCalibSetCfg.UseVisualStyleBackColor = true;
			this.m_btnPhaseShifterCalibSetCfg.Click += this.m_btnPhaseShifterCalibSetCfg_Click;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox2);
			base.Margin = new Padding(4);
			base.Name = "CalibDataReStore";
			base.Size = new Size(1476, 598);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public CalibDataRestoreSaveConfigParams m_CalibDataRestoreSaveConfigParams;

		public CalibDataRestoreConfigParams m_CalibDataRestoreConfigParams;

		public PhaseShiftAndCalibFilePathParams m_PhaseShiftAndCalibFilePathParams;

		private IContainer components;

		private GroupBox groupBox2;

		private Button m_btnCalibDataRestoreAndSaveCfg;

		private Button m_btnCalibDataRestoreCfg;

		private Label label4;

		private ComboBox m_cboCalibDataCHunkID0FilePath;

		private OpenFileDialog openFileDialog4;

		private GroupBox groupBox4;

		private Button m_btnPhaseShifterCalibGetCfg;

		private ComboBox m_cboPhaseShiftCalibTxFilePath;

		private Label label1;

		private Button m_btnPhaseShifterCalibSetCfg;

		private Button m_btnCalibStoreRestoreData;

		private SaveFileDialog m_fdCalibStoreRestoreData;

		private SaveFileDialog m_fdPhaseShifterCalibStoreRestoreData;

		private Button m_btnPhaseShfterCalibStoreRestoreData;
	}
}
