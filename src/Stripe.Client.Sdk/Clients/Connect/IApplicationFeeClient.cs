using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public interface IApplicationFeeClient
    {
        Task<StripeResponse<ApplicationFee>> GetApplicationFee(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<ApplicationFee>>> GetApplicationFees(ApplicationFeeListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<ApplicationFeeRefund>> GetApplicationFeeRefund(string id, string applicationFeeId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<ApplicationFeeRefund>>> GetApplicationFeeRefunds(
            ApplicationFeeRefundListFilter filter, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<ApplicationFeeRefund>> CreateApplicationFeeRefund(
            ApplicationFeeRefundCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<ApplicationFeeRefund>> UpdateApplicationFeeRefund(
            ApplicationFeeRefundUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}