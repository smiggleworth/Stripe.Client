using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class PayoutListFilterTests
    {
        private PayoutListFilter _filter;

        [TestMethod]
        public void SubscriptionItemListFilter_GetAllKeys()
        {
            // Arrange
            _filter = GenFu.GenFu.New<PayoutListFilter>();
            _filter.Limit = 10;
            _filter.CreatedFilter = GenFu.GenFu.New<DateFilter>();
            _filter.CreatedDateTime = DateTime.UtcNow;
            _filter.ArrivalDateFilter = GenFu.GenFu.New<DateFilter>();
            _filter.ArrivalDateTime = DateTime.UtcNow;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(7)
                         .And.Contain(x => x.Key == "arrival_date")
                         .And.Contain(x => x.Key == "created")
                         .And.Contain(x => x.Key == "destination")
                         .And.Contain(x => x.Key == "ending_before")
                         .And.Contain(x => x.Key == "limit")
                         .And.Contain(x => x.Key == "starting_after")
                         .And.Contain(x => x.Key == "status");
        }
    }
}