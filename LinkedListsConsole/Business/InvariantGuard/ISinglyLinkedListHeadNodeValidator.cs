using LinkedListsConsole.Elements;

namespace LinkedListsConsole.Business.InvariantGuard
{
    public interface ISinglyLinkedListHeadNodeValidator 
    {
        bool IsValid<T>(ListElement<T> singlyLinkedList);
    }
}
