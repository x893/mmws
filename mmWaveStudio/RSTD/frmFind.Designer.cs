namespace RSTD
{

	public partial class frmFind : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmFind));
			this.m_BaseSearchPathLabel = new global::System.Windows.Forms.Label();
			this.m_BasePathComboBox = new global::System.Windows.Forms.ComboBox();
			this.m_IsRecursiveCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_SearchForLabel = new global::System.Windows.Forms.Label();
			this.m_SearchForComboBox = new global::System.Windows.Forms.ComboBox();
			this.m_NameCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_ValueCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_CommentCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_ResultsGroupBox = new global::System.Windows.Forms.GroupBox();
			this.m_ResultsListView = new global::System.Windows.Forms.ListView();
			this.PathCol = new global::System.Windows.Forms.ColumnHeader();
			this.NameCol = new global::System.Windows.Forms.ColumnHeader();
			this.TypeCol = new global::System.Windows.Forms.ColumnHeader();
			this.ValueCol = new global::System.Windows.Forms.ColumnHeader();
			this.FixmodeCol = new global::System.Windows.Forms.ColumnHeader();
			this.CommentCol = new global::System.Windows.Forms.ColumnHeader();
			this.RoCol = new global::System.Windows.Forms.ColumnHeader();
			this.AddressCol = new global::System.Windows.Forms.ColumnHeader();
			this.DescCol = new global::System.Windows.Forms.ColumnHeader();
			this.m_FindBtn = new global::System.Windows.Forms.Button();
			this.m_MatchWholeWordCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_CaseSensitiveCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_AdvancedLabel = new global::System.Windows.Forms.Label();
			this.m_chkRegularExpression = new global::System.Windows.Forms.CheckBox();
			this.m_TypeCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_AddressCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_DescriptionCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_btn_ClearHistory = new global::System.Windows.Forms.Button();
			this.m_BottomToolStrip = new global::RSTD.ToolStripEx();
			this.m_SaveSplitBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.m_SaveSplitBtnSelectionMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_SaveSplitBtnAllMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_ResultsGroupBox.SuspendLayout();
			this.m_BottomToolStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_BaseSearchPathLabel.AutoSize = true;
			this.m_BaseSearchPathLabel.Location = new global::System.Drawing.Point(9, 18);
			this.m_BaseSearchPathLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_BaseSearchPathLabel.Name = "m_BaseSearchPathLabel";
			this.m_BaseSearchPathLabel.Size = new global::System.Drawing.Size(93, 13);
			this.m_BaseSearchPathLabel.TabIndex = 0;
			this.m_BaseSearchPathLabel.Text = "Base search path:";
			this.m_BasePathComboBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_BasePathComboBox.FormattingEnabled = true;
			this.m_BasePathComboBox.Location = new global::System.Drawing.Point(106, 18);
			this.m_BasePathComboBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_BasePathComboBox.Name = "m_BasePathComboBox";
			this.m_BasePathComboBox.Size = new global::System.Drawing.Size(592, 21);
			this.m_BasePathComboBox.TabIndex = 1;
			this.m_BasePathComboBox.Text = "/";
			this.m_BasePathComboBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_BasePathComboBox_KeyDown);
			this.m_IsRecursiveCheckBox.AutoSize = true;
			this.m_IsRecursiveCheckBox.Checked = true;
			this.m_IsRecursiveCheckBox.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.m_IsRecursiveCheckBox.Enabled = false;
			this.m_IsRecursiveCheckBox.Location = new global::System.Drawing.Point(106, 42);
			this.m_IsRecursiveCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_IsRecursiveCheckBox.Name = "m_IsRecursiveCheckBox";
			this.m_IsRecursiveCheckBox.Size = new global::System.Drawing.Size(114, 17);
			this.m_IsRecursiveCheckBox.TabIndex = 2;
			this.m_IsRecursiveCheckBox.Text = "Search sub-folders";
			this.m_IsRecursiveCheckBox.UseVisualStyleBackColor = true;
			this.m_SearchForLabel.AutoSize = true;
			this.m_SearchForLabel.Location = new global::System.Drawing.Point(11, 69);
			this.m_SearchForLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_SearchForLabel.Name = "m_SearchForLabel";
			this.m_SearchForLabel.Size = new global::System.Drawing.Size(62, 13);
			this.m_SearchForLabel.TabIndex = 3;
			this.m_SearchForLabel.Text = "Search For:";
			this.m_SearchForComboBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_SearchForComboBox.FormattingEnabled = true;
			this.m_SearchForComboBox.Location = new global::System.Drawing.Point(106, 69);
			this.m_SearchForComboBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_SearchForComboBox.Name = "m_SearchForComboBox";
			this.m_SearchForComboBox.Size = new global::System.Drawing.Size(592, 21);
			this.m_SearchForComboBox.TabIndex = 4;
			this.m_SearchForComboBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_SearchForComboBox_KeyDown);
			this.m_NameCheckBox.AutoSize = true;
			this.m_NameCheckBox.Checked = true;
			this.m_NameCheckBox.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.m_NameCheckBox.Location = new global::System.Drawing.Point(106, 94);
			this.m_NameCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_NameCheckBox.Name = "m_NameCheckBox";
			this.m_NameCheckBox.Size = new global::System.Drawing.Size(54, 17);
			this.m_NameCheckBox.TabIndex = 5;
			this.m_NameCheckBox.Text = "Name";
			this.m_NameCheckBox.UseVisualStyleBackColor = true;
			this.m_ValueCheckBox.AutoSize = true;
			this.m_ValueCheckBox.Location = new global::System.Drawing.Point(106, 116);
			this.m_ValueCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_ValueCheckBox.Name = "m_ValueCheckBox";
			this.m_ValueCheckBox.Size = new global::System.Drawing.Size(53, 17);
			this.m_ValueCheckBox.TabIndex = 6;
			this.m_ValueCheckBox.Text = "Value";
			this.m_ValueCheckBox.UseVisualStyleBackColor = true;
			this.m_CommentCheckBox.AutoSize = true;
			this.m_CommentCheckBox.Location = new global::System.Drawing.Point(106, 138);
			this.m_CommentCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_CommentCheckBox.Name = "m_CommentCheckBox";
			this.m_CommentCheckBox.Size = new global::System.Drawing.Size(70, 17);
			this.m_CommentCheckBox.TabIndex = 7;
			this.m_CommentCheckBox.Text = "Comment";
			this.m_CommentCheckBox.UseVisualStyleBackColor = true;
			this.m_ResultsGroupBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ResultsGroupBox.Controls.Add(this.m_ResultsListView);
			this.m_ResultsGroupBox.Location = new global::System.Drawing.Point(10, 204);
			this.m_ResultsGroupBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_ResultsGroupBox.Name = "m_ResultsGroupBox";
			this.m_ResultsGroupBox.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_ResultsGroupBox.Size = new global::System.Drawing.Size(687, 262);
			this.m_ResultsGroupBox.TabIndex = 8;
			this.m_ResultsGroupBox.TabStop = false;
			this.m_ResultsGroupBox.Text = "Results:";
			this.m_ResultsListView.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ResultsListView.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.PathCol,
				this.NameCol,
				this.TypeCol,
				this.ValueCol,
				this.FixmodeCol,
				this.CommentCol,
				this.RoCol,
				this.AddressCol,
				this.DescCol
			});
			this.m_ResultsListView.FullRowSelect = true;
			this.m_ResultsListView.HideSelection = false;
			this.m_ResultsListView.Location = new global::System.Drawing.Point(5, 18);
			this.m_ResultsListView.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_ResultsListView.Name = "m_ResultsListView";
			this.m_ResultsListView.Size = new global::System.Drawing.Size(678, 240);
			this.m_ResultsListView.TabIndex = 0;
			this.m_ResultsListView.UseCompatibleStateImageBehavior = false;
			this.m_ResultsListView.View = global::System.Windows.Forms.View.Details;
			this.m_ResultsListView.DoubleClick += new global::System.EventHandler(this.m_ResultsListView_DoubleClick);
			this.PathCol.Text = "Path";
			this.PathCol.Width = 262;
			this.NameCol.Text = "Name";
			this.NameCol.Width = 188;
			this.TypeCol.Text = "Type";
			this.TypeCol.Width = 90;
			this.ValueCol.Text = "Value";
			this.ValueCol.Width = 115;
			this.FixmodeCol.Text = "Fixmode";
			this.FixmodeCol.Width = 100;
			this.CommentCol.Text = "Comment";
			this.CommentCol.Width = 104;
			this.RoCol.Text = "RO";
			this.RoCol.Width = 42;
			this.AddressCol.Text = "Address";
			this.AddressCol.Width = 100;
			this.DescCol.Text = "Description";
			this.m_FindBtn.Font = new global::System.Drawing.Font("Times New Roman", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 178);
			this.m_FindBtn.ForeColor = global::System.Drawing.Color.Navy;
			this.m_FindBtn.Location = new global::System.Drawing.Point(475, 118);
			this.m_FindBtn.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_FindBtn.Name = "m_FindBtn";
			this.m_FindBtn.Size = new global::System.Drawing.Size(92, 37);
			this.m_FindBtn.TabIndex = 9;
			this.m_FindBtn.Text = "Find!";
			this.m_FindBtn.UseVisualStyleBackColor = true;
			this.m_FindBtn.Click += new global::System.EventHandler(this.m_FindBtn_Click);
			this.m_MatchWholeWordCheckBox.AutoSize = true;
			this.m_MatchWholeWordCheckBox.Location = new global::System.Drawing.Point(106, 182);
			this.m_MatchWholeWordCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_MatchWholeWordCheckBox.Name = "m_MatchWholeWordCheckBox";
			this.m_MatchWholeWordCheckBox.Size = new global::System.Drawing.Size(135, 17);
			this.m_MatchWholeWordCheckBox.TabIndex = 13;
			this.m_MatchWholeWordCheckBox.Text = "Match whole word only";
			this.m_MatchWholeWordCheckBox.UseVisualStyleBackColor = true;
			this.m_CaseSensitiveCheckBox.AutoSize = true;
			this.m_CaseSensitiveCheckBox.Location = new global::System.Drawing.Point(106, 160);
			this.m_CaseSensitiveCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_CaseSensitiveCheckBox.Name = "m_CaseSensitiveCheckBox";
			this.m_CaseSensitiveCheckBox.Size = new global::System.Drawing.Size(94, 17);
			this.m_CaseSensitiveCheckBox.TabIndex = 12;
			this.m_CaseSensitiveCheckBox.Text = "Case sensitive";
			this.m_CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
			this.m_AdvancedLabel.AutoSize = true;
			this.m_AdvancedLabel.Location = new global::System.Drawing.Point(11, 160);
			this.m_AdvancedLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_AdvancedLabel.Name = "m_AdvancedLabel";
			this.m_AdvancedLabel.Size = new global::System.Drawing.Size(59, 13);
			this.m_AdvancedLabel.TabIndex = 10;
			this.m_AdvancedLabel.Text = "Advanced:";
			this.m_chkRegularExpression.AutoSize = true;
			this.m_chkRegularExpression.Location = new global::System.Drawing.Point(267, 160);
			this.m_chkRegularExpression.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_chkRegularExpression.Name = "m_chkRegularExpression";
			this.m_chkRegularExpression.Size = new global::System.Drawing.Size(117, 17);
			this.m_chkRegularExpression.TabIndex = 15;
			this.m_chkRegularExpression.Text = "Regular Expression";
			this.m_chkRegularExpression.UseVisualStyleBackColor = true;
			this.m_TypeCheckBox.AutoSize = true;
			this.m_TypeCheckBox.Location = new global::System.Drawing.Point(267, 94);
			this.m_TypeCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_TypeCheckBox.Name = "m_TypeCheckBox";
			this.m_TypeCheckBox.Size = new global::System.Drawing.Size(50, 17);
			this.m_TypeCheckBox.TabIndex = 16;
			this.m_TypeCheckBox.Text = "Type";
			this.m_TypeCheckBox.UseVisualStyleBackColor = true;
			this.m_AddressCheckBox.AutoSize = true;
			this.m_AddressCheckBox.Location = new global::System.Drawing.Point(267, 115);
			this.m_AddressCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_AddressCheckBox.Name = "m_AddressCheckBox";
			this.m_AddressCheckBox.Size = new global::System.Drawing.Size(64, 17);
			this.m_AddressCheckBox.TabIndex = 17;
			this.m_AddressCheckBox.Text = "Address";
			this.m_AddressCheckBox.UseVisualStyleBackColor = true;
			this.m_DescriptionCheckBox.AutoSize = true;
			this.m_DescriptionCheckBox.Location = new global::System.Drawing.Point(267, 136);
			this.m_DescriptionCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_DescriptionCheckBox.Name = "m_DescriptionCheckBox";
			this.m_DescriptionCheckBox.Size = new global::System.Drawing.Size(79, 17);
			this.m_DescriptionCheckBox.TabIndex = 18;
			this.m_DescriptionCheckBox.Text = "Description";
			this.m_DescriptionCheckBox.UseVisualStyleBackColor = true;
			this.m_btn_ClearHistory.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_btn_ClearHistory.Location = new global::System.Drawing.Point(582, 95);
			this.m_btn_ClearHistory.Name = "m_btn_ClearHistory";
			this.m_btn_ClearHistory.Size = new global::System.Drawing.Size(111, 23);
			this.m_btn_ClearHistory.TabIndex = 19;
			this.m_btn_ClearHistory.Text = "Clear Find History";
			this.m_btn_ClearHistory.UseVisualStyleBackColor = true;
			this.m_btn_ClearHistory.Click += new global::System.EventHandler(this.ibtn_ClearHistory_Click);
			this.m_BottomToolStrip.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.m_BottomToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_BottomToolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_SaveSplitBtn
			});
			this.m_BottomToolStrip.Location = new global::System.Drawing.Point(0, 464);
			this.m_BottomToolStrip.Name = "m_BottomToolStrip";
			this.m_BottomToolStrip.Size = new global::System.Drawing.Size(706, 27);
			this.m_BottomToolStrip.TabIndex = 14;
			this.m_BottomToolStrip.Text = "toolStrip1";
			this.m_SaveSplitBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_SaveSplitBtnSelectionMenuItem,
				this.m_SaveSplitBtnAllMenuItem
			});
			this.m_SaveSplitBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_SaveSplitBtn.Image");
			this.m_SaveSplitBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_SaveSplitBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SaveSplitBtn.Name = "m_SaveSplitBtn";
			this.m_SaveSplitBtn.Size = new global::System.Drawing.Size(67, 24);
			this.m_SaveSplitBtn.Text = "Save";
			this.m_SaveSplitBtn.ButtonClick += new global::System.EventHandler(this.m_SaveSplitBtn_ButtonClick);
			this.m_SaveSplitBtnSelectionMenuItem.Name = "m_SaveSplitBtnSelectionMenuItem";
			this.m_SaveSplitBtnSelectionMenuItem.Size = new global::System.Drawing.Size(117, 22);
			this.m_SaveSplitBtnSelectionMenuItem.Text = "Selection";
			this.m_SaveSplitBtnSelectionMenuItem.Click += new global::System.EventHandler(this.m_SaveSplitBtnSelectionMenuItem_Click);
			this.m_SaveSplitBtnAllMenuItem.Name = "m_SaveSplitBtnAllMenuItem";
			this.m_SaveSplitBtnAllMenuItem.Size = new global::System.Drawing.Size(117, 22);
			this.m_SaveSplitBtnAllMenuItem.Text = "All";
			this.m_SaveSplitBtnAllMenuItem.Click += new global::System.EventHandler(this.m_SaveSplitBtnAllMenuItem_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(706, 491);
			base.Controls.Add(this.m_btn_ClearHistory);
			base.Controls.Add(this.m_DescriptionCheckBox);
			base.Controls.Add(this.m_AddressCheckBox);
			base.Controls.Add(this.m_TypeCheckBox);
			base.Controls.Add(this.m_chkRegularExpression);
			base.Controls.Add(this.m_BottomToolStrip);
			base.Controls.Add(this.m_MatchWholeWordCheckBox);
			base.Controls.Add(this.m_CaseSensitiveCheckBox);
			base.Controls.Add(this.m_AdvancedLabel);
			base.Controls.Add(this.m_FindBtn);
			base.Controls.Add(this.m_ResultsGroupBox);
			base.Controls.Add(this.m_CommentCheckBox);
			base.Controls.Add(this.m_ValueCheckBox);
			base.Controls.Add(this.m_NameCheckBox);
			base.Controls.Add(this.m_SearchForComboBox);
			base.Controls.Add(this.m_SearchForLabel);
			base.Controls.Add(this.m_IsRecursiveCheckBox);
			base.Controls.Add(this.m_BasePathComboBox);
			base.Controls.Add(this.m_BaseSearchPathLabel);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			this.MinimumSize = new global::System.Drawing.Size(500, 300);
			base.Name = "frmFind";
			base.TabText = "Find";
			this.Text = "Find";
			this.m_ResultsGroupBox.ResumeLayout(false);
			this.m_BottomToolStrip.ResumeLayout(false);
			this.m_BottomToolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Label m_BaseSearchPathLabel;


		private global::System.Windows.Forms.ComboBox m_BasePathComboBox;


		private global::System.Windows.Forms.CheckBox m_IsRecursiveCheckBox;


		private global::System.Windows.Forms.Label m_SearchForLabel;


		private global::System.Windows.Forms.ComboBox m_SearchForComboBox;


		private global::System.Windows.Forms.CheckBox m_NameCheckBox;


		private global::System.Windows.Forms.CheckBox m_ValueCheckBox;


		private global::System.Windows.Forms.CheckBox m_CommentCheckBox;


		private global::System.Windows.Forms.GroupBox m_ResultsGroupBox;


		private global::System.Windows.Forms.ListView m_ResultsListView;


		private global::System.Windows.Forms.Button m_FindBtn;


		private global::System.Windows.Forms.ColumnHeader NameCol;


		private global::System.Windows.Forms.ColumnHeader TypeCol;


		private global::System.Windows.Forms.ColumnHeader ValueCol;


		private global::System.Windows.Forms.ColumnHeader RoCol;


		private global::System.Windows.Forms.ColumnHeader CommentCol;


		private global::System.Windows.Forms.ColumnHeader PathCol;


		private global::System.Windows.Forms.CheckBox m_MatchWholeWordCheckBox;


		private global::System.Windows.Forms.CheckBox m_CaseSensitiveCheckBox;


		private global::System.Windows.Forms.Label m_AdvancedLabel;


		private global::RSTD.ToolStripEx m_BottomToolStrip;


		private global::System.Windows.Forms.ToolStripSplitButton m_SaveSplitBtn;


		private global::System.Windows.Forms.ToolStripMenuItem m_SaveSplitBtnSelectionMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem m_SaveSplitBtnAllMenuItem;


		private global::System.Windows.Forms.CheckBox m_chkRegularExpression;


		private global::System.Windows.Forms.ColumnHeader FixmodeCol;


		private global::System.Windows.Forms.CheckBox m_TypeCheckBox;


		private global::System.Windows.Forms.CheckBox m_AddressCheckBox;


		private global::System.Windows.Forms.ColumnHeader AddressCol;


		private global::System.Windows.Forms.CheckBox m_DescriptionCheckBox;


		private global::System.Windows.Forms.ColumnHeader DescCol;


		private global::System.Windows.Forms.Button m_btn_ClearHistory;
	}
}
