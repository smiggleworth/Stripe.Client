using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Models;
namespace Stripe.Client.Sdk.Tests.Models
{
    [TestClass]
    public class StripeResponseTests
    {
        [TestMethod]
        public void StripeResponse_Success()
        {
            var stripeResponse = new StripeResponse<string>();
            stripeResponse.Success.Should().BeTrue();
        }

        [TestMethod]
        public void StripeResponse_NotSuccess()
        {
            var stripeResponse = new StripeResponse<string>();
            stripeResponse.Error = new StripeError();
            stripeResponse.Success.Should().BeFalse();
        }
    }

    [TestClass]
    public class StripeErrorEnvelopeTests
    {
        [TestMethod]
        public void Event_Parsing()
        {
            // Arrange
            var json = File.ReadAllText("JSON/error.json");

            // Act
            var obj = JsonConvert.DeserializeObject<Event>(json);

            // Assert
            obj.Should().BeAssignableTo<Event>();
            obj.Data.Object.Should().BeAssignableTo<Invoice>();
        }
    }
}