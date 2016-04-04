using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Relay;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Tests.Clients.Relay
{
    [TestClass]
    public class ProductClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IProductClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new ProductClient(_stripe);
        }

        [TestMethod]
        public async Task GetProductTest()
        {
            // Arrange
            var id = "product-id";
            _stripe.Get(Arg.Is<StripeRequest<Product>>(a => a.UrlPath == "products/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Product>()));

            // Act
            var response = await _client.GetProduct(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetProductsTest()
        {
            // Arrange
            var filter = new ProductListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<ProductListFilter, Pagination<Product>>>(
                    a => a.UrlPath == "products" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Product>>()));

            // Act
            var response = await _client.GetProducts(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateProductTest()
        {
            // Arrange
            var args = new ProductCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<ProductCreateArguments, Product>>(a => a.UrlPath == "products" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Product>()));

            // Act
            var response = await _client.CreateProduct(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateProductTest()
        {
            // Arrange
            var args = new ProductUpdateArguments
            {
                ProductId = "product-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<ProductUpdateArguments, Product>>(
                    a => a.UrlPath == "products/" + args.ProductId && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Product>()));

            // Act
            var response = await _client.UpdateProduct(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteProductTest()
        {
            // Arrange
            var id = "product-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "products/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteProduct(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}