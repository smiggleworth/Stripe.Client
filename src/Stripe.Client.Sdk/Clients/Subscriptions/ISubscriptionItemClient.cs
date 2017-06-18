using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public interface ISubscriptionItemClient
    {
        Task<StripeResponse<SubscriptionItem>> GetSubscriptionItem(string id, string customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<SubscriptionItem>>> GetSubscriptionItems(
            SubscriptionItemListFilter filter, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<SubscriptionItem>> CreateSubscriptionItem(SubscriptionItemCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<SubscriptionItem>> UpdateSubscriptionItem(SubscriptionItemUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteSubscriptionItem(SubscriptionItemDeleteArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}