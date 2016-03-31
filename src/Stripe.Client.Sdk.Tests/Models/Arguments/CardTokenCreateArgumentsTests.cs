using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;
using System;
using System.Linq;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class CardTokenCreateArgumentsTests
    {
        private CardTokenCreateArguments _args = new CardTokenCreateArguments();

        [TestMethod]
        public void CardTokenCreateArguments_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _args = new CardTokenCreateArguments();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void CardTokenCreateArguments_Customer()
        {
            // Arrange 
            _args.Customer = "customer 1";

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(1).And.Contain(x => x.Key == "customer");
        }

        [TestMethod]
        public void CardTokenCreateArguments_Card()
        {
            // Arrange 
            _args.Card = GenFu.GenFu.New<CardCreateArguments>();
            _args.Card.ExpMonth = 3;
            _args.Card.ExpYear = DateTime.UtcNow.Year;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(13)
                .And.Contain(x => x.Key == "card[address_city]")
                .And.Contain(x => x.Key == "card[address_line1]")
                .And.Contain(x => x.Key == "card[address_line2]")
                .And.Contain(x => x.Key == "card[address_state]")
                .And.Contain(x => x.Key == "card[address_zip]")
                .And.Contain(x => x.Key == "card[currency]")
                .And.Contain(x => x.Key == "card[cvc]")
                .And.Contain(x => x.Key == "card[exp_month]")
                .And.Contain(x => x.Key == "card[exp_year]")
                .And.Contain(x => x.Key == "card[name]")
                .And.Contain(x => x.Key == "card[number]")
                .And.Contain(x => x.Key == "card[object]");
        }
    }
}