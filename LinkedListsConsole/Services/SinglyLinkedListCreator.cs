using LinkedListsConsole.Builders;
using LinkedListsConsole.Business.Strategy;
using LinkedListsConsole.Elements;
using System;
using System.Collections.Generic;

namespace LinkedListsConsole.Services
{
    public sealed class SinglyLinkedListCreator : ISinglyLinkedListCreator<int> ,
        ISinglyLinkedListCreator<decimal>
    {
        #region Fields

        private readonly ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>> _integerBasedBuilder;
        private readonly ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>> _decimalBasedBuilder;
        private readonly IStrategy<int, ListElement<int>> _integerListElementNodeTotalValueCalculator;
        private readonly IStrategy<decimal, ListElement<decimal>> _decimalListElementNodeTotalValueCalculator;

        #endregion


        #region CTOR

        public SinglyLinkedListCreator(ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>> integerBasedBuilder,
            ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>  decimalBasedBuilder,
            IStrategy<int, ListElement<int>> integerListElementNodeTotalValueCalculator,
            IStrategy<decimal, ListElement<decimal>> decimalListElementNodeTotalValueCalculator)
        {
            _integerBasedBuilder = integerBasedBuilder ?? throw new ArgumentNullException(nameof(integerBasedBuilder));
            _decimalBasedBuilder = decimalBasedBuilder ?? throw new ArgumentNullException(nameof(decimalBasedBuilder));

            _integerListElementNodeTotalValueCalculator = integerListElementNodeTotalValueCalculator ?? throw new ArgumentNullException(nameof(integerListElementNodeTotalValueCalculator));
            _decimalListElementNodeTotalValueCalculator = decimalListElementNodeTotalValueCalculator ?? throw new ArgumentNullException(nameof(decimalListElementNodeTotalValueCalculator));
        }

        #endregion

        #region ISingleLinkedListCreator implementation

        ListElement<int> ISinglyLinkedListCreator<int>.Create(IEnumerable<int> baseElements)
            => _integerBasedBuilder.Build(baseElements);


        ListElement<decimal> ISinglyLinkedListCreator<decimal>.Create(IEnumerable<decimal> baseElements)
            => _decimalBasedBuilder.Build(baseElements);
       

        void ISinglyLinkedListCreator<int>.Traverse(ListElement<int> rootElement)
            => DisplayResults(rootElement, _integerListElementNodeTotalValueCalculator);


        void ISinglyLinkedListCreator<decimal>.Traverse(ListElement<decimal> rootElement)
            => DisplayResults(rootElement, _decimalListElementNodeTotalValueCalculator);

        #endregion


        private static void DisplayResults<T>(ListElement<T> rootElement, IStrategy<T, ListElement<T>> listElementNodeTotalValueCalculator)
        {
            Console.WriteLine(rootElement.ToString());
            Console.WriteLine($"TotalValue: {listElementNodeTotalValueCalculator.Execute(rootElement)}");
        }
    }
}
