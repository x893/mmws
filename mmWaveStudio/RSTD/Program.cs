using System;
using System.Diagnostics;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace RSTD
{

	internal static class Program
	{



		public static string ClientDll
		{
			get
			{
				return Program.m_ClientDll;
			}
			set
			{
				Program.m_ClientDll = value;
			}
		}




		public static string OwningUser
		{
			get
			{
				return Program.m_OwningUser;
			}
			set
			{
				Program.m_OwningUser = value;
			}
		}




		public static string ConfigPath
		{
			get
			{
				return Program.m_ConfigPath;
			}
			set
			{
				Program.m_ConfigPath = value;
			}
		}




		public static string LuaExecutableScript
		{
			get
			{
				return Program.m_LuaExecutableScript;
			}
			set
			{
				Program.m_LuaExecutableScript = value;
			}
		}




		public static string Title
		{
			get
			{
				return Program.m_Title;
			}
			set
			{
				Program.m_Title = value;
			}
		}


		[STAThread]
		private static void Main(string[] args)
		{
			if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
			{
				MessageBox.Show("Application already running. Only one instance of this application is allowed", "mmWaveStudio Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				if (ParseArgs(args))
				{
					if (m_UserName != null && m_UserPass != null)
					{
						RunAs();
					}
					else
					{
						m_MainForm = new frmMain();
						if (m_MainForm.bAllProcsImported)
						{
							Application.Run(m_MainForm);
						}
						else
						{
							Application.Exit();
						}
					}
				}
			}
			catch (Exception ex)
			{
				iPrintExceptionInfo(ex);
			}
		}


		public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
				iPrintExceptionInfo(e.Exception);
			}
			catch (Exception ex)
			{
				try
				{
					MessageBox.Show(ex.Message + "\n\nStacktrace:\n" + ex.StackTrace, "Radar Studio Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					Environment.Exit(1);
				}
			}
		}


		public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				iPrintExceptionInfo((Exception)e.ExceptionObject);
			}
			catch (Exception ex)
			{
				try
				{
					MessageBox.Show(ex.Message + "\n\nStacktrace:\n" + ex.StackTrace, "Radar Studio Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					Application.Exit();
					Environment.Exit(1);
				}
			}
			finally
			{
				Application.Exit();
				Environment.Exit(1);
			}
		}


		private static void iPrintExceptionInfo(Exception ex)
		{
			if (Program.m_MainForm != null && Program.m_MainForm.WatchDogManager != null && Program.m_MainForm.WatchDogManager.IsOnGuard)
			{
				Program.m_MainForm.WatchDogManager.Suspend(RstdConstants.WATCHDOG_LEVEL.RSTD_ERRORS);
			}
			MessageBox.Show(ex.Message + "\n\nStacktrace:\n" + ex.StackTrace, "Radar Studio Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			if (Program.m_MainForm != null && Program.m_MainForm.WatchDogManager != null && Program.m_MainForm.WatchDogManager.IsOnGuard)
			{
				Program.m_MainForm.WatchDogManager.Resume();
			}
		}


		private static bool ParseArgs(string[] args)
		{
			string text = null;
			if (args.Length == 0)
				return true;

			for (int i = 0; i < args.Length - 1; i++)
			{
				string text2 = args[i].ToLower();
				if (text2 == "/p")
				{
					if (!args[i + 1].StartsWith("/"))
						text = args[++i];
				}
				else if (text2 == "/u")
				{
					if (!args[i + 1].StartsWith("/"))
						m_UserName = args[++i];
				}
				else if (text2 == "/t")
				{
					m_Title = args[++i];
				}
				else if (text2 == "/config")
				{
					if (!args[i + 1].StartsWith("/"))
						m_ConfigPath = args[++i];
				}
				else if (text2 == "/lua")
				{
					if (!args[i + 1].StartsWith("/"))
						m_LuaExecutableScript = args[++i];
				}
				else if (text2 == "/dll")
				{
					if (!args[i + 1].StartsWith("/"))
						m_ClientDll = args[++i];
				}
				else if (text2 == "/owninguser")
				{
					m_OwningUser = args[++i];
				}
			}

			if (text != null)
			{
				m_UserPass = new SecureString();
				foreach (char c in text)
					m_UserPass.AppendChar(c);
			}

			if ((m_UserName == null || m_UserPass == null) && m_ClientDll == null && m_OwningUser == null && m_ConfigPath == null && m_LuaExecutableScript == null && m_Title == null)
			{
				MessageBox.Show(@"Invalid arguments. Allowed Switches:
/config <config_dir_full_path>
/u <username>
/p <password>
/dll <dll path>
/lua <lua executable file>
/t title
", "Radar Studio");
				return false;
			}
			return true;
		}


		private static void RunAs()
		{
			string text = null;
			if (!Program.m_UserName.Contains("@"))
			{
				text = text + Program.m_UserName + "@ENT";
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo(Application.ExecutablePath);
			processStartInfo.UserName = text;
			processStartInfo.Password = Program.m_UserPass;
			processStartInfo.LoadUserProfile = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.Arguments = "/OwningUser " + Environment.UserName;
			if (Program.m_ClientDll != null)
			{
				ProcessStartInfo processStartInfo2 = processStartInfo;
				processStartInfo2.Arguments = processStartInfo2.Arguments + " /dll " + Program.m_ClientDll;
			}
			if (Program.m_LuaExecutableScript != null)
			{
				ProcessStartInfo processStartInfo3 = processStartInfo;
				processStartInfo3.Arguments = processStartInfo3.Arguments + " /lua " + Program.m_LuaExecutableScript;
			}
			Process process = new Process();
			process.StartInfo = processStartInfo;
			try
			{
				process.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nnStacktrace:\n" + ex.StackTrace, "Radar Studio Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			Application.Exit();
		}


		private static string m_UserName;


		private static SecureString m_UserPass;


		private static string m_ClientDll;


		private static string m_OwningUser;


		private static string m_ConfigPath;


		private static string m_LuaExecutableScript;


		private static string m_Title;


		private static frmMain m_MainForm;
	}
}
