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
    public class ChargeClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IChargeClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new ChargeClient(_stripe);
        }

        [TestMethod]
        public async Task GetChargeTest()
        {
            var id = "ID_VALUE";
            _stripe.Get(Arg.Is<StripeRequest<Charge>>(a => a.UrlPath == "charges/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Charge>()));
            var response = await _client.GetCharge(id, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetChargesTest()
        {
            var filter = new ChargeListFilter();
            _stripe.Get(
                    Arg.Is<StripeRequest<Pagination<Charge>>>(
                        a => a.UrlPath == "charges" && a.Data == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Charge>>()));
            var response = await _client.GetCharges(filter, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateChargeTest()
        {
            var args = new ChargeCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<Charge>>(a => a.UrlPath == "charges" && a.Data == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Charge>()));
            var response = await _client.CreateCharge(args, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateChargeTest()
        {
            var args = new ChargeUpdateArguments
            {
                ChargeId = "some-value"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<Charge>>(
                        a => a.UrlPath == "charges/" + args.ChargeId && a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Charge>()));
            var response = await _client.UpdateCharge(args, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CaptureChargeTest()
        {
            var args = new ChargeCaptureArguments
            {
                ChargeId = "some-value"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<Charge>>(
                        a => a.UrlPath == "charges/" + args.ChargeId + "/capture" && a.Data == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Charge>()));
            var response = await _client.CaptureCharge(args, _cancellationToken);
            response.Should().NotBeNull();
        }
    }
}