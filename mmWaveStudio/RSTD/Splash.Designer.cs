namespace RSTD
{

	public partial class Splash : global::System.Windows.Forms.Form
	{

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
			this.m_timer = new global::System.Timers.Timer();
			((global::System.ComponentModel.ISupportInitialize)this.m_timer).BeginInit();
			base.SuspendLayout();
			this.m_timer.Enabled = true;
			this.m_timer.Interval = 5000.0;
			this.m_timer.SynchronizingObject = this;
			this.m_timer.Elapsed += new global::System.Timers.ElapsedEventHandler(this.m_timer_Elapsed);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.Black;
			this.BackgroundImage = global::RSTD.Properties.Resources.mmWaveStudioSplashScreen1;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new global::System.Drawing.Size(628, 425);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Splash";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Splash";
			base.Load += new global::System.EventHandler(this.Splash_Load);
			((global::System.ComponentModel.ISupportInitialize)this.m_timer).EndInit();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Timers.Timer m_timer;
	}
}
