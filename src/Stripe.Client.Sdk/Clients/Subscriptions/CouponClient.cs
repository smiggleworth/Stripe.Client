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
        }

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
            var request = new StripeRequest<CouponListFilter, Pagination<Coupon>>
            {
                UrlPath = Paths.Coupons,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Coupon>> CreateCoupon(CouponCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CouponCreateArguments, Coupon>
            {
                UrlPath = Paths.Coupons,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Coupon>> UpdateCoupon(CouponUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CouponUpdateArguments, Coupon>
            {
                UrlPath = PathHelper.GetPath(Paths.Coupons, arguments.CouponId),
                Model = arguments
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