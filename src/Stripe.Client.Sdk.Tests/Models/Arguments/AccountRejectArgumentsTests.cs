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
    public class AccountRejectArgumentsTests
    {
        private AccountRejectArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<AccountRejectArguments>();
        }

        [TestMethod]
        public void AccountRejectArguments_AccountIdIsRequired()
        {
            // Arrange 
            _args.AccountId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void AccountRejectArguments_ReasonIsRequired()
        {
            // Arrange 
            _args.Reason = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void AccountRejectArguments_GetAllKeys()
        {
            // Arrange 

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(1).And.Contain(x => x.Key == "reason");
        }
    }
}