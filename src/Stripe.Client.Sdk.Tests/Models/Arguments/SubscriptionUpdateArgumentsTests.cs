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
    public class SubscriptionUpdateArgumentsTests
    {
        private SubscriptionUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<SubscriptionUpdateArguments>();
        }

        [TestMethod]
        public void SubscriptionUpdateArguments_CustomerIdIsRequired()
        {
            // Arrange 
            _args.CustomerId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SubscriptionUpdateArguments_SubscriptionIdIsRequired()
        {
            // Arrange 
            _args.SubscriptionId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SubscriptionUpdateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "source" && x.Value == _args.CardToken);
        }

        [TestMethod]
        public void SubscriptionUpdateArguments_CardCreateArguments()
        {
            // Arrange 
            _args.CardToken = null;
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();
            _args.CardCreateArguments.ExpMonth = 10;
            _args.CardCreateArguments.ExpYear = DateTime.UtcNow.Year;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "source")
                         .And.Contain(x => x.Key == "source[object]" && x.Value == "card");
        }

        [TestMethod]
        public void SubscriptionUpdateArguments_GetAllKeys()
        {
            // Arrange 
            _args.ApplicationFeePercent = 1;
            _args.Metadata = Data.Metadata;
            _args.Quantity = 1;
            _args.TaxPercent = 8.2m;
            _args.TrialEnd = DateTime.UtcNow;
            _args.ProrationDate = DateTime.UtcNow;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(11)
                         .And.Contain(x => x.Key == "application_fee_percent")
                         .And.Contain(x => x.Key == "coupon")
                         .And.Contain(x => x.Key == "prorate")
                         .And.Contain(x => x.Key == "proration_date")
                         .And.Contain(x => x.Key == "metadata[key1]")
                         .And.Contain(x => x.Key == "metadata[key2]")
                         .And.Contain(x => x.Key == "plan")
                         .And.Contain(x => x.Key == "quantity")
                         .And.Contain(x => x.Key == "source")
                         .And.Contain(x => x.Key == "tax_percent")
                         .And.Contain(x => x.Key == "trial_end");
        }
    }
}