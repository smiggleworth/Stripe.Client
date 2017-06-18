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
    public class CustomerUpdateArgumentsTests
    {
        private CustomerUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<CustomerUpdateArguments>();
        }

        [TestMethod]
        public void CustomerUpdateArguments_CustomerIdIsRequired()
        {
            // Arrange 
            _args.CustomerId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CustomerCardCreateArguments_CardTokenTrumpsCardCreateArguments()
        {
            // Arrange 
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "source" && x.Value == _args.CardToken);
        }

        [TestMethod]
        public void CustomerCardCreateArguments_CardCreateArguments()
        {
            // Arrange 
            _args.CardToken = null;
            _args.CardCreateArguments = GenFu.GenFu.New<CardCreateArguments>();
            _args.CardCreateArguments.ExpMonth = 10;
            _args.CardCreateArguments.ExpYear = DateTime.UtcNow.Year;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().NotContain(x => x.Key == "source")
                         .And.Contain(x => x.Key == "source[object]" && x.Value == "card");
        }

        [TestMethod]
        public void CustomerUpdateArguments_GetOtherKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;
            _args.Shipping = GenFu.GenFu.New<ShippingArguments>();
            _args.Shipping.Address = GenFu.GenFu.New<AddressArguments>();
            _args.Shipping.Address.Country = "US";

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(16)
                         .And.Contain(x => x.Key == "coupon")
                         .And.Contain(x => x.Key == "default_source")
                         .And.Contain(x => x.Key == "description")
                         .And.Contain(x => x.Key == "email")
                         .And.Contain(x => x.Key == "metadata[key1]")
                         .And.Contain(x => x.Key == "metadata[key2]")
                         .And.Contain(x => x.Key == "shipping[address][city]")
                         .And.Contain(x => x.Key == "shipping[address][country]")
                         .And.Contain(x => x.Key == "shipping[address][line1]")
                         .And.Contain(x => x.Key == "shipping[address][line2]")
                         .And.Contain(x => x.Key == "shipping[address][postal_code]")
                         .And.Contain(x => x.Key == "shipping[address][state]")
                         .And.Contain(x => x.Key == "shipping[address][town]")
                         .And.Contain(x => x.Key == "shipping[name]")
                         .And.Contain(x => x.Key == "shipping[phone]")
                         .And.Contain(x => x.Key == "source");
        }
    }
}