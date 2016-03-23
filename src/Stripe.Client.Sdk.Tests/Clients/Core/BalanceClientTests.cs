using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Core;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Core
{
    [TestClass]
    public class BalanceClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IBalanceClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new BalanceClient(_stripe);
        }

        [TestMethod]
        public async Task GetBalanceTest()
        {
            _stripe.Get(Arg.Is<StripeRequest<Balance>>(a => a.UrlPath == "balance"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Balance>()));
            var response = await _client.GetBalance(_cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetBalanceTranasactionTest()
        {
            var id = "id";
            _stripe.Get(Arg.Is<StripeRequest<BalanceTransaction>>(a => a.UrlPath == "balance/history/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<BalanceTransaction>()));
            var response = await _client.GetBalanceTranasaction(id, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetBalanceHistoryTest()
        {
            var filter = new BalanceTransactionListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<BalanceTransactionListFilter, Pagination<BalanceTransaction>>>(
                    a => a.UrlPath == "balance/history"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<BalanceTransaction>>()));
            var response = await _client.GetBalanceTranasactions(filter, _cancellationToken);
            response.Should().NotBeNull();
        }
    }
}