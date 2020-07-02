using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFrontEnd.ASTComposite;


namespace RFrontEnd.ASTVisitor.Visitors.ASTScopesVisitor
{
    class ASTScopeVisitor : RASTAbstractConcreteVisitor<int>
    {

        // Initialize global scope.
        private SymbolTable scopeSystem = new SymbolTable();
        private StreamWriter m_outputStream;

        public ASTScopeVisitor(string file)
        {
            string outputFile = Path.GetFileNameWithoutExtension(file) + "ST.txt";
            m_outputStream = new StreamWriter(outputFile);
        }

        public override int VisitProg(RASTElement currentNode)
        {

            scopeSystem.EnterEnviroment("Global");
            base.VisitProg(currentNode);
            scopeSystem.LeaveEnviroment();
            scopeSystem.WriteToFile(m_outputStream);

            return 0;

        }

        public override int VisitDefineFunction(RASTElement currentNode)
        {
            RASTComposite current = currentNode as RASTComposite;
            scopeSystem.EnterEnviroment(currentNode.M_Label);

            // Visit function's definition params context 
            if (current.GetNumberOfContextElements(ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS) > 0)
            {
                
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS))
                {
                    scopeSystem.AddSymbol(element.M_Label, "Formal Parameter");
                }

            }

            base.VisitDefineFunction(currentNode);

            scopeSystem.LeaveEnviroment();

            return 0;

        }


        public override int VisitAssignmentOpetators(RASTElement currentNode)
        {
            RASTComposite current = currentNode as RASTComposite;

            // Visit assignment opetator left context 
            if ( current.GetNumberOfContextElements(ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT) > 0)
            {
                foreach (RASTElement element in current.GetContextChildren(ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT))
                {
                    scopeSystem.AddSymbol(element.M_Label,"Local Variable");
                }
            }

            base.VisitAssignmentOpetators(currentNode);

            return 0;

        }

        public override int VisitIDENTIFIER(RASTElement currentNode)
        {
            scopeSystem.AddSymbol(currentNode.M_Label, "Check Type");
            return base.VisitIDENTIFIER(currentNode);
        }
    }
}
