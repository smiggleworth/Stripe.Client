using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface IPayoutClient
    {
        Task<StripeResponse<Payout>> GetPayout(string subscriptionId, string customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Payout>>> GetPayouts(
            PayoutListFilter filter, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Payout>> CreatePayout(PayoutCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Payout>> UpdatePayout(PayoutUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Payout>> CancelPayout(string id, CancellationToken cancellationToken = default(CancellationToken));
    }
}