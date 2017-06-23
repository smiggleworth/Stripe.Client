using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class TransferListFilterTests
    {
        private TransferListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<TransferListFilter>();
        }

        [TestMethod]
        public void TransferListFilter_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _filter = new TransferListFilter();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void TransferListFilter_CreatedDateTimeOverridesCreatedFilter()
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
        public void TransferListFilter_CreatedFilter()
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
        public void TransferListFilter_TransferDateTimeOverridesCreatedFilter()
        {
            // Arrange
            _filter.TransferDateTime = DateTime.UtcNow;
            _filter.TransferDateFilter = Data.DateFilter;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "date")
                .And.NotContain(x => x.Key == "date[gt]")
                .And.NotContain(x => x.Key == "date[gte]")
                .And.NotContain(x => x.Key == "date[lt]")
                .And.NotContain(x => x.Key == "date[lte]");
        }


        [TestMethod]
        public void TransferListFilter_TransferDateFilter()
        {
            // Arrange
            _filter.TransferDateTime = null;
            _filter.TransferDateFilter = Data.DateFilter;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "date")
                .And.Contain(x => x.Key == "date[gt]")
                .And.Contain(x => x.Key == "date[gte]")
                .And.Contain(x => x.Key == "date[lt]")
                .And.Contain(x => x.Key == "date[lte]");
        }

        [TestMethod]
        public void TransferListFilter_GetAllKeys()
        {
            // Arrange
            _filter.Limit = 10;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "recipient")
                .And.Contain(x => x.Key == "destination")
                .And.Contain(x => x.Key == "status")
                .And.Contain(x => x.Key == "ending_before")
                .And.Contain(x => x.Key == "starting_after")
                .And.Contain(x => x.Key == "limit")
                .And.HaveCount(6);
        }
    }
}