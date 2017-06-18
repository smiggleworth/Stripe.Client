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
    public class ApplicationFeeRefundCreateArgumentsTests
    {
        private ApplicationFeeRefundCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<ApplicationFeeRefundCreateArguments>().Fill(x => x.Amount, () => 100);
            _args = GenFu.GenFu.New<ApplicationFeeRefundCreateArguments>();
        }

        [TestMethod]
        public void ApplicationFeeRefundCreateArguments_ApplicationFeeIsRequired()
        {
            // Arrange 
            _args.ApplicationFeeId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void ApplicationFeeRefundCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                         .And.Contain(x => x.Key == "amount")
                         .And.Contain(x => x.Key == "metadata[key1]")
                         .And.Contain(x => x.Key == "metadata[key1]");
        }
    }
}