using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace RSTD
{

    public class RstdSettings
    {



        public string OutputPath
        {
            get
            {
                return this.m_OutputPath;
            }
            set
            {
                this.m_OutputPath = value;
            }
        }


        public RstdSettings()
        {
            XmlNode config_root_node = null;
            bool xml_loaded_ok = this.ibLoadXmlConfigFile(this.iGetSettingsFileName_FullPath(), ref config_root_node);
            this.m_OutputPath = this.iGetInitialOutputPath(xml_loaded_ok, config_root_node);
        }


        private string iGetInitialOutputPath(bool xml_loaded_ok, XmlNode config_root_node)
        {
            string text = "";
            if (!xml_loaded_ok)
            {
                return GuiCore.MainForm.SettingsOutputPath + Path.DirectorySeparatorChar.ToString() + "Output";
            }
            if (string.IsNullOrEmpty(text))
            {
                return GuiCore.MainForm.SettingsOutputPath + Path.DirectorySeparatorChar.ToString() + "Output";
            }
            return text;
        }


        public bool bHasClients()
        {
            string value = null;
            int num = 0;
            XmlNode xmlNode;
            GuiCore.GetNodeFromPath(SettingsPaths.Clients, out xmlNode);
            foreach (object obj in xmlNode)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                this.ibGetValueFromPath(string.Format(SettingsPaths.ClientsDll, num), out value);
                string value2;
                this.ibGetValueFromPath(string.Format(SettingsPaths.ClientsPriority, num), out value2);
                string a;
                this.ibGetValueFromPath(string.Format(SettingsPaths.ClientsUse, num), out a);
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value2) && a == "TRUE")
                {
                    return true;
                }
                num++;
            }
            return false;
        }


        public void LoadSettings()
        {
            this.LoadSettings(this.iGetSettingsFileName_FullPath());
        }


        public void LoadSettings(string fileName)
        {
            if (File.Exists(fileName))
            {
                this.ibInsertConfigToTree(fileName);
            }
            else if (this.ibSetValueForPath(SettingsPaths.OutputPath, this.m_OutputPath))
            {
                this.SaveSettings();
            }
            if (Program.ClientDll != null)
            {
                this.iSetCmdLineDll();
            }
        }


        private bool ibLoadXmlConfigFile(string fileName, ref XmlNode root_node)
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
                if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, string.Format("Config file loading error, while loading file \"{0}\"\nDelete invalid file?", ex.SourceUri), ex.StackTrace) == 6U)
                {
                    File.Delete(fileName);
                }
                return false;
            }
            if (xmlDocument.SelectSingleNode("ConfigRoot") != null)
            {
                if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, string.Format("\"{0}\" has obsolete xml format.Not supported yet\nDelete this file?", fileName)) == 6U)
                {
                    File.Delete(fileName);
                }
                return false;
            }
            if (xmlDocument.SelectSingleNode("TreeRoot") != null)
            {
                root_node = xmlDocument.SelectSingleNode("TreeRoot");
                return true;
            }
            return false;
        }


        private bool ibInsertConfigToTree(string fileName)
        {
            XmlNode xmlNode = null;
            if (!this.ibLoadXmlConfigFile(fileName, ref xmlNode))
            {
                return false;
            }
            GuiCore.Load(fileName);
            string outputPath = this.GetOutputPath();
            if (string.IsNullOrEmpty(outputPath))
            {
                this.ibSetValueForPath(SettingsPaths.OutputPath, this.m_OutputPath);
            }
            else
            {
                this.m_OutputPath = outputPath;
            }
            return true;
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


        private void iSetCmdLineDll()
        {
            bool flag = false;
            int num = 0;
            string a = "";
            XmlNode xmlNode;
            GuiCore.GetNodeFromPath(SettingsPaths.Clients, out xmlNode);
            if (File.Exists(Program.ClientDll))
            {
                foreach (object obj in xmlNode.ChildNodes)
                {
                    XmlNode xmlNode2 = (XmlNode)obj;
                    this.ibGetValueFromPath(string.Format(SettingsPaths.ClientsDll, num), out a);
                    if (a == Program.ClientDll)
                    {
                        flag = true;
                        this.ibSetValueForPath(string.Format(SettingsPaths.ClientsUse, num), "TRUE");
                    }
                    else
                    {
                        this.ibSetValueForPath(string.Format(SettingsPaths.ClientsUse, num), "FALSE");
                    }
                    num++;
                }
                if (!flag)
                {
                    this.ibSetValueForPath(string.Format(SettingsPaths.ClientsUse, 0), "TRUE");
                    this.ibSetValueForPath(string.Format(SettingsPaths.ClientsPriority, 0), ((int)Enum.Parse(typeof(Client_Priority), "LOW")).ToString());
                    this.ibSetValueForPath(string.Format(SettingsPaths.ClientsDll, 0), Program.ClientDll);
                }
                this.SaveSettings();
                return;
            }
            GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Error Loading client\nCould not find client DLL:\n" + Program.ClientDll + "\nUsing Client from setting instead.");
        }


        public string GetInputPath()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.InputPath, out result);
            return result;
        }


        public string GetOutputPath()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.OutputPath, out result);
            return result;
        }


        public string GetConfigPath()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.ConfigPath, out result);
            return result;
        }


        public string GetLuaPath()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.LuaPath, out result);
            return result;
        }


        public string GetClearCasePath()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.ClearCasePath, out result);
            return result;
        }


        public bool GetAutomationMode()
        {
            bool result = false;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.AutomationMode, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public bool GetWarnBeforeLogFilesDeletion()
        {
            bool result = true;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.WarnBeforeLogFilesDeletion, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public int GetMaxLogFiles()
        {
            int result = 25;
            string s = "";
            if (this.ibGetValueFromPath(SettingsPaths.MaxLogFiles, out s))
            {
                result = int.Parse(s);
            }
            return result;
        }


        public int GetLogFilesToLeave()
        {
            int result = 5;
            string s = "";
            if (this.ibGetValueFromPath(SettingsPaths.LogFilesToLeave, out s))
            {
                result = int.Parse(s);
            }
            return result;
        }


        public bool IsVerbose()
        {
            bool result = true;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.IsVerbosePath, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public WarningLevel GetWarningLevel()
        {
            string value = "";
            WarningLevel result = WarningLevel.NORMAl;
            if (this.ibGetValueFromPath(SettingsPaths.WarningLvlPath, out value))
            {
                result = (WarningLevel)Enum.Parse(typeof(WarningLevel), value, true);
            }
            return result;
        }


        public bool DisplayDateTime()
        {
            bool result = true;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.DisplayDateTime, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public string DateTimeFormat()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.DateTimeFormat, out result);
            return result;
        }


        public bool IsAutoUpdateEnabled()
        {
            bool result = true;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.AutoUpdateEnabled, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public float GetAutoUpdateInterval()
        {
            float result = 1f;
            string s = "";
            if (this.ibGetValueFromPath(SettingsPaths.AutoUpdateInterval, out s))
            {
                result = float.Parse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }
            return result;
        }


        public bool GetMonitorOneClickStart()
        {
            bool result = false;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.OneClickStartPath, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public string GetALXmlPath()
        {
            string result = "";
            this.ibGetValueFromPath(SettingsPaths.AL_Xml, out result);
            return result;
        }


        public string GetClientXmlPath()
        {
            return this.iGetClientSetting(SettingsPaths.ClientsXml);
        }


        public string GetClientGuiDllPath()
        {
            return this.iGetClientSetting(SettingsPaths.ClientsGuiDll);
        }


        private string iGetClientSetting(string path)
        {
            string text = null;
            int num = 0;
            string a = "";
            string value = "";
            XmlNode xmlNode;
            GuiCore.GetNodeFromPath(SettingsPaths.Clients, out xmlNode);
            foreach (object obj in xmlNode.ChildNodes)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                this.ibGetValueFromPath(string.Format(SettingsPaths.ClientsUse, num), out a);
                this.ibGetValueFromPath(string.Format(SettingsPaths.ClientsDll, num), out value);
                if (a == "TRUE" && !string.IsNullOrEmpty(value))
                {
                    this.ibGetValueFromPath(string.Format(path, num), out text);
                    return text.Trim();
                }
                num++;
            }
            return null;
        }


        public XmlNode GetSettingsFunction(string func_name)
        {
            XmlNode xmlNode;
            GuiCore.GetNodeFromPath(SettingsPaths.Methods, out xmlNode);
            foreach (object obj in xmlNode)
            {
                XmlNode xmlNode2 = (XmlNode)obj;
                if (xmlNode2.Attributes["name"].Value == func_name)
                {
                    return xmlNode2;
                }
            }
            return null;
        }


        public bool IsSubsetAskSaveOnClose()
        {
            bool result = true;
            string value = "";
            if (this.ibGetValueFromPath(SettingsPaths.SubsetAskSave, out value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public bool UseStartupScript()
        {
            bool result = false;
            if (ibGetValueFromPath(SettingsPaths.UseStartupScript, out string value))
            {
                result = bool.Parse(value);
            }
            return result;
        }


        public string GetStartupScriptPath()
        {
            string result = "";
            ibGetValueFromPath(SettingsPaths.StartupScriptPath, out result);
            return result;
        }


        public void SaveSettings()
        {
            this.SaveSettings(this.iGetSettingsFileName_FullPath());
        }


        public void SaveSettings(string fileName)
        {
            GuiCore.Save(GuiCore.GetXmlTree().DocumentElement.FirstChild, fileName);
            GuiCore.VerbosePrint(string.Format("RSTD.SaveSettings(): Settings saved to \"{0}\"\n", fileName));
        }


        public void LoadALXml()
        {
            GuiCore.VerbosePrint("RSTD.AL_LoadXml()\n");
            string text = this.GetALXmlPath().Trim();
            if (!string.IsNullOrEmpty(text))
            {
                GuiCore.Load(text);
            }
        }


        public void LoadClientXml()
        {
            GuiCore.VerbosePrint("RSTD.Client_LoadXml()\n");
            string text = this.GetClientXmlPath().Trim();
            if (!string.IsNullOrEmpty(text))
            {
                GuiCore.Load(text);
            }
        }


        private bool ibGetValueFromPath(string xml_path, out string value_str)
        {
            value_str = "";
            if (GuiCore.GetNodeFromPath(xml_path, out XmlNode xmlNode, false))
            {
                value_str = GuiCore.GetActualVarValue(xml_path);
                return true;
            }
            return false;
        }


        private bool ibSetValueForPath(string xml_path, string value_str)
        {
            XmlNode var_node;
            return GuiCore.GetNodeFromPath(xml_path, out var_node, false) && GuiCore.bSetLoadedValue(var_node, value_str);
        }


        private string m_OutputPath;
    }
}
