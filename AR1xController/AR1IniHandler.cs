using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LuaInterface;
using LuaRegister;

namespace AR1xController
{
	public class AR1IniHandler
	{
		public string FilePath
		{
			get
			{
				return this.m_FilePath;
			}
			set
			{
				this.m_FilePath = value;
			}
		}

		public AR1IniHandler(string ini_path)
		{
			this.m_FilePath = ini_path;
			this.m_Header = "";
			this.m_Fields = new List<IniField>();
		}

		public IniField GetField(string name)
		{
			foreach (IniField iniField in this.m_Fields)
			{
				if (iniField.Name == name)
				{
					return iniField;
				}
			}
			return null;
		}

		public LuaTable CreateLuaIniTable()
		{
			if (this.m_Fields.Count == 0)
			{
				GlobalRef.GuiManager.Error("Can't create INI lua table. No ini file was loaded yet.");
			}
			List<KeyValue> list = new List<KeyValue>();
			foreach (IniField iniField in this.m_Fields)
			{
				list.Add(new KeyValue(iniField.Name, iniField.Value));
			}
			return GlobalRef.LuaWrapper.CreateLuaTable(list);
		}

		public bool ReadIniFile()
		{
			StreamReader streamReader = null;
			if (!File.Exists(this.m_FilePath))
			{
				GlobalRef.GuiManager.Error(string.Format("INI read: Could not open ini file '{0}'", this.m_FilePath));
				return false;
			}
			bool result;
			try
			{
				streamReader = new StreamReader(this.m_FilePath);
				string text;
				while ((text = streamReader.ReadLine()) != null && !text.Contains("="))
				{
					this.m_Header = this.m_Header + text + "\n";
				}
				if (text == null)
				{
					result = false;
				}
				else
				{
					do
					{
						text = text.Trim();
						IniField item;
						if (text.StartsWith("#"))
						{
							if (this.m_Fields.Count > 0 && this.m_Fields[this.m_Fields.Count - 1].Comment == "")
							{
								this.m_Fields[this.m_Fields.Count - 1].Comment = text.Remove(0, 1).Trim();
								this.m_Fields[this.m_Fields.Count - 1].Comment = this.iRemoveInvalidChars(this.m_Fields[this.m_Fields.Count - 1].Comment);
							}
						}
						else if (text.Contains("=") && this.iGetFieldFromLine(text, out item))
						{
							this.m_Fields.Add(item);
						}
					}
					while ((text = streamReader.ReadLine()) != null);
					result = true;
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Close();
					streamReader.Dispose();
				}
			}
			return result;
		}

		private bool iGetFieldFromLine(string line, out IniField field)
		{
			field = new IniField();
			int num = line.IndexOf('=');
			int num2 = line.IndexOf('#', num);
			field.Name = line.Substring(0, num - 1).Trim();
			if (num2 != -1)
			{
				field.Value = line.Substring(num + 1, num2 - num - 1).Trim();
				field.Comment = line.Substring(num2 + 1).Trim();
				field.Comment = this.iRemoveInvalidChars(field.Comment);
			}
			else
			{
				field.Value = line.Substring(num + 1).Trim();
			}
			return true;
		}

		private string iRemoveInvalidChars(string str)
		{
			return str.Replace('�', '-');
		}

		private bool iUpdateBoardInfo()
		{
			if (!this.iCheckRequiredFields())
			{
				GlobalRef.GuiManager.Error("INI upadte: Failed to update values. Required fields are missing");
				return false;
			}
			if (GlobalRef.GuiManager.PhyStandAlone)
			{
				this.GetField("PHY_StandAlone").Value = "01";
			}
			else
			{
				this.GetField("PHY_StandAlone").Value = "00";
			}
			switch (GlobalRef.GuiManager.BoardInfo.RDL)
			{
			case 1:
			case 3:
			case 5:
			case 6:
			case 8:
			case 9:
				this.GetField("NumberOfAssembledAnt2_4").Value = "01";
				this.GetField("External_PA_DC2DC").Value = "01";
				break;
			case 2:
			case 4:
			case 7:
				this.GetField("NumberOfAssembledAnt2_4").Value = "02";
				this.GetField("External_PA_DC2DC").Value = "00";
				break;
			default:
				GlobalRef.GuiManager.Error("INI upadte: Failed to update values. Invalid RDL number");
				return false;
			}
			switch (GlobalRef.GuiManager.BoardInfo.Type)
			{
			case BoardType.EVB:
				this.GetField("Board_Type").Value = "00";
				break;
			case BoardType.DVP:
				this.GetField("Board_Type").Value = "01";
				this.GetField("LowBand_component").Value = "01";
				this.GetField("LowBand_component_type").Value = "05";
				this.GetField("HighBand_component").Value = "01";
				this.GetField("HighBand_component_type").Value = "09";
				break;
			case BoardType.HDK:
				this.GetField("Board_Type").Value = "02";
				this.GetField("LowBand_component").Value = "01";
				this.GetField("LowBand_component_type").Value = "06";
				this.GetField("HighBand_component").Value = "01";
				this.GetField("HighBand_component_type").Value = "09";
				break;
			case BoardType.FPGA:
				this.GetField("Board_Type").Value = "03";
				break;
			case BoardType.COM:
				this.GetField("Board_Type").Value = "04";
				break;
			}
			return true;
		}

		private bool iCheckRequiredFields()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			foreach (IniField iniField in this.m_Fields)
			{
				string name = iniField.Name;
				uint num = c00026d.ComputeStringHash(name);
				if (num <= 2482634612U)
				{
					if (num <= 1953201153U)
					{
						if (num != 407426050U)
						{
							if (num == 1953201153U)
							{
								if (name == "NumberOfAssembledAnt2_4")
								{
									flag6 = true;
								}
							}
						}
						else if (name == "LowBand_component")
						{
							flag2 = true;
						}
					}
					else if (num != 2046950746U)
					{
						if (num == 2482634612U)
						{
							if (name == "Board_Type")
							{
								flag8 = true;
							}
						}
					}
					else if (name == "PHY_StandAlone")
					{
						flag = true;
					}
				}
				else if (num <= 3662648094U)
				{
					if (num != 3245933375U)
					{
						if (num == 3662648094U)
						{
							if (name == "HighBand_component")
							{
								flag4 = true;
							}
						}
					}
					else if (name == "LowBand_component_type")
					{
						flag3 = true;
					}
				}
				else if (num != 4005717747U)
				{
					if (num == 4164738859U)
					{
						if (name == "HighBand_component_type")
						{
							flag5 = true;
						}
					}
				}
				else if (name == "External_PA_DC2DC")
				{
					flag7 = true;
				}
			}
			return flag && flag2 && flag3 && flag4 && flag5 && flag6 && flag7 && flag8;
		}

		public bool WriteIniFile()
		{
			StreamWriter streamWriter = null;
			if (!this.iUpdateBoardInfo())
			{
				return false;
			}
			bool result;
			try
			{
				if (this.iCheckFileReadOnly())
				{
					result = false;
				}
				else
				{
					streamWriter = new StreamWriter(this.m_FilePath);
					streamWriter.Write(this.m_Header);
					foreach (IniField iniField in this.m_Fields)
					{
						if (!string.IsNullOrEmpty(iniField.Comment))
						{
							if (iniField.Value.Length > 150)
							{
								streamWriter.WriteLine(string.Format("{0,-27} = {1}\n# {2}", iniField.Name, iniField.Value, iniField.Comment));
							}
							else
							{
								streamWriter.WriteLine(string.Format("{0,-27} = {1} # {2}", iniField.Name, iniField.Value, iniField.Comment));
							}
						}
						else
						{
							streamWriter.WriteLine(string.Format("{0,-27} = {1}", iniField.Name, iniField.Value));
						}
					}
					result = true;
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
					streamWriter.Dispose();
				}
			}
			return result;
		}

		private bool iCheckFileReadOnly()
		{
			if ((File.GetAttributes(this.m_FilePath) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
			{
				return false;
			}
			if (MessageBox.Show(string.Format("INI File \"{0}\" is read-only. Override?", this.m_FilePath), GlobalRef.AppTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				File.SetAttributes(this.m_FilePath, File.GetAttributes(this.m_FilePath) & ~FileAttributes.ReadOnly);
				return false;
			}
			return true;
		}

		private string m_FilePath;

		private string m_Header;

		private List<IniField> m_Fields;
	}
}
