using LinkedListsConsole.Business.Strategy;
using LinkedListsConsole.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestUnitTests.LinkedListTests.Setup;
using System.Linq;

namespace MSTestUnitTests.LinkedListTests.Strategies
{
    [TestClass]
    public class ElementNodeTotalValueCalculatorTests : TestBase
    {

        [TestMethod]
        public void WhenCalculatingIntegerValue_Then_TotalValueEquals_TotalsNodesValuesAsInteger()
        {
            // Setup  
            int[] seedValues = new int[] { 5,10,15 };
            ListElement<int> rootNodeLinkedList = Setup.IntegerBasedSinglyLinkedListCreator.Create(TestExtensions.CreateRootNodeValueAndChildNodeValues(seedValues));

            // Arrange
            IStrategy<int, ListElement<int>> linkedListCalculator = Setup.IntegerBasedLinkedListTotalValueCalculator;    

            // Assert
            int totalCalculatedValue = linkedListCalculator.Execute(rootNodeLinkedList);

            Assert.AreEqual(seedValues.ToList().Aggregate((n1,n2) => n1 + n2), totalCalculatedValue);
        }

        [TestMethod]
        public void WhenCalculatingDecimalValue_Then_TotalValueEquals_TotalsNodesValuesAsDecimal()
        {
            // Setup  
            decimal[] seedValues = new decimal[] { 5.10M, 10.25M, 15.33M };
            ListElement<decimal> rootNodeLinkedList = Setup.DecimalBasedSinglyLinkedListCreator.Create(TestExtensions.CreateRootNodeValueAndChildNodeValues(seedValues));

            // Arrange
            IStrategy<decimal, ListElement<decimal>> linkedListCalculator = Setup.DecimalBasedLinkedListTotalValueCalculator;

            // Assert
            decimal totalCalculatedValue = linkedListCalculator.Execute(rootNodeLinkedList);

            Assert.AreEqual(seedValues.ToList().Aggregate((n1, n2) => n1 + n2), totalCalculatedValue);
        }
    }
}
