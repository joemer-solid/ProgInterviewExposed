using LinkedListsConsole.Elements;
using System.Collections.Generic;

namespace LinkedListsConsole.Services
{
    public interface ISinglyLinkedListCreator<T>
    {
        public ListElement<T> Create(IEnumerable<T> baseElements);

        public void Traverse(ListElement<T> rootElement);
    }
}
