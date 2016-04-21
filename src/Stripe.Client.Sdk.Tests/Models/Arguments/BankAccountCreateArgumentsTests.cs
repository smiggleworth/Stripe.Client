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
    public class BankAccountCreateArgumentsTests
    {
        private BankAccountCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<BankAccountCreateArguments>();
        }

        [TestMethod]
        public void BankAccountCreateArguments_AccountNumberIsRequired()
        {
            // Arrange 
            _args.AccountNumber = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void BankAccountCreateArguments_CountryIsRequired()
        {
            // Arrange 
            _args.Country = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void BankAccountCreateArguments_CurrencyIsRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void BankAccountCreateArguments_GetAllKeys()
        {
            // Arrange 

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(7)
                .And.Contain(x => x.Key == "object" && x.Value == "bank_account")
                .And.Contain(x => x.Key == "account_number")
                .And.Contain(x => x.Key == "country")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "account_holder_name")
                .And.Contain(x => x.Key == "account_holder_type")
                .And.Contain(x => x.Key == "routing_number");
        }
    }
}