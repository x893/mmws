using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using RSTD.Properties;

namespace RSTD
{

	public partial class Splash : Form
	{

		public Splash()
		{
			this.InitializeComponent();
			this.m_timer.Interval = (double)this.m_timer_interval;
			this.m_timer.Start();
		}


		private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (base.InvokeRequired)
			{
				Splash.TimerDel method = new Splash.TimerDel(this.m_timer_Elapsed);
				base.Invoke(method, new object[]
				{
					sender,
					e
				});
				return;
			}
			this.m_timer.Stop();
			if (RstdGuiSettings.Default.bDisableFadeOutSplash)
			{
				Thread.Sleep(1000);
				return;
			}
			if (base.Opacity > 0.0)
			{
				base.Opacity -= this.m_OpacityDecrement;
				this.m_timer.Start();
				return;
			}
			this.m_timer.Stop();
		}


		public static void ShowSplashScreen()
		{
			if (Splash.m_frmSplash != null)
			{
				return;
			}
			Splash.m_Thread = new Thread(new ThreadStart(Splash.ShowForm));
			Splash.m_Thread.IsBackground = true;
			Splash.m_Thread.ApartmentState = ApartmentState.STA;
			Splash.m_Thread.Start();
			Thread.Sleep(2000);
		}



		public static Splash SplashForm
		{
			get
			{
				return Splash.m_frmSplash;
			}
		}


		private static void ShowForm()
		{
			Splash.m_frmSplash = new Splash();
			Splash.m_frmSplash.ShowDialog();
		}


		public static void CloseForm()
		{
			if (Splash.m_frmSplash.InvokeRequired)
			{
				Splash.CloseFormDel method = new Splash.CloseFormDel(Splash.CloseForm);
				Splash.m_frmSplash.Invoke(method);
				return;
			}
			if (Splash.m_frmSplash != null && !Splash.m_frmSplash.IsDisposed)
			{
				Splash.m_frmSplash.Close();
			}
			Splash.m_Thread = null;
			Splash.m_frmSplash = null;
		}


		private void Splash_Load(object sender, EventArgs e)
		{
		}


		private static Splash m_frmSplash;


		private static Thread m_Thread;


		private double m_OpacityDecrement = 0.08;


		private int m_timer_interval = 1000;



		private delegate void TimerDel(object sender, ElapsedEventArgs e);



		private delegate void CloseFormDel();
	}
}
