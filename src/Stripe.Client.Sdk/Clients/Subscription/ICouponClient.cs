using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscription
{
    public interface ICouponClient
    {
        Task<StripeResponse<Coupon>> GetCoupon(string couponId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Coupon>>> GetCoupons(CouponListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Coupon>> CreateCoupon(CouponCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Coupon>> UpdateCoupon(CouponUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteCoupon(string couponId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}