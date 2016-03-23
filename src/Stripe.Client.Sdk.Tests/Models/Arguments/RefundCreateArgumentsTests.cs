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
    public class RefundCreateArgumentsTests
    {
        private RefundCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<RefundCreateArguments>();
        }

        [TestMethod]
        public void RefundCreateArguments_ChargeIdIsRequired()
        {
            // Arrange 
             _args.ChargeId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void RefundCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Amount = 1;
            _args.Metadata = Data.Metadata;
            _args.RefundApplicationFee = true;
            _args.ReverseTransfer = true;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(6)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "reason")
                .And.Contain(x => x.Key == "refund_application_fee")
                .And.Contain(x => x.Key == "reverse_transfer");
        }
    }
}