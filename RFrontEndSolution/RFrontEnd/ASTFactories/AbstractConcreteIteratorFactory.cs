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
using RFrontEnd.ASTEvents;
using RFrontEnd.ASTIterator;

namespace RFrontEnd.ASTFactories
{
    public interface IASTAbstractConcreteIteratorFactory
    {

        #region Prog iterator
        RAbstractIterator<RASTElement> CreateProgIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateProgIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region IndexingByVectors iterator
        RAbstractIterator<RASTElement> CreateIndexingByVectorsIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateIndexingByVectorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region IndexingBasic  iterator
        RAbstractIterator<RASTElement> CreateIndexingBasicIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateIndexingBasicIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region SingleDoubleColonsOperators iterator
        RAbstractIterator<RASTElement> CreateSingleDoubleColonsOperatorsIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateSingleDoubleColonsOperatorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region DollarAtOperators iterator
        RAbstractIterator<RASTElement> CreateDollarAtOperatorsIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateDollarAtOperatorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion


        #region ExponentiationBinary iterator
        RAbstractIterator<RASTElement> CreateExponentiationBinaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateExponentiationBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region MinusOrPlusUnary iterator
        RAbstractIterator<RASTElement> CreateMinusOrPlusUnaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateMinusOrPlusUnaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region ColonOperator iterator
        RAbstractIterator<RASTElement> CreateColonOperatorIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateColonOperatorIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region WrappedWithPercent iterator
        RAbstractIterator<RASTElement> CreateWrappedWithPercentIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateWrappedWithPercentIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region MultiplicationOrDivisionBinary iterator
        RAbstractIterator<RASTElement> CreateMultiplicationOrDivisionBinaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateMultiplicationOrDivisionBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region MinusOrPlusBinary iterator
        RAbstractIterator<RASTElement> CreateMinusOrPlusBinaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateMinusOrPlusBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region Comparisons iterator
        RAbstractIterator<RASTElement> CreateComparisonsIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateComparisonsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion


        #region NotUnary iterator
        RAbstractIterator<RASTElement> CreateNotUnaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateNotUnaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region AndBinary iterator
        RAbstractIterator<RASTElement> CreateAndBinaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateAndBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region OrBinary iterator
        RAbstractIterator<RASTElement> CreateOrBinaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateOrBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region TildeUnary iterator
        RAbstractIterator<RASTElement> CreateTildeUnaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateTildeUnaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region TildeBinary iterator
        RAbstractIterator<RASTElement> CreateTildeBinaryIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateTildeBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region AssignmentOpetators iterator
        RAbstractIterator<RASTElement> CreateAssignmentOpetatorsIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateAssignmentOpetatorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion


        #region DefineFunction iterator
        RAbstractIterator<RASTElement> CreateDefineFunctionIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateDefineFunctionIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion


        #region CallFunction iterator
        RAbstractIterator<RASTElement> CreateCallFunctionIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateCallFunctionIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region Compound iterator
        RAbstractIterator<RASTElement> CreateCompoundIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateCompoundIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region IfStatement iterator
        RAbstractIterator<RASTElement> CreateIfStatementIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateIfStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region IfElseStatement iterator
        RAbstractIterator<RASTElement> CreateIfElseStatementIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateIfElseStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region For iterator
        RAbstractIterator<RASTElement> CreateForIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateForIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region While iterator
        RAbstractIterator<RASTElement> CreateWhileIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateWhileIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region Repeat iterator
        RAbstractIterator<RASTElement> CreateRepeatIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateRepeatIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region Help iterator
        RAbstractIterator<RASTElement> CreateHelpIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateHelpIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region HelpForMethods iterator
        RAbstractIterator<RASTElement> CreateHelpForMethodsIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateHelpForMethodsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region NextStatement iterator
        RAbstractIterator<RASTElement> CreateNextStatementIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateNextStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region BreakStatement iterator
        RAbstractIterator<RASTElement> CreateBreakStatementIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateBreakStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

        #region Parenthesis iterator
        RAbstractIterator<RASTElement> CreateParenthesisIterator(RASTElement element);

        RAbstractIterator<RASTElement> CreateParenthesisIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);
        #endregion

    }


    public class RASTAbstractConcreteIteratorFactory : RASTAbstractGenericIteratorFactory,
        IASTAbstractConcreteIteratorFactory
    {

        #region Prog iterator
        public virtual RAbstractIterator<RASTElement> CreateProgIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateProgIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region IndexingByVectors iterator
        public virtual RAbstractIterator<RASTElement> CreateIndexingByVectorsIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateIndexingByVectorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region IndexingBasic  iterator
        public virtual RAbstractIterator<RASTElement> CreateIndexingBasicIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateIndexingBasicIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region SingleDoubleColonsOperators iterator
        public virtual RAbstractIterator<RASTElement> CreateSingleDoubleColonsOperatorsIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateSingleDoubleColonsOperatorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region DollarAtOperators iterator
        public virtual RAbstractIterator<RASTElement> CreateDollarAtOperatorsIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateDollarAtOperatorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region ExponentiationBinary iterator
        public virtual RAbstractIterator<RASTElement> CreateExponentiationBinaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateExponentiationBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region MinusOrPlusUnary iterator
        public virtual RAbstractIterator<RASTElement> CreateMinusOrPlusUnaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateMinusOrPlusUnaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region ColonOperator iterator
        public virtual RAbstractIterator<RASTElement> CreateColonOperatorIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateColonOperatorIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region WrappedWithPercent iterator
        public virtual RAbstractIterator<RASTElement> CreateWrappedWithPercentIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateWrappedWithPercentIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region MultiplicationOrDivisionBinary iterator
        public virtual RAbstractIterator<RASTElement> CreateMultiplicationOrDivisionBinaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateMultiplicationOrDivisionBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region MinusOrPlusBinary iterator
        public virtual RAbstractIterator<RASTElement> CreateMinusOrPlusBinaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateMinusOrPlusBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region Comparisons iterator
        public virtual RAbstractIterator<RASTElement> CreateComparisonsIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateComparisonsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region NotUnary iterator
        public virtual RAbstractIterator<RASTElement> CreateNotUnaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateNotUnaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region AndBinary iterator
        public virtual RAbstractIterator<RASTElement> CreateAndBinaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateAndBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region OrBinary iterator
        public virtual RAbstractIterator<RASTElement> CreateOrBinaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateOrBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region TildeUnary iterator
        public virtual RAbstractIterator<RASTElement> CreateTildeUnaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateTildeUnaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region TildeBinary iterator
        public virtual RAbstractIterator<RASTElement> CreateTildeBinaryIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateTildeBinaryIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region AssignmentOpetators iterator
        public virtual RAbstractIterator<RASTElement> CreateAssignmentOpetatorsIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateAssignmentOpetatorsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region DefineFunction iterator
        public virtual RAbstractIterator<RASTElement> CreateDefineFunctionIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateDefineFunctionIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region CallFunction iterator
        public virtual RAbstractIterator<RASTElement> CreateCallFunctionIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateCallFunctionIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region Compound iterator
        public virtual RAbstractIterator<RASTElement> CreateCompoundIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateCompoundIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region IfStatement iterator
        public virtual RAbstractIterator<RASTElement> CreateIfStatementIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateIfStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region IfElseStatement iterator
        public virtual RAbstractIterator<RASTElement> CreateIfElseStatementIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateIfElseStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region For iterator
        public virtual RAbstractIterator<RASTElement> CreateForIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateForIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region While iterator
        public virtual RAbstractIterator<RASTElement> CreateWhileIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateWhileIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region Repeat iterator
        public virtual RAbstractIterator<RASTElement> CreateRepeatIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateRepeatIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

        #region Help iterator
        public virtual RAbstractIterator<RASTElement> CreateHelpIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateHelpIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region HelpForMethods iterator
        public virtual RAbstractIterator<RASTElement> CreateHelpForMethodsIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateHelpForMethodsIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region NextStatement iterator
        public virtual RAbstractIterator<RASTElement> CreateNextStatementIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateNextStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region BreakStatement iterator
        public virtual RAbstractIterator<RASTElement> CreateBreakStatementIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateBreakStatementIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion


        #region Parenthesis iterator
        public virtual RAbstractIterator<RASTElement> CreateParenthesisIterator(RASTElement element)
        {
            return CreateIteratorASTElementDescentantsFlatten(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateParenthesisIteratorEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return CreateIteratorASTElementDescentantsFlattenEvents(element, events, info);
        }
        #endregion

    }
}
