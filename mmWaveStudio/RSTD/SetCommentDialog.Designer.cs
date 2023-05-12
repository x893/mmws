namespace RSTD
{

	public partial class SetCommentDialog : global::System.Windows.Forms.Form
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
			this.m_txtSetComment = new global::System.Windows.Forms.TextBox();
			this.m_CancelBtn = new global::System.Windows.Forms.Button();
			this.m_OkBtn = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.m_txtSetComment.Location = new global::System.Drawing.Point(12, 31);
			this.m_txtSetComment.Name = "m_txtSetComment";
			this.m_txtSetComment.Size = new global::System.Drawing.Size(556, 20);
			this.m_txtSetComment.TabIndex = 0;
			this.m_CancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_CancelBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_CancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.m_CancelBtn.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_CancelBtn.ForeColor = global::System.Drawing.Color.Navy;
			this.m_CancelBtn.Location = new global::System.Drawing.Point(314, 78);
			this.m_CancelBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_CancelBtn.Name = "m_CancelBtn";
			this.m_CancelBtn.Size = new global::System.Drawing.Size(64, 29);
			this.m_CancelBtn.TabIndex = 2;
			this.m_CancelBtn.Text = "Cancel";
			this.m_CancelBtn.UseVisualStyleBackColor = true;
			this.m_CancelBtn.Click += new global::System.EventHandler(this.m_CancelBtn_Click);
			this.m_OkBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_OkBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_OkBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_OkBtn.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_OkBtn.ForeColor = global::System.Drawing.Color.Navy;
			this.m_OkBtn.Location = new global::System.Drawing.Point(181, 78);
			this.m_OkBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_OkBtn.Name = "m_OkBtn";
			this.m_OkBtn.Size = new global::System.Drawing.Size(62, 29);
			this.m_OkBtn.TabIndex = 1;
			this.m_OkBtn.Text = "Ok";
			this.m_OkBtn.UseVisualStyleBackColor = true;
			this.m_OkBtn.Click += new global::System.EventHandler(this.m_OkBtn_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(54, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Comment:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(575, 122);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.m_txtSetComment);
			base.Controls.Add(this.m_OkBtn);
			base.Controls.Add(this.m_CancelBtn);
			base.KeyPreview = true;
			base.Name = "SetCommentDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set Comment";
			base.Load += new global::System.EventHandler(this.SetCommentDialog_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.SetCommentDialog_KeyDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.TextBox m_txtSetComment;


		private global::System.Windows.Forms.Button m_CancelBtn;


		private global::System.Windows.Forms.Button m_OkBtn;


		private global::System.Windows.Forms.Label label1;
	}
}
