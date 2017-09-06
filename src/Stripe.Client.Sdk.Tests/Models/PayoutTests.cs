﻿using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models;

namespace Stripe.Client.Sdk.Tests.Models {
    [TestClass]
    public class PayoutTests
    {
        [TestMethod]
        public void Payout_DeserializeTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/payout.json");

            // Act
            var obj = StripeClient.Deserialize<Payout>(json);

            // Assert
            obj.Should().BeAssignableTo<Payout>();
            obj.BalanceTransactionId.Should().Be("txn_19XJJ02eZvKYlo2ClwuJ1rbA");
        }

        [TestMethod]
        public void Payouts_DeserializeTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/payouts.json");

            // Act
            var obj = StripeClient.Deserialize<Pagination<Payout>>(json);

            // Assert
            obj.Should().BeAssignableTo<Pagination<Payout>>();
            obj.Data.Should().AllBeOfType<Payout>();
        }
    }
}