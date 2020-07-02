using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RFrontEnd.ASTComposite;

namespace RFrontEnd{

    class Program{

        static void Main(string[] args){
            RFacade.SetNodeGraphicalAppearanceColor(NodeType.NT_EXPRESSION , Color.C_yellow);
            RFacade.SetNodeGraphicalAppearanceColor(NodeType.NT_LEAF, Color.C_green);
            //RFacade.SetNodeGraphicalAppearanceColor(NodeType.NT_NA, Color.C_aquamarine); ask also here

            RFacade.Start(args);
        }
    }
}
