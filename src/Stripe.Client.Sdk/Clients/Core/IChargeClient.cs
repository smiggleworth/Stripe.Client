using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface IChargeClient
    {
        Task<StripeResponse<Charge>> GetCharge(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Charge>>> GetCharges(ChargeListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Charge>> CreateCharge(ChargeCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Charge>> UpdateCharge(ChargeUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Charge>> CaptureCharge(ChargeCaptureArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}