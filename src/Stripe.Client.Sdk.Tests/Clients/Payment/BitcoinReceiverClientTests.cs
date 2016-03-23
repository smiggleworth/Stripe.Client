using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Payment;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Payment
{
    [TestClass]
    public class BitcoinReceiverClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IBitcoinReceiverClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new BitcoinReceiverClient(_stripe);
        }

        [TestMethod]
        public async Task GetBitcoinReceiverTest()
        {
            // Arrange
            var id = "bitcoin-receiver-id";
            _stripe.Get(Arg.Is<StripeRequest<BitcoinReceiver>>(a => a.UrlPath == "bitcoin/receivers/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<BitcoinReceiver>()));

            // Act
            var response = await _client.GetBitcoinReceiver(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetBitcoinReceiversTest()
        {
            // Arrange
            var filter = new BitcoinReceiverListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<BitcoinReceiverListFilter, Pagination<BitcoinReceiver>>>(
                    a => a.UrlPath == "bitcoin/receivers" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<BitcoinReceiver>>()));

            // Act
            var response = await _client.GetBitcoinReceivers(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateBitcoinReceiverTest()
        {
            // Arrange
            var args = new BitcoinReceiverCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<BitcoinReceiverCreateArguments, BitcoinReceiver>>(
                    a => a.UrlPath == "bitcoin/receivers" && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<BitcoinReceiver>()));

            // Act
            var response = await _client.CreateBitcoinReceiver(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}