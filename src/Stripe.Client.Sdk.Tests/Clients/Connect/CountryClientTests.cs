using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Connect;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Connect
{
    [TestClass]
    public class CountryClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ICountrySpecClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new CountrySpecClient(_stripe);
        }

        [TestMethod]
        public async Task GetCountrySpecTest()
        {
            // Arrange
            var id = "country-specs-id";
            _stripe.Get(Arg.Is<StripeRequest<CountrySpec>>(a => a.UrlPath == $"country_specs/{id}"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<CountrySpec>()));

            // Act
            var response = await _client.GetCountrySpec(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCountrySpecsTest()
        {
            // Arrange
            var filter = new CountrySpecListFilter();
            _stripe.Get(
                    Arg.Is<StripeRequest<CountrySpecListFilter, Pagination<CountrySpec>>>(
                        a => a.UrlPath == "country_specs" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<CountrySpec>>()));

            // Act
            var response = await _client.GetCountrySpecs(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}