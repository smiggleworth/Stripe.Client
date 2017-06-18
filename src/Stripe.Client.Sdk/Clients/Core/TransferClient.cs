using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class TransferClient : ITransferClient
    {
        private readonly IStripeClient _client;

        public TransferClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Transfer>> GetTransfer(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Transfer>
            {
                UrlPath = PathHelper.GetPath(Paths.Transfers, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Transfer>>> GetTransfers(TransferListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferListFilter, Pagination<Transfer>>
            {
                UrlPath = Paths.Transfers,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Transfer>> CreateTransfer(TransferCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferCreateArguments, Transfer>
            {
                UrlPath = Paths.Transfers,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Transfer>> UpdateTransfer(TransferUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferUpdateArguments, Transfer>
            {
                UrlPath = PathHelper.GetPath(Paths.Transfers, arguments.TransferId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<TransferReversal>> GetTransferReversal(string id, string transferId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferReversal>
            {
                UrlPath = PathHelper.GetPath(Paths.Transfers, transferId, Paths.Reversals, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<TransferReversal>>> GetTransferReversals(
            TransferReversalListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferReversalListFilter, Pagination<TransferReversal>>
            {
                UrlPath = PathHelper.GetPath(Paths.Transfers, filter.TransferId, Paths.Reversals),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<TransferReversal>> CreateTransferReversal(
            TransferReversalCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferReversalCreateArguments, TransferReversal>
            {
                UrlPath = PathHelper.GetPath(Paths.Transfers, arguments.TransferId, Paths.Reversals),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<TransferReversal>> UpdateTransferReversal(
            TransferReversalUpdateArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<TransferReversalUpdateArguments, TransferReversal>
            {
                UrlPath = PathHelper.GetPath(Paths.Transfers, arguments.TransferId, Paths.Reversals, arguments.TransferReversalId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}