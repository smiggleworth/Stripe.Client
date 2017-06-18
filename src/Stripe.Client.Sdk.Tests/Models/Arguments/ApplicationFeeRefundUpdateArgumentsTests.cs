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
    public class ApplicationFeeRefundUpdateArgumentsTests
    {
        private ApplicationFeeRefundUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<ApplicationFeeRefundUpdateArguments>();
        }

        [TestMethod]
        public void ApplicationFeeRefundUpdateArguments_ApplicationFeeIdIsRequired()
        {
            // Arrange 
            _args.ApplicationFeeId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void ApplicationFeeRefundUpdateArguments_ApplicationFeeRefundIdIsRequired()
        {
            // Arrange 
            _args.ApplicationFeeRefundId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void ApplicationFeeRefundUpdateArguments_GetAllKeys()
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