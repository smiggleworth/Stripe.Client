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
    public class TransferClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ITransferClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new TransferClient(_stripe);
        }

        [TestMethod]
        public async Task GetTransferTest()
        {
            // Arrange
            var id = "transfer-id";
            _stripe.Get(Arg.Is<StripeRequest<Transfer>>(a => a.UrlPath == "transfers/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Transfer>()));

            // Act
            var response = await _client.GetTransfer(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetTransfersTest()
        {
            // Arrange
            var filter = new TransferListFilter();
            _stripe.Get(
                    Arg.Is<StripeRequest<Pagination<Transfer>>>(
                        a => a.UrlPath == "transfers" && a.Data == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Transfer>>()));

            // Act
            var response = await _client.GetTransfers(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateTransferTest()
        {
            // Arrange
            var args = new TransferCreateArguments();
            _stripe.Post(
                    Arg.Is<StripeRequest<Transfer>>(
                        a => a.UrlPath == "transfers" && a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Transfer>()));

            // Act
            var response = await _client.CreateTransfer(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateTransferTest()
        {
            // Arrange
            var args = new TransferUpdateArguments
            {
                TransferId = "transfer-id"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<Transfer>>(
                        a => a.UrlPath == "transfers/" + args.TransferId && a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Transfer>()));

            // Act
            var response = await _client.UpdateTransfer(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetTransferReversalTest()
        {
            // Arrange
            var id = "transfer-reversal-id";
            var transferId = "transfer-id";
            _stripe.Get(
                Arg.Is<StripeRequest<TransferReversal>>(a => a.UrlPath == "transfers/" + transferId + "/reversals/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<TransferReversal>()));

            // Act
            var response = await _client.GetTransferReversal(id, transferId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetTransferReversalsTest()
        {
            // Arrange
            var filter = new TransferReversalListFilter
            {
                TransferId = "transfer-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<Pagination<TransferReversal>>>(
                    a => a.UrlPath == "transfers/" + filter.TransferId + "/reversals" && a.Data == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<TransferReversal>>()));

            // Act
            var response = await _client.GetTransferReversals(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateTransferReversalTest()
        {
            // Arrange
            var args = new TransferReversalCreateArguments
            {
                TransferId = "transfer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<TransferReversal>>(
                    a => a.UrlPath == "transfers/" + args.TransferId + "/reversals" && a.Data == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<TransferReversal>()));

            // Act
            var response = await _client.CreateTransferReversal(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateTransferReversalTest()
        {
            // Arrange
            var args = new TransferReversalUpdateArguments
            {
                TransferReversalId = "transfer-reversal-id",
                TransferId = "transfer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<TransferReversal>>(
                    a => a.UrlPath == "transfers/" + args.TransferId + "/reversals/" + args.TransferReversalId && a.Data == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<TransferReversal>()));

            // Act
            var response = await _client.UpdateTransferReversal(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}