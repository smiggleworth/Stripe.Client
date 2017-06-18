using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Core;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Clients.Core
{
    [TestClass]
    public class TokenClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ITokenClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new TokenClient(_stripe);
        }

        [TestMethod]
        public async Task GetTokenTest()
        {
            // Arrange
            var id = "token-id";
            _stripe.Get(Arg.Is<StripeRequest<Token>>(a => a.UrlPath == "tokens/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Token>()));

            // Act
            var response = await _client.GetToken(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateCardTokenTest()
        {
            // Arrange
            var args = new CardTokenCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<CardTokenCreateArguments, Token>>(a => a.UrlPath == "tokens" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Token>()));

            // Act
            var response = await _client.CreateCardToken(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateBankAccountTokenTest()
        {
            // Arrange
            var args = new BankAccountTokenCreateArguments();
            _stripe.Post(
                       Arg.Is<StripeRequest<BankAccountTokenCreateArguments, Token>>(
                           a => a.UrlPath == "tokens" && a.Model == args), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Token>()));

            // Act
            var response = await _client.CreateBankAccountToken(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreatePiiTokenTest()
        {
            // Arrange
            var args = new PiiTokenCreateArguments();
            _stripe.Post(
                       Arg.Is<StripeRequest<PiiTokenCreateArguments, Token>>(
                           a => a.UrlPath == "tokens" && a.Model == args), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Token>()));

            // Act
            var response = await _client.CreatePiiToken(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}