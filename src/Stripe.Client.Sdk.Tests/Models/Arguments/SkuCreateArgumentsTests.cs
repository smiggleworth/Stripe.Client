using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using GenFu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute.Routing.Handlers;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class SkuCreateArgumentsTests
    {
        private SkuCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<SkuCreateArguments>().Fill(x => x.Price, () => 1000);
            _args = GenFu.GenFu.New<SkuCreateArguments>();
        }

        [TestMethod]
        public void SkuCreateArguments_CurrencyIsRequired()
        {
            // Arrange 
            _args.Currency = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SkuCreateArguments_InventoryIsRequired()
        {
            // Arrange 
            _args.Inventory = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void SkuCreateArguments_ProductIsRequired()
        {
            // Arrange 
            _args.Product = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SkuCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;
            _args.Inventory = GenFu.GenFu.New<InventoryArguments>();
            _args.PackageDimensions = GenFu.GenFu.New<PackageDimensionArguments>();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(14)
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "image")
                .And.Contain(x => x.Key == "id")
                .And.Contain(x => x.Key == "inventory[quantity]")
                .And.Contain(x => x.Key == "inventory[type]")
                .And.Contain(x => x.Key == "inventory[value]")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "package_dimensions[height]")
                .And.Contain(x => x.Key == "package_dimensions[length]")
                .And.Contain(x => x.Key == "package_dimensions[weight]")
                .And.Contain(x => x.Key == "package_dimensions[width]")
                .And.Contain(x => x.Key == "price")
                .And.Contain(x => x.Key == "product");
        }
    }
}