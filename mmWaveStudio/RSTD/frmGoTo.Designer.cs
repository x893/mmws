namespace RSTD
{

	public partial class frmGoTo : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmGoTo));
			this.m_txtPath = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.m_txtPath.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_txtPath.Location = new global::System.Drawing.Point(50, 20);
			this.m_txtPath.Name = "m_txtPath";
			this.m_txtPath.Size = new global::System.Drawing.Size(424, 20);
			this.m_txtPath.TabIndex = 0;
			this.m_txtPath.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_txtPath_KeyDown);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Path:";
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.Location = new global::System.Drawing.Point(284, 60);
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(56, 22);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.TabStop = false;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(146, 60);
			this.btnOK.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(56, 22);
			this.btnOK.TabIndex = 7;
			this.btnOK.TabStop = false;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(486, 94);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.m_txtPath);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmGoTo";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Go To Path";
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.TextBox m_txtPath;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.Button btnCancel;


		public global::System.Windows.Forms.Button btnOK;
	}
}
