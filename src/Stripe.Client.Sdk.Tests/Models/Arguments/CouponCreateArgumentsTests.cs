using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Extensions;
using Stripe.Client.Sdk.Models.Arguments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class CouponCreateArgumentsTests
    {
        private CouponCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<CouponCreateArguments>();
        }

        [TestMethod]
        public void CouponCreateArguments_DurationIsRequired()
        {
            // Arrange 
            _args.Duration = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void CouponCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.AmountOff = 1;
            _args.DurationInMonths = 12;
            _args.MaxRedemptions = 1;
            _args.Metadata = Data.Metadata;
            _args.PercentOff = 10;
            _args.RedeemBy = DateTime.UtcNow;

            var epoch = _args.RedeemBy.Value.ToEpoch().ToString();

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(10)
                .And.Contain(x => x.Key == "duration")
                .And.Contain(x => x.Key == "amount_off")
                .And.Contain(x => x.Key == "currency")
                .And.Contain(x => x.Key == "amount_off")
                .And.Contain(x => x.Key == "duration_in_months")
                .And.Contain(x => x.Key == "max_redemptions")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "percent_off")
                .And.Contain(x => x.Key == "redeem_by" && x.Value == epoch);
        }
    }
}