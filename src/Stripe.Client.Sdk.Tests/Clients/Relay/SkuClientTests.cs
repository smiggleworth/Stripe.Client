using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Relay;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Relay
{
    [TestClass]
    public class SkuClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ISkuClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new SkuClient(_stripe);
        }

        [TestMethod]
        public async Task GetSkuTest()
        {
            // Arrange
            var id = "sku-id";
            _stripe.Get(Arg.Is<StripeRequest<Sku>>(a => a.UrlPath == "skus/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Sku>()));

            // Act
            var response = await _client.GetSku(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetSkusTest()
        {
            // Arrange
            var filter = new SkuListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<SkuListFilter, Pagination<Sku>>>(a => a.UrlPath == "skus" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<Sku>>()));

            // Act
            var response = await _client.GetSkus(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateSkuTest()
        {
            // Arrange
            var args = new SkuCreateArguments();
            _stripe.Post(Arg.Is<StripeRequest<SkuCreateArguments, Sku>>(a => a.UrlPath == "skus" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Sku>()));

            // Act
            var response = await _client.CreateSku(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateSkuTest()
        {
            // Arrange
            var args = new SkuUpdateArguments
            {
                SkuId = "sku-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<SkuUpdateArguments, Sku>>(a => a.UrlPath == "skus/" + args.SkuId && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Sku>()));

            // Act
            var response = await _client.UpdateSku(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteSkuTest()
        {
            // Arrange
            var id = "sku-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "skus/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteSku(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}