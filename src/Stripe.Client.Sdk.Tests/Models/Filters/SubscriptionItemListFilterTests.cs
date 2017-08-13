using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class SubscriptionItemListFilterTests
    {
        private SubscriptionItemListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<SubscriptionItemListFilter>();
        }

        [TestMethod]
        public void SubscriptionItemListFilter_GetAllKeys()
        {
            // Arrange
            _filter.Limit = 10;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs<SubscriptionItemListFilter>(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(4)
                         .And.Contain(x => x.Key == "subscription")
                         .And.Contain(x => x.Key == "ending_before")
                         .And.Contain(x => x.Key == "starting_after")
                         .And.Contain(x => x.Key == "limit");
        }
    }
}