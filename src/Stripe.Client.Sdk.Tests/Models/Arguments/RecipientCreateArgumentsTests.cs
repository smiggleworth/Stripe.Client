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
    public class RecipientCreateArgumentsTests
    {
        private RecipientCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<RecipientCreateArguments>();
        }

        [TestMethod]
        public void RecipientCreateArguments_NameIsRequired()
        {
            // Arrange 
            _args.Name = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void RecipientCreateArguments_TypeIsRequired()
        {
            // Arrange 
            _args.Type = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void RecipientCreateArguments_BankAccountTokenTrumpsBankAccountCreateArguments()
        {
            // Arrange 
            _args.RecipientBankAccountArguments = GenFu.GenFu.New<RecipientBankAccountArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "bank_account" && x.Value == _args.BankAccountToken);
        }

        [TestMethod]
        public void RecipientCreateArguments_BankAccountCreateArguments()
        {
            // Arrange 
            _args.BankAccountToken = null;
            _args.RecipientBankAccountArguments = GenFu.GenFu.New<RecipientBankAccountArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "bank_account")
                .And.Contain(x => x.Key == "bank_account[account_number]")
                .And.Contain(x => x.Key == "bank_account[country]")
                .And.Contain(x => x.Key == "bank_account[routing_number]");
        }

        [TestMethod]
        public void RecipientCreateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "card" && x.Value == _args.CardToken);
        }

        [TestMethod]
        public void RecipientCreateArguments_CardCreateArguments()
        {
            // Arrange 
            _args.CardToken = null;
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();
            _args.CardCreateArguments.ExpMonth = 2;
            _args.CardCreateArguments.ExpYear = 2012;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "card")
                .And.Contain(x => x.Key == "card[object]" && x.Value == "card");
        }

        [TestMethod]
        public void RecipientCreateArguments_GetOtherKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(9)
                .And.Contain(x => x.Key == "bank_account")
                .And.Contain(x => x.Key == "card")
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "email")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "tax_id")
                .And.Contain(x => x.Key == "name")
                .And.Contain(x => x.Key == "type");
        }
    }
}