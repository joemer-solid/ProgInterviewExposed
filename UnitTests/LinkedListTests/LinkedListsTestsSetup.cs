using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LinkedListsConsole.Elements;

namespace UnitTests.LinkedListTests
{
    public static class LinkedListsTestsSetup
    {
        public static IEnumerable<T> CreateRootNodeValueAndChildNodeValues<T>(T[] valuesList)
        {
            IEnumerable<T> container = new List<T>();
            if(typeof(T).IsValueType)
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
                var nextElement = linkedList.Next;

                while (nextElement != null)
                {
                    result = +1;                   
                }
            }

            return result;
        }
    }
}
