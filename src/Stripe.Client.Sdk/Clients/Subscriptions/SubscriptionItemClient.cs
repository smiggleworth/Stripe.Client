using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public class SubscriptionItemClient : ISubscriptionItemClient
    {
        private readonly IStripeClient _client;

        public List<string> Expandables { get; set; }

        public SubscriptionItemClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public async Task<StripeResponse<SubscriptionItem>> GetSubscriptionItem(
            string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionItem>
            {
                UrlPath = PathHelper.GetPath(Paths.SubscriptionItems, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<SubscriptionItem>>> GetSubscriptionItems(
            SubscriptionItemListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionItemListFilter, Pagination<SubscriptionItem>>
            {
                UrlPath = PathHelper.GetPath(Paths.SubscriptionItems),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<SubscriptionItem>> CreateSubscriptionItem(
            SubscriptionItemCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionItemCreateArguments, SubscriptionItem>
            {
                UrlPath = PathHelper.GetPath(Paths.SubscriptionItems),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<SubscriptionItem>> UpdateSubscriptionItem(
            SubscriptionItemUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionItemUpdateArguments, SubscriptionItem>
            {
                UrlPath =
                    PathHelper.GetPath(Paths.SubscriptionItems, arguments.Id),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }


        public async Task<StripeResponse<DeletedObject>> DeleteSubscriptionItem(
            SubscriptionItemDeleteArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionItemDeleteArguments, DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.SubscriptionItems, arguments.Id),
                Model = arguments
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}