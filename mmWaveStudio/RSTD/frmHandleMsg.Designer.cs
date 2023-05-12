namespace RSTD
{

	public partial class frmHandleMsg : global::System.Windows.Forms.Form
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
			this.m_flP_btn = new global::System.Windows.Forms.FlowLayoutPanel();
			this.detailsCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_ImagePictureBox = new global::System.Windows.Forms.PictureBox();
			this.stackLayoutPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.stackTraceTextBox = new global::System.Windows.Forms.TextBox();
			this.m_MainTableLayoutPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.txtMessage = new global::System.Windows.Forms.RichTextBox();
			((global::System.ComponentModel.ISupportInitialize)this.m_ImagePictureBox).BeginInit();
			this.stackLayoutPanel.SuspendLayout();
			this.m_MainTableLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			this.m_flP_btn.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_flP_btn.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_flP_btn.Location = new global::System.Drawing.Point(65, 74);
			this.m_flP_btn.Margin = new global::System.Windows.Forms.Padding(7, 3, 3, 7);
			this.m_flP_btn.Name = "m_flP_btn";
			this.m_flP_btn.Size = new global::System.Drawing.Size(488, 38);
			this.m_flP_btn.TabIndex = 1;
			this.detailsCheckBox.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.detailsCheckBox.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.detailsCheckBox.Image = global::RSTD.Properties.Resources.arrow_down_8;
			this.detailsCheckBox.ImageAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.detailsCheckBox.Location = new global::System.Drawing.Point(3, 74);
			this.detailsCheckBox.Margin = new global::System.Windows.Forms.Padding(3, 3, 3, 7);
			this.detailsCheckBox.Name = "detailsCheckBox";
			this.detailsCheckBox.Size = new global::System.Drawing.Size(52, 27);
			this.detailsCheckBox.TabIndex = 1;
			this.detailsCheckBox.Text = "Stack";
			this.detailsCheckBox.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.detailsCheckBox.UseVisualStyleBackColor = true;
			this.detailsCheckBox.CheckedChanged += new global::System.EventHandler(this.detailsCheckBox_CheckedChanged);
			this.m_ImagePictureBox.Location = new global::System.Drawing.Point(3, 3);
			this.m_ImagePictureBox.Name = "m_ImagePictureBox";
			this.m_ImagePictureBox.Size = new global::System.Drawing.Size(48, 48);
			this.m_ImagePictureBox.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.m_ImagePictureBox.TabIndex = 0;
			this.m_ImagePictureBox.TabStop = false;
			this.stackLayoutPanel.ColumnCount = 3;
			this.m_MainTableLayoutPanel.SetColumnSpan(this.stackLayoutPanel, 2);
			this.stackLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 10f));
			this.stackLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.stackLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 10f));
			this.stackLayoutPanel.Controls.Add(this.stackTraceTextBox, 1, 0);
			this.stackLayoutPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.stackLayoutPanel.Location = new global::System.Drawing.Point(3, 122);
			this.stackLayoutPanel.Name = "stackLayoutPanel";
			this.stackLayoutPanel.RowCount = 1;
			this.stackLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.stackLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 168f));
			this.stackLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 168f));
			this.stackLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 168f));
			this.stackLayoutPanel.Size = new global::System.Drawing.Size(550, 168);
			this.stackLayoutPanel.TabIndex = 3;
			this.stackTraceTextBox.BackColor = global::System.Drawing.Color.White;
			this.stackTraceTextBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.stackTraceTextBox.Location = new global::System.Drawing.Point(13, 3);
			this.stackTraceTextBox.MaxLength = 52767;
			this.stackTraceTextBox.Multiline = true;
			this.stackTraceTextBox.Name = "stackTraceTextBox";
			this.stackTraceTextBox.ReadOnly = true;
			this.stackTraceTextBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.stackTraceTextBox.Size = new global::System.Drawing.Size(524, 162);
			this.stackTraceTextBox.TabIndex = 0;
			this.m_MainTableLayoutPanel.ColumnCount = 2;
			this.m_MainTableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 10.60606f));
			this.m_MainTableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 89.39394f));
			this.m_MainTableLayoutPanel.Controls.Add(this.m_flP_btn, 1, 2);
			this.m_MainTableLayoutPanel.Controls.Add(this.stackLayoutPanel, 0, 3);
			this.m_MainTableLayoutPanel.Controls.Add(this.detailsCheckBox, 0, 2);
			this.m_MainTableLayoutPanel.Controls.Add(this.m_ImagePictureBox, 0, 0);
			this.m_MainTableLayoutPanel.Controls.Add(this.txtMessage, 1, 0);
			this.m_MainTableLayoutPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_MainTableLayoutPanel.Location = new global::System.Drawing.Point(0, 0);
			this.m_MainTableLayoutPanel.Name = "m_MainTableLayoutPanel";
			this.m_MainTableLayoutPanel.RowCount = 4;
			this.m_MainTableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.m_MainTableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 7f));
			this.m_MainTableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 48f));
			this.m_MainTableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.m_MainTableLayoutPanel.Size = new global::System.Drawing.Size(556, 118);
			this.m_MainTableLayoutPanel.TabIndex = 8;
			this.txtMessage.BackColor = global::System.Drawing.SystemColors.Control;
			this.txtMessage.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtMessage.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtMessage.Location = new global::System.Drawing.Point(64, 6);
			this.txtMessage.Margin = new global::System.Windows.Forms.Padding(6);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtMessage.Size = new global::System.Drawing.Size(486, 52);
			this.txtMessage.TabIndex = 4;
			this.txtMessage.Text = "";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = global::System.Drawing.SystemColors.Control;
			base.ClientSize = new global::System.Drawing.Size(556, 118);
			base.Controls.Add(this.m_MainTableLayoutPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmHandleMsg";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.TopMost = true;
			((global::System.ComponentModel.ISupportInitialize)this.m_ImagePictureBox).EndInit();
			this.stackLayoutPanel.ResumeLayout(false);
			this.stackLayoutPanel.PerformLayout();
			this.m_MainTableLayoutPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.FlowLayoutPanel m_flP_btn;


		private global::System.Windows.Forms.PictureBox m_ImagePictureBox;


		private global::System.Windows.Forms.CheckBox detailsCheckBox;


		private global::System.Windows.Forms.TableLayoutPanel stackLayoutPanel;


		private global::System.Windows.Forms.TextBox stackTraceTextBox;


		private global::System.Windows.Forms.TableLayoutPanel m_MainTableLayoutPanel;


		private global::System.Windows.Forms.RichTextBox txtMessage;
	}
}
