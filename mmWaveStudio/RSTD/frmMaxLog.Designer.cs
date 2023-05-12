namespace RSTD
{

	public partial class frmMaxLog : global::System.Windows.Forms.Form
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
			this.btnOpenLogFolder = new global::System.Windows.Forms.Button();
			this.lblMessage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnNo.Location = new global::System.Drawing.Point(101, 66);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new global::System.Drawing.Size(62, 27);
			this.btnNo.TabIndex = 8;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new global::System.EventHandler(this.btnNo_Click);
			this.btnYes.Location = new global::System.Drawing.Point(12, 66);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new global::System.Drawing.Size(62, 27);
			this.btnYes.TabIndex = 7;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new global::System.EventHandler(this.btnYes_Click);
			this.btnOpenLogFolder.Location = new global::System.Drawing.Point(186, 66);
			this.btnOpenLogFolder.Name = "btnOpenLogFolder";
			this.btnOpenLogFolder.Size = new global::System.Drawing.Size(96, 27);
			this.btnOpenLogFolder.TabIndex = 9;
			this.btnOpenLogFolder.Text = "Open Log Folder";
			this.btnOpenLogFolder.UseVisualStyleBackColor = true;
			this.btnOpenLogFolder.Click += new global::System.EventHandler(this.btnOpenLogFolder_Click);
			this.lblMessage.AutoSize = true;
			this.lblMessage.Location = new global::System.Drawing.Point(24, 22);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new global::System.Drawing.Size(49, 13);
			this.lblMessage.TabIndex = 6;
			this.lblMessage.Text = "message";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(308, 114);
			base.Controls.Add(this.btnOpenLogFolder);
			base.Controls.Add(this.btnNo);
			base.Controls.Add(this.btnYes);
			base.Controls.Add(this.lblMessage);
			base.Name = "frmMaxLog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Radar Studio";
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Button btnNo;


		private global::System.Windows.Forms.Button btnYes;


		private global::System.Windows.Forms.Button btnOpenLogFolder;


		private global::System.Windows.Forms.Label lblMessage;
	}
}
