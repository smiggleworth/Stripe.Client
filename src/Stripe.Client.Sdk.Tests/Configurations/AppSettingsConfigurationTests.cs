using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Configuration;

namespace Stripe.Client.Sdk.Tests.Configurations
{
    [TestClass]
    public class AppSettingsConfigurationTests
    {
        private readonly IStripeConfiguration _configuration = new AppSettingsConfiguration();

        [TestMethod]
        public void AppSettingsConfiguration_AccountId()
        {
            _configuration.AccountId.Should().Be("the-account-id");
        }

        [TestMethod]
        public void AppSettingsConfiguration_PublishableKey()
        {
            _configuration.PublishableKey.Should().Be("the-publishable-key");
        }

        [TestMethod]
        public void AppSettingsConfiguration_SecretKey()
        {
            _configuration.SecretKey.Should().Be("the-secret-key");
        }
    }
}