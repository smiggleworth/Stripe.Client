using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class PackageDimensionsTests
    {
        [TestMethod]
        public void PackageDimensionArguments_GetAllKeys()
        {
            // Arrange 
            var args = new PackageDimensions();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(4)
                .And.Contain(x => x.Key == "height")
                .And.Contain(x => x.Key == "length")
                .And.Contain(x => x.Key == "weight")
                .And.Contain(x => x.Key == "width");
        }
    }
}