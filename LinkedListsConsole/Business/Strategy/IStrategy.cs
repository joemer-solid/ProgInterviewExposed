using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListsConsole.Business.Strategy
{
    public interface IStrategy<T,P>
    {
        T Execute(P p);
    }
}
