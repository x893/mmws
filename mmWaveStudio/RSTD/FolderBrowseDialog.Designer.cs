namespace RSTD
{

	public partial class FolderBrowseDialog : global::System.Windows.Forms.Form
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
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.FolderBrowseDialog));
			this.m_FolderTreeView = new global::System.Windows.Forms.TreeView();
			this.m_ImageList = new global::System.Windows.Forms.ImageList(this.components);
			this.m_OkButton = new global::System.Windows.Forms.Button();
			this.m_CancelButton = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.m_FolderTreeView.CheckBoxes = true;
			this.m_FolderTreeView.ImageIndex = 0;
			this.m_FolderTreeView.ImageList = this.m_ImageList;
			this.m_FolderTreeView.Location = new global::System.Drawing.Point(0, -1);
			this.m_FolderTreeView.Name = "m_FolderTreeView";
			this.m_FolderTreeView.SelectedImageIndex = 0;
			this.m_FolderTreeView.Size = new global::System.Drawing.Size(310, 248);
			this.m_FolderTreeView.TabIndex = 1;
			this.m_FolderTreeView.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.m_FolderTreeView_AfterCheck);
			this.m_FolderTreeView.BeforeExpand += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.m_FolderTreeView_BeforeExpand);
			this.m_ImageList.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resources.GetObject("m_ImageList.ImageStream");
			this.m_ImageList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.m_ImageList.Images.SetKeyName(0, "Hard-Drive.png");
			this.m_ImageList.Images.SetKeyName(1, "Folder.png");
			this.m_ImageList.Images.SetKeyName(2, "CdRom.png");
			this.m_ImageList.Images.SetKeyName(3, "Removable-Drive.png");
			this.m_ImageList.Images.SetKeyName(4, "Network-Drive.png");
			this.m_ImageList.Images.SetKeyName(5, "Lock.png");
			this.m_OkButton.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.m_OkButton.Location = new global::System.Drawing.Point(62, 16);
			this.m_OkButton.Name = "m_OkButton";
			this.m_OkButton.Size = new global::System.Drawing.Size(73, 23);
			this.m_OkButton.TabIndex = 1;
			this.m_OkButton.Text = "Ok";
			this.m_OkButton.UseVisualStyleBackColor = true;
			this.m_OkButton.Click += new global::System.EventHandler(this.m_OkButton_Click);
			this.m_CancelButton.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.m_CancelButton.Location = new global::System.Drawing.Point(166, 16);
			this.m_CancelButton.Name = "m_CancelButton";
			this.m_CancelButton.Size = new global::System.Drawing.Size(78, 23);
			this.m_CancelButton.TabIndex = 2;
			this.m_CancelButton.Text = "Cancel";
			this.m_CancelButton.UseVisualStyleBackColor = true;
			this.m_CancelButton.Click += new global::System.EventHandler(this.m_CancelButton_Click);
			this.panel1.Controls.Add(this.m_OkButton);
			this.panel1.Controls.Add(this.m_CancelButton);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 253);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(310, 51);
			this.panel1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(310, 304);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.m_FolderTreeView);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FolderBrowseDialog";
			this.Text = "FolderBrowse";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.TreeView m_FolderTreeView;
		private global::System.Windows.Forms.Button m_OkButton;
		private global::System.Windows.Forms.Button m_CancelButton;
		private global::System.Windows.Forms.Panel panel1;
		private global::System.Windows.Forms.ImageList m_ImageList;
	}
}
