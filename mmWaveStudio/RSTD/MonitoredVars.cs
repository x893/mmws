using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using RSTD.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

    public partial class MonitoredVars : DockContent
    {


        public bool bIsMonitoring
        {
            get
            {
                return this.m_bIsMonitoring;
            }
        }




        public List<string> MonitoredVarsList
        {
            get
            {
                return this.m_MonitoredVarsList;
            }
            set
            {
                this.m_MonitoredVarsList = value;
            }
        }


        public MonitoredVars()
        {
            this.InitializeComponent();
            base.HideOnClose = true;
            this.m_bIsMonitoring = false;
            this.m_LastFileName = null;
            this.m_MonitoredVarsList = new List<string>();
        }


        public void Build()
        {
            this.m_bIsMonitoring = false;
            this.iCreateOutputFolderIfNotExists();
            this.m_LastFileName = this.iGetLastFileName();
            this.iAddVarsToListBox();
        }


        public void UnBuild()
        {
            if (this.m_bIsMonitoring)
            {
                this.MonitorStop();
            }
            for (int i = 0; i < this.m_ListView.Items.Count; i++)
            {
                if (!GuiCore.IsPathInTree(this.m_ListView.Items[i].Text))
                {
                    this.m_ListView.Items[i].Remove();
                    this.m_MonitoredVarsList.Remove(this.m_MonitoredVarsList[i]);
                    i--;
                }
            }
        }


        public void RefreshGui()
        {
            for (int i = 0; i < this.m_MonitoredVarsList.Count; i++)
            {
                if (-1 == this.iFindNameIndexInListView(this.m_MonitoredVarsList[i]))
                {
                    this.iAddOrReplaceListViewItem(this.m_MonitoredVarsList[i], "", "0", "1", "1");
                }
            }
            for (int i = 0; i < this.m_ListView.Items.Count; i++)
            {
                if (!this.ibItemExistsInStringArray(this.m_ListView.Items[i].Text, this.m_MonitoredVarsList))
                {
                    this.m_ListView.Items[i].Remove();
                    if (i >= 0)
                    {
                        i--;
                    }
                }
            }
        }


        public string MonitorStart()
        {
            if (base.InvokeRequired)
            {
                MonitoredVars.GuiOper_String_Void method = new MonitoredVars.GuiOper_String_Void(this.MonitorStart);
                return (string)base.Invoke(method);
            }
            GuiCore.VerbosePrint("RSTD.MonitorStart()\n");
            if (this.m_bIsMonitoring)
            {
                GuiCore.VerbosePrint("Scripter ignored: Attempted to start monitor twice.\n");
                return "";
            }
            if (this.m_ListView.Items.Count == 0)
            {
                string text = "No monitored variables in list.";
                if (GuiCore.IsOnScriptThread())
                {
                    GuiCore.VerbosePrint(string.Format("Scripter ignored: MonitorStart: %s\n", text));
                }
                else
                {
                    GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Monitor:\n" + text);
                }
                return "";
            }
            bool flag = false;
            int num = 0;
            while (num < this.m_ListView.Items.Count && !flag)
            {
                if (this.m_ListView.Items[num].SubItems[1].Text.Equals(string.Empty))
                {
                    flag = true;
                }
                num++;
            }
            if (flag)
            {
                string text2 = "Warning! Not all monitored variables were set with a clock.";
                if (GuiCore.IsOnScriptThread())
                {
                    GuiCore.VerbosePrint(string.Format("RSTD.MonitorStart: %s\n", text2));
                }
                else
                {
                    GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Monitor:\n" + text2);
                }
            }
            this.m_LastFileName = this.iGetNextFileName();
            this.MonitorSave("LastMonitorConfig.xml", true);
            GuiCore.MonitorSetVars("LastMonitorConfig.xml");
            GuiCore.MonitorStart(this.m_LastFileName);
            this.m_AutoFlushTimer.Start();
            this.m_StartStopBtn.Text = "Stop";
            this.m_StartStopBtn.Image = TreeIcons.red_light;
            this.m_bIsMonitoring = true;
            return this.m_LastFileName;
        }


        public void MonitorStop()
        {
            GuiCore.VerbosePrint("RSTD.MonitorStop()\n");
            if (!this.m_bIsMonitoring)
            {
                GuiCore.VerbosePrint("Scripter ignored: Attempted to stop monitor twice.\n");
                return;
            }
            this.m_AutoFlushTimer.Stop();
            GuiCore.MonitorStop();
            if (!GuiCore.IsOnGuiThread())
            {
                this.MonitorStopEnd();
            }
        }


        public void MonitorStopEnd()
        {
            if (GuiCore.MainForm.bIsRstdClosing)
            {
                return;
            }
            if (base.InvokeRequired)
            {
                MonitoredVars.GuiOper_Void_Void method = new MonitoredVars.GuiOper_Void_Void(this.MonitorStopEnd);
                base.Invoke(method);
                return;
            }
            this.m_StartStopBtn.Text = "Start";
            this.m_StartStopBtn.Image = TreeIcons.green_light;
            this.m_bIsMonitoring = false;
        }


        public void MonitorLoad(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                try
                {
                    xmlDocument.Load(fileName);
                    GuiCore.VerbosePrint(string.Format("RSTD.MonitorLoad(\"{0}\")\n", fileName.Replace('\\', '/')));
                }
                catch (FileNotFoundException ex)
                {
                    GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, ex.Message);
                }
                this.iLoadClockLines(xmlDocument.SelectNodes("MonitorVariables/Var"));
            }
            catch (Exception ex2)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Monitor:\nMonitorLoad of file " + fileName + " failed.\nCorrupt or obsolete file sent the following exception:\n" + ex2.Message, ex2.StackTrace);
            }
            finally
            {
                xmlDocument = null;
            }
        }


        public void MonitorSave(bool b_all_items)
        {
            if (this.m_ListView.Items.Count == 0)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_WARNING, "Save to file: \n monitor is empty.");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save an XML Monitor settings file";
            saveFileDialog.Filter = "XML Monitor settings files (*.xml)|*.xml";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Settings.Default.LastMonitorPath;
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                GuiCore.VerbosePrint(string.Format("RSTD.MonitorSave(\"{0}\")", saveFileDialog.FileName.Replace('\\', '/')));
                this.MonitorSave(saveFileDialog.FileName, b_all_items);
            }
        }


        public void MonitorSave(string fileName, bool b_all_items)
        {
            if (this.m_ListView.Items.Count == 0)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_WARNING, "Save to file: \n monitor is empty.");
                return;
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                this.iSaveSettingsToFile(fileName, b_all_items);
                RstdGuiSettings.Default.LastMonitorFile = fileName;
                RstdGuiSettings.Default.Save();
            }
        }


        public void DeleteAllFiles()
        {
            string[] files = Directory.GetFiles(GuiCore.GetOutputPath() + "\\Monitors\\", "Monitor*.rtd", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
            this.m_LastFileName = null;
        }


        public void ShowLastFile()
        {
            if (!string.IsNullOrEmpty(this.m_LastFileName))
            {
                GuiCore.MonitorFlush();
                GuiCore.RemoveDuplicateChars(ref this.m_LastFileName, '\\');
                if (File.Exists(this.m_LastFileName))
                {
                    Process.Start("explorer", string.Format("/select,{0}", this.m_LastFileName));
                }
            }
        }


        public void AddMonitorVar(string var_name, string rel_clocks, string vec_offset, string vec_stride, string vec_length)
        {
            string[] clocks = GuiCore.GetClocks();
            string text = null;
            if (this.ibAddMonitoredVar(var_name))
            {
                string[] array = rel_clocks.Split(new char[]
                {
                    ';'
                }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < array.Length; i++)
                {
                    if (this.ibStringExistsInList(array[i], clocks))
                    {
                        text = text + array[i] + ";";
                    }
                    else
                    {
                        GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Monitor:\n" + string.Format("Ignoring clock {0}, outdated.", array[i]));
                    }
                }
                this.iAddOrReplaceListViewItem(var_name, text, vec_offset, vec_stride, vec_length);
                GuiCore.VerbosePrint(string.Format("RSTD.AddMonitorVar(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")\n", new object[]
                {
                    var_name,
                    text,
                    vec_offset,
                    vec_stride,
                    vec_length
                }));
                if (this.m_bIsMonitoring)
                {
                    this.MonitorStop();
                    this.MonitorStart();
                    return;
                }
            }
            else
            {
                GuiCore.VerbosePrint(string.Format("RSTD.AddMonitorVar: Could not find variable \"{0}\"\n", var_name));
            }
        }


        private void m_StartStopBtn_Click(object sender, EventArgs e)
        {
            if (this.m_bIsMonitoring)
            {
                if (GuiCore.MainForm.RstdSettings.GetMonitorOneClickStart() && GuiCore.MainForm.bIsClientRunning)
                {
                    GuiCore.VerbosePrint("GUI: RSTD.Stop()\n");
                    GuiCore.MainForm.LuaOps.Stop();
                }
                this.MonitorStop();
                return;
            }
            this.MonitorStart();
            if (GuiCore.MainForm.RstdSettings.GetMonitorOneClickStart() && !GuiCore.MainForm.bIsClientRunning)
            {
                GuiCore.VerbosePrint("RSTD.Go()\n");
                GuiCore.MainForm.LuaOps.Go();
            }
        }


        private void m_SaveBtn_Click(object sender, EventArgs e)
        {
            this.MonitorSave(true);
        }


        private void m_LoadBtn_Click(object sender, EventArgs e)
        {
            string initial_dir = "";
            if (!string.IsNullOrEmpty(RstdGuiSettings.Default.LastMonitorFile))
            {
                initial_dir = Path.GetDirectoryName(RstdGuiSettings.Default.LastMonitorFile);
            }
            string text = GuiCore.OpenFileDialog(initial_dir, FileType.XML);
            if (!string.IsNullOrEmpty(text))
            {
                RstdGuiSettings.Default.LastMonitorFile = text;
                RstdGuiSettings.Default.Save();
                this.MonitorLoad(text);
            }
        }


        private void m_DeleteAllFilesBtn_Click(object sender, EventArgs e)
        {
            if (6U == GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, "This will delete all monitor files (*.rtd).\nAre you Sure?\n"))
            {
                GuiCore.VerbosePrint("RSTD.DeleteAllFiles()\n");
                this.DeleteAllFiles();
            }
        }


        private void m_ShowLastFileBtn_Click(object sender, EventArgs e)
        {
            GuiCore.VerbosePrint("RSTD.ShowLastFile()\n");
            this.ShowLastFile();
        }


        private void m_ListView_DoubleClick(object sender, EventArgs e)
        {
            this.iOpenUpdateDialog();
        }


        private void m_ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.m_ListView.SelectedItems.Count == 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    PassedVarData dataPassed = new PassedVarData(this.m_ListView.SelectedItems);
                    new MonitorContextMenu(this, dataPassed, RstdConstants.CONTEXT_MENU_ORIGIN.MONITOR);
                }
                catch (Exception ex)
                {
                    GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, ex.Message, ex.StackTrace);
                }
            }
        }


        private void m_ListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete))
            {
                if (e.Control && e.KeyCode.Equals(Keys.A))
                {
                    e.Handled = true;
                    if (this.m_ListView.Items.Count == 0)
                    {
                        return;
                    }
                    for (int i = 0; i < this.m_ListView.Items.Count; i++)
                    {
                        if (!this.m_ListView.Items[i].Selected)
                        {
                            this.m_ListView.Items[i].Selected = true;
                        }
                    }
                }
                return;
            }
            if (this.m_bIsMonitoring)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Monitor:\nCan't remove monitored variables \nwhile monitoring is in progress.");
                return;
            }
            this.iRemoveSelectedVars();
        }


        private void m_AutoFlushTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                GuiCore.MonitorFlush();
            }
            catch (Exception ex)
            {
                GuiCore.VerbosePrint(string.Format("MonitorFlush Exception caught:\n{0}\nMonitoring Will stop now.\nRSTD.MonitorStop()\n", ex.Message));
                this.MonitorStop();
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, string.Concat(new object[]
                {
                    "Error Flushing to Monitor file :\n\nMonitoring will stop now.\n\n",
                    ex.Message,
                    "\n",
                    ex.InnerException,
                    "\n"
                }), ex.StackTrace);
            }
        }


        private void m_ListView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PassedVarData)))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
            e.Effect = DragDropEffects.None;
        }


        private void m_ListView_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(PassedVarData)))
            {
                return;
            }
            GuiCore.bAddMonitoredVar(((PassedVarData)e.Data.GetData(typeof(PassedVarData))).XmlNodes);
        }


        private void iCreateOutputFolderIfNotExists()
        {
            string path = GuiCore.GetOutputPath() + "\\Monitors\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        private string iGetLastFileName()
        {
            string path = GuiCore.GetOutputPath() + "\\Monitors\\";
            return GuiCore.GetLastIndexedFileNameInPath("Monitor", "rtd", path);
        }


        private string iGetNextFileName()
        {
            string str = GuiCore.GetOutputPath() + "\\Monitors\\";
            if (string.IsNullOrEmpty(this.m_LastFileName))
            {
                return str + "Monitor0000.rtd";
            }
            string lastFileName = this.m_LastFileName;
            GuiCore.IncrementFileNameIdx("Monitor", 4, ref lastFileName);
            return lastFileName;
        }


        private void iWriteAssociatedClocksForSingleVar(ref XmlTextWriter rWriter, string clocks)
        {
            string[] array = clocks.Split(new char[]
            {
                ';'
            }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                rWriter.WriteStartElement("Clock");
                rWriter.WriteAttributeString("name", array[i]);
                rWriter.WriteEndElement();
            }
        }


        private void iWriteVarsAndAssociatedClocks(ref XmlTextWriter rWriter, bool b_all_items)
        {
            List<ListViewItem> list = new List<ListViewItem>();
            if (b_all_items)
            {
                foreach (ListViewItem item in this.m_ListView.Items)
                {
                    list.Add(item);
                }
            }
            else
            {
                foreach (object obj2 in this.m_ListView.SelectedItems)
                {
                    ListViewItem item2 = (ListViewItem)obj2;
                    list.Add(item2);
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                string text = list[i].Text;
                string text2 = list[i].SubItems[1].Text;
                string text3 = list[i].SubItems[2].Text;
                string text4 = list[i].SubItems[3].Text;
                string text5 = list[i].SubItems[4].Text;
                if (!text2.Equals(""))
                {
                    rWriter.WriteStartElement("Var");
                    rWriter.WriteAttributeString("name", text);
                    rWriter.WriteAttributeString("offset", text3);
                    rWriter.WriteAttributeString("stride", text4);
                    rWriter.WriteAttributeString("length", text5);
                    this.iWriteAssociatedClocksForSingleVar(ref rWriter, text2);
                    rWriter.WriteEndElement();
                }
                else
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Append("The following variables was not save to file\nbecause they do not contain an associating clock:\n");
                    }
                    stringBuilder.Append(list[i].Text);
                    stringBuilder.Append("\n");
                }
            }
            if (stringBuilder.Length > 0)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_WARNING, stringBuilder.ToString());
            }
        }


        private void iSaveSettingsToFile(string fileName, bool b_all_items)
        {
            XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, Encoding.ASCII);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("MonitorVariables");
            xmlTextWriter.WriteAttributeString("textmode", "false");
            this.iWriteVarsAndAssociatedClocks(ref xmlTextWriter, b_all_items);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
        }


        private void iAddVarsToListBox()
        {
            this.m_ListView.Items.Clear();
            for (int i = 0; i < this.m_MonitoredVarsList.Count; i++)
            {
                this.iAddOrReplaceListViewItem(this.m_MonitoredVarsList[i], "", "0", "1", "1");
            }
        }


        private void iOpenUpdateDialog()
        {
            new UpdateMonitorVarsDialog(GuiCore.GetClocks(), this.m_ListView.SelectedItems).ShowDialog();
        }


        private void iRemoveSelectedVars()
        {
            if (this.m_ListView.SelectedItems.Count == 0)
            {
                return;
            }
            List<XmlNode> list = new List<XmlNode>();
            for (int i = 0; i < this.m_ListView.SelectedItems.Count; i++)
            {
                list.Add((XmlNode)this.m_ListView.SelectedItems[i].Tag);
            }
            GuiCore.RemoveMonitoredVar(list);
        }


        private bool ibAddMonitoredVar(string varNameFullPath)
        {
            XmlNode var_node;
            return GuiCore.GetNodeFromPath(varNameFullPath, out var_node) && GuiCore.bAddMonitoredVar(var_node);
        }


        private bool ibStringExistsInList(string findStr, string[] strList)
        {
            for (int i = 0; i < strList.Length; i++)
            {
                if (strList[i].Equals(findStr))
                {
                    return true;
                }
            }
            return false;
        }


        private int iFindNameIndexInListView(string name)
        {
            for (int i = 0; i < this.m_ListView.Items.Count; i++)
            {
                if (this.m_ListView.Items[i].Text.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }


        private void iAddOrReplaceListViewItem(string varName, string relClocks, string offset, string stride, string length)
        {
            int num = this.iFindNameIndexInListView(varName);
            XmlNode tag;
            GuiCore.GetNodeFromPath(varName, out tag);
            if (-1 == num)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    varName,
                    relClocks,
                    offset,
                    stride,
                    length
                });
                listViewItem.Tag = tag;
                this.m_ListView.Items.Add(listViewItem);
                return;
            }
            if (this.m_ListView.Items[num].SubItems[1].Text != "")
            {
                string[] array = relClocks.Split(new char[]
                {
                    ';'
                }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < array.Length; i++)
                {
                    if (!this.m_ListView.Items[num].SubItems[1].Text.Contains(array[i]))
                    {
                        ListViewItem.ListViewSubItem listViewSubItem = this.m_ListView.Items[num].SubItems[1];
                        listViewSubItem.Text = listViewSubItem.Text + array[i] + ";";
                    }
                }
            }
            else
            {
                this.m_ListView.Items[num].SubItems[1].Text = relClocks;
            }
            this.m_ListView.Items[num].SubItems[2].Text = offset;
            this.m_ListView.Items[num].SubItems[3].Text = stride;
            this.m_ListView.Items[num].SubItems[4].Text = length;
        }


        private void iLoadVarNode(XmlNode varNode)
        {
            string value = varNode.Attributes["name"].Value;
            string value2 = varNode.Attributes["offset"].Value;
            string value3 = varNode.Attributes["stride"].Value;
            string value4 = varNode.Attributes["length"].Value;
            string[] clocks = GuiCore.GetClocks();
            string text = "";
            if (this.ibAddMonitoredVar(value))
            {
                for (int i = 0; i < varNode.ChildNodes.Count; i++)
                {
                    string value5 = varNode.ChildNodes[i].Attributes.GetNamedItem("name").Value;
                    if (this.ibStringExistsInList(value5, clocks))
                    {
                        text = text + value5 + ";";
                    }
                    else
                    {
                        GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Monitor:\n" + string.Format("Ignoring clock {0}, outdated.", value5));
                    }
                }
                this.iAddOrReplaceListViewItem(value, text, value2, value3, value4);
                return;
            }
            GuiCore.AlwaysPrint(string.Format("Monitor: Ignoring variable {0} \nwhich doesn't exist in tree.\n", value));
        }


        private void iLoadClockLines(XmlNodeList varNodeList)
        {
            for (int i = 0; i < varNodeList.Count; i++)
            {
                this.iLoadVarNode(varNodeList[i]);
            }
        }


        private bool ibItemExistsInStringArray(string itemName, List<string> node_list)
        {
            for (int i = 0; i < node_list.Count; i++)
            {
                if (node_list[i].Equals(itemName))
                {
                    return true;
                }
            }
            return false;
        }


        private void m_btnClear_Click(object sender, EventArgs e)
        {
            this.ClearMonitor();
        }


        public void ClearMonitor()
        {
            GuiCore.VerbosePrint("RSTD.ClearMonitor()\n");
            if (this.m_bIsMonitoring)
            {
                GuiCore.RstdException("Can't remove monitored variables while monitoring is in progress.\n", "");
                return;
            }
            List<XmlNode> list = new List<XmlNode>();
            foreach (object obj in this.m_ListView.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                list.Add((XmlNode)listViewItem.Tag);
            }
            GuiCore.RemoveMonitoredVar(list);
        }


        private void m_LoadLastBtn_Click(object sender, EventArgs e)
        {
            this.MonitorLoad(RstdGuiSettings.Default.LastMonitorFile);
        }


        private const string m_XmlRootStr = "MonitorVariables";


        private const string m_XmlTextModeStr = "textmode";


        private const string m_OutFolderName = "Monitors";


        private const string m_OutFilePrefix = "Monitor";


        private const string m_OutFileSuffix = "rtd";


        private string m_LastFileName;


        private bool m_bIsMonitoring;


        private List<string> m_MonitoredVarsList;



        private delegate string GuiOper_String_Void();



        private delegate void GuiOper_Void_Void();
    }
}
