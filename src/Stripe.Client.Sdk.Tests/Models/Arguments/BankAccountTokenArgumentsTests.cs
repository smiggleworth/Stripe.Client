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
    public class BankAccountTokenArgumentsTests
    {
        private BankAccountTokenArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<BankAccountTokenArguments>();
        }

        [TestMethod]
        public void BankAccountTokenArguments_AccountNumberIsRequired()
        {
            // Arrange 
            _args.AccountNumber = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void BankAccountTokenArguments_CountryIsRequired()
        {
            // Arrange 
            _args.Country = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void BankAccountTokenArguments_CurrencyIsRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void BankAccountTokenArguments_GetAllKeys()
        {
            // Arrange 

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(6)
                .And.Contain(x => x.Key == "account_number")
                .And.Contain(x => x.Key == "country")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "account_holder_name")
                .And.Contain(x => x.Key == "account_holder_type")
                .And.Contain(x => x.Key == "routing_number");
        }
    }
}