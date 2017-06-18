using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Configuration;

namespace Stripe.Client.Sdk.Tests.Configurations
{
    [TestClass]
    public class StripeConfigurationTests
    {
        private readonly StripeConfiguration _configuration = new StripeConfiguration();

        [TestMethod]
        public void StripeConfiguration_AccountIdIsNullOrEmpty()
        {
            _configuration.AccountId.Should().BeNullOrEmpty("the value has not been set");
        }

        [TestMethod]
        public void StripeConfiguration_PublishableKeyIsNullOrEmpty()
        {
            _configuration.PublishableKey.Should().BeNullOrEmpty("the value has not been set");
        }

        [TestMethod]
        public void StripeConfiguration_SecretKeyIsNullOrEmpty()
        {
            _configuration.SecretKey.Should().BeNullOrEmpty("the value has not been set");
        }

        [TestMethod]
        public void StripeConfiguration_AccountId()
        {
            _configuration.AccountId = "account-id";
            _configuration.AccountId.Should().Be("account-id");
        }

        [TestMethod]
        public void StripeConfiguration_PublishableKey()
        {
            _configuration.PublishableKey = "publishable-key";
            _configuration.PublishableKey.Should().Be("publishable-key");
        }

        [TestMethod]
        public void StripeConfiguration_SecretKey()
        {
            _configuration.SecretKey = "secret-key";
            _configuration.SecretKey.Should().Be("secret-key");
        }
    }
}