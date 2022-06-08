using LinkedListsConsole.Elements;
using System.Collections.Generic;
using System.Linq;

namespace MSTestUnitTests.LinkedListTests.Setup
{
    public static class TestExtensions
    {
        public static IEnumerable<T> CreateRootNodeValueAndChildNodeValues<T>(T[] valuesList)
        {
            IEnumerable<T> container = new List<T>();
            if (typeof(T).IsValueType)
            {

                container = valuesList.Select(element => element);
            }

            return container;

        }

        public static int CountListElementNodes<T>(this ListElement<T> linkedList)
        {
            int result = 0;

            if (linkedList != null)
            {
                result = 1;
                var nextElement = linkedList.Next;

                while (nextElement != null)
                {
                    result += 1;
                    nextElement = nextElement.Next;
                }
            }

            return result;
        }
    }
}
