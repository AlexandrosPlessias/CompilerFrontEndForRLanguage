/*
MIT License

Copyright(c) [2017] [Grigoris Dimitroulakos, Alexandros Plessias]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using RFrontEnd.ASTComposite;
using System;
using System.Diagnostics;
using System.IO;


namespace RFrontEnd.ASTVisitor.Visitors
{
      class ASTPrinter : RASTAbstractConcreteVisitor<int> {

        private StreamWriter m_outputStream;

        private string m_outputFile;

        private int ms_clusterCounter = 0;


        public ASTPrinter(string file) {
            m_outputFile = Path.GetFileNameWithoutExtension(file) + "AST.dot";
            m_outputStream = new StreamWriter(m_outputFile);
        }

        public override int VisitProg(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("digraph {\n");

            // Visit prog context
            if (current.GetNumberOfContextElements(ContextType.CT_PROG) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_PROG.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);

                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_PROG)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitProg(currentNode);

            m_outputStream.WriteLine("}");
            m_outputStream.Close();


            if (true) {
                Process process = new Process();
                // Configure the process using the StartInfo properties.
                process.StartInfo.FileName = @".\Graphviz\bin\dot.exe";
                process.StartInfo.Arguments = "-Tgif " + m_outputFile + " -o" + Path.GetFileNameWithoutExtension(m_outputFile) + ".gif";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();// Waits here for the process to exit.
            }


            return 0;
        }

        public override int VisitIndexingByVectors(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit indexing by vector base context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_INDEXING_BY_VECTORS_BASE) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_INDEXING_BY_VECTORS_BASE.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_INDEXING_BY_VECTORS_BASE)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit indexing by vector offset context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_INDEXING_BY_VECTORS_OFFSET) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_INDEXING_BY_VECTORS_OFFSET.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_INDEXING_BY_VECTORS_OFFSET))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitIndexingByVectors(currentNode);

            return 0;
        }

        public override int VisitIndexingBasic(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit indexing basic base context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_INDEXING_BASIC_BASE) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_INDEXING_BASIC_BASE.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_INDEXING_BASIC_BASE)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.Write(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit Visit indexing basic offset context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_INDEXING_BASIC_OFFSET) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_INDEXING_BASIC_OFFSET.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_INDEXING_BASIC_OFFSET))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.Write(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitIndexingBasic(currentNode);

            return 0;
        }

        public override int VisitSingleDoubleColonsOperators(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit single & double colons operators base context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_BASE) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_BASE.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_BASE)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit single & double colons operators offset context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_OFFSET) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_OFFSET.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_OFFSET))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitSingleDoubleColonsOperators(currentNode);

            return 0;
        }

        public override int VisitDollarAtOperators(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit dollar & at operations base context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_BASE) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_BASE.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_BASE)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit dollar & at operations offset context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_OFFSET) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_OFFSET.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_OFFSET))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitDollarAtOperators(currentNode);

            return 0;
        }

        public override int VisitExponentiationBinary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit exponentiation left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_EXPONENTIATION_BINARY_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_EXPONENTIATION_BINARY_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_EXPONENTIATION_BINARY_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit exponentiation right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_EXPONENTIATION_BINARY_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_EXPONENTIATION_BINARY_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_EXPONENTIATION_BINARY_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitExponentiationBinary(currentNode);

            return 0;
        }

        public override int VisitMinusOrPlusUnary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;

            m_outputStream.WriteLine("\"{0}\"->\"{1}\"",currentNode.M_Parent.M_Label,currentNode.M_Label);

            // Visit unary minus or plus context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_MINUS_OR_PLUS_UNARY) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_MINUS_OR_PLUS_UNARY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_MINUS_OR_PLUS_UNARY)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitMinusOrPlusUnary(currentNode);

            return 0;
        }

        public override int VisitColonOperator(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit colon operator left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_COLON_OPERATOR_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_COLON_OPERATOR_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_COLON_OPERATOR_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit colon operator right context  
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_COLON_OPERATOR_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_COLON_OPERATOR_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_COLON_OPERATOR_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitColonOperator(currentNode);

            return 0;
        }

        public override int VisitWrappedWithPercent(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit wrapped with percent left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit wrapped with percent right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitWrappedWithPercent(currentNode);

            return 0;
        }

        public override int VisitMultiplicationOrDivisionBinary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit multiplication or division left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }

                }
                m_outputStream.WriteLine("}");
            }

            // Visit multiplication or division right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }

                }
                m_outputStream.WriteLine("}");
            }

            base.VisitMultiplicationOrDivisionBinary(currentNode);

            return 0;
        }

        public override int VisitMinusOrPlusBinary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit minus or plus binary left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit minus or plus binary right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitMinusOrPlusBinary(currentNode);

            return 0;
        }

        public override int VisitComparisons(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit comparisons left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_COMPARISONS_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_COMPARISONS_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_COMPARISONS_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit comparisons right context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_COMPARISONS_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_COMPARISONS_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_COMPARISONS_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitComparisons(currentNode);

            return 0;
        }

        public override int VisitNotunary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit unary not context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_NOT_UNARY) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_NOT_UNARY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_NOT_UNARY)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }
            base.VisitNotunary(currentNode);

            return 0;
        }

        public override int VisitAndBinary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit binary and left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_AND_BINARY_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_AND_BINARY_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_AND_BINARY_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit binary and right context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_AND_BINARY_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_AND_BINARY_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_AND_BINARY_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitAndBinary(currentNode);

            return 0;
        }

        public override int VisitOrBinary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit binary or left context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_OR_BINARY_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_OR_BINARY_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_OR_BINARY_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit binary or right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_OR_BINARY_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_OR_BINARY_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_OR_BINARY_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitOrBinary(currentNode);

            return 0;
        }

        public override int VisitTildeUnary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit unary tilde context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_TILDE_UNARY) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_TILDE_UNARY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_TILDE_UNARY)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitTildeUnary(currentNode);

            return 0;
        }

        public override int VisitTildeBinary(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit binary tidle left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_TILDE_BINARY_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_TILDE_BINARY_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_TILDE_BINARY_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit binary tidle right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_TILDE_BINARY_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_TILDE_BINARY_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_TILDE_BINARY_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitTildeBinary(currentNode);

            return 0;
        }

        public override int VisitAssignmentOpetators(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit assignment opetator left context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit assignment opetator right context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_RIGHT) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitAssignmentOpetators(currentNode);

            return 0;
        }

        public override int VisitDefineFunction(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit function's definition params context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS) > 0) {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            //  Visit function's definition body context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_DEFINE_FUNCTION_BODY) > 0)
            {
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_DEFINE_FUNCTION_BODY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_DEFINE_FUNCTION_BODY))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitDefineFunction(currentNode);

            return 0;
        }

        public override int VisitCallFunction(RASTElement currentNode) {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit call function id/name context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_CALL_FUNCTION_ID) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_CALL_FUNCTION_ID.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_CALL_FUNCTION_ID)) {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT) {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit call function params context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_CALL_FUNCTION_PARAMS) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_CALL_FUNCTION_PARAMS.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_CALL_FUNCTION_PARAMS))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);

                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitCallFunction(currentNode);

            return 0;
        }

        public override int VisitCompound(RASTElement currentNode)
        {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit compound context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_COMPOUND) > 0)
            { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_COMPOUND.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_COMPOUND))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitCompound(currentNode);

            return 0;
        }

        public override int VisitIfStatement(RASTElement currentNode)
        {
            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit if statement condition context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_IF_STATEMENT_CONDITION) > 0)
            { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_IF_STATEMENT_CONDITION.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_IF_STATEMENT_CONDITION))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit if statement body context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_IF_STATEMENT_BODY) > 0)
            { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_IF_STATEMENT_BODY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_IF_STATEMENT_BODY))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitIfStatement(currentNode);

            return 0;
        }

        public override int VisitIfElseStatement(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit if-else statement condition context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_IF_ELSE_STATEMENT_CONDITION) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_IF_ELSE_STATEMENT_CONDITION.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_IF_ELSE_STATEMENT_CONDITION))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit if-else statement if_body context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_IF_ELSE_STATEMENT_IFBODY) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_IF_ELSE_STATEMENT_IFBODY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_IF_ELSE_STATEMENT_IFBODY))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // // Visit if-else statement else_body context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_IF_ELSE_STATEMENT_ELSEBODY) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_IF_ELSE_STATEMENT_ELSEBODY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_IF_ELSE_STATEMENT_ELSEBODY))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }
            base.VisitIfElseStatement(currentNode);

            return 0;
        }

        public override int VisitFor(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit for name(of vector) context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_FOR_NAME) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_FOR_NAME.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_FOR_NAME))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].
                            M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit for vector context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_FOR_VECTOR) > 0){ // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_FOR_VECTOR.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_FOR_VECTOR))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].
                            M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit for body context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_FOR_BODY) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_FOR_BODY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_FOR_BODY))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].
                            M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitFor(currentNode);

            return 0;
        }

        public override int VisitWhile(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit while condition context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_WHILE_CONDITION) > 0)           { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_WHILE_CONDITION.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_WHILE_CONDITION))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit while body context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_WHILE_BODY) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_WHILE_BODY.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_WHILE_BODY))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitWhile(currentNode);

            return 0;
        }

        public override int VisitRepeat(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit repeat context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_REPEAT) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_REPEAT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_REPEAT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitRepeat(currentNode);

            return 0;
        }

        public override int VisitHelp(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit help context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_HELP) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_HELP.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_HELP))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitHelp(currentNode);

            return 0;
        }

        public override int VisitHelpForMethods(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit help for methods left context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_HELP_FOR_METHODS_LEFT) > 0){ // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_HELP_FOR_METHODS_LEFT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_HELP_FOR_METHODS_LEFT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            // Visit help for methods right context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_HELP_FOR_METHODS_RIGHT) > 0)  { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_HELP_FOR_METHODS_RIGHT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_HELP_FOR_METHODS_RIGHT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitHelpForMethods(currentNode);

            return 0;
        }

        public override int VisitNextStatement(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit next statement context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_NEXT_STATEMENT) > 0) { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_NEXT_STATEMENT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_NEXT_STATEMENT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitNextStatement(currentNode);

            return 0;
        }

        public override int VisitBreakStatement(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit break statement context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_BREAK_STATEMENT) > 0)
            { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_BREAK_STATEMENT.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_BREAK_STATEMENT))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitBreakStatement(currentNode);

            return 0;
        }

        public override int VisitParenthesis(RASTElement currentNode)
        {

            RASTComposite current = currentNode as RASTComposite;
            string clusterName;
            string contextName;
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);

            // Visit parenthesis context
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_PARENTHESIS) > 0)
            { // if not a leaf
                clusterName = "cluster" + ms_clusterCounter++;
                contextName = ContextType.CT_EXPR_PARENTHESIS.ToString();
                m_outputStream.WriteLine(
                    "subgraph {0} {{\n node [style=filled,color=white];\n style=filled;\n color=lightgrey;\n label = \"{1}\";\n",
                    clusterName, contextName);
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_PARENTHESIS))
                {
                    m_outputStream.WriteLine("\"{0}\"", element.M_Label);
                    if (RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_Color != Color.C_DEFAULT)
                    {
                        m_outputStream.WriteLine(" [fillcolor = " + RConfigurationSettings.m_nodeTypeConfiguration[element.M_NodeType].M_ColorName + "]");
                    }
                }
                m_outputStream.WriteLine("}");
            }

            base.VisitParenthesis(currentNode);

            return 0;
        }

        public override int VisitIDENTIFIER(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);
            return base.VisitIDENTIFIER(currentNode);
        }

        public override int VisitSTRING(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label.Replace('"', ' ')); // i add this because i have issues with strings
            return base.VisitSTRING(currentNode);
        }

        public override int VisitHEX(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);
            return base.VisitHEX(currentNode);
        }

        public override int VisitINTEGER(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);
            return base.VisitINTEGER(currentNode);
        }

        public override int VisitFLOAT(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);
            return base.VisitFLOAT(currentNode);
        }

        public override int VisitCOMPLEX(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);
            return base.VisitCOMPLEX(currentNode);
        }

        public override int VisitLITERALSPECIFIER(RASTElement currentNode) {
            m_outputStream.WriteLine("\"{0}\"->\"{1}\"", currentNode.M_Parent.M_Label, currentNode.M_Label);
            return base.VisitLITERALSPECIFIER(currentNode);
        }
    }
}
