using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface ITransferClient
    {
        Task<StripeResponse<Transfer>> GetTransfer(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Transfer>>> GetTransfers(TransferListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Transfer>> CreateTransfer(TransferCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Transfer>> UpdateTransfer(TransferUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<TransferReversal>> GetTransferReversal(string id, string transferId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<TransferReversal>>> GetTransferReversals(TransferReversalListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<TransferReversal>> CreateTransferReversal(TransferReversalCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<TransferReversal>> UpdateTransferReversal(TransferReversalUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}