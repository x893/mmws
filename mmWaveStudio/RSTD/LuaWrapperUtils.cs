using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LuaInterface;
using LuaRegister;

namespace RSTD
{

	public class LuaWrapperUtils
	{

		static LuaWrapperUtils()
		{
			LuaWrapperUtils.RegisterLuaFunctionsToDotNet();
			LuaWrapperUtils.AddLuaShellHistoryCommandsToDictionary();
		}




		public static LuaWrapper LuaWrapper
		{
			get
			{
				return LuaWrapperUtils.m_LuaWrapper;
			}
			set
			{
				LuaWrapperUtils.m_LuaWrapper = value;
			}
		}




		public static Dictionary<string, string> LuaShellCommands
		{
			get
			{
				return LuaWrapperUtils.m_LuaShellCommands;
			}
			set
			{
				LuaWrapperUtils.m_LuaShellCommands = value;
			}
		}


		public static bool CheckIfLuaPackage(string AmILuaPackage)
		{
			bool result = false;
			if (string.IsNullOrEmpty(AmILuaPackage))
			{
				return false;
			}
			if (!AmILuaPackage.Contains(" "))
			{
				result = (bool)LuaWrapperUtils.m_LuaWrapper.LuaVM.DoString("if type(" + AmILuaPackage + " ) == \"table\" then return true else return false end")[0];
			}
			return result;
		}


		public static string CheckPrintValue(string AmILuaCommandWhichReturnValue)
		{
			return LuaWrapperUtils.m_LuaWrapper.LuaVM.DoString("return " + AmILuaCommandWhichReturnValue)[0].ToString();
		}


		public static List<string> CheckIfLuaReturnValue(string lua_command, ref Thread lua_command_thread, out bool aborted)
		{
			List<string> list = new List<string>();
			aborted = false;
			if (!lua_command.EndsWith(";"))
			{
				if (LuaWrapperUtils.bisVarEqualValue(lua_command))
				{
					list.Add("var_equals_value@");
					return list;
				}
				object[] array = LuaWrapperUtils.DoLuaString("return " + lua_command, out lua_command_thread, out aborted);
				if (array != null && array[0] != null)
				{
					foreach (object obj in array)
					{
						list.Add(obj.ToString());
					}
					return list;
				}
			}
			else
			{
				LuaWrapperUtils.DoLuaString(lua_command, out lua_command_thread, out aborted);
			}
			return null;
		}


		private static bool bisVarEqualValue(string command)
		{
			if (!command.Contains("="))
			{
				return false;
			}
			int num = command.IndexOf('=');
			if (num == 0)
			{
				return false;
			}
			if (num + 1 < command.Length && command[num + 1] == '=')
			{
				return false;
			}
			string[] array = command.Split(new char[]
			{
				'='
			})[0].Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (!LuaWrapperUtils.iIsValidVar(array[i].Trim()))
				{
					return false;
				}
			}
			return true;
		}


		private static bool iIsValidVar(string var_cand)
		{
			var_cand = var_cand.Trim();
			if (string.IsNullOrEmpty(var_cand))
			{
				return false;
			}
			if (!char.IsLetter(var_cand[0]) && var_cand[0] != '_')
			{
				return false;
			}
			for (int i = 1; i < var_cand.Length; i++)
			{
				if (!char.IsLetterOrDigit(var_cand[i]) && var_cand[i] != '_' && var_cand[i] != '.')
				{
					return false;
				}
			}
			return true;
		}


		public static bool IfExistInTable(string TableName, string IfBelongToTableName)
		{
			return LuaWrapperUtils.GetTableContent(TableName).Contains(IfBelongToTableName);
		}


		public static string GetTableContent(string TableName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("");
			LuaWrapperUtils.m_LuaWrapper.LuaVM.DoString("TableDefinedInDotNet = " + TableName);
			foreach (string value in LuaWrapperUtils.m_LuaWrapper.LuaVM.GetFunction("MakeTableString").Call(new object[0])[0].ToString().Trim().Split(new char[]
			{
				' '
			}))
			{
				stringBuilder.Append(value);
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString();
		}


		public static List<string> GetTableKeys(string table_name)
		{
			List<string> list = new List<string>();
			object[] array = LuaWrapperUtils.m_LuaWrapper.LuaVM.DoString("return " + table_name);
			if (array.Length != 0 && array[0] is LuaTable)
			{
				foreach (object obj in (array[0] as LuaTable))
				{
					list.Add(((DictionaryEntry)obj).Key.ToString());
				}
			}
			return list;
		}


		public static List<string> GetTableValues(LuaTable tableName)
		{
			List<string> list = new List<string>();
			foreach (object obj in tableName)
			{
				list.Add(((DictionaryEntry)obj).Value.ToString());
			}
			return list;
		}


		public static void RegisterLuaFunctionsToDotNet()
		{
			LuaWrapperUtils.m_LuaWrapper.DoFile(Application.StartupPath + "\\LuaScripts\\LuaFunctionsToDotNet.lua");
			LuaWrapperUtils.m_LuaWrapper.DoString("function dofile_ex(...) RSTD.ParseFile(...) return original_dofile(...) end;function loadfile_ex(...) RSTD.ParseFile(...) return original_loadfile(...) end;original_dofile = dofile; original_loadfile = loadfile; dofile = dofile_ex; loadfile = loadfile_ex");
		}


		public static StringBuilder GetTableContentByType(string TableName, string type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("");
			LuaWrapperUtils.m_LuaWrapper.LuaVM.DoString("TableDefinedInDotNet = " + TableName);
			foreach (string text in LuaWrapperUtils.m_LuaWrapper.LuaVM.GetFunction("MakeTableTypeMembersString").Call(new object[]
			{
				type
			})[0].ToString().Trim().Split(new char[]
			{
				' '
			}))
			{
				if (text != "TableDefinedInDotNet")
				{
					stringBuilder.Append(text);
				}
			}
			return stringBuilder;
		}


		public static bool CheckIfPackagesEqual(string package1, string package2)
		{
			string chunk = string.Format("if ({0} == {1}) then return true else return false end", package1, package2);
			return (bool)LuaWrapperUtils.m_LuaWrapper.LuaVM.DoString(chunk)[0];
		}


		private static void AddLuaShellHistoryCommandsToDictionary()
		{
			LuaWrapperUtils.m_LuaShellCommands.Add("RSTD Commands", "Usage RSTD.<desired_operation>.");
			LuaWrapperUtils.m_LuaShellCommands.Add("cls", "Clears the screen.");
			LuaWrapperUtils.m_LuaShellCommands.Add("help", "Shows all available commands in Lua Shell.");
			LuaWrapperUtils.m_LuaShellCommands.Add("history", "Prints history of entered commands.");
			LuaWrapperUtils.m_LuaShellCommands.Add("clear history", "delete all commands from history (from all previous RSTD sessions too).");
			LuaWrapperUtils.m_LuaShellCommands.Add("prompt", "Changes prompt. Usage (prompt=<desired_prompt>).");
			LuaWrapperUtils.m_LuaShellCommands.Add("printf", "Imitate C printf");
			LuaWrapperUtils.m_LuaShellCommands.Add("beginblock", "Starts Lua Block, the commands in the block will execute only after endblock command.");
			LuaWrapperUtils.m_LuaShellCommands.Add("endblock", "End Lua block.");
			LuaWrapperUtils.m_LuaShellCommands.Add("breakblock", "Breaks block, not executing the commands in the block.");
			LuaWrapperUtils.m_LuaShellCommands.Add("packages", "List of all Lua available packages.");
			LuaWrapperUtils.m_LuaShellCommands.Add("package <package name>", "List all function in the package name");
		}


		public static List<string> GetLuaShellCommands()
		{
			List<string> list = new List<string>();
			Dictionary<string, string>.KeyCollection keys = LuaWrapperUtils.m_LuaShellCommands.Keys;
			list.AddRange(keys);
			return list;
		}


		public static string ChangeDictionaryKeysToStringSeperatedByAt()
		{
			string text = "";
			foreach (string str in LuaWrapperUtils.m_LuaShellCommands.Keys)
			{
				text = text + str + "@";
			}
			text = text.TrimEnd(new char[]
			{
				'@'
			});
			return text;
		}


		public static object[] DoLuaString(string lua_str, out Thread lua_command_thread, out bool aborted)
		{
			bool safe = false;
			if (lua_str.Contains("("))
			{
				safe = true;
			}
			return LuaWrapperUtils.LuaWrapper.DoString(lua_str, 1, null, out lua_command_thread, false, safe, out aborted);
		}


		private static LuaWrapper m_LuaWrapper = new LuaWrapper();


		private static Dictionary<string, string> m_LuaShellCommands = new Dictionary<string, string>();



		private delegate object[] doStringDel(string str);
	}
}
