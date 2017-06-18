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
    public class SubscriptionClient : ISubscriptionClient
    {
        private readonly IStripeClient _client;

        public List<string> Expandables { get; set; }

        public SubscriptionClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public async Task<StripeResponse<Subscription>> GetSubscription(string subscriptionId, string customerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Subscription>
            {
                UrlPath = PathHelper.GetPath(Paths.Subscriptions, subscriptionId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Subscription>>> GetSubscriptions(
            SubscriptionListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionListFilter, Pagination<Subscription>>
            {
                UrlPath = PathHelper.GetPath(Paths.Subscriptions),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Subscription>> CreateSubscription(SubscriptionCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionCreateArguments, Subscription>
            {
                UrlPath = PathHelper.GetPath(Paths.Subscriptions),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Subscription>> UpdateSubscription(SubscriptionUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionUpdateArguments, Subscription>
            {
                UrlPath =
                    PathHelper.GetPath(Paths.Subscriptions, arguments.SubscriptionId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Subscription>> CancelSubscription(SubscriptionCancelArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Subscription>
            {
                UrlPath = PathHelper.GetPath(Paths.Subscriptions, arguments.SubscriptionId)
            };
            return await _client.Delete(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteDiscount(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Subscriptions, id, Paths.Discount)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}