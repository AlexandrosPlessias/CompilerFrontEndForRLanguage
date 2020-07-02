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

namespace RFrontEnd.ASTEvents
{
    /// <summary>
    /// Event handler signature
    /// </summary>
    /// <typeparam name="T">The type of AST node element</typeparam>
    /// <param name="current">The current.</param>
    /// <param name="args">The <see cref="RASTIteratorEventArgs" /> instance containing the event data.</param>
    public delegate void RSTVisitorEventHandler(RASTElement current, RASTVisitorEventArgs args);

    /// <summary>
    /// Event handler information
    /// </summary>
    public class RASTVisitorEventArgs
    {


    }

    /// <summary>
    /// <c>CASTAbstractIteratorEvents</c> class holds the events raised during the visitor
    /// traversal in the composite structure.
    /// </summary>
    public class RASTGenericIteratorEvents
    {

        protected event RSTVisitorEventHandler m_OnNodeEnter;

        protected event RSTVisitorEventHandler m_OnNodeLeave;

        protected event RSTVisitorEventHandler m_OnContextEnter;

        protected event RSTVisitorEventHandler m_OnContextLeave;

        public RASTGenericIteratorEvents() { }


        public virtual void OnNodeEnter(RASTElement node, RASTVisitorEventArgs args)
        {
            m_OnNodeEnter?.Invoke(node, args);
        }
        public virtual void OnNodeLeave(RASTElement node, RASTVisitorEventArgs args)
        {
            m_OnNodeLeave?.Invoke(node, args);
        }
        public virtual void OnContextEnter(RASTElement node, RASTVisitorEventArgs args)
        {
            m_OnContextEnter?.Invoke(node, args);
        }
        public virtual void OnContextLeave(RASTElement node, RASTVisitorEventArgs args)
        {
            m_OnContextLeave?.Invoke(node, args);
        }

    }
}
