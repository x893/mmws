using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RSTD
{

	public class WatchDogManager
	{

		public bool IsOnGuard
		{
			get { return m_IsOnGuard; }
			set { m_IsOnGuard = value; }
		}


		public WatchDogManager()
		{
			m_IsOnGuard = false;
			m_FileAccessMutex = new Mutex(false, "WatchDogFileAccessMutex");
		}


		public void Stop()
		{
			Stop("WatchDog", false);
		}


		public void Stop(string proc_name, bool is_au)
		{
			Process runningProcess = GetRunningProcess(proc_name);
			if (runningProcess != null)
			{
				runningProcess.Kill();
			}
			if (!is_au)
			{
				try
				{
					m_FileAccessMutex.WaitOne();
					if (m_WatchDogThread != null && m_WatchDogThread.IsAlive)
					{
						if ((m_WatchDogThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended)
						{
							m_WatchDogThread.Resume();
						}
						m_WatchDogThread.Abort();
						m_WatchDogThread = null;
					}
				}
				catch
				{
				}
				finally
				{
					m_FileAccessMutex.ReleaseMutex();
					m_IsOnGuard = false;
				}
			}
		}


		public void Suspend(RstdConstants.WATCHDOG_LEVEL level)
		{
			GuiCore.AlwaysPrint("Starting Watchdog Suspend.\n");
			bool flag = false;
			if (level < m_User_Selected_Level)
			{
				GuiCore.AlwaysPrint("Watchdog Suspend canceled since level is lower than user required.\n");
				return;
			}
			if (m_WatchDogThread != null && (m_WatchDogThread.ThreadState & System.Threading.ThreadState.Suspended) != System.Threading.ThreadState.Suspended)
			{
				try
				{
					m_FileAccessMutex.WaitOne();
					GuiCore.AlwaysPrint("Suspending RT3 alive thread for Watchdog.\n");
					m_WatchDogThread.Suspend();
					while (!flag)
					{
						Thread.Sleep(10);
						if ((m_WatchDogThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended)
						{
							flag = true;
						}
					}
				}
				catch
				{
				}
				finally
				{
					m_FileAccessMutex.ReleaseMutex();
				}
			}
		}


		public void Resume()
		{
			GuiCore.AlwaysPrint("Starting Watchdog Resume.\n");
			if (m_WatchDogThread != null && (m_WatchDogThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended)
			{
				GuiCore.AlwaysPrint("Resuming RT3 alive thread for Watchdog.\n");
				m_WatchDogThread.Resume();
			}
		}


		private Process GetRunningProcess(string proc_name)
		{
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName.ToUpper() == proc_name.ToUpper())
				{
					return process;
				}
			}
			return null;
		}


		public bool UnleashWatchDogAu(uint timeout, string script_name, string control_file_path)
		{
			Process process = new Process();
			process.StartInfo.FileName = Application.StartupPath + "\\WatchDogAu.exe";
			process.StartInfo.Arguments = string.Format("\"{0}\" {1} \"{2}\"", control_file_path, timeout, script_name);
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.UseShellExecute = false;
			GuiCore.AlwaysPrint("Starting WatchDogAu.\n");
			bool flag = process.Start();
			if (flag)
			{
				m_IsOnGuard = true;
			}
			return flag;
		}


		public bool UnleashWatchDog(uint timeout, string script_name, RstdConstants.WATCHDOG_LEVEL level)
		{
			string text = Application.StartupPath + Path.DirectorySeparatorChar.ToString() + "WatchDogControl.bin";
			m_User_Selected_Level = level;
			LifeSignsParams lifeSignsParams = default(LifeSignsParams);
			lifeSignsParams.m_FileName = text;
			lifeSignsParams.m_TimeOut = (int)timeout;
			ParameterizedThreadStart start = new ParameterizedThreadStart(iWriteAliveSignToFile);
			m_WatchDogThread = new Thread(start);
			Process process = new Process();
			m_WatchDogThread.IsBackground = true;
			try
			{
				m_FileAccessMutex.WaitOne();
				GuiCore.AlwaysPrint("Mutex2WaitOne.\n");
				new FileStream(text, FileMode.Create).Close();
			}
			catch
			{
			}
			finally
			{
				m_FileAccessMutex.ReleaseMutex();
			}
			GuiCore.AlwaysPrint("Starting RT3 alive thread for WatchDog.\n");
			m_WatchDogThread.Start(lifeSignsParams);
			string text2 = Application.StartupPath + "\\Rstd.exe";
			process.StartInfo.FileName = Application.StartupPath + "\\WatchDog.exe";
			process.StartInfo.Arguments = string.Format("\"{0}\" \"{1}\" {2} \"{3}\" \"{4}\"", new object[]
			{
				text2,
				text,
				timeout,
				GuiCore.MainForm.LastLogFileName,
				script_name
			});
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.UseShellExecute = false;
			GuiCore.AlwaysPrint("Starting WatchDog.\n");
			bool flag = process.Start();
			if (flag)
			{
				m_IsOnGuard = true;
			}
			return flag;
		}


		private void iWriteAliveSignToFile(object lsp_obj)
		{
			LifeSignsParams lifeSignsParams = (LifeSignsParams)lsp_obj;
			for (;;)
			{
				try
				{
					m_FileAccessMutex.WaitOne();
					GuiCore.AlwaysPrint("Mutex1WaitOne.\n");
					FileStream fileStream = new FileStream(lifeSignsParams.m_FileName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
					fileStream.WriteByte(1);
					fileStream.Close();
				}
				catch
				{
				}
				finally
				{
					m_FileAccessMutex.ReleaseMutex();
				}
				Thread.Sleep(lifeSignsParams.m_TimeOut / 3);
			}
		}


		private Thread m_WatchDogThread;


		private RstdConstants.WATCHDOG_LEVEL m_User_Selected_Level;


		private Mutex m_FileAccessMutex;


		private bool m_IsOnGuard;
	}
}
