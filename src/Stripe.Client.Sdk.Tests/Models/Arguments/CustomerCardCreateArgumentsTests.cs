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
    public class CustomerCardCreateArgumentsTests
    {
        private CustomerCardCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<CustomerCardCreateArguments>();
        }

        [TestMethod]
        public void CustomerCardCreateArguments_SourceIsRequired()
        {
            // Arrange 
            _args.CardToken = null;
            _args.CardCreateArguments = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CustomerCardCreateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "source" && x.Value == _args.CardToken);
        }

        [TestMethod]
        public void CustomerCardCreateArguments_CardCreateArguments()
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
        public void CustomerCardCreateArguments_GetOtherKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                .And.Contain(x => x.Key == "source")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]");
        }
    }
}