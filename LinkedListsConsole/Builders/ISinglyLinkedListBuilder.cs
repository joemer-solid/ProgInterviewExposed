using LinkedListsConsole.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListsConsole.Builders
{
    public interface ISinglyLinkedListBuilder<T, P> : ILinkedListBuilder<T, P>// where T : ListElement<T>
       // where P : IEnumerable<P>
    { }
    
}
