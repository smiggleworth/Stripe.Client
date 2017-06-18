using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public interface ISubscriptionClient
    {
        Task<StripeResponse<Subscription>> GetSubscription(string subscriptionId, string customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Subscription>>> GetSubscriptions(
            SubscriptionListFilter filter, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Subscription>> CreateSubscription(SubscriptionCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Subscription>> UpdateSubscription(SubscriptionUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Subscription>> CancelSubscription(SubscriptionCancelArguments arguments, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteDiscount(string id,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}