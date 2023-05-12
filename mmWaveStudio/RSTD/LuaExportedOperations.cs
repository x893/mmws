using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LuaInterface;
using LuaRegister;
using RstdNet;
using RstdRemoting;

namespace RSTD
{

    public class LuaExportedOperations : MarshalByRefObject
    {

        public LuaExportedOperations()
        {
            this.m_frmMain = GuiCore.MainForm;
            this.myYesNoTimerMsgBox = new frmYesNoTimerMsgBox();
            this.m_RemoteManager = new RemoteManager();
            this.m_Timer = new TimerManager(this.m_frmMain);
        }


        public override object InitializeLifetimeService()
        {
            return null;
        }


        public bool CheckIfRSTDFuncHasParams(string package, string func_name)
        {
            MethodInfo methodInfo = null;
            uint num = PrivateImplementationDetails.ComputeStringHash(func_name);
            if (num <= 1586923873U)
            {
                if (num <= 384654669U)
                {
                    if (num != 318364877U)
                    {
                        if (num == 384654669U)
                        {
                            if (func_name == "MessageBox")
                            {
                                func_name = "GuiMessage";
                            }
                        }
                    }
                    else if (func_name == "RunInBackground")
                    {
                        func_name = "RunAsynch";
                    }
                }
                else if (num != 1554545291U)
                {
                    if (num == 1586923873U)
                    {
                        if (func_name == "LoadTree")
                        {
                            func_name = "LoadFile";
                        }
                    }
                }
                else if (func_name == "MessageColor")
                {
                    func_name = "LuaMessageColor";
                }
            }
            else if (num <= 2569706276U)
            {
                if (num != 2371348074U)
                {
                    if (num == 2569706276U)
                    {
                        if (func_name == "CreateNextLogFile")
                        {
                            func_name = "CreateNextSubLogFile";
                        }
                    }
                }
                else if (func_name == "Run")
                {
                    func_name = "RunSynch";
                }
            }
            else if (num != 2705494512U)
            {
                if (num != 2920208772U)
                {
                    if (num == 2923258584U)
                    {
                        if (func_name == "SleepUntilStop")
                        {
                            func_name = "SleepUntilWithoutParam";
                        }
                    }
                }
                else if (func_name == "Message")
                {
                    func_name = "LuaMessage";
                }
            }
            else if (func_name == "SaveTree")
            {
                func_name = "SavePath";
            }
            Type type = base.GetType();
            try
            {
                methodInfo = type.GetMethod(func_name);
            }
            catch
            {
                return true;
            }
            if (methodInfo != null)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                return parameters.Length != 0;
            }
            return true;
        }


        [AttrLuaFunc("WorkSetLoad", "Loads a file to workset", new string[]
        {
            "file name"
        })]
        public void WorkSetLoad(string file_name)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dWorkSetLoad method = new dWorkSetLoad(this.WorkSetLoad);
                this.m_frmMain.Invoke(method, new object[]
                {
                    file_name
                });
                return;
            }
            if (!this.m_frmMain.browse_tree.WorkSet.LoadWorkSet(file_name))
            {
                GuiCore.RstdException("WorkSetLoad of file: " + file_name + " failed.\n", "");
            }
        }


        [AttrLuaFunc("WorkSetSave", "Saves a file from workset", new string[]
        {
            "file name"
        })]
        public void WorkSetSave(string file_name)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dWorkSetSave method = new dWorkSetSave(this.WorkSetSave);
                this.m_frmMain.Invoke(method, new object[]
                {
                    file_name
                });
                return;
            }
            if (!GuiCore.Save(this.m_frmMain.browse_tree.WorkSet.FillNodesList(), file_name))
            {
                GuiCore.RstdException("WorkSetSave of file: " + file_name + " failed (maybe wrong path/file extension?).\n", "");
            }
            GuiCore.VerbosePrint(string.Format("RSTD.WorkSetSave(\"{0}\")", file_name.Replace('\\', '/')));
        }


        [AttrLuaFunc("AddToWorkSet", "Add the node which resides in the given path to workset", new string[]
        {
            "node's path to remove"
        })]
        public void AddToWorkSet(string path)
        {
            NodeType nodeType = NodeType.VAR;
            if (this.m_frmMain.InvokeRequired)
            {
                dAddToWorkSet method = new dAddToWorkSet(this.AddToWorkSet);
                this.m_frmMain.Invoke(method, new object[]
                {
                    path
                });
                return;
            }
            List<XmlNode> list = new List<XmlNode>();
            XmlNode xmlNode;
            if (GuiCore.GetNodeFromPath(path, out xmlNode))
            {
                nodeType = GuiCore.GetNodeType(xmlNode);
            }
            if (nodeType.Equals(NodeType.FOLDER))
            {
                GuiCore.AlwaysPrint(0U, 2U, "WARNING:\nAddToWorkSet(): Only variables and functions can be added to workset!\n");
                return;
            }
            list.Add(xmlNode);
            GuiCore.WorkSet.AddNodesToWorkSet(list);
        }


        [AttrLuaFunc("RemoveFromWorkSet", "Remove the node which resides in the given path from workset", new string[]
        {
            "node's path to remove"
        })]
        public void RemoveFromWorkSet(string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dRemoveFromWorkSet method = new dRemoveFromWorkSet(this.RemoveFromWorkSet);
                this.m_frmMain.Invoke(method, new object[]
                {
                    path
                });
                return;
            }
            List<XmlNode> list = new List<XmlNode>();
            XmlNode item;
            if (GuiCore.GetNodeFromPath(path, out item))
            {
                list.Add(item);
            }
            GuiCore.WorkSet.RemoveFromWorkSet(list);
        }


        [AttrLuaFunc("ClearWorkSet", "Clears workset")]
        public void ClearWorkSet()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dClearWorkSet method = new dClearWorkSet(this.ClearWorkSet);
                this.m_frmMain.Invoke(method);
                return;
            }
            GuiCore.WorkSet.ClearWorkSet();
        }


        [AttrLuaFunc("GetWorkSet", "Get all variables in the workset as a Lua table (not inc. functions)")]
        public LuaTable GetWorkSet()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dLT_V method = new dLT_V(this.GetWorkSet);
                return (LuaTable)this.m_frmMain.Invoke(method);
            }
            return GuiCore.WorkSet.GetWorkSet();
        }


        [AttrLuaFunc("WorkSetReceive", "Receive workset")]
        public void WorkSetReceive()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.WorkSetReceive);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.WorkSet.ReceiveWS(true);
        }


        [AttrLuaFunc("WorkSetTransmit", "Transmit workset")]
        public void WorkSetTransmit()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.WorkSetTransmit);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.WorkSet.TransmitWS(true);
        }


        [AttrLuaFunc("ClearMonitor", "Clears monitor")]
        public void ClearMonitor()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dClearMonitor method = new dClearMonitor(this.ClearMonitor);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.MonitoredVars.ClearMonitor();
        }


        [AttrLuaFunc("RemoveFromMonitor", "Remove the node which resides in the given path from monitor", new string[]
        {
            "node's path to remove"
        })]
        public void RemoveFromMonitor(string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dRemoveFromMonitor method = new dRemoveFromMonitor(this.RemoveFromMonitor);
                this.m_frmMain.Invoke(method, new object[]
                {
                    path
                });
                return;
            }
            List<XmlNode> list = new List<XmlNode>();
            XmlNode item;
            if (GuiCore.GetNodeFromPath(path, out item))
            {
                list.Add(item);
            }
            GuiCore.RemoveAfterValidateFromMonitor(list);
        }


        [AttrLuaFunc("IsMonitorOn", "Return a bool indicates if monitor already took place")]
        public bool IsMonitorOn()
        {
            return this.m_frmMain.browse_tree.MonitoredVars.bIsMonitoring;
        }


        [AttrLuaFunc("MonitorStart", "Starts monitoring the variables in the monitor form.")]
        public string MonitorStart()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.MonitorStart);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.browse_tree.MonitorStart();
        }


        [AttrLuaFunc("MonitorStop", "Stops monitoring the variables in the monitor form.")]
        public void MonitorStop()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.MonitorStop);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.MonitorStop();
        }


        [AttrLuaFunc("MonitorLoad", "Loads variables from the given xml file into the monitor form.", new string[]
        {
            "File name"
        })]
        public void MonitorLoad(string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.MonitorLoad);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.browse_tree.MonitorLoad(fileName);
        }


        [AttrLuaFunc("MonitorSave", "Saves the variables from the monitor form to the given xml file.", new string[]
        {
            "File name"
        })]
        public void MonitorSave(string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.MonitorSave);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.browse_tree.MonitorSave(fileName);
        }


        [AttrLuaFunc("AddMonitorVar", "Adds the given variable with the given clocks, offset, stride & length to the monitor form.", new string[]
        {
            "variable name",
            "clocks",
            "offset",
            "stribe",
            "length"
        })]
        public void AddMonitorVar(string var_name, string rel_clocks, string vec_offset, string vec_stride, string vec_length)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_5String dGuiOperDel_5String = new dGuiOperDel_5String(this.AddMonitorVar);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_5String;
                object[] args = new string[]
                {
                    var_name,
                    rel_clocks,
                    vec_offset,
                    vec_stride,
                    vec_length
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.browse_tree.AddMonitorVar(var_name, rel_clocks, vec_offset, vec_stride, vec_length);
        }


        [AttrLuaFunc("ShowLastFile", "Opens the last monitor file (rtd)")]
        public void ShowLastFile()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.ShowLastFile);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.ShowLastFile();
        }


        [AttrLuaFunc("DeleteAllFiles", "Deletes all monitor*.rtd files from the \"<output>\\ Monitors\\\"  folder.")]
        public void DeleteAllFiles()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.DeleteAllFiles);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.DeleteAllFiles();
        }


        [AttrLuaFunc("Go", "Begins the simulation (Calls the client’s Apply method)")]
        public void Go()
        {
            if (!this.m_frmMain.AscertainModulesBuilt())
            {
                return;
            }
            if (this.m_frmMain.bIsClientRunning)
            {
                this.m_frmMain.AlwaysPrint("Ignored: Attempt to Go() again\n");
                return;
            }
            if (this.m_frmMain.RstdSettings.GetWarningLevel() == WarningLevel.ALL)
            {
                GuiCore.CheckIfAllSetVarsTransmitted();
            }
            this.m_frmMain.GoBegin();
            GuiCore.Go();
            if (!GuiCore.IsOnGuiThread())
            {
                this.m_frmMain.GoEnd();
            }
        }


        [AttrLuaFunc("Stop", "Stops the simulation.")]
        public void Stop()
        {
            if (!this.m_frmMain.AscertainModulesBuilt())
            {
                return;
            }
            this.m_frmMain.bIsStopPending = true;
            if (this.m_frmMain.bIsClientRunning)
            {
                this.m_frmMain.StopBegin();
                GuiCore.Stop();
                Thread.Sleep(200);
                if (!GuiCore.IsOnGuiThread())
                {
                    this.m_frmMain.StopEnd();
                }
            }
            else
            {
                this.m_frmMain.AlwaysPrint("Ignored: Attempt to Stop() again or before Go\n");
            }
            this.m_frmMain.bIsStopPending = false;
        }


        [AttrLuaFunc("Abort", "Aborts the apply loop of the simulation")]
        public void Abort()
        {
            this.m_frmMain.AlwaysPrint("RSTD.Abort()\n");
            if (!this.m_frmMain.AscertainModulesBuilt())
            {
                return;
            }
            this.m_frmMain.bIsStopPending = true;
            if (this.m_frmMain.bIsClientRunning)
            {
                this.m_frmMain.StopBegin();
                GuiCore.Abort();
                Thread.Sleep(200);
                if (!GuiCore.IsOnGuiThread())
                {
                    this.m_frmMain.StopEnd();
                }
            }
            else
            {
                this.m_frmMain.AlwaysPrint("Ignored: Attempt to Abort() again or before Go\n");
            }
            this.m_frmMain.bIsStopPending = false;
        }


        [AttrLuaFunc("Build", "Build the Client (calls: AL Ctor, AL  ExportToGui, AL Init, Client Ctor, Client ExportToGui)")]
        public void Build()
        {
            if (GuiCore.IsClientBuilt)
            {
                this.m_frmMain.AlwaysPrint("Scripter ignored: Attempt to Build() again\n");
                return;
            }
            if (this.m_frmMain.RstdSettings.bHasClients())
            {
                this.m_frmMain.BuildBegin();
                GuiCore.Build();
                if (!GuiCore.IsOnGuiThread())
                {
                    this.m_frmMain.BuildEnd();
                    return;
                }
            }
            else
            {
                GuiCore.RstdException("Attempted to build without client names configured!", "");
            }
        }


        [AttrLuaFunc("AL_Build", "Builds the Abstraction Layer (Calls the AL's Ctor and ExportToGui)")]
        public void AL_Build()
        {
            GuiCore.AL_Build(true);
        }


        [AttrLuaFunc("AL_Reset", "Calls the AL's exported Reset() function")]
        public void AL_Reset()
        {
            GuiCore.AL_Reset();
        }


        [AttrLuaFunc("AL_Init", "Calls the AL's exported Init() function")]
        public void AL_Init()
        {
            GuiCore.AL_Init();
        }


        [AttrLuaFunc("AL_UnBuild", "UnBuilds the Abstraction Layer (Calls the AL's Dtor and removes its tabs from the BrowseTree)")]
        public void AL_UnBuild()
        {
            GuiCore.AL_UnBuild(true);
        }


        [AttrLuaFunc("AL_GetStatus", "Returns the Abstraction Layer's connection status (connected or not)")]
        public bool AL_GetStatus()
        {
            return CoreImports.AL_GetStatus();
        }


        [AttrLuaFunc("Client_Build", "Builds the Client (calls Client's Ctor and ExportToGui)")]
        public void Client_Build()
        {
            GuiCore.Clients_Build(true);
        }


        [AttrLuaFunc("Client_Init", "Calls the Client's exported Init() function")]
        public void Client_Init()
        {
            GuiCore.Clients_Init();
        }


        [AttrLuaFunc("Client_Reset", "Calls the Client's exported Reset() function")]
        public void Client_Reset()
        {
            GuiCore.Clients_Reset();
        }


        [AttrLuaFunc("Client_UnBuild", "UnBuilds the Client (Calls the Client's dtor and removes it's tabs from BrowseTree)")]
        public void Client_UnBuild()
        {
            GuiCore.Clients_UnBuild(true);
        }


        [AttrLuaFunc("AL_LoadALXml", "Loads AL XML")]
        public void AL_LoadALXml()
        {
            this.m_frmMain.RstdSettings.LoadALXml();
        }


        [AttrLuaFunc("Client_LoadXml", "Loads Client XML")]
        public void Client_LoadXml()
        {
            this.m_frmMain.RstdSettings.LoadClientXml();
        }


        [AttrLuaFunc("UnBuild", "Unbuild the Client (calls: Client Dtor, AL Dtor).")]
        public void UnBuild()
        {
            if (GuiCore.IsClientBuilt)
            {
                this.m_frmMain.UnBuildBegin();
                GuiCore.UnBuild();
                if (!GuiCore.IsOnGuiThread())
                {
                    this.m_frmMain.UnBuildEnd();
                    return;
                }
            }
            else
            {
                this.m_frmMain.AlwaysPrint("Scripter ignored: Attempt to UnBuild() again or before Build.\n");
            }
        }


        [AttrLuaFunc("IsBuilt", "Return a bool indicates if build already took place")]
        public bool IsBuilt()
        {
            return GuiCore.IsClientBuilt;
        }


        [AttrLuaFunc("RunFunction", "Runs the function that resides in the given tree path. Returns the function’s return value.", new string[]
        {
            "Function Name"
        })]
        public string RunFunction(string funcCall)
        {
            if (1 == CoreImports.IsDebuggerPresent())
            {
                this.m_frmMain.MinimizeAllWindows();
            }
            return GuiCore.RunFunction(funcCall, false);
        }


        [AttrLuaFunc("RunFunctionAsync", "Runs the function that resides in the given tree path in a new thread.", new string[]
        {
            "Function Name"
        })]
        public string RunFunctionAsync(string funcCall)
        {
            if (1 == CoreImports.IsDebuggerPresent())
            {
                this.m_frmMain.MinimizeAllWindows();
            }
            return GuiCore.RunFunction(funcCall, true);
        }


        [AttrLuaFunc("BrowseTree", "Shows the BrowseTree.")]
        public void BrowseTree()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.BrowseTree);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.Warning("BrowseTree(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("HideBrowseTree", "Hides the BrowseTree.")]
        public void HideBrowseTree()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.HideBrowseTree);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.Hide();
        }


        [AttrLuaFunc("Workset", "Shows the Workset.")]
        public void Workset()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.Workset);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.Warning("Workset(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("HideWorkset", "Hides the Workset.")]
        public void HideWorkset()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.HideWorkset);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.browse_tree.WorkSet.Hide();
        }


        [AttrLuaFunc("SubsetLoad", "Show the SubSet.", new string[]
        {
            "Subset file name"
        })]
        public int SubsetLoad(string file_name)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_i_s method = new del_i_s(this.SubsetLoad);
                return (int)this.m_frmMain.Invoke(method, new object[]
                {
                    file_name
                });
            }
            this.m_frmMain.Warning("SubsetLoad(): The Command is not supported in this installation.\n");
            return 0;
        }


        [AttrLuaFunc("SubsetNew", "Creates SubSet. Returns subset handle")]
        public int SubsetNew()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_i_v method = new del_i_v(this.SubsetNew);
                return (int)this.m_frmMain.Invoke(method);
            }
            this.m_frmMain.Warning("SubsetNew(): The Command is not supported in this installation.\n");
            return 0;
        }


        [AttrLuaFunc("SubsetSave", "Save SubSet", new string[]
        {
            "handle",
            "path"
        })]
        public void SubsetSave(int handle, string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i_s method = new del_v_i_s(this.SubsetSave);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle,
                    path
                });
                return;
            }
            this.m_frmMain.Warning("SubsetNew(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("SubsetClose", "Close SubSet", new string[]
        {
            "handle",
            "save subset"
        })]
        public void SubsetClose(int handle, bool b_save)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i_b method = new del_v_i_b(this.SubsetClose);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle,
                    b_save
                });
                return;
            }
            this.m_frmMain.Warning("SubsetClose(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("SubsetClear", "Clear SubSet", new string[]
        {
            "handle"
        })]
        public void SubsetClear(int handle)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i method = new del_v_i(this.SubsetClear);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle
                });
                return;
            }
            this.m_frmMain.Warning("SubsetClear(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("SubsetReceive", "Receive SubSet", new string[]
        {
            "handle"
        })]
        public void SubsetReceive(int handle)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i method = new del_v_i(this.SubsetReceive);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle
                });
                return;
            }
            this.m_frmMain.Warning("SubsetReceive(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("SubsetTransmit", "Transmit SubSet", new string[]
        {
            "handle"
        })]
        public void SubsetTransmit(int handle)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i method = new del_v_i(this.SubsetTransmit);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle
                });
                return;
            }
            this.m_frmMain.Warning("SubsetTransmit(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("SubsetGet", "Get SubSet", new string[]
        {
            "handle"
        })]
        public LuaTable SubsetGet(int handle)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dLT_i method = new dLT_i(this.SubsetGet);
                return (LuaTable)this.m_frmMain.Invoke(method, new object[]
                {
                    handle
                });
            }
            this.m_frmMain.Warning("SubsetGet(): The Command is not supported in this installation.\n");
            return null;
        }


        [AttrLuaFunc("SubsetAdd", "Add register to subset", new string[]
        {
            "handle",
            "register path"
        })]
        public void SubsetAdd(int handle, string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i_s method = new del_v_i_s(this.SubsetAdd);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle,
                    path
                });
                return;
            }
            this.m_frmMain.Warning("SubsetNew(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("SubsetRemove", "Remove register from subset", new string[]
        {
            "handle",
            "register path"
        })]
        public void SubsetRemove(int handle, string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_i_s method = new del_v_i_s(this.SubsetRemove);
                this.m_frmMain.Invoke(method, new object[]
                {
                    handle,
                    path
                });
                return;
            }
            this.m_frmMain.Warning("SubsetRemove(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("LuaShell", "Shows the Lua Shell.")]
        public void LuaShell()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.LuaShell);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.LuaShellForm.Show(this.m_frmMain.DockPanel);
        }


        [AttrLuaFunc("HideLuaShell", "Hides the Lua Shell.")]
        public void HideLuaShell()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.HideLuaShell);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.LuaShellForm.Hide();
        }


        [AttrLuaFunc("Output", "Shows the Output form.")]
        public void Output()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.Output);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.OutputForm.Show(this.m_frmMain.DockPanel);
        }


        [AttrLuaFunc("HideOutput", "Hides the Output form.")]
        public void HideOutput()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.HideOutput);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.OutputForm.Hide();
        }


        [AttrLuaFunc("MonitorShow", "Opens the Monitor form.")]
        public void MonitorShow()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.MonitorShow);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.Warning("MonitorShow(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("MonitorHide", "Opens the Monitor form.")]
        public void MonitorHide()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.MonitorHide);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.Warning("MonitorShow(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("ClearOutput", "Clear the output")]
        public void ClearOutput()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.ClearOutput);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.OutputForm.ClearOutput();
        }


        [AttrLuaFunc("GetMainWindowSize", "Returns the Main window's size (width, height)", new string[]
        {
            "2nd Returned value. Do not provide this."
        })]
        public int GetMainWindowSize(out int height)
        {
            height = this.m_frmMain.Size.Height;
            return this.m_frmMain.Size.Width;
        }


        [AttrLuaFunc("SetMainWindowSize", "Sets the Main window's size", new string[]
        {
            "The Required width",
            "The Required height"
        })]
        public void SetMainWindowSize(int width, int height)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_2Int method = new dGuiOperDel_2Int(this.SetMainWindowSize);
                this.m_frmMain.Invoke(method, new object[]
                {
                    width,
                    height
                });
                return;
            }
            this.m_frmMain.WindowState = FormWindowState.Normal;
            this.m_frmMain.Width = width;
            this.m_frmMain.Height = height;
        }


        [AttrLuaFunc("GetMainWindowPos", "Returns the Main window's position (x & y)", new string[]
        {
            "2nd Returned value. Do not provide this."
        })]
        public int GetMainWindowPos(out int y)
        {
            y = this.m_frmMain.Location.Y;
            return this.m_frmMain.Location.X;
        }


        [AttrLuaFunc("SetMainWindowPos", "Sets the Main window's position", new string[]
        {
            "The X coordinate",
            "The Y coordinate"
        })]
        public void SetMainWindowPos(int x, int y)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_2Int method = new dGuiOperDel_2Int(this.SetMainWindowPos);
                this.m_frmMain.Invoke(method, new object[]
                {
                    x,
                    y
                });
                return;
            }
            int height = this.m_frmMain.Size.Height;
            int width = this.m_frmMain.Size.Width;
            this.m_frmMain.WindowState = FormWindowState.Normal;
            this.m_frmMain.Location = new Point(x, y);
            this.m_frmMain.Width = width;
            this.m_frmMain.Height = height;
        }


        [AttrLuaFunc("SetMessagesMask", "Switches to show only script messages (on) or all (off)", new string[]
        {
            "On/Off"
        })]
        public void SetMessageMask(bool on_off_flag)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dSetMessageMask method = new dSetMessageMask(this.SetMessageMask);
                this.m_frmMain.Invoke(method, new object[]
                {
                    on_off_flag
                });
                return;
            }
            this.m_frmMain.OutputForm.ButtonUserMsgMask.Checked = on_off_flag;
            RstdGuiSettings.Default.AllowOnlyUserMsgs = on_off_flag;
        }


        [AttrLuaFunc("SetAutoScroll", "Switches the output AutoScroll on or off", new string[]
        {
            "true - On; false - Off"
        })]
        public void SetAutoScroll(bool on_off_flag)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dSetMessageMask method = new dSetMessageMask(this.SetAutoScroll);
                this.m_frmMain.Invoke(method, new object[]
                {
                    on_off_flag
                });
                return;
            }
            this.m_frmMain.OutputForm.ButtonAutoScroll.Checked = on_off_flag;
            RstdGuiSettings.Default.bAutoScrollOutput = on_off_flag;
        }


        [AttrLuaFunc("SetTitle", "Sets the title of the main form", new string[]
        {
            "the title to set"
        })]
        public void SetTitle(string title)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.SetTitle);
                this.m_frmMain.Invoke(method, new object[]
                {
                    title
                });
                return;
            }
            this.m_frmMain.SetTitle(title);
        }


        [AttrLuaFunc("SetVersion", "Sets the title of the main form", new string[]
        {
            "the title to set"
        })]
        public void SetVersion(string title)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.SetVersion);
                this.m_frmMain.Invoke(method, new object[]
                {
                    title
                });
                return;
            }
            this.m_frmMain.SetVersion(title);
        }


        [AttrLuaFunc("GetDllVersion", "Gets the dll assembly version", new string[]
        {
            "path for the dll file"
        })]
        public string GetDllVersion(string dll_path)
        {
            string result = "";
            if (!string.IsNullOrEmpty(dll_path))
            {
                result = AssemblyName.GetAssemblyName(dll_path).Version.ToString();
            }
            return result;
        }


        [AttrLuaFunc("GetToolbarScript", "Returns the script selected in the lower toolbar")]
        public string GetToolbarScript()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.GetToolbarScript);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.GetToolbarScript();
        }


        [AttrLuaFunc("ReceiveArray", "Gets the array of values of the variable that resides in the given path", new string[]
        {
            "The Full Path of the location of the variable.",
            "Array Offset",
            "Array Stride",
            "Array Length"
        })]
        public LuaTable ReceiveArray(string varFullPath, int offset, int stride, int length)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dReceiveArrayDel method = new dReceiveArrayDel(this.ReceiveArray);
                return (LuaTable)this.m_frmMain.Invoke(method, new object[]
                {
                    varFullPath,
                    offset,
                    stride,
                    length
                });
            }
            LuaWrapperUtils.LuaWrapper.LuaVM.NewTable("lua_table");
            LuaTable table = LuaWrapperUtils.LuaWrapper.LuaVM.GetTable("lua_table");
            int num = varFullPath.LastIndexOf('/');
            if (-1 == num)
            {
                throw new LuaException(string.Format("Illegal var {0}", varFullPath));
            }
            string[] array = this.ReceiveArrayAsStrArr(varFullPath, offset, stride, length);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Replace("(", "{");
                array[i] = array[i].Replace(")", "}");
                LuaWrapperUtils.LuaWrapper.LuaVM.DoString(string.Format("lua_table[{0}] = {1}", i + 1, array[i]));
            }
            return table;
        }


        public string[] ReceiveArrayAsStrArr(string varFullPath, int offset, int stride, int length)
        {
            XmlNode xmlNode;
            GuiCore.GetNodeFromPath(varFullPath, out xmlNode);
            xmlNode.Attributes["offset"].Value = offset.ToString();
            xmlNode.Attributes["stride"].Value = stride.ToString();
            xmlNode.Attributes["length"].Value = length.ToString();
            GuiCore.Receive(xmlNode, ReceiveTransmit_T.ARRAY_VAR, true);
            return GuiCore.GetNodeValue(xmlNode).Split(new char[]
            {
                ' '
            });
        }


        [AttrLuaFunc("TransmitArray", "Sets the given value in the variable that resides in the given path", new string[]
        {
            "The Full Path of the location of the variable.",
            "Array Offset",
            "Array Stride",
            "Array Length",
            "Table containg all the new values."
        })]
        public void TransmitArray(string varFullPath, int offset, int stride, int length, LuaTable table_name_contains_new_value)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dTransmitArrayDel method = new dTransmitArrayDel(this.TransmitArray);
                this.m_frmMain.Invoke(method, new object[]
                {
                    varFullPath,
                    offset,
                    stride,
                    length,
                    table_name_contains_new_value
                });
                return;
            }
            new List<XmlNode>();
            int num = varFullPath.LastIndexOf('/');
            if (varFullPath.StartsWith("/"))
            {
                num = varFullPath.LastIndexOf('/');
            }
            if (-1 == num)
            {
                throw new LuaException(string.Format("Illegal var {0}", varFullPath));
            }
            List<string> tableValues = LuaWrapperUtils.GetTableValues(table_name_contains_new_value);
            this.TransmitArrayAsStr(varFullPath, offset, stride, length, tableValues);
        }


        public void TransmitArrayAsStr(string varFullPath, int offset, int stride, int length, List<string> table_name_contains_new_value)
        {
            string text = string.Empty;
            foreach (string str in table_name_contains_new_value)
            {
                text = text + str + " ";
            }
            text = text.Trim();
            XmlNode xmlNode;
            GuiCore.GetNodeFromPath(varFullPath, out xmlNode);
            xmlNode.InnerText = text;
            xmlNode.Attributes["offset"].Value = offset.ToString();
            xmlNode.Attributes["stride"].Value = stride.ToString();
            xmlNode.Attributes["length"].Value = length.ToString();
            GuiCore.Transmit(xmlNode, ReceiveTransmit_T.ARRAY_VAR, true);
        }


        [AttrLuaFunc("GetVar", "Gets the value of the variable that resides in the given path", new string[]
        {
            "The Full Path of the location of the variable."
        })]
        public string GetVar(string varFullPath)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGetVarDel dGetVarDel = new dGetVarDel(this.GetVar);
                Control frmMain = this.m_frmMain;
                Delegate method = dGetVarDel;
                object[] args = new string[]
                {
                    varFullPath
                };
                return (string)frmMain.Invoke(method, args);
            }
            int num = varFullPath.LastIndexOf('/');
            if (-1 == num)
            {
                throw new LuaException(string.Format("Illegal var {0}", varFullPath));
            }
            string varFullPath2 = varFullPath.Remove(num);
            string varName = varFullPath.Substring(num + 1);
            return GuiCore.GetVarValue(varFullPath2, varName);
        }


        [AttrLuaFunc("IsValidVarPath", "Check if given var path is valid", new string[]
        {
            "Full Path of var"
        })]
        public bool IsValidVarPath(string varFullPath)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dbGuiOperDel_1String dbGuiOperDel_1String = new dbGuiOperDel_1String(this.IsValidVarPath);
                Control frmMain = this.m_frmMain;
                Delegate method = dbGuiOperDel_1String;
                object[] args = new string[]
                {
                    varFullPath
                };
                return (bool)frmMain.Invoke(method, args);
            }
            XmlNode xmlNode;
            return GuiCore.GetNodeFromPath(varFullPath, out xmlNode, false);
        }


        [AttrLuaFunc("GetAttribute", "Gets the attribute value of given var", new string[]
        {
            "Full Path of var",
            "Name of attribute"
        })]
        public string GetAttribute(string varFullPath, string attr_str)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGetAttributeDel dGetAttributeDel = new dGetAttributeDel(this.GetAttribute);
                Control frmMain = this.m_frmMain;
                Delegate method = dGetAttributeDel;
                object[] args = new string[]
                {
                    varFullPath,
                    attr_str
                };
                return (string)frmMain.Invoke(method, args);
            }
            attr_str = attr_str.ToLower();
            XmlNode xmlNode;
            if (!GuiCore.GetNodeFromPath(varFullPath, out xmlNode, true))
            {
                return null;
            }
            foreach (object obj in xmlNode.Attributes)
            {
                XmlAttribute xmlAttribute = (XmlAttribute)obj;
                if (xmlAttribute.Name == attr_str)
                {
                    return xmlAttribute.Value;
                }
            }
            if (GuiCore.GetNodeType(xmlNode) == NodeType.FIELD)
            {
                foreach (object obj2 in xmlNode.LastChild.Attributes)
                {
                    XmlAttribute xmlAttribute2 = (XmlAttribute)obj2;
                    if (xmlAttribute2.Name == attr_str)
                    {
                        return xmlAttribute2.Value;
                    }
                }
            }
            return null;
        }


        [AttrLuaFunc("GetNodeType", "Gets the type of the node in the given path\n(UNSUPPORTED, ROOT, TAB, FOLDER, FUNCTION, REGISTER, VAR, MAPPED_VAR, FIELD)", new string[]
        {
            "The full path of the node in the BrowseTree XML"
        })]
        public string GetNodeType(string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGetVarDel dGetVarDel = new dGetVarDel(this.GetNodeType);
                Control frmMain = this.m_frmMain;
                Delegate method = dGetVarDel;
                object[] args = new string[]
                {
                    path
                };
                return (string)frmMain.Invoke(method, args);
            }
            XmlNode node;
            GuiCore.GetNodeFromPath(path, out node);
            return GuiCore.GetNodeType(node).ToString();
        }


        [AttrLuaFunc("SetVar", "Sets the given value in the variable that resides in the given path", new string[]
        {
            "The Full Path of the location of the variable.",
            "The new value."
        })]
        public void SetVar(string varFullPath, string newValue)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dSetVarDel dSetVarDel = new dSetVarDel(this.SetVar);
                Control frmMain = this.m_frmMain;
                Delegate method = dSetVarDel;
                object[] args = new string[]
                {
                    varFullPath,
                    newValue
                };
                frmMain.Invoke(method, args);
                return;
            }
            if (newValue == null)
            {
                GuiCore.ErrorMessage(string.Format("RSTD.SetVar(\"{0}\", nil): Can't set a null value\n", varFullPath));
                return;
            }
            XmlNode xmlNode;
            if (GuiCore.GetNodeFromPath(varFullPath, out xmlNode))
            {
                int length = int.Parse(xmlNode.Attributes["length"].Value);
                string arg;
                if (!string.IsNullOrEmpty(xmlNode.Attributes["options"].Value))
                {
                    if (!GuiCore.ValidateOptionValue(xmlNode.Attributes["type"].Value, xmlNode.Attributes["options"].Value, newValue, out arg))
                    {
                        LuaWrapperUtils.LuaWrapper.PrintError(string.Format("RSTD.SetVar (\"{0}\", \"{1}\"): {2}", varFullPath, newValue, arg));
                        return;
                    }
                }
                else if (!GuiCore.ValidateValue(length, xmlNode.Attributes["type"].Value, newValue, out arg))
                {
                    LuaWrapperUtils.LuaWrapper.PrintError(string.Format("RSTD.SetVar (\"{0}\", \"{1}\"): {2}", varFullPath, newValue, arg));
                    return;
                }
                GuiCore.ChangeVarsValue(varFullPath, newValue);
            }
        }


        [AttrLuaFunc("Log", "Writes the text in the Rstd console in specified color", new string[]
        {
            "Text To Write",
            "Color"
        })]
        public void Log(string text, string color)
        {
            if (color == "red")
            {
                this.LuaMessageColor(text, 1U);
                return;
            }
            if (color == "blue")
            {
                this.LuaMessageColor(text, 3U);
                return;
            }
            if (color == "green")
            {
                this.LuaMessageColor(text, 4U);
                return;
            }
            if (color == "yellow")
            {
                this.LuaMessageColor(text, 6U);
                return;
            }
            if (color == "orange")
            {
                this.LuaMessageColor(text, 7U);
                return;
            }
            if (color == "purple")
            {
                this.LuaMessageColor(text, 8U);
                return;
            }
            this.LuaMessageColor(text, 5U);
        }


        [AttrLuaFunc("SetAndTransmit", "Calls both SetVar and Transmit (in that order) for a given variable.", new string[]
        {
            "var full path",
            "var new value"
        })]
        public void SetAndTransmit(string varFullPath, string newValue)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dSetVarDel dSetVarDel = new dSetVarDel(this.SetAndTransmit);
                Control frmMain = this.m_frmMain;
                Delegate method = dSetVarDel;
                object[] args = new string[]
                {
                    varFullPath,
                    newValue
                };
                frmMain.Invoke(method, args);
                return;
            }
            int num = varFullPath.LastIndexOf('/');
            if (varFullPath.StartsWith("/"))
            {
                num = varFullPath.LastIndexOf('/');
            }
            if (-1 == num)
            {
                throw new LuaException(string.Format("Illegal var {0}", varFullPath));
            }
            string varFullPath2 = varFullPath.Remove(num);
            string varName = varFullPath.Substring(num + 1);
            XmlNode xmlNode;
            if (GuiCore.GetNodeFromPath(varFullPath, out xmlNode))
            {
                int length = int.Parse(xmlNode.Attributes["length"].Value);
                string arg;
                if (!string.IsNullOrEmpty(xmlNode.Attributes["options"].Value))
                {
                    if (!GuiCore.ValidateOptionValue(xmlNode.Attributes["type"].Value, xmlNode.Attributes["options"].Value, newValue, out arg))
                    {
                        LuaWrapperUtils.LuaWrapper.PrintError(string.Format("RSTD.SetAndTransmit (\"{0}\", \"{1}\"): {2}", varFullPath, newValue, arg));
                        return;
                    }
                }
                else if (!GuiCore.ValidateValue(length, xmlNode.Attributes["type"].Value, newValue, out arg))
                {
                    LuaWrapperUtils.LuaWrapper.PrintError(string.Format("RSTD.SetAndTransmit (\"{0}\", \"{1}\"): {2}", varFullPath, newValue, arg));
                    return;
                }
                if (GuiCore.ChangeVarsValueBeforeTransmit(varFullPath2, varName, newValue))
                {
                    GuiCore.Transmit(varFullPath, ReceiveTransmit_T.SET_AND_TRANSMIT, true);
                }
            }
        }


        [AttrLuaFunc("ReceiveAndGet", "Calls both Receive and GetVar (in that order) for a given variable.", new string[]
        {
            "var full path"
        })]
        public string ReceiveAndGet(string varFullPath)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGetVarDel dGetVarDel = new dGetVarDel(this.ReceiveAndGet);
                Control frmMain = this.m_frmMain;
                Delegate method = dGetVarDel;
                object[] args = new string[]
                {
                    varFullPath
                };
                return (string)frmMain.Invoke(method, args);
            }
            string result = null;
            if (GuiCore.Receive(varFullPath, ReceiveTransmit_T.RECEIVE_AND_GET, true))
            {
                result = this.GetVar(varFullPath);
            }
            return result;
        }


        [AttrLuaFunc("LoadTree", "Loads the given xml file into the BrowseTree.", new string[]
        {
            "File Name."
        })]
        public void LoadFile(string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.LoadFile);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.browse_tree.LoadFile(fileName);
        }


        [AttrLuaFunc("LoadExpose", "Loads the given exposed xml file into the BrowseTree.", new string[]
        {
            "File Name."
        })]
        public void LoadExpose(string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.LoadExpose);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            if (!GuiCore.IsClientBuilt)
            {
                GuiCore.ErrorMessage("Client must be built for requested operation!");
                return;
            }
        }


        [AttrLuaFunc("SaveTree", "Saves the given path from the BrowseTree in the given xml file.", new string[]
        {
            "A given path from the Browse tree",
            "File name"
        })]
        public void SavePath(string path, string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_2String dGuiOperDel_2String = new dGuiOperDel_2String(this.SavePath);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_2String;
                object[] args = new string[]
                {
                    path,
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.browse_tree.SavePath(path, fileName);
        }


        [AttrLuaFunc("Transmit", "Transmits the given BrowseTree path.", new string[]
        {
            "The path"
        })]
        public void Transmit(string path)
        {
            this.m_frmMain.browse_tree.TransmitPath(path, true);
        }


        [AttrLuaFunc("Receive", "Receives the given BrowseTree path.", new string[]
        {
            "The path"
        })]
        public string Receive(string path)
        {
            XmlNode node = null;
            string result = null;
            if (GuiCore.GetNodeFromPath(path, out node) && GuiCore.Receive(path, ReceiveTransmit_T.XML_PATH, true))
            {
                NodeType nodeType = GuiCore.GetNodeType(node);
                if (nodeType > NodeType.VALUE_TYPE_START && nodeType < NodeType.VALUE_TYPE_END)
                {
                    result = this.GetVar(path);
                }
            }
            return result;
        }


        [AttrLuaFunc("LoadVarFromFile", "Loads a vector from a file (with values separated by a newline character) into the given variable.", new string[]
        {
            "The Full Path of the location of the variable.",
            "A file full name."
        })]
        public void LoadVarFromFile(string varFullPath, string fileName)
        {
            if (File.Exists(fileName))
            {
                GuiCore.LoadVarFromFile(varFullPath, fileName);
                return;
            }
            throw new LuaException("LoadVarFromFile attempted to call a non-existing file: " + fileName);
        }


        [AttrLuaFunc("GetFolder", "Returns all vars names within a folder into a lua table", new string[]
        {
            "the folder path"
        })]
        public LuaTable GetFolder(string folder_path)
        {
            XmlNode xmlNode = null;
            if (this.m_frmMain.InvokeRequired)
            {
                dGetFolderDel dGetFolderDel = new dGetFolderDel(this.GetFolder);
                Control frmMain = this.m_frmMain;
                Delegate method = dGetFolderDel;
                object[] args = new string[]
                {
                    folder_path
                };
                return (LuaTable)frmMain.Invoke(method, args);
            }
            int num = folder_path.LastIndexOf('/');
            if (-1 == num)
            {
                throw new LuaException(string.Format("Illegal var {0}", folder_path));
            }
            LuaWrapperUtils.LuaWrapper.LuaVM.NewTable("lua_path_table");
            LuaTable table = LuaWrapperUtils.LuaWrapper.LuaVM.GetTable("lua_path_table");
            if (GuiCore.bGetFolder(folder_path, out xmlNode))
            {
                foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    if (xmlNode2.Attributes != null)
                    {
                        LuaWrapperUtils.LuaWrapper.LuaVM.DoString(string.Format("table.insert(lua_path_table , \"{0}\")", xmlNode2.Attributes["name"].Value.ToString()));
                    }
                }
                return table;
            }
            GuiCore.RstdException("GetFolder(): Could not find selected folder (is client built ?)\n", "");
            return table;
        }


        [AttrLuaFunc("ExportToCsv", "Saves to a csv file all nodes from a given folder in display_type", new string[]
        {
            "the node path",
            "the file path",
            "display type"
        })]
        public void ExportToCsv(string node_path, string file_path, string display_type)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dExportToCsv dExportToCsv = new dExportToCsv(this.ExportToCsv);
                Control frmMain = this.m_frmMain;
                Delegate method = dExportToCsv;
                object[] args = new string[]
                {
                    node_path,
                    file_path,
                    display_type
                };
                frmMain.Invoke(method, args);
                return;
            }
            XmlNode node;
            if (!GuiCore.GetNodeFromPath(node_path, out node))
            {
                return;
            }
            DisplayType display_type2 = (DisplayType)Enum.Parse(typeof(DisplayType), display_type.ToUpper(), true);
            TextWriter textWriter;
            if (!File.Exists(file_path))
            {
                textWriter = File.CreateText(file_path);
            }
            else
            {
                textWriter = new StreamWriter(file_path);
            }
            this.iPrintVarsRecursive(node, textWriter, display_type2);
            textWriter.Close();
        }


        private void iPrintVarsRecursive(XmlNode node, TextWriter tw, DisplayType display_type)
        {
            NodeType nodeType = GuiCore.GetNodeType(node);
            if (nodeType == NodeType.FOLDER)
            {
                foreach (XmlNode node2 in node)
                    this.iPrintVarsRecursive(node2, tw, display_type);
                return;
            }
            if (nodeType > NodeType.VALUE_TYPE_START && nodeType < NodeType.VALUE_TYPE_END)
            {
                string displayedValue = GuiCore.GetDisplayedValue(node, display_type);
                string pathFromNode = GuiCore.GetPathFromNode(node);
                tw.WriteLine(string.Format("{0}, {1} , {2}", pathFromNode, node.Attributes["name"].Value, displayedValue));
            }
        }


        [AttrLuaFunc("GetVarDisplay", "Returns var in the chosen display format", new string[]
        {
            "var full path",
            "display type format(DEFAULT, DECIMAL, DECIMAL_SIGNED, INTEGER, HEX, BINARY, DB10, DB20, MIXED)"
        })]
        public string GetVarDisplay(string var_full_path, string display_type)
        {
            int num = var_full_path.LastIndexOf('/');
            if (-1 == num)
            {
                throw new LuaException(string.Format("Illegal var {0}", var_full_path));
            }
            XmlNode node;
            GuiCore.GetNodeFromPath(var_full_path, out node);
            try
            {
                DisplayType display_type2 = (DisplayType)Enum.Parse(typeof(DisplayType), display_type.ToUpper(), true);
                return GuiCore.GetDisplayedValue(node, display_type2);
            }
            catch (ArgumentException ex)
            {
                GuiCore.RstdException(ex.Message, ex.StackTrace);
            }
            return null;
        }


        [AttrLuaFunc("GoToPath", "Selects and Focuses the Gui on the variable/folder in the given path in the BrowseTree..", new string[]
        {
            "The path"
        })]
        public void GoToPath(string path)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.GoToPath);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    path
                };
                frmMain.Invoke(method, args);
                return;
            }
            if (this.m_frmMain.browse_tree.bJumpToPath(path))
            {
                this.m_frmMain.browse_tree.Show(this.m_frmMain.DockPanel);
            }
        }


        [AttrLuaFunc("MemoryAllocated", "Get the amount of memory currently allocated to this RSTD process (in KB)")]
        public long MemoryAllocated()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_l_v method = new del_l_v(this.MemoryAllocated);
                return (long)this.m_frmMain.Invoke(method);
            }
            return Process.GetCurrentProcess().WorkingSet64 / 1024L;
        }


        [AttrLuaFunc("ExitRstd", "Exits Rstd.")]
        public void ExitRstd()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.ExitRstd);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.AlwaysPrint("RSTD.ExitRstd()\n");
            Application.Exit();
        }


        [AttrLuaFunc("GetPID", "Get RSTD PID in Running Processes")]
        public int GetPID()
        {
            return Process.GetCurrentProcess().Id;
        }


        [AttrLuaFunc("GetRstdVersion", "Returns the RSTD version")]
        public string GetRstdVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        [AttrLuaFunc("Execute", "Execute shell commands in silent mode", new string[]
        {
            "shell command",
            "out: command's output"
        })]
        public int Execute(string cmd_str, out string output)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = string.Format("/c \"{0}\"", cmd_str);
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            output = process.StandardOutput.ReadToEnd();
            string text = process.StandardError.ReadToEnd();
            if (text != string.Empty)
            {
                this.m_frmMain.Warning(string.Format("Execute: {0}\n", text));
            }
            process.WaitForExit();
            return process.ExitCode;
        }


        [AttrLuaFunc("Run", "Opens the file/executable with the given arguments. Return the process’s return-code. Waits for the process to finish before continuing execution..", new string[]
        {
            "File",
            "File Argument"
        })]
        public int RunSynch(string fileNameStr, string argumentStr)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            Process process = new Process();
            bool flag = false;
            processStartInfo.FileName = fileNameStr;
            processStartInfo.Arguments = argumentStr;
            process.StartInfo = processStartInfo;
            int result;
            try
            {
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                flag = true;
                throw new LuaException(string.Format("Run (\"{0}\" , \"{1}\") command threw an exception:\n" + ex.Message, fileNameStr, argumentStr));
            }
            finally
            {
                if (flag)
                {
                    result = 0;
                }
                else
                {
                    result = process.ExitCode;
                }
                process = null;
            }
            return result;
        }


        [AttrLuaFunc("RunInBackground", "Opens the file/executable with the given arguments and runs it Asynchronously, i.e. continues execution of the next command without waiting for process to finish.", new string[]
        {
            "File",
            "File Argument"
        })]
        public void RunAsynch(string fileNameStr, string argumentStr)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            Process process = new Process();
            processStartInfo.FileName = fileNameStr;
            processStartInfo.Arguments = argumentStr;
            process.StartInfo = processStartInfo;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                throw new LuaException(string.Format("RunInBackground (\"{0}\" , \"{1}\") command threw an exception:\n" + ex.Message, fileNameStr, argumentStr));
            }
            finally
            {
            }
        }


        [AttrLuaFunc("Sleep", "Executable main thread sleeps the amount of given miliseconds..", new string[]
        {
            "the duration in miliSeconds"
        })]
        public void Sleep(int sleepDuration_milliSec)
        {
            Thread.Sleep(sleepDuration_milliSec);
        }


        [AttrLuaFunc("SleepUntil", "Executable main thread sleeps until RstdStopRunning() is called by the client.", new string[]
        {
            "String Stop"
        })]
        public void SleepUntil(string endCondition)
        {
            if (endCondition.Equals("Stop"))
            {
                while (!this.m_frmMain.bIsClientRunning)
                {
                    this.Sleep(200);
                }
                while (GuiCore.IsOnScriptThread())
                {
                    if (!this.m_frmMain.bIsClientRunning)
                    {
                        break;
                    }
                    this.Sleep(200);
                }
                while (!CoreImports.bHasStopped())
                {
                    this.Sleep(200);
                }
                Thread.Sleep(200);
                return;
            }
            throw new LuaException(string.Format("Sleep(\"{0}\") : Illegal end condition.", endCondition));
        }


        [AttrLuaFunc("SleepUntilStop", "Executable main thread sleeps until RstdStopRunning() is called by client.")]
        public void SleepUntilWithoutParam()
        {
            while (!this.m_frmMain.bIsClientRunning)
            {
                this.Sleep(200);
            }
            while (GuiCore.IsOnScriptThread())
            {
                if (!this.m_frmMain.bIsClientRunning)
                {
                    break;
                }
                this.Sleep(200);
            }
            while (!CoreImports.bHasStopped())
            {
                this.Sleep(200);
            }
            Thread.Sleep(200);
        }


        [AttrLuaFunc("SetClientDll", "Activates the wanted client", new string[]
        {
            "The Full Path to an AL client dll.",
            "The Full Path to the client dll",
            "Gui dll path",
            "The client's dll."
        })]
        public void SetClientDll(string al_client_path, string client_path, string gui_dll_path, uint client_number)
        {
            string text = "/Settings/Clients";
            string varFullPath = string.Concat(new object[]
            {
                text,
                "/Client ",
                client_number,
                "/Dll"
            });
            string varFullPath2 = "/Settings/AL Client/AL Dll";
            string varFullPath3 = string.Concat(new object[]
            {
                text,
                "/Client ",
                client_number,
                "/GuiDll"
            });
            this.SetVar(varFullPath, client_path);
            for (int i = 0; i < 5; i++)
            {
                string varFullPath4 = string.Concat(new object[]
                {
                    text,
                    "/Client ",
                    i,
                    "/Use"
                });
                if ((ulong)client_number != (ulong)((long)i))
                {
                    this.SetVar(varFullPath4, "FALSE");
                }
                else
                {
                    this.SetVar(varFullPath4, "TRUE");
                }
            }
            this.SetVar(varFullPath2, al_client_path);
            this.SetVar(varFullPath3, gui_dll_path);
        }


        [AttrLuaFunc("ShowLuaHistoryFile", "Opens the current log file.")]
        public void ShowLuaHistoryFile()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.ShowLuaHistoryFile);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.VerbosePrint("RSTD.ShowLuaHistoryFile()\n");
            this.m_frmMain.LogStreamWriter.Flush();
            if (File.Exists(this.m_frmMain.LuaHistoryCommandFile))
            {
                File.SetAttributes(this.m_frmMain.LuaHistoryCommandFile, FileAttributes.ReadOnly);
                Process.Start(this.m_frmMain.LuaHistoryCommandFile);
                return;
            }
            GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_INFORMATION, "History is empty");
        }


        [AttrLuaFunc("LoadConfig", "Loads the Rstd Settings (the first BrowseTree tab) from the given file. (settings are saved/loaded by default in the config.xml file which resides in the same directory as Rstd.exe)", new string[]
        {
            "File name"
        })]
        public void LoadConfig(string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.LoadConfig);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.RstdSettings.LoadSettings(fileName);
        }


        [AttrLuaFunc("SaveConfig", "Saves the Rstd Settings in the given file.", new string[]
        {
            "File name"
        })]
        public void SaveConfig(string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_1String dGuiOperDel_1String = new dGuiOperDel_1String(this.SaveConfig);
                Control frmMain = this.m_frmMain;
                Delegate method = dGuiOperDel_1String;
                object[] args = new string[]
                {
                    fileName
                };
                frmMain.Invoke(method, args);
                return;
            }
            this.m_frmMain.RstdSettings.SaveSettings(fileName);
        }


        [AttrLuaFunc("SaveClientSettings", "Save Rstd Client settings (first Tree tab) - Deprecated. use RSTD.SaveConfig() instead.")]
        public void SaveClientSettings()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.SaveClientSettings);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.RstdSettings.SaveSettings();
        }


        [AttrLuaFunc("SaveSearch", "Searches for the given search string in the exported tree under the base path specified and saves it to a file (in text or xml format according to the given file's extension) e.g.: SaveSearch(\"/\", \"test\", \"Name|Value|Comment\",\"MatchCase|WholeWord|RegularExpression\",\"C:\\00\\test.txt\")", new string[]
        {
            "base place",
            "search string",
            "search context",
            "search options",
            "file Name"
        })]
        public void SaveSearch(string base_path, string search_string, string search_context, string search_options, string fileName)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_5String method = new dGuiOperDel_5String(this.SaveSearch);
                this.m_frmMain.Invoke(method, new object[]
                {
                    base_path,
                    search_string,
                    search_context,
                    search_options,
                    fileName
                });
                return;
            }
            GuiCore.SaveSearch(base_path, search_string, search_context, search_options, fileName);
        }


        [AttrLuaFunc("GetSearch", "Searches for the given search string in the exported tree under the base path specified and returns it as LuaTable  e.g.: GetSearch(\"/\", \"test\", \"Name|Value|Comment\",\"MatchCase|WholeWord|RegularExpression\")", new string[]
        {
            "base place",
            "search string",
            "search context",
            "search options"
        })]
        public LuaTable GetSearch(string base_path, string search_string, string search_context, string search_options)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_4String method = new dGuiOperDel_4String(this.GetSearch);
                return (LuaTable)this.m_frmMain.Invoke(method, new object[]
                {
                    base_path,
                    search_string,
                    search_context,
                    search_options
                });
            }
            string text = "";
            List<XmlNode> list = new List<XmlNode>();
            LuaTable result = null;
            List<object> list2 = new List<object>();
            try
            {
                list = GuiCore.GetSearch(base_path, search_string, search_context, search_options, ref text);
                if (text != "")
                {
                    GuiCore.AlwaysPrint(string.Format("GetSearch:{0}", text));
                }
                else if (list.Count == 0)
                {
                    GuiCore.AlwaysPrint("GetSearch: No results found!");
                }
                else
                {
                    foreach (XmlNode xml_node in list)
                    {
                        list2.Add(GuiCore.GetPathFromNode(xml_node));
                    }
                    result = LuaWrapperUtils.LuaWrapper.CreateLuaTable(list2);
                }
            }
            catch (Exception ex)
            {
                GuiCore.RstdException(ex.Message, ex.StackTrace);
            }
            return result;
        }


        [AttrLuaFunc("BrowseForFile", "Browses for a file and returns its full path", new string[]
        {
            "Starting directory",
            "filter by extensions (e.g. \"bmp,jpeg\")",
            "title"
        })]
        public string BrowseForFile(string initial_dir, string filter, string title)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dOpenFileDialogDel method = new dOpenFileDialogDel(this.BrowseForFile);
                return (string)this.m_frmMain.Invoke(method, new object[]
                {
                    initial_dir,
                    filter,
                    title
                });
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string text = "";
            openFileDialog.RestoreDirectory = true;
            if ("" != title)
            {
                openFileDialog.Title = title;
            }
            else
            {
                openFileDialog.Title = "Browse for file";
            }
            if (string.IsNullOrEmpty(filter))
            {
                filter = "All Files (*.*)|*.*";
            }
            else
            {
                string[] array = filter.Split(new char[]
                {
                    ';',
                    ','
                }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < array.Length; i++)
                {
                    if (i > 0)
                    {
                        text += ";";
                    }
                    text = text + "*." + array[i];
                }
                filter = string.Format("({0})|{0}", text);
            }
            openFileDialog.Filter = filter;
            if (!string.IsNullOrEmpty(initial_dir))
            {
                openFileDialog.InitialDirectory = initial_dir;
            }
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }


        [AttrLuaFunc("FolderBrowser", "Select a folder")]
        public LuaTable FolderBrowser()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiSelectFolderDel method = new dGuiSelectFolderDel(this.FolderBrowser);
                return (LuaTable)this.m_frmMain.Invoke(method);
            }
            FolderBrowseDialog folderBrowseDialog = new FolderBrowseDialog();
            folderBrowseDialog.ShowDialog();
            return folderBrowseDialog.Folders;
        }


        [AttrLuaFunc("BrowseForFolder", "Browses for a folder and returns its full path", new string[]
        {
            "Starting directory",
            "description"
        })]
        public string BrowseForFolder(string initial_dir, string description)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dOpenFolderDialogDel method = new dOpenFolderDialogDel(this.BrowseForFolder);
                return (string)this.m_frmMain.Invoke(method, new object[]
                {
                    initial_dir,
                    description
                });
            }
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if ("" != description)
            {
                folderBrowserDialog.Description = description;
            }
            else
            {
                folderBrowserDialog.Description = "Browse for folder";
            }
            if (Directory.Exists(initial_dir))
            {
                folderBrowserDialog.SelectedPath = initial_dir;
            }
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                return folderBrowserDialog.SelectedPath;
            }
            return "";
        }


        public int API_DoString(string str_expression, out object[] obj_arr, out string err_msg)
        {
            int result;
            try
            {
                obj_arr = LuaWrapperUtils.LuaWrapper.LuaVM.DoString(str_expression);
                err_msg = "";
                result = 0;
            }
            catch (Exception ex)
            {
                obj_arr = null;
                err_msg = ex.Message;
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint("\n***Script FAILED!***");
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint(string.Format("\nScript: \"{0}\"", str_expression));
                this.m_frmMain.MustPrint("\nException message is:\n");
                this.m_frmMain.MustPrint(ex.Message + "\n\n");
                result = 1;
            }
            return result;
        }


        [AttrLuaFunc("DoString", "Runs a string in Lua", new string[]
        {
            "String"
        })]
        public LuaTable DoString(string str_expression)
        {
            LuaTable result;
            try
            {
                object[] array = LuaWrapperUtils.LuaWrapper.LuaVM.DoString(str_expression);
                if (array == null || array.Length == 0)
                {
                    result = null;
                }
                else
                {
                    List<object> values = new List<object>(array);
                    result = LuaWrapperUtils.LuaWrapper.CreateLuaTable(values);
                }
            }
            catch (Exception ex)
            {
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint("\n***Script FAILED!***");
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint(string.Format("\nScript: \"{0}\"", str_expression));
                this.m_frmMain.MustPrint("\nException message is:\n");
                this.m_frmMain.MustPrint(ex.Message + "\n\n");
                result = null;
            }
            return result;
        }


        [AttrLuaFunc("ParseFile", "Parsing block comments in a file to get function description", new string[]
        {
            "file path"
        })]
        public void ParseFile(string file_name)
        {
            try
            {
                LuaWrapperUtils.LuaWrapper.LuaParser.ParseFile(file_name);
            }
            catch (Exception ex)
            {
                m_frmMain.MustPrint(ex.Message + "\n\n");
            }
        }


        public object[] API_DoFile(string file_name)
        {
            object[] result;
            try
            {
                result = LuaWrapperUtils.LuaWrapper.DoFile(file_name);
            }
            catch (Exception ex)
            {
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint("\n***Script FAILED!***");
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint(string.Format("\nScript: \"{0}\"", file_name));
                this.m_frmMain.MustPrint("\nException message is:\n");
                this.m_frmMain.MustPrint(ex.Message + "\n\n");
                result = null;
            }
            return result;
        }


        [AttrLuaFunc("DoFile", "Runs a file in Lua", new string[]
        {
            "File name"
        })]
        public LuaTable DoFile(string file_name)
        {
            LuaTable result;
            try
            {
                object[] array = LuaWrapperUtils.LuaWrapper.DoFile(file_name);
                if (array == null || array.Length == 0)
                {
                    result = null;
                }
                else
                {
                    List<object> values = new List<object>(array);
                    result = LuaWrapperUtils.LuaWrapper.CreateLuaTable(values);
                }
            }
            catch (Exception ex)
            {
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint("\n***Script FAILED!***");
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint(string.Format("\nScript: \"{0}\"", file_name));
                this.m_frmMain.MustPrint("\nException message is:\n");
                this.m_frmMain.MustPrint(ex.Message + "\n\n");
                result = null;
            }
            return result;
        }


        [AttrLuaFunc("DoFileParams", "Runs a file in Lua with given params", new string[]
        {
            "File name",
            "Script params"
        })]
        public object[] DoFile(string file_name, List<object> script_params)
        {
            object[] result;
            try
            {
                result = LuaWrapperUtils.LuaWrapper.LoadFile(file_name).Call(script_params.ToArray());
            }
            catch (Exception ex)
            {
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint("\n***Script FAILED!***");
                this.m_frmMain.MustPrint("\n&&&&&&&&&&&&&&&&&&&&");
                this.m_frmMain.MustPrint(string.Format("\nScript: \"{0}\"", file_name));
                this.m_frmMain.MustPrint("\nException message is:\n");
                this.m_frmMain.MustPrint(ex.Message + "\n\n");
                result = null;
            }
            return result;
        }


        [AttrLuaFunc("doFileRelative", "Set working directory to the current dofile directory ", new string[]
        {
            "File name"
        })]
        public void doFileRelative(string file_name)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            try
            {
                file_name = this.iSetDirToFileDir(file_name);
                LuaWrapperUtils.LuaWrapper.DoFile(file_name);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }


        private string iSetDirToFileDir(string fullFileName)
        {
            int i;
            for (i = fullFileName.IndexOf(".."); i > -1; i = fullFileName.IndexOf(".."))
            {
                int num = fullFileName.IndexOf("\\");
                if (num <= 0)
                {
                    break;
                }
                num++;
                Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
                fullFileName = fullFileName.Remove(i, num - i);
            }
            i = fullFileName.LastIndexOf("\\");
            string result;
            if (i > -1)
            {
                i++;
                result = fullFileName.Substring(i, fullFileName.Length - i);
                string text = this.iExtractPathFromFileName(fullFileName);
                if (text != "")
                {
                    Directory.SetCurrentDirectory(text);
                }
            }
            else
            {
                result = fullFileName;
            }
            return result;
        }


        private string iExtractPathFromFileName(string fileName)
        {
            string result = "";
            int num = fileName.LastIndexOf('\\');
            if (num != -1)
            {
                result = fileName.Substring(0, num);
            }
            return result;
        }


        [AttrLuaFunc("IsDllRegistered", "Check if DLL already registered", new string[]
        {
            "DLL full path"
        })]
        public bool IsDllRegistered(string dll_path)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(dll_path) || !File.Exists(dll_path))
            {
                this.m_frmMain.Warning(string.Format("IsDllRegistered: Could not find path \"{0}\"\n", dll_path));
                return false;
            }
            int num = 0;
            while (num < RstdGuiSettings.Default.LuaRegisterInfos.Count && !flag)
            {
                if (Path.GetFullPath(RstdGuiSettings.Default.LuaRegisterInfos[num].DllPath) == Path.GetFullPath(dll_path))
                {
                    flag = true;
                }
                num++;
            }
            return flag;
        }


        [AttrLuaFunc("RegisterDll", "Register DLL to Lua", new string[]
        {
            "DLL full path"
        })]
        public bool RegisterDll(string dll_path)
        {
            return this.RegisterDllEx(dll_path, true);
        }


        [AttrLuaFunc("RegisterDllEx", "Register DLL to Lua - extended version", new string[]
        {
            "DLL full path",
            "Save dll to settings file on exit (for auto-load next time) or not"
        })]
        public bool RegisterDllEx(string dll_path, bool save_to_settings)
        {
            if (string.IsNullOrEmpty(dll_path) || !File.Exists(dll_path))
            {
                this.m_frmMain.Warning(string.Format("RegisterDll: Could not find path \"{0}\"\n", dll_path));
                return false;
            }
            LuaRegisterInfo luaRegisterInfo = new LuaRegisterInfo();
            luaRegisterInfo.Use = true;
            luaRegisterInfo.DllPath = dll_path;
            luaRegisterInfo.IsRegistered = false;
            luaRegisterInfo.SaveToSettings = save_to_settings;
            if (this.m_frmMain.GetDllModuleName(luaRegisterInfo))
            {
                for (int i = 0; i < RstdGuiSettings.Default.LuaRegisterInfos.Count; i++)
                {
                    LuaRegisterInfo luaRegisterInfo2 = RstdGuiSettings.Default.LuaRegisterInfos[i];
                    if (luaRegisterInfo2.Package == luaRegisterInfo.Package)
                    {
                        this.m_frmMain.UnregisterLuaDll(luaRegisterInfo2);
                        RstdGuiSettings.Default.LuaRegisterInfos.Remove(luaRegisterInfo2);
                        break;
                    }
                }
                RstdGuiSettings.Default.LuaRegisterInfos.Add(luaRegisterInfo);
                this.m_frmMain.RegisterDllToLua(luaRegisterInfo);
                return true;
            }
            this.m_frmMain.Warning(string.Format("RegisterDll: path \"{0}\" does not contain a Lua module\n", dll_path));
            return false;
        }


        [AttrLuaFunc("UnRegisterDll", "UnRegister a previously registered Dll", new string[]
        {
            "Dll full path"
        })]
        public bool UnRegisterDll(string dll_path)
        {
            bool result = false;
            LuaRegisterInfo luaRegisterInfo = null;
            foreach (LuaRegisterInfo luaRegisterInfo2 in RstdGuiSettings.Default.LuaRegisterInfos)
            {
                if (luaRegisterInfo2.DllPath != null && luaRegisterInfo2.DllPath.ToUpper() == dll_path.ToUpper())
                {
                    this.m_frmMain.UnregisterLuaDll(luaRegisterInfo2);
                    luaRegisterInfo = luaRegisterInfo2;
                    result = true;
                    break;
                }
            }
            if (luaRegisterInfo != null)
            {
                RstdGuiSettings.Default.LuaRegisterInfos.Remove(luaRegisterInfo);
            }
            else
            {
                this.m_frmMain.AlwaysPrint(string.Format("UnRegisterDll: Ignored. dll \"{0}\" is not registered.\n", dll_path));
            }
            return result;
        }


        [AttrLuaFunc("ClearRegisteredDlls", "Clear all registered Dll to Lua")]
        public void ClearRegisteredDlls()
        {
            for (int i = 0; i < RstdGuiSettings.Default.LuaRegisterInfos.Count; i++)
            {
                this.m_frmMain.UnregisterLuaDll(RstdGuiSettings.Default.LuaRegisterInfos[i]);
            }
            RstdGuiSettings.Default.LuaRegisterInfos.Clear();
        }


        [AttrLuaFunc("GetFileLastModified", "Get the last modification time of a given file (0 on error)", new string[]
        {
            "the file"
        })]
        public string GetFileLastModified(string file_path)
        {
            if (File.Exists(file_path))
            {
                return File.GetLastWriteTime(file_path).ToFileTime().ToString();
            }
            this.m_frmMain.AlwaysPrint(string.Format("GetFileLastModified: Could not locate file {0}\n", file_path));
            return null;
        }


        [AttrLuaFunc("SetExternalAL", "Set registered DLL as Abstraction Layer (for handling Receive/Transmit operations)", new string[]
        {
            "DLL path"
        })]
        public void SetExternalAL(string dll_path)
        {
            bool flag = false;
            foreach (LuaRegisterInfo luaRegisterInfo in RstdGuiSettings.Default.LuaRegisterInfos)
            {
                if (luaRegisterInfo.DllPath != null && luaRegisterInfo.DllPath.ToUpper() == dll_path.ToUpper() && luaRegisterInfo.ClassObj != null)
                {
                    luaRegisterInfo.ClassObj.SetALOps();
                    GuiCore.m_ExternalTransmit = luaRegisterInfo.ClassObj.Transmit_func;
                    GuiCore.m_ExternalReceive = luaRegisterInfo.ClassObj.Receive_func;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                this.m_frmMain.Warning(string.Format("SetExternalAL: failed to set \"{0}\" as AL.\nCheck that the DLL was registered.\n", dll_path));
            }
        }


        [AttrLuaFunc("CreateNextLogFile", "Creates a new logfile (and verbose logfile) with the next sub index (i.e. \"log0015_1.txt\").")]
        public void CreateNextSubLogFile()
        {
            this.m_frmMain.LogStreamWriter.Close();
            if (GuiCore.UseVerboseLog)
            {
                this.m_frmMain.LogVerboseStreamWriter.Close();
            }
            string outputPath = GuiCore.GetOutputPath();
            if (this.m_frmMain.LastLogFileName.Remove(this.m_frmMain.LastLogFileName.LastIndexOf("Log\\")) != outputPath)
            {
                this.m_frmMain.InitLogFile();
                return;
            }
            this.m_frmMain.LastLogFileName = GuiCore.IncrementSubFileNameIdx(this.m_frmMain.LastLogFileName);
            this.m_frmMain.LogStreamWriter = File.CreateText(this.m_frmMain.LastLogFileName);
            if (GuiCore.UseVerboseLog)
            {
                string path = this.m_frmMain.LastLogFileName.Remove(this.m_frmMain.LastLogFileName.Length - 4) + "_verbose.txt";
                this.m_frmMain.LogVerboseStreamWriter = File.CreateText(path);
            }
        }


        [AttrLuaFunc("CreateUserDefinedLogFile", "Creates a new used defined logfile.", new string[]
        {
            "Output file path",
            "reserved"
        })]
        public int CreateUserDefinedLogFile(string path, int reserved)
        {
            this.m_frmMain.LogStreamWriter.Close();
            bool useVerboseLog = GuiCore.UseVerboseLog;
            GuiCore.GetOutputPath();
            this.m_frmMain.LastLogFileName.Remove(this.m_frmMain.LastLogFileName.LastIndexOf("Log\\"));
            this.m_frmMain.LogStreamWriter = File.CreateText(path);
            return 0;
        }


        [AttrLuaFunc("ShowLogFile", "Opens the current log file.")]
        public void ShowLogFile()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.ShowLogFile);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.VerbosePrint("RSTD.ShowLogFile()\n");
            this.m_frmMain.LogStreamWriter.Flush();
            if (File.Exists(this.m_frmMain.LastLogFileName))
            {
                Process.Start(this.m_frmMain.LastLogFileName);
            }
        }


        [AttrLuaFunc("WatchDogStop", "Close WatchDog")]
        public void WatchDogStop()
        {
            GuiCore.AlwaysPrint("WatchDogStop()\n");
            GuiCore.MainForm.WatchDogManager.Stop();
            GuiCore.AlwaysPrint(0U, 2U, "***WatchDog Stopped***\n");
        }


        [AttrLuaFunc("WatchDogStopAu", "Close WatchDog")]
        public void WatchDogStopAu()
        {
            GuiCore.AlwaysPrint("WatchDogStopAu()\n");
            GuiCore.MainForm.WatchDogManager.Stop("WatchDogAu", true);
            GuiCore.AlwaysPrint(0U, 2U, "***WatchDogStopAu Stopped***\n");
        }


        [AttrLuaFunc("WatchDogStartAu", "Opens WatchDog", new string[]
        {
            "TimeOut between samples in seconds",
            "ScriptName to run after crash",
            "Full file name to watch"
        })]
        public void WatchDogStartAu(uint timeout, string cmd_to_run, string control_file_name)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_u_s_s method = new del_v_u_s_s(this.WatchDogStartAu);
                this.m_frmMain.Invoke(method, new object[]
                {
                    timeout,
                    cmd_to_run,
                    control_file_name
                });
                return;
            }
            GuiCore.AlwaysPrint(string.Format("WatchDogStartAu({0},{1},{2})\n", timeout, cmd_to_run, control_file_name));
            this.m_frmMain.Warning("WatchDog(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("WatchDogStart", "Opens WatchDog", new string[]
        {
            "TimeOut between samples in seconds",
            "ScriptName to run after crash",
            "Level between 1-3. 1- all errors & messages, 2- only on errors, 3- non-lua errors only"
        })]
        public void WatchDogStart(uint timeout, string script_name, int level)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                del_v_u_s_i method = new del_v_u_s_i(this.WatchDogStart);
                this.m_frmMain.Invoke(method, new object[]
                {
                    timeout,
                    script_name,
                    level
                });
                return;
            }
            GuiCore.AlwaysPrint(string.Format("WatchDogStart({0},{1},{2})\n", timeout, script_name, level));
            this.m_frmMain.Warning("WatchDog(): The Command is not supported in this installation.\n");
        }


        [AttrLuaFunc("Reggae", "Opens Reggae with the last monitor output file.")]
        public void Reggae()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.Reggae);
                this.m_frmMain.Invoke(method);
                return;
            }
            this.m_frmMain.Warning("Reggae(): The Command is not supported in this installation.\n");
        }


        private Process iStartReggae(string monitor_path)
        {
            Process result;
            try
            {
                if (this.m_frmMain.ReggaeProcess == null)
                {
                    this.m_frmMain.ReggaeProcess = new ArrayList();
                }
                if (monitor_path != null)
                {
                    this.m_frmMain.ReggaeProcess.Add(Process.Start(Application.StartupPath + "\\Reggae.exe", monitor_path));
                }
                else
                {
                    this.m_frmMain.ReggaeProcess.Add(Process.Start(Application.StartupPath + "\\Reggae.exe"));
                }
                result = (Process)this.m_frmMain.ReggaeProcess[this.m_frmMain.ReggaeProcess.Count - 1];
            }
            catch (Exception ex)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, string.Format("Reggae init failed:\n{0}", ex.Message), ex.StackTrace);
                result = null;
            }
            return result;
        }


        [AttrLuaFunc("KillReggae", "Kills all reggae instances which were called from the current Rstd process.")]
        public void KillReggae()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel method = new dGuiOperDel(this.KillReggae);
                this.m_frmMain.Invoke(method);
                return;
            }
            try
            {
                if (this.m_frmMain.ReggaeProcess != null)
                {
                    foreach (object obj in this.m_frmMain.ReggaeProcess)
                    {
                        Process process = (Process)obj;
                        if (!process.HasExited)
                        {
                            process.Kill();
                        }
                    }
                    this.m_frmMain.ReggaeProcess.Clear();
                }
            }
            catch (Exception ex)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, string.Format("Reggae Close failed:\n{0}", ex.Message), ex.StackTrace);
            }
        }


        [AttrLuaFunc("Plot", "Plots a vector to Reggae", new string[]
        {
            "Chart name",
            "Series name",
            "X values",
            "Y values"
        })]
        public void Plot(string chart_name, string series_name, LuaTable x_values, LuaTable y_values)
        {
            this.m_frmMain.Warning("Plot(): The Command is not supported in this installation.\n");
        }


        public void CallReggaePlot(string chart_name, string series_name, double[] x_arr, double[] y_arr_real, double[] y_arr_imag, bool b_is_complex)
        {
            Process process = this.iGetReggaeInstance();
            if (process == null)
            {
                process = this.iStartReggae(null);
                if (process == null)
                {
                    return;
                }
            }
            IRemotableReggaeObject remotableReggaeObject = (IRemotableReggaeObject)Activator.GetObject(typeof(IRemotableReggaeObject), "tcp://localhost:8080/ReggaeRemoting");
            if (b_is_complex)
            {
                remotableReggaeObject.Plot(chart_name, series_name, x_arr, y_arr_real, y_arr_imag);
            }
            else
            {
                remotableReggaeObject.Plot(chart_name, series_name, x_arr, y_arr_real);
            }
            if (!process.HasExited)
            {
                CoreImports.SetForegroundWindow(process.MainWindowHandle);
                GuiCore.RestoreWindow(process.MainWindowHandle);
            }
        }


        [AttrLuaFunc("PlotAnotate", "Sets annotation for a plotted chart", new string[]
        {
            "Chart name",
            "label for X axis",
            "label for Y axis",
            "Chart title"
        })]
        public void PlotAnotate(string chart_name, string x_axis_label, string y_axis_label, string chart_title)
        {
            if (this.iGetReggaeInstance() == null)
            {
                this.m_frmMain.Warning("PlotAnotate: Could not find an active Reggae instance\n");
                return;
            }
            ((IRemotableReggaeObject)Activator.GetObject(typeof(IRemotableReggaeObject), "tcp://localhost:8080/ReggaeRemoting")).PlotAnotate(chart_name, x_axis_label, y_axis_label, chart_title);
        }


        [AttrLuaFunc("PlotClear", "Inactive all series from all charts")]
        public void PlotClear()
        {
            if (this.iGetReggaeInstance() == null)
            {
                this.m_frmMain.Warning("PlotClear: Could not find an active Reggae instance\n");
                return;
            }
            ((IRemotableReggaeObject)Activator.GetObject(typeof(IRemotableReggaeObject), "tcp://localhost:8080/ReggaeRemoting")).PlotClear();
        }


        private Process iGetReggaeInstance()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "Reggae")
                {
                    return process;
                }
            }
            return null;
        }


        [AttrLuaFunc("RegisterServer", "Register the RT3 to listen on the specified port for incoming remote calls", new string[]
        {
            "The port"
        })]
        public bool RegisterServer(int port)
        {
            return this.m_RemoteManager.RegisterServer(port);
        }


        [AttrLuaFunc("RegisterClient", "Register a Lua table as a client for sending remote calls to an RT3 server at ip_address:port", new string[]
        {
            "The Server IP Address",
            "The Server port",
            "The Lua table name"
        })]
        public bool RegisterClient(string ip_address, int port, string table_name)
        {
            return this.m_RemoteManager.RegisterClient(ip_address, port, table_name);
        }


        [AttrLuaFunc("bitWiseAnd", "bitWise And", new string[]
        {
            "param1",
            "param2"
        })]
        public uint bitWiseAnd(uint frtNum, uint scndNum)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                duGuiOperDel_2Uint32 method = new duGuiOperDel_2Uint32(this.bitWiseAnd);
                return (uint)this.m_frmMain.Invoke(method, new object[]
                {
                    frtNum,
                    scndNum
                });
            }
            return frtNum & scndNum;
        }


        [AttrLuaFunc("bitWiseOr", "bitWise Or", new string[]
        {
            "param1",
            "param2"
        })]
        public uint bitWiseOr(uint frtNum, uint scndNum)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                duGuiOperDel_2Uint32 method = new duGuiOperDel_2Uint32(this.bitWiseOr);
                return (uint)this.m_frmMain.Invoke(method, new object[]
                {
                    frtNum,
                    scndNum
                });
            }
            return frtNum | scndNum;
        }


        [AttrLuaFunc("bitWiseNot", "bitWise Not", new string[]
        {
            "param1"
        })]
        public uint bitWiseNot(uint inNum)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                duGuiOperDel_1Uint32 method = new duGuiOperDel_1Uint32(this.bitWiseNot);
                return (uint)this.m_frmMain.Invoke(method, new object[]
                {
                    inNum
                });
            }
            return ~inNum;
        }


        [AttrLuaFunc("InputMessageBox", "Writes the message in a GUI MessageBox and gets the answer from user", new string[]
        {
            "Message To Write"
        })]
        public string InteractiveGuiMessage(string message)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGetVarDel method = new dGetVarDel(this.InteractiveGuiMessage);
                return (string)this.m_frmMain.Invoke(method, new object[]
                {
                    message
                });
            }
            frmInteractiveMsgBox frmInteractiveMsgBox = new frmInteractiveMsgBox(message);
            if (this.m_frmMain.WindowState == FormWindowState.Minimized)
            {
                this.m_frmMain.WindowState = FormWindowState.Normal;
            }
            frmInteractiveMsgBox.ShowDialog();
            return frmInteractiveMsgBox.Answer;
        }


        [AttrLuaFunc("MessageBox", "Writes the message in a GUI MessageBox", new string[]
        {
            "Message To Write",
            "true – pauses execution, the MessageBox must be closed to continue. false – does not pause execution.."
        })]
        public void GuiMessage(string message, bool isModal)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDel_GuiMessage method = new dGuiOperDel_GuiMessage(this.GuiMessage);
                this.m_frmMain.Invoke(method, new object[]
                {
                    message,
                    isModal
                });
                return;
            }
            frmMessage frmMessage = new frmMessage(message);
            if (isModal)
            {
                if (this.m_frmMain.WindowState == FormWindowState.Minimized)
                {
                    this.m_frmMain.WindowState = FormWindowState.Normal;
                }
                frmMessage.ShowDialog();
                return;
            }
            frmMessage.Show();
        }


        [AttrLuaFunc("YesNoTimerMsgBox", "Writes a question in a GUI MessageBox with timer", new string[]
        {
            "Question To Show",
            "Default answer",
            "Timer"
        })]
        public bool YesNoTimerMsgBox(string text, bool defaultAns, int t)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dbGuiOperDel_1String1bool1int method = new dbGuiOperDel_1String1bool1int(this.YesNoTimerMsgBox);
                return (bool)this.m_frmMain.Invoke(method, new object[]
                {
                    text,
                    defaultAns,
                    t
                });
            }
            this.myYesNoTimerMsgBox.configure(text, defaultAns, t);
            this.myYesNoTimerMsgBox.ShowDialog(this.m_frmMain);
            return this.myYesNoTimerMsgBox.ans;
        }


        [AttrLuaFunc("YesNoMsgBox", "Writes a question in a GUI MessageBox", new string[]
        {
            "Question To Show"
        })]
        public bool YesNoMsgBox(string question)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dbGuiOperDel_1String method = new dbGuiOperDel_1String(this.YesNoMsgBox);
                return (bool)this.m_frmMain.Invoke(method, new object[]
                {
                    question
                });
            }
            bool result = true;
            DialogResult dialogResult = MessageBox.Show(question, "LUA script message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == dialogResult)
            {
                result = false;
            }
            return result;
        }


        [AttrLuaFunc("Message", "Writes the text in the Rstd console", new string[]
        {
            "Text To Write"
        })]
        public void LuaMessage(string text)
        {
            if (text == null)
            {
                text = "nil";
            }
            this.m_frmMain.AlwaysPrint(0U, 0U, text, true, false);
        }


        [AttrLuaFunc("MessageColor", "Writes the text in the Rstd console in specified color", new string[]
        {
            "Text To Write",
            "Color"
        })]
        public void LuaMessageColor(string text, uint text_color)
        {
            this.m_frmMain.AlwaysPrint(0U, text_color, text, true, false);
        }


        [AttrLuaFunc("MessageColorAdvanced", "Writes the text in the Rstd console in specified color, removes ", new string[]
        {
            "Text To Write",
            "Color"
        })]
        public void LuaMessageColorAdvanced(string text, uint text_color)
        {
            text = text.Replace("\n", "*****");
            this.m_frmMain.AlwaysPrint(0U, text_color, text, true, false);
        }


        [AttrLuaFunc("GetApplicationDir", "Get the directory where the RSTD.exe is located")]
        public string GetApplicationDir()
        {
            return Path.GetFullPath(Application.StartupPath);
        }


        [AttrLuaFunc("GetRstdPath", "Get the directory where the RSTD application resides")]
        public string GetRstdPath()
        {
            return Path.GetFullPath(Application.StartupPath + "\\..");
        }


        [AttrLuaFunc("GetSettingsPath", "Get the directory where the RSTD settings resides")]
        public string GetSettingsPath()
        {
            return this.m_frmMain.SettingsOutputPath;
        }


        [AttrLuaFunc("GetInputPath", "Returns the Input working directory path.")]
        public string GetInputPath()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.GetInputPath);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.RstdSettings.GetInputPath();
        }


        [AttrLuaFunc("GetLuaPath", "Returns the Lua working directory path.")]
        public string GetLuaPath()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.GetLuaPath);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.RstdSettings.GetLuaPath();
        }


        [AttrLuaFunc("GetConfigPath", "Returns the Config working directory path.")]
        public string GetConfigPath()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.GetConfigPath);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.RstdSettings.GetConfigPath();
        }


        [AttrLuaFunc("GetOutputPath", "Returns the Output working directory path.")]
        public string GetOutputPath()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.GetOutputPath);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.RstdSettings.GetOutputPath();
        }


        [AttrLuaFunc("GetClearCasePath", "Returns the ClearCase path which was defined.")]
        public string GetClearCasePath()
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dGuiOperDelRetStr method = new dGuiOperDelRetStr(this.GetClearCasePath);
                return (string)this.m_frmMain.Invoke(method);
            }
            return this.m_frmMain.RstdSettings.GetClearCasePath().Trim();
        }


        [AttrLuaFunc("SetWorkingDirectory", "Changes the current working directory", new string[]
        {
            "full directory path"
        })]
        public void SetWorkingDirectory(string full_path)
        {
            if (!Directory.Exists(full_path))
            {
                this.m_frmMain.AlwaysPrint(string.Format("WARNING: SetWorkingDirectory(): can't find directory \"{0}\"\n", full_path));
                return;
            }
            Environment.CurrentDirectory = full_path;
            this.m_frmMain.AlwaysPrint(string.Format("SetWorkingDirectory(): directory changed to \"{0}\"\n", full_path));
        }


        [AttrLuaFunc("GetWorkingDirectory", "Displays the current working directory")]
        public string GetWorkingDirectory()
        {
            return Environment.CurrentDirectory;
        }


        [AttrLuaFunc("Dir", "Returns all filenames in given path in Lua table", new string[]
        {
            "full dir path",
            "files filter",
            "recursive dir",
            "files as full path"
        })]
        public LuaTable Dir(string dir_path, string filter, bool recursive, bool full_path)
        {
            StringBuilder stringBuilder = new StringBuilder("{");
            SearchOption searchOption;
            if (recursive)
            {
                searchOption = SearchOption.AllDirectories;
            }
            else
            {
                searchOption = SearchOption.TopDirectoryOnly;
            }
            if (string.IsNullOrEmpty(filter))
            {
                filter = "*.*";
            }
            FileInfo[] files = new DirectoryInfo(dir_path).GetFiles(filter, searchOption);
            if (files.Length == 0)
            {
                return null;
            }
            foreach (FileInfo fileInfo in files)
            {
                string value;
                if (full_path)
                {
                    value = fileInfo.FullName.Replace("\\", "\\\\");
                }
                else
                {
                    value = fileInfo.Name;
                }
                stringBuilder.Append("\"");
                stringBuilder.Append(value);
                stringBuilder.Append("\",");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("}");
            string chunk = string.Format("local out_table = {0} return out_table", stringBuilder.ToString());
            return (LuaTable)LuaWrapperUtils.LuaWrapper.LuaVM.DoString(chunk)[0];
        }


        [AttrLuaFunc("FileExists", "Returns true if file exists", new string[]
        {
            "full file name"
        })]
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }


        [AttrLuaFunc("AddToAutoUpdate", "Add Auto update to variable", new string[]
        {
            "The path of the var to add"
        })]
        public bool bAddToAutoUpdate(string fullPath)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dbGuiOperDel_1String dbGuiOperDel_1String = new dbGuiOperDel_1String(this.bAddToAutoUpdate);
                Control frmMain = this.m_frmMain;
                Delegate method = dbGuiOperDel_1String;
                object[] args = new string[]
                {
                    fullPath
                };
                return (bool)frmMain.Invoke(method, args);
            }
            return GuiCore.bAddToAutoUpdate(fullPath);
        }


        [AttrLuaFunc("RemoveFromAutoUpdate", "Remove Auto update from variable", new string[]
        {
            "The path of the var to remove"
        })]
        public bool bRemoveFromAutoUpdate(string fullPath)
        {
            if (this.m_frmMain.InvokeRequired)
            {
                dbGuiOperDel_1String dbGuiOperDel_1String = new dbGuiOperDel_1String(this.bRemoveFromAutoUpdate);
                Control frmMain = this.m_frmMain;
                Delegate method = dbGuiOperDel_1String;
                object[] args = new string[]
                {
                    fullPath
                };
                return (bool)frmMain.Invoke(method, args);
            }
            return GuiCore.bRemoveFromAutoUpdate(fullPath);
        }


        [AttrLuaFunc("AutoUpdateStart", "Start the Auto update")]
        public void AutoUpdateStart()
        {
            object lockerAutoUpdateTimer = this.m_frmMain.browse_tree.LockerAutoUpdateTimer;
            lock (lockerAutoUpdateTimer)
            {
                this.m_frmMain.browse_tree.AutoUpdateTimer.Start();
            }
        }


        [AttrLuaFunc("AutoUpdateStop", "Stop the Auto update")]
        public void AutoUpdateStop()
        {
            object lockerAutoUpdateTimer = this.m_frmMain.browse_tree.LockerAutoUpdateTimer;
            lock (lockerAutoUpdateTimer)
            {
                this.m_frmMain.browse_tree.AutoUpdateTimer.Stop();
            }
        }


        [AttrLuaFunc("NetStart", "Start the RT3 Net Server listening on default port (2777)")]
        public int NetStart()
        {
            return this.iNetStart(RstdNetConsts.DEFAULT_PORT);
        }


        [AttrLuaFunc("NetStart_Port", "Start the RT3 Net Server listening on provided port", new string[]
        {
            "port to listen on"
        })]
        public int NetStart_Port(int port)
        {
            return this.iNetStart(port);
        }


        private int iNetStart(int port)
        {
            RstdServer rstdServer;
            if (!this.m_frmMain.ServerExists(port))
            {
                rstdServer = this.m_frmMain.AddNewServer(port);
            }
            else
            {
                rstdServer = this.m_frmMain.GetServer(port);
            }
            if (rstdServer.State != ServerState.Disconnected)
            {
                this.m_frmMain.ErrorPrint(string.Format("NetStart: already listnening to port {0}\n", port));
                return -1;
            }
            return rstdServer.OpenConnection();
        }


        [AttrLuaFunc("NetClientConnected", "Returns if a client is connected to the RT3 net server listening on default port")]
        public bool NetClientConnected()
        {
            return this.iNetClientConnected(RstdNetConsts.DEFAULT_PORT);
        }


        [AttrLuaFunc("NetClientConnected_Port", "Returns if a client is connected to the RT3 net server listening on provided port", new string[]
        {
            "port server is listening on"
        })]
        public bool NetClientConnected_Port(int port)
        {
            return this.iNetClientConnected(port);
        }


        private bool iNetClientConnected(int port)
        {
            RstdServer server = this.m_frmMain.GetServer(port);
            if (server == null)
            {
                this.m_frmMain.ErrorPrint(string.Format("IsConnected: Not listening on port {0}\n", port));
                return false;
            }
            return server.IsConnected();
        }


        [AttrLuaFunc("NetReset", "Reset the RT3 Default Net Server")]
        public void NetReset()
        {
            this.iNetReset(RstdNetConsts.DEFAULT_PORT);
        }


        [AttrLuaFunc("NetReset_Port", "Reset an RT3 Net Server", new string[]
        {
            "port server is listening on"
        })]
        public void NetReset_Port(int port)
        {
            this.iNetReset(port);
        }


        private void iNetReset(int port)
        {
            RstdServer server = this.m_frmMain.GetServer(port);
            if (server == null)
            {
                this.m_frmMain.ErrorPrint(string.Format("NetReset: Not listening on port {0}\n", port));
                return;
            }
            server.ResetConnection();
        }


        [AttrLuaFunc("NetClose", "Close the RT3 Default Net Server")]
        public int NetClose()
        {
            return this.iNetClose(RstdNetConsts.DEFAULT_PORT);
        }


        [AttrLuaFunc("NetClose_Port", "Close an RT3 Net Server", new string[]
        {
            "port server is listening on"
        })]
        public int NetClose_Port(int port)
        {
            return this.iNetClose(port);
        }


        public int iNetClose(int port)
        {
            RstdServer server = this.m_frmMain.GetServer(port);
            if (server == null)
            {
                this.m_frmMain.ErrorPrint(string.Format("NetClose: Not listening on port {0}\n", port));
                return -1;
            }
            int result = server.Close();
            Thread.Sleep(10);
            this.m_frmMain.RemoveServer(server.Port);
            return result;
        }


        [AttrLuaFunc("NetCloseAll", "Close all RT3 Net Servers")]
        public void NetCloseAll()
        {
            foreach (RstdServer rstdServer in this.m_frmMain.Servers)
            {
                rstdServer.Close();
            }
            Thread.Sleep(10);
            this.m_frmMain.Servers.Clear();
        }


        [AttrLuaFunc("NetSyncTimout", "Set the sync timeout between several clients", new string[]
        {
            "the sync timeout (ms)"
        })]
        public void NetSyncTimout(int timeout)
        {
            RstdServer.SyncTimeout = timeout;
        }


        [AttrLuaFunc("TimerStart", "Start the timer which will trigger when the time has elapsed, stopping the current script and running the provided script.", new string[]
        {
            "time in seconds",
            "script to run when timeout"
        })]
        public void TimerStart(int time, string script)
        {
            if (!File.Exists(script))
            {
                GuiCore.RstdException("TimerStart: script path not found. \n", "");
            }
            if (time < 0)
            {
                GuiCore.RstdException("TimerStart: time cannot be negative. \n", "");
                return;
            }
            this.m_Timer.TimerStart(time, script);
        }


        [AttrLuaFunc("TimerEnd", "Stop the timer, aborting it")]
        public void TimerEnd()
        {
            this.m_Timer.TimerEnd();
        }


        [AttrLuaFunc("TimerResetCount", "Reset count of the timer triggers")]
        public void TimerResetCount()
        {
            this.m_Timer.TimeoutCount = 0;
        }


        [AttrLuaFunc("TimerGetCount", "Get the number of times the timer has triggered")]
        public int TimerGetCount()
        {
            return this.m_Timer.TimeoutCount;
        }


        private frmMain m_frmMain;


        private frmYesNoTimerMsgBox myYesNoTimerMsgBox;


        private RemoteManager m_RemoteManager;


        private TimerManager m_Timer;
    }
}
