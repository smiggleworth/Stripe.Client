using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
}