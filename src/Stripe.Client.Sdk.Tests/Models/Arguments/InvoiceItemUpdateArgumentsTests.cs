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
    public class InvoiceItemUpdateArgumentsTests
    {
        private InvoiceItemUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<InvoiceItemUpdateArguments>();
        }

        [TestMethod]
        public void InvoiceItemUpdateArguments_InvoiceItemIdIsRequired()
        {
            // Arrange 
            _args.InvoiceItemId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void InvoiceItemUpdateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Amount = 100;
            _args.Discountable = false;
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(5)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "discountable")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]");
        }
    }
}