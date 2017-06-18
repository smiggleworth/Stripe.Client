using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class SubscriptionCancelArgumentsTests
    {
        private SubscriptionCancelArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<SubscriptionCancelArguments>();
        }

        [TestMethod]
        public void SubscriptionCancelArguments_CustomerIdIsRequired()
        {
            // Arrange 
            _args.CustomerId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SubscriptionCancelArguments_SubscriptionIdIsRequired()
        {
            // Arrange 
            _args.SubscriptionId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SubscriptionCancelArguments_GetAllKeys()
        {
            // Arrange 
            _args.AtPeriodEnd = true;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(1).And.Contain(x => x.Key == "at_period_end");
        }
    }
}