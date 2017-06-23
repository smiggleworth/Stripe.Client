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
    public class AccountCreateArgumentsTests
    {
        private AccountCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<AccountCreateArguments>();
        }

        [TestMethod]
        public void AccountCreateArguments_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _args = new AccountCreateArguments();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [Ignore]
        [TestMethod]
        public void CrateAccountArguments_RequiresValidEmail()
        {
            var args = new AccountCreateArguments
            {
                Email = "notvalidemail"
            };

            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(args);
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void AccountCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Type = "standard";

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                .And.Contain(x => x.Key == "country")
                .And.Contain(x => x.Key == "email")
                .And.Contain(x => x.Key == "type");
        }
    }
}