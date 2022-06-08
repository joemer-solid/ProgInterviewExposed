using LinkedListsConsole.Builders;
using LinkedListsConsole.Business.Strategy;
using LinkedListsConsole.Elements;
using LinkedListsConsole.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MSTestUnitTests.LinkedListTests.Setup
{
    public sealed class LinkedListsTestsSetup
    {       
     
        public LinkedListsTestsSetup()
            => Initialize(SetupServices());


        #region Properties

        public ISinglyLinkedListCreator<int> IntegerBasedSinglyLinkedListCreator { get; private set; }      

        public IStrategy<int, ListElement<int>> IntegerBasedLinkedListTotalValueCalculator { get; private set; }       

        public ISinglyLinkedListCreator<decimal> DecimalBasedSinglyLinkedListCreator { get; private set; }       

        public IStrategy<decimal, ListElement<decimal>> DecimalBasedLinkedListTotalValueCalculator { get; private set; }

        public ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>> DecimalBasedSinglyLinkedListBuilder { get; private set; }

        public ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>> IntegerBasedSinglyLinkedListBuilder { get; private set; }


        #endregion

        #region Methods

        private void Initialize(ServiceProvider serviceProvider)
        {
            IntegerBasedSinglyLinkedListCreator = (ISinglyLinkedListCreator<int>)serviceProvider.GetRequiredService(typeof(ISinglyLinkedListCreator<int>));
            DecimalBasedSinglyLinkedListCreator = (ISinglyLinkedListCreator<decimal>)serviceProvider.GetRequiredService(typeof(ISinglyLinkedListCreator<decimal>));
            IntegerBasedLinkedListTotalValueCalculator = (IStrategy<int, ListElement<int>>)serviceProvider.GetRequiredService(typeof(IStrategy<int, ListElement<int>>));
            DecimalBasedLinkedListTotalValueCalculator = (IStrategy<decimal, ListElement<decimal>>)serviceProvider.GetRequiredService(typeof(IStrategy<decimal, ListElement<decimal>>));
            DecimalBasedSinglyLinkedListBuilder = 
                (ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>)serviceProvider.GetRequiredService(typeof(ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>));
            IntegerBasedSinglyLinkedListBuilder =
               (ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>>)serviceProvider.GetRequiredService(typeof(ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>>));
        }

        private ServiceProvider SetupServices()
        {
            IServiceCollection services = new ServiceCollection();
            // Configure services here 
            services.AddScoped<ISinglyLinkedListBuilder<ListElement<decimal>, IEnumerable<decimal>>, SinglyLinkedListBuilder>();
            services.AddScoped<ISinglyLinkedListBuilder<ListElement<int>, IEnumerable<int>>, SinglyLinkedListBuilder>();

            services.AddScoped<IStrategy<decimal, ListElement<decimal>>, NumericListElementNodeTotalValueCalculator>();
            services.AddScoped<IStrategy<int, ListElement<int>>, NumericListElementNodeTotalValueCalculator>();

            services.AddScoped<ISinglyLinkedListCreator<int>, SinglyLinkedListCreator>();
            services.AddScoped<ISinglyLinkedListCreator<decimal>, SinglyLinkedListCreator>();

            return services.BuildServiceProvider();             
        }

        #endregion
    }
}
