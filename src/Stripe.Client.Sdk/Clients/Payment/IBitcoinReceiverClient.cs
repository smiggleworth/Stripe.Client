using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Payment
{
    public interface IBitcoinReceiverClient
    {
        Task<StripeResponse<BitcoinReceiver>> GetBitcoinReceiver(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<BitcoinReceiver>>> GetBitcoinReceivers(BitcoinReceiverListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BitcoinReceiver>> CreateBitcoinReceiver(BitcoinReceiverCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}