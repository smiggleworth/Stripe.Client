using System.Collections.Generic;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class DisputeClient : IDisputeClient
    {
        private readonly IStripeClient _client;

        public DisputeClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Dispute>> GetDispute(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Dispute>
            {
                UrlPath = PathHelper.GetPath(Paths.Disputes, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Dispute>>> GetDisputes(DisputeListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DisputeListFilter, Pagination<Dispute>>
            {
                UrlPath = Paths.Disputes,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Dispute>> UpdateDispute(DisputeUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DisputeUpdateArguments, Dispute>
            {
                UrlPath = PathHelper.GetPath(Paths.Disputes, arguments.DisputeId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Dispute>> CloseDispute(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Dispute>
            {
                UrlPath = PathHelper.GetPath(Paths.Disputes, id, "close")
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}