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
    public class SubscriptionClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ISubscriptionClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new SubscriptionClient(_stripe);
        }


        [TestMethod]
        public async Task GetSubscriptionTest()
        {
            // Arrange
            var id = "subscription-id";
            var customerId = "customer-id";
            _stripe.Get(
                    Arg.Is<StripeRequest<Subscription>>(
                        a => a.UrlPath == $"subscriptions/{id}"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Subscription>()));

            // Act
            var response = await _client.GetSubscription(id, customerId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetSubscriptionsTest()
        {
            // Arrange
            var filter = new SubscriptionListFilter
            {
                Customer = "customer-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<Pagination<Subscription>>>(
                    a => a.UrlPath == "subscriptions" && a.Data == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<Subscription>>()));

            // Act
            var response = await _client.GetSubscriptions(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateSubscriptionTest()
        {
            // Arrange
            var args = new SubscriptionCreateArguments
            {
                CustomerId = "customer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<Subscription>>(
                    a => a.UrlPath == "subscriptions" && a.Data == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Subscription>()));

            // Act
            var response = await _client.CreateSubscription(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateSubscriptionTest()
        {
            // Arrange
            var args = new SubscriptionUpdateArguments
            {
                SubscriptionId = "subscription-id",
                CustomerId = "customer-id"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<Subscription>>(
                        a =>
                            a.UrlPath == $"subscriptions/{args.SubscriptionId}" &&
                            a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Subscription>()));

            // Act
            var response = await _client.UpdateSubscription(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CancelSubscriptionTest()
        {
            // Arrange
            var args = GenFu.GenFu.New<SubscriptionCancelArguments>();

            _stripe.Delete(
                    Arg.Is<StripeRequest<Subscription>>(
                        a => a.UrlPath == $"subscriptions/{args.SubscriptionId}"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Subscription>()));

            // Act
            var response = await _client.CancelSubscription(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteDiscountTest()
        {
            // Arrange
            var id = "subscription-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == $"subscriptions/{id}/discount"),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteDiscount(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}