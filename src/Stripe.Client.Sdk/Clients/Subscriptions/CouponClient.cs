using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public class CouponClient : ICouponClient
    {
        private readonly IStripeClient _client;

        public CouponClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Coupon>> GetCoupon(string couponId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Coupon>
            {
                UrlPath = PathHelper.GetPath(Paths.Coupons, couponId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Coupon>>> GetCoupons(CouponListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Pagination<Coupon>>
            {
                UrlPath = Paths.Coupons,
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Coupon>> CreateCoupon(CouponCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Coupon>
            {
                UrlPath = Paths.Coupons,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Coupon>> UpdateCoupon(CouponUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Coupon>
            {
                UrlPath = PathHelper.GetPath(Paths.Coupons, arguments.CouponId),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteCoupon(string couponId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Coupons, couponId)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}