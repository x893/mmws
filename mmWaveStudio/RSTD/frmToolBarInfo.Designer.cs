namespace RSTD
{

	public partial class frmToolBarInfo : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmToolBarInfo));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.nameTextBox = new global::System.Windows.Forms.TextBox();
			this.basePathTextBox = new global::System.Windows.Forms.TextBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.okButton = new global::System.Windows.Forms.Button();
			this.browseButton = new global::System.Windows.Forms.Button();
			this.pathlinkLabel = new global::System.Windows.Forms.LinkLabel();
			this.pathFlowLayoutPanel = new global::System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.pathFlowLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(86, 28);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(78, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "ToolBar Name:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(86, 63);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(99, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "ToolBar Base Path:";
			this.nameTextBox.Location = new global::System.Drawing.Point(191, 23);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new global::System.Drawing.Size(296, 20);
			this.nameTextBox.TabIndex = 2;
			this.basePathTextBox.Location = new global::System.Drawing.Point(191, 57);
			this.basePathTextBox.Name = "basePathTextBox";
			this.basePathTextBox.Size = new global::System.Drawing.Size(296, 20);
			this.basePathTextBox.TabIndex = 3;
			this.pictureBox1.Image = global::RSTD.Properties.Resources.settings_64;
			this.pictureBox1.Location = new global::System.Drawing.Point(12, 20);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(68, 66);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.cancelButton.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Image = global::RSTD.Properties.Resources.cancel;
			this.cancelButton.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelButton.Location = new global::System.Drawing.Point(451, 150);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(70, 31);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cancelButton.UseVisualStyleBackColor = true;
			this.okButton.Image = global::RSTD.Properties.Resources.ok;
			this.okButton.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.okButton.Location = new global::System.Drawing.Point(375, 150);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(70, 31);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "Ok";
			this.okButton.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.browseButton.Location = new global::System.Drawing.Point(491, 58);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new global::System.Drawing.Size(30, 20);
			this.browseButton.TabIndex = 7;
			this.browseButton.Text = "...";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new global::System.EventHandler(this.browseButton_Click);
			this.pathlinkLabel.AutoSize = true;
			this.pathlinkLabel.Location = new global::System.Drawing.Point(79, 0);
			this.pathlinkLabel.Name = "pathlinkLabel";
			this.pathlinkLabel.Size = new global::System.Drawing.Size(55, 13);
			this.pathlinkLabel.TabIndex = 8;
			this.pathlinkLabel.TabStop = true;
			this.pathlinkLabel.Text = "linkLabel1";
			this.pathlinkLabel.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pathlinkLabel_LinkClicked);
			this.pathFlowLayoutPanel.Controls.Add(this.label3);
			this.pathFlowLayoutPanel.Controls.Add(this.pathlinkLabel);
			this.pathFlowLayoutPanel.Location = new global::System.Drawing.Point(17, 100);
			this.pathFlowLayoutPanel.Name = "pathFlowLayoutPanel";
			this.pathFlowLayoutPanel.Size = new global::System.Drawing.Size(495, 36);
			this.pathFlowLayoutPanel.TabIndex = 9;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(70, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "File Location:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(530, 189);
			base.Controls.Add(this.pathFlowLayoutPanel);
			base.Controls.Add(this.browseButton);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.basePathTextBox);
			base.Controls.Add(this.nameTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmToolBarInfo";
			base.ShowInTaskbar = false;
			this.Text = "Config ToolBar";
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.pathFlowLayoutPanel.ResumeLayout(false);
			this.pathFlowLayoutPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.Label label2;


		private global::System.Windows.Forms.TextBox nameTextBox;


		private global::System.Windows.Forms.TextBox basePathTextBox;


		private global::System.Windows.Forms.Button okButton;


		private global::System.Windows.Forms.Button cancelButton;


		private global::System.Windows.Forms.PictureBox pictureBox1;


		private global::System.Windows.Forms.Button browseButton;


		private global::System.Windows.Forms.LinkLabel pathlinkLabel;


		private global::System.Windows.Forms.FlowLayoutPanel pathFlowLayoutPanel;


		private global::System.Windows.Forms.Label label3;
	}
}
