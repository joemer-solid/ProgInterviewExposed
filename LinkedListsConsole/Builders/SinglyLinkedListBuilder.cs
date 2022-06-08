using LinkedListsConsole.Business.InvariantGuard;
using LinkedListsConsole.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListsConsole.Builders
{
    public sealed class SinglyLinkedListBuilder : ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>>,
        ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>
       
    {
        private readonly ISinglyLinkedListHeadNodeValidator _listHeadNodeValidator;

        public SinglyLinkedListBuilder(ISinglyLinkedListHeadNodeValidator listHeadNodeValidator)
        {
            _listHeadNodeValidator = listHeadNodeValidator ?? throw new ArgumentNullException(nameof(listHeadNodeValidator));
        }

        #region Builder Interface Implementation

        ListElement<decimal> ILinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>.Build(IEnumerable<decimal> p)
        {
            ListElement<decimal> singlyLinkedList = BuildLinkedListElements(p);

            return BuildIsValid(singlyLinkedList, _listHeadNodeValidator) ? singlyLinkedList : throw new ApplicationException("Linked List Build Invalid");
        }
      

        ListElement<int> ILinkedListBuilder<ListElement<int>, IEnumerable<int>>.Build(IEnumerable<int> p)
        {
            ListElement<int> singlyLinkedList = BuildLinkedListElements(p);

            return BuildIsValid(singlyLinkedList, _listHeadNodeValidator) ? singlyLinkedList : throw new ApplicationException("Linked List Build Invalid");
        }        

        #endregion       

        private static ListElement<T> BuildLinkedListElements<T>(IEnumerable<T> linkedListElements)
        {
            ListElement<T> currentNode = null;
            ListElement<T> rootNode = null;

            linkedListElements.ToList().
                ForEach(p =>
                {
                    if (rootNode == null)
                    {
                        rootNode = CreateNode(p, null, true);
                        currentNode = rootNode;
                    }
                    else
                    {
                        currentNode = CreateNode(p, currentNode);
                    }
                });

            return rootNode;
        }

        private static bool BuildIsValid<T>(ListElement<T> singlyLinkedList, ISinglyLinkedListHeadNodeValidator listHeadNodeValidator)
            => listHeadNodeValidator.IsValid(singlyLinkedList);

        private static ListElement<T> CreateNode<T>(T nodeValue, ListElement<T> currentNode = null, bool isHead = false)
        {
            ListElement<T> createdElement = new ListElement<T>(nodeValue,isHead);

            if(currentNode == null)
            {
                createdElement = new ListElement<T>(nodeValue, isHead);
            }
            else
            {
                currentNode.SetNext(createdElement);
            }

            return createdElement;

        }     
    }
}
