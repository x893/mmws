using System;
using System.Collections;

namespace RSTD
{
	internal class CommandHistory
	{
		public ArrayList CommandHistoryRegular
		{
			get
			{
				return m_commandHistory;
			}
			set
			{
				m_commandHistory = value;
			}
		}

		public ArrayList LuaCurrentCommandHistory
		{
			get
			{
				return m_LuaCurrentCommandHistory;
			}
			set
			{
				m_LuaCurrentCommandHistory = value;
			}
		}

		public string Got_command_from_history
		{
			get
			{
				return m_GotCommandFromHistory;
			}
			set
			{
				m_GotCommandFromHistory = value;
			}
		}

		public ArrayList LuaCommandWithDuplicated
		{
			get
			{
				return m_LuaCommandWithDuplicated;
			}
			set
			{
				m_LuaCommandWithDuplicated = value;
			}
		}

		public int CurrentPosn
		{
			get
			{
				return m_CurrentPosn;
			}
			set
			{
				m_CurrentPosn = value;
			}
		}

		public int CurrentPosLua
		{
			get
			{
				return m_LuaCurrentPosn;
			}
			set
			{
				m_LuaCurrentPosn = value;
			}
		}

		internal CommandHistory()
		{
			m_CommandHistoryLengthForFileNotDuplicateCommand = 0;
			m_GotCommandFromHistory = null;
			m_commandHistory = new ArrayList();
			m_LuaCommandWithDuplicated = new ArrayList();
			m_LuaCurrentCommandHistory = new ArrayList();
		}

		internal void Add(string command)
		{
			if (command != m_LastCommand || command == Got_command_from_history)
			{
				m_commandHistory.Add(command);
				m_LastCommand = command;
				m_CurrentPosn = m_commandHistory.Count;
				Got_command_from_history = null;
				m_CommandHistoryLengthForFileNotDuplicateCommand++;
			}
		}

		internal void AddToValidArrayList(string command)
		{
			if (command != null)
			{
				m_commandHistory.Add(command);
			}
		}

		internal bool DoesPreviousCommandExist()
		{
			return m_CurrentPosn > 0;
		}

		internal bool DoesNextCommandExist()
		{
			return m_CurrentPosn < m_commandHistory.Count - 1;
		}

		internal bool DoesPreviousCommandThatStartsWithNoEmptyTokenExist()
		{
			return m_LuaCurrentPosn > 0;
		}

		internal bool DoesNextCommandThatStartsWithNoEmptyTokenExist()
		{
			return m_LuaCurrentPosn < m_LuaCurrentCommandHistory.Count - 1;
		}

		internal string GetPreviousCommand()
		{
			ArrayList commandHistory = m_commandHistory;
			int num = m_CurrentPosn - 1;
			m_CurrentPosn = num;
			m_LastCommand = (string)commandHistory[num];
			return m_LastCommand;
		}

		internal string GetNextCommand()
		{
			ArrayList commandHistory = m_commandHistory;
			int num = m_CurrentPosn + 1;
			m_CurrentPosn = num;
			m_LastCommand = (string)commandHistory[num];
			return LastCommand;
		}

		internal string GetPreviousCommandThatStartsWithNoEmptyToken()
		{
			ArrayList luaCurrentCommandHistory = m_LuaCurrentCommandHistory;
			int num = m_LuaCurrentPosn - 1;
			m_LuaCurrentPosn = num;
			return (string)luaCurrentCommandHistory[num];
		}

		internal string GetNextCommandThatStartsWithNoEmptyToken()
		{
			ArrayList luaCurrentCommandHistory = m_LuaCurrentCommandHistory;
			int num = m_LuaCurrentPosn + 1;
			m_LuaCurrentPosn = num;
			return (string)luaCurrentCommandHistory[num];
		}

		internal string LastCommand
		{
			get
			{
				return m_LastCommand;
			}
		}

		internal string[] GetCommandHistory()
		{
			return (string[])m_commandHistory.ToArray(typeof(string));
		}

		internal string[] GetLuaCommandHistory()
		{
			return (string[])m_LuaCurrentCommandHistory.ToArray(typeof(string));
		}

		internal void EraseCommandHistory()
		{
			m_commandHistory.Clear();
		}

		internal void EraseLuaCommandHistory()
		{
			m_LuaCurrentCommandHistory.Clear();
		}

		internal bool GetCommandsThatStartWithToken(string token)
		{
			foreach (object obj in m_commandHistory)
			{
				string text = (string)obj;
				if (text.ToLower().StartsWith(token.ToLower()))
				{
					m_LuaCurrentCommandHistory.Add(text);
				}
			}
			if (m_LuaCurrentCommandHistory.Count == 0)
			{
				return false;
			}
			Got_command_from_history = null;
			m_LuaCurrentPosn = m_LuaCurrentCommandHistory.Count;
			return true;
		}

		private int m_CurrentPosn;
		private int m_LuaCurrentPosn;
		private int m_CommandHistoryLengthForFileNotDuplicateCommand;
		private string m_LastCommand;
		private string m_GotCommandFromHistory;
		private ArrayList m_commandHistory;
		private ArrayList m_LuaCommandWithDuplicated;

		private static ArrayList m_LuaCurrentCommandHistory;
	}
}
