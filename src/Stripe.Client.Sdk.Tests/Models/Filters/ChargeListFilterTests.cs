using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class ChargeListFilterTests
    {
        private ChargeListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<ChargeListFilter>();
        }

        [TestMethod]
        public void ChargeListFilter_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _filter = new ChargeListFilter();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void ChargeListFilter_CreatedDateTimeOverridesCreatedFilter()
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
        public void ChargeListFilter_CreatedFilter()
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
        public void ChargeListFilter_GetAllKeys()
        {
            // Arrange
            _filter.Limit = 10;
            _filter.Source = GenFu.GenFu.New<SourceObjectFilter>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(5)
                .And.Contain(x => x.Key == "customer")
                .And.Contain(x => x.Key == "source[object]")
                .And.Contain(x => x.Key == "ending_before")
                .And.Contain(x => x.Key == "starting_after")
                .And.Contain(x => x.Key == "limit");
        }
    }
}