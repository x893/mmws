using System;
using System.Threading;
using System.Timers;

namespace RSTD
{

	internal class TimerManager
	{



		public bool TimerAbort
		{
			get
			{
				return this.m_bTimerAbort;
			}
			set
			{
				this.m_bTimerAbort = value;
			}
		}




		public int PassedTime
		{
			get
			{
				return this.m_PassedTime;
			}
			set
			{
				this.m_PassedTime = value;
			}
		}




		public int TimeoutCount
		{
			get
			{
				return this.m_TimeoutCount;
			}
			set
			{
				this.m_TimeoutCount = value;
			}
		}




		public int TimeOutTime
		{
			get
			{
				return this.m_TimeOutTime;
			}
			set
			{
				this.m_TimeOutTime = value;
			}
		}




		public string ReRunScript
		{
			get
			{
				return this.m_ReRunScript;
			}
			set
			{
				this.m_ReRunScript = value;
			}
		}


		public TimerManager(frmMain main_form)
		{
			this.m_ScriptTimer = new System.Timers.Timer();
			this.m_PassedTime = 0;
			this.m_TimeoutCount = 0;
			this.m_TimeOutTime = 0;
			this.m_bTimerAbort = false;
			this.m_MainForm = main_form;
		}


		public void TimerStart(int time, string script)
		{
			this.m_PassedTime = 0;
			this.m_bTimerAbort = false;
			this.m_TimeOutTime = time;
			this.m_ReRunScript = script;
			new Thread(new ThreadStart(this.iTimerCounter))
			{
				IsBackground = true
			}.Start();
		}


		private void iTimerCounter()
		{
			Thread.CurrentThread.Name = "TimerThread";
			this.m_MainForm.AlwaysPrint("Timeout thread started\n");
			while (this.m_PassedTime < this.m_TimeOutTime && frmMain.bIsScriptRunning && !this.m_bTimerAbort)
			{
				Thread.Sleep(1000);
				this.m_PassedTime++;
			}
			if (!frmMain.bIsScriptRunning || this.m_bTimerAbort)
			{
				this.m_MainForm.AlwaysPrint("Timeout thread aborted\n");
				return;
			}
			this.m_TimeoutCount++;
			this.m_MainForm.AlwaysPrint(string.Format("Timeout occurred! (count={0}) Stopping the current script and starting \"{1}\".\n", this.m_TimeoutCount, this.m_ReRunScript));
			this.m_PassedTime = 0;
			this.m_MainForm.StopScript();
			int num = 3000;
			int num2 = 0;
			int num3 = 100;
			while (frmMain.bIsScriptRunning && num2 < num / num3)
			{
				Thread.Sleep(num3);
				num2++;
			}
			if (frmMain.bIsScriptRunning)
			{
				this.m_MainForm.ErrorPrint("Timeout thread: failed to stop the running script\n");
				return;
			}
			bool flag;
			LuaWrapperUtils.LuaWrapper.DoFile(this.m_ReRunScript, true, out flag);
		}


		public void TimerEnd()
		{
			this.m_MainForm.AlwaysPrint("RTTT.TimerEnd(): stopping the timeout thread\n");
			this.m_PassedTime = 0;
			this.m_bTimerAbort = true;
		}


		private bool m_bTimerAbort;


		private int m_PassedTime;


		private int m_TimeoutCount;


		private int m_TimeOutTime;


		private string m_ReRunScript;


		private System.Timers.Timer m_ScriptTimer;


		private frmMain m_MainForm;
	}
}
