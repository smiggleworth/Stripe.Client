using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Connect;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Tests.Clients.Connect
{
    [TestClass]
    public class ApplicationFeeClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IApplicationFeeClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new ApplicationFeeClient(_stripe);
        }

        [TestMethod]
        public async Task GetApplicationFeeTest()
        {
            // Arrange
            var id = "ID_VALUE";
            _stripe.Get(Arg.Is<StripeRequest<ApplicationFee>>(a => a.UrlPath == "application_fees/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<ApplicationFee>()));

            // Act
            var response = await _client.GetApplicationFee(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetApplicationFeesTest()
        {
            // Arrange
            var filter = new ApplicationFeeListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<ApplicationFeeListFilter, Pagination<ApplicationFee>>>(
                    a => a.UrlPath == "application_fees"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<ApplicationFee>>()));

            // Act
            var response = await _client.GetApplicationFees(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetApplicationFeeRefundTest()
        {
            // Arrange
            var id = "ID_VALUE";
            var applicationFeeId = "app-fee-id";
            _stripe.Get(
                Arg.Is<StripeRequest<ApplicationFeeRefund>>(
                    a => a.UrlPath == "application_fees/" + applicationFeeId + "/refunds/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<ApplicationFeeRefund>()));

            // Act
            var response = await _client.GetApplicationFeeRefund(id, applicationFeeId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetApplicationFeeRefundsTest()
        {
            // Arrange
            var filter = new ApplicationFeeRefundListFilter
            {
                ApplicationFeeId = "application-fee-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<ApplicationFeeRefundListFilter, Pagination<ApplicationFeeRefund>>>(
                    a => a.UrlPath == "application_fees/" + filter.ApplicationFeeId + "/refunds"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<ApplicationFeeRefund>>()));

            // Act
            var response = await _client.GetApplicationFeeRefunds(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateApplicationFeeRefundTest()
        {
            // Arrange
            var args = new ApplicationFeeRefundCreateArguments
            {
                ApplicationFeeId = "application-fee-id"
            };

            _stripe.Post(
                Arg.Is<StripeRequest<ApplicationFeeRefundCreateArguments, ApplicationFeeRefund>>(
                    a => a.UrlPath == "application_fees/" + args.ApplicationFeeId + "/refunds"), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<ApplicationFeeRefund>()));

            // Act
            var response = await _client.CreateApplicationFeeRefund(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateApplicationFeeRefundTest()
        {
            // Arrange
            var args = new ApplicationFeeRefundUpdateArguments
            {
                ApplicationFeeId = "application-fee-id",
                ApplicationFeeRefundId = "refund-id"
            };

            _stripe.Post(
                Arg.Is<StripeRequest<ApplicationFeeRefundUpdateArguments, ApplicationFeeRefund>>(
                    a => a.UrlPath == "application_fees/" + args.ApplicationFeeId + "/refunds/" + args.ApplicationFeeRefundId),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<ApplicationFeeRefund>()));

            // Act
            var response = await _client.UpdateApplicationFeeRefund(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}