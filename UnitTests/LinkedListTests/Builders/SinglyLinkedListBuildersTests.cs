using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using LinkedListsConsole.Elements;
using LinkedListsConsole.Builders;

namespace UnitTests.LinkedListTests.Builders
{
   
    public class SinglyLinkedListBuildersTests
    {
        [Fact]
        public void WhenDecimalTypeLinkedListBuilt_Then_RootListElementNotNullContainsOnly_N_ChildNodes()
        {
            // Setup
            decimal[] seedValues = new decimal[] { 1.23M, 2.34M, 3.35M };
            IEnumerable<decimal> rootList = LinkedListsTestsSetup.CreateRootNodeValueAndChildNodeValues<decimal>(seedValues);
            ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>> decimalTypeLinkedListBuilder = new SinglyLinkedListBuilder();

            // Arrange
            ListElement<decimal> decimalTypeLinkedList = decimalTypeLinkedListBuilder.Build(rootList);

            // Assert
            decimalTypeLinkedList.ShouldBeOfType<ListElement<decimal>>();
            decimalTypeLinkedList.ShouldNotBeNull();
            decimalTypeLinkedList.Value.ShouldBe(seedValues[0]);
            decimalTypeLinkedList.CountListElementNodes().ShouldBe(seedValues.Length);
          
        }
    }
}
