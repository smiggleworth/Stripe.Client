using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class TransferCreateArgumentsTests
    {
        private TransferCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<TransferCreateArguments>().Fill(x => x.Amount, () => 100);
            _args = GenFu.GenFu.New<TransferCreateArguments>();
        }

        [TestMethod]
        public void TransferCreateArguments_CurrencyIsRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void TransferCreateArguments_DestinationIsRequired()
        {
            // Arrange 
            _args.Destination = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void TransferCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(9)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "destination")
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "source_transaction")
                .And.Contain(x => x.Key == "statement_descriptor")
                .And.Contain(x => x.Key == "source_type");
        }
    }
}