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
    public class OrderCreateArgumentsTests
    {
        private OrderCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<OrderItemCreateArguments>().Fill(x => x.Amount, () => 0);
            GenFu.GenFu.Configure<AddressArguments>().Fill(x => x.Country, () => "US");
            _args = GenFu.GenFu.New<OrderCreateArguments>();
        }

        [TestMethod]
        public void OrderCreateArguments_CurrencyIsRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void OrderCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Shipping = GenFu.GenFu.New<ShippingArguments>();
            _args.Shipping.Address = GenFu.GenFu.New<AddressArguments>();
            _args.Items = GenFu.GenFu.ListOf<OrderItemCreateArguments>(2);
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(27)
                .And.Contain(x => x.Key == "coupon")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "customer")
                .And.Contain(x => x.Key == "email")
                .And.Contain(x => x.Key == "items[0][amount]")
                .And.Contain(x => x.Key == "items[0][currency]")
                .And.Contain(x => x.Key == "items[0][description]")
                .And.Contain(x => x.Key == "items[0][parent]")
                .And.Contain(x => x.Key == "items[0][quantity]")
                .And.Contain(x => x.Key == "items[0][type]")
                .And.Contain(x => x.Key == "items[1][amount]")
                .And.Contain(x => x.Key == "items[1][currency]")
                .And.Contain(x => x.Key == "items[1][description]")
                .And.Contain(x => x.Key == "items[1][parent]")
                .And.Contain(x => x.Key == "items[1][quantity]")
                .And.Contain(x => x.Key == "items[1][type]")
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
                .And.Contain(x => x.Key == "shipping[phone]");
        }
    }
}