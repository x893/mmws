using System;

namespace RSTD
{

	public static class RstdConstants
	{

		public static RstdConstants.CheckedToolBars ToolBarParseStr2EnumVal(string name)
		{
			if (name == "STANDARD")
			{
				return RstdConstants.CheckedToolBars.STANDARD;
			}
			if (name == "USER_BUTTONS")
			{
				return RstdConstants.CheckedToolBars.USER_BUTTONS;
			}
			if (!(name == "SCRIPT"))
			{
				return RstdConstants.CheckedToolBars.ERROR_TOOL_BAR;
			}
			return RstdConstants.CheckedToolBars.SCRIPT;
		}


		public static string ListViewParseColumnNameToEnumVal(string name)
		{
			if (name == "NAME")
			{
				return "Name";
			}
			if (name == "VALUE")
			{
				return "Value";
			}
			if (name == "ADDRESS")
			{
				return "Address";
			}
			if (name == "START_BIT")
			{
				return "Start Bit";
			}
			if (name == "STOP_BIT")
			{
				return "Stop Bit";
			}
			if (!(name == "DESCRIPTION"))
			{
				return "Error";
			}
			return "Description";
		}


		public static RstdConstants.ListViewSubItem_T ListViewParseStr2EnumVal(string name)
		{
			uint num = PrivateImplementationDetails.ComputeStringHash(name);
			if (num <= 1122648243U)
			{
				if (num <= 595531577U)
				{
					if (num != 220155128U)
					{
						if (num != 266367750U)
						{
							if (num != 595531577U)
							{
								return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
							}
							if (!(name == "STOP_BIT"))
							{
								return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
							}
							return RstdConstants.ListViewSubItem_T.STOP_BIT;
						}
						else if (!(name == "Name"))
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
					}
					else
					{
						if (!(name == "Start Bit"))
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
						return RstdConstants.ListViewSubItem_T.START_BIT;
					}
				}
				else if (num != 622060074U)
				{
					if (num != 1103584457U)
					{
						if (num != 1122648243U)
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
						if (!(name == "ADDRESS"))
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
						return RstdConstants.ListViewSubItem_T.ADDRESS;
					}
					else
					{
						if (!(name == "DESCRIPTION"))
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
						return RstdConstants.ListViewSubItem_T.DESCRIPTION;
					}
				}
				else
				{
					if (!(name == "VALUE"))
					{
						return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
					}
					return RstdConstants.ListViewSubItem_T.VALUE;
				}
			}
			else if (num <= 1725856265U)
			{
				if (num != 1296227947U)
				{
					if (num != 1387956774U)
					{
						if (num != 1725856265U)
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
						if (!(name == "Description"))
						{
							return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
						}
						return RstdConstants.ListViewSubItem_T.DESCRIPTION;
					}
					else if (!(name == "NAME"))
					{
						return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
					}
				}
				else
				{
					if (!(name == "START_BIT"))
					{
						return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
					}
					return RstdConstants.ListViewSubItem_T.START_BIT;
				}
			}
			else if (num != 1879400691U)
			{
				if (num != 2781217978U)
				{
					if (num != 3511155050U)
					{
						return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
					}
					if (!(name == "Value"))
					{
						return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
					}
					return RstdConstants.ListViewSubItem_T.VALUE;
				}
				else
				{
					if (!(name == "Stop Bit"))
					{
						return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
					}
					return RstdConstants.ListViewSubItem_T.STOP_BIT;
				}
			}
			else
			{
				if (!(name == "Address"))
				{
					return RstdConstants.ListViewSubItem_T.ERROR_SUB_ITEM;
				}
				return RstdConstants.ListViewSubItem_T.ADDRESS;
			}
			return RstdConstants.ListViewSubItem_T.NAME;
		}


		public const int Tooltip_Max_Width = 500;


		public const uint NumBrowseTreeColumns = 6U;


		public const uint NumWorkSetColumns = 6U;


		public const int NumCheckedToolBars = 3;


		public const int NumDockContents = 5;


		public const int UserButtonMaxWidth = 50;


		public const int ToolBarsHeaderItems = 4;


		public const int RunRtttScriptsMessage = 30;


		public const int WatchDogMessage = 60;


		public const string ScriptThreadName = "ScriptThread";


		public const string DoStringThreadName = "DoStringThread";


		public const string GuiThreadName = "GUI";


		public const string RegexOldFixmodeFormat = "\\((-?[0-9]+).(-?[0-9]+)([S|U])?\\)[T|R|F][E|W|C][S|A][T|F]";


		public const string RegexNewFixmodeFormat = "\\((-?[0-9]+).(-?[0-9]+)([S|U])?\\)((T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)(,(T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)){0,3})?$";


		public enum ListViewSubItem_T
		{

			NAME,

			VALUE,

			ADDRESS,

			START_BIT,

			STOP_BIT,

			DESCRIPTION,

			ERROR_SUB_ITEM
		}


		public enum CheckedToolBars
		{

			STANDARD,

			USER_BUTTONS,

			SCRIPT,

			ERROR_TOOL_BAR
		}


		public enum FILE_HANDLE
		{

			SUCCESS,

			WRONG_EXTENSION,

			WRONG_PATH,

			EMPTY_FILE_NAME
		}


		public enum CORE_MSG_BTN
		{

			OK,

			ExitDebugIgnore,

			OkCancel,

			YesNo,

			ExitDebug
		}


		public enum MESSAGE_TYPE
		{

			OK_INFORMATION,

			RSTD_EXCEPTION,

			OK_CANCEL_INFORMATION,

			QEUSTION,

			RSTD_EXCEPTION_EXIT,

			RSTD_DEF,

			OK_ERROR,

			YES_NO_WARNING,

			OK_WARNING,

			GUI_CLIENT_MESSAGE,

			GUI_CLIENT_ERROR
		}


		public enum WATCHDOG_LEVEL
		{

			RSTD_MESSAGES = 1,

			LUA_ERRORS,

			RSTD_ERRORS
		}


		public enum CONTEXT_MENU_ORIGIN
		{

			MONITOR,

			WORKSET,

			BROWSE_TREE,

			FIND_FORM,

			SUB_SET
		}


		public enum GUI_OPERATION
		{

			RECEIVE,

			TRANSMIT
		}


		public enum FILE_TYPE
		{

			XML = 1,

			TXT,

			CSV = 4
		}
	}
}
