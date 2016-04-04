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
    public class SkuUpdateArgumentsTests
    {
        private SkuUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<SkuUpdateArguments>().Fill(x => x.Price, () => 1000);
            _args = GenFu.GenFu.New<SkuUpdateArguments>();
        }

        [TestMethod]
        public void SkuUpdateArguments_SkuIdIsRequired()
        {
            // Arrange 
             _args.SkuId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void SkuUpdateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;
            _args.PackageDimensions = GenFu.GenFu.New<PackageDimensions>();
            _args.Active = true;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(12)
                .And.Contain(x => x.Key == "active")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "image")
                .And.Contain(x => x.Key == "inventory")
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