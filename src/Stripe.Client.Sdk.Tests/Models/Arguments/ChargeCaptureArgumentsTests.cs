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
    public class ChargeCaptureArgumentsTests
    {
        private ChargeCaptureArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<ChargeCaptureArguments>();
        }

        [TestMethod]
        public void ChargeCaptureArguments_ChargeIdIsRequired()
        {
            // Arrange 
             _args.ChargeId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void ChargeCaptureArguments_GetAllKeys()
        {
            // Arrange 
            _args.Amount = 10;
            _args.ApplicationFee = 19;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(4)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "application_fee")
                .And.Contain(x => x.Key == "receipt_email")
                .And.Contain(x => x.Key == "statement_descriptor");
        }
    }
}