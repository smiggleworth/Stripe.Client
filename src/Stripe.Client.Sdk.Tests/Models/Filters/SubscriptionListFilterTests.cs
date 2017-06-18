using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class SubscriptionListFilterTests
    {
        private SubscriptionListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<SubscriptionListFilter>();
        }

        [TestMethod]
        public void ActiveSubscriptionListFilter_GetAllKeys()
        {
            // Arrange
            _filter.Limit = 10;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(6)
                         .And.Contain(x => x.Key == "customer")
                         .And.Contain(x => x.Key == "plan")
                         .And.Contain(x => x.Key == "status")
                         .And.Contain(x => x.Key == "ending_before")
                         .And.Contain(x => x.Key == "starting_after")
                         .And.Contain(x => x.Key == "limit");
        }
    }
}