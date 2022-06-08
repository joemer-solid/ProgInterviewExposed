using LinkedListsConsole.Elements;

namespace LinkedListsConsole.Business.Strategy
{
    public class NumericListElementNodeTotalValueCalculator : IStrategy<int, ListElement<int>>
        , IStrategy<decimal, ListElement<decimal>>
    {
        decimal IStrategy<decimal, ListElement<decimal>>.Execute(ListElement<decimal> p)
        {
            decimal total = p.Value;

            var nextElement = p.Next;

            while (nextElement != null)
            {
                total += nextElement.Value;
                nextElement = nextElement.Next;
            }

            return total;
        }

        int IStrategy<int, ListElement<int>>.Execute(ListElement<int> p)
        {           
            int total = p.Value;

            var nextElement = p.Next;

            while (nextElement != null)
            {
                total += nextElement.Value;
                nextElement = nextElement.Next;
            }

            return total;
        }
    }
}
