using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models;

namespace Stripe.Client.Sdk.Tests.Models
{
    [TestClass]
    public class SubscriptionTests
    {
        [TestMethod]
        public void Subscription_DeserializeTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/subscription.json");

            // Act
            var obj = StripeClient.Deserialize<Subscription>(json);

            // Assert
            obj.Should().BeAssignableTo<Subscription>();
            obj.Plan.Should().BeAssignableTo<Plan>();
        }

        [TestMethod]
        public void Subscriptions_DeserializeTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/subscriptions.json");

            // Act
            var obj = StripeClient.Deserialize<Pagination<Subscription>>(json);

            // Assert
            obj.Should().BeAssignableTo<Pagination<Subscription>>();
            obj.Data.Should().AllBeOfType<Subscription>();
        }
    }
}
