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
    public class CardCreateArgumentsTests
    {
        private CardCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<CardCreateArguments>();
        }

        [TestMethod]
        public void CardCreateArguments_ExpMonthIsLessThanOne()
        {
            // Arrange 
            _args.ExpMonth = 0;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CardCreateArguments_ExpMonthIsLessGreaterThanTwelve()
        {
            // Arrange 
            _args.ExpMonth = 13;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CardCreateArguments_ExpYearIsLessGreaterThan1970()
        {
            // Arrange 
            _args.ExpMonth = 1969;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CardCreateArguments_NumberIsRequired()
        {
            // Arrange 
            _args.Number = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void CardCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.ExpMonth = 2;
            _args.ExpYear = 2012;
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args, "external_account").ToList();

            // Assert
            keyValuePairs.Should().HaveCount(15)
                .And.Contain(x => x.Key == "external_account[address_city]")
                .And.Contain(x => x.Key == "external_account[address_line1]")
                .And.Contain(x => x.Key == "external_account[address_line2]")
                .And.Contain(x => x.Key == "external_account[address_state]")
                .And.Contain(x => x.Key == "external_account[address_zip]")
                .And.Contain(x => x.Key == "external_account[currency]")
                .And.Contain(x => x.Key == "external_account[cvc]")
                .And.Contain(x => x.Key == "external_account[exp_month]")
                .And.Contain(x => x.Key == "external_account[exp_year]")
                .And.Contain(x => x.Key == "external_account[metadata][key1]")
                .And.Contain(x => x.Key == "external_account[metadata][key2]")
                .And.Contain(x => x.Key == "external_account[name]")
                .And.Contain(x => x.Key == "external_account[number]")
                .And.Contain(x => x.Key == "external_account[object]");
        }
    }
}