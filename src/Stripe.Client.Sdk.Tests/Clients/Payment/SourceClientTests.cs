using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Payment;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Clients.Payment
{
    [TestClass]
    public class SourceClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ISourceClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new SourceClient(_stripe);
        }

        [TestMethod]
        public async Task GetSourceTest()
        {
            // Arrange
            var id = "source-id";
            _stripe.Get(Arg.Any<StripeRequest<Source>>(), _cancellationToken).Returns(Task.FromResult(new StripeResponse<Source>()));

            // Act
            var response = await _client.GetSource(id, _cancellationToken);

            // Assert

            await _stripe.Received().Get(Arg.Is<StripeRequest<Source>>(a => a.UrlPath == $"sources/{id}"), _cancellationToken);
        }

        [TestMethod]
        public async Task CreateSourceTest()
        {
            // Arrange
            var args = new SourceCreateArguments();
            _stripe.Post(
                    Arg.Is<StripeRequest<Source>>(
                        a => a.UrlPath == "sources" && a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Source>()));

            // Act
            var response = await _client.CreateSource(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateSourceTest()
        {
            // Arrange
            var args = new SourceUpdateArguments
            {
                Id = "source-id"
            };
            _stripe.Post(Arg.Any<StripeRequest<Source>>(), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Source>()));

            // Act
            var response = await _client.UpdateSource(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();

            await _stripe.Received().Post(
                Arg.Is<StripeRequest<Source>>(
                    a => a.UrlPath == $"sources/{args.Id}" && a.Data == args), _cancellationToken);
        }
    }
}