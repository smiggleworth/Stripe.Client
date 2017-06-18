using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class EventClient : IEventClient
    {
        private readonly IStripeClient _client;

        public EventClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Event>> GetEvent(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Event>
            {
                UrlPath = PathHelper.GetPath(Paths.Events, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Event>>> GetEvents(EventListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<EventListFilter, Pagination<Event>>
            {
                UrlPath = Paths.Events,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }
    }
}