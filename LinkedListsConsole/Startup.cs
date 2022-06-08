using LinkedListsConsole.Builders;
using LinkedListsConsole.Elements;
using LinkedListsConsole.Services;
using LinkedListsConsole.Business.Strategy;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace LinkedListsConsole
{
    public class Startup
    {       

        public static void ConfigureServices(IServiceCollection services)
        {
            // Configure services here 
            services.AddScoped<ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>, SinglyLinkedListBuilder>();
            services.AddScoped<ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>>, SinglyLinkedListBuilder>();

           
            services.AddScoped<IStrategy<decimal, ListElement<decimal>>, NumericListElementNodeTotalValueCalculator>();
            services.AddScoped<IStrategy<int, ListElement<int>>, NumericListElementNodeTotalValueCalculator>();

            services.AddScoped<ISinglyLinkedListCreator<int>, SinglyLinkedListCreator>();
            services.AddScoped<ISinglyLinkedListCreator<decimal>, SinglyLinkedListCreator>();
        }
    }
}
