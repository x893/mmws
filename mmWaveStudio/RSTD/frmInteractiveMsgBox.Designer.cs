namespace RSTD
{
	public partial class frmInteractiveMsgBox : global::System.Windows.Forms.Form
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
			this.m_tblPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.txtAnswer = new global::System.Windows.Forms.TextBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.lblQuestionText = new global::System.Windows.Forms.Label();
			this.m_FlowPanel = new global::System.Windows.Forms.FlowLayoutPanel();
			this.m_tblPanel.SuspendLayout();
			this.m_FlowPanel.SuspendLayout();
			base.SuspendLayout();
			this.m_tblPanel.AutoSize = true;
			this.m_tblPanel.ColumnCount = 1;
			this.m_tblPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tblPanel.Controls.Add(this.btnOK, 0, 2);
			this.m_tblPanel.Controls.Add(this.txtAnswer, 0, 1);
			this.m_tblPanel.Controls.Add(this.m_FlowPanel, 0, 0);
			this.m_tblPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_tblPanel.Location = new global::System.Drawing.Point(0, 0);
			this.m_tblPanel.Name = "m_tblPanel";
			this.m_tblPanel.RowCount = 3;
			this.m_tblPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.m_tblPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 39f));
			this.m_tblPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 9f));
			this.m_tblPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.m_tblPanel.Size = new global::System.Drawing.Size(400, 135);
			this.m_tblPanel.TabIndex = 2;
			this.txtAnswer.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtAnswer.Location = new global::System.Drawing.Point(3, 53);
			this.txtAnswer.Name = "txtAnswer";
			this.txtAnswer.Size = new global::System.Drawing.Size(394, 20);
			this.txtAnswer.TabIndex = 9;
			this.txtAnswer.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);
			this.btnOK.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.btnOK.Location = new global::System.Drawing.Point(147, 93);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(105, 32);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.lblQuestionText.Anchor = global::System.Windows.Forms.AnchorStyles.Left;
			this.lblQuestionText.AutoSize = true;
			this.lblQuestionText.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.lblQuestionText.Location = new global::System.Drawing.Point(3, 3);
			this.lblQuestionText.Margin = new global::System.Windows.Forms.Padding(3);
			this.lblQuestionText.Name = "lblQuestionText";
			this.lblQuestionText.Size = new global::System.Drawing.Size(92, 15);
			this.lblQuestionText.TabIndex = 8;
			this.lblQuestionText.Text = "Put text here!";
			this.m_FlowPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.m_FlowPanel.Controls.Add(this.lblQuestionText);
			this.m_FlowPanel.Location = new global::System.Drawing.Point(3, 3);
			this.m_FlowPanel.Name = "m_FlowPanel";
			this.m_FlowPanel.Size = new global::System.Drawing.Size(394, 38);
			this.m_FlowPanel.TabIndex = 12;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.ClientSize = new global::System.Drawing.Size(400, 135);
			base.Controls.Add(this.m_tblPanel);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmInteractiveMsgBox";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lua Input Message";
			this.m_tblPanel.ResumeLayout(false);
			this.m_tblPanel.PerformLayout();
			this.m_FlowPanel.ResumeLayout(false);
			this.m_FlowPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.TableLayoutPanel m_tblPanel;
		private global::System.Windows.Forms.Button btnOK;
		private global::System.Windows.Forms.Label lblQuestionText;
		private global::System.Windows.Forms.TextBox txtAnswer;
		private global::System.Windows.Forms.FlowLayoutPanel m_FlowPanel;
	}
}
