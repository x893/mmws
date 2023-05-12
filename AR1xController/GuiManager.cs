using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LuaInterface;
using LuaRegister;

namespace AR1xController
{
	public class GuiManager
	{
		public Dictionary<GuiOp, Delegate> GuiStartDict
		{
			get
			{
				return this.m_GuiStartDict;
			}
			set
			{
				this.m_GuiStartDict = value;
			}
		}

		public Dictionary<GuiOp, Delegate> GuiEndDict
		{
			get
			{
				return this.m_GuiEndDict;
			}
			set
			{
				this.m_GuiEndDict = value;
			}
		}

		public Dictionary<TsApiOp, Delegate> ApiDict
		{
			get
			{
				return this.m_ApiDict;
			}
			set
			{
				this.m_ApiDict = value;
			}
		}

		public frmAR1Main MainTsForm
		{
			get
			{
				return this.m_MainTsForm;
			}
			set
			{
				this.m_MainTsForm = value;
			}
		}

		public AR1xxxgui p000002
		{
			get
			{
				return this.m_ar1gui;
			}
			set
			{
				this.m_ar1gui = value;
			}
		}

		public bool GuiOpPending
		{
			get
			{
				return this.m_GuiOpPending;
			}
			set
			{
				this.m_GuiOpPending = value;
			}
		}

		public bool TsApiMode
		{
			get
			{
				return this.m_TsApiMode;
			}
			set
			{
				this.m_TsApiMode = value;
			}
		}

		public bool PhyStandAlone
		{
			get
			{
				return this.m_PhyStandAlone;
			}
			set
			{
				this.m_PhyStandAlone = value;
			}
		}

		public bool IsElpOn
		{
			get
			{
				return this.m_IsElpOn;
			}
			set
			{
				this.m_IsElpOn = value;
			}
		}

		public bool IsPowerDownOn
		{
			get
			{
				return this.m_IsPowerDownOn;
			}
			set
			{
				this.m_IsPowerDownOn = value;
			}
		}

		public bool LogLuaKeyChanges
		{
			get
			{
				return this.m_LogLuaKeyChanges;
			}
			set
			{
				this.m_LogLuaKeyChanges = value;
			}
		}

		public string p000003
		{
			get
			{
				return this.m_TsDllVersion;
			}
			set
			{
				this.m_TsDllVersion = value;
			}
		}

		public BoardInfo BoardInfo
		{
			get
			{
				return this.m_BoardInfo;
			}
			set
			{
				this.m_BoardInfo = value;
			}
		}

		public int NumAssembledAnt2_4
		{
			get
			{
				return this.m_NumAssembledAnt2_4;
			}
			set
			{
				this.m_NumAssembledAnt2_4 = value;
			}
		}

		public int NumAssembledAnt5
		{
			get
			{
				return this.m_NumAssembledAnt5;
			}
			set
			{
				this.m_NumAssembledAnt5 = value;
			}
		}

		public TsParams TsParams
		{
			get
			{
				return this.m_TsParams;
			}
			set
			{
				this.m_TsParams = value;
			}
		}

		public DllOps DllOps
		{
			get
			{
				return this.m_DllOps;
			}
			set
			{
				this.m_DllOps = value;
			}
		}

		public ScriptOps ScriptOps
		{
			get
			{
				return this.m_ScriptOps;
			}
			set
			{
				this.m_ScriptOps = value;
			}
		}

		public AR1xxxExtOpps AR1xxxExtOpps
		{
			get
			{
				return this.m_AR1xxxExtOpps;
			}
			set
			{
				this.m_AR1xxxExtOpps = value;
			}
		}

		public bool PG2
		{
			get
			{
				return this.m_PG2;
			}
			set
			{
				this.m_PG2 = value;
			}
		}

		public bool OvUvCheckEnabled
		{
			get
			{
				return this.m_EnableOvUvCheck;
			}
			set
			{
				this.m_EnableOvUvCheck = value;
			}
		}

		public bool EnableLDOCheck
		{
			get
			{
				return this.m_EnableLDOCheck;
			}
			set
			{
				this.m_EnableLDOCheck = value;
			}
		}

		public GuiManager()
		{
			this.m_GuiStartDict = new Dictionary<GuiOp, Delegate>();
			this.m_GuiEndDict = new Dictionary<GuiOp, Delegate>();
			this.m_ApiDict = new Dictionary<TsApiOp, Delegate>();
			this.m_RecordApiDict = new Dictionary<RecordApiOp, string>();
			this.iFillRecordApiDictionary();
			this.m_ar1gui = new AR1xxxgui(this);
			this.m_GuiOpPending = false;
			this.m_TsApiMode = false;
			this.m_IsElpOn = false;
			this.m_IsPowerDownOn = false;
			this.m_BoardInfo = new BoardInfo();
			this.m_TsParams = new TsParams();
			this.m_DllOps = new DllOps();
			this.m_ScriptOps = new ScriptOps();
			this.m_AR1xxxExtOpps = new AR1xxxExtOpps();
			GlobalRef.AR1xxxExtOpps = this.m_AR1xxxExtOpps;
		}

		private void iFillRecordApiDictionary()
		{
			this.m_RecordApiDict.Add(RecordApiOp.None, "None");
			this.m_RecordApiDict.Add(RecordApiOp.Connect, "Connect");
			this.m_RecordApiDict.Add(RecordApiOp.Disconnect, "Disconnect");
			this.m_RecordApiDict.Add(RecordApiOp.ReadIni, "ReadIniFile");
			this.m_RecordApiDict.Add(RecordApiOp.UpdateIni, "UpdateIni");
			this.m_RecordApiDict.Add(RecordApiOp.DownloadFw, "DownloadFw");
			this.m_RecordApiDict.Add(RecordApiOp.ChannelTune, "ChannelTune");
			this.m_RecordApiDict.Add(RecordApiOp.PowerMode, "PowerMode");
			this.m_RecordApiDict.Add(RecordApiOp.SetAntennaMode, "SetAntennaMode");
			this.m_RecordApiDict.Add(RecordApiOp.StartTx, "StartTx");
			this.m_RecordApiDict.Add(RecordApiOp.StopTx, "StopTx");
			this.m_RecordApiDict.Add(RecordApiOp.StartRx, "StartRx");
			this.m_RecordApiDict.Add(RecordApiOp.StopRx, "StopRx");
			this.m_RecordApiDict.Add(RecordApiOp.GetRxStats, "GetRxStats");
			this.m_RecordApiDict.Add(RecordApiOp.f0002b5, "RstRxStats");
			this.m_RecordApiDict.Add(RecordApiOp.SetOutputPower, "SetOutputPower");
			this.m_RecordApiDict.Add(RecordApiOp.ConnectAnalogPorts, "ConnectAnalogPorts");
		}

		public void BindGuiStart(GuiOp op_id, Delegate del)
		{
			this.m_GuiStartDict.Add(op_id, del);
		}

		public void BindGuiEnd(GuiOp op_id, Delegate del)
		{
			this.m_GuiEndDict.Add(op_id, del);
		}

		public void BindApi(TsApiOp op_id, Delegate del)
		{
			this.m_ApiDict.Add(op_id, del);
		}

		public void GuiStart(int op_id)
		{
			Delegate @delegate;
			if (this.m_GuiStartDict.TryGetValue((GuiOp)op_id, out @delegate) && @delegate != null)
			{
				@delegate.DynamicInvoke(new object[0]);
			}
		}

		public void GuiEnd(int op_id, object[] res)
		{
			Delegate @delegate;
			if (this.m_GuiEndDict.TryGetValue((GuiOp)op_id, out @delegate) && @delegate != null)
			{
				@delegate.DynamicInvoke(new object[]
				{
					res
				});
			}
		}

		public Delegate GetGuiEndFunc(GuiOp op_id)
		{
			Delegate result = null;
			this.m_GuiEndDict.TryGetValue(op_id, out result);
			return result;
		}

		public Delegate GetApiFunc(TsApiOp op_id)
		{
			Delegate result = null;
			this.m_ApiDict.TryGetValue(op_id, out result);
			return result;
		}

		public object[] DoLuaString(int op_id, string lua_str)
		{
			return this.DoLuaString(op_id, lua_str, true);
		}

		public object[] DoLuaString(int op_id, string lua_str, bool log)
		{
			object[] result = null;
			try
			{
				if (log)
				{
					this.RecordLog(op_id, lua_str);
				}
				result = GlobalRef.LuaWrapper.DoString(lua_str);
			}
			catch (Exception ex)
			{
				string str = string.Format("Lua command \"{0}\" failed with error:\n{1}", lua_str, ex.Message);
				GlobalRef.LuaWrapper.PrintError("[AR1xxx FW]: " + str);
			}
			return result;
		}

		public void Log(string msg)
		{
			string msg2 = string.Format("[RadarAPI]: {0}", msg);
			GlobalRef.LuaWrapper.Print(msg2);
		}

		public void RecordLog(int op_id, string full_command, bool print_to_log)
		{
			full_command = full_command.Replace("\\", "\\\\").Replace("return ", "");
			if (print_to_log)
			{
				string msg = string.Format("[RadarAPI]: {0}", full_command);
				GlobalRef.LuaWrapper.Print(msg);
			}
			if (GlobalRef.LuaWrapper.IsMacroOn)
			{
				string text = "";
				if (full_command.StartsWith("ar1.") && full_command.Contains("(") && !full_command.Contains("Calling"))
				{
					text = full_command.Remove(0, 5);
					text = text.Substring(0, text.IndexOf("("));
				}
				GlobalRef.DllController.Record(text, full_command);
			}
		}

		public void RecordLog(int op_id, string full_command)
		{
			this.RecordLog(op_id, full_command, true);
		}

		public void Warning(string msg)
		{
			string msg2 = string.Format("[RadarAPI]: Warning: {0}", msg);
			GlobalRef.LuaWrapper.PrintWarning(msg2);
		}

		public void LuaError(string msg)
		{
			if (GlobalRef.GuiManager.IsExternalThread())
			{
				GlobalRef.LuaWrapper.LuaError(msg);
				return;
			}
			this.Error(msg);
		}

		public void GuiError(string msg)
		{
			this.Error(msg, null, true, false);
		}

		public void GuiError(string msg, string stack_trace)
		{
			this.Error(msg, stack_trace, true, true);
		}

		public void Error(string msg)
		{
			this.Error(msg, null, false, false);
		}

		public void ErrorAbort(string msg)
		{
			this.Error(msg, null, false, true);
		}

		public void Error(string msg, string stack_trace)
		{
			this.Error(msg, stack_trace, false, true);
		}

		public void Error(string msg, string stack_trace, bool msg_box, bool script_abort)
		{
			bool flag = GlobalRef.LuaWrapper.IsAutomationOnFunc();
			string text;
			if (string.IsNullOrEmpty(stack_trace))
			{
				text = "[RadarAPI]: Error: " + msg;
			}
			else
			{
				text = string.Format("[RadarAPI]: Error: {0}\nTrace:\n{1}", msg, stack_trace);
			}
			if (!flag && (msg_box || (Thread.CurrentThread.Name == "GUI" && GlobalRef.TsWrapper.IsGuiShown())))
			{
				MessageBox.Show(text, GlobalRef.AppTitle);
			}
			else if (script_abort && Thread.CurrentThread.Name == "ScriptThread")
			{
				this.LuaError(text);
			}
			GlobalRef.LuaWrapper.PrintError(text);
		}

		public void ErrorApiFailure(TsApiOp api_op, int error_code)
		{
			this.Error(string.Format("{0} failed with error code {1}", this.m_ar1gui.ApiNameDict[api_op], error_code));
		}

		public int GetValueFromCombo(ComboBox combo)
		{
			if (combo.InvokeRequired)
			{
				del_i_cbo method = new del_i_cbo(this.GetValueFromCombo);
				return (int)combo.Invoke(method, new object[]
				{
					combo
				});
			}
			return ((NameValueList)combo.Tag).GetValue(combo.SelectedItem.ToString());
		}

		public bool SetValueInCombo(ComboBox combo, int value)
		{
			if (combo.InvokeRequired)
			{
				del_b_cbo_i method = new del_b_cbo_i(this.SetValueInCombo);
				return (bool)combo.Invoke(method, new object[]
				{
					combo
				});
			}
			bool result;
			try
			{
				string name = ((NameValueList)combo.Tag).GetName(value);
				if (name == null || combo.FindStringExact(name) == -1)
				{
					this.Error(string.Format("Value '{0}' does not match any item in combo box '{1}'", value, combo.Name));
					result = false;
				}
				else
				{
					combo.SelectedItem = name;
					result = true;
				}
			}
			catch (Exception ex)
			{
				this.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public string GetValueFromTextbox(TextBox text_box)
		{
			if (text_box.InvokeRequired)
			{
				del_s_txt method = new del_s_txt(this.GetValueFromTextbox);
				return (string)text_box.Invoke(method, new object[]
				{
					text_box
				});
			}
			return text_box.Text;
		}

		public bool IsExternalThread()
		{
			return Thread.CurrentThread.Name == "ScriptThread" || Thread.CurrentThread.Name == "DoStringThread";
		}

		public static string FileExtentionInfo(AssocStr assocStr, string doctype)
		{
			uint capacity = 0U;
			NativeImports.AssocQueryString(AssocF.Verify, assocStr, doctype, null, null, ref capacity);
			StringBuilder stringBuilder = new StringBuilder((int)capacity);
			NativeImports.AssocQueryString(AssocF.Verify, assocStr, doctype, null, stringBuilder, ref capacity);
			return stringBuilder.ToString();
		}

		public LuaTable GetBoardInfoAsLuaTable()
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			List<KeyValue> list = new List<KeyValue>();
			list.Add(new KeyValue("RDL", this.m_BoardInfo.RDL));
			switch (this.m_BoardInfo.Type)
			{
			case BoardType.EVB:
				value = "EVB";
				break;
			case BoardType.DVP:
				value = "DVP";
				break;
			case BoardType.HDK:
				value = "HDK";
				break;
			case BoardType.FPGA:
				value = "FPGA";
				break;
			case BoardType.COM:
				value = "COM";
				break;
			}
			list.Add(new KeyValue("Type", value));
			switch (this.m_BoardInfo.Flavor)
			{
			case BoardFlavor.Unkown:
				value2 = "Unknown";
				break;
			case BoardFlavor.f0002c0:
				value2 = "185x";
				break;
			case BoardFlavor.f0002c1:
				value2 = "189x";
				break;
			}
			list.Add(new KeyValue("Flavor", value2));
			switch (this.m_BoardInfo.Antenna)
			{
			case AntennaType.Unknown:
				value3 = "Unknown";
				break;
			case AntennaType.SISO:
				value3 = "SISO";
				break;
			case AntennaType.MIMO:
				value3 = "MIMO";
				break;
			}
			list.Add(new KeyValue("Antenna", value3));
			switch (this.m_BoardInfo.Process)
			{
			case ProcessType.Unkown:
				value4 = "Unkown";
				break;
			case ProcessType.Nominal:
				value4 = "Nominal";
				break;
			case ProcessType.Weak:
				value4 = "Weak";
				break;
			case ProcessType.Strong:
				value4 = "Strong";
				break;
			}
			list.Add(new KeyValue("Process", value4));
			list.Add(new KeyValue("PG", this.m_BoardInfo.PG));
			return GlobalRef.LuaWrapper.CreateLuaTable(list);
		}

		private Dictionary<GuiOp, Delegate> m_GuiStartDict;

		private Dictionary<GuiOp, Delegate> m_GuiEndDict;

		private Dictionary<TsApiOp, Delegate> m_ApiDict;

		private Dictionary<RecordApiOp, string> m_RecordApiDict;

		private frmAR1Main m_MainTsForm;

		private AR1xxxgui m_ar1gui;

		private bool m_GuiOpPending;

		private bool m_TsApiMode;

		private bool m_PhyStandAlone;

		private bool m_IsElpOn;

		private bool m_IsPowerDownOn;

		private bool m_LogLuaKeyChanges;

		private string m_TsDllVersion;

		private BoardInfo m_BoardInfo;

		private int m_NumAssembledAnt2_4 = 1;

		private int m_NumAssembledAnt5 = 1;

		private TsParams m_TsParams;

		private DllOps m_DllOps;

		private ScriptOps m_ScriptOps;

		private AR1xxxExtOpps m_AR1xxxExtOpps;

		private bool m_PG2;

		private bool m_EnableOvUvCheck = true;

		private bool m_EnableLDOCheck = true;
	}
}
