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
    public class OrderClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IOrderClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new OrderClient(_stripe);
        }

        [TestMethod]
        public async Task GetOrderTest()
        {
            // Arrange
            var id = "order-id";
            _stripe.Get(Arg.Is<StripeRequest<Order>>(a => a.UrlPath == "orders/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Order>()));

            // Act
            var response = await _client.GetOrder(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetOrdersTest()
        {
            // Arrange
            var filter = new OrderListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<OrderListFilter, Pagination<Order>>>(
                    a => a.UrlPath == "orders" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Order>>()));

            // Act
            var response = await _client.GetOrders(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateOrderTest()
        {
            // Arrange
            var args = new OrderCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<OrderCreateArguments, Order>>(a => a.UrlPath == "orders" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Order>()));

            // Act
            var response = await _client.CreateOrder(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateOrderTest()
        {
            // Arrange
            var args = new OrderUpdateArguments
            {
                OrderId = "order-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<OrderUpdateArguments, Order>>(
                    a => a.UrlPath == "orders/" + args.OrderId && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Order>()));

            // Act
            var response = await _client.UpdateOrder(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task PayOrderTest()
        {
            // Arrange
            var args = new OrderPayArguments
            {
                OrderId = "order-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<OrderPayArguments, Order>>(
                    a => a.UrlPath == "orders/" + args.OrderId + "/pay" && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Order>()));

            // Act
            var response = await _client.PayOrder(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}