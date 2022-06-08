using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListsConsole.Business.InvariantGuard
{
    public interface IValidator<T,P>
    {
        T IsValid(P p);
    }
}
