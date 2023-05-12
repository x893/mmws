namespace RSTD
{

	public partial class frmLuaRegister : global::System.Windows.Forms.Form
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
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.m_dgvDllRegister = new global::System.Windows.Forms.DataGridView();
			this.colUse = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colIsRegistered = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colPackage = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPath = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBrowse = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.btn_Cancel = new global::System.Windows.Forms.Button();
			this.btn_OK = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvDllRegister).BeginInit();
			base.SuspendLayout();
			this.m_dgvDllRegister.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgvDllRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.m_dgvDllRegister.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dgvDllRegister.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colUse,
				this.colIsRegistered,
				this.colPackage,
				this.colPath,
				this.colBrowse
			});
			dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			dataGridViewCellStyle2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgvDllRegister.DefaultCellStyle = dataGridViewCellStyle2;
			this.m_dgvDllRegister.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.m_dgvDllRegister.Location = new global::System.Drawing.Point(0, 0);
			this.m_dgvDllRegister.Name = "m_dgvDllRegister";
			dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			dataGridViewCellStyle3.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgvDllRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.m_dgvDllRegister.RowHeadersWidth = 30;
			this.m_dgvDllRegister.RowHeadersWidthSizeMode = global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgvDllRegister.Size = new global::System.Drawing.Size(572, 157);
			this.m_dgvDllRegister.TabIndex = 2;
			this.m_dgvDllRegister.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDllRegister_CellContentClick);
			this.m_dgvDllRegister.RowsAdded += new global::System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDllRegister_RowsAdded);
			this.colUse.HeaderText = "Use";
			this.colUse.MinimumWidth = 40;
			this.colUse.Name = "colUse";
			this.colUse.Width = 40;
			this.colIsRegistered.HeaderText = "IsRegistered";
			this.colIsRegistered.Name = "colIsRegistered";
			this.colIsRegistered.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.colIsRegistered.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colIsRegistered.Visible = false;
			this.colPackage.HeaderText = "Package";
			this.colPackage.Name = "colPackage";
			this.colPackage.ReadOnly = true;
			this.colPath.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colPath.HeaderText = "Path";
			this.colPath.Name = "colPath";
			dataGridViewCellStyle4.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.NullValue = "...";
			this.colBrowse.DefaultCellStyle = dataGridViewCellStyle4;
			this.colBrowse.HeaderText = "";
			this.colBrowse.MinimumWidth = 25;
			this.colBrowse.Name = "colBrowse";
			this.colBrowse.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.colBrowse.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colBrowse.Text = "...";
			this.colBrowse.ToolTipText = "Browse For A DLL...";
			this.colBrowse.Width = 25;
			this.btn_Cancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btn_Cancel.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btn_Cancel.ForeColor = global::System.Drawing.Color.Navy;
			this.btn_Cancel.Location = new global::System.Drawing.Point(300, 178);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new global::System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 4;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new global::System.EventHandler(this.btn_Cancel_Click);
			this.btn_OK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btn_OK.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btn_OK.ForeColor = global::System.Drawing.Color.Navy;
			this.btn_OK.Location = new global::System.Drawing.Point(182, 178);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new global::System.Drawing.Size(75, 23);
			this.btn_OK.TabIndex = 3;
			this.btn_OK.Text = "OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new global::System.EventHandler(this.btn_OK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(572, 223);
			base.Controls.Add(this.btn_Cancel);
			base.Controls.Add(this.btn_OK);
			base.Controls.Add(this.m_dgvDllRegister);
			base.KeyPreview = true;
			base.Name = "frmLuaRegister";
			this.Text = "Register Dlls To Lua";
			base.Load += new global::System.EventHandler(this.frmLuaRegister_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.frmLuaRegister_KeyDown);
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvDllRegister).EndInit();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.DataGridView m_dgvDllRegister;


		private global::System.Windows.Forms.Button btn_Cancel;


		private global::System.Windows.Forms.Button btn_OK;


		private global::System.Windows.Forms.DataGridViewCheckBoxColumn colUse;


		private global::System.Windows.Forms.DataGridViewCheckBoxColumn colIsRegistered;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colPackage;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colPath;


		private global::System.Windows.Forms.DataGridViewButtonColumn colBrowse;
	}
}
