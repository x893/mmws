using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LuaInterface;
using LuaRegister;
using Rstd.Controls.ContainerListViews;
using RSTD.Properties;
using RstdGuiClientBase;
using RstdXml;

namespace RSTD
{
    public delegate uint ConsoleMessageBoxDel(uint message_type, string msg);

    public static class GuiCore
	{
		public static void Init(frmMain main_form, BrowseTree browseTreeForm, RstdSettings rstd_settings, ConsolePrintLevelDel dAlwaysPrint, ConsolePrint dVerbosePrint, ConsoleMessageDel dConsoleMsg, RefreshGuiDel dRefresgGui, ConsoleMessageBoxDel dConsoleMsgBox)
		{
			m_MainForm = main_form;
			m_BrowseTree = browseTreeForm;
			m_RstdSettings = rstd_settings;
			m_dAlwaysPrint = dAlwaysPrint;
			m_dVerbosePrint = dVerbosePrint;
			m_dCoreMsg = dConsoleMsg;
			m_dRefreshGui = dRefresgGui;
			m_dCoreMsgBox = dConsoleMsgBox;
			m_BuildStatus = EBuildStatus.AL_UnBuilt;
			m_pUnManagedConsolePrint = new UnManagedConsolePrintDel(AlwaysPrint);
			m_pUnManagedCoreMessage = new UnManagedCoreMessageDel(iDoCoreMsg);
			m_pUnManagedCoreMessageBox = new UnManagedCoreMessageBoxDel(iDoMsgBox);
			m_UpdateMonitorsVars = new UpdateMonitoredVarsDel(UpdateMonitoredVarsDisplay);
			StringBuilder stringBuilder = new StringBuilder(102400);
			CoreImports.ClientCmdParams_T pCmdLine;
			pCmdLine.Data = IntPtr.Zero;
			pCmdLine.DataLength = 0U;
			pCmdLine.DataVersion = 0U;
			CoreImports.RtttCore_Init(CoreImports.RtttExecutionContext_T.RTTT_CONTEXT__MASTER_SLAVE, pCmdLine, m_pUnManagedConsolePrint, m_pUnManagedCoreMessage, stringBuilder, m_pUnManagedCoreMessageBox, m_UpdateMonitorsVars);
			m_XmlParser = new RstdXmlParser(m_dVerbosePrint);
			m_XmlTreeWrapper = new RstdXmlTreeWrapper(stringBuilder.ToString(), m_dVerbosePrint);
			m_XmlTreeWrapper.AppendGuiAttributesToXmlTree();
		}


		public static void Close()
		{
			CoreImports.RtttCore_Close();
			m_dAlwaysPrint = null;
			m_dVerbosePrint = null;
			m_dCoreMsg = null;
			m_dCoreMsgBox = null;
			m_dRefreshGui = null;
			m_pUnManagedConsolePrint = null;
			m_pUnManagedCoreMessage = null;
			m_pUnManagedCoreMessageBox = null;
			m_UpdateMonitorsVars = null;
			m_XmlTreeWrapper = null;
			m_XmlParser = null;
			m_ClocksList = null;
		}


		public static Image ResizeImage(Image img, Size size)
		{
			int width = img.Width;
			int height = img.Height;
			float num = (float)size.Width / (float)width;
			float num2 = (float)size.Height / (float)height;
			float num3;
			if (num2 < num)
			{
				num3 = num2;
			}
			else
			{
				num3 = num;
			}
			int width2 = (int)((float)width * num3);
			int height2 = (int)((float)height * num3);
			Bitmap bitmap = new Bitmap(width2, height2);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(img, 0, 0, width2, height2);
			graphics.Dispose();
			return bitmap;
		}

		public static Icon ImageToIcon(Image image)
		{
			return Icon.FromHandle(((Bitmap)image).GetHicon());
		}

		public static Form GetOpenedForm(string form_name)
		{
			foreach (object obj in Application.OpenForms)
			{
				Form form = (Form)obj;
				if (form.Name == form_name)
				{
					return form;
				}
			}
			return null;
		}

		public static void OpenFindForm(string base_path)
		{
			m_FindForm = new frmFind(base_path);
			m_FindForm.Show(m_MainForm.DockingPanel);
			m_FindForm.SearchForComboBox.Focus();
		}


		public static void VerbosePrint(string text)
		{
			if (m_dVerbosePrint != null)
			{
				m_dVerbosePrint(text);
			}
		}

		public static void AlwaysPrint(uint print_level, uint text_color, string text)
		{
			if (m_dAlwaysPrint != null)
			{
				m_dAlwaysPrint(print_level, text_color, text);
			}
		}

		public static void ConfigSettings(string fileName)
		{
			CoreImports.bConfigSettings();
		}

		public static void Build()
		{
			if (!IsOnGuiThread())
			{
				iBuild();
				return;
			}
			new CoreAsyncDel(iBuild).BeginInvoke(new AsyncCallback(iBuildAsyncThreadCompleted), null);
		}

		public static void UnBuild()
		{
			if (!IsOnGuiThread() || m_MainForm.bIsRstdClosing)
			{
				iUnBuild();
				return;
			}
			new CoreAsyncDel(iUnBuild).BeginInvoke(new AsyncCallback(iUnBuildAsyncThreadCompleted), null);
		}

		public static void Go()
		{
			if (!IsOnGuiThread())
			{
				iGo();
				return;
			}
			new CoreAsyncDel(iGo).BeginInvoke(new AsyncCallback(iGoAsyncThreadCompleted), null);
		}

		public static void Stop()
		{
			if (!IsOnGuiThread())
			{
				iStop();
				return;
			}
			new CoreAsyncDel(iStop).BeginInvoke(new AsyncCallback(iStopAsyncThreadCompleted), null);
		}

		public static void SetAllNodesUpdateStatus(bool status)
		{
			m_XmlTreeWrapper.SetAllNodesUpdateStatus(status);
		}

		public static void Abort()
		{
			if (!IsOnGuiThread())
			{
				iAbort();
				return;
			}
			new CoreAsyncDel(iAbort).BeginInvoke(new AsyncCallback(iStopAsyncThreadCompleted), null);
		}

		public static void Transmit(string[] fullPaths, ReceiveTransmit_T transmit_type, bool is_script_operation)
		{
			XmlNode item = null;
			List<XmlNode> list = new List<XmlNode>();
			for (int i = 0; i < fullPaths.Length; i++)
			{
				if (GetNodeFromPath(fullPaths[i], out item))
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				Transmit(list, transmit_type, is_script_operation);
			}
		}

		public static void Transmit(XmlNode node, ReceiveTransmit_T transmit_type, bool is_script_operation)
		{
			Transmit(new List<XmlNode>
			{
				node
			}, transmit_type, is_script_operation);
		}

		public static void Transmit(List<XmlNode> nodes, ReceiveTransmit_T transmit_type, bool is_script_operation)
		{
			Transmit(nodes, transmit_type, is_script_operation, null);
		}

		public static void Transmit(List<XmlNode> nodes, ReceiveTransmit_T transmit_type, bool is_script_operation, frmSubSet sub_set)
		{
			if (transmit_type == ReceiveTransmit_T.XML_PATH && m_XmlParser.bNodesContainHwInfo(nodes))
			{
				m_DisableGui = true;
				RefreshGui();
				if (sub_set != null)
				{
					sub_set.RefreshDisplay();
				}
			}
			if (is_script_operation)
			{
				iTransmitAsync(transmit_type, nodes, sub_set);
				m_DisableGui = false;
				RefreshGui();
				if (sub_set != null)
				{
					sub_set.RefreshDisplay();
					return;
				}
			}
			else
			{
				new CoreAsyncDel_OperationTypeNodeListAndSubSet(iTransmitAsync).BeginInvoke(transmit_type, nodes, sub_set, new AsyncCallback(iAsyncThreadCompleted), null);
			}
		}

		public static void Transmit(string path, ReceiveTransmit_T transmit_type, bool is_script_operation)
		{
			Transmit(new string[]
			{
				path
			}, transmit_type, is_script_operation);
		}

		public static bool Receive(string[] fullPaths, ReceiveTransmit_T receive_type, bool is_script_operation)
		{
			List<XmlNode> list = new List<XmlNode>();
			XmlNode item = null;
			bool result = true;
			for (int i = 0; i < fullPaths.Length; i++)
			{
				if (GetNodeFromPath(fullPaths[i], out item))
				{
					list.Add(item);
				}
				else
				{
					result = false;
				}
			}
			if (list.Count > 0)
			{
				Receive(list, receive_type, is_script_operation);
			}
			return result;
		}


		public static void Receive(XmlNode node, ReceiveTransmit_T receive_type, bool is_script_operation)
		{
			Receive(new List<XmlNode>
			{
				node
			}, receive_type, is_script_operation);
		}


		public static void Receive(List<XmlNode> nodes, ReceiveTransmit_T receive_type, bool is_script_operation)
		{
			Receive(nodes, receive_type, is_script_operation, null);
		}


		public static void Receive(List<XmlNode> nodes, ReceiveTransmit_T receive_type, bool is_script_operation, frmSubSet sub_set)
		{
			if (receive_type == ReceiveTransmit_T.XML_PATH && (iCountVarsUnderNodePath(nodes[0]) > 1000 || m_XmlParser.bNodesContainHwInfo(nodes)))
			{
				m_DisableGui = true;
				RefreshGui();
				if (sub_set != null)
				{
					sub_set.RefreshDisplay();
				}
			}
			if (is_script_operation || receive_type == ReceiveTransmit_T.ARRAY_VAR || receive_type == ReceiveTransmit_T.RECEIVE_AND_GET || receive_type == ReceiveTransmit_T.AUTO_UPDATED_VAR)
			{
				iReceiveAsync(receive_type, nodes, sub_set);
				m_DisableGui = false;
				RefreshGui();
				if (sub_set != null)
				{
					sub_set.RefreshDisplay();
					return;
				}
			}
			else
			{
				new CoreAsyncDel_OperationTypeNodeListAndSubSet(iReceiveAsync).BeginInvoke(receive_type, nodes, sub_set, new AsyncCallback(iAsyncThreadCompleted), null);
			}
		}


		public static bool Receive(string path, ReceiveTransmit_T receive_type, bool is_script_operation)
		{
			return Receive(new string[]
			{
				path
			}, receive_type, is_script_operation);
		}


		public static void LoadExpose(string fileName)
		{
			AlwaysPrint(string.Format("RSTD.LoadExpose(\"{0}\")\n", fileName));
			if (!m_bIsAlBuilt)
			{
				ErrorMessage("Load Expose Failed. Abstraction Layer must be built first.");
				return;
			}
			if (!File.Exists(fileName))
			{
				ErrorMessage("Load Expose Failed. File name \"" + fileName + "\" Not found");
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.Load(fileName);
			}
			catch (Exception ex)
			{
				string text = string.Format("Load Expose Failed. {0}", ex.Message.ToString());
				ErrorMessage(text);
				xmlDocument = null;
				return;
			}
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/TreeRoot");
			string text2 = "";
			ValidateRegisterValues_Rec(xmlNode, ref text2);
			if (text2 != "")
			{
				string text = string.Format("LoadExpose - values of the following registers don't match their fields:\n{0}", text2);
				WarningMsgBox(text);
			}
			if (xmlNode != null)
			{
				if (m_XmlTreeWrapper.CheckTabsDuplicate(xmlNode))
				{
					CoreImports.DisposeLoadedXml();
				}
				Dictionary<string, string> version_pool = iFillVersionPull(xmlNode);
				if (!m_XmlTreeWrapper.CreateExportDescFromXml(xmlNode))
				{
					ErrorMessage("LoadExpose failed. Check if XML is a valid RT3 XML");
					xmlDocument = null;
					return;
				}
				string arg;
				if (!m_XmlTreeWrapper.ExposeXml(xmlNode, out arg, version_pool, 31457280))
				{
					ErrorMessage(string.Format("LoadExpose failed:\n{0}\nCheck if XML is a valid RT3 XML", arg));
					xmlDocument = null;
					return;
				}
				m_BrowseTree.Build();
			}
			else
			{
				string text = "LoadTree: " + fileName + " Could not find TreeRoot in file.";
				if (IsOnScriptThread())
				{
					throw new LuaException(text);
				}
				AlwaysPrint(text);
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error loading file: \n" + text);
			}
			RefreshGui();
			xmlDocument = null;
		}


		public static void Load(string fileName)
		{
			string text = "";
			if (!File.Exists(fileName))
			{
				ErrorMessage("Load XML: File name \"" + fileName + "\" Not found");
				return;
			}
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(fileName);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("/TreeRoot");
				ValidateRegisterValues_Rec(xmlNode, ref text);
				if (text != "")
				{
					string text2 = string.Format("Load failed.\nValues of the following registers don't match their fields:\n{0}", text);
					ErrorMessage(text2);
					RefreshGui();
				}
				else
				{
					if (xmlNode != null)
					{
						m_XmlTreeWrapper.MergeToMainXmlTree(xmlNode);
					}
					else
					{
						string text2 = "LoadTree: " + fileName + " Could not find TreeRoot in file.";
						if (IsOnScriptThread())
						{
							throw new LuaException(text2);
						}
						AlwaysPrint(text2);
						RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error loading file: \n" + text2);
					}
					RefreshGui();
				}
			}
			catch (Exception ex)
			{
				string text2 = string.Format("Load failed with exception:\n{0}", ex.Message);
				if (IsOnScriptThread())
				{
					throw new LuaException(text2);
				}
				RstdException(text2, ex.StackTrace);
			}
		}


		public static void Save(string xml_path, string fileName)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				VerbosePrint(string.Format("RSTD.SaveTree(\"{0}\",\"{1}\")\n", xml_path, fileName.Replace('\\', '/')));
				XmlNode item;
				XmlNode xmlNode;
				if (xml_path.Equals("/"))
				{
					xmlDocument.LoadXml(m_XmlTreeWrapper.GetOuterXmlTree());
					item = xmlDocument.SelectSingleNode("TreeRoot");
				}
				else if (bGetFolder(xml_path, out xmlNode))
				{
					xmlDocument.LoadXml(iGetXmlString(xmlNode, false));
					item = xmlNode;
				}
				else
				{
					string text = string.Format("SavePath: Illegal path to save {0}", xml_path);
					if (IsOnScriptThread())
					{
						throw new LuaException(text);
					}
					AlwaysPrint(text);
					RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error saving to file: \n" + text);
					return;
				}
				List<XmlNode> list = new List<XmlNode>();
				list.Add(item);
				m_XmlTreeWrapper.RemoveFunctionPointers(ref xmlDocument);
				if (ibValidateRegisterValuesList(list))
				{
					m_XmlTreeWrapper.InsertValuesForMappedVars(ref xmlDocument);
					m_XmlTreeWrapper.RemoveGuiAttributes(ref xmlDocument);
					m_XmlTreeWrapper.ChangeValuesToHex(ref xmlDocument);
					xmlDocument.Save(fileName);
					xmlDocument = null;
				}
			}
			catch (Exception ex)
			{
				string text = string.Format("Save failed with exception:\n{0}", ex.Message);
				if (IsOnScriptThread())
				{
					throw new LuaException(text);
				}
				RstdException(text, ex.StackTrace);
			}
		}


		public static string GetActualVarValue(XmlNode node)
		{
			return GetActualVarValue(GetPathFromNode(node));
		}


		public static string GetActualVarValue(string node_path)
		{
			StringBuilder stringBuilder = new StringBuilder(4096);
			CoreImports.ReceiveVarStr(node_path, stringBuilder);
			return stringBuilder.ToString();
		}


		public static bool Save(List<XmlNode> nodes, string fileName)
		{
			if (Path.GetExtension(fileName).ToLower().Equals(".txt"))
			{
				iSaveTxt(nodes, fileName);
				return true;
			}
			if (Path.GetExtension(fileName).ToLower().Equals(".xml"))
			{
				return ibSaveXml(nodes, fileName);
			}
			RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_WARNING, "File does not save use only .xml or .txt extensions");
			return false;
		}


		public static bool SaveDialogTxtOrXml(List<XmlNode> XmlNodes, out string file_name, bool bIsSubSet, string version, string src_version)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Select destination file...";
			if (!bIsSubSet)
			{
				saveFileDialog.Filter = "XML Tree Data Values files (*.xml)|*.xml|Text Files (*.txt)|*.txt";
				SaveFileDialog saveFileDialog2 = saveFileDialog;
				saveFileDialog2.Filter += "|Csv Files (*.csv)|*.csv";
			}
			else
			{
				SaveFileDialog saveFileDialog3 = saveFileDialog;
				saveFileDialog3.Filter += "Csv Files (*.csv)|*.csv";
			}
			saveFileDialog.RestoreDirectory = true;
			if (DialogResult.OK != saveFileDialog.ShowDialog())
			{
				file_name = null;
				return false;
			}
			if (Path.GetExtension(saveFileDialog.FileName).Equals(".csv"))
			{
				Save2Csv(saveFileDialog.FileName, XmlNodes, bIsSubSet, version, src_version);
				file_name = saveFileDialog.FileName;
				return true;
			}
			file_name = saveFileDialog.FileName;
			return Save(XmlNodes, saveFileDialog.FileName);
		}


		public static bool Save(XmlNode node, string fileName)
		{
			return Save(new List<XmlNode>
			{
				node
			}, fileName);
		}


		public static string SaveDialogTxtOrXml(string initial_dir, byte filetypes)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if ((filetypes & 1) == 1)
			{
				saveFileDialog.Filter = "XML Tree Data Values files (*.xml)|*.xml";
			}
			if ((filetypes & 2) == 2)
			{
				SaveFileDialog saveFileDialog2 = saveFileDialog;
				saveFileDialog2.Filter += "|Text Files (*.txt)|*.txt";
			}
			if ((filetypes & 4) == 4)
			{
				SaveFileDialog saveFileDialog3 = saveFileDialog;
				saveFileDialog3.Filter += "|Csv Files (*.csv)|*.csv";
			}
			saveFileDialog.Title = "Select destination file...";
			saveFileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(initial_dir))
			{
				saveFileDialog.InitialDirectory = initial_dir;
			}
			saveFileDialog.ShowDialog();
			return saveFileDialog.FileName;
		}


		public static string OpenFileDialog(string initial_dir, FileType file_type)
		{
			return iFileDialog(initial_dir, file_type, DialogType.OPEN);
		}


		public static string SaveFileDialog(string initial_dir, FileType file_type)
		{
			return iFileDialog(initial_dir, file_type, DialogType.SAVE);
		}


		public static void LoadVarFromFile(string varFullPath, string fileName)
		{
			CoreImports.LoadVar(varFullPath, fileName);
		}


		public static void SaveSearch(string base_path, string search_string, string search_context, string search_options, string fileName)
		{
			List<XmlNode> list = new List<XmlNode>();
			string text = "";
			list = GetSearch(base_path, search_string, search_context, search_options, ref text);
			if (text != "")
			{
				AlwaysPrint(string.Format("SaveSearch:{0}", text));
				return;
			}
			if (list.Count == 0)
			{
				AlwaysPrint("SaveSearch: No results found!");
				return;
			}
			Save(list, fileName);
		}


		public static List<XmlNode> GetSearch(string base_path, string search_string, string search_context, string search_options, ref string error_msg)
		{
			StringCollection stringCollection = new StringCollection();
			StringCollection stringCollection2 = new StringCollection();
			List<XmlNode> list = new List<XmlNode>();
			search_context = search_context.ToLower();
			stringCollection.AddRange(search_context.Split(new char[]
			{
				'|'
			}, StringSplitOptions.RemoveEmptyEntries));
			bool bCheckName = stringCollection.Contains("name");
			bool bCheckValue = stringCollection.Contains("value");
			bool bCheckComment = stringCollection.Contains("comment");
			bool bCheckType = stringCollection.Contains("type");
			bool bCheckAddress = stringCollection.Contains("address");
			bool bCheckDescription = stringCollection.Contains("description");
			search_options = search_options.ToLower();
			stringCollection2.AddRange(search_options.Split(new char[]
			{
				'|'
			}, StringSplitOptions.RemoveEmptyEntries));
			bool bMatchCase = stringCollection2.Contains("matchcase");
			bool bWholeWordOnly = stringCollection2.Contains("wholeword");
			bool bRegularExpression = stringCollection2.Contains("regularexpression");
			XmlNode basePathNode;
			if (bGetFolder(base_path, out basePathNode))
			{
				try
				{
					RecursiveFind(basePathNode, true, search_string, bCheckName, bCheckValue, bCheckComment, bCheckType, bCheckAddress, bCheckDescription, bMatchCase, bWholeWordOnly, bRegularExpression, list);
					return list;
				}
				catch (Exception ex)
				{
					error_msg = "Error in search: " + ex.Message + "\n";
					return list;
				}
			}
			error_msg = "Invalid base path!";
			return list;
		}


		public static string GetVarValue(string varFullPath, string varName)
		{
			XmlNode xmlNode;
			if (!ibGetNodeInPath(varFullPath, varName, out xmlNode, true, "RSTD.GetVar"))
			{
				return null;
			}
			if (xmlNode.Name == "Register")
			{
				return xmlNode.ChildNodes[0].Value;
			}
			return xmlNode.InnerText;
		}


		public static bool ChangeVarsValueBeforeTransmit(string varFullPath, string varName, string value)
		{
			XmlNode var_node;
			if (!ibGetNodeInPath(varFullPath, varName, out var_node, true, "SetVar"))
			{
				return false;
			}
			if (!ibSetVar(ReceiveTransmit_T.SET_AND_TRANSMIT, var_node, value))
			{
				return false;
			}
			RefreshGui();
			return true;
		}


		public static bool ChangeVarsValueBeforeTransmit(List<XmlNode> xml_nodes, string value, frmSubSet sub_set)
		{
			bool result = true;
			foreach (XmlNode var_node in xml_nodes)
			{
				if (!ibSetVar(ReceiveTransmit_T.SET_AND_TRANSMIT, var_node, value))
				{
					result = false;
				}
			}
			RefreshGui();
			if (sub_set != null)
			{
				sub_set.RefreshDisplay();
			}
			return result;
		}


		public static bool ChangeVarsValue(string varFullPath, string value)
		{
			XmlNode xml_node;
			return GetNodeFromPath(varFullPath, out xml_node) && ChangeVarsValue(xml_node, value);
		}


		public static bool ChangeVarsValue(XmlNode xml_node, string value)
		{
			return ChangeVarsValue(new List<XmlNode>
			{
				xml_node
			}, value, null);
		}


		public static bool ChangeVarsValue(List<XmlNode> xml_nodes, string value, frmSubSet sub_set)
		{
			bool result = true;
			using (List<XmlNode>.Enumerator enumerator = xml_nodes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!bChangeValue(enumerator.Current, value))
					{
						result = false;
					}
				}
			}
			RefreshGui();
			if (sub_set != null)
			{
				sub_set.RefreshDisplay();
			}
			return result;
		}


		public static bool bChangeArrayBeforeTransmit(XmlNode var_node, string value)
		{
			return ibSetVar(ReceiveTransmit_T.ARRAY_VAR, var_node, value);
		}


		public static bool bChangeValue(XmlNode var_node, string value)
		{
			return ibSetVar(ReceiveTransmit_T.XML_PATH, var_node, value);
		}


		public static bool bSetLoadedValue(XmlNode var_node, string value)
		{
			return ibSetVar(ReceiveTransmit_T.LOADED_VAR, var_node, value);
		}


		public static bool bAddMonitoredVar(XmlNode var_node)
		{
			return bAddMonitoredVar(new List<XmlNode>
			{
				var_node
			});
		}


		public static bool bAddMonitoredVar(List<XmlNode> var_nodes)
		{
			bool flag = m_XmlTreeWrapper.ReplaceVarsAttribute(var_nodes, "is_monitored", "true");
			if (flag)
			{
				foreach (XmlNode xml_node in var_nodes)
				{
					string pathFromNode = GetPathFromNode(xml_node);
					if (!m_BrowseTree.MonitoredVars.MonitoredVarsList.Contains(pathFromNode))
					{
						m_BrowseTree.MonitoredVars.MonitoredVarsList.Add(pathFromNode);
					}
				}
				RefreshGui();
			}
			return flag;
		}


		public static bool RemoveMonitoredVar(List<XmlNode> var_nodes)
		{
			bool flag = m_XmlTreeWrapper.ReplaceVarsAttribute(var_nodes, "is_monitored", "false");
			if (flag)
			{
				foreach (XmlNode xml_node in var_nodes)
				{
					string pathFromNode = GetPathFromNode(xml_node);
					if (m_BrowseTree.MonitoredVars.MonitoredVarsList.Contains(pathFromNode))
					{
						m_BrowseTree.MonitoredVars.MonitoredVarsList.Remove(pathFromNode);
					}
				}
				RefreshGui();
			}
			return flag;
		}


		public static void RemoveAfterValidateFromMonitor(List<XmlNode> var_nodes)
		{
			foreach (object obj in Application.OpenForms)
			{
				Form form = (Form)obj;
				if (form.Name == "MonitoredVars" && ((MonitoredVars)form).bIsMonitoring)
				{
					RstdException("Can't remove monitored variables while monitoring is in progress.\n", "");
					return;
				}
			}
			for (int i = 0; i < var_nodes.Count; i++)
			{
				string pathFromNode = GetPathFromNode(var_nodes[i]);
				VerbosePrint(string.Format("RSTD.RemoveFromMonitor({0})\n", pathFromNode));
			}
			RemoveMonitoredVar(var_nodes);
		}


		public static void MonitorSetVars(string settingsFile)
		{
			CoreImports.MonitorSetVars(settingsFile);
		}


		public static void MonitorStart(string outFileName)
		{
			CoreImports.MonitorStart(outFileName);
		}


		public static void MonitorStop()
		{
			if (!IsOnGuiThread())
			{
				iMonitorStop();
				return;
			}
			new CoreAsyncDel(iMonitorStop).BeginInvoke(new AsyncCallback(iMonitorStopAsyncThreadCompleted), null);
		}


		public static void MonitorFlush()
		{
			CoreImports.MonitorFlush();
		}


		public static void RemoveDuplicateChars(ref string str, char ch)
		{
			for (int i = 0; i < str.Length - 1; i++)
			{
				if (str[i] == ch && str[i + 1] == ch)
				{
					str = str.Remove(i, 1);
					i--;
				}
			}
		}


		public static void UpdateMonitoredVarsDisplay(IntPtr nodes_info, uint count)
		{
			int num = Marshal.SizeOf(typeof(NodeInfo));
			if (count > 0U)
			{
				IntPtr intPtr = nodes_info;
				for (uint num2 = 0U; num2 < count; num2 += 1U)
				{
					NodeInfo nodeInfo = (NodeInfo)Marshal.PtrToStructure(intPtr, typeof(NodeInfo));
					XmlNode xmlNode;
					if (GetNodeFromPath(nodeInfo.path, out xmlNode))
					{
						if (xmlNode.FirstChild == null)
						{
							xmlNode.InnerText = nodeInfo.value;
						}
						else
						{
							xmlNode.FirstChild.Value = nodeInfo.value;
						}
						xmlNode.Attributes["is_updated"].Value = true.ToString();
						NodeType nodeType = GetNodeType(xmlNode);
						if (nodeType == NodeType.REGISTER)
						{
							bCalcFieldsFromRegister(xmlNode);
						}
						else if (nodeType == NodeType.FIELD)
						{
							m_XmlTreeWrapper.CalcRegisterValue(xmlNode.ParentNode);
						}
					}
					intPtr = (IntPtr)((int)intPtr + num);
				}
				RefreshGui();
			}
		}


		public static bool bAddToAutoUpdate(string fullPath)
		{
			XmlNode item = null;
			List<XmlNode> list = new List<XmlNode>();
			if (GetNodeFromPath(fullPath, out item))
			{
				list.Add(item);
			}
			return bAddToAutoUpdate(list);
		}


		public static bool bAddToAutoUpdate(List<XmlNode> var_nodes)
		{
			object autoUpdateListLocker = m_BrowseTree.AutoUpdateListLocker;
			bool flag2;
			lock (autoUpdateListLocker)
			{
				flag2 = m_XmlTreeWrapper.ReplaceVarsAttribute(var_nodes, "is_auto_updated", "true");
				if (flag2)
				{
					foreach (XmlNode xml_node in var_nodes)
					{
						string pathFromNode = GetPathFromNode(xml_node);
						if (!m_BrowseTree.AutoUpdateList.Contains(pathFromNode))
						{
							m_BrowseTree.AutoUpdateList.Add(pathFromNode);
						}
					}
					RefreshGui();
				}
			}
			return flag2;
		}


		public static bool bRemoveFromAutoUpdate(string fullPath)
		{
			XmlNode item = null;
			List<XmlNode> list = new List<XmlNode>();
			if (GetNodeFromPath(fullPath, out item))
			{
				list.Add(item);
			}
			return bRemoveFromAutoUpdate(list);
		}


		public static bool bRemoveFromAutoUpdate(List<XmlNode> var_nodes)
		{
			object autoUpdateListLocker = m_BrowseTree.AutoUpdateListLocker;
			bool flag2;
			lock (autoUpdateListLocker)
			{
				flag2 = m_XmlTreeWrapper.ReplaceVarsAttribute(var_nodes, "is_auto_updated", "false");
				if (flag2)
				{
					foreach (XmlNode xml_node in var_nodes)
					{
						string pathFromNode = GetPathFromNode(xml_node);
						if (m_BrowseTree.AutoUpdateList.Contains(pathFromNode))
						{
							m_BrowseTree.AutoUpdateList.Remove(pathFromNode);
						}
					}
					RefreshGui();
				}
			}
			return flag2;
		}


		public static string RunFunction(string funcCall, bool async)
		{
			return RunFunction(funcCall, async, false);
		}


		public static string RunFunction(string funcCall, bool async, bool is_from_gui_client)
		{
			string result = null;
			string arg = "RSTD.RunFunction";
			VerbosePrint(string.Format("{0}(\"{1}\")\n", arg, funcCall.Replace("\\", "\\\\").Replace("\"", "\\\"")));
			XmlNode xmlNode;
			if (ibGetNodeFromFunctionCall(funcCall, out xmlNode))
			{
				m_XmlTreeWrapper.ReplaceAttributeValuesWithinNode_Recursive(xmlNode, "is_updated", true.ToString());
			}
			if (!is_from_gui_client)
			{
				ActivateGuiClientOperationStart(funcCall);
			}
			if (!async)
			{
				result = iRunFunctionAsync(funcCall, is_from_gui_client);
				RefreshGui();
			}
			else
			{
				new CoreAsyncDel_string_bool(iRunFunctionAsync).BeginInvoke(funcCall, is_from_gui_client, new AsyncCallback(iRunFunctionAsyncThreadCompleted), null);
			}
			return result;
		}


		public static string RunFuncByXml(string funcPath)
		{
			string str;
			if (ibGetFuncParamsStr(funcPath, out str))
			{
				return RunFunction(funcPath + str, true);
			}
			return "Not found";
		}


		public static void ErrorMessage(string msg)
		{
			if (!msg.EndsWith("\n"))
			{
				msg += "\n";
			}
			if (IsOnScriptThread())
			{
				throw new LuaException(string.Format("ERROR:\n{0}", msg));
			}
			MainForm.ErrorPrint(string.Format("ERROR:\n{0}", msg));
			RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Rstd Error: \n" + msg);
		}


		public static void RstdException(string msg, string msg_stack)
		{
			if (!msg.EndsWith("\n"))
			{
				msg += "\n";
			}
			if (frmMain.bIsScriptRunning && IsOnScriptThread())
			{
				throw new LuaException(msg);
			}
			AlwaysPrint(msg);
			RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, msg, msg_stack);
		}


		public static void RstdMesssage(string msg)
		{
			if (!msg.EndsWith("\n"))
			{
				msg += "\n";
			}
			AlwaysPrint(msg);
			if (!IsOnScriptThread())
			{
				RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, msg);
			}
		}


		public static uint RSTDMessage(RstdConstants.MESSAGE_TYPE msg_type, string msg)
		{
			return RSTDMessage(msg_type, msg, "");
		}


		public static uint RSTDMessage(RstdConstants.MESSAGE_TYPE msg_type, string msg, string msg_stack)
		{
			if (m_MainForm.InvokeRequired)
			{
				dRstdMessageDel method = new dRstdMessageDel(RSTDMessage);
				return (uint)m_MainForm.Invoke(method, new object[]
				{
					msg_type,
					msg,
					msg_stack
				});
			}
			RstdConstants.CORE_MSG_BTN core_msg_btn;
			Icon msg_box_icon;
			string title;
			RstdConstants.WATCHDOG_LEVEL level;
			switch (msg_type)
			{
			case RstdConstants.MESSAGE_TYPE.OK_INFORMATION:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.OK;
				msg_box_icon = SystemIcons.Information;
				title = "Radar Studio";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.RSTD_EXCEPTION:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.ExitDebugIgnore;
				msg_box_icon = SystemIcons.Error;
				title = "Radar Studio Exception";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_ERRORS;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.OK_CANCEL_INFORMATION:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.OkCancel;
				msg_box_icon = SystemIcons.Information;
				title = "Radar Studio";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.QEUSTION:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.YesNo;
				msg_box_icon = SystemIcons.Question;
				title = "Radar Studio";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.RSTD_EXCEPTION_EXIT:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.ExitDebug;
				msg_box_icon = SystemIcons.Error;
				title = "Radar Studio Exception";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_ERRORS;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.OK_ERROR:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.OK;
				msg_box_icon = SystemIcons.Error;
				title = "Radar Studio Error";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_ERRORS;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.YES_NO_WARNING:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.YesNo;
				msg_box_icon = SystemIcons.Warning;
				title = "Radar Studio Warning";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.OK_WARNING:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.OK;
				msg_box_icon = SystemIcons.Warning;
				title = "Radar Studio Warning";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.GUI_CLIENT_MESSAGE:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.OK;
				msg_box_icon = SystemIcons.Information;
				title = "Radar Studio GUI Client";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
				AlwaysPrint(msg);
				goto IL_178;
			case RstdConstants.MESSAGE_TYPE.GUI_CLIENT_ERROR:
				core_msg_btn = RstdConstants.CORE_MSG_BTN.OK;
				msg_box_icon = SystemIcons.Error;
				title = "Radar Studio GUI Client";
				level = RstdConstants.WATCHDOG_LEVEL.RSTD_ERRORS;
				AlwaysPrint(0U, 1U, "ERROR:\n" + msg);
				goto IL_178;
			}
			core_msg_btn = RstdConstants.CORE_MSG_BTN.OK;
			msg_box_icon = ImageToIcon(Resources.RstdImage);
			title = "Radar Studio";
			level = RstdConstants.WATCHDOG_LEVEL.RSTD_MESSAGES;
			IL_178:
			DialogResult result;
			if (IsAutomationModeOn() && (msg_type == RstdConstants.MESSAGE_TYPE.OK_INFORMATION || msg_type == RstdConstants.MESSAGE_TYPE.OK_WARNING || msg_type == RstdConstants.MESSAGE_TYPE.GUI_CLIENT_MESSAGE || msg_type == RstdConstants.MESSAGE_TYPE.GUI_CLIENT_ERROR))
			{
				result = DialogResult.OK;
			}
			else
			{
				if (m_MainForm.WatchDogManager.IsOnGuard)
				{
					m_MainForm.WatchDogManager.Suspend(level);
				}
				result = new frmHandleMsg(msg, msg_stack, msg_type, title, core_msg_btn, msg_box_icon).ShowDialog(m_MainForm);
				if (m_MainForm.WatchDogManager.IsOnGuard)
				{
					m_MainForm.WatchDogManager.Resume();
				}
			}
			return (uint)result;
		}


		public static void WarningMsgBox(string msg)
		{
			RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_WARNING, msg);
			m_MainForm.Warning(msg);
		}


		public static bool ValidateSameShowArrayOpenOnlyOnce(XmlNode xml_node)
		{
			string pathFromNode = GetPathFromNode(xml_node);
			foreach (object obj in Application.OpenForms)
			{
				Form form = (Form)obj;
				if (form.Name == "frmUpdateArrayDialog" && ((frmUpdateArrayDialog)form).txtArrayName.Text.Equals(pathFromNode))
				{
					((frmUpdateArrayDialog)form).Focus();
					return false;
				}
			}
			return true;
		}


		public static string GetLastIndexedFileNameInPath(string fileNamePrefix, string fileNameSuffix, string path)
		{
			if (!Directory.Exists(path))
			{
				string text = string.Format("Could not find path {0}", path);
				if (IsOnScriptThread())
				{
					throw new LuaException(text);
				}
				AlwaysPrint(text);
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error getting file: \n" + text);
			}
			string[] files = Directory.GetFiles(path, fileNamePrefix + "*" + fileNameSuffix, SearchOption.TopDirectoryOnly);
			for (int i = files.Length - 1; i >= 0; i--)
			{
				string text2 = Path.GetFileNameWithoutExtension(files[i]);
				if (text2.Contains("_"))
				{
					text2 = text2.Remove(text2.IndexOf('_'));
				}
				int num;
				if (int.TryParse(text2.Substring(fileNamePrefix.Length), NumberStyles.Integer, null, out num))
				{
					return files[i];
				}
			}
			return null;
		}


		public static void IncrementFileNameIdx(string fileNamePrefix, int nominalNumberStringPaddingLen, ref string prevFileName)
		{
			string text = Path.GetDirectoryName(prevFileName);
			string text2 = Path.GetFileNameWithoutExtension(prevFileName);
			string extension = Path.GetExtension(prevFileName);
			if (!string.IsNullOrEmpty(text))
			{
				text += Path.DirectorySeparatorChar.ToString();
			}
			if (text2.Contains("_"))
			{
				text2 = text2.Remove(text2.IndexOf('_'));
			}
			string text3 = text2.Substring(fileNamePrefix.Length);
			int num;
			if (int.TryParse(text3, NumberStyles.Integer, null, out num))
			{
				num++;
				text3 = num.ToString().PadLeft(nominalNumberStringPaddingLen, '0');
			}
			else
			{
				string text4 = string.Format("Illegal prev file name {0}", prevFileName);
				if (IsOnScriptThread())
				{
					throw new LuaException(text4);
				}
				AlwaysPrint(text4);
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error in operation: \n" + text4);
			}
			prevFileName = text + fileNamePrefix + text3 + extension;
		}


		public static string IncrementSubFileNameIdx(string prevFileName)
		{
			string text = Path.GetDirectoryName(prevFileName);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(prevFileName);
			string extension = Path.GetExtension(prevFileName);
			if (!string.IsNullOrEmpty(text))
			{
				text += Path.DirectorySeparatorChar.ToString();
			}
			string text2;
			string text3;
			if (fileNameWithoutExtension.Contains("_"))
			{
				text2 = fileNameWithoutExtension.Substring(fileNameWithoutExtension.IndexOf('_') + 1);
				text3 = fileNameWithoutExtension.Remove(fileNameWithoutExtension.IndexOf('_'));
				int num;
				if (int.TryParse(text2, NumberStyles.Integer, null, out num))
				{
					num++;
					text2 = num.ToString();
				}
				else
				{
					string text4 = string.Format("Illegal prev file name {0}", prevFileName);
					if (IsOnScriptThread())
					{
						throw new LuaException(text4);
					}
					AlwaysPrint(text4);
					RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Error in operation: \n" + text4);
				}
			}
			else
			{
				text2 = "0";
				text3 = fileNameWithoutExtension;
			}
			prevFileName = string.Concat(new string[]
			{
				text,
				text3,
				"_",
				text2,
				extension
			});
			return prevFileName;
		}


		public static bool bCalcFieldsFromRegister(XmlNode reg_node)
		{
			double num = 0.0;
			long value;
			if (!long.TryParse(reg_node.FirstChild.Value, out value))
			{
				ErrorMessage(string.Format("Could not convert value {0} of register \"{1}\" to decimal\n", reg_node.FirstChild.Value, reg_node.Attributes["name"].Value));
				return false;
			}
			string text = Convert.ToString(value, 2);
			text = text.PadLeft(32, '0');
			for (int i = 1; i < reg_node.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = reg_node.ChildNodes[i].ChildNodes[1];
				int num2 = int.Parse(xmlNode.Attributes["start_bit"].Value);
				int num3 = int.Parse(xmlNode.Attributes["n_bits"].Value);
				long bit_pattern = Convert.ToInt64(text.Substring(text.Length - num2 - num3, num3), 2);
				if (reg_node.ChildNodes[i].Attributes["type"].Value == "FIX")
				{
					if (reg_node.ChildNodes[i].Attributes["fixmode"] != null)
					{
						string value2 = reg_node.ChildNodes[i].Attributes["fixmode"].Value;
						double num4;
						if (!CoreImports.GetFixedValue(bit_pattern, value2, out num, out num4))
						{
							return false;
						}
						reg_node.ChildNodes[i].FirstChild.Value = num4.ToString("R");
					}
					else
					{
						ErrorMessage(string.Format("field {0} has no fixmode set", reg_node.ChildNodes[i].ChildNodes[1].Attributes["field_name"].Value));
					}
				}
				else
				{
					reg_node.ChildNodes[i].FirstChild.Value = bit_pattern.ToString();
				}
				reg_node.ChildNodes[i].Attributes["is_updated"].Value = reg_node.Attributes["is_updated"].Value;
			}
			return true;
		}


		public static bool IsAutomationModeOn()
		{
			bool result = false;
			if (m_RstdSettings != null)
			{
				result = m_RstdSettings.GetAutomationMode();
			}
			return result;
		}


		public static bool bNodeContainsRegisters(XmlNode node)
		{
			return m_XmlTreeWrapper.bNodeContainsRegisters(node);
		}


		public static NodeType GetNodeType(XmlNode node)
		{
			NodeType result = NodeType.UNSUPPORTED;
			string name = node.Name;
			uint num = PrivateImplementationDetails.ComputeStringHash(name);
			if (num <= 683324629U)
			{
				if (num <= 647111111U)
				{
					if (num != 104168189U)
					{
						if (num == 647111111U)
						{
							if (name == "ReturnList")
							{
								result = NodeType.RETURN_LIST;
							}
						}
					}
					else if (name == "Folder")
					{
						result = NodeType.FOLDER;
					}
				}
				else if (num != 658098656U)
				{
					if (num == 683324629U)
					{
						if (name == "TreeRoot")
						{
							result = NodeType.ROOT;
						}
					}
				}
				else if (name == "Register")
				{
					result = NodeType.REGISTER;
				}
			}
			else if (num <= 3275460354U)
			{
				if (num != 2561120873U)
				{
					if (num == 3275460354U)
					{
						if (name == "ArgumentList")
						{
							result = NodeType.ARGUMENT_LIST;
						}
					}
				}
				else if (name == "Function")
				{
					result = NodeType.FUNCTION;
				}
			}
			else if (num != 3971093086U)
			{
				if (num == 4219689196U)
				{
					if (name == "Tab")
					{
						result = NodeType.TAB;
					}
				}
			}
			else if (name == "Var")
			{
				if (node.ParentNode.Name == "Register")
				{
					result = NodeType.FIELD;
				}
				else if (-1 != m_XmlParser.GetHwInfoIndex(node))
				{
					result = NodeType.MAPPED_VAR;
				}
				else
				{
					result = NodeType.VAR;
				}
			}
			return result;
		}


		public static string GetDisplayedValue(XmlNode node)
		{
			if (GetNodeType(node) == NodeType.MAPPED_VAR)
			{
				node = m_XmlTreeWrapper.RegisterMapping[node];
			}
			DisplayType display_type = (DisplayType)Enum.Parse(typeof(DisplayType), node.Attributes["display_type"].Value, true);
			return GetDisplayedValue(node, display_type);
		}


		public static string GetDisplayedValue(XmlNode node, DisplayType display_type, string value)
		{
			string text = "";
			NodeType nodeType = GetNodeType(node);
			if (nodeType == NodeType.MAPPED_VAR)
			{
				node = RegisterMapping[node];
				nodeType = GetNodeType(node);
			}
			if (node.FirstChild == null)
			{
				return "";
			}
			if (display_type == DisplayType.DEFAULT)
			{
				display_type = GetDefaultDispalyType(nodeType);
			}
			string[] array = value.Split(" ".ToCharArray());
			if (array.Length > 1)
			{
				foreach (string single_original_value in array)
				{
					string singleValueDisplay = GetSingleValueDisplay(node, display_type, single_original_value);
					text = text + singleValueDisplay + " ";
				}
			}
			else
			{
				text = GetSingleValueDisplay(node, display_type, array[0]);
				bGetOptionFromValue(node, ref text);
			}
			return text.Trim();
		}


		public static string GetDisplayedValue(XmlNode node, DisplayType display_type)
		{
			string text = "";
			NodeType nodeType = GetNodeType(node);
			if (nodeType == NodeType.MAPPED_VAR)
			{
				node = RegisterMapping[node];
				nodeType = GetNodeType(node);
			}
			if (node.FirstChild == null)
			{
				return "";
			}
			if (display_type == DisplayType.DEFAULT)
			{
				display_type = GetDefaultDispalyType(nodeType);
			}
			string[] array = node.FirstChild.Value.Split(" ".ToCharArray());
			if (array.Length > 1)
			{
				foreach (string single_original_value in array)
				{
					string singleValueDisplay = GetSingleValueDisplay(node, display_type, single_original_value);
					text = text + singleValueDisplay + " ";
				}
			}
			else
			{
				text = GetSingleValueDisplay(node, display_type, array[0]);
				bGetOptionFromValue(node, ref text);
			}
			return text.Trim();
		}


		public static string GetDisplayedType(XmlNode node)
		{
			string result = "";
			if (GetNodeType(node) == NodeType.MAPPED_VAR)
			{
				node = m_XmlTreeWrapper.RegisterMapping[node];
			}
			if (node.Attributes["type"] != null)
			{
				result = node.Attributes["type"].Value;
			}
			return result;
		}


		public static string GetDisplayedFixMode(XmlNode node)
		{
			string result = "";
			if (GetNodeType(node) == NodeType.MAPPED_VAR)
			{
				node = m_XmlTreeWrapper.RegisterMapping[node];
			}
			if (node.Attributes["fixmode"] != null)
			{
				result = node.Attributes["fixmode"].Value;
			}
			return result;
		}


		public static bool bIsDisplayTypeValidForType(DisplayType display_type, string var_type)
		{
			switch (display_type)
			{
			case DisplayType.DEFAULT:
				return true;
			case DisplayType.DECIMAL:
				if (var_type == "INT8" || var_type == "INT16" || var_type == "INT32" || var_type == "INT64" || var_type == "UINT8" || var_type == "UINT16" || var_type == "UINT32" || var_type == "UINT64" || var_type == "INT8PTR" || var_type == "INT16PTR" || var_type == "INT32PTR" || var_type == "INT64PTR" || var_type == "UINT8PTR" || var_type == "UINT16PTR" || var_type == "UINT32PTR" || var_type == "UINT64PTR" || var_type == "FLOAT32" || var_type == "FLOAT32PTR" || var_type == "FLOAT64" || var_type == "FLOAT64PTR" || var_type == "FLOAT80" || var_type == "FLOAT80PTR" || var_type == "FIX" || var_type == "FIXVALPTR" || var_type == "FIXVECT" || var_type == "FLOAT64COMPLEX" || var_type == "FLOAT64COMPLEXPTR")
				{
					return true;
				}
				break;
			case DisplayType.DECIMAL_SIGNED:
				if (var_type == "INT8" || var_type == "INT16" || var_type == "INT32" || var_type == "INT64" || var_type == "INT8PTR" || var_type == "INT16PTR" || var_type == "INT32PTR" || var_type == "INT64PTR")
				{
					return true;
				}
				break;
			case DisplayType.INTEGER:
			case DisplayType.HEX:
			case DisplayType.BINARY:
				if (var_type == "INT8" || var_type == "INT16" || var_type == "INT32" || var_type == "INT64" || var_type == "UINT8" || var_type == "UINT16" || var_type == "UINT32" || var_type == "UINT64" || var_type == "INT8PTR" || var_type == "INT16PTR" || var_type == "INT32PTR" || var_type == "INT64PTR" || var_type == "UINT8PTR" || var_type == "UINT16PTR" || var_type == "UINT32PTR" || var_type == "UINT64PTR" || var_type == "FIX" || var_type == "FIXVALPTR" || var_type == "FIXVECT" || var_type == "FIXCPLX" || var_type == "FIXCPLXPTR")
				{
					return true;
				}
				break;
			case DisplayType.DB10:
			case DisplayType.DB20:
				if (var_type == "FLOAT32" || var_type == "FLOAT32PTR" || var_type == "FLOAT64" || var_type == "FLOAT64PTR" || var_type == "FLOAT80" || var_type == "FLOAT80PTR" || var_type == "FIX" || var_type == "FIXVALPTR" || var_type == "FIXVECT" || var_type == "FLOAT64COMPLEX" || var_type == "FLOAT64COMPLEXPTR")
				{
					return true;
				}
				break;
			}
			return false;
		}


		public static VarIcon GetVarIcon(XmlNode xmlNode)
		{
			if (GetNodeType(xmlNode) == NodeType.MAPPED_VAR)
			{
				xmlNode = m_XmlTreeWrapper.RegisterMapping[xmlNode];
			}
			VarIcon result;
			if (bool.Parse(xmlNode.Attributes["is_monitored"].Value))
			{
				result = VarIcon.CLOCK;
			}
			else if (!bool.Parse(xmlNode.Attributes["is_updated"].Value))
			{
				result = VarIcon.NOT_UPDATED;
			}
			else if (bool.Parse(xmlNode.Attributes["is_auto_updated"].Value))
			{
				result = VarIcon.AUTO_UPDATED;
			}
			else if (xmlNode.ParentNode.Name.Equals("ArgumentList"))
			{
				result = VarIcon.PARAMETER;
			}
			else
			{
				result = VarIcon.UPDATED;
			}
			return result;
		}


		public static bool bGetVarOptions(XmlNode node, out string[] options_arr)
		{
			return m_XmlTreeWrapper.bGetVarOptions(node, out options_arr);
		}


		public static bool bGetOptionFromValue(XmlNode var_node, ref string value)
		{
			if (var_node.FirstChild == null)
			{
				return false;
			}
			string[] array;
			if (bGetVarOptions(var_node, out array))
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (GetValueFromOption(array[i]).Trim() == value.Trim())
					{
						value = array[i];
						return true;
					}
				}
			}
			return false;
		}


		public static bool bGetValueFromOptions(XmlNode var_node, ref string value)
		{
			string[] array;
			if (bGetVarOptions(var_node, out array))
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (value == array[i])
					{
						value = GetValueFromOption(array[i]);
						return true;
					}
				}
			}
			return false;
		}


		public static void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			UpdateListView(sender, e, null);
		}


		public static void UpdateListView(object sender, MouseEventArgs e, frmSubSet sub_set)
		{
			ContainerListView containerListView = (ContainerListView)sender;
			if (!containerListView.ClickedInsideItemList(e))
			{
				return;
			}
			if (containerListView.SelectedItems.Count == 0)
			{
				return;
			}
			XmlNode xmlNode = (XmlNode)containerListView.SelectedItems[0].Tag;
			if (GetNodeType(xmlNode) == NodeType.MAPPED_VAR)
			{
				xmlNode = m_XmlTreeWrapper.RegisterMapping[xmlNode];
			}
			if (xmlNode.Attributes["permission"].Value == "R")
			{
				return;
			}
			bool flag = false;
			List<XmlNode> list = new List<XmlNode>();
			list.Add(xmlNode);
			string value = xmlNode.Attributes["type"].Value;
			string text = null;
			if (xmlNode.Attributes["type"].Value.Equals("FIXMODE"))
			{
				UpdateDialog update_dlg;
				if (GetDisplayedValue(xmlNode).ToUpper().Contains("Q"))
				{
					update_dlg = new UpdateDialog_FixMode(list);
				}
				else
				{
					update_dlg = new UpdateDialog_FixMode_New(list);
				}
				iUpdateVar(update_dlg, ref text, ref flag);
			}
			else if (value.Equals("FILE"))
			{
				iUpdateFileVar(GetNodeValue(xmlNode), ref text);
			}
			else if (value.Equals("PATH"))
			{
				iUpdatePathVar(GetNodeValue(xmlNode), ref text);
			}
			else if ((GetNodeValue(list[0]).Contains(" ") || 1 < int.Parse(list[0].Attributes["length"].Value)) && !value.Equals("STRING") && string.IsNullOrEmpty(list[0].Attributes["options"].Value))
			{
				if (ValidateSameShowArrayOpenOnlyOnce(list[0]))
				{
					new frmUpdateArrayDialog(list).Show();
				}
			}
			else
			{
				UpdateDialog update_dlg = new UpdateDialog(list);
				iUpdateVar(update_dlg, ref text, ref flag);
			}
			if (text != null)
			{
				bool flag2;
				if (flag)
				{
					flag2 = ChangeVarsValueBeforeTransmit(list, text, sub_set);
				}
				else
				{
					flag2 = ChangeVarsValue(list, text, sub_set);
				}
				if (flag && flag2)
				{
					Transmit(list, ReceiveTransmit_T.SET_AND_TRANSMIT, false, sub_set);
				}
			}
		}


		public static void UpdateFolderList(ContainerListView list_view)
		{
			foreach (object obj in ((IEnumerable)list_view.Items))
			{
				ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
				XmlNode xmlNode = (XmlNode)containerListViewItem.Tag;
				if (GetNodeType(xmlNode) == NodeType.REGISTER)
				{
					bool flag = true;
					foreach (object obj2 in ((IEnumerable)containerListViewItem.Items))
					{
						ContainerListViewItem containerListViewItem2 = (ContainerListViewItem)obj2;
						XmlNode xmlNode2 = (XmlNode)containerListViewItem2.Tag;
						containerListViewItem2.SubItems[1].Text = GetDisplayedValue(xmlNode2);
						containerListViewItem2.ImageIndex = (int)GetVarIcon(xmlNode2);
						if (!bool.Parse(xmlNode2.Attributes["is_updated"].Value))
						{
							flag = false;
						}
					}
					if (frmMain.gGui_updated_mode == GUI_REGISTER_UPDATED_MODE.ON_FIELDS_UPDATE)
					{
						xmlNode.Attributes["is_updated"].Value = flag.ToString();
					}
				}
				containerListViewItem.ImageIndex = (int)GetVarIcon(xmlNode);
				containerListViewItem.SubItems[1].Text = GetDisplayedValue(xmlNode);
			}
			list_view.Refresh();
		}


		public static bool bHasBuildStatus(EBuildStatus status)
		{
			return (m_BuildStatus & status) == status;
		}


		public static void AdjustToolTipSize(object sender, PopupEventArgs e)
		{
			if (e.ToolTipSize.Width > 600)
			{
				e.ToolTipSize = new Size
				{
					Width = 500,
					Height = (int)((double)e.ToolTipSize.Width / 500.0 * (double)e.ToolTipSize.Height)
				};
			}
		}


		public static void DisplayToolTip(ContainerListView list_view, MouseEventArgs e, ToolTip tooltip)
		{
			ContainerListViewItem itemAtMousePos = list_view.GetItemAtMousePos(e);
			if (itemAtMousePos != null && iGetToolTip(list_view, itemAtMousePos, e, 5, tooltip))
			{
				return;
			}
			tooltip.SetToolTip(list_view, "");
		}


		public static bool bAreAllFunctionArgs(List<XmlNode> xml_nodes)
		{
			using (List<XmlNode>.Enumerator enumerator = xml_nodes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (GetNodeType(enumerator.Current.ParentNode) != NodeType.ARGUMENT_LIST)
					{
						return false;
					}
				}
			}
			return true;
		}


		public static Image GetImageFromFile(string file_name)
		{
			if (!string.IsNullOrEmpty(file_name) && File.Exists(file_name))
			{
				return Image.FromStream(new MemoryStream(File.ReadAllBytes(file_name)));
			}
			return null;
		}


		public static void UpdateGuiClient()
		{
			if (m_MainForm.InvokeRequired)
			{
				RefreshGuiDel method = new RefreshGuiDel(UpdateGuiClient);
				m_MainForm.Invoke(method);
				return;
			}
			foreach (RstdGuiModuleBase rstdGuiModuleBase in m_MainForm.GuiDllForms)
			{
				rstdGuiModuleBase.UpdateControls();
			}
		}


		public static void ActivateGuiClientOperationStart(string func_call)
		{
			foreach (RstdGuiModuleBase rstdGuiModuleBase in m_MainForm.GuiDllForms)
			{
				rstdGuiModuleBase.OperationStart(func_call);
			}
		}


		public static void ActivateGuiClientOperationEnd(string func_call, string ret_val)
		{
			foreach (RstdGuiModuleBase rstdGuiModuleBase in m_MainForm.GuiDllForms)
			{
				rstdGuiModuleBase.OperationEnd(func_call, ret_val);
			}
		}


		public static bool IsDeliveryVersion()
		{
			return true;
		}


		public static bool ReadIniFile(string ini_path)
		{
			IniHandler.FilePath = ini_path;
			if (string.IsNullOrEmpty(ini_path) || !File.Exists(ini_path))
			{
				return false;
			}
			m_UseVerboseLog = !(IniHandler.ReadValue("global", "UseVerboseLog", "0") == "0");
			m_UseUserLog = !(IniHandler.ReadValue("global", "UseUserLog", "0") == "0");
			return true;
		}


		public static void RestoreWindow(Form frm)
		{
			if (frm.WindowState == FormWindowState.Minimized)
			{
				CoreImports.WindowPlacement windowPlacement = default(CoreImports.WindowPlacement);
				CoreImports.GetWindowPlacement(frm.Handle, ref windowPlacement);
				if (windowPlacement.flags == 2)
				{
					frm.WindowState = FormWindowState.Maximized;
					return;
				}
				frm.WindowState = FormWindowState.Normal;
			}
		}


		public static void RestoreWindow(IntPtr handle)
		{
			if (CoreImports.IsIconic(handle))
			{
				CoreImports.WindowPlacement windowPlacement = default(CoreImports.WindowPlacement);
				CoreImports.GetWindowPlacement(handle, ref windowPlacement);
				if (windowPlacement.flags == 2)
				{
					CoreImports.ShowWindowAsync(handle, 3);
					return;
				}
				CoreImports.ShowWindowAsync(handle, 1);
			}
		}


		public static bool IsOnScriptThread()
		{
			return Thread.CurrentThread.Name == "ScriptThread";
		}


		public static bool IsOnGuiThread()
		{
			return Thread.CurrentThread.Name == "GUI";
		}


		public static bool IsFileReadOnly(string file_name)
		{
			return (File.GetAttributes(file_name) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
		}




		public static frmFind FindForm
		{
			get
			{
				return m_FindForm;
			}
			set
			{
				m_FindForm = value;
			}
		}




		public static frmMain MainForm
		{
			get
			{
				return m_MainForm;
			}
			set
			{
				m_MainForm = value;
			}
		}


		public static string GetOutputPath()
		{
			string text = Marshal.PtrToStringAnsi(CoreImports.GetOutputDirectoryPath());
			if (string.IsNullOrEmpty(text))
			{
				text = m_RstdSettings.OutputPath;
			}
			return text;
		}


		public static XmlDocument GetXmlTree()
		{
			if (m_XmlTreeWrapper != null)
			{
				return m_XmlTreeWrapper.XmlTree;
			}
			return null;
		}


		public static string[] GetClocks()
		{
			return m_ClocksList;
		}



		public static bool OperationPending
		{
			get
			{
				return m_bOperationPending;
			}
		}


		public static bool bJumpToPath(XmlNode node)
		{
			return m_BrowseTree.bJumpToPath(node);
		}


		public static string LastRunFunctionReturnValue()
		{
			return m_LastRunFunctionReturnValue;
		}



		public static BidirHashtable<XmlNode, XmlNode> RegisterMapping
		{
			get
			{
				return m_XmlTreeWrapper.RegisterMapping;
			}
		}


		public static uint GetNumRemainingTabs()
		{
			return m_NumRemainingTabs;
		}




		public static bool IsClientBuilt
		{
			get
			{
				return m_bIsClientBuilt;
			}
			set
			{
				m_bIsClientBuilt = value;
			}
		}




		public static bool IsAlBuilt
		{
			get
			{
				return m_bIsAlBuilt;
			}
			set
			{
				m_bIsAlBuilt = value;
			}
		}




		public static bool DisableGui
		{
			get
			{
				return m_DisableGui;
			}
			set
			{
				m_DisableGui = value;
			}
		}




		public static EBuildStatus BuildStatus
		{
			get
			{
				return m_BuildStatus;
			}
			set
			{
				m_BuildStatus = value;
			}
		}



		public static frmWorkSet WorkSet
		{
			get
			{
				return m_BrowseTree.WorkSet;
			}
		}




		public static bool UseVerboseLog
		{
			get
			{
				return m_UseVerboseLog;
			}
			set
			{
				m_UseVerboseLog = value;
			}
		}




		public static bool UseUserLog
		{
			get
			{
				return m_UseUserLog;
			}
			set
			{
				m_UseUserLog = value;
			}
		}


		private static string iGetXmlPrefix(XmlNode selNode)
		{
			string str = "<" + selNode.Name;
			for (int i = 0; i < selNode.Attributes.Count; i++)
			{
				str = str + " " + selNode.Attributes[i].OuterXml;
			}
			return str + ">";
		}


		private static string iGetXmlSuffix(XmlNode selNode)
		{
			return "</" + selNode.Name + ">";
		}


		private static XmlNode iGetCleanNode(XmlNode node)
		{
			XmlNode xmlNode = node.Clone();
			iRemoveRegisterFieldsFromNode_Recursive(xmlNode);
			iRemoveMappedVarsFromNode_Recursive(xmlNode);
			return xmlNode;
		}


		private static string iGetXmlString(XmlNode selNode, bool remove_nodes)
		{
			XmlNode xmlNode = selNode;
			if (remove_nodes)
			{
				xmlNode = iGetCleanNode(selNode);
			}
			if (selNode.Name.Equals("TreeRoot"))
			{
				return xmlNode.OuterXml;
			}
			string text = xmlNode.OuterXml;
			XmlNode parentNode = selNode.ParentNode;
			while (parentNode != null && parentNode.NodeType != XmlNodeType.Document)
			{
				text = iGetXmlPrefix(parentNode) + text + iGetXmlSuffix(parentNode);
				parentNode = parentNode.ParentNode;
			}
			return text;
		}


		public static void RecursiveFind(XmlNode basePathNode, bool recursiveFolder, string searchStr, bool bCheckName, bool bCheckValue, bool bCheckComment, bool bCheckType, bool bCheckAddress, bool bCheckDescription, bool bMatchCase, bool bWholeWordOnly, bool bRegularExpression, List<XmlNode> nodesFound)
		{
			bool flag = false;
			NodeType nodeType = GetNodeType(basePathNode);
			if ((nodeType > NodeType.VALUE_TYPE_START && nodeType < NodeType.VALUE_TYPE_END) || nodeType == NodeType.FUNCTION)
			{
				if (bCheckName && ibCompare(basePathNode.Attributes["name"].Value, searchStr, bMatchCase, bWholeWordOnly, bRegularExpression))
				{
					nodesFound.Add(basePathNode);
					flag = true;
				}
				if (nodeType != NodeType.FUNCTION)
				{
					if (bCheckType && ibCompare(basePathNode.Attributes["type"].Value, searchStr, bMatchCase, bWholeWordOnly, bRegularExpression))
					{
						nodesFound.Add(basePathNode);
						flag = true;
					}
					if (nodeType == NodeType.FIELD && bCheckDescription && ibCompare(basePathNode.LastChild.Attributes["description"].Value, searchStr, bMatchCase, bWholeWordOnly, bRegularExpression))
					{
						nodesFound.Add(basePathNode);
						flag = true;
					}
					if (nodeType == NodeType.REGISTER && bCheckAddress && basePathNode.Attributes["address"] != null && ibCompare(basePathNode.Attributes["address"].Value, searchStr, bMatchCase, bWholeWordOnly, bRegularExpression))
					{
						nodesFound.Add(basePathNode);
						flag = true;
					}
					if (bCheckValue && !flag)
					{
						XmlNode xmlNode = basePathNode;
						if (nodeType == NodeType.MAPPED_VAR)
						{
							xmlNode = m_XmlTreeWrapper.RegisterMapping[basePathNode];
						}
						if (xmlNode.FirstChild != null && xmlNode.FirstChild.Value.Equals(searchStr) && ibCompare(xmlNode.FirstChild.Value, searchStr, bMatchCase, bWholeWordOnly, bRegularExpression))
						{
							nodesFound.Add(basePathNode);
							flag = true;
						}
					}
					if (bCheckComment && !flag && ibCompare(basePathNode.Attributes["comment"].Value, searchStr, bMatchCase, bWholeWordOnly, bRegularExpression))
					{
						nodesFound.Add(basePathNode);
					}
				}
			}
			for (int i = 0; i < basePathNode.ChildNodes.Count; i++)
			{
				if (recursiveFolder)
				{
					RecursiveFind(basePathNode.ChildNodes[i], recursiveFolder, searchStr, bCheckName, bCheckValue, bCheckComment, bCheckType, bCheckAddress, bCheckDescription, bMatchCase, bWholeWordOnly, bRegularExpression, nodesFound);
				}
			}
		}


		public static bool bGetFolder(string path, out XmlNode xmlFolder)
		{
			return m_XmlParser.bGetFolder(path, out xmlFolder, m_XmlTreeWrapper.XmlTree);
		}


		public static string GetUpperPath(XmlNode xmlItem)
		{
			XmlNode parentNode = xmlItem.ParentNode;
			string text = "";
			while (parentNode != null && !parentNode.NodeType.Equals(XmlNodeType.Document))
			{
				if (parentNode.Name.Equals("Tab") || parentNode.Name.Equals("Folder") || parentNode.Name.Equals("Function") || parentNode.Name.Equals("Register"))
				{
					text = "/" + parentNode.Attributes["name"].Value + text;
				}
				parentNode = parentNode.ParentNode;
			}
			return text;
		}


		public static string GetPathFromNode(XmlNode xml_node)
		{
			if (xml_node.Name == "TreeRoot")
			{
				return "/";
			}
			return GetUpperPath(xml_node) + "/" + xml_node.Attributes["name"].Value;
		}


		private static bool ibGetFuncParamsStr(string funcName, out string paramStr)
		{
			XmlNode xmlNode;
			if (bGetFolder(funcName, out xmlNode))
			{
				paramStr = "(";
				for (int i = 1; i < xmlNode.ChildNodes.Item(0).ChildNodes.Count; i++)
				{
					string text = GetNodeValue(xmlNode.ChildNodes[0].ChildNodes[i]);
					string value = xmlNode.ChildNodes[0].ChildNodes[i].Attributes["type"].Value;
					if (value == "STRING" || value == "FILE" || value == "PATH")
					{
						text = text.Replace("\"", "\\\"");
						paramStr = paramStr + "\"" + text + "\"";
					}
					else
					{
						paramStr += text;
					}
					paramStr += ",";
				}
				paramStr = paramStr.TrimEnd(new char[]
				{
					','
				});
				paramStr += ")";
				return true;
			}
			paramStr = null;
			return false;
		}


		public static bool GetNodeFromPath(string path, out XmlNode xmlFolder)
		{
			return GetNodeFromPath(path, out xmlFolder, true);
		}


		public static bool GetNodeFromPath(string path, out XmlNode xmlFolder, bool b_warn)
		{
			return GetNodeFromPath(path, out xmlFolder, b_warn, m_XmlTreeWrapper.XmlTree);
		}


		public static bool GetNodeFromPath(string path, out XmlNode xmlFolder, bool b_warn, XmlDocument xmlDoc)
		{
			bool folderOrVar = m_XmlParser.GetFolderOrVar(path, out xmlFolder, xmlDoc);
			if (!folderOrVar && b_warn)
			{
				string text = string.Format("Could not find specified path:\n{0}\n", path);
				if (IsOnScriptThread())
				{
					throw new LuaException(text);
				}
				AlwaysPrint(text);
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error in operation: \n" + text);
			}
			return folderOrVar;
		}


		public static List<XmlNode> GetNodeListFromPath(string path)
		{
			return m_XmlParser.GetNodeListFromPath(path);
		}


		public static List<string> GetNodeChildNamesFromPath(string node_path)
		{
			return m_XmlParser.GetNodeChildNamesFromPath(node_path);
		}


		public static bool IsPathInTree(string path)
		{
			return m_XmlTreeWrapper.IsPathInTree(path);
		}


		private static bool ibGetNodeFromFunctionCall(string funcCall, out XmlNode node)
		{
			node = null;
			int num = funcCall.IndexOf('(');
			return num >= 0 && GetNodeFromPath(funcCall.Remove(num), out node);
		}


		private static string[] iGetParamsFromParamsStr(string params_str)
		{
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < params_str.Length; i++)
			{
				if (params_str[i] != ',')
				{
					if (params_str[i] == '"')
					{
						do
						{
							text += params_str[i].ToString();
							i++;
						}
						while (params_str[i] != '"');
						list.Add(text + params_str[i].ToString());
						text = "";
					}
					else if (params_str[i] == '(')
					{
						while (params_str[i] != ')')
						{
							text += params_str[i].ToString();
							i++;
						}
						list.Add(text + params_str[i].ToString());
						text = "";
					}
					else
					{
						text += params_str[i].ToString();
					}
				}
				else
				{
					list.Add(text);
					text = "";
				}
			}
			if (text != "")
			{
				list.Add(text);
			}
			return list.ToArray();
		}


		public static ContainerListViewItem CreateTreeListNode(XmlNode xml_node)
		{
			ContainerListViewItem containerListViewItem = new ContainerListViewItem();
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			NodeType nodeType = GetNodeType(xml_node);
			if (nodeType != NodeType.REGISTER)
			{
				if (nodeType - NodeType.VAR > 1)
				{
					if (nodeType == NodeType.FIELD)
					{
						text = xml_node.ChildNodes[1].Attributes["field_name"].Value;
						text2 = xml_node.ChildNodes[1].Attributes["register_address"].Value;
						text3 = xml_node.ChildNodes[1].Attributes["start_bit"].Value;
						string value = xml_node.ChildNodes[1].Attributes["n_bits"].Value;
						text4 = (int.Parse(text3) + int.Parse(value) - 1).ToString();
						GetDisplayedType(xml_node);
						GetDisplayedFixMode(xml_node);
						text5 = xml_node.ChildNodes[1].Attributes["description"].Value;
					}
				}
				else
				{
					text = xml_node.Attributes["name"].Value;
					GetDisplayedFixMode(xml_node);
					GetDisplayedType(xml_node);
				}
			}
			else
			{
				text = xml_node.Attributes["name"].Value;
				text2 = xml_node.Attributes["address"].Value;
				if (xml_node.Attributes["description"] != null)
				{
					text5 = xml_node.Attributes["description"].Value;
				}
			}
			string displayedValue = GetDisplayedValue(xml_node);
			containerListViewItem.Text = text;
			ContainerListViewSubItem[] subItems = new ContainerListViewSubItem[]
			{
				new ContainerListViewSubItem(displayedValue),
				new ContainerListViewSubItem(text2),
				new ContainerListViewSubItem(text3),
				new ContainerListViewSubItem(text4),
				new ContainerListViewSubItem(text5)
			};
			containerListViewItem.SubItems.AddRange(subItems);
			containerListViewItem.ImageIndex = (int)GetVarIcon(xml_node);
			if (xml_node.Attributes["permission"].Value == "R")
			{
				containerListViewItem.ForeColor = Color.Gray;
			}
			containerListViewItem.Tag = xml_node;
			return containerListViewItem;
		}


		public static void Save2Csv(string output_file_name, List<XmlNode> nodes, bool bIsSubSet, string version, string src_version)
		{
			StreamWriter streamWriter = null;
			try
			{
				streamWriter = new StreamWriter(new FileStream(output_file_name, FileMode.Create, FileAccess.Write));
				if (bIsSubSet)
				{
					streamWriter.Write(iXmlSubSet2Csv(nodes, version, src_version, bIsSubSet));
				}
				else if (m_XmlParser.bNodesAllHwInfo(nodes))
				{
					streamWriter.Write(iXmlHW2Csv(nodes, false));
				}
				else if (!m_XmlParser.bNodesContainHwInfo(nodes))
				{
					streamWriter.Write(iXmlSW2Csv(nodes, false));
				}
				else
				{
					RSTDMessage(RstdConstants.MESSAGE_TYPE.GUI_CLIENT_ERROR, "Export to Csv only separately Registers/Fields or separately Vars");
				}
			}
			catch (Exception ex)
			{
				RSTDMessage(RstdConstants.MESSAGE_TYPE.GUI_CLIENT_ERROR, ex.Message);
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
				streamWriter = null;
			}
		}


		private static StringBuilder iXmlSubSet2Csv(List<XmlNode> nodes, string version, string src_version, bool b_subset)
		{
			string text = "Version";
			if (version != null)
			{
				text = string.Format("{0}, {1}", text, version);
			}
			StringBuilder stringBuilder = new StringBuilder(text);
			text = "Source version";
			if (src_version != null)
			{
				text = string.Format("{0}, {1}", text, src_version);
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(text);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("register name,field_name,address, start_bit, n_bits,value(hex), value(dec), path, fixmode, type, description");
			foreach (XmlNode xmlNode in nodes)
			{
				NodeType nodeType = GetNodeType(xmlNode);
				if (nodeType != NodeType.REGISTER)
				{
					if (nodeType == NodeType.FIELD)
					{
						iAddField2Csv(xmlNode, ref stringBuilder, "SF");
					}
				}
				else
				{
					iAddRegister2Csv(xmlNode, ref stringBuilder, b_subset);
				}
			}
			return stringBuilder;
		}


		private static StringBuilder iXmlSW2Csv(List<XmlNode> nodes, bool b_subset)
		{
			StringBuilder result = new StringBuilder("name,type ,value(hex), value(dec),stride, fixmode ,comment, path\n");
			for (int i = 0; i < nodes.Count; i++)
			{
				iXml2Csv_Rec(nodes[i], ref result, b_subset);
			}
			return result;
		}


		private static StringBuilder iXmlHW2Csv(List<XmlNode> nodes, bool b_subset)
		{
			StringBuilder stringBuilder = new StringBuilder("Version");
			stringBuilder.AppendLine("\n");
			stringBuilder.AppendLine("\nregister name,field_name,address, start_bit, n_bits,value(hex), value(dec), path, fixmode, type, description\n");
			for (int i = 0; i < nodes.Count; i++)
			{
				iXml2Csv_Rec(nodes[i], ref stringBuilder, b_subset);
			}
			return stringBuilder;
		}


		private static void iXml2Csv_Rec(XmlNode node, ref StringBuilder result, bool b_subset)
		{
			NodeType nodeType = GetNodeType(node);
			if (nodeType <= NodeType.RETURN_LIST)
			{
				if (nodeType - NodeType.ROOT > 2)
				{
					int num = nodeType - NodeType.FUNCTION;
					return;
				}
				iAddFolder2Csv(node, ref result, b_subset);
				return;
			}
			else
			{
				if (nodeType == NodeType.REGISTER)
				{
					iAddRegister2Csv(node, ref result, b_subset);
					return;
				}
				if (nodeType - NodeType.VAR <= 1)
				{
					iAddVar2Csv(node, ref result);
					return;
				}
				if (nodeType != NodeType.FIELD)
				{
					return;
				}
				iAddField2Csv(node, ref result, "F");
				return;
			}
		}


		private static void iAddFolder2Csv(XmlNode folder_node, ref StringBuilder result, bool b_subset)
		{
			foreach (object obj in folder_node)
			{
				iXml2Csv_Rec((XmlNode)obj, ref result, b_subset);
			}
		}


		private static void iAddRegister2Csv(XmlNode register_node, ref StringBuilder result, bool b_subset)
		{
			string nodeAttribute = GetNodeAttribute(register_node, "address");
			string nodeAttribute2 = GetNodeAttribute(register_node, "name");
			string displayedValue = GetDisplayedValue(register_node, DisplayType.INTEGER);
			string displayedValue2 = GetDisplayedValue(register_node, DisplayType.HEX);
			string pathFromNode = GetPathFromNode(register_node);
			string value = string.Concat(new string[]
			{
				nodeAttribute2,
				",,",
				nodeAttribute,
				",,,",
				displayedValue2,
				",",
				displayedValue,
				",",
				pathFromNode,
				",,R,"
			});
			result.AppendLine(value);
			if (!b_subset)
			{
				foreach (object obj in register_node)
				{
					iXml2Csv_Rec((XmlNode)obj, ref result, false);
				}
			}
		}


		private static void iAddField2Csv(XmlNode field_node, ref StringBuilder result, string type)
		{
			string nodeAttribute = GetNodeAttribute(field_node, "name");
			string displayedValue = GetDisplayedValue(field_node, DisplayType.INTEGER);
			string displayedValue2 = GetDisplayedValue(field_node, DisplayType.HEX);
			string nodeAttribute2 = GetNodeAttribute(field_node.LastChild, "start_bit");
			string nodeAttribute3 = GetNodeAttribute(field_node.LastChild, "n_bits");
			string pathFromNode = GetPathFromNode(field_node);
			string nodeAttribute4 = GetNodeAttribute(field_node.LastChild, "description");
			string value = "";
			if (!GetNodeAttribute(field_node, "fixmode", ref value))
			{
				value = "";
			}
			string text;
			if (type.Equals("F"))
			{
				text = "";
			}
			else
			{
				text = GetNodeAttribute(field_node.ParentNode, "name");
			}
			text = string.Concat(new string[]
			{
				text,
				",",
				nodeAttribute,
				", ,",
				nodeAttribute2,
				",",
				nodeAttribute3,
				",",
				displayedValue2,
				",",
				displayedValue,
				",",
				pathFromNode,
				",",
				iFix4Csv(value),
				",",
				type,
				",",
				iFix4Csv(nodeAttribute4)
			});
			result.AppendLine(text);
		}


		private static void iAddVar2Csv(XmlNode node, ref StringBuilder result)
		{
			string text = "";
			string text2 = "";
			string nodeAttribute = GetNodeAttribute(node, "stride");
			string nodeAttribute2 = GetNodeAttribute(node, "name");
			string nodeAttribute3 = GetNodeAttribute(node, "type");
			if (bIsDisplayTypeValidForType(DisplayType.HEX, nodeAttribute3))
			{
				text = GetDisplayedValue(node, DisplayType.HEX);
			}
			string text3;
			if (bIsDisplayTypeValidForType(DisplayType.DECIMAL, nodeAttribute3))
			{
				text3 = GetDisplayedValue(node, DisplayType.DECIMAL);
			}
			else
			{
				text3 = GetNodeValue(node);
			}
			if (!GetNodeAttribute(node, "fixmode", ref text2))
			{
				text2 = "";
			}
			string text4 = GetNodeAttribute(node, "comment");
			string pathFromNode = GetPathFromNode(node);
			text4 = iFix4Csv(text4);
			text3 = iFix4Csv(text3);
			text = iFix4Csv(text);
			text2 = iFix4Csv(text2);
			string value = string.Concat(new string[]
			{
				nodeAttribute2,
				",",
				nodeAttribute3,
				",",
				text,
				",",
				text3,
				",",
				nodeAttribute,
				",",
				text2,
				",",
				text4,
				",",
				pathFromNode,
				","
			});
			result.AppendLine(value);
		}


		private static string iFix4Csv(string value)
		{
			value = value.Replace("\"", "\"\"");
			if (value.Contains(","))
			{
				return value = "\"" + value + "\"";
			}
			return value;
		}


		public static bool CheckIfAllSetVarsTransmitted()
		{
			return m_XmlTreeWrapper.CheckIfAllSetVarsTransmitted();
		}


		public static string GetNodeAttribute(XmlNode node, string attrib_name)
		{
			if (node.Attributes[attrib_name] != null)
			{
				return node.Attributes[attrib_name].Value;
			}
			return null;
		}


		public static bool GetNodeAttribute(XmlNode node, string attrib_name, ref string value)
		{
			return m_XmlParser.GetNodeAttribute(node, attrib_name, ref value);
		}


		public static bool GetRegisterInfoForPath(string xml_path, out bool is_full_register, out int reg_type, out uint address, out int start_bit, out int end_bit)
		{
			reg_type = -1;
			address = 0U;
			start_bit = 0;
			end_bit = 0;
			is_full_register = false;
			try
			{
				XmlNode xmlNode;
				if (!GetNodeFromPath(xml_path, out xmlNode, false))
				{
					return false;
				}
				NodeType nodeType = GetNodeType(xmlNode);
				if (nodeType == NodeType.REGISTER)
				{
					is_full_register = true;
					reg_type = int.Parse(xmlNode.Attributes["reg_type"].Value);
					address = uint.Parse(xmlNode.Attributes["address"].Value, NumberStyles.HexNumber);
					start_bit = 0;
					end_bit = int.Parse(xmlNode.Attributes["n_bits"].Value) - 1;
					return true;
				}
				if (nodeType == NodeType.FIELD)
				{
					is_full_register = false;
					reg_type = int.Parse(xmlNode.ParentNode.Attributes["reg_type"].Value);
					address = uint.Parse(xmlNode.ChildNodes[1].Attributes["register_address"].Value, NumberStyles.HexNumber);
					start_bit = int.Parse(xmlNode.ChildNodes[1].Attributes["start_bit"].Value);
					end_bit = int.Parse(xmlNode.ChildNodes[1].Attributes["n_bits"].Value) + start_bit - 1;
					return true;
				}
			}
			catch (Exception ex)
			{
				ErrorMessage(ex.ToString());
			}
			return false;
		}


		private static void iStop()
		{
			CoreImports.RtttCore_Stop();
			while (!CoreImports.bHasStopped())
			{
				Thread.Sleep(100);
			}
		}


		private static void iAbort()
		{
			CoreImports.RtttCore_Abort();
			while (!CoreImports.bHasStopped())
			{
				Thread.Sleep(100);
			}
		}


		private static Dictionary<string, string> iFillVersionPull(XmlNode exposed_root)
		{
			Dictionary<string, string> dictionary = null;
			string value = "";
			string key = "";
			dictionary = new Dictionary<string, string>();
			foreach (object obj in exposed_root.ChildNodes)
			{
				XmlNode node = (XmlNode)obj;
				GetNodeAttribute(node, "version", ref value);
				GetNodeAttribute(node, "name", ref key);
				if (!string.IsNullOrEmpty(value))
				{
					dictionary.Add(key, value);
				}
			}
			return dictionary;
		}


		private static void iMonitorStop()
		{
			CoreImports.MonitorStop();
		}


		private static string iFileDialog(string initial_dir, FileType file_type, DialogType dialog_type)
		{
			FileDialog fileDialog;
			string str;
			if (dialog_type == DialogType.OPEN)
			{
				fileDialog = new OpenFileDialog();
				str = "Open";
			}
			else
			{
				fileDialog = new SaveFileDialog();
				str = "Save";
			}
			switch (file_type)
			{
			case FileType.SCRIPT:
				fileDialog.Title = str + " a script file";
				fileDialog.Filter = "Script files (*.lua; *.txt)|*.lua;*.txt";
				goto IL_120;
			case FileType.XML:
				fileDialog.Title = str + " an XML file";
				fileDialog.Filter = "XML Data Values files (*.xml)|*.xml";
				goto IL_120;
			case FileType.ICON:
				fileDialog.Title = str + " an icon file";
				fileDialog.Filter = "Icon files (*.ico; *.jpg; *.jpeg; *.bmp; *.png)|*.ico; *.jpg; *.jpeg; *.bmp; *.png";
				goto IL_120;
			case FileType.DLL:
				fileDialog.Title = str + " an DLL file";
				fileDialog.Filter = "DLL files (*.dll)|*.dll";
				goto IL_120;
			case FileType.CSV:
				fileDialog.Title = str + " an CSV file";
				fileDialog.Filter = "CSV files (*.csv)|*.csv";
				goto IL_120;
			case FileType.TXT:
				fileDialog.Title = str + " an TXT file";
				fileDialog.Filter = "TXT files (*.txt)|*.txt";
				goto IL_120;
			}
			fileDialog.Title = str + " a file";
			fileDialog.Filter = "All files (*.*)|*.*";
			IL_120:
			fileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(initial_dir))
			{
				fileDialog.InitialDirectory = initial_dir;
			}
			fileDialog.ShowDialog();
			return fileDialog.FileName;
		}


		private static string iRunFunctionAsync(string funcCall, bool is_from_gui_client)
		{
			StringBuilder stringBuilder = new StringBuilder(1048576);
			string text = "";
			string text2 = "";
			try
			{
				if (!ibRunSettingsFunction(funcCall))
				{
					int num = CoreImports.RunFunction(funcCall, stringBuilder);
					if (num != 0)
					{
						if (1 == num)
						{
							text2 = "Function not found. Check function path.\n";
						}
						else if (2 == num)
						{
							text2 = "Error converting function arguments. Check function arguments.\n";
						}
						if (IsOnScriptThread())
						{
							throw new LuaException(text2);
						}
						throw new Exception(text2);
					}
					else
					{
						text = stringBuilder.ToString();
						if (!is_from_gui_client)
						{
							ActivateGuiClientOperationEnd(funcCall, text);
						}
						AlwaysPrint(string.Format("Return values (\"{0}\"): {1}\n", funcCall, text));
					}
				}
			}
			catch (Exception ex)
			{
				string text3 = string.Format("Error In RunFunction(\"{0}\"):\n{1}\n", funcCall, ex.Message);
				m_MainForm.ErrorPrint(text3);
				if (IsOnScriptThread())
				{
					throw new LuaException(text3);
				}
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, text3 + ex.InnerException + "\n", ex.StackTrace);
			}
			finally
			{
			}
			return text;
		}


		private static bool ibRunSettingsFunction(string funcCall)
		{
			XmlNode xmlNode = null;
			if (ibGetNodeFromFunctionCall(funcCall, out xmlNode))
			{
				if (xmlNode == m_RstdSettings.GetSettingsFunction("AL Build"))
				{
					AL_Build(true);
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("AL Init"))
				{
					AL_Init();
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("AL Reset"))
				{
					AL_Reset();
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("Clients Build"))
				{
					Clients_Build(true);
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("Clients Init"))
				{
					Clients_Init();
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("Clients Reset"))
				{
					Clients_Reset();
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("AL UnBuild"))
				{
					AL_UnBuild(true);
					return true;
				}
				if (xmlNode == m_RstdSettings.GetSettingsFunction("Clients UnBuild"))
				{
					Clients_UnBuild(true);
					return true;
				}
			}
			return false;
		}


		private static void iRunFunctionAsyncThreadCompleted(IAsyncResult res)
		{
			RefreshGui();
			CoreAsyncDel_string_bool coreAsyncDel_string_bool = (CoreAsyncDel_string_bool)((AsyncResult)res).AsyncDelegate;
			try
			{
				m_LastRunFunctionReturnValue = coreAsyncDel_string_bool.EndInvoke(res);
			}
			catch (Exception ex)
			{
				RstdException(ex.Message.ToString(), ex.StackTrace);
			}
		}


		private static void iGetSeperatorInCommand(out string SepertorInCommand, string path)
		{
			SepertorInCommand = path[0].ToString();
		}


		private static bool ibIsValueValidForRegister(XmlNode reg_node, string new_val)
		{
			long num;
			if (!long.TryParse(new_val, out num))
			{
				ErrorMessage(string.Format("Value \"{0}\" not valid for register \"{1}\"\n", new_val, reg_node.Attributes["name"].Value));
				return false;
			}
			return true;
		}


		public static DisplayType GetDefaultDispalyType(NodeType node_type)
		{
			DisplayType result = DisplayType.DEFAULT;
			if (node_type == NodeType.REGISTER || node_type == NodeType.FIELD)
			{
				result = RstdGuiSettings.Default.DefaultTypesDict[node_type];
			}
			return result;
		}


		private static long iGetIntValue(XmlNode node, string var_single_value)
		{
			long result = 0L;
			bool flag = false;
			string value = node.Attributes["type"].Value;
			uint num = PrivateImplementationDetails.ComputeStringHash(value);
			if (num <= 2149926011U)
			{
				if (num <= 268302705U)
				{
					if (num <= 72344531U)
					{
						if (num != 71211698U)
						{
							if (num != 72344531U)
							{
								return result;
							}
							if (!(value == "UINT64"))
							{
								return result;
							}
							goto IL_313;
						}
						else
						{
							if (!(value == "UINT16"))
							{
								return result;
							}
							goto IL_313;
						}
					}
					else if (num != 167029943U)
					{
						if (num != 200059396U)
						{
							if (num != 268302705U)
							{
								return result;
							}
							if (!(value == "INT16"))
							{
								return result;
							}
							goto IL_313;
						}
						else
						{
							if (!(value == "INT64"))
							{
								return result;
							}
							goto IL_313;
						}
					}
					else
					{
						if (!(value == "UINT8PTR"))
						{
							return result;
						}
						goto IL_313;
					}
				}
				else if (num <= 665806367U)
				{
					if (num != 324270942U)
					{
						if (num != 665806367U)
						{
							return result;
						}
						if (!(value == "UINT64PTR"))
						{
							return result;
						}
						goto IL_313;
					}
					else
					{
						if (!(value == "INT64PTR"))
						{
							return result;
						}
						goto IL_313;
					}
				}
				else if (num != 813031976U)
				{
					if (num != 1517748251U)
					{
						if (num != 2149926011U)
						{
							return result;
						}
						if (!(value == "FIXCPLXPTR"))
						{
							return result;
						}
					}
					else
					{
						if (!(value == "UINT8"))
						{
							return result;
						}
						goto IL_313;
					}
				}
				else
				{
					if (!(value == "BOOL32"))
					{
						return result;
					}
					goto IL_313;
				}
			}
			else if (num <= 3052385782U)
			{
				if (num <= 2214109151U)
				{
					if (num != 2179202354U)
					{
						if (num != 2214109151U)
						{
							return result;
						}
						if (!(value == "INT32"))
						{
							return result;
						}
						goto IL_313;
					}
					else
					{
						if (!(value == "INT8"))
						{
							return result;
						}
						goto IL_313;
					}
				}
				else if (num != 2286151596U)
				{
					if (num != 2676191253U)
					{
						if (num != 3052385782U)
						{
							return result;
						}
						if (!(value == "UINT32PTR"))
						{
							return result;
						}
						goto IL_313;
					}
					else
					{
						if (!(value == "INT16PTR"))
						{
							return result;
						}
						goto IL_313;
					}
				}
				else
				{
					if (!(value == "UINT32"))
					{
						return result;
					}
					goto IL_313;
				}
			}
			else if (num <= 3481363276U)
			{
				if (num != 3067248607U)
				{
					if (num != 3211190303U)
					{
						if (num != 3481363276U)
						{
							return result;
						}
						if (!(value == "INT8PTR"))
						{
							return result;
						}
						goto IL_313;
					}
					else if (!(value == "FIXCPLX"))
					{
						return result;
					}
				}
				else
				{
					if (!(value == "BOOL8"))
					{
						return result;
					}
					if (!bool.TryParse(var_single_value, out flag))
					{
						long.TryParse(var_single_value, out result);
						return result;
					}
					if (flag)
					{
						return 1L;
					}
					return 0L;
				}
			}
			else if (num != 3561912123U)
			{
				if (num != 3710781388U)
				{
					if (num != 4122909080U)
					{
						return result;
					}
					if (!(value == "FIX"))
					{
						return result;
					}
					ibGetFixedNodeBitPattern(node, ref result, var_single_value);
					return result;
				}
				else
				{
					if (!(value == "UINT16PTR"))
					{
						return result;
					}
					goto IL_313;
				}
			}
			else
			{
				if (!(value == "INT32PTR"))
				{
					return result;
				}
				goto IL_313;
			}
			ibGetFixedNodeBitPattern(node, ref result, var_single_value);
			return result;
			IL_313:
			long.TryParse(var_single_value, out result);
			return result;
		}


		public static string GetSingleValueDisplay(XmlNode node, DisplayType display_type, string single_original_value)
		{
			string text = "(";
			if (single_original_value.Trim().ToUpper().Contains("NAN"))
			{
				return "NaN";
			}
			if (single_original_value == "(null)")
			{
				return single_original_value;
			}
			string value = node.Attributes["type"].Value;
			if ((value == "FIX" || value == "FIXCPLX" || value == "FIXCPLXPTR") && node.Attributes["fixmode"] == null)
			{
				return "NaN";
			}
			if (value == "FIXCPLX" || value == "FLOAT64COMPLEX" || value == "FIXCPLXPTR" || value == "FLOAT64COMPLEXPTR")
			{
				single_original_value = single_original_value.Trim(new char[]
				{
					'(',
					')'
				});
				string[] array = single_original_value.Split(new char[]
				{
					','
				});
				text += GetDisplayedValueSegment(node, display_type, array[0]);
				text = text + "," + GetDisplayedValueSegment(node, display_type, array[1]) + ")";
			}
			else
			{
				text = GetDisplayedValueSegment(node, display_type, single_original_value);
			}
			return text;
		}


		public static string GetDisplayedValueSegment(XmlNode node, DisplayType display_type, string single_original_value)
		{
			string text = single_original_value;
			NodeType nodeType = GetNodeType(node);
			long num = iGetIntValue(node, single_original_value);
			switch (display_type)
			{
			case DisplayType.DECIMAL_SIGNED:
				if (nodeType == NodeType.FIELD)
				{
					int num2;
					int.TryParse(node.ChildNodes[1].Attributes["n_bits"].Value, out num2);
					if ((double)num > Math.Pow(2.0, (double)(num2 - 1)) - 1.0)
					{
						text = Convert.ToString(((num ^ (long)(Math.Pow(2.0, (double)num2) - 1.0)) + 1L) * -1L);
					}
				}
				break;
			case DisplayType.INTEGER:
				text = num.ToString();
				break;
			case DisplayType.HEX:
				if (nodeType == NodeType.FIELD)
				{
					num = Convert.ToInt64(m_XmlTreeWrapper.GetFieldBinaryValue(node, ref single_original_value), 2);
				}
				text = string.Format("0x{0:X}", num);
				break;
			case DisplayType.BINARY:
				if (nodeType == NodeType.FIELD)
				{
					text = m_XmlTreeWrapper.GetFieldBinaryValue(node, ref single_original_value);
				}
				else
				{
					text = Convert.ToString(num, 2);
				}
				text = string.Format("0b{0}", text);
				break;
			case DisplayType.DB10:
				text = string.Format("{0}[db]", (10.0 * Math.Log10(double.Parse(single_original_value))).ToString("R"));
				break;
			case DisplayType.DB20:
				text = string.Format("{0}[db]", (20.0 * Math.Log10(double.Parse(single_original_value))).ToString("R"));
				break;
			}
			return text;
		}


		private static bool ibGetFixedNodeBitPattern(XmlNode node, ref long bit_pattern)
		{
			double num = 0.0;
			string value = node.Attributes["fixmode"].Value;
			double value2;
			if (1 < int.Parse(node.Attributes["length"].Value) && node.FirstChild.Value.Contains(" "))
			{
				value2 = double.Parse(node.FirstChild.Value.Split(new char[]
				{
					' '
				})[0]);
			}
			else
			{
				value2 = double.Parse(node.FirstChild.Value);
			}
			return GetBitPattern(value2, value, ref num, ref bit_pattern);
		}


		private static bool ibGetFixedNodeBitPattern(XmlNode node, ref long bit_pattern, string val_str)
		{
			double value = 0.0;
			double num = 0.0;
			string value2 = node.Attributes["fixmode"].Value;
			try
			{
				value = double.Parse(val_str);
			}
			catch (Exception ex)
			{
				RstdException(ex.ToString(), ex.StackTrace);
				return false;
			}
			return GetBitPattern(value, value2, ref num, ref bit_pattern);
		}


		public static DisplayType GetNodeDisplayType(XmlNode node)
		{
			DisplayType result = DisplayType.DEFAULT;
			string text = GetDisplayedType(node).ToUpper();
			uint num = PrivateImplementationDetails.ComputeStringHash(text);
			if (num <= 1592469244U)
			{
				if (num <= 103337586U)
				{
					if (num != 2524777U)
					{
						if (num == 103337586U)
						{
							if (text == "DB10")
							{
								result = DisplayType.DB10;
							}
						}
					}
					else if (text == "DB20")
					{
						result = DisplayType.DB20;
					}
				}
				else if (num != 1219467820U)
				{
					if (num == 1592469244U)
					{
						if (text == "BINARY")
						{
							result = DisplayType.BINARY;
						}
					}
				}
				else if (text == "DECIMAL")
				{
					result = DisplayType.DECIMAL;
				}
			}
			else if (num <= 2095186942U)
			{
				if (num != 1873109273U)
				{
					if (num == 2095186942U)
					{
						if (text == "DEFAULT")
						{
							result = DisplayType.DEFAULT;
						}
					}
				}
				else if (text == "DECIMAL_SIGNED")
				{
					result = DisplayType.DECIMAL_SIGNED;
				}
			}
			else if (num != 2173638954U)
			{
				if (num == 2367501349U)
				{
					if (text == "INTEGER")
					{
						result = DisplayType.INTEGER;
					}
				}
			}
			else if (text == "HEX")
			{
				result = DisplayType.HEX;
			}
			return result;
		}


		public static bool GetBitPattern(double value, string q_notation, ref double q_value, ref long bit_pattern)
		{
			return !(q_notation == "UNINITIALIZED") && CoreImports.GetBitPattern(value, q_notation, out q_value, out bit_pattern);
		}


		public static string GetValueFromOption(string option_str)
		{
			string text = option_str.Trim();
			int num = text.IndexOf('}');
			if (num != -1)
			{
				text = text.Remove(num);
			}
			return text.Trim(new char[]
			{
				' ',
				'{',
				'}'
			});
		}


		private static void iUpdateVar(UpdateDialog update_dlg, ref string new_val, ref bool isTransmit)
		{
			if (DialogResult.OK == update_dlg.ShowDialog() && update_dlg.bHasValidValue())
			{
				new_val = update_dlg.GetValue();
			}
			isTransmit = update_dlg.bIsTransmit;
			update_dlg = null;
		}


		private static void iUpdateFileVar(string old_val, ref string new_val)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select a file";
			openFileDialog.Filter = "All Files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;
			if (File.Exists(old_val))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(old_val);
			}
			openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(openFileDialog.FileName))
			{
				new_val = openFileDialog.FileName;
			}
			if (openFileDialog != null)
			{
			}
		}


		private static void iUpdatePathVar(string old_val, ref string new_val)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Select Folder";
			if (Directory.Exists(old_val))
			{
				folderBrowserDialog.SelectedPath = old_val;
			}
			if (DialogResult.OK == folderBrowserDialog.ShowDialog())
			{
				new_val = folderBrowserDialog.SelectedPath;
			}
			if (folderBrowserDialog != null)
			{
			}
		}


		public static bool iGetToolTip(ContainerListView list_view, ContainerListViewItem item, MouseEventArgs e, int subitem_index, ToolTip tooltip)
		{
			if (!string.IsNullOrEmpty(item.SubItems[subitem_index].Text))
			{
				Rectangle rectangle = list_view.HeaderColumnRect(subitem_index);
				if (e.X >= rectangle.Left && e.X <= rectangle.Right)
				{
					SizeF sizeF = list_view.CreateGraphics().MeasureString(item.SubItems[subitem_index].Text, item.SubItems[subitem_index].Font);
					if ((sizeF.Width > (float)rectangle.Width || (float)list_view.ClientRectangle.Right < (float)rectangle.Left + sizeF.Width) && item.SubItems[subitem_index].Text != tooltip.GetToolTip(list_view))
					{
						tooltip.SetToolTip(list_view, item.SubItems[subitem_index].Text);
					}
					return true;
				}
			}
			return false;
		}


		public static void AlwaysPrint(string text)
		{
			if (m_dAlwaysPrint != null)
			{
				iAlwaysPrint(0U, text);
			}
		}


		private static void iAlwaysPrint(uint print_level, string text)
		{
			if (m_dAlwaysPrint != null)
			{
				AlwaysPrint(print_level, 0U, text);
			}
		}


		private static void iDoCoreMsg(string msg)
		{
			if (m_dCoreMsg != null)
			{
				m_dCoreMsg(msg);
			}
		}


		private static uint iDoMsgBox(uint msg_type, string msg)
		{
			if (m_dCoreMsgBox != null)
			{
				return m_dCoreMsgBox(msg_type, msg);
			}
			return 0U;
		}


		public static void RefreshGui()
		{
			if (m_dRefreshGui != null)
			{
				m_dRefreshGui();
			}
		}


		private static void iParseClockList(StringBuilder clockSb)
		{
			m_ClocksList = clockSb.ToString().Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (m_ClocksList.Length != 0 && !m_ClocksList[0].StartsWith("1"))
			{
				Array.Sort<string>(m_ClocksList, new Comparison<string>(string.Compare));
			}
		}


		private static void iCreateDirectoryIfNotExists(string dirName)
		{
			if (!Directory.Exists(dirName))
			{
				Directory.CreateDirectory(dirName);
			}
		}


		private static void iTransmitAsync(XmlNode node)
		{
			iTransmitAsync(ReceiveTransmit_T.XML_PATH, new List<XmlNode>
			{
				node
			}, null);
		}


		private static void iTransmitAsync(ReceiveTransmit_T transmitType, List<XmlNode> nodes, frmSubSet sub_set)
		{
			if (nodes.Count == 0)
			{
				return;
			}
			m_bOperationPending = true;
			iTransmitBegin(transmitType, nodes);
			iTransmit(nodes);
			iTransmitEnd(nodes, sub_set);
			m_bOperationPending = false;
		}


		private static void iTransmitBegin(ReceiveTransmit_T transmitType, List<XmlNode> nodes)
		{
			for (int i = nodes.Count - 1; i >= 0; i--)
			{
				switch (transmitType)
				{
				case ReceiveTransmit_T.XML_PATH:
					VerbosePrint(string.Format("RSTD.Transmit(\"{0}\")\n", GetPathFromNode(nodes[i])));
					break;
				case ReceiveTransmit_T.ARRAY_VAR:
					VerbosePrint(string.Format("RSTD.TransmitArray(\"{0}\")\n", GetPathFromNode(nodes[i])));
					break;
				}
				if (bNodeIsReadOnly(nodes[i]))
				{
					VerbosePrint("Transmit: Ignored. Var is set as Read-Only.\n");
					nodes.Remove(nodes[i]);
				}
				else if (nodes[i].Name == "Var" && nodes[i].Attributes["type"].Value == "STRING" && GetNodeValue(nodes[i]) == "")
				{
					nodes[i].InnerText = " ";
				}
			}
			m_XmlTreeWrapper.AddMappedFields(nodes);
			iRemoveDuplicatedFields(nodes);
		}


		public static bool bNodeIsReadOnly(XmlNode node)
		{
			bool result = false;
			if (node.Attributes["permission"] != null && node.Attributes["permission"].Value == "R")
			{
				result = true;
			}
			return result;
		}


		private static void iTransmit(List<XmlNode> nodes)
		{
			if (nodes.Count == 0)
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			iCreateTreeFromNodes(nodes, xmlDocument, false);
			iInsertSpacesToEmptyStringVars_Recursive(xmlDocument.DocumentElement);
			if (m_ExternalTransmit != null && iContainsExternalUpdateTab(xmlDocument.DocumentElement))
			{
				XmlNode xmlNode;
				XmlNode xmlNode2;
				iSplitXmlExtInt(xmlDocument.DocumentElement, out xmlNode, out xmlNode2);
				if (xmlNode != null)
				{
					xmlNode = iGetCleanNode(xmlNode);
					m_ExternalTransmit(xmlNode);
				}
				if (xmlNode2 != null)
				{
					iTransmit_internal(xmlNode2);
				}
			}
			else
			{
				iTransmit_internal(xmlDocument.DocumentElement);
			}
		}


		private static void iTransmit_internal(XmlNode node)
		{
			CoreImports.Transmit(iGetXmlString(node, true));
		}


		private static bool iContainsExternalUpdateTab(XmlNode root_node)
		{
			foreach (object obj in root_node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.Attributes["update_type"] != null && xmlNode.Attributes["update_type"].Value == "ext")
				{
					return true;
				}
			}
			return false;
		}


		private static void iSplitXmlExtInt(XmlNode root_node, out XmlNode ext_node, out XmlNode int_node)
		{
			List<XmlNode> list = new List<XmlNode>();
			XmlDocument xmlDocument = new XmlDocument();
			ext_node = null;
			int_node = null;
			foreach (object obj in root_node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.Attributes["update_type"] != null && xmlNode.Attributes["update_type"].Value == "ext")
				{
					ext_node = xmlNode;
				}
				else
				{
					list.Add(xmlNode);
				}
			}
			if (list.Count > 0)
			{
				iCreateTreeFromNodes(list, xmlDocument, false);
				int_node = xmlDocument.DocumentElement;
			}
		}


		private static void iTransmitEnd(List<XmlNode> nodes, frmSubSet sub_set)
		{
			foreach (XmlNode xmlNode in nodes)
			{
				m_XmlTreeWrapper.ReplaceAttributeValuesWithinNode_Recursive(xmlNode, "is_updated", true.ToString());
				if (frmMain.gGui_updated_mode == GUI_REGISTER_UPDATED_MODE.ON_FIELDS_UPDATE && GetNodeType(xmlNode) == NodeType.FIELD)
				{
					xmlNode.ParentNode.Attributes["is_updated"].Value = m_XmlTreeWrapper.bAreAllRegisterFieldsUpdated(xmlNode.ParentNode).ToString();
				}
			}
			if (sub_set != null)
			{
				sub_set.RefreshDisplay();
			}
		}


		private static void iAsyncThreadCompleted(IAsyncResult res)
		{
			CoreAsyncDel_OperationTypeNodeListAndSubSet coreAsyncDel_OperationTypeNodeListAndSubSet = (CoreAsyncDel_OperationTypeNodeListAndSubSet)((AsyncResult)res).AsyncDelegate;
			try
			{
				coreAsyncDel_OperationTypeNodeListAndSubSet.EndInvoke(res);
			}
			catch (Exception ex)
			{
				RstdException(ex.Message.ToString(), ex.StackTrace);
			}
			m_DisableGui = false;
			RefreshGui();
		}


		public static void AL_Build(bool isManual)
		{
			if (m_bIsAlBuilt)
			{
				if (isManual)
				{
					AlwaysPrint("Ignored: Attempt to call AL_Build() twice\n");
				}
				return;
			}
			VerbosePrint("RSTD.AL_Build()\n");
			StringBuilder stringBuilder = new StringBuilder(31457280);
			CoreImports.bAL_Build(stringBuilder);
			m_XmlTreeWrapper.Load(stringBuilder.ToString());
			m_XmlTreeWrapper.AppendGuiAttributesToXmlTree();
			m_BrowseTree.Build();
			m_bIsAlBuilt = true;
			m_BuildStatus |= EBuildStatus.AL_Built;
		}


		public static void AL_Init()
		{
			if (!m_bIsAlBuilt)
			{
				RstdException("Abstraction Layer must be built first", "");
				return;
			}
			VerbosePrint("RSTD.AL_Init()\n");
			CoreImports.AL_Init();
			m_BuildStatus |= EBuildStatus.AL_Init;
		}


		public static void AL_Reset()
		{
			if (!m_bIsAlBuilt)
			{
				RstdException("Abstraction Layer must be built first", "");
				return;
			}
			VerbosePrint("RSTD.AL_Reset()\n");
			CoreImports.AL_Reset();
			m_BuildStatus |= EBuildStatus.AL_Reset;
		}


		public static void AL_UnBuild(bool isManual)
		{
			if (!m_bIsAlBuilt)
			{
				if (isManual)
				{
					AlwaysPrint("Ignored: Attempt to calls AL_UnBuild() before AL_Build()\n");
				}
				return;
			}
			VerbosePrint("RSTD.AL_UnBuild()\n");
			m_NumRemainingTabs = CoreImports.AL_UnBuild();
			XmlNode xmlTreeRoot = m_XmlTreeWrapper.XmlTreeRoot;
			object autoUpdateListLocker = m_BrowseTree.AutoUpdateListLocker;
			lock (autoUpdateListLocker)
			{
				int num = xmlTreeRoot.ChildNodes.Count - 1;
				while ((long)num >= (long)((ulong)m_NumRemainingTabs))
				{
					xmlTreeRoot.RemoveChild(xmlTreeRoot.ChildNodes[num]);
					num--;
				}
			}
			if (isManual)
			{
				m_MainForm.UnBuildEnd();
			}
			m_bIsAlBuilt = false;
			m_BuildStatus = EBuildStatus.AL_UnBuilt;
		}


		public static void Clients_Build(bool isManual)
		{
			StringBuilder stringBuilder = new StringBuilder(31457280);
			StringBuilder stringBuilder2 = new StringBuilder(1024);
			if (m_bIsClientBuilt)
			{
				AlwaysPrint("Ignored: Attempt to Build() again\n");
				return;
			}
			if (!m_bIsAlBuilt)
			{
				RstdException("Attempt to call Client_Build() before AL_Build()\n", "");
				return;
			}
			VerbosePrint("RSTD.Clients_Build()\n");
			CoreImports.bConfigSettings();
			CoreImports.bRtttCore_Build(stringBuilder, stringBuilder2);
			m_XmlTreeWrapper.Load(stringBuilder.ToString());
			iParseClockList(stringBuilder2);
			m_XmlTreeWrapper.AppendGuiAttributesToXmlTree();
			m_XmlTreeWrapper.CalcRegs();
			if (isManual)
			{
				m_MainForm.BuildEnd();
			}
		}


		public static void Clients_Init()
		{
			if (!m_bIsClientBuilt)
			{
				RstdException("Client must be built first", "");
				return;
			}
			VerbosePrint("RSTD.Clients_Init()\n");
			CoreImports.Clients_Init();
			m_BuildStatus |= EBuildStatus.Client_Init;
		}


		public static void Clients_Reset()
		{
			if (!m_bIsClientBuilt)
			{
				RstdException("Client must be built first", "");
				return;
			}
			VerbosePrint("Clients_Reset()\n");
			CoreImports.Clients_Reset();
			m_BuildStatus |= EBuildStatus.Client_Reset;
		}


		public static void Clients_UnBuild(bool isManual)
		{
			if (!m_bIsClientBuilt)
			{
				if (isManual)
				{
					AlwaysPrint("Ignored: Attempt to call Client_Unbuild() before Client_Build()\n");
				}
				return;
			}
			VerbosePrint("RSTD.Clients_UnBuild()\n");
			m_NumRemainingTabs = CoreImports.RtttCore_UnBuild();
			m_BrowseTree.UnBuild();
			XmlNode xmlTreeRoot = m_XmlTreeWrapper.XmlTreeRoot;
			object autoUpdateListLocker = m_BrowseTree.AutoUpdateListLocker;
			lock (autoUpdateListLocker)
			{
				int num = xmlTreeRoot.ChildNodes.Count - 1;
				while ((long)num >= (long)((ulong)m_NumRemainingTabs))
				{
					xmlTreeRoot.RemoveChild(xmlTreeRoot.ChildNodes[num]);
					num--;
				}
			}
			if (isManual)
			{
				m_MainForm.UnBuildEnd();
			}
			m_ClocksList = null;
			m_MainForm.CleanSubsetList();
		}


		public static string GetNodeValue(XmlNode node)
		{
			if (node == null)
			{
				return null;
			}
			if (GetNodeType(node) == NodeType.MAPPED_VAR)
			{
				return m_XmlTreeWrapper.RegisterMapping[node].FirstChild.Value;
			}
			if (node.FirstChild == null)
			{
				return "";
			}
			return node.FirstChild.Value;
		}


		private static void iBuild()
		{
			m_bOperationPending = true;
			iTransmitAsync(m_XmlTreeWrapper.XmlTreeRoot);
			AL_Build(false);
			m_RstdSettings.LoadALXml();
			iTransmitAsync(m_XmlTreeWrapper.XmlTreeRoot);
			AL_Init();
			Clients_Build(false);
			m_RstdSettings.LoadClientXml();
			m_bOperationPending = false;
		}


		private static void iCalcRegisterFieldsValues(XmlNode node)
		{
			if (node.Name == "Register")
			{
				bCalcFieldsFromRegister(node);
				return;
			}
			foreach (object obj in ((XmlElement)node).GetElementsByTagName("Register"))
			{
				bCalcFieldsFromRegister((XmlNode)obj);
			}
		}


		private static void iGo()
		{
			CoreImports.RtttCore_Go();
		}


		private static void iUnBuild()
		{
			Clients_UnBuild(false);
			AL_UnBuild(false);
		}


		private static void iBuildAsyncThreadCompleted(IAsyncResult res)
		{
			iHandleAsyncThreadExceptions(res);
			m_MainForm.BuildEnd();
		}


		private static void iGoAsyncThreadCompleted(IAsyncResult res)
		{
			iHandleAsyncThreadExceptions(res);
			m_MainForm.GoEnd();
		}


		private static void iStopAsyncThreadCompleted(IAsyncResult res)
		{
			iHandleAsyncThreadExceptions(res);
			m_MainForm.StopEnd();
		}


		private static void iMonitorStopAsyncThreadCompleted(IAsyncResult res)
		{
			iHandleAsyncThreadExceptions(res);
			m_BrowseTree.MonitoredVars.MonitorStopEnd();
		}


		private static void iUnBuildAsyncThreadCompleted(IAsyncResult res)
		{
			iHandleAsyncThreadExceptions(res);
			m_MainForm.UnBuildEnd();
		}


		private static void iHandleAsyncThreadExceptions(IAsyncResult res)
		{
			CoreAsyncDel coreAsyncDel = (CoreAsyncDel)((AsyncResult)res).AsyncDelegate;
			try
			{
				coreAsyncDel.EndInvoke(res);
			}
			catch (Exception ex)
			{
				RstdException(ex.Message.ToString(), ex.StackTrace);
			}
		}


		private static void iReceiveAsync(ReceiveTransmit_T receiveType, List<XmlNode> nodes, frmSubSet sub_set)
		{
			if (nodes.Count == 0)
			{
				return;
			}
			m_bOperationPending = true;
			iReceiveBegin(receiveType, nodes);
			iReceive(nodes);
			iReceiveEnd(nodes, sub_set);
			m_bOperationPending = false;
		}


		private static void iReceiveBegin(ReceiveTransmit_T receiveType, List<XmlNode> nodes)
		{
			foreach (XmlNode xmlNode in nodes)
			{
				switch (receiveType)
				{
				case ReceiveTransmit_T.XML_PATH:
					VerbosePrint(string.Format("RSTD.Receive(\"{0}\")\n", GetPathFromNode(xmlNode)));
					break;
				case ReceiveTransmit_T.ARRAY_VAR:
					VerbosePrint(string.Format("RSTD.ReceiveArray(\"{0}\",{1},{2},{3})\n", new object[]
					{
						GetPathFromNode(xmlNode),
						xmlNode.Attributes["offset"].Value,
						xmlNode.Attributes["stride"].Value,
						xmlNode.Attributes["length"].Value
					}));
					break;
				case ReceiveTransmit_T.RECEIVE_AND_GET:
					VerbosePrint(string.Format("RSTD.ReceiveAndGet(\"{0}\")\n", GetPathFromNode(xmlNode)));
					break;
				}
				if (xmlNode.Name == "Var" && xmlNode.Attributes["type"].Value == "STRING" && GetNodeValue(xmlNode) == "")
				{
					xmlNode.InnerText = " ";
				}
			}
			m_XmlTreeWrapper.AddMappedFields(nodes);
			iRemoveDuplicatedFields(nodes);
		}


		private static void iRemoveDuplicatedFields(List<XmlNode> nodes)
		{
			List<XmlNode> list = new List<XmlNode>();
			foreach (XmlNode xmlNode in nodes)
			{
				if (GetNodeType(xmlNode) == NodeType.FIELD)
				{
					list.Add(xmlNode);
				}
			}
			foreach (XmlNode xmlNode2 in list)
			{
				bool flag = false;
				int num = 0;
				while (num < nodes.Count && !flag)
				{
					if (nodes[num] == xmlNode2.ParentNode)
					{
						nodes.Remove(xmlNode2);
						flag = true;
					}
					num++;
				}
			}
		}


		private static void iReceive(List<XmlNode> nodes)
		{
			if (nodes.Count == 0)
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			iCreateTreeFromNodes(nodes, xmlDocument, false);
			iInsertSpacesToEmptyStringVars_Recursive(xmlDocument.DocumentElement);
			if (m_ExternalReceive != null && iContainsExternalUpdateTab(xmlDocument.DocumentElement))
			{
				XmlNode xmlNode;
				XmlNode xmlNode2;
				iSplitXmlExtInt(xmlDocument.DocumentElement, out xmlNode, out xmlNode2);
				if (xmlNode != null)
				{
					m_ExternalReceive(ref xmlNode);
					xmlDocument.DocumentElement.RemoveAll();
					xmlDocument.DocumentElement.AppendChild(xmlNode);
					m_XmlTreeWrapper.MergeToMainXmlTree(nodes[0].OwnerDocument, xmlDocument.DocumentElement);
				}
				if (xmlNode2 != null)
				{
					iReceive_internal(nodes[0].OwnerDocument, xmlNode2);
				}
			}
			else
			{
				iReceive_internal(nodes[0].OwnerDocument, xmlDocument.DocumentElement);
			}
		}


		private static void iReceive_internal(XmlDocument owning_doc, XmlNode node)
		{
			XmlDocument xmlDocument = new XmlDocument();
			string text = iGetXmlString(node, true);
			StringBuilder stringBuilder = new StringBuilder(Math.Min(text.Length * 2, 31457280));
			stringBuilder.Append(text);
			stringBuilder = stringBuilder.Replace("\r\n", "@NL");
			CoreImports.Receive(stringBuilder);
			stringBuilder = stringBuilder.Replace("@NL", "\r\n");
			xmlDocument.LoadXml(stringBuilder.ToString());
			m_XmlTreeWrapper.MergeToMainXmlTree(owning_doc, xmlDocument.SelectSingleNode("/TreeRoot"));
		}


		private static void iReceiveEnd(List<XmlNode> nodes, frmSubSet sub_set)
		{
			foreach (XmlNode xmlNode in nodes)
			{
				iCalcRegisterFieldsValues(xmlNode);
				if (xmlNode.ParentNode.Name == "Register")
				{
					m_XmlTreeWrapper.CalcRegisterValue(xmlNode.ParentNode);
				}
				m_XmlTreeWrapper.ReplaceAttributeValuesWithinNode_Recursive(xmlNode, "is_updated", true.ToString());
			}
			if (sub_set != null)
			{
				sub_set.RefreshDisplay();
			}
		}


		private static bool ibGetCplxValueToSet(XmlNode var_node, ref string value)
		{
			string[] array = value.Trim(new char[]
			{
				'(',
				')'
			}).Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 2)
			{
				ErrorMessage(string.Format("SetVar: value \"{0}\" is not a valid complex format\n", value));
				return false;
			}
			DisplayType display_type = (DisplayType)Enum.Parse(typeof(DisplayType), var_node.Attributes["display_type"].Value, true);
			if (!bGetNumericValueToSet(var_node, display_type, ref array[0], false))
			{
				return false;
			}
			if (!bGetNumericValueToSet(var_node, display_type, ref array[1], false))
			{
				return false;
			}
			value = string.Format("({0},{1})", array[0], array[1]);
			return true;
		}


		public static bool bSetVarValue(XmlNode var_node, string value)
		{
			if (!string.IsNullOrEmpty(var_node.Attributes["options"].Value))
			{
				bGetValueFromOptions(var_node, ref value);
			}
			string value2 = var_node.Attributes["type"].Value;
			if (value2 != "STRING" && value2 != "FILE" && value2 != "PATH")
			{
				string[] array = value.Split(new char[]
				{
					' '
				}, StringSplitOptions.RemoveEmptyEntries);
				value = "";
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						if (value2 == "FIXCPLX" || value2 == "FIXCPLXPTR" || value2 == "FLOAT64COMPLEX" || value2 == "FLOAT64COMPLEXPTR")
						{
							if (!ibGetCplxValueToSet(var_node, ref array[i]))
							{
								return false;
							}
						}
						else
						{
							DisplayType display_type = (DisplayType)Enum.Parse(typeof(DisplayType), var_node.Attributes["display_type"].Value, true);
							if (!bGetNumericValueToSet(var_node, display_type, ref array[i], false))
							{
								return false;
							}
						}
						value = value + array[i] + " ";
					}
				}
				value = value.Trim();
			}
			NodeType nodeType = GetNodeType(var_node);
			if (nodeType != NodeType.REGISTER)
			{
				if (nodeType != NodeType.FIELD)
				{
					if (var_node.Attributes["type"].Value.StartsWith("BOOL"))
					{
						if (value == "1" || value.ToUpper() == "TRUE")
						{
							var_node.InnerText = "TRUE";
						}
						else if (value == "0" || value.ToUpper() == "FALSE")
						{
							var_node.InnerText = "FALSE";
						}
					}
					else if (var_node.FirstChild == null)
					{
						var_node.InnerText = value;
					}
					else
					{
						var_node.FirstChild.Value = value;
					}
				}
				else
				{
					if (m_XmlTreeWrapper.GetFieldBinaryValue(var_node, ref value) == null)
					{
						return false;
					}
					var_node.FirstChild.Value = value;
					m_XmlTreeWrapper.CalcRegisterValue(var_node.ParentNode);
				}
			}
			else
			{
				if (!ibIsValueValidForRegister(var_node, value))
				{
					return false;
				}
				var_node.FirstChild.Value = value;
				var_node.Attributes["is_updated"].Value = false.ToString();
				bCalcFieldsFromRegister(var_node);
			}
			return true;
		}


		private static string HandleDBValue(string value, DisplayType display_type)
		{
			int num = 10;
			value = value.Remove(value.Length - "[db]".Length);
			if (display_type == DisplayType.DB10)
			{
				num = 10;
			}
			else if (display_type == DisplayType.DB20)
			{
				num = 20;
			}
			value = Math.Pow(10.0, double.Parse(value) / (double)num).ToString("R");
			return value;
		}


		private static long HandleHexAndBinaryValue(string value)
		{
			long result = 0L;
			if (value.StartsWith("0x"))
			{
				result = Convert.ToInt64(value, 16);
			}
			else if (value.StartsWith("0b"))
			{
				value = value.Remove(0, 2);
				if (!Regex.IsMatch(value, "^[01]+$"))
				{
					throw new RstdException(string.Format("value \"{0}\" is not a valid binary value.", value));
				}
				result = Convert.ToInt64(value, 2);
			}
			return result;
		}


		public static bool IsDisplayTypeBitPattern(DisplayType display_type)
		{
			return display_type == DisplayType.INTEGER || display_type == DisplayType.BINARY || display_type == DisplayType.HEX;
		}


		private static string HandleNoPrefixValue(XmlNode var_node, string value, string var_type, DisplayType display_type, bool check_bitpattern_display)
		{
			double value2 = 0.0;
			double num = 0.0;
			long num2 = 0L;
			if ((var_type == "FIX" || var_type == "FIXCPLX" || var_type == "FIXCPLXPTR") && value.Trim().ToUpper() != "NAN")
			{
				if (check_bitpattern_display && IsDisplayTypeBitPattern(display_type))
				{
					CoreImports.GetFixedValue(long.Parse(value), var_node.Attributes["fixmode"].Value, out value2, out num);
					if (GetNodeType(var_node) == NodeType.FIELD)
					{
						value = num.ToString("R");
					}
					else
					{
						value = value2.ToString("R");
					}
				}
				else
				{
					value2 = double.Parse(value);
					if (GetNodeType(var_node) == NodeType.FIELD)
					{
						if (!GetBitPattern(value2, var_node.Attributes["fixmode"].Value, ref num, ref num2))
						{
							throw new RstdException("Could not get Q() value for value entered");
						}
						value = num.ToString("R");
					}
					else
					{
						value = value2.ToString("R");
					}
				}
			}
			return value;
		}


		public static bool bGetNumericValueToSet(XmlNode var_node, DisplayType display_type, ref string value, bool check_bitpattern_display)
		{
			double num = 0.0;
			double num2 = 0.0;
			string value2 = var_node.Attributes["type"].Value;
			try
			{
				if (value.EndsWith("[db]"))
				{
					value = HandleDBValue(value, display_type);
				}
				else if (value.StartsWith("0x") || value.StartsWith("0b"))
				{
					long bit_pattern = HandleHexAndBinaryValue(value);
					if (value2 == "FIX" || value2 == "FIXCPLX" || value2 == "FIXCPLXPTR")
					{
						CoreImports.GetFixedValue(bit_pattern, var_node.Attributes["fixmode"].Value, out num, out num2);
						if (GetNodeType(var_node) == NodeType.FIELD)
						{
							value = num2.ToString("R");
						}
						else
						{
							value = num.ToString("R");
						}
					}
					else
					{
						value = bit_pattern.ToString();
					}
				}
				else
				{
					value = HandleNoPrefixValue(var_node, value, value2, display_type, check_bitpattern_display);
				}
			}
			catch (Exception ex)
			{
				ErrorMessage("SetVar: " + ex.Message);
				return false;
			}
			return true;
		}


		public static bool ValidateInt(string type, string text, out string actual_val, out string err_msg)
		{
			bool flag = true;
			actual_val = text;
			if (text.StartsWith("0x"))
			{
				flag = Regex.IsMatch(text, "\\A\\b(0[x])?[0-9a-fA-F]+\\b\\Z");
			}
			else if (text.StartsWith("0b"))
			{
				flag = Regex.IsMatch(text, "\\A\\b(0[b])?[01]+\\b\\Z");
			}
			else
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(type);
				if (num <= 1517748251U)
				{
					if (num <= 200059396U)
					{
						if (num <= 72344531U)
						{
							if (num != 71211698U)
							{
								if (num != 72344531U)
								{
									goto IL_361;
								}
								if (!(type == "UINT64"))
								{
									goto IL_361;
								}
								goto IL_34C;
							}
							else
							{
								if (!(type == "UINT16"))
								{
									goto IL_361;
								}
								goto IL_31E;
							}
						}
						else if (num != 167029943U)
						{
							if (num != 200059396U)
							{
								goto IL_361;
							}
							if (!(type == "INT64"))
							{
								goto IL_361;
							}
						}
						else
						{
							if (!(type == "UINT8PTR"))
							{
								goto IL_361;
							}
							goto IL_307;
						}
					}
					else if (num <= 324270942U)
					{
						if (num != 268302705U)
						{
							if (num != 324270942U)
							{
								goto IL_361;
							}
							if (!(type == "INT64PTR"))
							{
								goto IL_361;
							}
						}
						else
						{
							if (!(type == "INT16"))
							{
								goto IL_361;
							}
							goto IL_2BC;
						}
					}
					else if (num != 665806367U)
					{
						if (num != 1517748251U)
						{
							goto IL_361;
						}
						if (!(type == "UINT8"))
						{
							goto IL_361;
						}
						goto IL_307;
					}
					else
					{
						if (!(type == "UINT64PTR"))
						{
							goto IL_361;
						}
						goto IL_34C;
					}
					long num2;
					flag = long.TryParse(text, out num2);
					if (flag)
					{
						actual_val = num2.ToString();
						goto IL_361;
					}
					goto IL_361;
					IL_307:
					byte b;
					flag = byte.TryParse(text, out b);
					if (flag)
					{
						actual_val = b.ToString();
						goto IL_361;
					}
					goto IL_361;
					IL_34C:
					ulong num3;
					flag = ulong.TryParse(text, out num3);
					if (flag)
					{
						actual_val = num3.ToString();
						goto IL_361;
					}
					goto IL_361;
				}
				else
				{
					if (num <= 2676191253U)
					{
						if (num <= 2214109151U)
						{
							if (num != 2179202354U)
							{
								if (num != 2214109151U)
								{
									goto IL_361;
								}
								if (!(type == "INT32"))
								{
									goto IL_361;
								}
								goto IL_2D9;
							}
							else if (!(type == "INT8"))
							{
								goto IL_361;
							}
						}
						else if (num != 2286151596U)
						{
							if (num != 2676191253U)
							{
								goto IL_361;
							}
							if (!(type == "INT16PTR"))
							{
								goto IL_361;
							}
							goto IL_2BC;
						}
						else
						{
							if (!(type == "UINT32"))
							{
								goto IL_361;
							}
							goto IL_335;
						}
					}
					else if (num <= 3481363276U)
					{
						if (num != 3052385782U)
						{
							if (num != 3481363276U)
							{
								goto IL_361;
							}
							if (!(type == "INT8PTR"))
							{
								goto IL_361;
							}
						}
						else
						{
							if (!(type == "UINT32PTR"))
							{
								goto IL_361;
							}
							goto IL_335;
						}
					}
					else if (num != 3561912123U)
					{
						if (num != 3710781388U)
						{
							goto IL_361;
						}
						if (!(type == "UINT16PTR"))
						{
							goto IL_361;
						}
						goto IL_31E;
					}
					else
					{
						if (!(type == "INT32PTR"))
						{
							goto IL_361;
						}
						goto IL_2D9;
					}
					sbyte b2;
					flag = sbyte.TryParse(text, out b2);
					if (flag)
					{
						actual_val = b2.ToString();
						goto IL_361;
					}
					goto IL_361;
					IL_2D9:
					int num4;
					flag = int.TryParse(text, out num4);
					if (flag)
					{
						actual_val = num4.ToString();
						goto IL_361;
					}
					goto IL_361;
					IL_335:
					uint num5;
					flag = uint.TryParse(text, out num5);
					if (flag)
					{
						actual_val = num5.ToString();
						goto IL_361;
					}
					goto IL_361;
				}
				IL_2BC:
				short num6;
				flag = short.TryParse(text, out num6);
				if (flag)
				{
					actual_val = num6.ToString();
					goto IL_361;
				}
				goto IL_361;
				IL_31E:
				ushort num7;
				flag = ushort.TryParse(text, out num7);
				if (flag)
				{
					actual_val = num7.ToString();
				}
			}
			IL_361:
			if (!flag)
			{
				err_msg = "Value is not valid for " + type + " type";
			}
			else
			{
				err_msg = "";
			}
			return flag;
		}


		public static bool ValidateFloatingPoint(string type, string val, out string actual_val, out string err_msg)
		{
			bool flag = true;
			actual_val = val;
			if (val.StartsWith("0x"))
			{
				flag = Regex.IsMatch(val, "\\A\\b(0[x])?[0-9a-fA-F]+\\b\\Z");
			}
			else if (val.StartsWith("0b"))
			{
				flag = Regex.IsMatch(val, "\\A\\b(0[b])?[01]+\\b\\Z");
			}
			else if (val.EndsWith("[db]"))
			{
				flag = Regex.IsMatch(val, "^[-+]?\\d*(\\.\\d+)?\\[db\\]$");
			}
			else
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(type);
				if (num <= 1450498067U)
				{
					if (num <= 1414029642U)
					{
						if (num != 1212580912U)
						{
							if (num != 1414029642U)
							{
								goto IL_182;
							}
							if (!(type == "FLOAT32PTR"))
							{
								goto IL_182;
							}
						}
						else if (!(type == "FLOAT32"))
						{
							goto IL_182;
						}
						float num2;
						flag = float.TryParse(val, out num2);
						if (flag)
						{
							actual_val = num2.ToString();
							goto IL_182;
						}
						goto IL_182;
					}
					else if (num != 1415045173U)
					{
						if (num != 1450498067U)
						{
							goto IL_182;
						}
						if (!(type == "FLOAT64PTR"))
						{
							goto IL_182;
						}
					}
					else if (!(type == "FLOAT80"))
					{
						goto IL_182;
					}
				}
				else if (num <= 3695124071U)
				{
					if (num != 2001733715U)
					{
						if (num != 3695124071U)
						{
							goto IL_182;
						}
						if (!(type == "FLOAT64"))
						{
							goto IL_182;
						}
					}
					else if (!(type == "FIXVALPTR"))
					{
						goto IL_182;
					}
				}
				else if (num != 4052975833U)
				{
					if (num != 4122909080U)
					{
						goto IL_182;
					}
					if (!(type == "FIX"))
					{
						goto IL_182;
					}
				}
				else if (!(type == "FLOAT80PTR"))
				{
					goto IL_182;
				}
				double num3;
				flag = double.TryParse(val, out num3);
				if (flag)
				{
					actual_val = num3.ToString();
				}
			}
			IL_182:
			if (!flag)
			{
				err_msg = "Value is not valid for " + type + " type";
			}
			else
			{
				err_msg = "";
			}
			return flag;
		}


		public static bool ValidateComplex(string type, string text, out string actual_val, out string err_msg)
		{
			bool flag = true;
			string[] array = new string[2];
			actual_val = text;
			text = text.TrimStart(new char[]
			{
				'('
			});
			text = text.TrimEnd(new char[]
			{
				')'
			});
			string[] array2 = text.Split(new char[]
			{
				','
			});
			if (array2.Length != 2)
			{
				flag = false;
			}
			else
			{
				int num = 0;
				while (flag && num < array2.Length)
				{
					if ((type == "FIXCPLX" || type == "FIXCPLXPTR" || type == "FLOAT64COMPLEX" || type == "FLOAT64COMPLEXPTR") && !ValidateFloatingPoint("FLOAT64", array2[num], out array[num], out err_msg))
					{
						flag = false;
					}
					num++;
				}
			}
			if (!flag)
			{
				err_msg = "Value is not valid for " + type + " type";
			}
			else
			{
				actual_val = string.Format("({0},{1})", array[0], array[1]);
				err_msg = "";
			}
			return flag;
		}


		public static bool ValidateBool(string val, out string actual_val, out string err_msg)
		{
			err_msg = "";
			actual_val = val;
			if (val.ToUpper() == "TRUE" || val == "1")
			{
				actual_val = "1";
				return true;
			}
			if (val.ToUpper() == "FALSE" || val == "0")
			{
				actual_val = "0";
				return true;
			}
			err_msg = "You have entered an invalid boolean value (accepted values: true,false,1,0)\n";
			return false;
		}


		public static bool ValidateString(string text, out string err_msg)
		{
			err_msg = "";
			return true;
		}


		public static bool ValidateChar(string text, out string err_msg)
		{
			if (text.Length > 1)
			{
				err_msg = "Length cannot be bigger than 1";
				return false;
			}
			err_msg = "";
			return true;
		}


		public static bool ValidateOptionValue(string type, string options, string val, out string error_msg)
		{
			error_msg = "Requested option doesn't exist in the options list";
			bool flag = false;
			string a = "";
			string b = val;
			string[] array = options.Split(new char[]
			{
				','
			});
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].Trim() == val.Trim())
				{
					error_msg = "";
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string valueFromOption = GetValueFromOption(array2[i]);
					if (!iValidateSingleVal(type, valueFromOption, out a, out error_msg))
					{
						flag = false;
						break;
					}
					if (!iValidateSingleVal(type, val, out b, out error_msg))
					{
						flag = false;
						break;
					}
					if (a == b)
					{
						error_msg = "";
						flag = true;
						break;
					}
				}
			}
			return flag;
		}


		private static bool iValidateSingleVal(string type, string value, out string actual_val, out string error_msg)
		{
			error_msg = "";
			bool result = true;
			actual_val = value;
			uint num = PrivateImplementationDetails.ComputeStringHash(type);
			if (num <= 2149926011U)
			{
				if (num <= 1212580912U)
				{
					if (num <= 200059396U)
					{
						if (num <= 72344531U)
						{
							if (num != 71211698U)
							{
								if (num != 72344531U)
								{
									return result;
								}
								if (!(type == "UINT64"))
								{
									return result;
								}
								goto IL_551;
							}
							else
							{
								if (!(type == "UINT16"))
								{
									return result;
								}
								goto IL_551;
							}
						}
						else if (num != 167029943U)
						{
							if (num != 200059396U)
							{
								return result;
							}
							if (!(type == "INT64"))
							{
								return result;
							}
							goto IL_551;
						}
						else
						{
							if (!(type == "UINT8PTR"))
							{
								return result;
							}
							goto IL_551;
						}
					}
					else if (num <= 324270942U)
					{
						if (num != 268302705U)
						{
							if (num != 324270942U)
							{
								return result;
							}
							if (!(type == "INT64PTR"))
							{
								return result;
							}
							goto IL_551;
						}
						else
						{
							if (!(type == "INT16"))
							{
								return result;
							}
							goto IL_551;
						}
					}
					else if (num != 665806367U)
					{
						if (num != 1212580912U)
						{
							return result;
						}
						if (!(type == "FLOAT32"))
						{
							return result;
						}
						goto IL_560;
					}
					else
					{
						if (!(type == "UINT64PTR"))
						{
							return result;
						}
						goto IL_551;
					}
				}
				else if (num <= 1450498067U)
				{
					if (num <= 1414029642U)
					{
						if (num != 1371739963U)
						{
							if (num != 1414029642U)
							{
								return result;
							}
							if (!(type == "FLOAT32PTR"))
							{
								return result;
							}
							goto IL_560;
						}
						else
						{
							if (!(type == "BOOL8PTR"))
							{
								return result;
							}
							goto IL_543;
						}
					}
					else if (num != 1415045173U)
					{
						if (num != 1450498067U)
						{
							return result;
						}
						if (!(type == "FLOAT64PTR"))
						{
							return result;
						}
						goto IL_560;
					}
					else
					{
						if (!(type == "FLOAT80"))
						{
							return result;
						}
						goto IL_560;
					}
				}
				else if (num <= 1758621869U)
				{
					if (num != 1517748251U)
					{
						if (num != 1758621869U)
						{
							return result;
						}
						if (!(type == "FLOAT64COMPLEX"))
						{
							return result;
						}
						goto IL_56F;
					}
					else
					{
						if (!(type == "UINT8"))
						{
							return result;
						}
						goto IL_551;
					}
				}
				else if (num != 1839435638U)
				{
					if (num != 2001733715U)
					{
						if (num != 2149926011U)
						{
							return result;
						}
						if (!(type == "FIXCPLXPTR"))
						{
							return result;
						}
						goto IL_56F;
					}
					else
					{
						if (!(type == "FIXVALPTR"))
						{
							return result;
						}
						goto IL_560;
					}
				}
				else if (!(type == "PATH"))
				{
					return result;
				}
			}
			else if (num <= 3067248607U)
			{
				if (num <= 2297176337U)
				{
					if (num <= 2214109151U)
					{
						if (num != 2179202354U)
						{
							if (num != 2214109151U)
							{
								return result;
							}
							if (!(type == "INT32"))
							{
								return result;
							}
							goto IL_551;
						}
						else
						{
							if (!(type == "INT8"))
							{
								return result;
							}
							goto IL_551;
						}
					}
					else if (num != 2286151596U)
					{
						if (num != 2297176337U)
						{
							return result;
						}
						if (!(type == "CHARPTR"))
						{
							return result;
						}
					}
					else
					{
						if (!(type == "UINT32"))
						{
							return result;
						}
						goto IL_551;
					}
				}
				else if (num <= 2778687069U)
				{
					if (num != 2676191253U)
					{
						if (num != 2778687069U)
						{
							return result;
						}
						if (!(type == "CHAR"))
						{
							return result;
						}
					}
					else
					{
						if (!(type == "INT16PTR"))
						{
							return result;
						}
						goto IL_551;
					}
				}
				else if (num != 2822617731U)
				{
					if (num != 3052385782U)
					{
						if (num != 3067248607U)
						{
							return result;
						}
						if (!(type == "BOOL8"))
						{
							return result;
						}
						goto IL_543;
					}
					else
					{
						if (!(type == "UINT32PTR"))
						{
							return result;
						}
						goto IL_551;
					}
				}
				else
				{
					if (!(type == "FILE"))
					{
						return result;
					}
					goto IL_536;
				}
				if (!ValidateChar(value, out error_msg))
				{
					return false;
				}
				return result;
			}
			else if (num <= 3561912123U)
			{
				if (num <= 3211190303U)
				{
					if (num != 3178552161U)
					{
						if (num != 3211190303U)
						{
							return result;
						}
						if (!(type == "FIXCPLX"))
						{
							return result;
						}
						goto IL_56F;
					}
					else
					{
						if (!(type == "FLOAT64COMPLEXPTR"))
						{
							return result;
						}
						goto IL_56F;
					}
				}
				else if (num != 3481363276U)
				{
					if (num != 3561912123U)
					{
						return result;
					}
					if (!(type == "INT32PTR"))
					{
						return result;
					}
					goto IL_551;
				}
				else
				{
					if (!(type == "INT8PTR"))
					{
						return result;
					}
					goto IL_551;
				}
			}
			else if (num <= 3710781388U)
			{
				if (num != 3695124071U)
				{
					if (num != 3710781388U)
					{
						return result;
					}
					if (!(type == "UINT16PTR"))
					{
						return result;
					}
					goto IL_551;
				}
				else
				{
					if (!(type == "FLOAT64"))
					{
						return result;
					}
					goto IL_560;
				}
			}
			else if (num != 4052975833U)
			{
				if (num != 4122909080U)
				{
					if (num != 4127814520U)
					{
						return result;
					}
					if (!(type == "STRING"))
					{
						return result;
					}
				}
				else
				{
					if (!(type == "FIX"))
					{
						return result;
					}
					goto IL_560;
				}
			}
			else
			{
				if (!(type == "FLOAT80PTR"))
				{
					return result;
				}
				goto IL_560;
			}
			IL_536:
			if (!ValidateString(value, out error_msg))
			{
				return false;
			}
			return result;
			IL_543:
			if (!ValidateBool(value, out actual_val, out error_msg))
			{
				return false;
			}
			return result;
			IL_551:
			if (!ValidateInt(type, value, out actual_val, out error_msg))
			{
				return false;
			}
			return result;
			IL_560:
			if (!ValidateFloatingPoint(type, value, out actual_val, out error_msg))
			{
				return false;
			}
			return result;
			IL_56F:
			if (!ValidateComplex(type, value, out actual_val, out error_msg))
			{
				result = false;
			}
			return result;
		}


		public static bool ValidateValue(int length, string type, string value, out string error_msg)
		{
			error_msg = "";
			bool flag = true;
			string text = value;
			string[] array = value.Split(new char[]
			{
				' '
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != length && type != "STRING" && type != "PATH" && type != "FILE")
			{
				error_msg = "Wrong amount of values (Expecting " + length + ")";
				flag = false;
			}
			else
			{
				int num = 0;
				while (flag && num < array.Length)
				{
					if (!iValidateSingleVal(type, array[num], out text, out error_msg))
					{
						flag = false;
					}
					num++;
				}
			}
			return flag;
		}


		private static bool ibSetVar(ReceiveTransmit_T transmitType, XmlNode var_node, string value)
		{
			string value2 = var_node.Attributes["type"].Value;
			if (value2 == "FIXMODE" && !ibValidateFixModeString(value))
			{
				iDoMsgBox(0U, string.Format("Invalid value string {0} for variable {1}", value, GetPathFromNode(var_node)));
				return false;
			}
			string text = value;
			if (var_node.Attributes["type"].Value.Equals("FILE") || var_node.Attributes["type"].Value.Equals("PATH"))
			{
				text = value.Replace("\\", "\\\\");
			}
			if (value2 == "FIXCPLX" || value2 == "FLOAT64COMPLEX" || value2 == "FIXCPLXPTR" || value2 == "FLOAT64COMPLEXPTR")
			{
				text = text.Trim(new char[]
				{
					'(',
					')'
				});
				text = text.Insert(0, "(");
				text = text.Insert(text.Length, ")");
			}
			switch (transmitType)
			{
			case ReceiveTransmit_T.XML_PATH:
				VerbosePrint(string.Format("RSTD.SetVar (\"{0}\" , \"{1}\")\n", GetPathFromNode(var_node), text));
				break;
			case ReceiveTransmit_T.SET_AND_TRANSMIT:
				VerbosePrint(string.Format("RSTD.SetAndTransmit (\"{0}\" , \"{1}\")\n", GetPathFromNode(var_node), text));
				break;
			}
			if (var_node.Attributes["permission"].Value == "R")
			{
				if (transmitType == ReceiveTransmit_T.XML_PATH)
				{
					VerbosePrint("SetVar: Ignored. Var is set as Read-Only.\n");
					return false;
				}
				if (transmitType == ReceiveTransmit_T.SET_AND_TRANSMIT)
				{
					VerbosePrint("SetAndTransmit: Ignored. Var is set as Read-Only.\n");
					return false;
				}
			}
			if (GetNodeType(var_node) == NodeType.MAPPED_VAR)
			{
				var_node = m_XmlTreeWrapper.RegisterMapping[var_node];
			}
			if (!bSetVarValue(var_node, value))
			{
				return false;
			}
			var_node.Attributes["is_updated"].Value = false.ToString();
			return true;
		}


		private static bool ibGetNodeInPath(string path, string var_name, out XmlNode var_node, bool bThrowExceptions, string luaOperation)
		{
			var_node = null;
			XmlNode xmlFolder;
			if (bGetFolder(path, out xmlFolder))
			{
				if (m_XmlTreeWrapper.bGetVarInNode(var_name, xmlFolder, out var_node))
				{
					return true;
				}
				if (bThrowExceptions)
				{
					string text = string.Format("{0}: Could not find var \"{1}\" in node", luaOperation, path + "/" + var_name);
					if (IsOnScriptThread())
					{
						throw new LuaException(text);
					}
					AlwaysPrint(text);
					RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error retrieving node: \n" + text);
				}
			}
			else if (bThrowExceptions)
			{
				string text2 = string.Format("{0}: Could not find folder {1}", luaOperation, path);
				if (IsOnScriptThread())
				{
					throw new LuaException(text2);
				}
				AlwaysPrint(text2);
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error retrieving node: \n" + text2);
			}
			return false;
		}


		private static void iRecursiveMerge(XmlNode receive_node, XmlNode insert_node, XmlDocument receive_doc, bool allow_duplicates, ref bool inserted)
		{
			if (inserted)
			{
				return;
			}
			int num = 0;
			while (num < receive_node.ChildNodes.Count && !inserted)
			{
				if (!receive_node.Name.Equals("Var") && !insert_node.Name.Equals("Var"))
				{
					if (GetNodeType(receive_node.ChildNodes[num]) == NodeType.REGISTER && GetNodeType(insert_node.ChildNodes[0]) == NodeType.REGISTER && receive_node.ChildNodes[num].Attributes["name"].Value.ToUpper() == insert_node.ChildNodes[0].Attributes["name"].Value.ToUpper() && (receive_node.ChildNodes[num].ChildNodes[0].Name == "#text" ^ insert_node.ChildNodes[0].ChildNodes[0].Name == "#text"))
					{
						if (allow_duplicates)
						{
							receive_node.AppendChild(receive_doc.ImportNode(insert_node.ChildNodes[0], true));
						}
						else if (insert_node.ChildNodes[0].ChildNodes[0].Name == "#text")
						{
							receive_node.RemoveChild(receive_node.ChildNodes[num]);
							receive_node.AppendChild(receive_doc.ImportNode(insert_node.ChildNodes[0], true));
						}
						inserted = true;
						return;
					}
					if ((receive_node.ChildNodes[num].Name == "ArgumentList" && insert_node.ChildNodes[0].Name == "ArgumentList") || receive_node.ChildNodes[num].Attributes["name"].Value.ToUpper() == insert_node.ChildNodes[0].Attributes["name"].Value.ToUpper())
					{
						iRecursiveMerge(receive_node.ChildNodes[num], insert_node.ChildNodes[0], receive_doc, allow_duplicates, ref inserted);
					}
					else if (num == receive_node.ChildNodes.Count - 1)
					{
						receive_node.AppendChild(receive_doc.ImportNode(insert_node.ChildNodes[0], true));
						inserted = true;
						return;
					}
				}
				num++;
			}
		}


		private static void iSaveTxt(List<XmlNode> nodes, string fileName)
		{
			StreamWriter streamWriter = null;
			try
			{
				streamWriter = new StreamWriter(fileName);
				foreach (XmlNode xmlNode in nodes)
				{
					if (!RstdGuiSettings.Default.bSaveDisplayAsForTxt)
					{
						streamWriter.WriteLine(string.Format("\"{0}\",\"{1}\"", GetPathFromNode(xmlNode), GetNodeValue(xmlNode)));
					}
					else
					{
						streamWriter.WriteLine(string.Format("\"{0}\",\"{1}\"", GetPathFromNode(xmlNode), GetDisplayedValue(xmlNode)));
					}
				}
			}
			catch (Exception ex)
			{
				string text = "SaveSearch:\n " + ex.Message + "\nmaybe the workset is empty?";
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, text, ex.StackTrace);
				if (IsOnScriptThread())
				{
					throw new LuaException(text);
				}
				AlwaysPrint(text);
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
					streamWriter = null;
				}
			}
		}


		private static bool ibValidateRegisterValuesList(List<XmlNode> nodes)
		{
			string text = "";
			foreach (XmlNode node in nodes)
			{
				ValidateRegisterValues_Rec(node, ref text);
			}
			if (text != "")
			{
				ErrorMessage(string.Format("Values of the following registers don't match their fields:\n{0}", text));
				return false;
			}
			return true;
		}


		public static void ValidateRegisterValues_Rec(XmlNode node, ref string all_names)
		{
			NodeType nodeType = GetNodeType(node);
			if (nodeType - NodeType.ROOT > 2)
			{
				if (nodeType == NodeType.REGISTER)
				{
					iValidateRegisterValues(node, ref all_names);
					return;
				}
			}
			else
			{
				foreach (object obj in node.ChildNodes)
				{
					ValidateRegisterValues_Rec((XmlNode)obj, ref all_names);
				}
			}
		}


		private static void iValidateRegisterValues(XmlNode register_node, ref string all_names)
		{
			uint num = 0U;
			string nodeValue = GetNodeValue(register_node);
			if (nodeValue == null)
			{
				return;
			}
			if (nodeValue.StartsWith("0x"))
			{
				uint.Parse(nodeValue.Replace('x', '0'), NumberStyles.HexNumber);
			}
			else
			{
				uint.Parse(nodeValue);
			}
			iCalcFieldsVal(register_node, out num);
		}


		private static void iCalcFieldsVal(XmlNode register_node, out uint fields_values)
		{
			fields_values = 0U;
			foreach (object obj in register_node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (NodeType.FIELD == GetNodeType(xmlNode))
				{
					int num = int.Parse(GetNodeAttribute(xmlNode.LastChild, "start_bit"));
					string nodeValue = GetNodeValue(xmlNode);
					uint num2;
					if (nodeValue.StartsWith("0x"))
					{
						num2 = uint.Parse(nodeValue.Replace('x', '0'), NumberStyles.HexNumber);
					}
					else if (xmlNode.Attributes["fixmode"] != null)
					{
						string value = xmlNode.Attributes["fixmode"].Value;
						double num3;
						long num4;
						CoreImports.GetBitPattern(double.Parse(nodeValue), value, out num3, out num4);
						num2 = (uint)num4;
					}
					else
					{
						num2 = uint.Parse(nodeValue);
					}
					fields_values |= num2 << num;
				}
			}
		}


		private static bool ibSaveXml(List<XmlNode> nodes, string fileName)
		{
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				if (!ibValidateRegisterValuesList(nodes))
				{
					return false;
				}
				iCreateTreeFromNodes(nodes, xmlDocument, true);
				m_XmlTreeWrapper.RemoveFunctionPointers(ref xmlDocument);
				m_XmlTreeWrapper.RemoveGuiAttributes(ref xmlDocument);
				m_XmlTreeWrapper.InsertValuesForMappedVars(ref xmlDocument);
				m_XmlTreeWrapper.ChangeValuesToHex(ref xmlDocument);
				xmlDocument.Save(fileName);
			}
			catch (Exception)
			{
				string text;
				if (nodes.Count == 0)
				{
					text = "Cannot save an empty workset";
				}
				else
				{
					text = "Cannot save to file";
				}
				if (IsOnScriptThread())
				{
					throw new LuaException(text);
				}
				RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, text);
				AlwaysPrint(text);
			}
			finally
			{
				xmlDocument = null;
			}
			return true;
		}


		private static void iCreateTreeFromNodes(List<XmlNode> nodes, XmlDocument xml_doc, bool allow_duplicates)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xml_doc.LoadXml(iGetXmlString(nodes[0], false));
			if (xml_doc != null)
			{
				for (int i = 1; i < nodes.Count; i++)
				{
					xmlDocument.LoadXml(iGetXmlString(nodes[i], false));
					if (xmlDocument != null)
					{
						bool flag = false;
						iRecursiveMerge(xml_doc.ChildNodes[0], xmlDocument.ChildNodes[0], xml_doc, allow_duplicates, ref flag);
					}
				}
			}
		}


		private static bool ibCompare(string compareStr, string searchStr, bool bMatchCase, bool bWholeWordOnly, bool bRegularExpression)
		{
			bool result = false;
			string text;
			string text2;
			if (bMatchCase)
			{
				text = searchStr;
				text2 = compareStr;
			}
			else
			{
				text = searchStr.ToLower();
				text2 = compareStr.ToLower();
			}
			if (bRegularExpression)
			{
				Match match = Regex.Match(text2, text);
				if (match.Success)
				{
					result = (!bWholeWordOnly || text2.Equals(match.ToString()));
				}
			}
			else if (bWholeWordOnly)
			{
				result = text2.Equals(text);
			}
			else
			{
				result = text2.Contains(text);
			}
			return result;
		}

		private static int iCountVarsUnderNodePath(XmlNode node)
		{
			return ((XmlElement)node).GetElementsByTagName("Var").Count;
		}

		private static void iRemoveRegisterFieldsFromNode_Recursive(XmlNode node)
		{
			foreach (object obj in node.ChildNodes)
			{
				XmlNode node2 = (XmlNode)obj;
				if (GetNodeType(node) == NodeType.REGISTER && node.ChildNodes[0].Name == "#text")
				{
					for (int i = 1; i < node.ChildNodes.Count; i++)
					{
						node.RemoveChild(node.ChildNodes[i]);
						i--;
					}
				}
				else
				{
					iRemoveRegisterFieldsFromNode_Recursive(node2);
				}
			}
		}

		private static void iInsertSpacesToEmptyStringVars_Recursive(XmlNode node)
		{
			foreach (object obj in node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (GetNodeType(xmlNode) == NodeType.VAR && (xmlNode.Attributes["type"].Value == "STRING" || xmlNode.Attributes["type"].Value == "FILE" || xmlNode.Attributes["type"].Value == "PATH") && GetNodeValue(xmlNode) == "")
				{
					xmlNode.InnerText = " ";
				}
				else if (GetNodeType(xmlNode) == NodeType.TAB || GetNodeType(xmlNode) == NodeType.FOLDER)
				{
					iInsertSpacesToEmptyStringVars_Recursive(xmlNode);
				}
			}
		}

		private static void iRemoveMappedVarsFromNode_Recursive(XmlNode node)
		{
			for (int i = 0; i < node.ChildNodes.Count; i++)
			{
				if (GetNodeType(node.ChildNodes[i]) == NodeType.MAPPED_VAR)
				{
					node.RemoveChild(node.ChildNodes[i]);
					i--;
				}
				else
				{
					iRemoveMappedVarsFromNode_Recursive(node.ChildNodes[i]);
				}
			}
		}

		private static bool ibValidateFixModeString(string fixmode)
		{
			bool success;
			if (fixmode.Contains("Q"))
			{
				success = Regex.Match(fixmode.ToUpper().Trim(), "\\((-?[0-9]+).(-?[0-9]+)([S|U])?\\)[T|R|F][E|W|C][S|A][T|F]").Success;
			}
			else
			{
				success = Regex.Match(fixmode.ToUpper().Trim(), "\\((-?[0-9]+).(-?[0-9]+)([S|U])?\\)((T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)(,(T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)){0,3})?$").Success;
			}
			return success;
		}

		public static bool AutoSizeColumns;
		private static ConsolePrintLevelDel m_dAlwaysPrint;
		private static ConsolePrint m_dVerbosePrint;
		private static ConsoleMessageDel m_dCoreMsg;
		private static ConsoleMessageBoxDel m_dCoreMsgBox;
		private static RefreshGuiDel m_dRefreshGui;
		private static UnManagedConsolePrintDel m_pUnManagedConsolePrint;
		private static UnManagedCoreMessageDel m_pUnManagedCoreMessage;
		private static UnManagedCoreMessageBoxDel m_pUnManagedCoreMessageBox;
		private static UpdateMonitoredVarsDel m_UpdateMonitorsVars;
		private static string[] m_ClocksList;
		private static frmMain m_MainForm;
		private static frmFind m_FindForm;
		private static RstdXmlTreeWrapper m_XmlTreeWrapper;
		private static BrowseTree m_BrowseTree;
		private static RstdSettings m_RstdSettings;
		private static bool m_bOperationPending;
		private static string m_LastRunFunctionReturnValue;
		private static uint m_NumRemainingTabs;
		private static bool m_bIsClientBuilt;
		private static bool m_bIsAlBuilt;
		private static bool m_DisableGui;
		private static EBuildStatus m_BuildStatus;
		private static bool m_UseVerboseLog;
		private static bool m_UseUserLog;
		public static TransmitDel m_ExternalTransmit;
		public static ReceiveDel m_ExternalReceive;
		public static RstdXmlParser m_XmlParser;
		private enum ETreeSize
		{
			_30_MB = 31457280
		}

		private enum EActualTreeSize
		{
			_4_KB = 4096
		}

		private enum EClocksList
		{
			STR_BUF_LEN = 1024
		}
	}
}
