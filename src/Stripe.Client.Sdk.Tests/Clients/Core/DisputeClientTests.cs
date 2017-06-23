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
    public class DisputeClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IDisputeClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new DisputeClient(_stripe);
        }

        [TestMethod]
        public async Task GetDisputeTest()
        {
            // Arrange
            var id = "dispute-id";
            _stripe.Get(Arg.Is<StripeRequest<Dispute>>(a => a.UrlPath == "disputes/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Dispute>()));

            // Act
            var response = await _client.GetDispute(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetDisputesTest()
        {
            // Arrange
            var filter = new DisputeListFilter();
            _stripe.Get(
                    Arg.Is<StripeRequest<DisputeListFilter, Pagination<Dispute>>>(
                        a => a.UrlPath == "disputes" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Dispute>>()));

            // Act
            var response = await _client.GetDisputes(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateDisputeTest()
        {
            // Arrange
            var args = new DisputeUpdateArguments
            {
                DisputeId = "dispute-id"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<DisputeUpdateArguments, Dispute>>(
                        a => a.UrlPath == "disputes/" + args.DisputeId && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Dispute>()));

            // Act
            var response = await _client.UpdateDispute(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CloseDisputeTest()
        {
            // Arrange
            var id = "dispute-id";
            _stripe.Post(Arg.Is<StripeRequest<Dispute>>(a => a.UrlPath == "disputes/" + id + "/close"),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Dispute>()));

            // Act
            var response = await _client.CloseDispute(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}