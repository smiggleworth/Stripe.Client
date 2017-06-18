using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class AccountUpdateArgumentsWithBankAccountTests
    {
        private AccountUpdateArguments<BankAccountCreateArguments> _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<AccountUpdateArguments<BankAccountCreateArguments>>();
        }

        [TestMethod]
        public void AccountUpdateArguments_BankAccountTokenTrumpsBankAccountCreateArguments()
        {
            // Arrange 
            _args.ExternalAccountCreateArguments = GenFu.GenFu.New<BankAccountCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "external_account" && x.Value == _args.Token);
        }

        [TestMethod]
        public void AccountUpdateArguments_BankAccountCreateArguments()
        {
            // Arrange 
            _args.Token = null;
            _args.ExternalAccountCreateArguments = GenFu.GenFu.New<BankAccountCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "external_account")
                         .And.Contain(x => x.Key == "external_account[object]" && x.Value == "bank_account");
        }
    }
}