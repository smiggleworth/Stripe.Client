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
    public class InvoiceCreateArgumentsTests
    {
        private InvoiceCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<InvoiceCreateArguments>();
        }

        [TestMethod]
        public void InvoiceCreateArguments_CustomerIdIsRequired()
        {
            // Arrange 
            _args.Customer = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void InvoiceCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;
            _args.ApplicationFee = 15;
            _args.TaxPercent = 16;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(8)
                .And.Contain(x => x.Key == "application_fee")
                .And.Contain(x => x.Key == "customer")
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "statement_descriptor")
                .And.Contain(x => x.Key == "subscription")
                .And.Contain(x => x.Key == "tax_percent");
        }
    }
}