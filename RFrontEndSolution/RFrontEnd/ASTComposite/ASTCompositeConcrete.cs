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
using System.Runtime.InteropServices;
using RFrontEnd.ASTEvents;
using RFrontEnd.ASTFactories;
using RFrontEnd.ASTIterator;
using RFrontEnd.ASTVisitor;



namespace RFrontEnd.ASTComposite
{
    /// <summary>
    /// This file contains automatically generated code
    /// </summary>
    ///

    public enum NodeType
    {
        /// <summary>
        /// This enumeration carries the different types of AST Nodes. The numbers indicate the index in the
        /// m_contextMappings table of tuples where each specific context starts
        /// </summary>
        // NON-TERMINAL NODES
        /* 35 */
        NT_PROG = 0, NT_EXPR_INDEXING_BY_VECTORS = 1, NT_EXPR_INDEXING_BASIC = 3, NT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS = 5,
        NT_EXPR_DOLLAR_AT_OPERATORS = 7, NT_EXPR_EXPONENTIATION_BINARY = 9, NT_EXPR_MINUS_OR_PLUS_UNARY = 11, NT_EXPR_COLON_OPERATOR = 12,
        NT_EXPR_WRAPPED_WITH_PERCENT = 14, NT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY = 16, NT_EXPR_MINUS_OR_PLUS_BINARY = 18,
        NT_EXPR_COMPARISONS = 20, NT_EXPR_NOT_UNARY = 22, NT_EXPR_AND_BINARY = 23, NT_EXPR_OR_BINARY = 25, NT_EXPR_TILDE_UNARY = 27,
        NT_EXPR_TILDE_BINARY = 28, NT_EXPR_ASSIGNMENT_OPETATORS = 30, NT_EXPR_DEFINE_FUNCTION = 32, NT_EXPR_CALL_FUNCTION = 34,
        NT_EXPR_COMPOUND = 36, NT_EXPR_IF_STATEMENT = 37, NT_EXPR_IF_ELSE_STATEMENT = 39, NT_EXPR_FOR = 42, NT_EXPR_WHILE = 45,
        NT_EXPR_REPEAT = 47, NT_EXPR_HELP = 48, NT_EXPR_HELP_FOR_METHODS = 49, NT_EXPR_NEXT_STATEMENT = 51, NT_EXPR_BREAK_STATEMENT,
        NT_EXPR_PARENTHESIS = 53,


        // LEAF NODES
        /* 7 */
        NT_ID = 54, NT_STRING, NT_HEX, NT_INT, NT_FLOAT, NT_COMPLEX, NT_LITERALSPECIFIER,


        // NODE CATEGORIES
        /* 4 */
        NT_EXPRESSION = 61, NT_LEAF, NT_NA
    }



    public enum ContextType
    {
        /*  00 */
        CT_PROG,
        /* +01 */
        CT_EXPR_INDEXING_BY_VECTORS_BASE, CT_EXPR_INDEXING_BY_VECTORS_OFFSET,
        /* +03 */
        CT_EXPR_INDEXING_BASIC_BASE, CT_EXPR_INDEXING_BASIC_OFFSET,
        /* +05 */
        CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_BASE, CT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS_OFFSET,
        /* +07 */
        CT_EXPR_DOLLAR_AT_OPERATORS_BASE, CT_EXPR_DOLLAR_AT_OPERATORS_OFFSET,
        /* +09 */
        CT_EXPR_EXPONENTIATION_BINARY_LEFT, CT_EXPR_EXPONENTIATION_BINARY_RIGHT,
        /* +11 */
        CT_EXPR_MINUS_OR_PLUS_UNARY,
        /* +12 */
        CT_EXPR_COLON_OPERATOR_LEFT, CT_EXPR_COLON_OPERATOR_RIGHT,
        /* +14 */
        CT_EXPR_WRAPPED_WITH_PERCENT_LEFT, CT_EXPR_WRAPPED_WITH_PERCENT_RIGHT,
        /* +16 */
        CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_LEFT, CT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY_RIGHT,
        /* +18 */
        CT_EXPR_MINUS_OR_PLUS_BINARY_LEFT, CT_EXPR_MINUS_OR_PLUS_BINARY_RIGHT,
        /* +20 */
        CT_EXPR_COMPARISONS_LEFT, CT_EXPR_COMPARISONS_RIGHT,
        /* +22 */
        CT_EXPR_NOT_UNARY,
        /* +23 */
        CT_EXPR_AND_BINARY_LEFT, CT_EXPR_AND_BINARY_RIGHT,
        /* +25 */
        CT_EXPR_OR_BINARY_LEFT, CT_EXPR_OR_BINARY_RIGHT,
        /* +27 */
        CT_EXPR_TILDE_UNARY,
        /* +28 */
        CT_EXPR_TILDE_BINARY_LEFT, CT_EXPR_TILDE_BINARY_RIGHT,
        /* +30 */
        CT_EXPR_ASSIGNMENT_OPETATORS_LEFT, CT_EXPR_ASSIGNMENT_OPETATORS_RIGHT,
        /* +32 */
        CT_EXPR_DEFINE_FUNCTION_PARAMS, CT_EXPR_DEFINE_FUNCTION_BODY,
        /* +34 */
        CT_EXPR_CALL_FUNCTION_ID, CT_EXPR_CALL_FUNCTION_PARAMS,
        /* +36 */
        CT_EXPR_COMPOUND,
        /* +37 */
        CT_EXPR_IF_STATEMENT_CONDITION, CT_EXPR_IF_STATEMENT_BODY,
        /* +39 */
        CT_EXPR_IF_ELSE_STATEMENT_CONDITION, CT_EXPR_IF_ELSE_STATEMENT_IFBODY, CT_EXPR_IF_ELSE_STATEMENT_ELSEBODY,
        /* +42 */
        CT_EXPR_FOR_NAME, CT_EXPR_FOR_VECTOR, CT_EXPR_FOR_BODY,
        /* +45 */
        CT_EXPR_WHILE_CONDITION, CT_EXPR_WHILE_BODY,
        /* +47 */
        CT_EXPR_REPEAT,
        /* +48 */
        CT_EXPR_HELP,
        /* +49 */
        CT_EXPR_HELP_FOR_METHODS_LEFT, CT_EXPR_HELP_FOR_METHODS_RIGHT,
        /* +51 */
        CT_EXPR_NEXT_STATEMENT,
        /* +52 */
        CT_EXPR_BREAK_STATEMENT,
        /* +53 */
        CT_EXPR_PARENTHESIS,
        CT_NA
    }

    public enum LiteralSpecifier
    {
        LT_NULL, LT_NA, LT_NA_INTEGER, LT_NA_REAL, LT_NA_COMPLEX, LT_NA_CHARACTER, LT_INF,
        LT_NAN, LT_TRUE, LT_FALSE
    }

    public class RProg : RASTComposite
    {
        public RProg() : base(NodeType.NT_PROG, null, NodeType.NT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitProg(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateProgIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateProgIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }

    }

    public class RIndexingByVectors : RASTComposite
    {

        public RIndexingByVectors(RASTComposite parent) :
            base(NodeType.NT_EXPR_INDEXING_BY_VECTORS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitIndexingByVectors(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIndexingByVectorsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIndexingByVectorsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }

    }

    public class RIndexingBasic : RASTComposite
    {
        public RIndexingBasic(RASTComposite parent) :
            base(NodeType.NT_EXPR_INDEXING_BASIC, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitIndexingBasic(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIndexingBasicIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIndexingBasicIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RSingleDoubleColonsOperators : RASTComposite
    {
        public RSingleDoubleColonsOperators(RASTComposite parent) :
            base(NodeType.NT_EXPR_SINGLE_DOUBLE_COLONS_OPERATORS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitSingleDoubleColonsOperators(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateSingleDoubleColonsOperatorsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateSingleDoubleColonsOperatorsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RDollarAtOperators : RASTComposite
    {
        public RDollarAtOperators(RASTComposite parent) :
            base(NodeType.NT_EXPR_DOLLAR_AT_OPERATORS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitDollarAtOperators(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateDollarAtOperatorsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateDollarAtOperatorsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RExponentiationBinary : RASTComposite
    {
        public RExponentiationBinary(RASTComposite parent) :
            base(NodeType.NT_EXPR_EXPONENTIATION_BINARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitExponentiationBinary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateExponentiationBinaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateExponentiationBinaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RMinusOrPlusUnary : RASTComposite
    {
        public RMinusOrPlusUnary(RASTComposite parent) :
            base(NodeType.NT_EXPR_MINUS_OR_PLUS_UNARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitMinusOrPlusUnary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateMinusOrPlusUnaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateMinusOrPlusUnaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RColonOperator : RASTComposite
    {
        public RColonOperator(RASTComposite parent) :
            base(NodeType.NT_EXPR_COLON_OPERATOR, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitColonOperator(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateColonOperatorIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateColonOperatorIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RWrappedWithPercent : RASTComposite
    {
        public RWrappedWithPercent(RASTComposite parent) :
            base(NodeType.NT_EXPR_WRAPPED_WITH_PERCENT, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitWrappedWithPercent(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateWhileIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateWrappedWithPercentIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RMultiplicationOrDivisionBinary : RASTComposite
    {
        public RMultiplicationOrDivisionBinary(RASTComposite parent) :
            base(NodeType.NT_EXPR_MULTIPLICATION_OR_DIVISION_BINARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitMultiplicationOrDivisionBinary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateMultiplicationOrDivisionBinaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateMultiplicationOrDivisionBinaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RMinusOrPlusBinary : RASTComposite
    {
        public RMinusOrPlusBinary(RASTComposite parent) :
            base(NodeType.NT_EXPR_MINUS_OR_PLUS_BINARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitMinusOrPlusBinary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateMinusOrPlusBinaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateMinusOrPlusBinaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RComparisons : RASTComposite
    {
        public RComparisons(RASTComposite parent) :
            base(NodeType.NT_EXPR_COMPARISONS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitComparisons(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateComparisonsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateComparisonsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RNotunary : RASTComposite
    {
        public RNotunary(RASTComposite parent) :
            base(NodeType.NT_EXPR_NOT_UNARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitNotunary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateNotUnaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateNotUnaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RAndBinary : RASTComposite
    {
        public RAndBinary(RASTComposite parent) :
            base(NodeType.NT_EXPR_AND_BINARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitAndBinary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAndBinaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAndBinaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class ROrBinary : RASTComposite
    {
        public ROrBinary(RASTComposite parent) :
            base(NodeType.NT_EXPR_OR_BINARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitOrBinary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateOrBinaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateOrBinaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RTildeUnary : RASTComposite
    {
        public RTildeUnary(RASTComposite parent) :
            base(NodeType.NT_EXPR_TILDE_UNARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitTildeUnary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateTildeUnaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateTildeUnaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RTildeBinary : RASTComposite
    {
        public RTildeBinary(RASTComposite parent) :
            base(NodeType.NT_EXPR_TILDE_BINARY, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitTildeBinary(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateTildeBinaryIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateTildeBinaryIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RASsignmentOpetators : RASTComposite
    {
        public RASsignmentOpetators(RASTComposite parent) :
            base(NodeType.NT_EXPR_ASSIGNMENT_OPETATORS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitAssignmentOpetators(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssignmentOpetatorsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssignmentOpetatorsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RDefineFunction : RASTComposite
    {
        public RDefineFunction(RASTComposite parent) :
            base(NodeType.NT_EXPR_DEFINE_FUNCTION, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitDefineFunction(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateDefineFunctionIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateDefineFunctionIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RCallFunction : RASTComposite
    {
        public RCallFunction(RASTComposite parent) :
            base(NodeType.NT_EXPR_CALL_FUNCTION, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitCallFunction(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateCallFunctionIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateCallFunctionIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RCompound : RASTComposite
    {
        public RCompound(RASTComposite parent) :
            base(NodeType.NT_EXPR_COMPOUND, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitCompound(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateCompoundIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateCompoundIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RIfStatement : RASTComposite
    {
        public RIfStatement(RASTComposite parent) :
            base(NodeType.NT_EXPR_IF_STATEMENT, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitIfStatement(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIfStatementIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIfStatementIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RIfElseStatement : RASTComposite
    {
        public RIfElseStatement(RASTComposite parent) :
            base(NodeType.NT_EXPR_IF_ELSE_STATEMENT, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitIfElseStatement(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIfElseStatementIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateIfElseStatementIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RFor : RASTComposite
    {
        public RFor(RASTComposite parent) :
            base(NodeType.NT_EXPR_FOR, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitFor(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateForIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateForIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RWhile : RASTComposite
    {
        public RWhile(RASTComposite parent) :
            base(NodeType.NT_EXPR_WHILE, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitWhile(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateWhileIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateWhileIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RRepeat : RASTComposite
    {
        public RRepeat(RASTComposite parent) :
            base(NodeType.NT_EXPR_REPEAT, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRepeat(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRepeatIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRepeatIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RHelp : RASTComposite
    {
        public RHelp(RASTComposite parent) :
            base(NodeType.NT_EXPR_HELP, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitHelp(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateHelpIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateHelpIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RHelpForMethods : RASTComposite
    {
        public RHelpForMethods(RASTComposite parent) :
            base(NodeType.NT_EXPR_HELP_FOR_METHODS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitHelpForMethods(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateHelpForMethodsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateHelpForMethodsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RNextStatement : RASTComposite
    {
        public RNextStatement(RASTComposite parent) :
            base(NodeType.NT_EXPR_NEXT_STATEMENT, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitNextStatement(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateNextStatementIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateNextStatementIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RBreakStatement : RASTComposite
    {
        public RBreakStatement(RASTComposite parent) :
            base(NodeType.NT_EXPR_BREAK_STATEMENT, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitBreakStatement(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateBreakStatementIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateBreakStatementIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class RParenthesis : RASTComposite
    {
        public RParenthesis(RASTComposite parent) :
            base(NodeType.NT_EXPR_PARENTHESIS, parent, NodeType.NT_EXPRESSION)
        {
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitParenthesis(this);
            else return visitor.VisitChildren(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateParenthesisIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateParenthesisIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    // Leafs...

    public class RIDENTIFIER : RASTLeaf<RASTElement>
    {
        public RIDENTIFIER(string idLiteral, RASTComposite parent) : base(idLiteral, NodeType.NT_ID, parent)
        {
            m_value = this;
            if (m_semanticValueConverter == null)
            {
                m_semanticValueConverter = TokenSemanticValueDefaultConverter.Create(this);
            }
        }

        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1 /*insert last by default*/)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitIDENTIFIER(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }

    public class RSTRING : RASTLeaf<string>
    {
        public class RSTRINGConverter : RTokenSemanticValueConverter<string>
        {

            /// <summary>
            ///  A converter between the string token and its semantic value. This
            /// is a singleton class that is, one for all RSTRING tokens
            /// Initializes a new instance of the <see cref="RSTRINGConverter"/> class.
            /// </summary>
            /// <param name="token">The token.</param>
            public RSTRINGConverter(RSTRING token) : base(token) { }
            public override string GetSemanticValue(string literal)
            {
                return literal;
            }

            public override string GetLiteral(string semanticValue)
            {
                return semanticValue;
            }
        }

        public RSTRING(string stringLiteral, RASTComposite parent) : base(stringLiteral, NodeType.NT_STRING, parent)
        {
            if (m_semanticValueConverter == null)
            {
                m_semanticValueConverter = new RSTRINGConverter(this);
            }
        }

        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitSTRING(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }

    public class RHEX : RASTLeaf<int> // here like string.
    {
        /// <summary>

        /// </summary>
        /// <seealso cref="int" />
        public class RHEXConverter : RTokenSemanticValueConverter<int>
        {

            public RHEXConverter(RHEX token) : base(token) { }
            public override int GetSemanticValue(string literal)
            {
                return Convert.ToInt32(literal, 16);
            }

            public override string GetLiteral(int semanticValue)
            {
                return string.Format("{0:X}", semanticValue);
            }
        }

        public RHEX(string hexLiteral, RASTComposite parent) : base(hexLiteral, NodeType.NT_HEX, parent)
        {
            if (m_semanticValueConverter == null)
            {
                m_semanticValueConverter = new RHEXConverter(this);
            }
        }

        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitHEX(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }

        public int M_Value
        {
            get { return m_value; }
        }
    }

    public class RINTEGER : RASTLeaf<int>
    {
        /// <summary>
        /// A converter between the integer token and its semantic value. This
        /// is a singleton class that is, one for all RINTEGER tokens
        /// </summary>
        /// <seealso cref="int" />
        public class RINTEGERConverter : RTokenSemanticValueConverter<int>
        {

            public RINTEGERConverter(RINTEGER token) : base(token) { }
            public override int GetSemanticValue(string literal)
            {
                return Int32.Parse(literal);
            }

            public override string GetLiteral(int semanticValue)
            {
                return semanticValue.ToString();
            }
        }

        public RINTEGER(string intLiteral, RASTComposite parent) : base(intLiteral, NodeType.NT_INT, parent)
        {
            if (m_semanticValueConverter == null)
            {
                m_semanticValueConverter = new RINTEGERConverter(this);
            }
        }

        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitINTEGER(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }

        public int M_Value
        {
            get { return m_value; }
        }
    }

    public class RFLOAT : RASTLeaf<float>
    {
        /// <summary>
        /// A converted to between the float token and its semantic value. This
        /// is a singleton class that is, one for all RFLOAT tokens
        /// </summary>
        /// <seealso cref="float" />
        public class RFLOATConverter : RTokenSemanticValueConverter<float>
        {

            public RFLOATConverter(RFLOAT token) : base(token) { }
            public override float GetSemanticValue(string literal)
            {
                return Single.Parse(literal);
            }

            public override string GetLiteral(float semanticValue)
            {
                return semanticValue.ToString();
            }
        }

        public RFLOAT(string floatLiteral, RASTComposite parent) : base(floatLiteral, NodeType.NT_FLOAT, parent)
        {
            if (m_semanticValueConverter == null)
            {
                m_semanticValueConverter = new RFLOATConverter(this);
            }
        }

        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1 /*insert last by default*/)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitFLOAT(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ImagePartNumber
    {
        [FieldOffsetAttribute(0)]
        public int num1;
        [FieldOffsetAttribute(0)]
        public float num2;
    }

    public class RCOMPLEX : RASTLeaf<ImagePartNumber>
    {
        /// <summary>

        /// </summary>
        /// <seealso cref="ImagePartNumber" />
        public class RCOMPLEXConverter : RTokenSemanticValueConverter<ImagePartNumber>
        {

            public RCOMPLEXConverter(RCOMPLEX token) : base(token) { }
            public override ImagePartNumber GetSemanticValue(string literal)
            {
                // ask here.
                ImagePartNumber imagePartNumber = new ImagePartNumber();

                int intValue;
                if (int.TryParse(literal, out intValue))
                {
                    imagePartNumber.num1 = intValue;
                    imagePartNumber.num2 = float.NaN;
                }

                float floatValue;
                if (float.TryParse(literal, out floatValue))
                {
                    imagePartNumber.num1 = -1;
                    imagePartNumber.num2 = floatValue;
                }

                return imagePartNumber;

            }

            public override string GetLiteral(ImagePartNumber semanticValue)
            {
                if (float.IsNaN(semanticValue.num2)) // if num2(float) is NaN -> only num1(int) exist.
                    return (semanticValue.num1).ToString();
                else // If num2(float) isn't NaN -> only num1(int) don't exist.
                    return (semanticValue.num2).ToString();
            }
        }

        public RCOMPLEX(string complexLiteral, RASTComposite parent) : base(complexLiteral, NodeType.NT_COMPLEX, parent)
        {
            if (m_semanticValueConverter == null)
            {
                m_semanticValueConverter = new RCOMPLEXConverter(this);
            }
        }

        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitCOMPLEX(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }

    }

    public class RLITERALSPECIFIER : RASTLeaf<LiteralSpecifier>
    {
        /// <summary>
        /// A converter between the integer token and its semantic value. This
        /// is a singleton class that is, one for all CINTEGER tokens
        /// </summary>
        /// <seealso cref="int" />
        public class RLITERALSPECIFIERConverter : RTokenSemanticValueConverter<LiteralSpecifier>
        {

            public RLITERALSPECIFIERConverter(RLITERALSPECIFIER token) : base(token) { }
            public override LiteralSpecifier GetSemanticValue(string literal)
            {
                return GetTypeSpecifier(literal);
            }

            public override string GetLiteral(LiteralSpecifier semanticValue)
            {
                return semanticValue.ToString();
            }
        }

        public RLITERALSPECIFIER(string litSpecifier, RASTComposite parent) : base(litSpecifier, NodeType.NT_LITERALSPECIFIER, parent)
        {
            m_value = GetTypeSpecifier(litSpecifier);
        }
        /// <summary>
        /// Literals do not implement this function because they do not have children
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="child">The child.</param>
        /// <param name="pos">The position.</param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void AddChild(RASTElement child, int context, int pos = -1 /*insert last by default*/)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(RASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitLITERALSPECIFIER(this);
            else return visitor.VisitTerminal(this);
        }

        public override RAbstractIterator<RASTElement> AcceptIterator(RASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override RAbstractIterator<RASTElement> AcceptEventIterator(RASTAbstractConcreteIteratorFactory iteratorFactory,
            RASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }

        private static LiteralSpecifier GetTypeSpecifier(string stringLiteral)
        {
            switch (stringLiteral)
            {
                case "NULL":
                    return LiteralSpecifier.LT_NULL;
                case "NA":
                    return LiteralSpecifier.LT_NA;
                case "NA_integer_":
                    return LiteralSpecifier.LT_NA_INTEGER;
                case "NA_real_":
                    return LiteralSpecifier.LT_NA_REAL;
                case "NA_complex_":
                    return LiteralSpecifier.LT_NA_COMPLEX;
                case "NA_character_":
                    return LiteralSpecifier.LT_NA_CHARACTER;
                case "Inf":
                    return LiteralSpecifier.LT_INF;
                case "NaN":
                    return LiteralSpecifier.LT_NAN;
                case "TRUE":
                    return LiteralSpecifier.LT_TRUE;
                case "FALSE":
                    return LiteralSpecifier.LT_FALSE;
                default:
                    throw new Exception("Non recognizable type specifier");
            }
        }
    }
}




