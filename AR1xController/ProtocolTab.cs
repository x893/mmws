using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AR1xController
{
	public class ProtocolTab : UserControl
	{
		public ProtocolTab()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_ProtocolConfigParams = this.m_GuiManager.TsParams.ProtocolConfigParams;
			this.m_cboMsgDir.SelectedIndex = 0;
			this.m_nudMsgId.Value = 22m;
			this.m_nudSBId.Value = 716m;
			this.m_nudSBLen.Value = 8m;
			this.m_txtSbData.Text = "01000000";
		}

		public static byte[] StringToByteArray(string hex)
		{
			ProtocolTab.c000272 c = new ProtocolTab.c000272();
			c.hex = hex;
			return Enumerable.Range(0, c.hex.Length).Where(new Func<int, bool>(ProtocolTab.c000273.f00019e.m00005c)).Select(new Func<int, byte>(c.m00005b)).ToArray<byte>();
		}

		public static byte[] StringToByteArray2(string hex)
		{
			int length = hex.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}

		private void m_btnInvoke_Click(object sender, EventArgs p1)
		{
			ushort msgDir = 0;
			IntPtr sbData = GCHandle.Alloc(ProtocolTab.StringToByteArray(this.m_txtSbData.Text), GCHandleType.Pinned).AddrOfPinnedObject();
			if (this.m_cboMsgDir.SelectedIndex == 0)
			{
				msgDir = 1;
			}
			else if (this.m_cboMsgDir.SelectedIndex == 1)
			{
				msgDir = 5;
			}
			ushort msgType = 0;
			ushort msgID = (ushort)this.m_nudMsgId.Value;
			ushort p2 = 1;
			ushort sbID = (ushort)this.m_nudSBId.Value;
			ushort sbLen = (ushort)this.m_nudSBLen.Value;
			int length = this.m_txtSbData.Text.Length;
			this.m_GuiManager.ScriptOps.CustomCommand_Impl(msgDir, msgType, msgID, p2, sbID, sbLen, sbData);
		}

		public bool UpdateCustomCommandConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateCustomCommandConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				if (this.m_ProtocolConfigParams.MsgDir == 1)
				{
					this.m_cboMsgDir.SelectedIndex = 0;
				}
				else if (this.m_ProtocolConfigParams.MsgDir == 5)
				{
					this.m_cboMsgDir.SelectedIndex = 1;
				}
				this.m_ProtocolConfigParams.MsgType = 0;
				this.m_nudMsgId.Value = this.m_ProtocolConfigParams.MsgId;
				this.m_ProtocolConfigParams.f0004ec = 1;
				this.m_nudSBId.Value = this.m_ProtocolConfigParams.SuBlockID;
				this.m_nudSBLen.Value = this.m_ProtocolConfigParams.SuBlockLen;
				this.m_txtSbData.Text = this.m_ProtocolConfigParams.SuBlockData;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private bool iConvertHexTextToUInt(TextBox p0, out uint uint_val)
		{
			uint_val = 0U;
			if (string.IsNullOrEmpty(p0.Text))
			{
				return false;
			}
			string text = p0.Text.ToLower();
			if (text.Length > 1 && text.StartsWith("0x"))
			{
				text = text.Remove(0, 2);
			}
			return uint.TryParse(text, NumberStyles.HexNumber, null, out uint_val);
		}

		private void m_txtSbData_TextChanged(object sender, EventArgs p1)
		{
			if (!this.IsHexadecimal(this.m_txtSbData.Text) && !string.IsNullOrWhiteSpace(this.m_txtSbData.Text))
			{
				this.m_txtSbData.Clear();
				MessageBox.Show("Invalid Content");
			}
		}

		private void m_txtSbData_KeyDown(object sender, KeyEventArgs p1)
		{
			if (!this.IsHexadecimal(p1.KeyValue.ToString()) && p1.KeyCode != Keys.Back)
			{
				p1.Handled = true;
				p1.SuppressKeyPress = true;
			}
		}

		public bool IsHexadecimal(string strInput)
		{
			Regex regex = new Regex("^[a-fA-F0-9]+$");
			return !string.IsNullOrEmpty(strInput) && regex.IsMatch(strInput);
		}

		public bool iDisableProtoTabBtns()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.iDisableProtoTabBtns);
				return (bool)base.Invoke(method);
			}
			this.m_btnInvoke.Enabled = false;
			return true;
		}

		public bool iEnableProtoTabBtns()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.iEnableProtoTabBtns);
				return (bool)base.Invoke(method);
			}
			this.m_btnInvoke.Enabled = true;
			return true;
		}

		public string iGetSbDataText()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(this.iGetSbDataText);
				return (string)base.Invoke(method);
			}
			return this.m_txtSbData.Text;
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
			this.m_txtSbData = new TextBox();
			this.m_lblProtSBData = new Label();
			this.m_nudSBLen = new NumericUpDown();
			this.m_lblProtSBLen = new Label();
			this.m_nudSBId = new NumericUpDown();
			this.m_lblProtSBId = new Label();
			this.m_grpProtCustom = new GroupBox();
			this.m_cboMsgDir = new ComboBox();
			this.m_nudMsgId = new NumericUpDown();
			this.m_lblProtMsgId = new Label();
			this.m_lblProtMsgDir = new Label();
			this.m_btnInvoke = new Button();
			((ISupportInitialize)this.m_nudSBLen).BeginInit();
			((ISupportInitialize)this.m_nudSBId).BeginInit();
			this.m_grpProtCustom.SuspendLayout();
			((ISupportInitialize)this.m_nudMsgId).BeginInit();
			base.SuspendLayout();
			this.m_txtSbData.Location = new Point(132, 186);
			this.m_txtSbData.Margin = new Padding(2);
			this.m_txtSbData.Name = "m_txtSbData";
			this.m_txtSbData.Size = new Size(172, 21);
			this.m_txtSbData.TabIndex = 5;
			this.m_txtSbData.TextChanged += this.m_txtSbData_TextChanged;
			this.m_txtSbData.KeyDown += this.m_txtSbData_KeyDown;
			this.m_lblProtSBData.AutoSize = true;
			this.m_lblProtSBData.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblProtSBData.Location = new Point(9, 191);
			this.m_lblProtSBData.Margin = new Padding(2, 0, 2, 0);
			this.m_lblProtSBData.Name = "m_lblProtSBData";
			this.m_lblProtSBData.Size = new Size(88, 15);
			this.m_lblProtSBData.TabIndex = 25;
			this.m_lblProtSBData.Text = "SubBlock Data";
			this.m_nudSBLen.Hexadecimal = true;
			this.m_nudSBLen.Location = new Point(132, 150);
			this.m_nudSBLen.Margin = new Padding(2);
			NumericUpDown nudSBLen = this.m_nudSBLen;
			int[] array = new int[4];
			array[0] = 65535;
			nudSBLen.Maximum = new decimal(array);
			this.m_nudSBLen.Name = "m_nudSBLen";
			this.m_nudSBLen.Size = new Size(64, 21);
			this.m_nudSBLen.TabIndex = 4;
			this.m_lblProtSBLen.AutoSize = true;
			this.m_lblProtSBLen.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblProtSBLen.Location = new Point(9, 155);
			this.m_lblProtSBLen.Margin = new Padding(2, 0, 2, 0);
			this.m_lblProtSBLen.Name = "m_lblProtSBLen";
			this.m_lblProtSBLen.Size = new Size(115, 15);
			this.m_lblProtSBLen.TabIndex = 23;
			this.m_lblProtSBLen.Text = "SubBlock Len (Hex)";
			this.m_nudSBId.Hexadecimal = true;
			this.m_nudSBId.Location = new Point(132, 114);
			this.m_nudSBId.Margin = new Padding(2);
			NumericUpDown nudSBId = this.m_nudSBId;
			int[] array2 = new int[4];
			array2[0] = 65535;
			nudSBId.Maximum = new decimal(array2);
			this.m_nudSBId.Name = "m_nudSBId";
			this.m_nudSBId.Size = new Size(64, 21);
			this.m_nudSBId.TabIndex = 3;
			this.m_lblProtSBId.AutoSize = true;
			this.m_lblProtSBId.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblProtSBId.Location = new Point(9, 119);
			this.m_lblProtSBId.Margin = new Padding(2, 0, 2, 0);
			this.m_lblProtSBId.Name = "m_lblProtSBId";
			this.m_lblProtSBId.Size = new Size(106, 15);
			this.m_lblProtSBId.TabIndex = 21;
			this.m_lblProtSBId.Text = "SubBlock ID (Hex)";
			this.m_grpProtCustom.Controls.Add(this.m_txtSbData);
			this.m_grpProtCustom.Controls.Add(this.m_cboMsgDir);
			this.m_grpProtCustom.Controls.Add(this.m_lblProtSBData);
			this.m_grpProtCustom.Controls.Add(this.m_nudMsgId);
			this.m_grpProtCustom.Controls.Add(this.m_nudSBLen);
			this.m_grpProtCustom.Controls.Add(this.m_lblProtMsgId);
			this.m_grpProtCustom.Controls.Add(this.m_lblProtSBLen);
			this.m_grpProtCustom.Controls.Add(this.m_lblProtMsgDir);
			this.m_grpProtCustom.Controls.Add(this.m_nudSBId);
			this.m_grpProtCustom.Controls.Add(this.m_lblProtSBId);
			this.m_grpProtCustom.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_grpProtCustom.Location = new Point(156, 28);
			this.m_grpProtCustom.Margin = new Padding(2);
			this.m_grpProtCustom.Name = "m_grpProtCustom";
			this.m_grpProtCustom.Padding = new Padding(2);
			this.m_grpProtCustom.Size = new Size(357, 241);
			this.m_grpProtCustom.TabIndex = 28;
			this.m_grpProtCustom.TabStop = false;
			this.m_grpProtCustom.Text = "Custom Command";
			this.m_cboMsgDir.FormattingEnabled = true;
			this.m_cboMsgDir.Items.AddRange(new object[]
			{
				"Host To BSS",
				"Host To MSS"
			});
			this.m_cboMsgDir.Location = new Point(132, 42);
			this.m_cboMsgDir.Name = "m_cboMsgDir";
			this.m_cboMsgDir.Size = new Size(121, 23);
			this.m_cboMsgDir.TabIndex = 1;
			this.m_nudMsgId.Hexadecimal = true;
			this.m_nudMsgId.Location = new Point(132, 78);
			this.m_nudMsgId.Margin = new Padding(2);
			NumericUpDown nudMsgId = this.m_nudMsgId;
			int[] array3 = new int[4];
			array3[0] = 65535;
			nudMsgId.Maximum = new decimal(array3);
			this.m_nudMsgId.Name = "m_nudMsgId";
			this.m_nudMsgId.Size = new Size(64, 21);
			this.m_nudMsgId.TabIndex = 2;
			this.m_lblProtMsgId.AutoSize = true;
			this.m_lblProtMsgId.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblProtMsgId.Location = new Point(9, 83);
			this.m_lblProtMsgId.Margin = new Padding(2, 0, 2, 0);
			this.m_lblProtMsgId.Name = "m_lblProtMsgId";
			this.m_lblProtMsgId.Size = new Size(77, 15);
			this.m_lblProtMsgId.TabIndex = 5;
			this.m_lblProtMsgId.Text = "Msg ID (Hex)";
			this.m_lblProtMsgDir.AutoSize = true;
			this.m_lblProtMsgDir.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblProtMsgDir.Location = new Point(9, 47);
			this.m_lblProtMsgDir.Margin = new Padding(2, 0, 2, 0);
			this.m_lblProtMsgDir.Name = "m_lblProtMsgDir";
			this.m_lblProtMsgDir.Size = new Size(49, 15);
			this.m_lblProtMsgDir.TabIndex = 1;
			this.m_lblProtMsgDir.Text = "Msg Dir";
			this.m_btnInvoke.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_btnInvoke.Location = new Point(288, 295);
			this.m_btnInvoke.Margin = new Padding(2);
			this.m_btnInvoke.Name = "m_btnInvoke";
			this.m_btnInvoke.Size = new Size(83, 27);
			this.m_btnInvoke.TabIndex = 6;
			this.m_btnInvoke.Text = "Invoke";
			this.m_btnInvoke.UseVisualStyleBackColor = true;
			this.m_btnInvoke.Click += this.m_btnInvoke_Click;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			base.Controls.Add(this.m_grpProtCustom);
			base.Controls.Add(this.m_btnInvoke);
			base.Name = "ProtocolTab";
			base.Size = new Size(802, 505);
			((ISupportInitialize)this.m_nudSBLen).EndInit();
			((ISupportInitialize)this.m_nudSBId).EndInit();
			this.m_grpProtCustom.ResumeLayout(false);
			this.m_grpProtCustom.PerformLayout();
			((ISupportInitialize)this.m_nudMsgId).EndInit();
			base.ResumeLayout(false);
		}

		public GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		public ProtocolConfigParams m_ProtocolConfigParams;

		private frmAR1Main m_MainForm;

		private IContainer components;

		private TextBox m_txtSbData;

		private Label m_lblProtSBData;

		private NumericUpDown m_nudSBLen;

		private Label m_lblProtSBLen;

		private NumericUpDown m_nudSBId;

		private Label m_lblProtSBId;

		private GroupBox m_grpProtCustom;

		private NumericUpDown m_nudMsgId;

		private Label m_lblProtMsgId;

		private Label m_lblProtMsgDir;

		private Button m_btnInvoke;

		private ComboBox m_cboMsgDir;

		[CompilerGenerated]
		private sealed class c000272
		{
			internal byte m00005b(int p0)
			{
				return Convert.ToByte(this.hex.Substring(p0, 2), 16);
			}

			public string hex;
		}

		[CompilerGenerated]
		[Serializable]
		private sealed class c000273
		{
			internal bool m00005c(int p0)
			{
				return p0 % 2 == 0;
			}

			public static readonly ProtocolTab.c000273 f00019e = new ProtocolTab.c000273();

			public static Func<int, bool> f000205;
		}
	}
}
