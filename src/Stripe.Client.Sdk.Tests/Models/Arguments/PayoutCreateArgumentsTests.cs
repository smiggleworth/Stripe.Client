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
    public class PayoutCreateArgumentsTests
    {
        private PayoutCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<PayoutCreateArguments>().Fill(x => x.Amount, 1333);
            _args = GenFu.GenFu.New<PayoutCreateArguments>();
        }

        [TestMethod]
        public void PayoutCreateArguments_CurrencyRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void OrderPayArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(9)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "destination")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "method")
                .And.Contain(x => x.Key == "source_type")
                .And.Contain(x => x.Key == "statement_descriptor");
        }
    }
}