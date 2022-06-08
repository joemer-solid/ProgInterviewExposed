using LinkedListsConsole.Elements;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListsConsole.Builders
{
    public sealed class SinglyLinkedListBuilder : ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>>,
        ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>

    {

        ListElement<decimal> ILinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>.Build(IEnumerable<decimal> p)
            => BuildLinkedListElements<decimal>(p);
      

        ListElement<int> ILinkedListBuilder<ListElement<int>, IEnumerable<int>>.Build(IEnumerable<int> p)
         =>  BuildLinkedListElements<int>(p);

        

        private static ListElement<T> BuildLinkedListElements<T>(IEnumerable<T> linkedListElements)
        {
            ListElement<T> currentNode = null;
            ListElement<T> rootNode = null;

            linkedListElements.ToList().
                ForEach(p =>
                {
                    if (rootNode == null)
                    {
                        rootNode = CreateNode<T>(p);
                        currentNode = rootNode;
                    }
                    else
                    {
                        currentNode = CreateNode<T>(p, currentNode);
                    }
                });

            return rootNode;
        }

        private static ListElement<T> CreateNode<T>(T nodeValue, ListElement<T> currentNode = null)
        {
            ListElement<T> createdElement = new ListElement<T>(nodeValue);

            if(currentNode == null)
            {
                createdElement = new ListElement<T>(nodeValue);
            }
            else
            {
                currentNode.SetNext(createdElement);
            }

            return createdElement;

        }     
    }
}
