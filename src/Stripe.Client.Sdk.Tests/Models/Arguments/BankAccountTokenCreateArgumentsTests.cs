using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class BankAccountTokenCreateArgumentsTests
    {
        private BankAccountTokenCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<BankAccountTokenCreateArguments>();
        }

        [TestMethod]
        public void BankAccountTokenArguments_GetAllKeys()
        {
            // Arrange 
            _args.BankAccount = GenFu.GenFu.New<BankAccountTokenArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(7)
                         .And.Contain(x => x.Key == "bank_account[account_number]")
                         .And.Contain(x => x.Key == "bank_account[country]")
                         .And.Contain(x => x.Key == "bank_account[currency]")
                         .And.Contain(x => x.Key == "bank_account[account_holder_name]")
                         .And.Contain(x => x.Key == "bank_account[account_holder_type]")
                         .And.Contain(x => x.Key == "bank_account[routing_number]")
                         .And.Contain(x => x.Key == "customer");
        }
    }
}