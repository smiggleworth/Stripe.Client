using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Autofac.Modules;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Core;
using Stripe.Client.Sdk.Configuration;

namespace Stripe.Client.Autofac.Tests.Modules
{
    [TestClass]
    public class StripeClientModuleTests
    {
        [TestMethod]
        public void ShouldResolveStripeClient()
        {
            // Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<StripeConfiguration>().As<IStripeConfiguration>();
            builder.RegisterModule<StripeClientModule>();
            var container = builder.Build();

            // Act
            var stripeClient = container.Resolve<IStripeClient>();

            // Assert
            stripeClient.Should().BeAssignableTo<StripeClient>();
        }

        [TestMethod]
        public void ShouldResolveCustomerClient()
        {
            // Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<StripeConfiguration>().As<IStripeConfiguration>();
            builder.RegisterModule<StripeClientModule>();
            var container = builder.Build();

            // Act
            var customerClient = container.Resolve<ICustomerClient>();

            // Assert
            customerClient.Should().BeAssignableTo<CustomerClient>();
        }
    }
}
