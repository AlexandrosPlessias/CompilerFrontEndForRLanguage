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
using RFrontEnd.ASTEvents;
using RFrontEnd.ASTFactories;
using RFrontEnd.ASTIterator;

namespace RFrontEnd.ASTVisitor
{
    /// <summary>
    /// A visitor class referring to an AST composite structure with a top
    /// level hierarchy class of type T and Visit methods returning type
    /// "Return"
    /// </summary>
    /// <typeparam name="Return">The return type of the Visit methods.</typeparam>
    public class RASTAbstractVisitor<Return>
    {

        private RASTGenericIteratorEvents m_events;

        private IAbstractASTIteratorsFactory m_iteratorFactory;

        public RASTAbstractVisitor(IAbstractASTIteratorsFactory iteratorFactory = null, RASTGenericIteratorEvents events = null)
        {
            if (iteratorFactory == null)
            {
                m_iteratorFactory = new RASTAbstractConcreteIteratorFactory();
            }
            else
            {
                m_iteratorFactory = iteratorFactory;
            }
            if (events == null)
            {
                m_events = new RASTGenericIteratorEvents();
            }
            else
            {
                m_events = events;
            }

        }

        /// <summary>
        /// <c>VisitChildren</c> method is used to visit child nodes of the node given
        /// as a parameter. This method provides default functionality for
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <returns></returns>
        public virtual Return VisitChildren(RASTElement currentNode)
        {

            RAbstractIterator<RASTElement> it = m_iteratorFactory.CreateIteratorASTElementDescentantsFlatten(currentNode);

            // Call Accept to all children of the current node
            for (it.ItBegin(); !it.ItEnd(); it.ITNext())
            {
                it.M_item.AcceptVisitor(this);
            }

            return default(Return);
        }

        /// <summary>
        /// Visits the children of the specified context in the currentNode
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <returns></returns>
        public virtual Return VisitContext(RASTElement currentNode, ContextType context)
        {

            RAbstractIterator<RASTElement> it = m_iteratorFactory.CreateIteratorASTElementDescentantsContext(currentNode);

            // Call Accept to all children in the specified context of the current node
            for (it.ItBegin(context); !it.ItEnd(); it.ITNext())
            {
                it.M_item.AcceptVisitor(this);
            }

            return default(Return);
        }

        public virtual Return VisitContextEvents(RASTElement currentNode, ContextType context)
        {

            RAbstractIterator<RASTElement> it = m_iteratorFactory.CreateIteratorASTElementDescentantsContextEvents(currentNode, m_events, this);

            // Call Accept to all children in the specified context of the current node
            for (it.ItBegin(context); !it.ItEnd(); it.ITNext())
            {
                it.M_item.AcceptVisitor(this);
            }

            return default(Return);
        }

        /// <summary>
        /// Visits the children of the specified node <c>current</c> raising events
        /// at specific sequence points determined by the iterator
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <returns></returns>
        public virtual Return VisitChildrenEvents(RASTElement currentNode)
        {
            RAbstractIterator<RASTElement> it =
                m_iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(currentNode, m_events, this);

            // Call Accept to all children of the current node
            for (it.ItBegin(); !it.ItEnd(); it.ITNext())
            {
                it.M_item.AcceptVisitor(this);
            }

            return default(Return);
        }

        /// <summary>
        /// Visits the specified node by calling its Accept function. The method
        /// can be used to start a new traversal from the specified node
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public virtual Return Visit(RASTElement node)
        {
            // Call Accept of the specific node
            return node.AcceptVisitor<Return>(this);
        }


        /// <summary>
        /// Visits the terminal. It doen't go any further since this is a leaf node
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public virtual Return VisitTerminal(RASTElement node)
        {
            return default(Return);
        }

    }
}
