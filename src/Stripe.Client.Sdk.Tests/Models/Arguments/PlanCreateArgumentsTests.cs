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
    public class PlanCreateArgumentsTests
    {
        private PlanCreateArguments _args = new PlanCreateArguments();

        [TestMethod]
        public void PlanCreateArguments_IdIsRequired()
        {
            // Arrange 
            // _args.Id = "Plan Id";
            _args.Amount = 1;
            _args.Currency = "USD";
            _args.Interval = "month";
            _args.Name = "Generic Plan";

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void PlanCreateArguments_NameIsRequired()
        {
            // Arrange 
            _args.Id = "Plan Id";
            _args.Amount = 1;
            _args.Currency = "USD";
            _args.Interval = "month";
            //_args.Name = "Generic Plan";

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void PlanCreateArguments_IntervalIsRequired()
        {
            // Arrange 
            _args.Id = "Plan Id";
            _args.Amount = 1;
            _args.Currency = "USD";
            //_args.Interval = "month";
            _args.Name = "Generic Plan";

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void PlanCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Amount = 1;
            _args.Currency = "USD";
            _args.Id = "Plan Id";
            _args.Interval = "month";
            _args.IntervalCount = 1;
            _args.Metadata = Data.Metadata;
            _args.Name = "Generic Plan";
            _args.StatementDescriptor = "The descriptor";
            _args.TrialPeriodDays = 30;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(10)
                .And.Contain(x => x.Key == "amount")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "id")
                .And.Contain(x => x.Key == "interval")
                .And.Contain(x => x.Key == "interval_count")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "name")
                .And.Contain(x => x.Key == "statement_descriptor")
                .And.Contain(x => x.Key == "trial_period_days");
        }
    }
}