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
    public class SubscriptionCreateArgumentsTests
    {
        private SubscriptionCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<SubscriptionCreateArguments>();
        }

        [TestMethod]
        public void SubscriptionCreateArguments_CustomerIdIsRequired()
        {
            // Arrange 
            _args.CustomerId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SubscriptionCreateArguments_PlanIsRequired()
        {
            // Arrange 
            _args.Plan = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SubscriptionCreateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "source" && x.Value == _args.CardToken);
        }

        [TestMethod]
        public void SubscriptionCreateArguments_CardCreateArguments()
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
        public void SubscriptionCreateArguments_SourceNotRequired()
        {
            // Arrange 
            _args.CardToken = null;
            _args.CardCreateArguments = null;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "source")
                .And.NotContain(x => x.Key == "source[object]");
        }

        [TestMethod]
        public void SubscriptionCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.ApplicationFeePercent = 1;
            _args.Metadata = Data.Metadata;
            _args.Quantity = 1;
            _args.TaxPercent = 8.2m;
            _args.TrialEnd = DateTime.UtcNow;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(9)
                .And.Contain(x => x.Key == "application_fee_percent")
                .And.Contain(x => x.Key == "coupon")
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