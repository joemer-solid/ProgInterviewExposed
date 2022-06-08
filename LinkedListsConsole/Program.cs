using LinkedListsConsole.Elements;
using LinkedListsConsole.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace LinkedListsConsole
{
    internal class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            _serviceProvider = ConfigureServices();

            TestSinglyLinkedList(new decimal[] { 11.23M, 22.00M, 33.33M, 44.00M, 55.01M, 66.77M });

            TestSinglyLinkedList(new int[] { 11, 22, 33, 44, 55, 66 });

            _ = Console.Read();
        }      

        private static void TestSinglyLinkedList(IEnumerable<int> nodeValues)
        {
            ISinglyLinkedListCreator<int> creator = _serviceProvider.GetService(typeof(ISinglyLinkedListCreator<int>)) as ISinglyLinkedListCreator<int>;
            ListElement<int> listElementRoot = creator.Create(nodeValues);
            creator.Traverse(listElementRoot);       
        }

        private static void TestSinglyLinkedList(IEnumerable<decimal> nodeValues)
        {
            ISinglyLinkedListCreator<decimal> creator = _serviceProvider.GetService(typeof(ISinglyLinkedListCreator<decimal>)) as ISinglyLinkedListCreator<decimal>;
            ListElement<decimal> listElementRoot = creator.Create(nodeValues);
            creator.Traverse(listElementRoot);
        }
   
        private static ServiceProvider ConfigureServices()
        {  
            var serviceProvider = new ServiceCollection();
            Startup.ConfigureServices(serviceProvider);
            return serviceProvider.BuildServiceProvider();
        }     
    }
}
