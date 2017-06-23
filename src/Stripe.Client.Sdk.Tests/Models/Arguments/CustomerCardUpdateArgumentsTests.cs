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
    public class CustomerCardUpdateArgumentsTests
    {
        private CustomerCardUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<CustomerCardUpdateArguments>();
        }

        [TestMethod]
        public void CustomerCardUpdateArguments_CardIdIsRequired()
        {
            // Arrange 
            _args.CardId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CustomerCardUpdateArguments_AccountIdIsRequired()
        {
            // Arrange 
            _args.CustomerId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void CustomerCardUpdateArguments_GetOtherKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(11)
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "address_city")
                .And.Contain(x => x.Key == "address_line1")
                .And.Contain(x => x.Key == "address_line2")
                .And.Contain(x => x.Key == "address_state")
                .And.Contain(x => x.Key == "address_zip")
                .And.Contain(x => x.Key == "exp_month")
                .And.Contain(x => x.Key == "exp_year")
                .And.Contain(x => x.Key == "name");
        }
    }
}