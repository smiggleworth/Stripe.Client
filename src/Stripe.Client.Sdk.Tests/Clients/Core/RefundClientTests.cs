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
    public class RefundClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IRefundClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new RefundClient(_stripe);
        }


        [TestMethod]
        public async Task GetRefundTest()
        {
            var id = "ID_VALUE";
            _stripe.Get(Arg.Is<StripeRequest<Refund>>(a => a.UrlPath == "refunds/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Refund>()));
            var response = await _client.GetRefund(id, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetRefundsTest()
        {
            var filter = new RefundListFilter
            {
                Charge = "charge-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<RefundListFilter, Pagination<Refund>>>(
                    a => a.UrlPath == "refunds" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<Refund>>()));
            var response = await _client.GetRefunds(filter, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateRefundTest()
        {
            var args = new RefundCreateArguments
            {
                ChargeId = "some-value"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<RefundCreateArguments, Refund>>(
                        a => a.UrlPath == "refunds" && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Refund>()));
            var response = await _client.CreateRefund(args, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateRefundTest()
        {
            var args = new RefundUpdateArguments
            {
                RefundId = "refund-id",
                ChargeId = "some-value"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<RefundUpdateArguments, Refund>>(
                    a => a.UrlPath == "refunds/" + args.RefundId && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Refund>()));
            var response = await _client.UpdateRefund(args, _cancellationToken);
            response.Should().NotBeNull();
        }
    }
}