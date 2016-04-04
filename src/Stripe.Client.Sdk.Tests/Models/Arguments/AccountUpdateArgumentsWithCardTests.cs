using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;
using System;
using System.Linq;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class AccountUpdateArgumentsWithCardTests
    {
        private AccountUpdateArguments<CardCreateArguments> _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<AccountUpdateArguments<CardCreateArguments>>();
        }

        [TestMethod]
        public void AccountUpdateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.ExternalAccountCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "external_account" && x.Value == _args.Token);
        }

        [TestMethod]
        public void AccountUpdateArguments_CardCreateArguments()
        {
            // Arrange 
            _args.Token = null;
            _args.ExternalAccountCreateArguments = GenFu.GenFu.New<CardCreateArguments>();
            _args.ExternalAccountCreateArguments.ExpMonth = DateTime.UtcNow.Month;
            _args.ExternalAccountCreateArguments.ExpYear = DateTime.UtcNow.Year;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "external_account")
                .And.Contain(x => x.Key == "external_account[object]" && x.Value == "card");
        }
    }
}