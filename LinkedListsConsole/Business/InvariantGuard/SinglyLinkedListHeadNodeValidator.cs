using LinkedListsConsole.Elements;

namespace LinkedListsConsole.Business.InvariantGuard
{
    public sealed class SinglyLinkedListHeadNodeValidator : ISinglyLinkedListHeadNodeValidator
    {       
        bool ISinglyLinkedListHeadNodeValidator.IsValid<T>(ListElement<T> singlyLinkedList)
        {
            bool isValid = false;

            if (singlyLinkedList != null && singlyLinkedList.IsHead == true)
            {
                var nextElement = singlyLinkedList.Next;

                while (nextElement != null)
                {
                    isValid = !nextElement.IsHead;
                    nextElement = nextElement.Next;
                }
            }

            return isValid;
        }
    }
}
