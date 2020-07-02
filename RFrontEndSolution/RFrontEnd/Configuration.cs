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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFrontEnd.ASTComposite;

namespace RFrontEnd
{
    public enum Color
    {
        C_DEFAULT, C_antiquewhite, C_coral, C_darkgoldenrod,
        C_azure, C_crimson, C_gold, C_bisque, C_darksalmon,
        C_goldenrod, C_aliceblue, C_blanchedalmond, C_deeppink,
        C_blue, C_cornsilk, C_firebrick, C_lightgoldenrod,
        C_floralwhite, C_hotpink, C_lightgoldenrodyellow, C_cadetblue,
        C_gainsboro, C_indianred, C_lightyellow, C_cornflowerblue, C_ghostwhite,
        C_lightpink, C_palegoldenrod, C_darkslateblue, C_honeydew, C_lightsalmon,
        C_yellow, C_deepskyblue, C_ivory, C_maroon, C_dodgerblue,
        C_lavender, C_indigo, C_lavenderblush,
        C_lightblue, C_lemonchiffon, C_chartreuse, C_lightskyblue,
        C_linen, C_pink, C_darkgreen, C_lightslateblue, C_red, C_darkolivegreen,
        C_mediumblue, C_mistyrose, C_salmon, C_darkseagreen, C_mediumslateblue,
        C_moccasin, C_tomato, C_forestgreen, C_midnightblue, C_navajowhite,
        C_green, C_navy, C_oldlace, C_greenyellow, C_navyblue,
        C_papayawhip, C_lawngreen, C_powderblue, C_peachpuff, C_beige, C_lightseagreen,
        C_royalblue, C_seashell, C_brown, C_limegreen, C_skyblue, C_snow, C_burlywood,
        C_mediumseagreen, C_slateblue, C_thistle, C_chocolate, C_mediumspringgreen, C_steelblue,
        C_wheat, C_darkkhaki, C_mintcream, C_white, C_khaki, C_olivedrab, C_whitesmoke, C_peru,
        C_palegreen, C_blueviolet, C_rosybrown, C_seagreen, C_darkorchid, C_saddlebrown, C_springgreen,
        C_darkviolet, C_darkslategray, C_sandybrown, C_yellowgreen, C_magenta, C_dimgray, C_sienna,
        C_mediumorchid, C_tan, C_mediumpurple, C_gray, C_aquamarine, C_mediumvioletred, C_lightgray,
        C_cyan, C_orchid, C_lightslategray, C_darkorange, C_darkturquoise, C_palevioletred, C_slategray,
        C_orange, C_lightcyan, C_plum, C_orangered, C_mediumaquamarine, C_purple, C_mediumturquoise, C_violet,
        C_black, C_paleturquoise, C_violetred
    };

    public partial class RNodeTypeConfiguration
    {
        public NodeType M_NodeTypeCategory { get; set; }
        public int M_NumberOfContexts { get; set; }

        public Color M_Color { get; set; }
        public string M_ColorName { get; set; }
    }

    public partial class RContextTypeConfiguration
    {

        public int M_ContextIndex { get; set; }

        public NodeType M_HostNodeType { get; set; }

    }

    internal static partial class RConfigurationSettings
    {

        public static readonly string[] m_colorNames = new[] { "default", "antiquewhite", "coral", "darkgoldenrod",
                                                           "azure", "crimson", "gold", "bisque", "darksalmon",
                                                            "goldenrod", "aliceblue","blanchedalmond", "deeppink",
                                                            "blue","cornsilk", "firebrick", "lightgoldenrod",
                                                            "floralwhite", "hotpink","lightgoldenrodyellow", "cadetblue",
                                                            "gainsboro", "indianred", "lightyellow", "cornflowerblue","ghostwhite",
                                                            "lightpink", "palegoldenrod", "darkslateblue","honeydew", "lightsalmon",
                                                            "yellow", "deepskyblue","ivory", "maroon", "dodgerblue",
                                                            "lavender", "indigo","lavenderblush",
                                                            "lightblue","lemonchiffon",  "chartreuse", "lightskyblue",
                                                            "linen", "pink", "darkgreen", "lightslateblue", "red","darkolivegreen",
                                                            "mediumblue","mistyrose", "salmon", "darkseagreen", "mediumslateblue",
                                                            "moccasin", "tomato", "forestgreen", "midnightblue","navajowhite",
                                                            "green", "navy","oldlace", "greenyellow", "navyblue",
                                                            "papayawhip", "lawngreen", "powderblue", "peachpuff", "beige", "lightseagreen",
                                                            "royalblue","seashell", "brown", "limegreen", "skyblue","snow", "burlywood",
                                                            "mediumseagreen", "slateblue","thistle", "chocolate", "mediumspringgreen", "steelblue",
                                                            "wheat", "darkkhaki", "mintcream", "white", "khaki", "olivedrab", "whitesmoke", "peru",
                                                            "palegreen", "blueviolet", "rosybrown", "seagreen", "darkorchid", "saddlebrown", "springgreen",
                                                            "darkviolet", "darkslategray", "sandybrown", "yellowgreen", "magenta","dimgray", "sienna",
                                                            "mediumorchid","tan","mediumpurple","gray","aquamarine","mediumvioletred","lightgray",
                                                            "cyan","orchid","lightslategray","darkorange","darkturquoise","palevioletred","slategray",
                                                            "orange","lightcyan","plum","orangered","mediumaquamarine","purple","mediumturquoise","violet",
                                                            "black","paleturquoise","violetred"};

        internal static Dictionary<NodeType, RNodeTypeConfiguration> m_nodeTypeConfiguration = new Dictionary<NodeType, RNodeTypeConfiguration>();

        internal static Dictionary<ContextType, RContextTypeConfiguration> m_contextTypeConfiguration = new Dictionary<ContextType, RContextTypeConfiguration>();

        static RConfigurationSettings()
        {
            InitNodeTypeConfigurationSettings();
        }

        public static void SetNodeCategoryColor(NodeType nodeType, Color color)
        {
            switch (nodeType)
            {
                case NodeType.NT_EXPRESSION:
                case NodeType.NT_LEAF:
                    foreach (KeyValuePair<NodeType, RNodeTypeConfiguration> record in m_nodeTypeConfiguration)
                    {
                        if (record.Value.M_NodeTypeCategory == nodeType)
                        {
                            record.Value.M_Color = color;
                            record.Value.M_ColorName = RConfigurationSettings.m_colorNames[(int)color];
                        }
                    }
                    break;
                default:
                    if (color != Color.C_DEFAULT)
                    {
                        m_nodeTypeConfiguration[nodeType].M_Color = color;
                        m_nodeTypeConfiguration[nodeType].M_ColorName = RConfigurationSettings.m_colorNames[(int)color];
                    }
                    break;
            }
        }

        private static void InitNodeTypeConfigurationSettings()
        {
            Console.Write("Initializing AST configuration...");

            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_PROG] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_NA, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_INDEXING_BY_VECTORS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_INDEXING_BASIC] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_DOLLAR_AT_OPERATORS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_EXPONENTIATION_BINARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_MINUS_OR_PLUS_UNARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_COLON_OPERATOR] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_WRAPPED_WITH_PERCENT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_MINUS_OR_PLUS_BINARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_COMPARISONS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_NOT_UNARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_AND_BINARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_OR_BINARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_TILDE_UNARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_TILDE_BINARY] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_ASSIGNMENT_OPETATORS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_DEFINE_FUNCTION] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_CALL_FUNCTION] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_COMPOUND] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_IF_STATEMENT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_IF_ELSE_STATEMENT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 3, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_FOR] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 3, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_WHILE] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_REPEAT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_HELP] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_HELP_FOR_METHODS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 2, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_NEXT_STATEMENT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_BREAK_STATEMENT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_EXPR_PARENTHESIS] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 1, M_NodeTypeCategory = NodeType.NT_EXPRESSION, M_ColorName = "default", M_Color = Color.C_DEFAULT };

            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_ID] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_STRING] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_HEX] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_INT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_FLOAT] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_COMPLEX] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };
            RConfigurationSettings.m_nodeTypeConfiguration[NodeType.NT_LITERALSPECIFIER] = new RNodeTypeConfiguration()
            { M_NumberOfContexts = 0, M_NodeTypeCategory = NodeType.NT_LEAF, M_ColorName = "default", M_Color = Color.C_DEFAULT };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_PROG] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_PROG };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_INDEXING_BY_VECTORS_BASE] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_INDEXING_BY_VECTORS };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_INDEXING_BY_VECTORS_OFFSET] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_INDEXING_BY_VECTORS };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_INDEXING_BASIC_BASE] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_INDEXING_BASIC };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_INDEXING_BASIC_OFFSET] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_INDEXING_BASIC };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_BASE] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_OFFSET] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS };


            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_BASE] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_DOLLAR_AT_OPERATORS };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_OFFSET] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_DOLLAR_AT_OPERATORS };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_EXPONENTIATION_BINARY_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_EXPONENTIATION_BINARY };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_EXPONENTIATION_BINARY_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_EXPONENTIATION_BINARY };


            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_MINUS_OR_PLUS_UNARY] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_MINUS_OR_PLUS_UNARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_COLON_OPERATOR_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_COLON_OPERATOR };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_COLON_OPERATOR_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_COLON_OPERATOR };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_WRAPPED_WITH_PERCENT };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_WRAPPED_WITH_PERCENT };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_MINUS_OR_PLUS_BINARY };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_MINUS_OR_PLUS_BINARY };


            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_COMPARISONS_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_COMPARISONS };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_COMPARISONS_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_COMPARISONS };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_NOT_UNARY] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_NOT_UNARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_AND_BINARY_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_AND_BINARY };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_AND_BINARY_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_AND_BINARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_OR_BINARY_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_OR_BINARY };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_OR_BINARY_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_OR_BINARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_TILDE_UNARY] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_TILDE_UNARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_TILDE_BINARY_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_TILDE_BINARY};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_TILDE_BINARY_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_TILDE_BINARY };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_ASSIGNMENT_OPETATORS};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_ASSIGNMENT_OPETATORS};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_DEFINE_FUNCTION };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_DEFINE_FUNCTION_BODY] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_DEFINE_FUNCTION };

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_CALL_FUNCTION_ID] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_CALL_FUNCTION };
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_CALL_FUNCTION_PARAMS] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_CALL_FUNCTION };

            
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_COMPOUND] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_COMPOUND};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_IF_STATEMENT_CONDITION] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_IF_STATEMENT};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_IF_STATEMENT_BODY] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_IF_STATEMENT};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_IF_ELSE_STATEMENT_CONDITION] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_IF_ELSE_STATEMENT};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_IF_ELSE_STATEMENT_IFBODY] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_IF_ELSE_STATEMENT};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_IF_ELSE_STATEMENT_ELSEBODY] = new RContextTypeConfiguration()
            { M_ContextIndex = 2, M_HostNodeType = NodeType.NT_EXPR_IF_ELSE_STATEMENT};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_FOR_NAME] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_FOR};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_FOR_VECTOR] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_FOR};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_FOR_BODY] = new RContextTypeConfiguration()
            { M_ContextIndex = 2, M_HostNodeType = NodeType.NT_EXPR_FOR};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_WHILE_CONDITION] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_WHILE};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_WHILE_BODY] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_WHILE};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_REPEAT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_REPEAT};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_HELP] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_HELP};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_HELP_FOR_METHODS_LEFT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_HELP_FOR_METHODS};
            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_HELP_FOR_METHODS_RIGHT] = new RContextTypeConfiguration()
            { M_ContextIndex = 1, M_HostNodeType = NodeType.NT_EXPR_HELP_FOR_METHODS};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_NEXT_STATEMENT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_NEXT_STATEMENT};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_BREAK_STATEMENT] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_BREAK_STATEMENT};

            RConfigurationSettings.m_contextTypeConfiguration[ContextType.CT_EXPR_PARENTHESIS] = new RContextTypeConfiguration()
            { M_ContextIndex = 0, M_HostNodeType = NodeType.NT_EXPR_PARENTHESIS};

            Console.WriteLine("OK");
        }

    }
}
