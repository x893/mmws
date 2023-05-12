using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RstdXml;

namespace RSTD
{

    internal class RstdXmlTreeWrapper
    {

        public string GetOuterXmlTree()
        {
            return this.m_XmlTree.OuterXml;
        }




        public XmlDocument XmlTree
        {
            get
            {
                return this.m_XmlTree;
            }
            set
            {
                this.m_XmlTree = value;
            }
        }



        public XmlNode XmlTreeRoot
        {
            get
            {
                return this.iGetTreeRoot(this.m_XmlTree);
            }
        }




        public BidirHashtable<XmlNode, XmlNode> RegisterMapping
        {
            get
            {
                return this.m_RegisterMapping;
            }
            set
            {
                this.m_RegisterMapping = value;
            }
        }


        private RstdXmlTreeWrapper()
        {
        }


        public RstdXmlTreeWrapper(string xml_tree_str, ConsolePrint dConsolePrint)
        {
            this.m_XmlTree = new XmlDocument();
            this.m_XmlTree.LoadXml(xml_tree_str);
            this.m_XmlParser = new RstdXmlParser(dConsolePrint);
        }


        public void Load(string tree_str)
        {
            this.m_XmlTree.LoadXml(tree_str);
        }


        public void AppendGuiAttributesToXmlTree()
        {
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            this.iAppendGuiAttributesWithinNode_Recursive(ref xmlNode);
        }


        public void RemoveGuiAttributes(ref XmlDocument doc)
        {
            XmlNode node = this.iGetTreeRoot(doc);
            this.iRemoveGuiAttribute_Rec(node);
        }


        public bool ChangeValuesToHex(ref XmlDocument save_doc)
        {
            XmlNode xml_node = this.iGetTreeRoot(save_doc);
            return this.iChangeValuesToHex_Recursive(xml_node);
        }


        public void SetAllNodesUpdateStatus(bool status)
        {
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            this.iReplaceAttributeValuesWithinNode_Recursive(ref xmlNode, "is_updated", status.ToString());
            GuiCore.RefreshGui();
        }


        public void MergeToMainXmlTree(XmlNode new_tree)
        {
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            this.iMergeToMainXmlTree_Recursive(this.m_XmlTree, new_tree, ref xmlNode);
        }


        public void MergeToMainXmlTree(XmlDocument doc, XmlNode new_tree)
        {
            XmlNode xmlNode = this.iGetTreeRoot(doc);
            this.iMergeToMainXmlTree_Recursive(doc, new_tree, ref xmlNode);
        }


        public void ReplaceAttributeValuesWithinNode_Recursive(XmlNode xmlNode, string attribName, string attribValue)
        {
            this.iReplaceAttributeValuesWithinNode_Recursive(ref xmlNode, attribName, attribValue);
        }


        public bool CheckIfAllSetVarsTransmitted()
        {
            bool flag = false;
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            this.iCheckIfSetButNotTransmitted_Rec(ref xmlNode, ref flag);
            if (flag)
            {
                GuiCore.AlwaysPrint(0U, 2U, "WARNING:\nGo(): Not all Vars Set have been Transmitted !\n");
            }
            return flag;
        }


        public bool ReplaceVarsAttribute(List<XmlNode> nodes, string attribName, string attribValue)
        {
            foreach (XmlNode var_node in nodes)
            {
                if (!this.ibReplaceVarAttrib(var_node, attribName, attribValue))
                {
                    return false;
                }
            }
            return true;
        }


        public void GetNodesWithAttribute(string attrib_name, ref List<XmlNode> node_list)
        {
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            this.iGetNodesWithAttribute_Recursive(ref xmlNode, attrib_name, ref node_list);
        }


        public bool CheckTabsDuplicate(XmlNode exposed_root)
        {
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                string nodeAttribute = this.m_XmlParser.GetNodeAttribute(xmlNode.ChildNodes[i], "name");
                for (int j = 0; j < exposed_root.ChildNodes.Count; j++)
                {
                    string nodeAttribute2 = this.m_XmlParser.GetNodeAttribute(exposed_root.ChildNodes[j], "name");
                    if (nodeAttribute.ToUpper() == nodeAttribute2.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool ExposeXml(XmlNode exposed_root, out string err_msg, Dictionary<string, string> version_pool, int size)
        {
            StringBuilder stringBuilder = new StringBuilder(size);
            err_msg = "";
            XmlNode documentElement = this.m_XmlTree.DocumentElement;
            if (!CoreImports.bExposeLoadedXml(stringBuilder))
            {
                return false;
            }
            if (!this.ibValidateXml(stringBuilder, out err_msg))
            {
                return false;
            }
            this.AppendGuiAttributesToXmlTree();
            this.iAppendExtUpdateAttribToTree(documentElement);
            this.iAppendExtUpdateAttribToTree(exposed_root);
            this.CalcRegs();
            this.iEmptyVersionPull(version_pool);
            return true;
        }


        public void CalcRegs()
        {
            if (this.bNodeContainsRegisters(this.m_XmlTree.SelectSingleNode("/TreeRoot")))
            {
                this.iCalcAllRegisterValues();
                this.iGetRegisterMapping();
            }
        }


        public bool bNodeContainsRegisters(XmlNode node)
        {
            return ((XmlElement)node).GetElementsByTagName("Register").Count > 0;
        }


        public void InsertValuesForMappedVars(ref XmlDocument doc)
        {
            XmlNode xmlNode = this.iGetTreeRoot(doc);
            this.iInsertValuesForMappedVars_Recursive(ref xmlNode, ref doc);
        }


        public void AddMappedFields(List<XmlNode> nodes)
        {
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                foreach (object obj in this.iGetMappedVars(nodes[i]))
                {
                    XmlNode key = (XmlNode)obj;
                    XmlNode item = this.m_RegisterMapping[key];
                    nodes.Add(item);
                }
            }
        }


        public bool CalcRegisterValue(XmlNode reg_node)
        {
            char[] array = new char[32];
            if (reg_node.FirstChild.Value == null)
            {
                return true;
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = '0';
            }
            for (int i = 1; i < reg_node.ChildNodes.Count; i++)
            {
                XmlNode xmlNode = reg_node.ChildNodes[i];
                XmlNode xmlNode2 = xmlNode.ChildNodes[1];
                int num = int.Parse(xmlNode2.Attributes["start_bit"].Value);
                int num2 = int.Parse(xmlNode2.Attributes["n_bits"].Value);
                string nodeValue = GuiCore.GetNodeValue(xmlNode);
                string fieldBinaryValue = this.GetFieldBinaryValue(xmlNode, ref nodeValue);
                if (fieldBinaryValue == null)
                {
                    return false;
                }
                fieldBinaryValue.CopyTo(0, array, array.Length - num - num2, num2);
            }
            string value = Convert.ToInt64(new string(array), 2).ToString();
            reg_node.FirstChild.Value = value;
            if (frmMain.gGui_updated_mode == GUI_REGISTER_UPDATED_MODE.ON_FIELDS_UPDATE)
            {
                reg_node.Attributes["is_updated"].Value = this.bAreAllRegisterFieldsUpdated(reg_node).ToString();
            }
            return true;
        }


        public bool bAreAllRegisterFieldsUpdated(XmlNode reg_node)
        {
            bool result = true;
            for (int i = 1; i < reg_node.ChildNodes.Count; i++)
            {
                if (!bool.Parse(reg_node.ChildNodes[i].Attributes["is_updated"].Value))
                {
                    return false;
                }
            }
            return result;
        }


        public string GetFieldBinaryValue(XmlNode field_node, ref string val_to_convert)
        {
            long num = 0L;
            long num2 = 0L;
            double num3 = 0.0;
            XmlNode xmlNode = field_node.ChildNodes[1];
            if (field_node.Attributes["type"].Value == "FIX")
            {
                if (field_node.Attributes["fixmode"] != null)
                {
                    double value = double.Parse(val_to_convert);
                    string value2 = field_node.Attributes["fixmode"].Value;
                    if (!GuiCore.GetBitPattern(value, value2, ref num3, ref num2))
                    {
                        return null;
                    }
                    num = num2;
                    val_to_convert = num3.ToString("R");
                }
                else
                {
                    GuiCore.ErrorMessage(string.Format("field {0} has no fixmode set", xmlNode.Attributes["field_name"].Value));
                }
            }
            else if (!long.TryParse(val_to_convert, out num))
            {
                GuiCore.ErrorMessage(string.Format("Value \"{0}\" not valid for field \"{1}\"\n", val_to_convert, xmlNode.Attributes["field_name"].Value));
                return null;
            }
            int.Parse(xmlNode.Attributes["start_bit"].Value);
            int num4 = int.Parse(xmlNode.Attributes["n_bits"].Value);
            string text = Convert.ToString(num, 2);
            bool flag;
            if (num < 0L)
            {
                flag = (num4 != 1 && (double)num >= Math.Pow(2.0, (double)(num4 - 1)) * -1.0);
                text = text.Remove(0, text.Length - num4);
            }
            else
            {
                flag = ((double)num < Math.Pow(2.0, (double)num4));
            }
            if (!flag)
            {
                GuiCore.ErrorMessage(string.Format("The value of field \"{0}\" (in register \"{1}\") is greater than the number of bits in the field ({2}) !\n", xmlNode.Attributes["field_name"].Value, field_node.ParentNode.Attributes["name"].Value, xmlNode.Attributes["n_bits"].Value));
                return null;
            }
            return text.PadLeft(num4, '0');
        }


        public bool CreateExportDescFromXml(XmlNode newTree)
        {
            return this.iCreateExportDescFromXml_Recursive(newTree);
        }


        public bool bGetVarInNode(string var_name, XmlNode xmlFolder, out XmlNode xmlVar)
        {
            string value = var_name.ToUpper();
            if (xmlFolder.Name.Equals("Function"))
            {
                xmlFolder = xmlFolder.SelectSingleNode("ArgumentList");
            }
            if (xmlFolder.Name.Equals("Register"))
            {
                for (int i = 1; i < xmlFolder.ChildNodes.Count; i++)
                {
                    XmlNode xmlNode = xmlFolder.ChildNodes[i].ChildNodes[1];
                    if (xmlFolder.ChildNodes[i].Name.Equals("Var") && xmlNode.Attributes["field_name"].Value.ToUpper().Equals(value))
                    {
                        xmlVar = xmlFolder.ChildNodes[i];
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < xmlFolder.ChildNodes.Count; i++)
                {
                    if ((xmlFolder.ChildNodes[i].Name.Equals("Var") || xmlFolder.ChildNodes[i].Name.Equals("Register")) && xmlFolder.ChildNodes[i].Attributes["name"].Value.ToUpper().Equals(value))
                    {
                        xmlVar = xmlFolder.ChildNodes[i];
                        return true;
                    }
                }
            }
            xmlVar = null;
            return false;
        }


        public bool IsPathInTree(string path)
        {
            XmlNode xmlNode;
            return this.m_XmlParser.GetFolderOrVar(path, out xmlNode, this.m_XmlTree);
        }


        public void RemoveFunctionPointers(ref XmlDocument doc)
        {
            XmlNode node = this.iGetTreeRoot(doc);
            this.iRemoveFunctionPointers_Rec(node);
        }


        public bool bGetVarOptions(XmlNode node, out string[] options_arr)
        {
            if (!string.IsNullOrEmpty(node.Attributes["options"].Value))
            {
                string value = node.Attributes["options"].Value;
                options_arr = value.Split(new char[]
                {
                    ','
                }, StringSplitOptions.RemoveEmptyEntries);
                return true;
            }
            options_arr = null;
            return false;
        }


        private XmlNode iGetTreeRoot(XmlDocument doc)
        {
            return doc.SelectSingleNode("TreeRoot");
        }


        private void iRemoveFunctionPointers_Rec(XmlNode node)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (GuiCore.GetNodeType(node.ChildNodes[i]) == NodeType.VAR && node.ChildNodes[i].Attributes["type"] != null && node.ChildNodes[i].Attributes["type"].Value == "THIS")
                {
                    node.RemoveChild(node.ChildNodes[i]);
                    i--;
                }
                else
                {
                    this.iRemoveFunctionPointers_Rec(node.ChildNodes[i]);
                }
            }
        }


        private bool iChangeValuesToHex_Recursive(XmlNode xml_node)
        {
            NodeType nodeType = GuiCore.GetNodeType(xml_node);
            if (nodeType - NodeType.ROOT > 2)
            {
                if (nodeType != NodeType.REGISTER)
                {
                    if (nodeType != NodeType.FIELD)
                        return true;
                }
                else
                {
                    if (xml_node.FirstChild.Name == "#text")
                    {
                        xml_node.FirstChild.Value = GuiCore.GetSingleValueDisplay(xml_node, DisplayType.HEX, xml_node.FirstChild.Value);
                        xml_node.Attributes["display_type"].Value = "Hex";
                    }
                    foreach (XmlNode xml_node2 in xml_node)
                    {
                        if (!this.iChangeValuesToHex_Recursive(xml_node2))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {

                foreach (XmlNode xml_node3 in xml_node)
                {
                    if (!this.iChangeValuesToHex_Recursive(xml_node3))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (xml_node.FirstChild.Name != "#text")
            {
                return false;
            }
            xml_node.FirstChild.Value = GuiCore.GetSingleValueDisplay(xml_node, DisplayType.HEX, xml_node.FirstChild.Value);
            xml_node.Attributes["display_type"].Value = "Hex";
            return true;
        }


        private void iRemoveGuiAttribute_Rec(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                node.Attributes.RemoveNamedItem("is_updated");
                node.Attributes.RemoveNamedItem("is_auto_updated");
                node.Attributes.RemoveNamedItem("is_monitored");
            }
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                this.iRemoveGuiAttribute_Rec(node.ChildNodes[i]);
            }
        }


        private void iAppendGuiAttributesWithinNode_Recursive(ref XmlNode xmlNode)
        {
            if (GuiCore.GetNodeType(xmlNode) == NodeType.REGISTER)
            {
                this.iAppendGuiAttributesToNode(xmlNode);
            }
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode xmlNode2 = xmlNode.ChildNodes[i];
                if (xmlNode2.Name.Equals("Var"))
                {
                    this.iAppendGuiAttributesToNode(xmlNode2);
                }
                else
                {
                    this.iAppendGuiAttributesWithinNode_Recursive(ref xmlNode2);
                }
            }
        }


        private void iAppendGuiAttributesToNode(XmlNode node)
        {
            XmlAttribute xmlAttribute = node.OwnerDocument.CreateAttribute("is_updated");
            XmlAttribute xmlAttribute2 = node.OwnerDocument.CreateAttribute("is_auto_updated");
            XmlAttribute xmlAttribute3 = node.OwnerDocument.CreateAttribute("is_monitored");
            XmlAttribute xmlAttribute4 = node.OwnerDocument.CreateAttribute("display_type");
            NodeType nodeType = GuiCore.GetNodeType(node);
            DisplayType displayType;
            if (nodeType != NodeType.REGISTER)
            {
                if (nodeType != NodeType.MAPPED_VAR)
                {
                    if (nodeType != NodeType.FIELD)
                    {
                        displayType = DisplayType.DEFAULT;
                        xmlAttribute.Value = "true";
                    }
                    else
                    {
                        displayType = DisplayType.DEFAULT;
                        xmlAttribute.Value = "false";
                    }
                }
                else
                {
                    displayType = DisplayType.DEFAULT;
                    xmlAttribute.Value = "false";
                    XmlAttribute xmlAttribute5 = node.Attributes["comment"];
                    xmlAttribute5.Value += this.m_XmlParser.GetHwInfoString(node);
                }
            }
            else
            {
                displayType = DisplayType.DEFAULT;
                xmlAttribute.Value = "false";
            }
            xmlAttribute3.Value = "false";
            xmlAttribute2.Value = "false";
            xmlAttribute4.Value = Enum.Format(typeof(DisplayType), displayType, "g").ToLower();
            if (node.Attributes.GetNamedItem("is_updated") == null)
            {
                node.Attributes.Append(xmlAttribute);
            }
            if (node.Attributes.GetNamedItem("is_auto_updated") == null)
            {
                node.Attributes.Append(xmlAttribute2);
            }
            if (node.Attributes.GetNamedItem("is_monitored") == null)
            {
                node.Attributes.Append(xmlAttribute3);
            }
            if (node.Attributes.GetNamedItem("display_type") == null)
            {
                node.Attributes.Append(xmlAttribute4);
            }
        }


        private void iReplaceAttributeValuesWithinNode_Recursive(ref XmlNode xmlNode, string attribName, string attribValue)
        {
            if (xmlNode.Name.Equals("Var"))
            {
                if (GuiCore.GetNodeType(xmlNode) == NodeType.MAPPED_VAR)
                {
                    xmlNode = this.m_RegisterMapping[xmlNode];
                }
                xmlNode.Attributes[attribName].Value = attribValue;
                return;
            }
            if (xmlNode.Name.Equals("Register"))
            {
                xmlNode.Attributes[attribName].Value = attribValue;
                for (int i = 1; i < xmlNode.ChildNodes.Count; i++)
                {
                    XmlNode xmlNode2 = xmlNode.ChildNodes[i];
                    this.iReplaceAttributeValuesWithinNode_Recursive(ref xmlNode2, attribName, attribValue);
                }
                return;
            }
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode xmlNode3 = xmlNode.ChildNodes[i];
                this.iReplaceAttributeValuesWithinNode_Recursive(ref xmlNode3, attribName, attribValue);
            }
        }


        private void iMergeToMainXmlTree_Recursive(XmlDocument doc_src, XmlNode partialTree, ref XmlNode partialSrcTree)
        {
            int i;
            if (GuiCore.GetNodeType(partialTree) == NodeType.REGISTER && partialTree.ChildNodes[0].Name == "#text")
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            while (i < partialTree.ChildNodes.Count)
            {
                string text;
                XmlNode xmlNode = this.iGetSameChild(partialTree.ChildNodes[i], partialSrcTree, out text);
                if (xmlNode == null)
                {
                    string pathFromNode = GuiCore.GetPathFromNode(partialTree.ChildNodes[i]);
                    string str = "XML: Ignoring node: \"" + partialTree.ChildNodes[i].Name + "\"";
                    if (partialTree.ChildNodes[i].Name.Equals("Var") || partialTree.ChildNodes[i].Name.Equals("Folder") || partialTree.ChildNodes[i].Name.Equals("Function") || partialTree.ChildNodes[i].Name.Equals("Tab"))
                    {
                        str = str + "- name=\"" + pathFromNode + "\"";
                    }
                    if (text != "")
                    {
                        str = str + "for the following reason: " + text;
                    }
                    GuiCore.AlwaysPrint(str + "\n");
                }
                else if (GuiCore.GetNodeType(partialTree.ChildNodes[i]) == NodeType.VAR || GuiCore.GetNodeType(partialTree.ChildNodes[i]) == NodeType.FIELD)
                {
                    if (xmlNode.FirstChild != null && partialTree.ChildNodes[i].FirstChild != null)
                    {
                        if (GuiCore.GetNodeType(partialTree.ChildNodes[i]) == NodeType.FIELD && partialTree.ChildNodes[i].FirstChild.Value.StartsWith("0x"))
                        {
                            GuiCore.bSetLoadedValue(xmlNode, partialTree.ChildNodes[i].FirstChild.Value);
                        }
                        else
                        {
                            xmlNode.FirstChild.Value = partialTree.ChildNodes[i].FirstChild.Value;
                        }
                    }
                    else
                    {
                        xmlNode.InnerText = GuiCore.GetNodeValue(partialTree.ChildNodes[i]);
                    }
                    this.iMergeAttribute(xmlNode, partialTree.ChildNodes[i], "fixmode");
                    this.iMergeAttribute(xmlNode, partialTree.ChildNodes[i], "display_type");
                    this.iMergeAttribute(xmlNode, partialTree.ChildNodes[i], "comment");
                    xmlNode.Attributes["is_updated"].Value = false.ToString();
                    this.iMergeHwInfo(doc_src, partialTree.ChildNodes[i], xmlNode);
                }
                else if (GuiCore.GetNodeType(partialTree.ChildNodes[i]) == NodeType.MAPPED_VAR)
                {
                    xmlNode.Attributes["is_updated"].Value = false.ToString();
                    this.iMergeHwInfo(doc_src, partialTree.ChildNodes[i], xmlNode);
                    if (partialTree.ChildNodes[i].FirstChild.Name == "#text")
                    {
                        this.m_RegisterMapping[xmlNode].FirstChild.Value = partialTree.ChildNodes[i].FirstChild.Value;
                    }
                }
                else if (GuiCore.GetNodeType(partialTree.ChildNodes[i]) == NodeType.REGISTER && partialTree.ChildNodes[i].FirstChild.Value != null)
                {
                    if (partialTree.ChildNodes[i].FirstChild.Value.StartsWith("0x"))
                    {
                        GuiCore.bSetLoadedValue(xmlNode, partialTree.ChildNodes[i].FirstChild.Value);
                    }
                    else
                    {
                        xmlNode.FirstChild.Value = partialTree.ChildNodes[i].FirstChild.Value;
                    }
                    this.iMergeAttribute(xmlNode, partialTree.ChildNodes[i], "display_type");
                    this.iMergeAttribute(xmlNode, partialTree.ChildNodes[i], "comment");
                    xmlNode.Attributes["is_updated"].Value = false.ToString();
                    this.iMergeHwInfo(doc_src, partialTree.ChildNodes[i], xmlNode);
                    this.iMergeToMainXmlTree_Recursive(doc_src, partialTree.ChildNodes[i], ref xmlNode);
                }
                else
                {
                    this.iMergeToMainXmlTree_Recursive(doc_src, partialTree.ChildNodes[i], ref xmlNode);
                }
                i++;
            }
        }


        private XmlNode iGetSameChild(XmlNode targetNode, XmlNode parentNode, out string variable_not_found_reason)
        {
            bool flag = false;
            bool flag2 = false;
            variable_not_found_reason = "";
            for (int i = 0; i < parentNode.ChildNodes.Count; i++)
            {
                if (targetNode.Name == parentNode.ChildNodes[i].Name && (targetNode.Name.Equals("ArgumentList") || targetNode.Name.Equals("ReturnList") || targetNode.Attributes.GetNamedItem("name").Value == parentNode.ChildNodes[i].Attributes.GetNamedItem("name").Value))
                {
                    flag = true;
                    if (targetNode.Name == "Var" && targetNode.Attributes.GetNamedItem("type").Value == parentNode.ChildNodes[i].Attributes.GetNamedItem("type").Value)
                    {
                        return parentNode.ChildNodes[i];
                    }
                    if (targetNode.Name != "Var")
                    {
                        return parentNode.ChildNodes[i];
                    }
                }
            }
            if (!flag)
            {
                variable_not_found_reason = targetNode.Name + " doesn't exist";
            }
            else if (!flag2)
            {
                variable_not_found_reason = string.Format("The {0} type doesn't match", targetNode.Name);
            }
            else
            {
                variable_not_found_reason = "Unknown reason";
            }
            return null;
        }


        private void iMergeAttribute(XmlNode tree_node, XmlNode file_node, string attrib_name)
        {
            if (tree_node.Attributes[attrib_name] != null && file_node.Attributes[attrib_name] != null)
            {
                tree_node.Attributes[attrib_name].Value = file_node.Attributes[attrib_name].Value;
            }
        }


        private void iMergeHwInfo(XmlDocument doc_src, XmlNode new_var_node, XmlNode old_var_node)
        {
            int hwInfoIndex = this.m_XmlParser.GetHwInfoIndex(new_var_node);
            if (hwInfoIndex != -1)
            {
                XmlNode newChild = doc_src.ImportNode(new_var_node.ChildNodes[hwInfoIndex], true);
                int hwInfoIndex2 = this.m_XmlParser.GetHwInfoIndex(old_var_node);
                if (hwInfoIndex2 != -1)
                {
                    old_var_node.ReplaceChild(newChild, old_var_node.ChildNodes[hwInfoIndex2]);
                    return;
                }
                old_var_node.AppendChild(newChild);
            }
        }


        private bool iCheckIfTabExists(string tab_name)
        {
            XmlNode xmlNode = this.iGetTreeRoot(this.m_XmlTree);
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (this.m_XmlParser.GetNodeAttribute(xmlNode.ChildNodes[i], "name").ToUpper() == tab_name.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }


        private void iCheckIfSetButNotTransmitted_Rec(ref XmlNode xmlNode, ref bool bHasVarNotTransmitted)
        {
            if (bHasVarNotTransmitted)
            {
                return;
            }
            int num = 0;
            while (num < xmlNode.ChildNodes.Count && !bHasVarNotTransmitted)
            {
                XmlNode xmlNode2 = xmlNode.ChildNodes[num];
                if (xmlNode2.Name.Equals("Var"))
                {
                    if (xmlNode2.Attributes.GetNamedItem("is_updated").Value.ToString().Equals(false.ToString()))
                    {
                        bHasVarNotTransmitted = true;
                    }
                }
                else
                {
                    this.iCheckIfSetButNotTransmitted_Rec(ref xmlNode2, ref bHasVarNotTransmitted);
                }
                num++;
            }
        }


        private bool ibReplaceVarAttrib(XmlNode var_node, string attribName, string attribValue)
        {
            if (GuiCore.GetNodeType(var_node) == NodeType.MAPPED_VAR)
            {
                var_node = this.m_RegisterMapping[var_node];
            }
            var_node.Attributes[attribName].Value = attribValue;
            return true;
        }


        private void iGetNodesWithAttribute_Recursive(ref XmlNode node, string attrib_name, ref List<XmlNode> node_list)
        {
            if (GuiCore.GetNodeType(node) > NodeType.VALUE_TYPE_START && GuiCore.GetNodeType(node) < NodeType.VALUE_TYPE_END)
            {
                if (GuiCore.GetNodeType(node) == NodeType.MAPPED_VAR && this.m_RegisterMapping != null && this.m_RegisterMapping.ContainsKey(node))
                {
                    node = this.m_RegisterMapping[node];
                }
                string nodeAttribute = this.m_XmlParser.GetNodeAttribute(node, attrib_name);
                if (!string.IsNullOrEmpty(nodeAttribute) && bool.Parse(nodeAttribute))
                {
                    node_list.Add(node);
                }
                if (GuiCore.GetNodeType(node) == NodeType.REGISTER)
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        XmlNode xmlNode = node.ChildNodes[i];
                        this.iGetNodesWithAttribute_Recursive(ref xmlNode, attrib_name, ref node_list);
                    }
                    return;
                }
            }
            else
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    XmlNode xmlNode = node.ChildNodes[i];
                    this.iGetNodesWithAttribute_Recursive(ref xmlNode, attrib_name, ref node_list);
                }
            }
        }


        private void iAppendExtUpdateAttribToTree(XmlNode exposed_root)
        {
            XmlNode documentElement = this.m_XmlTree.DocumentElement;
            foreach (object obj in exposed_root.ChildNodes)
            {
                XmlNode node = (XmlNode)obj;
                string nodeAttribute = GuiCore.GetNodeAttribute(node, "update_type");
                if (nodeAttribute != null && nodeAttribute == "ext")
                {
                    string nodeAttribute2 = GuiCore.GetNodeAttribute(node, "name");
                    foreach (object obj2 in documentElement.ChildNodes)
                    {
                        XmlNode xmlNode = (XmlNode)obj2;
                        if (GuiCore.GetNodeAttribute(xmlNode, "name") == nodeAttribute2)
                        {
                            XmlAttribute xmlAttribute = this.m_XmlTree.CreateAttribute("update_type");
                            xmlAttribute.Value = "ext";
                            xmlNode.Attributes.Append(xmlAttribute);
                        }
                    }
                }
            }
        }


        private bool ibValidateXml(StringBuilder tree_sb, out string err_msg)
        {
            bool result;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(tree_sb.ToString());
                this.m_XmlTree = xmlDocument;
                err_msg = "";
                result = true;
            }
            catch (XmlException ex)
            {
                err_msg = ex.Message;
                result = false;
            }
            return result;
        }


        private void iCalcAllRegisterValues()
        {
            foreach (object obj in this.m_XmlTree.GetElementsByTagName("Register"))
            {
                XmlNode reg_node = (XmlNode)obj;
                this.CalcRegisterValue(reg_node);
            }
        }


        private void iGetRegisterMapping()
        {
            this.m_RegisterMapping = new BidirHashtable<XmlNode, XmlNode>();
            XmlNodeList xmlNodeList = this.iGetMappedVars(this.m_XmlTree);
            XmlNodeList field_list = this.iGetFields(this.m_XmlTree);
            foreach (object obj in xmlNodeList)
            {
                XmlNode xmlNode = (XmlNode)obj;
                XmlNode xmlNode2 = this.iGetMappedFieldFromList(field_list, xmlNode);
                if (xmlNode2 == null)
                {
                    int hwInfoIndex = this.m_XmlParser.GetHwInfoIndex(xmlNode);
                    GuiCore.ErrorMessage(string.Format("Coulnd't find field {0} mapped to varibale {1}\n", xmlNode.ChildNodes[hwInfoIndex].Attributes["field_name"].Value, xmlNode.Attributes["name"].Value));
                }
                else
                {
                    this.m_RegisterMapping.Add(xmlNode, xmlNode2);
                }
            }
        }


        private void iEmptyVersionPull(Dictionary<string, string> version_pool)
        {
            string text = "";
            foreach (object obj in this.m_XmlTree.DocumentElement.ChildNodes)
            {
                XmlNode xmlNode = (XmlNode)obj;
                foreach (string text2 in version_pool.Keys)
                {
                    this.m_XmlParser.GetNodeAttribute(xmlNode, "name", ref text);
                    if (text.Trim() == text2.Trim() && xmlNode.Attributes.GetNamedItem("version") == null)
                    {
                        XmlAttribute xmlAttribute = xmlNode.OwnerDocument.CreateAttribute("version");
                        xmlAttribute.Value = version_pool[text2];
                        xmlNode.Attributes.Append(xmlAttribute);
                    }
                }
            }
        }


        private void iInsertValuesForMappedVars_Recursive(ref XmlNode node, ref XmlDocument doc)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode xmlNode = node.ChildNodes[i];
                NodeType nodeType = GuiCore.GetNodeType(xmlNode);
                if (nodeType == NodeType.MAPPED_VAR && xmlNode.FirstChild != null)
                {
                    XmlNode xmlNode2 = this.iGetMappedVarByPath(GuiCore.GetPathFromNode(xmlNode));
                    if (xmlNode2 != null)
                    {
                        XmlText newChild = doc.CreateTextNode(this.m_RegisterMapping[xmlNode2].FirstChild.Value);
                        xmlNode.InsertBefore(newChild, xmlNode.FirstChild);
                    }
                }
                else if (nodeType == NodeType.FOLDER || nodeType == NodeType.TAB)
                {
                    this.iInsertValuesForMappedVars_Recursive(ref xmlNode, ref doc);
                }
            }
        }


        private XmlNode iGetMappedVarByPath(string node_path)
        {
            foreach (XmlNode xmlNode in this.m_RegisterMapping.Keys)
            {
                if (GuiCore.GetPathFromNode(xmlNode) == node_path)
                {
                    return xmlNode;
                }
            }
            return null;
        }


        private XmlNode iGetMappedFieldFromList(XmlNodeList field_list, XmlNode mapped_var)
        {
            int hwInfoIndex = this.m_XmlParser.GetHwInfoIndex(mapped_var);
            string b = mapped_var.ChildNodes[hwInfoIndex].Attributes["field_name"].Value.ToUpper();
            string b2 = mapped_var.ChildNodes[hwInfoIndex].Attributes["register_name"].Value.ToUpper();
            foreach (object obj in field_list)
            {
                XmlNode xmlNode = (XmlNode)obj;
                int hwInfoIndex2 = this.m_XmlParser.GetHwInfoIndex(xmlNode);
                if (xmlNode.ChildNodes[hwInfoIndex2].Attributes["field_name"].Value.ToUpper() == b && xmlNode.ChildNodes[hwInfoIndex2].Attributes["register_name"].Value.ToUpper() == b2)
                {
                    return xmlNode;
                }
            }
            return null;
        }


        private XmlNodeList iGetFields(XmlNode node)
        {
            string xpath = "descendant-or-self::Var[parent::Register]";
            return node.SelectNodes(xpath);
        }


        private XmlNodeList iGetMappedVars(XmlNode node)
        {
            string xpath = "descendant-or-self::Var[child::hw_info and parent::Folder]";
            return node.SelectNodes(xpath);
        }


        private bool iCreateExportDescFromXml_Recursive(XmlNode xml_node)
        {
            string name = xml_node.Name;
            if (name == "TreeRoot")
            {
                return this.iExportTree(xml_node);
            }
            if (name == "Tab")
            {
                return this.iExportTab(xml_node);
            }
            if (name == "Folder")
            {
                return this.iExportFolder(xml_node);
            }
            if (!(name == "Register"))
            {
                return name == "Var" && this.iExportField(xml_node);
            }
            return this.iExportRegister(xml_node);
        }


        private bool iExportTree(XmlNode tree_node)
        {
            foreach (object obj in tree_node)
            {
                XmlNode xml_node = (XmlNode)obj;
                if (!this.iCreateExportDescFromXml_Recursive(xml_node))
                {
                    return false;
                }
            }
            return true;
        }


        private bool iExportTab(XmlNode tab_node)
        {
            string tabName = null;
            if (tab_node.ParentNode.Name != "TreeRoot")
            {
                return false;
            }
            if (!this.m_XmlParser.GetNodeAttribute(tab_node, "name", ref tabName))
            {
                return false;
            }
            CoreImports.TabStart(tabName);
            foreach (object obj in tab_node)
            {
                XmlNode xml_node = (XmlNode)obj;
                if (!this.iCreateExportDescFromXml_Recursive(xml_node))
                {
                    return false;
                }
            }
            CoreImports.TabEnd();
            return true;
        }


        private bool iExportFolder(XmlNode folder_node)
        {
            string text = null;
            string text2 = null;
            if (folder_node.ParentNode.Name != "Tab" && folder_node.ParentNode.Name != "Folder")
            {
                return false;
            }
            if (!this.m_XmlParser.GetNodeAttribute(folder_node, "name", ref text))
            {
                return false;
            }
            this.m_XmlParser.GetNodeAttribute(folder_node, "comment", ref text2);
            string folderName;
            if (string.IsNullOrEmpty(text2))
            {
                folderName = text;
            }
            else
            {
                folderName = text + "//" + text2;
            }
            CoreImports.FolderStart(folderName);
            foreach (object obj in folder_node)
            {
                XmlNode xml_node = (XmlNode)obj;
                if (!this.iCreateExportDescFromXml_Recursive(xml_node))
                {
                    return false;
                }
            }
            CoreImports.FolderEnd();
            return true;
        }


        private bool iExportRegister(XmlNode register_node)
        {
            string pDescription = null;
            string register_address = null;
            int register_type = 0;
            int n_bits = 0;
            uint default_val = 0U;
            int export_mode = 0;
            string description = "";
            if (register_node.ParentNode.Name != "Folder")
            {
                return false;
            }
            if (this.m_XmlParser.GetRegAttributes(register_node, ref pDescription, ref register_address, ref register_type, ref n_bits, ref default_val, ref description, ref export_mode))
            {
                CoreImports.RegisterStart(pDescription, IntPtr.Zero, register_address, register_type, n_bits, default_val, description, export_mode);
                foreach (object obj in register_node)
                {
                    XmlNode xmlNode = (XmlNode)obj;
                    if (xmlNode.Name != "#text" && !this.iCreateExportDescFromXml_Recursive(xmlNode))
                    {
                        return false;
                    }
                }
                CoreImports.RegisterEnd();
                return true;
            }
            return false;
        }


        private bool iExportField(XmlNode field_node)
        {
            string field_name = null;
            string description = null;
            string register_name = null;
            string register_address = null;
            int register_type = 0;
            int start_bit = 0;
            int n_bits = 0;
            string type = "INT64";
            string q_notation = null;
            long default_val = 0L;
            int export_mode = 0;
            if (field_node.ParentNode.Name != "Register")
            {
                return false;
            }
            if (field_node.LastChild.Name != "hw_info")
            {
                return false;
            }
            if (this.m_XmlParser.GetFieldAttributes(field_node, ref field_name, ref description, ref register_name, ref register_address, ref register_type, ref start_bit, ref n_bits, ref type, ref q_notation, ref default_val, ref export_mode))
            {
                CoreImports.AddHwRegisterField(field_name, description, register_name, register_address, register_type, start_bit, n_bits, type, q_notation, default_val, export_mode);
                return true;
            }
            return false;
        }


        private XmlDocument m_XmlTree;


        private RstdXmlParser m_XmlParser;


        private BidirHashtable<XmlNode, XmlNode> m_RegisterMapping;
    }
}
