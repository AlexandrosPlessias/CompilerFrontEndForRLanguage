using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFrontEnd.ASTComposite;

namespace RFrontEnd.ASTVisitor
{
    public interface IASTAbstractConcreteVisitor<Return>
    {

        Return VisitProg(RASTElement currentNode);

        Return VisitIndexingByVectors(RASTElement currentNode);

        Return VisitIndexingBasic(RASTElement currentNode);

        Return VisitSingleDoubleColonsOperators(RASTElement currentNode);

        Return VisitDollarAtOperators(RASTElement currentNode);

        Return VisitExponentiationBinary(RASTElement currentNode);

        Return VisitMinusOrPlusUnary(RASTElement currentNode);

        Return VisitColonOperator(RASTElement currentNode);

        Return VisitWrappedWithPercent(RASTElement currentNode);

        Return VisitMultiplicationOrDivisionBinary(RASTElement currentNode);

        Return VisitMinusOrPlusBinary(RASTElement currentNode);

        Return VisitComparisons(RASTElement currentNode);

        Return VisitNotunary(RASTElement currentNode);

        Return VisitAndBinary(RASTElement currentNode);

        Return VisitOrBinary(RASTElement currentNode);

        Return VisitTildeUnary(RASTElement currentNode);

        Return VisitTildeBinary(RASTElement currentNode);

        Return VisitAssignmentOpetators(RASTElement currentNode);

        Return VisitDefineFunction(RASTElement currentNode);

        Return VisitCallFunction(RASTElement currentNode);

        Return VisitCompound(RASTElement currentNode);

        Return VisitIfStatement(RASTElement currentNode);

        Return VisitIfElseStatement(RASTElement currentNode);

        Return VisitFor(RASTElement currentNode);

        Return VisitWhile(RASTElement currentNode);

        Return VisitRepeat(RASTElement currentNode);

        Return VisitHelp(RASTElement currentNode);

        Return VisitHelpForMethods(RASTElement currentNode);

        Return VisitNextStatement(RASTElement currentNode);

        Return VisitBreakStatement(RASTElement currentNode);

        Return VisitParenthesis(RASTElement currentNode);

        Return VisitIDENTIFIER(RASTElement currentNode);

        Return VisitSTRING(RASTElement currentNode);

        Return VisitHEX(RASTElement currentNode);

        Return VisitINTEGER(RASTElement currentNode);

        Return VisitFLOAT(RASTElement currentNode);

        Return VisitCOMPLEX(RASTElement currentNode);

        Return VisitLITERALSPECIFIER(RASTElement currentNode);

    }

    public class RASTAbstractConcreteVisitor<Return> : RASTAbstractVisitor<Return>, IASTAbstractConcreteVisitor<Return>
    {

        public virtual Return VisitProg(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitIndexingByVectors(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitIndexingBasic(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitSingleDoubleColonsOperators(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitDollarAtOperators(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitExponentiationBinary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitMinusOrPlusUnary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitColonOperator(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitWrappedWithPercent(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitMultiplicationOrDivisionBinary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitMinusOrPlusBinary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitComparisons(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitNotunary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitAndBinary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitOrBinary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitTildeUnary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitTildeBinary(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitAssignmentOpetators(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitDefineFunction(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitCallFunction(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitCompound(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitIfStatement(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitIfElseStatement(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitFor(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitWhile(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitRepeat(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitHelp(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitHelpForMethods(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitNextStatement(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitBreakStatement(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitParenthesis(RASTElement currentNode)
        {
            return base.VisitChildren(currentNode);
        }

        public virtual Return VisitIDENTIFIER(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

        public virtual Return VisitSTRING(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

        public virtual Return VisitHEX(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

        public virtual Return VisitINTEGER(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

        public virtual Return VisitFLOAT(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

        public virtual Return VisitCOMPLEX(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

        public virtual Return VisitLITERALSPECIFIER(RASTElement currentNode)
        {
            return base.VisitTerminal(currentNode);
        }

    }
}
