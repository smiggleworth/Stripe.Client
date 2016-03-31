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
    public class DateOfBirthArgumentsTests
    {
        private DateOfBirthArguments _args = new DateOfBirthArguments();

        [TestMethod]
        public void DateOfBirthArguments_YearIsRequired()
        {
            // Arrange 
            //_args.Year = 1978;
            _args.Month = 10;
            _args.Day = 21;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void DateOfBirthArguments_MonthIsRequired()
        {
            // Arrange 
            _args.Year = 1978;
            //_args.Month = 10;
            _args.Day = 21;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void DateOfBirthArguments_DayIsRequired()
        {
            // Arrange 
            _args.Year = 1978;
            _args.Month = 10;
            //_args.Day = 21;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }



        [TestMethod]
        public void DateOfBirthArguments_GetAllKeys()
        {
            // Arrange 
            _args.Year = 1978;
            _args.Month = 10;
            _args.Day = 21;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                .And.Contain(x => x.Key == "day")
                .And.Contain(x => x.Key == "month")
                .And.Contain(x => x.Key == "year");
        }
    }
}