using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models;

namespace Stripe.Client.Sdk.Tests.Models {
    [TestClass]
    public class ChargeTests
    {
        [TestMethod]
        public void Charge_DeserializeTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/charge.json");

            // Act
            var obj = StripeClient.Deserialize<Charge>(json);

            // Assert
            obj.Should().BeAssignableTo<Charge>();
            obj.BalanceTransactionId.Should().Be("txn_19XJJ02eZvKYlo2ClwuJ1rbA");
            obj.CustomerId.Should().Be("cus_9NEdzxwfMSJm7L");
        }

        [TestMethod]
        public void Charges_DeserializeTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/charges.json");

            // Act
            var obj = StripeClient.Deserialize<Pagination<Charge>>(json);

            // Assert
            obj.Should().BeAssignableTo<Pagination<Charge>>();
            obj.Data.Should().AllBeOfType<Charge>();
        }
    }
}