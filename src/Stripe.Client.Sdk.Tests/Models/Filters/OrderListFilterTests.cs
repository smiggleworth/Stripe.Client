using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class OrderListFilterTests
    {
        private OrderListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<OrderListFilter>();
        }

        [TestMethod]
        public void OrderListFilter_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _filter = new OrderListFilter();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void OrderListFilter_CreatedDateTimeOverridesCreatedFilter()
        {
            // Arrange
            _filter.CreatedDateTime = DateTime.UtcNow;
            _filter.CreatedFilter = Data.DateFilter;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "created")
                .And.NotContain(x => x.Key == "created[gt]")
                .And.NotContain(x => x.Key == "created[gte]")
                .And.NotContain(x => x.Key == "created[lt]")
                .And.NotContain(x => x.Key == "created[lte]");
        }

        [TestMethod]
        public void OrderListFilter_CreatedFilter()
        {
            // Arrange
            _filter.CreatedDateTime = null;
            _filter.CreatedFilter = Data.DateFilter;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "created")
                .And.Contain(x => x.Key == "created[gt]")
                .And.Contain(x => x.Key == "created[gte]")
                .And.Contain(x => x.Key == "created[lt]")
                .And.Contain(x => x.Key == "created[lte]");
        }

        [TestMethod]
        public void OrderListFilter_CancelledDateTimeOverridesCancelledFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                CancelledDateTime = DateTime.UtcNow,
                CancelledFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "status_transitions[cancelled]")
                .And.NotContain(x => x.Key == "status_transitions[cancelled][gt]")
                .And.NotContain(x => x.Key == "status_transitions[cancelled][gte]")
                .And.NotContain(x => x.Key == "status_transitions[cancelled][lt]")
                .And.NotContain(x => x.Key == "status_transitions[cancelled][lte]");
        }

        [TestMethod]
        public void OrderListFilter_CancelledFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                CancelledDateTime = null,
                CancelledFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "status_transitions[cancelled]")
                .And.Contain(x => x.Key == "status_transitions[cancelled][gt]")
                .And.Contain(x => x.Key == "status_transitions[cancelled][gte]")
                .And.Contain(x => x.Key == "status_transitions[cancelled][lt]")
                .And.Contain(x => x.Key == "status_transitions[cancelled][lte]");
        }

        [TestMethod]
        public void OrderListFilter_FulfilledDateTimeOverridesFulfilledFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                FulfilledDateTime = DateTime.UtcNow,
                FulfilledFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "status_transitions[fulfilled]")
                .And.NotContain(x => x.Key == "status_transitions[fulfilled][gt]")
                .And.NotContain(x => x.Key == "status_transitions[fulfilled][gte]")
                .And.NotContain(x => x.Key == "status_transitions[fulfilled][lt]")
                .And.NotContain(x => x.Key == "status_transitions[fulfilled][lte]");
        }

        [TestMethod]
        public void OrderListFilter_FulfilledFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                FulfilledDateTime = null,
                FulfilledFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "status_transitions[fulfilled]")
                .And.Contain(x => x.Key == "status_transitions[fulfilled][gt]")
                .And.Contain(x => x.Key == "status_transitions[fulfilled][gte]")
                .And.Contain(x => x.Key == "status_transitions[fulfilled][lt]")
                .And.Contain(x => x.Key == "status_transitions[fulfilled][lte]");
        }

        [TestMethod]
        public void OrderListFilter_PaidDateTimeOverridesPaidFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                PaidDateTime = DateTime.UtcNow,
                PaidFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "status_transitions[paid]")
                .And.NotContain(x => x.Key == "status_transitions[paid][gt]")
                .And.NotContain(x => x.Key == "status_transitions[paid][gte]")
                .And.NotContain(x => x.Key == "status_transitions[paid][lt]")
                .And.NotContain(x => x.Key == "status_transitions[paid][lte]");
        }

        [TestMethod]
        public void OrderListFilter_PaidFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                PaidDateTime = null,
                PaidFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "status_transitions[paid]")
                .And.Contain(x => x.Key == "status_transitions[paid][gt]")
                .And.Contain(x => x.Key == "status_transitions[paid][gte]")
                .And.Contain(x => x.Key == "status_transitions[paid][lt]")
                .And.Contain(x => x.Key == "status_transitions[paid][lte]");
        }

        [TestMethod]
        public void OrderListFilter_ReturnedDateTimeOverridesReturnedFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                ReturnedDateTime = DateTime.UtcNow,
                ReturnedFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "status_transitions[returned]")
                .And.NotContain(x => x.Key == "status_transitions[returned][gt]")
                .And.NotContain(x => x.Key == "status_transitions[returned][gte]")
                .And.NotContain(x => x.Key == "status_transitions[returned][lt]")
                .And.NotContain(x => x.Key == "status_transitions[returned][lte]");
        }

        [TestMethod]
        public void OrderListFilter_ReturnedFilter()
        {
            // Arrange
            _filter.StatusTransitions = new StatusTransitionFilter
            {
                ReturnedDateTime = null,
                ReturnedFilter = Data.DateFilter
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "status_transitions[returned]")
                .And.Contain(x => x.Key == "status_transitions[returned][gt]")
                .And.Contain(x => x.Key == "status_transitions[returned][gte]")
                .And.Contain(x => x.Key == "status_transitions[returned][lt]")
                .And.Contain(x => x.Key == "status_transitions[returned][lte]");
        }

        [TestMethod]
        public void OrderListFilter_GetAllKeys()
        {
            // Arrange
            _filter.Limit = 10;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "customer")
                .And.Contain(x => x.Key == "ending_before")
                .And.Contain(x => x.Key == "starting_after")
                .And.Contain(x => x.Key == "limit")
                .And.HaveCount(4);
        }
    }
}