using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using RSTD.Properties;

namespace RSTD
{

	public partial class SettingsForm : Form
	{

		public SettingsForm()
		{
			this.InitializeComponent();
			this.m_TabControl.TabPages.Remove(this.tpCom);
			if (File.Exists(this.iGetSettingsFileName_FullPath()))
			{
				this.LoadConfig(this.iGetSettingsFileName_FullPath());
				if (Program.ClientDll != null)
				{
					this.iSetCmdLineDll();
					return;
				}
			}
			else if (Program.OwningUser != null)
			{
				this.LoadConfig(this.iGetSettingsFileName_default());
				if (Program.ClientDll != null)
				{
					this.iSetCmdLineDll();
				}
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Output path must be changed for this user to prevent collision with default user.");
				this.m_TabControl.SelectedIndex = 1;
				base.ShowDialog();
			}
		}


		public void LoadConfig(string fileName)
		{
			if (File.Exists(fileName) && this.ibReadXmlConfigFile(fileName))
			{
				GuiCore.ConfigSettings(fileName);
			}
		}


		public void SaveConfig(string fileName)
		{
			this.iWriteXmlConfigFile(fileName);
			GuiCore.ConfigSettings(fileName);
		}


		public string GetInputPath()
		{
			return this.m_InputPathComboBox.Text;
		}


		public string GetConfigPath()
		{
			return this.m_ConfigPathComboBox.Text;
		}


		public string GetOutputPath()
		{
			return this.m_OutputPathComboBox.Text;
		}


		public bool bIsVerbose()
		{
			return this.m_ScripterVerboseModeCheckBox.Checked;
		}


		public bool bHasClients()
		{
			for (int i = 0; i < this.dgvClientDlls.Rows.Count - 1; i++)
			{
				if (this.dgvClientDlls.Rows[i].Cells[this.colUseClient.Index] != null && this.dgvClientDlls.Rows[i].Cells[this.colPriority.Index] != null && this.dgvClientDlls.Rows[i].Cells[this.colClientDll.Index] != null && this.dgvClientDlls.Rows[i].Cells[this.colUseClient.Index].Value != null && this.dgvClientDlls.Rows[i].Cells[this.colPriority.Index].Value != null && this.dgvClientDlls.Rows[i].Cells[this.colClientDll.Index].Value != null)
				{
					string value = this.dgvClientDlls.Rows[i].Cells[this.colUseClient.Index].Value.ToString();
					this.dgvClientDlls.Rows[i].Cells[this.colPriority.Index].Value.ToString();
					this.dgvClientDlls.Rows[i].Cells[this.colClientDll.Index].Value.ToString();
					if (bool.Parse(value))
					{
						return true;
					}
				}
			}
			return false;
		}


		private void m_InputPathBrowseBtn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Input path:";
			if (Directory.Exists(this.m_InputPathComboBox.Text))
			{
				folderBrowserDialog.SelectedPath = this.m_InputPathComboBox.Text;
			}
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				this.m_InputPathComboBox.Items.Insert(0, folderBrowserDialog.SelectedPath);
				this.m_InputPathComboBox.Text = (string)this.m_InputPathComboBox.Items[0];
			}
			if (folderBrowserDialog != null)
			{
			}
		}


		private void m_OutputPathBrowseBtn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Output path:";
			if (Directory.Exists(this.m_OutputPathComboBox.Text))
			{
				folderBrowserDialog.SelectedPath = this.m_OutputPathComboBox.Text;
			}
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				this.m_OutputPathComboBox.Items.Insert(0, folderBrowserDialog.SelectedPath);
				this.m_OutputPathComboBox.Text = (string)this.m_OutputPathComboBox.Items[0];
			}
			if (folderBrowserDialog != null)
			{
			}
		}


		private void m_ConfigPathBrowseBtn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Config path:";
			if (Directory.Exists(this.m_ConfigPathComboBox.Text))
			{
				folderBrowserDialog.SelectedPath = this.m_ConfigPathComboBox.Text;
			}
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				this.m_ConfigPathComboBox.Items.Insert(0, folderBrowserDialog.SelectedPath);
				this.m_ConfigPathComboBox.Text = (string)this.m_ConfigPathComboBox.Items[0];
			}
			if (folderBrowserDialog != null)
			{
			}
		}


		private void dgvClientDlls_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex.Equals(this.colBrowseClientDll.Index))
			{
				string text = this.iDllLoadDialog(Settings.Default.LastDllPath);
				if (!string.IsNullOrEmpty(text))
				{
					Settings.Default.LastDllPath = Path.GetDirectoryName(text);
					Settings.Default.Save();
					this.dgvClientDlls[this.colClientDll.Index, e.RowIndex].Value = text;
					return;
				}
			}
			else if (e.ColumnIndex.Equals(this.colBrowseClientXml.Index))
			{
				string value = this.iXmlLoadDialog();
				if (!string.IsNullOrEmpty(value))
				{
					this.dgvClientDlls[this.colClientXml.Index, e.RowIndex].Value = value;
				}
			}
		}


		private void dgvComDlls_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex.Equals(this.colBrowseComDll.Index))
			{
				string value = this.iDllLoadDialog(Settings.Default.LastDllPath);
				if (!string.IsNullOrEmpty(value))
				{
					this.dgvComDlls[this.colComDll.Index, e.RowIndex].Value = value;
					return;
				}
			}
			else if (e.ColumnIndex.Equals(this.colBrowseComXml.Index))
			{
				string value2 = this.iXmlLoadDialog();
				if (!string.IsNullOrEmpty(value2))
				{
					this.dgvComDlls[this.colComXml.Index, e.RowIndex].Value = value2;
				}
			}
		}


		private void m_BottomToolStripOkBtn_Click(object sender, EventArgs e)
		{
			this.SaveConfig(this.iGetSettingsFileName_FullPath());
			base.Close();
		}


		private void m_BottomToolStripCancelBtn_Click(object sender, EventArgs e)
		{
			if (this.ibReadXmlConfigFile(this.iGetSettingsFileName_FullPath()))
			{
				GuiCore.ConfigSettings(this.iGetSettingsFileName_FullPath());
			}
			base.Close();
		}


		private void m_SaveBtn_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save an XML settings file";
			saveFileDialog.Filter = "XML settings files (*.xml)|*.xml";
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				this.SaveConfig(saveFileDialog.FileName);
			}
		}


		private void m_LoadBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open an XML settings file";
			openFileDialog.Filter = "XML settings files (*.xml)|*.xml";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(openFileDialog.FileName))
			{
				this.LoadConfig(openFileDialog.FileName);
			}
		}


		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.m_BottomToolStrip.Focus();
			this.ibReadXmlConfigFile(this.iGetSettingsFileName_FullPath());
		}


		private string iGetSettingsFileName_FullPath()
		{
			string text = "config";
			if (Program.OwningUser != null)
			{
				text = text + "_" + Environment.UserName;
			}
			return GuiCore.MainForm.SettingsOutputPath + Path.DirectorySeparatorChar.ToString() + text + ".xml";
		}


		private string iGetSettingsFileName_default()
		{
			return GuiCore.MainForm.SettingsOutputPath + Path.DirectorySeparatorChar.ToString() + "config.xml";
		}


		private void iReadClients(XmlNode xmlSection)
		{
			int num = 0;
			this.dgvClientDlls.Rows.Clear();
			for (int i = 0; i < xmlSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xmlSection.ChildNodes[i];
				if (!xmlNode.Name.Equals("Client"))
				{
					throw new Exception(string.Format("Illegal node {0} within Clients section.", xmlNode.Name));
				}
				if (num == 5)
				{
					throw new Exception("Invalid Settings file config.xml - too many clients.");
				}
				this.dgvClientDlls.Rows.Add();
				if (xmlNode.Attributes.Count < 2)
				{
					throw new Exception("XML Config:: Must have at least 2 attribute per Client: Use & Priority");
				}
				this.dgvClientDlls.Rows[num].Cells[this.colUseClient.Index].Value = bool.Parse(xmlNode.Attributes["Use"].Value);
				this.dgvClientDlls.Rows[num].Cells[this.colPriority.Index].Value = xmlNode.Attributes["Priority"].Value;
				if (xmlNode.Attributes["DefaultXml"] != null)
				{
					this.dgvClientDlls.Rows[num].Cells[this.colClientXml.Index].Value = xmlNode.Attributes["DefaultXml"].Value;
				}
				this.dgvClientDlls.Rows[num].Cells[this.colClientDll.Index].Value = xmlNode.FirstChild.Value;
				num++;
			}
		}


		private void iReadComs(XmlNode xmlSection)
		{
			int num = 0;
			this.dgvComDlls.Rows.Clear();
			for (int i = 0; i < xmlSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xmlSection.ChildNodes[i];
				if (!xmlNode.Name.Equals("Communication"))
				{
					throw new Exception(string.Format("Illegal node {0} within Communication section.", xmlNode.Name));
				}
				this.dgvComDlls.Rows.Add();
				if (xmlNode.Attributes.Count < 1)
				{
					throw new Exception("XML Config:: Must have at least 1 attribute per Communication: Use");
				}
				this.dgvComDlls.Rows[num].Cells[this.colUseCom.Index].Value = bool.Parse(xmlNode.Attributes["Use"].Value);
				if (xmlNode.Attributes["DefaultXml"] != null)
				{
					this.dgvComDlls.Rows[num].Cells[this.colComXml.Index].Value = xmlNode.Attributes["DefaultXml"].Value;
				}
				this.dgvComDlls.Rows[num].Cells[this.colComDll.Index].Value = xmlNode.FirstChild.Value;
				num++;
			}
		}


		private void iReadPaths(XmlNode xmlSection)
		{
			for (int i = 0; i < xmlSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xmlSection.ChildNodes[i];
				if (xmlNode.FirstChild != null)
				{
					if (xmlNode.Name.Equals("Input"))
					{
						this.m_InputPathComboBox.Text = xmlNode.FirstChild.Value;
					}
					else if (xmlNode.Name.Equals("Config"))
					{
						this.m_ConfigPathComboBox.Text = xmlNode.FirstChild.Value;
					}
					else
					{
						if (!xmlNode.Name.Equals("Output"))
						{
							throw new Exception(string.Format("Illegal node {0} within Paths section.", xmlNode.Name));
						}
						this.m_OutputPathComboBox.Text = xmlNode.FirstChild.Value;
					}
				}
			}
		}


		private void iReadScripter(XmlNode xmlSection)
		{
			for (int i = 0; i < xmlSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xmlSection.ChildNodes[i];
				if (!xmlNode.Name.Equals("VerboseMode"))
				{
					throw new Exception(string.Format("Illegal node {0} within Scripter section.", xmlNode.Name));
				}
				this.m_ScripterVerboseModeCheckBox.Checked = bool.Parse(xmlNode.FirstChild.Value);
			}
		}


		private void iWriteClients(ref XmlTextWriter rXmlTxtWriter)
		{
			string value = string.Empty;
			rXmlTxtWriter.WriteStartElement("Clients");
			this.dgvClientDlls.EndEdit();
			foreach (object obj in ((IEnumerable)this.dgvClientDlls.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (!dataGridViewRow.IsNewRow && dataGridViewRow.Cells[this.colClientDll.Index].Value != null)
				{
					if (dataGridViewRow.Cells[this.colUseClient.Index].Value == null)
					{
						dataGridViewRow.Cells[this.colUseClient.Index].Value = false;
					}
					if (dataGridViewRow.Cells[this.colPriority.Index].Value == null)
					{
						dataGridViewRow.Cells[this.colPriority.Index].Value = "NORMAL";
					}
					string value2 = dataGridViewRow.Cells[this.colUseClient.Index].Value.ToString();
					string value3 = dataGridViewRow.Cells[this.colPriority.Index].Value.ToString();
					string text = dataGridViewRow.Cells[this.colClientDll.Index].Value.ToString();
					if (dataGridViewRow.Cells[this.colClientXml.Index].Value != null)
					{
						value = dataGridViewRow.Cells[this.colClientXml.Index].Value.ToString();
					}
					rXmlTxtWriter.WriteStartElement("Client");
					rXmlTxtWriter.WriteAttributeString("Use", value2);
					rXmlTxtWriter.WriteAttributeString("Priority", value3);
					rXmlTxtWriter.WriteAttributeString("DefaultXml", value);
					rXmlTxtWriter.WriteString(text);
					rXmlTxtWriter.WriteEndElement();
				}
			}
			rXmlTxtWriter.WriteEndElement();
		}


		private void iWriteComs(ref XmlTextWriter rXmlTxtWriter)
		{
			string value = string.Empty;
			rXmlTxtWriter.WriteStartElement("Communications");
			this.dgvComDlls.EndEdit();
			foreach (object obj in ((IEnumerable)this.dgvComDlls.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (!dataGridViewRow.IsNewRow && dataGridViewRow.Cells[this.colComDll.Index].Value != null)
				{
					if (dataGridViewRow.Cells[this.colUseCom.Index].Value == null)
					{
						dataGridViewRow.Cells[this.colUseCom.Index].Value = false;
					}
					string value2 = dataGridViewRow.Cells[this.colUseCom.Index].Value.ToString();
					string text = dataGridViewRow.Cells[this.colComDll.Index].Value.ToString();
					if (dataGridViewRow.Cells[this.colComXml.Index].Value != null)
					{
						value = dataGridViewRow.Cells[this.colComXml.Index].Value.ToString();
					}
					rXmlTxtWriter.WriteStartElement("Communication");
					rXmlTxtWriter.WriteAttributeString("Use", value2);
					rXmlTxtWriter.WriteAttributeString("DefaultXml", value);
					rXmlTxtWriter.WriteString(text);
					rXmlTxtWriter.WriteEndElement();
				}
			}
			rXmlTxtWriter.WriteEndElement();
		}


		private void iWritePaths(ref XmlTextWriter rXmlTxtWriter)
		{
			rXmlTxtWriter.WriteStartElement("Paths");
			rXmlTxtWriter.WriteStartElement("Input");
			rXmlTxtWriter.WriteString(this.m_InputPathComboBox.Text);
			rXmlTxtWriter.WriteEndElement();
			rXmlTxtWriter.WriteStartElement("Config");
			rXmlTxtWriter.WriteString(this.m_ConfigPathComboBox.Text);
			rXmlTxtWriter.WriteEndElement();
			rXmlTxtWriter.WriteStartElement("Output");
			rXmlTxtWriter.WriteString(this.m_OutputPathComboBox.Text);
			rXmlTxtWriter.WriteEndElement();
			rXmlTxtWriter.WriteEndElement();
		}


		private void iWriteScripter(ref XmlTextWriter rXmlTxtWriter)
		{
			rXmlTxtWriter.WriteStartElement("Scripter");
			rXmlTxtWriter.WriteStartElement("VerboseMode");
			rXmlTxtWriter.WriteString(this.m_ScripterVerboseModeCheckBox.Checked.ToString());
			rXmlTxtWriter.WriteEndElement();
			rXmlTxtWriter.WriteEndElement();
		}


		private bool ibReadXmlConfigFile(string fileName)
		{
			if (!File.Exists(fileName))
			{
				return false;
			}
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.Load(fileName);
			}
			catch (XmlException ex)
			{
				if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.YES_NO_WARNING, string.Format("Config file loading error, while loading file \"{0}\"\n\nDelete invalid file?", ex.SourceUri), ex.StackTrace) == 6U)
				{
					File.Delete(fileName);
				}
				return false;
			}
			XmlNode xmlNode = xmlDocument.GetElementsByTagName("ConfigRoot")[0];
			for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
			{
				if (xmlNode.ChildNodes[i].Name.Equals("Clients"))
				{
					this.iReadClients(xmlNode.ChildNodes[i]);
				}
				else if (xmlNode.ChildNodes[i].Name.Equals("Paths"))
				{
					this.iReadPaths(xmlNode.ChildNodes[i]);
				}
				else
				{
					if (!xmlNode.ChildNodes[i].Name.Equals("Scripter"))
					{
						throw new Exception(string.Format("iReadXmlConfigFile: Invalid node name {0}", xmlNode.ChildNodes[i].Name));
					}
					this.iReadScripter(xmlNode.ChildNodes[i]);
				}
			}
			xmlDocument = null;
			return true;
		}


		private void iWriteXmlConfigFile(string fileName)
		{
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
			XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, Encoding.ASCII);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("ConfigRoot");
			this.iWriteClients(ref xmlTextWriter);
			this.iWritePaths(ref xmlTextWriter);
			this.iWriteScripter(ref xmlTextWriter);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
		}


		private void iSetCmdLineDll()
		{
			bool flag = false;
			if (File.Exists(Program.ClientDll))
			{
				foreach (object obj in ((IEnumerable)this.dgvClientDlls.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (!dataGridViewRow.IsNewRow)
					{
						if (dataGridViewRow.Cells[this.colClientDll.Index].Value.Equals(Program.ClientDll))
						{
							flag = true;
							dataGridViewRow.Cells[this.colUseClient.Index].Value = true;
						}
						else
						{
							dataGridViewRow.Cells[this.colUseClient.Index].Value = false;
						}
					}
				}
				if (!flag)
				{
					this.dgvClientDlls.Rows.Add();
					int index = this.dgvClientDlls.Rows.Count - 2;
					this.dgvClientDlls.Rows[index].Cells[this.colUseClient.Index].Value = true;
					this.dgvClientDlls.Rows[index].Cells[this.colPriority.Index].Value = "LOW";
					this.dgvClientDlls.Rows[index].Cells[this.colClientDll.Index].Value = Program.ClientDll;
				}
				this.SaveConfig(this.iGetSettingsFileName_FullPath());
				return;
			}
			GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error Loading client dll:" + Program.ClientDll + "\nUsing Client from setting instead.");
		}


		private string iXmlLoadDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open an XML file";
			openFileDialog.Filter = "XML files (*.xml)|*.xml";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.ShowDialog();
			return openFileDialog.FileName;
		}


		private string iDllLoadDialog(string last_path)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open a DLL file";
			openFileDialog.Filter = "DLL files (*.dll)|*.dll";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.InitialDirectory = last_path;
			openFileDialog.ShowDialog();
			return openFileDialog.FileName;
		}
	}
}
