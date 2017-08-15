using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Subscriptions;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Subscriptions
{
    [TestClass]
    public class SubscriptionItemClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ISubscriptionItemClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new SubscriptionItemClient(_stripe);
        }


        [TestMethod]
        public async Task GetSubscriptionTest()
        {
            // Arrange
            var id = "subscription-item-id";
            _stripe.Get(
                    Arg.Is<StripeRequest<SubscriptionItem>>(
                        a => a.UrlPath == $"subscription_items/{id}"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<SubscriptionItem>()));

            // Act
            var response = await _client.GetSubscriptionItem(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetSubscriptionsTest()
        {
            // Arrange
            var filter = new SubscriptionItemListFilter
            {
                Subscription = "subscription-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<Pagination<SubscriptionItem>>>(
                    a => a.UrlPath == "subscription_items" && a.Data == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<SubscriptionItem>>()));

            // Act
            var response = await _client.GetSubscriptionItems(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateSubscriptionTest()
        {
            // Arrange
            var args = new SubscriptionItemCreateArguments
            {
                Subscription = "subscription-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<SubscriptionItem>>(
                    a => a.UrlPath == "subscription_items" && a.Data == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<SubscriptionItem>()));

            // Act
            var response = await _client.CreateSubscriptionItem(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateSubscriptionTest()
        {
            // Arrange
            var args = new SubscriptionItemUpdateArguments
            {
                Id = "subscription-item-id",
                Subscription = "subscription-id"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<SubscriptionItem>>(
                        a =>
                            a.UrlPath == $"subscription_items/{args.Id}" &&
                            a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<SubscriptionItem>()));

            // Act
            var response = await _client.UpdateSubscriptionItem(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteSubscriptionItemTest()
        {
            // Arrange
            var args = new SubscriptionItemDeleteArguments { Id = "subscription-item-id" };
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == $"subscription_items/{args.Id}"),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteSubscriptionItem(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}