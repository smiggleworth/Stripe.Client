using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [TestClass]
    public class AccountListFilterTests
    {
        private AccountListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<AccountListFilter>();
        }

        [TestMethod]
        public void AccountListFilter_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _filter = new AccountListFilter();

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_filter);

            // Assert
            func.Enumerating().ShouldNotThrow();
        }

        [TestMethod]
        public void AccountListFilter_GetAllKeys()
        {
            // Arrange
            _filter.Limit = 10;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                .And.Contain(x => x.Key == "ending_before")
                .And.Contain(x => x.Key == "starting_after")
                .And.Contain(x => x.Key == "limit");
        }
    }
}