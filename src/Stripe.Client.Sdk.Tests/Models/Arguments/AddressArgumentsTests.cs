using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;
using System.Linq;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class AddressArgumentsTests
    {
        private AddressArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<AddressArguments>();
        }

        [TestMethod]
        public void AddressArguments_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _args = new AddressArguments();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void AddressArguments_GetAllKeys()
        {
            // Arrange 
            _args.Country = "US";

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "city")
                .And.Contain(x => x.Key == "country")
                .And.Contain(x => x.Key == "line1")
                .And.Contain(x => x.Key == "line2")
                .And.Contain(x => x.Key == "postal_code")
                .And.Contain(x => x.Key == "state")
                .And.Contain(x => x.Key == "town");
        }
    }
}