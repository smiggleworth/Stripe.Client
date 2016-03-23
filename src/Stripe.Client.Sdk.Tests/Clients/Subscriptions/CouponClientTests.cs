using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Subscription;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Subscriptions
{
    [TestClass]
    public class CouponClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ICouponClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new CouponClient(_stripe);
        }

        [TestMethod]
        public async Task GetCouponTest()
        {
            // Arrange
            var id = "coupon-id";
            _stripe.Get(Arg.Is<StripeRequest<Coupon>>(a => a.UrlPath == "coupons/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Coupon>()));

            // Act
            var response = await _client.GetCoupon(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCouponsTest()
        {
            // Arrange
            var filter = new CouponListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<CouponListFilter, Pagination<Coupon>>>(
                    a => a.UrlPath == "coupons" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Coupon>>()));

            // Act
            var response = await _client.GetCoupons(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateCouponTest()
        {
            // Arrange
            var args = new CouponCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<CouponCreateArguments, Coupon>>(a => a.UrlPath == "coupons" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Coupon>()));

            // Act
            var response = await _client.CreateCoupon(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateCouponTest()
        {
            // Arrange
            var args = new CouponUpdateArguments
            {
                CouponId = "coupon-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<CouponUpdateArguments, Coupon>>(
                    a => a.UrlPath == "coupons/" + args.CouponId && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Coupon>()));

            // Act
            var response = await _client.UpdateCoupon(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteCouponTest()
        {
            // Arrange
            var id = "coupon-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "coupons/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteCoupon(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}