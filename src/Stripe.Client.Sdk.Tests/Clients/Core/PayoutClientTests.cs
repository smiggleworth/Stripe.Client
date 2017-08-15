using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Core;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Core
{
    [TestClass]
    public class PayoutClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IPayoutClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new PayoutClient(_stripe);
        }

        [TestMethod]
        public async Task GetPayoutTest()
        {
            // Arrange
            var id = "Payout-id";
            _stripe.Get(Arg.Is<StripeRequest<Payout>>(a => a.UrlPath == "payouts/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Payout>()));

            // Act
            var response = await _client.GetPayout(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetPayoutsTest()
        {
            // Arrange
            var filter = new PayoutListFilter();
            _stripe.Get(
                    Arg.Is<StripeRequest<PayoutListFilter, Pagination<Payout>>>(
                        a => a.UrlPath == "payouts" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Payout>>()));

            // Act
            var response = await _client.GetPayouts(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdatePayoutTest()
        {
            // Arrange
            var args = new PayoutUpdateArguments
            {
                Id = "payout-id"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<PayoutUpdateArguments, Payout>>(
                        a => a.UrlPath == "payouts/" + args.Id && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Payout>()));

            // Act
            var response = await _client.UpdatePayout(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CancelPayoutTest()
        {
            // Arrange
            var id = "payout-id";

            // Act
            var response = await _client.CancelPayout(id, _cancellationToken);

            // Assert
            await _stripe.Received().Post(Arg.Is<StripeRequest<Payout>>(a => a.UrlPath == "payouts/" + id + "/cancel"), _cancellationToken);
        }
    }
}