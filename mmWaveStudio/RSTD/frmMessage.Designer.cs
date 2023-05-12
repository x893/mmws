namespace RSTD
{

	public partial class frmMessage : global::System.Windows.Forms.Form
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
			this.lblMessage = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lblMessage.AutoSize = true;
			this.lblMessage.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.lblMessage.Location = new global::System.Drawing.Point(9, 19);
			this.lblMessage.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new global::System.Drawing.Size(71, 15);
			this.lblMessage.TabIndex = 0;
			this.lblMessage.Text = "lblMessage";
			this.btnOK.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Location = new global::System.Drawing.Point(94, 65);
			this.btnOK.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(56, 20);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(244, 104);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.lblMessage);
			base.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmMessage";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lua script message";
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Label lblMessage;


		private global::System.Windows.Forms.Button btnOK;
	}
}
