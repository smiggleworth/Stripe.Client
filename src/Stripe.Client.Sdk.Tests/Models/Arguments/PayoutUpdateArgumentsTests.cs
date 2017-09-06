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
    public class PayoutUpdateArgumentsTests
    {
        private PayoutUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<PayoutUpdateArguments>();
        }

        [TestMethod]
        public void PayoutCreateArguments_PayoutRequired()
        {
            // Arrange 
            _args.Id = null;

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
            keyValuePairs.Should().HaveCount(2)
                         .And.Contain(x => x.Key == "metadata[key1]")
                         .And.Contain(x => x.Key == "metadata[key2]");
        }
    }
}