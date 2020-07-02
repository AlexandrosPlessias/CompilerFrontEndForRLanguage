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
    public interface IAbstractASTIteratorsFactory
    {

        RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsFlatten(RASTElement element);

        RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsFlattenEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);

        RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsContext(RASTElement element);

        RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsContextEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null);

    }

    public abstract class RASTAbstractGenericIteratorFactory : IAbstractASTIteratorsFactory
    {
        public virtual RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsFlatten(RASTElement element)
        {
            return new RASTElementDescentantsFlattenIterator(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsFlattenEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return new RASTElementDescentantsFlattenEventIterator(element, events, info);
        }

        public virtual RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsContext(RASTElement element)
        {
            return new RASTElementDescentantsContextIterator(element);
        }

        public virtual RAbstractIterator<RASTElement> CreateIteratorASTElementDescentantsContextEvents(RASTElement element,
            RASTGenericIteratorEvents events, object info = null)
        {
            return new RASTElementDescentantsContextEventIterator(element, events, info);
        }
    }
}
