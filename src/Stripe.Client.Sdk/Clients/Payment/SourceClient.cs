using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Payment
{
    public class SourceClient : ISourceClient
    {
        private readonly IStripeClient _client;

        public SourceClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Source>> GetSource(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Source>
            {
                UrlPath = PathHelper.GetPath(Paths.Sources, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Source>> CreateSource(
            SourceCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SourceCreateArguments, Source>
            {
                UrlPath = PathHelper.GetPath(Paths.Sources),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Source>> UpdateSource(
            SourceUpdateArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SourceUpdateArguments, Source>
            {
                UrlPath = PathHelper.GetPath(Paths.Sources, arguments.Id),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}