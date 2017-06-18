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
    public class OrderUpdateArgumentsTests
    {
        private OrderUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<OrderUpdateArguments>();
        }

        [TestMethod]
        public void OrderUpdateArguments_OrderIdIsRequired()
        {
            // Arrange 
            _args.OrderId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void OrderUpdateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(5)
                         .And.Contain(x => x.Key == "coupon")
                         .And.Contain(x => x.Key == "metadata[key1]")
                         .And.Contain(x => x.Key == "metadata[key2]")
                         .And.Contain(x => x.Key == "selected_shipping_method")
                         .And.Contain(x => x.Key == "status");
        }
    }
}