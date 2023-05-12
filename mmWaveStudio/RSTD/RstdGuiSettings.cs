using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LuaRegister;

namespace RSTD
{

    internal class RstdGuiSettings
    {



        public ArrayList ListFindChosenItemsFromLoad
        {
            get
            {
                return RstdGuiSettings.m_ListFindChosenItemsFromLoad;
            }
            set
            {
                RstdGuiSettings.m_ListFindChosenItemsFromLoad = value;
            }
        }




        public bool CheckedToolBarsStatusBar
        {
            get
            {
                return RstdGuiSettings.m_bCheckedToolBarsStatusBar;
            }
            set
            {
                RstdGuiSettings.m_bCheckedToolBarsStatusBar = value;
            }
        }




        public bool IsSortBTColumns
        {
            get
            {
                return RstdGuiSettings.m_bSortBTColumns;
            }
            set
            {
                RstdGuiSettings.m_bSortBTColumns = value;
            }
        }




        public bool IsSortWSColumns
        {
            get
            {
                return RstdGuiSettings.m_bSortWSColumns;
            }
            set
            {
                RstdGuiSettings.m_bSortWSColumns = value;
            }
        }




        public bool DisplayFunctions
        {
            get
            {
                return RstdGuiSettings.m_bDisplayFunctions;
            }
            set
            {
                RstdGuiSettings.m_bDisplayFunctions = value;
            }
        }




        public bool bSaveDisplayAsForTxt
        {
            get
            {
                return RstdGuiSettings.m_bSaveDisplayInTxt;
            }
            set
            {
                RstdGuiSettings.m_bSaveDisplayInTxt = value;
            }
        }




        public bool bDisableFadeOutSplash
        {
            get
            {
                return RstdGuiSettings.m_bDisableFadeOutSplash;
            }
            set
            {
                RstdGuiSettings.m_bDisableFadeOutSplash = value;
            }
        }




        public bool bAutoScrollOutput
        {
            get
            {
                return RstdGuiSettings.m_bAutoScrollInOutput;
            }
            set
            {
                RstdGuiSettings.m_bAutoScrollInOutput = value;
            }
        }




        public bool[] CheckedToolBarsArr
        {
            get
            {
                return RstdGuiSettings.m_bCheckedToolBarsArr;
            }
            set
            {
                RstdGuiSettings.m_bCheckedToolBarsArr = value;
            }
        }




        public float OutputZoomFactor
        {
            get
            {
                return this.m_OutputZoomFactor;
            }
            set
            {
                this.m_OutputZoomFactor = value;
            }
        }




        public string OutputFilterExclude
        {
            get
            {
                return this.m_OutputFilterExclude;
            }
            set
            {
                this.m_OutputFilterExclude = value;
            }
        }




        public string OutputFilterInclude
        {
            get
            {
                return this.m_OutputFilterInclude;
            }
            set
            {
                this.m_OutputFilterInclude = value;
            }
        }




        public List<string> LastScriptsRun
        {
            get
            {
                return this.m_LastScriptsRun;
            }
            set
            {
                this.m_LastScriptsRun = value;
            }
        }




        public string LastTreePath
        {
            get
            {
                return this.m_LastTreePath;
            }
            set
            {
                this.m_LastTreePath = value;
            }
        }




        public string LastExportTreePath
        {
            get
            {
                return this.m_LastExportTreePath;
            }
            set
            {
                this.m_LastExportTreePath = value;
            }
        }




        public string LastMonitorFile
        {
            get
            {
                return this.m_LastMonitorFile;
            }
            set
            {
                this.m_LastMonitorFile = value;
            }
        }




        public string LastScriptPath
        {
            get
            {
                return this.m_LastScriptPath;
            }
            set
            {
                this.m_LastScriptPath = value;
            }
        }




        public string LastDllPath
        {
            get
            {
                return this.m_LastDllPath;
            }
            set
            {
                this.m_LastDllPath = value;
            }
        }




        public string LastUserButtonsFile
        {
            get
            {
                return this.m_LastUserButtonsFile;
            }
            set
            {
                this.m_LastUserButtonsFile = value;
            }
        }




        public string LastWorksetFile
        {
            get
            {
                return this.m_LastWorksetFile;
            }
            set
            {
                this.m_LastWorksetFile = value;
            }
        }




        public string LastSubSetFile
        {
            get
            {
                return this.m_LastSubSetFile;
            }
            set
            {
                this.m_LastSubSetFile = value;
            }
        }




        public List<UserButtonInfo> UserButtons
        {
            get
            {
                return this.m_UserButtons;
            }
            set
            {
                this.m_UserButtons = value;
            }
        }




        public List<UserToolStripInfo> UserToolStrips
        {
            get
            {
                return this.m_UserToolStrips;
            }
            set
            {
                this.m_UserToolStrips = value;
            }
        }




        public List<ToolBarBtnInfo> StandardButtons
        {
            get
            {
                return this.m_StandardButtons;
            }
            set
            {
                this.m_StandardButtons = value;
            }
        }




        public List<LuaRegisterInfo> LuaRegisterInfos
        {
            get
            {
                return this.m_LuaRegisterInfos;
            }
            set
            {
                this.m_LuaRegisterInfos = value;
            }
        }



        public string MainSettingsFileName
        {
            get
            {
                return this.m_MainSettingsFileName;
            }
        }



        public string UserButtonsFileName
        {
            get
            {
                return this.m_UserButtonsFileName;
            }
        }



        public string DefaultUserButtonsFileName
        {
            get
            {
                return this.m_DefaultUserButtonsFileName;
            }
        }



        public string RegisteredDllsFileName
        {
            get
            {
                return this.m_RegisteredDllsFileName;
            }
        }




        public string LuaFamilyFont
        {
            get
            {
                return this.m_LuaFamilyFont;
            }
            set
            {
                this.m_LuaFamilyFont = value;
            }
        }




        public string LuaFontBold
        {
            get
            {
                return this.m_LuaFontBold;
            }
            set
            {
                this.m_LuaFontBold = value;
            }
        }




        public string LuaFontItalic
        {
            get
            {
                return this.m_LuaFontItalic;
            }
            set
            {
                this.m_LuaFontItalic = value;
            }
        }




        public string LuaFontSize
        {
            get
            {
                return this.m_LuaFontSize;
            }
            set
            {
                this.m_LuaFontSize = value;
            }
        }




        public string LuaBackGroundColor
        {
            get
            {
                return this.m_LuaBackGroundColor;
            }
            set
            {
                this.m_LuaBackGroundColor = value;
            }
        }




        public string LuaForeGroundColor
        {
            get
            {
                return this.m_LuaForeGroundColor;
            }
            set
            {
                this.m_LuaForeGroundColor = value;
            }
        }




        public bool[] bvisible_columns_in_browse_tree_arr
        {
            get
            {
                return RstdGuiSettings.m_bvisible_columns_in_browse_tree_arr;
            }
            set
            {
                RstdGuiSettings.m_bvisible_columns_in_browse_tree_arr = value;
            }
        }




        public bool[] bvisible_columns_in_work_set_arr
        {
            get
            {
                return RstdGuiSettings.m_bvisible_columns_in_work_set_arr;
            }
            set
            {
                RstdGuiSettings.m_bvisible_columns_in_work_set_arr = value;
            }
        }




        public int[] dBTColumnsOrderArr
        {
            get
            {
                return RstdGuiSettings.m_dBTColumnsOrderArr;
            }
            set
            {
                RstdGuiSettings.m_dBTColumnsOrderArr = value;
            }
        }




        public int[] dWSColumnsOrderArr
        {
            get
            {
                return RstdGuiSettings.m_dWSColumnsOrderArr;
            }
            set
            {
                RstdGuiSettings.m_dWSColumnsOrderArr = value;
            }
        }




        public StandardButtonsSize StandardBtnsSize
        {
            get
            {
                return this.m_StandardBtnsSize;
            }
            set
            {
                this.m_StandardBtnsSize = value;
            }
        }




        public Dictionary<NodeType, DisplayType> DefaultTypesDict
        {
            get
            {
                return this.m_DefaultTypesDict;
            }
            set
            {
                this.m_DefaultTypesDict = value;
            }
        }




        public bool AllowOnlyUserMsgs
        {
            get
            {
                return this.m_bAllowOnlyUserMsgs;
            }
            set
            {
                this.m_bAllowOnlyUserMsgs = value;
            }
        }


        private RstdGuiSettings()
        {
            this.m_MainSettingsFileName = Path.Combine(GuiCore.MainForm.SettingsOutputPath, "GuiConfig.xml");
            this.m_UserButtonsFileName = Path.Combine(GuiCore.MainForm.SettingsOutputPath, "UserButtons.xml");
            this.m_DefaultUserButtonsFileName = Path.Combine(Application.StartupPath, "DefaultUserButtons.xml");
            this.m_RegisteredDllsFileName = Path.Combine(GuiCore.MainForm.SettingsOutputPath, "RegisteredDlls.xml");
            this.m_LastScriptsRun = new List<string>();
            this.m_UserButtons = new List<UserButtonInfo>();
            this.m_UserToolStrips = new List<UserToolStripInfo>();
            this.m_StandardButtons = new List<ToolBarBtnInfo>();
            this.m_LuaRegisterInfos = new List<LuaRegisterInfo>();
            this.m_LuaFamilyFont = "Courier New";
            this.m_LuaFontBold = "False";
            this.m_LuaFontItalic = "False";
            this.m_LuaFontSize = "10.2";
            this.m_LuaBackGroundColor = frmLuaShell.ConvertColorToHex(SystemColors.Window);
            this.m_LuaForeGroundColor = frmLuaShell.ConvertColorToHex(SystemColors.ControlText);
            RstdGuiSettings.m_bvisible_columns_in_browse_tree_arr = new bool[6];
            RstdGuiSettings.m_bvisible_columns_in_work_set_arr = new bool[6];
            RstdGuiSettings.m_bCheckedToolBarsArr = new bool[3];
            RstdGuiSettings.m_dBTColumnsOrderArr = new int[6];
            RstdGuiSettings.m_dWSColumnsOrderArr = new int[6];
            this.m_StandardBtnsSize = StandardButtonsSize.LARGE;
            this.m_DefaultTypesDict = new Dictionary<NodeType, DisplayType>();
            this.m_DefaultTypesDict.Add(NodeType.REGISTER, DisplayType.HEX);
            this.m_DefaultTypesDict.Add(NodeType.FIELD, DisplayType.HEX);
            for (int i = 0; i < GuiCore.MainForm.MainToolBar.Items.Count; i++)
            {
                if (GuiCore.MainForm.MainToolBar.Items[i] is ToolStripButton)
                {
                    this.m_StandardButtons.Add(new ToolBarBtnInfo(GuiCore.MainForm.MainToolBar.Items[i].Text));
                }
            }
            int num = 0;
            while ((long)num < 6L)
            {
                RstdGuiSettings.m_bvisible_columns_in_browse_tree_arr[num] = true;
                num++;
            }
            int num2 = 0;
            while ((long)num2 < 6L)
            {
                RstdGuiSettings.m_bvisible_columns_in_work_set_arr[num2] = true;
                num2++;
            }
            for (int j = 0; j < 3; j++)
            {
                RstdGuiSettings.m_bCheckedToolBarsArr[j] = true;
            }
            int num3 = 0;
            while ((long)num3 < 6L)
            {
                RstdGuiSettings.m_dBTColumnsOrderArr[num3] = num3;
                num3++;
            }
            int num4 = 0;
            while ((long)num4 < 6L)
            {
                RstdGuiSettings.m_dWSColumnsOrderArr[num4] = num4;
                num4++;
            }
            RstdGuiSettings.m_ListFindChosenItemsFromLoad = new ArrayList();
            RstdGuiSettings.m_bCheckedToolBarsStatusBar = true;
            RstdGuiSettings.m_bSortBTColumns = true;
            RstdGuiSettings.m_bSortWSColumns = true;
            RstdGuiSettings.m_bDisplayFunctions = true;
            RstdGuiSettings.m_bSaveDisplayInTxt = false;
            RstdGuiSettings.m_bDisableFadeOutSplash = false;
            RstdGuiSettings.m_bAutoScrollInOutput = true;
            this.m_bAllowOnlyUserMsgs = false;
        }



        public static RstdGuiSettings Default
        {
            get
            {
                return RstdGuiSettings.defaultInstance;
            }
        }


        public void Save()
        {
            this.Save(this.m_MainSettingsFileName, SettingsType.MainSettings);
        }


        public void BackupUserToolbars()
        {
            string text = GuiCore.MainForm.SettingsOutputPath + "\\ToolBars\\Backup";
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            foreach (UserToolStripInfo userToolStripInfo in this.m_UserToolStrips)
            {
                if (!userToolStripInfo.IsReadOnly)
                {
                    try
                    {
                        string text2 = Path.Combine(text, Path.GetFileName(userToolStripInfo.ToolBarConfigFile));
                        if (File.Exists(text2) && GuiCore.IsFileReadOnly(text2))
                        {
                            File.SetAttributes(text2, FileAttributes.Normal);
                        }
                        File.Copy(userToolStripInfo.ToolBarConfigFile, text2, true);
                        if (GuiCore.IsFileReadOnly(text2))
                        {
                            File.SetAttributes(text2, FileAttributes.Normal);
                        }
                    }
                    catch (Exception ex)
                    {
                        GuiCore.RstdException(ex.Message, ex.StackTrace);
                    }
                }
            }
        }


        public void Save(string fileName, SettingsType type)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            if (File.Exists(fileName))
            {
                if (GuiCore.IsFileReadOnly(fileName))
                {
                    if (type == SettingsType.UserButtons)
                    {
                        GuiCore.ErrorMessage(string.Format("Can't save user buttons to:\n\"{0}\".\nFile is read-only.", fileName));
                        return;
                    }
                    File.SetAttributes(fileName, FileAttributes.Normal);
                }
                File.Delete(fileName);
            }
            XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, Encoding.ASCII);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("GuiConfigRoot");
            if (type == SettingsType.MainSettings)
            {
                this.iWriteMainSettings(xmlTextWriter);
            }
            else if (type == SettingsType.UserButtons)
            {
                this.iWriteUserButtons(xmlTextWriter);
            }
            else if (type == SettingsType.RegisteredDlls)
            {
                this.iWriteLuaDllRegisters(xmlTextWriter);
            }
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
            if (type == SettingsType.UserButtons)
            {
                this.iSaveUserButtonsIcons();
            }
        }


        public void SaveUserButtons()
        {
            this.SaveUserButtons(this.m_UserButtonsFileName);
        }


        public void SaveUserButtons(int tool_strip_index)
        {
            this.m_SelectedUserToolStripIndex = tool_strip_index;
            this.SaveUserButtons(this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarConfigFile);
        }


        public void SaveUserButtons(int tool_strip_index, string filename)
        {
            this.m_SelectedUserToolStripIndex = tool_strip_index;
            this.SaveUserButtons(filename);
        }


        public void SaveUserButtons(string fileName)
        {
            this.Save(fileName, SettingsType.UserButtons);
        }


        private void iWriteMainSettings(XmlTextWriter xml_writer)
        {
            string[] names = Enum.GetNames(typeof(RstdConstants.ListViewSubItem_T));
            string[] names2 = Enum.GetNames(typeof(RstdConstants.CheckedToolBars));
            xml_writer.WriteStartElement("MainSettings");
            xml_writer.WriteAttributeString("rttt_version", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            xml_writer.WriteStartElement("Output");
            this.iAddValueElement(xml_writer, "OnlyUserMessages", this.m_bAllowOnlyUserMsgs.ToString());
            this.iAddValueElement(xml_writer, "FilterExclude", this.m_OutputFilterExclude);
            this.iAddValueElement(xml_writer, "FilterInclude", this.m_OutputFilterInclude);
            this.iAddValueElement(xml_writer, "ZoomFactor", this.m_OutputZoomFactor.ToString());
            this.iAddValueElement(xml_writer, "AutoScroll", RstdGuiSettings.m_bAutoScrollInOutput.ToString());
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("Scripts");
            xml_writer.WriteStartElement("LastScripts");
            foreach (string value in this.m_LastScriptsRun)
            {
                this.iAddValueElement(xml_writer, "Script", value);
            }
            xml_writer.WriteEndElement();
            this.iAddValueElement(xml_writer, "LastScriptPath", this.m_LastScriptPath);
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("Paths");
            this.iAddValueElement(xml_writer, "LastTreePath", this.m_LastTreePath);
            this.iAddValueElement(xml_writer, "LastDllPath", this.m_LastDllPath);
            this.iAddValueElement(xml_writer, "LastExportTreePath", this.m_LastExportTreePath);
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("Files");
            this.iAddValueElement(xml_writer, "LastWorkSetFile", this.m_LastWorksetFile);
            this.iAddValueElement(xml_writer, "LastMonitorFile", this.m_LastMonitorFile);
            this.iAddValueElement(xml_writer, "LastSubSetFile", this.m_LastSubSetFile);
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("LuaSettings");
            xml_writer.WriteStartElement("Font");
            this.iAddValueElement(xml_writer, "Family", this.m_LuaFamilyFont);
            this.iAddValueElement(xml_writer, "Bold", this.m_LuaFontBold);
            this.iAddValueElement(xml_writer, "Italic", this.m_LuaFontItalic);
            this.iAddValueElement(xml_writer, "Size", this.m_LuaFontSize);
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("LuaShellBackGround");
            this.iAddValueElement(xml_writer, "BackGround", this.m_LuaBackGroundColor);
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("LuaShellForeGround");
            this.iAddValueElement(xml_writer, "ForeGround", this.m_LuaForeGroundColor);
            xml_writer.WriteEndElement();
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("BrowseTree");
            xml_writer.WriteStartElement("Columns");
            int num = 0;
            while ((long)num < 6L)
            {
                xml_writer.WriteStartElement("col");
                xml_writer.WriteAttributeString("Name", names[num]);
                xml_writer.WriteAttributeString("Visible", RstdGuiSettings.m_bvisible_columns_in_browse_tree_arr[num].ToString());
                xml_writer.WriteAttributeString("Index", RstdGuiSettings.m_dBTColumnsOrderArr[num].ToString());
                xml_writer.WriteEndElement();
                num++;
            }
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("SortColumns");
            this.iAddValueElement(xml_writer, "Sort", RstdGuiSettings.m_bSortBTColumns.ToString());
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("DefaultDisplay");
            foreach (NodeType key in this.m_DefaultTypesDict.Keys)
            {
                xml_writer.WriteStartElement("Type");
                xml_writer.WriteAttributeString("Name", key.ToString());
                xml_writer.WriteAttributeString("Display", this.m_DefaultTypesDict[key].ToString());
                xml_writer.WriteEndElement();
            }
            xml_writer.WriteEndElement();
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("WorkSet");
            xml_writer.WriteStartElement("Columns");
            int num2 = 0;
            while ((long)num2 < 6L)
            {
                xml_writer.WriteStartElement("col");
                xml_writer.WriteAttributeString("Name", names[num2]);
                xml_writer.WriteAttributeString("Visible", RstdGuiSettings.m_bvisible_columns_in_work_set_arr[num2].ToString());
                xml_writer.WriteAttributeString("Index", RstdGuiSettings.m_dWSColumnsOrderArr[num2].ToString());
                xml_writer.WriteEndElement();
                num2++;
            }
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("SortColumns");
            this.iAddValueElement(xml_writer, "Sort", RstdGuiSettings.m_bSortWSColumns.ToString());
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("DisplayFunctions");
            this.iAddValueElement(xml_writer, "Display", RstdGuiSettings.m_bDisplayFunctions.ToString());
            xml_writer.WriteEndElement();
            xml_writer.WriteEndElement();
            xml_writer.WriteStartElement("General");
            this.iAddValueElement(xml_writer, "SaveDisplayInTxt", RstdGuiSettings.m_bSaveDisplayInTxt.ToString());
            this.iAddValueElement(xml_writer, "DisableFadeOutSplash", RstdGuiSettings.m_bDisableFadeOutSplash.ToString());
            xml_writer.WriteEndElement();
            if (GuiCore.FindForm != null)
            {
                xml_writer.WriteStartElement("FindForm");
                xml_writer.WriteStartElement("SearchHistory");
                for (int i = GuiCore.FindForm.ListFindChosenItems.Count - 1; i >= 0; i--)
                {
                    xml_writer.WriteStartElement("SearchItem");
                    xml_writer.WriteAttributeString("str", GuiCore.FindForm.ListFindChosenItems[i].ToString());
                    xml_writer.WriteEndElement();
                }
                xml_writer.WriteEndElement();
                xml_writer.WriteEndElement();
            }
            xml_writer.WriteStartElement("ToolBars");
            for (int j = 0; j < 3; j++)
            {
                xml_writer.WriteStartElement("ToolBar");
                xml_writer.WriteAttributeString("Name", names2[j]);
                xml_writer.WriteAttributeString("Visible", RstdGuiSettings.m_bCheckedToolBarsArr[j].ToString());
                xml_writer.WriteEndElement();
            }
            xml_writer.WriteStartElement("ToolBar");
            xml_writer.WriteAttributeString("Name", "STATUS_BAR");
            xml_writer.WriteAttributeString("Visible", RstdGuiSettings.m_bCheckedToolBarsStatusBar.ToString());
            xml_writer.WriteEndElement();
            this.iWriteStandardButtons(xml_writer);
            xml_writer.WriteEndElement();
            this.iWriteUserToolStripsFiles(xml_writer);
        }


        private void iWriteLuaDllRegisters(XmlTextWriter xml_writer)
        {
            xml_writer.WriteStartElement("LuaDllRegisters");
            foreach (LuaRegisterInfo luaRegisterInfo in this.m_LuaRegisterInfos)
            {
                if (luaRegisterInfo.SaveToSettings)
                {
                    xml_writer.WriteStartElement("DllRegister");
                    xml_writer.WriteAttributeString("Use", luaRegisterInfo.Use.ToString());
                    xml_writer.WriteAttributeString("Package", luaRegisterInfo.Package.ToString());
                    xml_writer.WriteAttributeString("Path", luaRegisterInfo.DllPath);
                    xml_writer.WriteEndElement();
                }
            }
            xml_writer.WriteEndElement();
        }


        private void iWriteStandardButtons(XmlTextWriter xml_writer)
        {
            xml_writer.WriteStartElement("StandardButtons");
            xml_writer.WriteAttributeString("Size", this.m_StandardBtnsSize.ToString());
            foreach (ToolBarBtnInfo toolBarBtnInfo in this.m_StandardButtons)
            {
                xml_writer.WriteStartElement("StandardButton");
                xml_writer.WriteAttributeString("Title", toolBarBtnInfo.Title);
                xml_writer.WriteAttributeString("Visible", toolBarBtnInfo.Show.ToString());
                xml_writer.WriteEndElement();
            }
            xml_writer.WriteEndElement();
        }


        private void iWriteUserToolStripsFiles(XmlTextWriter xml_writer)
        {
            xml_writer.WriteStartElement("UserToolStrips");
            foreach (UserToolStripInfo userToolStripInfo in this.m_UserToolStrips)
            {
                if (!userToolStripInfo.IsDefualt)
                {
                    xml_writer.WriteStartElement("UserToolStrip");
                    xml_writer.WriteAttributeString("Path", userToolStripInfo.ToolBarConfigFile);
                    xml_writer.WriteAttributeString("Visible", userToolStripInfo.Show.ToString());
                    xml_writer.WriteAttributeString("row", userToolStripInfo.RowIndex.ToString());
                    xml_writer.WriteAttributeString("col", userToolStripInfo.ColIndex.ToString());
                    xml_writer.WriteEndElement();
                }
            }
            xml_writer.WriteEndElement();
        }


        private void iWriteUserButtons(XmlTextWriter xml_writer)
        {
            string text = this.ParseBasePath(this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarBasePath);
            xml_writer.WriteStartElement("UserButtons");
            xml_writer.WriteAttributeString("name", this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarName);
            xml_writer.WriteAttributeString("base_path", this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarBasePath);
            for (int i = 0; i < this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons.Count; i++)
            {
                LuaSourceType sourceType = this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].SourceType;
                string text2 = this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].UserButtonSource;
                string text3 = this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].FunctionSource;
                xml_writer.WriteStartElement("UserButton");
                xml_writer.WriteAttributeString("Visible", this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].Show.ToString());
                xml_writer.WriteAttributeString("Title", this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].Title);
                xml_writer.WriteAttributeString("SourceType", sourceType.ToString());
                if (sourceType == LuaSourceType.File && !string.IsNullOrEmpty(text) && text2.StartsWith(text))
                {
                    text2 = text2.Remove(0, text.Length);
                }
                xml_writer.WriteAttributeString("Script", text2);
                if (sourceType == LuaSourceType.Function)
                {
                    if (!string.IsNullOrEmpty(text) && text3.StartsWith(text))
                    {
                        text3 = text3.Remove(0, text.Length);
                    }
                    xml_writer.WriteAttributeString("FunctionSource", text3);
                }
                xml_writer.WriteAttributeString("IconFile", this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].IconFile);
                xml_writer.WriteAttributeString("ToolTip", this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].ToolTip);
                xml_writer.WriteAttributeString("UserColor", ColorTranslator.ToHtml(this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].UserColor));
                xml_writer.WriteStartElement("Params");
                foreach (ScriptParam scriptParam in this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].Params)
                {
                    xml_writer.WriteStartElement("Param");
                    xml_writer.WriteAttributeString("Type", scriptParam.Type.ToString());
                    xml_writer.WriteAttributeString("Name", scriptParam.Name);
                    xml_writer.WriteAttributeString("Value", scriptParam.Value);
                    xml_writer.WriteEndElement();
                }
                xml_writer.WriteEndElement();
                xml_writer.WriteEndElement();
            }
            xml_writer.WriteEndElement();
        }


        private void iSaveUserButtonsIcons()
        {
            string text = GuiCore.MainForm.SettingsOutputPath + "\\UserFiles\\";
            try
            {
                for (int i = 0; i < this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons.Count; i++)
                {
                    if (this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].Icon != null)
                    {
                        if (!Directory.Exists(text))
                        {
                            Directory.CreateDirectory(text);
                        }
                        string text2 = string.Concat(new object[]
                        {
                            text,
                            "icon",
                            i,
                            ".png"
                        });
                        this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].Icon.Save(text2, ImageFormat.Png);
                        this.m_UserToolStrips[this.m_SelectedUserToolStripIndex].ToolBarUserButtons[i].IconFile = text2;
                    }
                }
            }
            catch (Exception ex)
            {
                GuiCore.RstdException(ex.Message, ex.StackTrace);
            }
        }


        private void iAddValueElement(XmlTextWriter xml_writer, string name, string value)
        {
            xml_writer.WriteStartElement(name);
            xml_writer.WriteString(value);
            xml_writer.WriteEndElement();
        }


        public void Load()
        {
            this.Load(this.m_MainSettingsFileName);
            this.Load(this.m_RegisteredDllsFileName);
            this.LoadToolStrips();
        }


        public void LoadToolStrips()
        {
            foreach (UserToolStripInfo user_tool in this.m_UserToolStrips)
            {
                this.Load(user_tool);
            }
        }


        public void Load(UserToolStripInfo user_tool)
        {
            if (string.IsNullOrEmpty(user_tool.ToolBarConfigFile))
            {
                return;
            }
            if (!File.Exists(user_tool.ToolBarConfigFile))
            {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(user_tool.ToolBarConfigFile);
            }
            catch (XmlException ex)
            {
                if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, string.Format("Config file loading error, while loading file \"{0}\"\nDelete invalid file?", ex.SourceUri), ex.StackTrace) == 6U)
                {
                    File.Delete(user_tool.ToolBarConfigFile);
                }
                return;
            }
            XmlNode xmlNode = xmlDocument.SelectSingleNode("GuiConfigRoot");
            if (xmlNode == null)
            {
                GuiCore.ErrorMessage("Error loading file: Invalid file format");
                return;
            }
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (xmlNode.ChildNodes[i].Name.Equals("UserButtons"))
                {
                    if (xmlNode.ChildNodes[i].Attributes["name"] != null)
                    {
                        user_tool.ToolBarName = xmlNode.ChildNodes[i].Attributes["name"].Value;
                    }
                    else
                    {
                        user_tool.ToolBarName = "User ToolBar";
                    }
                    if (xmlNode.ChildNodes[i].Attributes["base_path"] != null)
                    {
                        user_tool.ToolBarBasePath = xmlNode.ChildNodes[i].Attributes["base_path"].Value;
                    }
                    else
                    {
                        user_tool.ToolBarBasePath = "";
                    }
                    this.iReadUserButtons(xmlNode.ChildNodes[i], SettingsType.UserButtons, true, user_tool);
                }
            }
            xmlDocument = null;
        }


        public string ParseBasePath(string base_path)
        {
            string text = "{cc_path}";
            if (base_path.StartsWith(text))
            {
                base_path = base_path.Remove(0, text.Length);
                base_path = base_path.Insert(0, GuiCore.MainForm.RstdSettings.GetClearCasePath());
            }
            return base_path;
        }


        public void Load(string fileName)
        {
            this.Load(fileName, true);
        }


        public void Load(string fileName, bool clear_user_buttons, int toolstrip_index)
        {
            this.m_SelectedUserToolStripIndex = toolstrip_index;
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            if (!File.Exists(fileName))
            {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(fileName);
            }
            catch (XmlException ex)
            {
                if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, string.Format("Config file loading error, while loading file \"{0}\"\nDelete invalid file?", ex.SourceUri), ex.StackTrace) == 6U)
                {
                    File.Delete(fileName);
                }
                return;
            }
            XmlNode xmlNode = xmlDocument.SelectSingleNode("GuiConfigRoot");
            if (xmlNode == null)
            {
                GuiCore.ErrorMessage("Error loading file: Invalid file format");
                return;
            }
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (xmlNode.ChildNodes[i].Name.Equals("UserButtons"))
                {
                    this.iReadUserButtons(xmlNode.ChildNodes[i], SettingsType.UserButtons, clear_user_buttons, this.m_UserToolStrips[this.m_SelectedUserToolStripIndex]);
                }
            }
            xmlDocument = null;
        }


        public void Load(string fileName, bool clear_user_buttons)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            if (!File.Exists(fileName))
            {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(fileName);
            }
            catch (XmlException ex)
            {
                if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, string.Format("Config file loading error, while loading file \"{0}\"\nDelete invalid file?", ex.SourceUri), ex.StackTrace) == 6U)
                {
                    File.Delete(fileName);
                }
                return;
            }
            XmlNode xmlNode = xmlDocument.SelectSingleNode("GuiConfigRoot");
            if (xmlNode == null)
            {
                GuiCore.ErrorMessage("Error loading file: Invalid file format");
                return;
            }
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (xmlNode.ChildNodes[i].Name.Equals("MainSettings"))
                {
                    this.iReadMainSettings(xmlNode.ChildNodes[i]);
                }
                else if (xmlNode.ChildNodes[i].Name.Equals("UserButtons"))
                {
                    this.iReadUserButtons(xmlNode.ChildNodes[i], SettingsType.UserButtons, clear_user_buttons);
                }
                else if (xmlNode.ChildNodes[i].Name.Equals("LuaDllRegisters"))
                {
                    this.iReadLuaDllRegisters(xmlNode.ChildNodes[i]);
                }
            }
            xmlDocument = null;
        }


        public void LoadUserButtons()
        {
            this.Load(this.m_UserButtonsFileName);
        }


        private void iReadMainSettings(XmlNode xmlNode)
        {
            bool flag = false;
            if (xmlNode.Attributes["rttt_version"] != null)
            {
                this.m_RstdVersion = xmlNode.Attributes["rttt_version"].Value;
            }
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                if (xmlNode2.Name.Equals("Output"))
                {
                    if (!bool.TryParse(GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("OnlyUserMessages")), out this.m_bAllowOnlyUserMsgs))
                    {
                        this.m_bAllowOnlyUserMsgs = false;
                    }
                    this.m_OutputFilterExclude = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("FilterExclude"));
                    this.m_OutputFilterInclude = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("FilterInclude"));
                    this.m_OutputZoomFactor = float.Parse(GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("ZoomFactor")), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                    if (xmlNode2.SelectSingleNode("AutoScroll") != null)
                    {
                        RstdGuiSettings.m_bAutoScrollInOutput = bool.Parse(GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("AutoScroll")));
                    }
                }
                else if (xmlNode2.Name.Equals("Scripts"))
                {
                    this.m_LastScriptsRun.Clear();
                    foreach (object obj2 in xmlNode2.SelectSingleNode("LastScripts"))
                    {
                        XmlNode xmlNode3 = (XmlNode)obj2;
                        if (xmlNode3.Name.Equals("Script"))
                        {
                            this.m_LastScriptsRun.Add(GuiCore.GetNodeValue(xmlNode3));
                        }
                    }
                    this.m_LastScriptPath = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastScriptPath"));
                }
                else if (xmlNode2.Name.Equals("Paths"))
                {
                    this.m_LastTreePath = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastTreePath"));
                    this.m_LastDllPath = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastDllPath"));
                    this.m_LastExportTreePath = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastExportTreePath"));
                }
                else if (xmlNode2.Name.Equals("Files"))
                {
                    this.m_LastMonitorFile = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastMonitorFile"));
                    this.m_LastWorksetFile = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastWorkSetFile"));
                    this.m_LastSubSetFile = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LastSubSetFile"));
                }
                else if (xmlNode2.Name.Equals("LuaSettings"))
                {
                    this.m_LuaFamilyFont = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("Font").SelectSingleNode("Family"));
                    this.m_LuaFontBold = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("Font").SelectSingleNode("Bold"));
                    this.m_LuaFontItalic = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("Font").SelectSingleNode("Italic"));
                    this.m_LuaFontSize = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("Font").SelectSingleNode("Size"));
                    this.m_LuaBackGroundColor = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LuaShellBackGround").SelectSingleNode("BackGround"));
                    this.m_LuaForeGroundColor = GuiCore.GetNodeValue(xmlNode2.SelectSingleNode("LuaShellForeGround").SelectSingleNode("ForeGround"));
                }
                else
                {
                    if (xmlNode2.Name.Equals("BrowseTree"))
                    {
                        foreach (XmlNode xmlNode4 in xmlNode2.ChildNodes)
                        {
                            if (xmlNode4.Name == "Columns")
                            {
                                foreach (XmlNode xmlNode5 in xmlNode4)
                                {
                                    if (xmlNode5.Attributes["Name"] != null && xmlNode5.Attributes["Visible"] != null && xmlNode5.Attributes["Index"] != null)
                                    {
                                        RstdConstants.ListViewSubItem_T listViewSubItem_T = RstdConstants.ListViewParseStr2EnumVal(xmlNode5.Attributes["Name"].Value);
                                        RstdGuiSettings.m_bvisible_columns_in_browse_tree_arr[(int)listViewSubItem_T] = bool.Parse(xmlNode5.Attributes["Visible"].Value);
                                        RstdGuiSettings.m_dBTColumnsOrderArr[(int)listViewSubItem_T] = int.Parse(xmlNode5.Attributes["Index"].Value);
                                    }
                                }
                                continue;
                            }
                            if (xmlNode4.Name == "DefaultDisplay")
                            {
                                foreach (XmlNode node in xmlNode4)
                                {
                                    NodeType key = (NodeType)Enum.Parse(typeof(NodeType), GuiCore.GetNodeAttribute(node, "Name"));
                                    DisplayType value = (DisplayType)Enum.Parse(typeof(DisplayType), GuiCore.GetNodeAttribute(node, "Display"));
                                    this.m_DefaultTypesDict[key] = value;
                                }
                                continue;
                            }
                            if (xmlNode4.Name == "SortColumns")
                            {
                                RstdGuiSettings.m_bSortBTColumns = bool.Parse(GuiCore.GetNodeValue(xmlNode4.SelectSingleNode("Sort")));
                            }
                        }
                        continue;
                    }
                    if (xmlNode2.Name.Equals("WorkSet"))
                    {
                        foreach (XmlNode xmlNode6 in xmlNode2.ChildNodes)
                        {
                            if (xmlNode6.Name.Equals("Columns"))
                            {
                                foreach (XmlNode xmlNode7 in xmlNode6.ChildNodes)
                                {
                                    if (xmlNode7.Attributes["Name"] != null && xmlNode7.Attributes["Visible"] != null && xmlNode7.Attributes["Index"] != null)
                                    {
                                        RstdConstants.ListViewSubItem_T listViewSubItem_T = RstdConstants.ListViewParseStr2EnumVal(xmlNode7.Attributes["Name"].Value);
                                        RstdGuiSettings.m_bvisible_columns_in_work_set_arr[(int)listViewSubItem_T] = bool.Parse(xmlNode7.Attributes["Visible"].Value);
                                        RstdGuiSettings.m_dWSColumnsOrderArr[(int)listViewSubItem_T] = int.Parse(xmlNode7.Attributes["Index"].Value);
                                    }
                                }
                                continue;
                            }
                            if (xmlNode6.Name.Equals("SortColumns"))
                            {
                                RstdGuiSettings.m_bSortWSColumns = bool.Parse(GuiCore.GetNodeValue(xmlNode6.SelectSingleNode("Sort")));
                            }
                            else if (xmlNode6.Name.Equals("DisplayFunctions"))
                            {
                                RstdGuiSettings.m_bDisplayFunctions = bool.Parse(GuiCore.GetNodeValue(xmlNode6.SelectSingleNode("Display")));
                            }
                        }
                        continue;
                    }
                    if (xmlNode2.Name.Equals("General"))
                    {
                        foreach (XmlNode xmlNode8 in xmlNode2.ChildNodes)
                        {
                            if (xmlNode8.Name.Equals("SaveDisplayInTxt"))
                            {
                                RstdGuiSettings.m_bSaveDisplayInTxt = bool.Parse(GuiCore.GetNodeValue(xmlNode8));
                            }
                            if (xmlNode8.Name.Equals("DisableFadeOutSplash"))
                            {
                                RstdGuiSettings.m_bDisableFadeOutSplash = bool.Parse(GuiCore.GetNodeValue(xmlNode8));
                            }
                        }
                        continue;
                    }
                    if (xmlNode2.Name.Equals("FindForm"))
                    {
                        foreach (XmlNode xmlNode9 in xmlNode2.ChildNodes[0])
                        {
                            RstdGuiSettings.m_ListFindChosenItemsFromLoad.Insert(0, xmlNode9.Attributes["str"].Value);
                        }
                        continue;
                    }
                    if (xmlNode2.Name.Equals("ToolBars"))
                    {
                        foreach (XmlNode xmlNode10 in xmlNode2.ChildNodes)
                        {
                            if (xmlNode10.Name.Equals("StandardButtons"))
                            {
                                this.iReadStandardButtons(xmlNode10);
                            }
                            else if (xmlNode10.Attributes["Name"].Value.Equals("STATUS_BAR"))
                            {
                                RstdGuiSettings.m_bCheckedToolBarsStatusBar = bool.Parse(xmlNode10.Attributes["Visible"].Value);
                            }
                            else
                            {
                                RstdConstants.CheckedToolBars checkedToolBars = RstdConstants.ToolBarParseStr2EnumVal(xmlNode10.Attributes["Name"].Value);
                                RstdGuiSettings.m_bCheckedToolBarsArr[(int)checkedToolBars] = bool.Parse(xmlNode10.Attributes["Visible"].Value);
                            }
                        }
                        continue;
                    }
                    if (xmlNode2.Name.Equals("UserToolStrips"))
                    {
                        flag = true;
                        this.iReadUserToolStrips(xmlNode2);
                    }
                }
            }
            if (!flag)
            {
                string text = GuiCore.MainForm.SettingsOutputPath + "\\ToolBars";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                if ("2.0.0.34".CompareTo(this.m_RstdVersion) > 0)
                {
                    try
                    {
                        string text2 = Path.Combine(text, "UserButtons.xml");
                        File.Copy(this.m_UserButtonsFileName, text2, true);
                        UserToolStripInfo item = new UserToolStripInfo("", "", text2, true);
                        this.m_UserToolStrips.Add(item);
                    }
                    catch (Exception ex)
                    {
                        GuiCore.RstdException("Couldn't remove file", ex.StackTrace);
                    }
                }
            }
        }


        private void iReadLuaDllRegisters(XmlNode xmlNode)
        {
            bool use = false;
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                if (xmlNode2.Name.Equals("DllRegister"))
                {
                    string nodeAttribute = GuiCore.GetNodeAttribute(xmlNode2, "Use");
                    if (!string.IsNullOrEmpty(nodeAttribute))
                    {
                        use = bool.Parse(nodeAttribute);
                    }
                    string nodeAttribute2 = GuiCore.GetNodeAttribute(xmlNode2, "Package");
                    string nodeAttribute3 = GuiCore.GetNodeAttribute(xmlNode2, "Path");
                    LuaRegisterInfo item = new LuaRegisterInfo(use, nodeAttribute2, nodeAttribute3);
                    this.m_LuaRegisterInfos.Add(item);
                }
            }
        }


        private void iReadUserToolStrips(XmlNode xmlNode)
        {
            string text = GuiCore.MainForm.SettingsOutputPath + "\\ToolBars";
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            if ("0.0.0.34".CompareTo(this.m_RstdVersion) >= 0)
            {
                string text2 = Path.Combine(text, "UserButtons.xml");
                try
                {
                    File.Copy(this.m_UserButtonsFileName, text2, true);
                    UserToolStripInfo item = new UserToolStripInfo("", "", text2, true);
                    this.m_UserToolStrips.Add(item);
                    return;
                }
                catch (Exception ex)
                {
                    GuiCore.RstdException("Couldn't remove file", ex.StackTrace);
                    return;
                }
            }
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                int rowIndex = 0;
                int colIndex = 0;
                string nodeAttribute = GuiCore.GetNodeAttribute(xmlNode2, "Path");
                bool show = bool.Parse(GuiCore.GetNodeAttribute(xmlNode2, "Visible"));
                if (xmlNode2.Attributes["row"] != null)
                {
                    rowIndex = int.Parse(GuiCore.GetNodeAttribute(xmlNode2, "row"));
                    colIndex = int.Parse(GuiCore.GetNodeAttribute(xmlNode2, "col"));
                }
                UserToolStripInfo item = new UserToolStripInfo("", "", nodeAttribute, show);
                this.m_UserToolStrips.Add(item);
                this.m_UserToolStrips[this.m_UserToolStrips.Count - 1].RowIndex = rowIndex;
                this.m_UserToolStrips[this.m_UserToolStrips.Count - 1].ColIndex = colIndex;
            }
        }


        private void iReadStandardButtons(XmlNode xmlNode)
        {
            string nodeAttribute = GuiCore.GetNodeAttribute(xmlNode, "Size");
            if (nodeAttribute != null)
            {
                this.m_StandardBtnsSize = (StandardButtonsSize)Enum.Parse(typeof(StandardButtonsSize), nodeAttribute);
            }
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                if (xmlNode2.Name.Equals("StandardButton"))
                {
                    string nodeAttribute2 = GuiCore.GetNodeAttribute(xmlNode2, "Title");
                    string nodeAttribute3 = GuiCore.GetNodeAttribute(xmlNode2, "Visible");
                    if (nodeAttribute2 != null && nodeAttribute3 != null)
                    {
                        bool flag = false;
                        foreach (ToolBarBtnInfo toolBarBtnInfo in this.m_StandardButtons)
                        {
                            if (toolBarBtnInfo.Title == nodeAttribute2)
                            {
                                toolBarBtnInfo.Show = bool.Parse(nodeAttribute3);
                            }
                        }
                        int num = 0;
                        while (num < GuiCore.MainForm.MainToolBar.Items.Count && !flag)
                        {
                            if (GuiCore.MainForm.MainToolBar.Items[num] is ToolStripButton && GuiCore.MainForm.MainToolBar.Items[num].Text == nodeAttribute2)
                            {
                                bool visible = bool.Parse(nodeAttribute3);
                                GuiCore.MainForm.MainToolBar.Items[num].Visible = visible;
                                if (num > 0)
                                {
                                    GuiCore.MainForm.MainToolBar.Items[num - 1].Visible = visible;
                                }
                                flag = true;
                            }
                            num++;
                        }
                    }
                }
            }
        }


        private void iReadUserButtons(XmlNode xmlNode, SettingsType buttons_type, bool clear_user_buttons, UserToolStripInfo user_tool)
        {
            bool show = true;
            List<UserButtonInfo> toolBarUserButtons = user_tool.ToolBarUserButtons;
            if (clear_user_buttons)
            {
                toolBarUserButtons.Clear();
            }
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                if (xmlNode2.Name.Equals("UserButton"))
                {
                    string nodeAttribute = GuiCore.GetNodeAttribute(xmlNode2, "Visible");
                    if (nodeAttribute != null)
                    {
                        show = bool.Parse(nodeAttribute);
                    }
                    string nodeAttribute2 = GuiCore.GetNodeAttribute(xmlNode2, "Title");
                    string text = GuiCore.GetNodeAttribute(xmlNode2, "Script");
                    if (!string.IsNullOrEmpty(user_tool.ToolBarBasePath) && text.StartsWith(user_tool.ToolBarBasePath))
                    {
                        text = text.Remove(0, user_tool.ToolBarBasePath.Length);
                    }
                    string nodeAttribute3 = GuiCore.GetNodeAttribute(xmlNode2, "IconFile");
                    string nodeAttribute4 = GuiCore.GetNodeAttribute(xmlNode2, "ToolTip");
                    string nodeAttribute5 = GuiCore.GetNodeAttribute(xmlNode2, "UserColor");
                    string nodeAttribute6 = GuiCore.GetNodeAttribute(xmlNode2, "SourceType");
                    string text2 = GuiCore.GetNodeAttribute(xmlNode2, "FunctionSource");
                    if (text2 == null)
                    {
                        text2 = "";
                    }
                    else if (!string.IsNullOrEmpty(user_tool.ToolBarBasePath) && text2.StartsWith(user_tool.ToolBarBasePath))
                    {
                        text2 = text2.Remove(0, user_tool.ToolBarBasePath.Length);
                    }
                    LuaSourceType source_type;
                    if (nodeAttribute6 != null)
                    {
                        if (nodeAttribute6 == "String")
                        {
                            source_type = LuaSourceType.Function;
                        }
                        else if (nodeAttribute6 == "Script")
                        {
                            source_type = LuaSourceType.LuaString;
                        }
                        else
                        {
                            source_type = (LuaSourceType)Enum.Parse(typeof(LuaSourceType), nodeAttribute6);
                        }
                    }
                    else
                    {
                        source_type = LuaSourceType.File;
                    }
                    UserButtonInfo userButtonInfo = new UserButtonInfo(show, nodeAttribute3, nodeAttribute5, nodeAttribute2, nodeAttribute4, text, source_type, text2);
                    if (xmlNode2.ChildNodes.Count > 0 && xmlNode2.FirstChild.Name == "Params")
                    {
                        foreach (object obj2 in xmlNode2.FirstChild.ChildNodes)
                        {
                            XmlNode node = (XmlNode)obj2;
                            ScriptParam scriptParam = new ScriptParam();
                            scriptParam.Type = (ScriptParamType)Enum.Parse(typeof(ScriptParamType), GuiCore.GetNodeAttribute(node, "Type"));
                            scriptParam.Name = GuiCore.GetNodeAttribute(node, "Name");
                            scriptParam.Value = GuiCore.GetNodeAttribute(node, "Value");
                            userButtonInfo.Params.Add(scriptParam);
                        }
                    }
                    toolBarUserButtons.Add(userButtonInfo);
                }
            }
        }


        private void iReadUserButtons(XmlNode xmlNode, SettingsType buttons_type, bool clear_user_buttons)
        {
            bool show = true;
            List<UserButtonInfo> userButtons = this.m_UserButtons;
            if (clear_user_buttons)
            {
                userButtons.Clear();
            }
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                if (xmlNode2.Name.Equals("UserButton"))
                {
                    string nodeAttribute = GuiCore.GetNodeAttribute(xmlNode2, "Visible");
                    if (nodeAttribute != null)
                    {
                        show = bool.Parse(nodeAttribute);
                    }
                    string nodeAttribute2 = GuiCore.GetNodeAttribute(xmlNode2, "Title");
                    string nodeAttribute3 = GuiCore.GetNodeAttribute(xmlNode2, "Script");
                    string nodeAttribute4 = GuiCore.GetNodeAttribute(xmlNode2, "IconFile");
                    string nodeAttribute5 = GuiCore.GetNodeAttribute(xmlNode2, "ToolTip");
                    string nodeAttribute6 = GuiCore.GetNodeAttribute(xmlNode2, "UserColor");
                    string nodeAttribute7 = GuiCore.GetNodeAttribute(xmlNode2, "SourceType");
                    string text = GuiCore.GetNodeAttribute(xmlNode2, "FunctionSource");
                    if (text == null)
                    {
                        text = "";
                    }
                    LuaSourceType source_type;
                    if (nodeAttribute7 != null)
                    {
                        if (nodeAttribute7 == "String")
                        {
                            source_type = LuaSourceType.Function;
                        }
                        else if (nodeAttribute7 == "Script")
                        {
                            source_type = LuaSourceType.LuaString;
                        }
                        else
                        {
                            source_type = (LuaSourceType)Enum.Parse(typeof(LuaSourceType), nodeAttribute7);
                        }
                    }
                    else
                    {
                        source_type = LuaSourceType.File;
                    }
                    UserButtonInfo userButtonInfo = new UserButtonInfo(show, nodeAttribute4, nodeAttribute6, nodeAttribute2, nodeAttribute5, nodeAttribute3, source_type, text);
                    if (xmlNode2.ChildNodes.Count > 0 && xmlNode2.FirstChild.Name == "Params")
                    {
                        foreach (object obj2 in xmlNode2.FirstChild.ChildNodes)
                        {
                            XmlNode node = (XmlNode)obj2;
                            ScriptParam scriptParam = new ScriptParam();
                            scriptParam.Type = (ScriptParamType)Enum.Parse(typeof(ScriptParamType), GuiCore.GetNodeAttribute(node, "Type"));
                            scriptParam.Name = GuiCore.GetNodeAttribute(node, "Name");
                            scriptParam.Value = GuiCore.GetNodeAttribute(node, "Value");
                            userButtonInfo.Params.Add(scriptParam);
                        }
                    }
                    userButtons.Add(userButtonInfo);
                }
            }
        }


        private Point iStringToPoint(string str_point)
        {
            string[] array = this.iGetValuesFromParenthesis(str_point);
            return new Point(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
        }


        private Size iStringToSize(string str_point)
        {
            string[] array = this.iGetValuesFromParenthesis(str_point);
            return new Size(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
        }


        private string[] iGetValuesFromParenthesis(string str)
        {
            str = str.Trim(new char[]
            {
                '{',
                '}'
            });
            string[] array = str.Split(new char[]
            {
                ','
            });
            array[0] = array[0].Remove(0, array[0].IndexOf('=') + 1);
            array[1] = array[1].Remove(0, array[1].IndexOf('=') + 1);
            return array;
        }


        private float m_OutputZoomFactor = 1f;


        private string m_OutputFilterExclude;


        private string m_OutputFilterInclude;


        private List<string> m_LastScriptsRun;


        private string m_LastTreePath;


        private string m_LastExportTreePath;


        private string m_LastMonitorFile;


        private string m_LastScriptPath;


        private string m_LastDllPath;


        private string m_LastUserButtonsFile;


        private string m_LastWorksetFile;


        private string m_LastSubSetFile;


        private List<UserButtonInfo> m_UserButtons;


        private List<UserToolStripInfo> m_UserToolStrips;


        private List<ToolBarBtnInfo> m_StandardButtons;


        private List<LuaRegisterInfo> m_LuaRegisterInfos;


        private string m_MainSettingsFileName;


        private string m_UserButtonsFileName;


        private string m_DefaultUserButtonsFileName;


        private string m_RegisteredDllsFileName;


        private string m_LuaFamilyFont;


        private string m_LuaFontBold;


        private string m_LuaFontItalic;


        private string m_LuaFontSize;


        private string m_LuaBackGroundColor;


        private string m_LuaForeGroundColor;


        private static bool[] m_bvisible_columns_in_browse_tree_arr;


        private static bool[] m_bvisible_columns_in_work_set_arr;


        private static bool[] m_bCheckedToolBarsArr;


        private static int[] m_dBTColumnsOrderArr;


        private static int[] m_dWSColumnsOrderArr;


        private static bool m_bCheckedToolBarsStatusBar;


        private static bool m_bSortBTColumns;


        private static bool m_bSortWSColumns;


        private static bool m_bDisplayFunctions;


        private static bool m_bSaveDisplayInTxt;


        private static bool m_bDisableFadeOutSplash;


        private static bool m_bAutoScrollInOutput;


        private static ArrayList m_ListFindChosenItemsFromLoad;


        private StandardButtonsSize m_StandardBtnsSize;


        private Dictionary<NodeType, DisplayType> m_DefaultTypesDict;


        private bool m_bAllowOnlyUserMsgs;


        private int m_SelectedUserToolStripIndex;


        private string m_RstdVersion;


        private static RstdGuiSettings defaultInstance = new RstdGuiSettings();
    }
}
