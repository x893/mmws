namespace RSTD
{

	public partial class frmYesNoTimerMsgBox : global::System.Windows.Forms.Form
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
			this.btnNo = new global::System.Windows.Forms.Button();
			this.btnYes = new global::System.Windows.Forms.Button();
			this.QestionText = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnNo.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnNo.Location = new global::System.Drawing.Point(168, 79);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new global::System.Drawing.Size(109, 27);
			this.btnNo.TabIndex = 5;
			this.btnNo.Text = "no";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new global::System.EventHandler(this.btnNo_Click);
			this.btnYes.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnYes.Location = new global::System.Drawing.Point(15, 79);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new global::System.Drawing.Size(109, 27);
			this.btnYes.TabIndex = 4;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new global::System.EventHandler(this.btnYes_Click);
			this.QestionText.AutoSize = true;
			this.QestionText.Location = new global::System.Drawing.Point(12, 22);
			this.QestionText.Name = "QestionText";
			this.QestionText.Size = new global::System.Drawing.Size(73, 13);
			this.QestionText.TabIndex = 3;
			this.QestionText.Text = "Put Test Here";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(304, 129);
			base.Controls.Add(this.btnNo);
			base.Controls.Add(this.btnYes);
			base.Controls.Add(this.QestionText);
			base.Name = "frmYesNoTimerMsgBox";
			this.Text = "frmYesNoTimerMsgBox";
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Button btnNo;


		private global::System.Windows.Forms.Button btnYes;


		private global::System.Windows.Forms.Label QestionText;
	}
}
