using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RFrontEnd.ASTComposite;
using RGrammarParser;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using System;

namespace RFrontEnd
{
    class ASTGenerator : RBaseVisitor<int>
    {

        private RASTComposite m_root;

        private Stack<RASTComposite> m_parents = new Stack<RASTComposite>();

        private Stack<ContextType> m_currentContext = new Stack<ContextType>();

        public ASTGenerator()
        {
            m_currentContext.Push(ContextType.CT_NA);

        }

        private ITerminalNode GetTerminalNode(ParserRuleContext node, IToken terminal)
        {

            for (int i = 0; i < node.ChildCount; i++)
            {
                ITerminalNode child = node.GetChild(i) as ITerminalNode;
                if (child != null)
                {
                    if (child.Symbol == terminal)
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        private int VisitTerminalInContext(ParserRuleContext tokenParent, IToken token, ContextType contextType)
        {
            int res;
            m_currentContext.Push(contextType);
            res = Visit(GetTerminalNode(tokenParent, token));
            m_currentContext.Pop();
            return res;
        }

        private int VisitElementInContext(IParseTree element, ContextType contextType)
        {
            int res=0;
            if (element != null)            {
                m_currentContext.Push(contextType);
                res = Visit(element);
                m_currentContext.Pop();
            }
            return res;
        }

        private int VisitElementsInContext(IEnumerable<IParseTree> context, ContextType contextType)
        {
            int res = 0;
            m_currentContext.Push(contextType);
            foreach (ParserRuleContext elem in context)
            {
                res = Visit(elem);
            }
            m_currentContext.Pop();
            return res;
        }


        public RASTComposite M_Root
        {
            get { return m_root; }
        }


        public override int VisitProg( RParser.ProgContext context)
        {
            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RProg();
            // Update root
            m_root = newElement;
            // Update parents stack
            m_parents.Push(newElement);

            // VISIT CHILDREN
            VisitElementsInContext(context._expressions, ContextType.CT_PROG);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprIndexingByVectors( RParser.ExprIndexingByVectorsContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RIndexingByVectors(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.arraybase, ContextType.CT_EXPR_INDEXING_BY_VECTORS_BASE);
            VisitElementInContext(context.arrayoffset, ContextType.CT_EXPR_INDEXING_BY_VECTORS_OFFSET);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprIndexingBasic( RParser.ExprIndexingBasicContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RIndexingBasic(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.arraybase, ContextType.CT_EXPR_INDEXING_BASIC_BASE);
            VisitElementInContext(context.arrayoffset, ContextType.CT_EXPR_INDEXING_BASIC_OFFSET);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprSingleDoubleColonsOperators( RParser.ExprSingleDoubleColonsOperatorsContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RSingleDoubleColonsOperators(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_BASE);
            VisitElementInContext(context.right, ContextType.CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_OFFSET);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprDollarAtOperators( RParser.ExprDollarAtOperatorsContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RDollarAtOperators(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_BASE);
            VisitElementInContext(context.right, ContextType.CT_EXPR_DOLLAR_AT_OPERATORS_OFFSET);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprExponentiationBinary( RParser.ExprExponentiationBinaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RExponentiationBinary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_EXPONENTIATION_BINARY_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_EXPONENTIATION_BINARY_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprMinusOrPlusUnary( RParser.ExprMinusOrPlusUnaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RMinusOrPlusUnary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.expr(), ContextType.CT_EXPR_MINUS_OR_PLUS_UNARY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprColonOperator( RParser.ExprColonOperatorContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RColonOperator(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_COLON_OPERATOR_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_COLON_OPERATOR_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprWrappedWithPercent( RParser.ExprWrappedWithPercentContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RWrappedWithPercent(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_WRAPPED_WITH_PERCENT_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprMultiplicationOrDivisionBinary( RParser.ExprMultiplicationOrDivisionBinaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RMultiplicationOrDivisionBinary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprMinusOrPlusBinary( RParser.ExprMinusOrPlusBinaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RMinusOrPlusBinary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_MINUS_OR_PLUS_BINARY_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprComparisons( RParser.ExprComparisonsContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RComparisons(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_COMPARISONS_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_COMPARISONS_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprNotUnary( RParser.ExprNotUnaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RNotunary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.expr(), ContextType.CT_EXPR_NOT_UNARY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprAndBinary( RParser.ExprAndBinaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RAndBinary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_AND_BINARY_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_AND_BINARY_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprOrBinary( RParser.ExprOrBinaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new ROrBinary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_OR_BINARY_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_OR_BINARY_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprTildeUnary( RParser.ExprTildeUnaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RTildeUnary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.expr(), ContextType.CT_EXPR_TILDE_UNARY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprTildeBinary( RParser.ExprTildeBinaryContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RTildeBinary(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_TILDE_BINARY_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_TILDE_BINARY_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprAssignmentOpetators( RParser.ExprAssignmentOpetatorsContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RASsignmentOpetators(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_ASSIGNMENT_OPETATORS_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprDefineFunction( RParser.ExprDefineFunctionContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RDefineFunction(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.funargs, ContextType.CT_EXPR_DEFINE_FUNCTION_PARAMS);
            VisitElementInContext(context.functionbody, ContextType.CT_EXPR_DEFINE_FUNCTION_BODY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprCallFunction( RParser.ExprCallFunctionContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RCallFunction(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.funid, ContextType.CT_EXPR_CALL_FUNCTION_ID);
            VisitElementInContext(context.funargs, ContextType.CT_EXPR_CALL_FUNCTION_PARAMS);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprCompound( RParser.ExprCompoundContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RCompound(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.exprlist(), ContextType.CT_EXPR_COMPOUND);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprIfStatement( RParser.ExprIfStatementContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RIfStatement(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.thenbody, ContextType.CT_EXPR_IF_STATEMENT_CONDITION);
            VisitElementInContext(context.ifcond, ContextType.CT_EXPR_IF_STATEMENT_BODY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprIfElseStatement( RParser.ExprIfElseStatementContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RIfElseStatement(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.ifcond, ContextType.CT_EXPR_IF_ELSE_STATEMENT_CONDITION);
            VisitElementInContext(context.thenbody, ContextType.CT_EXPR_IF_ELSE_STATEMENT_IFBODY);
            VisitElementInContext(context.elsebody, ContextType.CT_EXPR_IF_ELSE_STATEMENT_ELSEBODY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprFor( RParser.ExprForContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RFor(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.ID(), ContextType.CT_EXPR_FOR_NAME);
            VisitElementInContext(context.for_list, ContextType.CT_EXPR_FOR_VECTOR);
            VisitElementInContext(context.for_body, ContextType.CT_EXPR_FOR_BODY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprWhile( RParser.ExprWhileContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RWhile(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.whilecond, ContextType.CT_EXPR_WHILE_CONDITION);
            VisitElementInContext(context.whilebody, ContextType.CT_EXPR_WHILE_BODY);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprRepeat( RParser.ExprRepeatContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RRepeat(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.expr(), ContextType.CT_EXPR_REPEAT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprHelp( RParser.ExprHelpContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RHelp(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.expr(), ContextType.CT_EXPR_HELP);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprHelpForMethods( RParser.ExprHelpForMethodsContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RHelpForMethods(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.left, ContextType.CT_EXPR_HELP_FOR_METHODS_LEFT);
            VisitElementInContext(context.right, ContextType.CT_EXPR_HELP_FOR_METHODS_RIGHT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprNextStatement(RParser.ExprNextStatementContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RNextStatement(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
          

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

            public override int VisitExprBreakStatement(RParser.ExprBreakStatementContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RBreakStatement(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            //VisitElementInContext(context., ContextType.CT_EXPR_BREAK_STATEMENT);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitExprParenthesis( RParser.ExprParenthesisContext context)
        {
            RASTComposite parent = m_parents.Peek();

            // PREORDER ACTIONS
            // Create new element
            RASTComposite newElement = new RParenthesis(parent);
            // Update parents stack
            m_parents.Push(newElement);

            // Add new element to the parent's descentants
            parent.AddChild(newElement, m_currentContext.Peek());

            // VISIT CHILDREN
            VisitElementInContext(context.expr(), ContextType.CT_EXPR_PARENTHESIS);

            // POSTORDER ACTIONS

            // Update parents stack
            m_parents.Pop();

            return 0;
        }

        public override int VisitTerminal(ITerminalNode node)
        {
            RASTComposite parent = m_parents.Peek();
            switch (node.Symbol.Type)
            {
                case RParser.ID:
                    RIDENTIFIER identifierToken = new RIDENTIFIER(node.GetText(), parent);
                    parent.AddChild(identifierToken, m_currentContext.Peek());
                    break;
                case RParser.STRING:
                    RSTRING stringToken = new RSTRING(node.GetText().Replace('"',' '), parent);
                    parent.AddChild(stringToken, m_currentContext.Peek());
                    break;
                case RParser.HEX:
                    RHEX hexToken = new RHEX(node.GetText(), parent);
                    parent.AddChild(hexToken, m_currentContext.Peek());
                    break;
                case RParser.INT:
                    RINTEGER integerToken = new RINTEGER(node.GetText(), parent);
                    parent.AddChild(integerToken, m_currentContext.Peek());
                    break;
                case RParser.FLOAT:
                    RFLOAT floatToken = new RFLOAT(node.GetText(), parent);
                    parent.AddChild(floatToken, m_currentContext.Peek());
                    break;
                case RParser.COMPLEX:
                    RCOMPLEX complexToken = new RCOMPLEX(node.GetText(), parent);
                    parent.AddChild(complexToken, m_currentContext.Peek());
                    break;
                case 47 :   // 'NULL'
                    RLITERALSPECIFIER NULL_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NULL_literal, m_currentContext.Peek());
                    break;
                case 48:    // 'NA'
                    RLITERALSPECIFIER NA_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NA_literal, m_currentContext.Peek());
                    break;
                case 49:    // 'NA_integer_'
                    RLITERALSPECIFIER NA_integer_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NA_integer_literal, m_currentContext.Peek());
                    break;
                case 50:    // 'NA_real_'
                    RLITERALSPECIFIER NA_real_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NA_real_literal, m_currentContext.Peek());
                    break;
                case 51:    // 'NA_complex_'
                    RLITERALSPECIFIER NA_complex_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NA_complex_literal, m_currentContext.Peek());
                    break;
                case 52:    // 'NA_character_' 
                    RLITERALSPECIFIER NA_character_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NA_character_literal, m_currentContext.Peek());
                    break;
                case 53:    // 'Inf'
                    RLITERALSPECIFIER Inf_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(Inf_literal, m_currentContext.Peek());
                    break;
                case 54:    // 'NaN'
                    RLITERALSPECIFIER NaN_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(NaN_literal, m_currentContext.Peek());
                    break;
                case 55:    // 'TRUE'
                    RLITERALSPECIFIER TRUE_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(TRUE_literal, m_currentContext.Peek());
                    break;
                case 56:    // 'FALSE'
                    RLITERALSPECIFIER FALSE_literal = new RLITERALSPECIFIER(node.GetText(), parent);
                    parent.AddChild(FALSE_literal, m_currentContext.Peek());
                    break;
            }

            return base.VisitTerminal(node);
        }
    }
}

