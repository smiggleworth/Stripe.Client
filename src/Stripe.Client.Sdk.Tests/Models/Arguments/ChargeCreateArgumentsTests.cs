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
    public class ChargeCreateArgumentsTests
    {
        private ChargeCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<ChargeCreateArguments>().Fill(x => x.Amount, () => 100);
            _args = GenFu.GenFu.New<ChargeCreateArguments>();
        }

        [TestMethod]
        public void ChargeCreateArguments_CurrencyIsRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void ChargeCreateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "source" && x.Value == _args.CardToken);
        }

        [TestMethod]
        public void ChargeCreateArguments_CardCreateArguments()
        {
            // Arrange 
            _args.CardToken = null;
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();
            _args.CardCreateArguments.ExpMonth = 10;
            _args.CardCreateArguments.ExpYear = DateTime.UtcNow.Year;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "source")
                .And.Contain(x => x.Key == "source[object]" && x.Value == "card");
        }

        [TestMethod]
        public void ChargeCreateArguments_ApplicationFeeWhenSet()
        {
            // Arrange 
            _args.ApplicationFee = 1;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "application_fee");
        }

        [TestMethod]
        public void ChargeCreateArguments_CatureWhenSet()
        {
            // Arrange 
            _args.Capture = false;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "capture");
        }

        [TestMethod]
        public void ChargeCreateArguments_ShippingWhenSet()
        {
            // Arrange 
            _args.Shipping = GenFu.GenFu.New<ShippingArguments>();
            _args.Shipping.Address = GenFu.GenFu.New<AddressArguments>();
            _args.Shipping.Address.Country = "US";

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "shipping[address][city]")
                .And.Contain(x => x.Key == "shipping[address][country]")
                .And.Contain(x => x.Key == "shipping[address][line1]")
                .And.Contain(x => x.Key == "shipping[address][line2]")
                .And.Contain(x => x.Key == "shipping[address][postal_code]")
                .And.Contain(x => x.Key == "shipping[address][state]")
                .And.Contain(x => x.Key == "shipping[name]")
                .And.Contain(x => x.Key == "shipping[phone]");
        }


        [TestMethod]
        public void ChargeCreateArguments_GetOtherKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(10)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "destination")
                .And.Contain(x => x.Key == "source")
                .And.Contain(x => x.Key == "customer")
                .And.Contain(x => x.Key == "receipt_email")
                .And.Contain(x => x.Key == "statement_descriptor");
        }
    }
}