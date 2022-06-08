using LinkedListsConsole.Builders;
using LinkedListsConsole.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestUnitTests.LinkedListTests.Setup;
using System.Collections.Generic;

namespace MSTestUnitTests.LinkedListTests.Builders
{
    [TestClass]
    public class SinglyLinkedListBuildersTests : TestBase
    {
        [TestMethod]
        public void WhenDecimalTypeLinkedListBuilt_Then_RootListElementNotNullContainsOnly_N_ChildNodes()
        {
            // Setup
            decimal[] seedValues = new decimal[] { 1.23M, 2.34M, 3.35M };
            IEnumerable<decimal> rootList = TestExtensions.CreateRootNodeValueAndChildNodeValues<decimal>(seedValues);
           
            // Arrange
            ListElement<decimal> decimalTypeLinkedList = Setup.DecimalBasedSinglyLinkedListBuilder.Build(rootList);

            // Assert
            Assert.IsNotNull(decimalTypeLinkedList);
            Assert.IsInstanceOfType(decimalTypeLinkedList, typeof(ListElement<decimal>));
            Assert.AreEqual<int>(seedValues.Length, decimalTypeLinkedList.CountListElementNodes());           

        }
    }
}
