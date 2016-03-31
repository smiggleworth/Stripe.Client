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
    public class AccountBankAccountCreateArgumentsTests
    {
        private AccountBankAccountCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<AccountBankAccountCreateArguments>();
        }

        [TestMethod]
        public void AccountBankAccountCreateArguments_ExternalAccountIsRequired()
        {
            // Arrange 
            _args.BankAccountToken = null;
            _args.BankAccountCreateArguments = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void AccountBankAccountCreateArguments_BankAccountTokenTrumpsBankAccountCreateArguments()
        {
            // Arrange 
            _args.BankAccountCreateArguments = GenFu.GenFu.New<BankAccountCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "external_account" && x.Value == _args.BankAccountToken);
        }

        [TestMethod]
        public void AccountBankAccountCreateArguments_BankAccountCreateArguments()
        {
            // Arrange 
            _args.BankAccountToken = null;
            _args.BankAccountCreateArguments = GenFu.GenFu.New<BankAccountCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "external_account")
                .And.Contain(x => x.Key == "external_account[object]" && x.Value == "bank_account");
        }

        [TestMethod]
        public void AccountBankAccountCreateArguments_GetOtherKeys()
        {
            // Arrange 
            _args.DefaultForCurrency = true;
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(4)
                .And.Contain(x => x.Key == "external_account")
                .And.Contain(x => x.Key == "default_for_currency")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]");
        }
    }
}