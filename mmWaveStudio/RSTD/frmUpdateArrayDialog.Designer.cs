namespace RSTD
{

	public partial class frmUpdateArrayDialog : global::System.Windows.Forms.Form
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
			this.m_lblVarPath = new global::System.Windows.Forms.Label();
			this.m_txtArrayName = new global::System.Windows.Forms.TextBox();
			this.m_grpVectorSettings = new global::System.Windows.Forms.GroupBox();
			this.m_btnArrayPlot = new global::System.Windows.Forms.Button();
			this.m_array_icon = new global::System.Windows.Forms.PictureBox();
			this.m_lblArrayOffset = new global::System.Windows.Forms.Label();
			this.m_txtArrayOffset = new global::System.Windows.Forms.TextBox();
			this.m_lblArrayStride = new global::System.Windows.Forms.Label();
			this.m_txtArrayStride = new global::System.Windows.Forms.TextBox();
			this.m_lblArrayLength = new global::System.Windows.Forms.Label();
			this.m_txtArrayLength = new global::System.Windows.Forms.TextBox();
			this.m_grpVectorDisplay = new global::System.Windows.Forms.GroupBox();
			this.m_btnTransmit = new global::System.Windows.Forms.Button();
			this.m_btnReceive = new global::System.Windows.Forms.Button();
			this.m_dgvArray = new global::System.Windows.Forms.DataGridView();
			this.colIndex = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colValue = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_btnCancel = new global::System.Windows.Forms.Button();
			this.m_btnOK = new global::System.Windows.Forms.Button();
			this.m_grpVectorSettings.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_array_icon).BeginInit();
			this.m_grpVectorDisplay.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvArray).BeginInit();
			base.SuspendLayout();
			this.m_lblVarPath.AutoSize = true;
			this.m_lblVarPath.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblVarPath.Location = new global::System.Drawing.Point(9, 10);
			this.m_lblVarPath.Name = "m_lblVarPath";
			this.m_lblVarPath.Size = new global::System.Drawing.Size(90, 13);
			this.m_lblVarPath.TabIndex = 0;
			this.m_lblVarPath.Text = "Settings for Array:";
			this.m_txtArrayName.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_txtArrayName.Location = new global::System.Drawing.Point(9, 29);
			this.m_txtArrayName.Name = "m_txtArrayName";
			this.m_txtArrayName.ReadOnly = true;
			this.m_txtArrayName.Size = new global::System.Drawing.Size(310, 20);
			this.m_txtArrayName.TabIndex = 1;
			this.m_grpVectorSettings.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_grpVectorSettings.Controls.Add(this.m_btnArrayPlot);
			this.m_grpVectorSettings.Controls.Add(this.m_array_icon);
			this.m_grpVectorSettings.Controls.Add(this.m_lblArrayOffset);
			this.m_grpVectorSettings.Controls.Add(this.m_txtArrayOffset);
			this.m_grpVectorSettings.Controls.Add(this.m_lblArrayStride);
			this.m_grpVectorSettings.Controls.Add(this.m_txtArrayStride);
			this.m_grpVectorSettings.Controls.Add(this.m_lblArrayLength);
			this.m_grpVectorSettings.Controls.Add(this.m_txtArrayLength);
			this.m_grpVectorSettings.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_grpVectorSettings.Location = new global::System.Drawing.Point(11, 60);
			this.m_grpVectorSettings.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_grpVectorSettings.Name = "m_grpVectorSettings";
			this.m_grpVectorSettings.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_grpVectorSettings.Size = new global::System.Drawing.Size(307, 91);
			this.m_grpVectorSettings.TabIndex = 10;
			this.m_grpVectorSettings.TabStop = false;
			this.m_grpVectorSettings.Text = "Vector Settings";
			this.m_btnArrayPlot.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_btnArrayPlot.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnArrayPlot.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_btnArrayPlot.Location = new global::System.Drawing.Point(209, 38);
			this.m_btnArrayPlot.Name = "m_btnArrayPlot";
			this.m_btnArrayPlot.Size = new global::System.Drawing.Size(79, 23);
			this.m_btnArrayPlot.TabIndex = 10;
			this.m_btnArrayPlot.Text = "Plot";
			this.m_btnArrayPlot.UseVisualStyleBackColor = true;
			this.m_btnArrayPlot.Click += new global::System.EventHandler(this.m_btnArrayPlot_Click);
			this.m_array_icon.Location = new global::System.Drawing.Point(16, 32);
			this.m_array_icon.Name = "m_array_icon";
			this.m_array_icon.Size = new global::System.Drawing.Size(32, 37);
			this.m_array_icon.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_array_icon.TabIndex = 9;
			this.m_array_icon.TabStop = false;
			this.m_lblArrayOffset.AutoSize = true;
			this.m_lblArrayOffset.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.m_lblArrayOffset.Location = new global::System.Drawing.Point(69, 20);
			this.m_lblArrayOffset.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblArrayOffset.Name = "m_lblArrayOffset";
			this.m_lblArrayOffset.Size = new global::System.Drawing.Size(38, 13);
			this.m_lblArrayOffset.TabIndex = 8;
			this.m_lblArrayOffset.Text = "Offset:";
			this.m_txtArrayOffset.Location = new global::System.Drawing.Point(124, 17);
			this.m_txtArrayOffset.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_txtArrayOffset.Name = "m_txtArrayOffset";
			this.m_txtArrayOffset.Size = new global::System.Drawing.Size(67, 20);
			this.m_txtArrayOffset.TabIndex = 7;
			this.m_lblArrayStride.AutoSize = true;
			this.m_lblArrayStride.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.m_lblArrayStride.Location = new global::System.Drawing.Point(69, 42);
			this.m_lblArrayStride.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblArrayStride.Name = "m_lblArrayStride";
			this.m_lblArrayStride.Size = new global::System.Drawing.Size(37, 13);
			this.m_lblArrayStride.TabIndex = 4;
			this.m_lblArrayStride.Text = "Stride:";
			this.m_txtArrayStride.Location = new global::System.Drawing.Point(124, 40);
			this.m_txtArrayStride.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_txtArrayStride.Name = "m_txtArrayStride";
			this.m_txtArrayStride.Size = new global::System.Drawing.Size(67, 20);
			this.m_txtArrayStride.TabIndex = 2;
			this.m_lblArrayLength.AutoSize = true;
			this.m_lblArrayLength.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.m_lblArrayLength.Location = new global::System.Drawing.Point(69, 65);
			this.m_lblArrayLength.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblArrayLength.Name = "m_lblArrayLength";
			this.m_lblArrayLength.Size = new global::System.Drawing.Size(43, 13);
			this.m_lblArrayLength.TabIndex = 5;
			this.m_lblArrayLength.Text = "Length:";
			this.m_txtArrayLength.Location = new global::System.Drawing.Point(124, 64);
			this.m_txtArrayLength.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_txtArrayLength.Name = "m_txtArrayLength";
			this.m_txtArrayLength.Size = new global::System.Drawing.Size(67, 20);
			this.m_txtArrayLength.TabIndex = 6;
			this.m_grpVectorDisplay.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_grpVectorDisplay.Controls.Add(this.m_btnTransmit);
			this.m_grpVectorDisplay.Controls.Add(this.m_btnReceive);
			this.m_grpVectorDisplay.Controls.Add(this.m_dgvArray);
			this.m_grpVectorDisplay.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_grpVectorDisplay.Location = new global::System.Drawing.Point(11, 159);
			this.m_grpVectorDisplay.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_grpVectorDisplay.Name = "m_grpVectorDisplay";
			this.m_grpVectorDisplay.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_grpVectorDisplay.Size = new global::System.Drawing.Size(307, 364);
			this.m_grpVectorDisplay.TabIndex = 11;
			this.m_grpVectorDisplay.TabStop = false;
			this.m_grpVectorDisplay.Text = "Array ";
			this.m_btnTransmit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_btnTransmit.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnTransmit.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnTransmit.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_btnTransmit.Location = new global::System.Drawing.Point(153, 327);
			this.m_btnTransmit.Name = "m_btnTransmit";
			this.m_btnTransmit.Size = new global::System.Drawing.Size(79, 23);
			this.m_btnTransmit.TabIndex = 3;
			this.m_btnTransmit.Text = "Transmit";
			this.m_btnTransmit.UseVisualStyleBackColor = false;
			this.m_btnTransmit.Click += new global::System.EventHandler(this.m_btnTransmit_Click);
			this.m_btnReceive.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_btnReceive.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnReceive.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnReceive.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_btnReceive.Location = new global::System.Drawing.Point(66, 327);
			this.m_btnReceive.Name = "m_btnReceive";
			this.m_btnReceive.Size = new global::System.Drawing.Size(79, 23);
			this.m_btnReceive.TabIndex = 2;
			this.m_btnReceive.Text = "Receive";
			this.m_btnReceive.UseVisualStyleBackColor = false;
			this.m_btnReceive.Click += new global::System.EventHandler(this.m_btnReceive_Click);
			this.m_dgvArray.AllowUserToAddRows = false;
			this.m_dgvArray.AllowUserToDeleteRows = false;
			this.m_dgvArray.AllowUserToResizeColumns = false;
			this.m_dgvArray.AllowUserToResizeRows = false;
			this.m_dgvArray.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_dgvArray.BackgroundColor = global::System.Drawing.SystemColors.Window;
			this.m_dgvArray.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dgvArray.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colIndex,
				this.colValue
			});
			this.m_dgvArray.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.m_dgvArray.Location = new global::System.Drawing.Point(50, 18);
			this.m_dgvArray.Name = "m_dgvArray";
			this.m_dgvArray.RowHeadersVisible = false;
			this.m_dgvArray.RowHeadersWidthSizeMode = global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgvArray.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.m_dgvArray.Size = new global::System.Drawing.Size(210, 287);
			this.m_dgvArray.TabIndex = 1;
			this.m_dgvArray.CellMouseUp += new global::System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_ArrayDataGridView_CellMouseUp);
			this.m_dgvArray.CellBeginEdit += new global::System.Windows.Forms.DataGridViewCellCancelEventHandler(this.m_ArrayDataGridView_CellBeginEdit);
			this.m_dgvArray.CellEndEdit += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.m_ArrayDataGridView_CellEndEdit);
			this.colIndex.HeaderText = "Index";
			this.colIndex.MinimumWidth = 40;
			this.colIndex.Name = "colIndex";
			this.colIndex.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.colIndex.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colIndex.Width = 45;
			this.colValue.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colValue.HeaderText = "Value";
			this.colValue.Name = "colValue";
			this.colValue.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colValue.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.m_btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_btnCancel.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnCancel.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnCancel.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_btnCancel.Location = new global::System.Drawing.Point(171, 528);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new global::System.Drawing.Size(72, 24);
			this.m_btnCancel.TabIndex = 12;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = false;
			this.m_btnCancel.Click += new global::System.EventHandler(this.m_btnCancel_Click);
			this.m_btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_btnOK.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnOK.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnOK.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_btnOK.Location = new global::System.Drawing.Point(78, 528);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new global::System.Drawing.Size(74, 24);
			this.m_btnOK.TabIndex = 13;
			this.m_btnOK.Text = "Ok";
			this.m_btnOK.UseVisualStyleBackColor = false;
			this.m_btnOK.Click += new global::System.EventHandler(this.m_btnOK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(328, 564);
			base.Controls.Add(this.m_btnOK);
			base.Controls.Add(this.m_btnCancel);
			base.Controls.Add(this.m_grpVectorDisplay);
			base.Controls.Add(this.m_grpVectorSettings);
			base.Controls.Add(this.m_txtArrayName);
			base.Controls.Add(this.m_lblVarPath);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Location = new global::System.Drawing.Point(11, 64);
			base.MaximizeBox = false;
			base.Name = "frmUpdateArrayDialog";
			this.Text = "Update array dialog";
			this.m_grpVectorSettings.ResumeLayout(false);
			this.m_grpVectorSettings.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_array_icon).EndInit();
			this.m_grpVectorDisplay.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvArray).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Label m_lblVarPath;


		private global::System.Windows.Forms.TextBox m_txtArrayName;


		private global::System.Windows.Forms.GroupBox m_grpVectorSettings;


		private global::System.Windows.Forms.Label m_lblArrayOffset;


		private global::System.Windows.Forms.TextBox m_txtArrayOffset;


		private global::System.Windows.Forms.Label m_lblArrayStride;


		private global::System.Windows.Forms.TextBox m_txtArrayStride;


		private global::System.Windows.Forms.Label m_lblArrayLength;


		private global::System.Windows.Forms.TextBox m_txtArrayLength;


		private global::System.Windows.Forms.GroupBox m_grpVectorDisplay;


		private global::System.Windows.Forms.Button m_btnCancel;


		private global::System.Windows.Forms.Button m_btnOK;


		private global::System.Windows.Forms.DataGridView m_dgvArray;


		private global::System.Windows.Forms.Button m_btnTransmit;


		private global::System.Windows.Forms.Button m_btnReceive;


		private global::System.Windows.Forms.PictureBox m_array_icon;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colIndex;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colValue;


		private global::System.Windows.Forms.Button m_btnArrayPlot;
	}
}
