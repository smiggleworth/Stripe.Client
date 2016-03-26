using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Autofac.Modules;
using Stripe.Client.Sdk.Configuration;

namespace Stripe.Client.Autofac.Tests.Modules
{
    [TestClass]
    public class StripeAppSettingsModule
    {
        [TestMethod]
        public void ShouldResolveStripeClient()
        {
            // Arrange
            var builder = new ContainerBuilder();
            builder.RegisterModule<StripeAppSettingModule>();
            var container = builder.Build();

            // Act
            var stripeConfiguration = container.Resolve<IStripeConfiguration>();

            // Assert
            stripeConfiguration.Should().BeAssignableTo<AppSettingsConfiguration>();
        }
    }
}