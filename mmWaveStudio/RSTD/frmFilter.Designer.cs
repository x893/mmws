namespace RSTD
{

	public partial class frmFilter : global::System.Windows.Forms.Form
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
			this.txtInclude = new global::System.Windows.Forms.TextBox();
			this.txtExclude = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.txtInclude.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtInclude.Location = new global::System.Drawing.Point(75, 45);
			this.txtInclude.Name = "txtInclude";
			this.txtInclude.Size = new global::System.Drawing.Size(266, 22);
			this.txtInclude.TabIndex = 0;
			this.txtExclude.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtExclude.Location = new global::System.Drawing.Point(75, 96);
			this.txtExclude.Name = "txtExclude";
			this.txtExclude.Size = new global::System.Drawing.Size(266, 22);
			this.txtExclude.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(57, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Include:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 99);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Exclude:";
			this.btnOK.Location = new global::System.Drawing.Point(104, 145);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(77, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(238, 145);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(77, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(369, 191);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtExclude);
			base.Controls.Add(this.txtInclude);
			this.MinimumSize = new global::System.Drawing.Size(377, 231);
			base.Name = "frmFilter";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Filter";
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.TextBox txtInclude;


		private global::System.Windows.Forms.TextBox txtExclude;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.Label label2;


		private global::System.Windows.Forms.Button btnOK;


		private global::System.Windows.Forms.Button btnCancel;
	}
}
