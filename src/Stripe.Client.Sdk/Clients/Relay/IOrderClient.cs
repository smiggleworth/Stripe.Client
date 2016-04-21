using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Relay
{
    public interface IOrderClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Order>> GetOrder(string id, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Order>>> GetOrders(OrderListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Order>> CreateOrder(OrderCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Order>> UpdateOrder(OrderUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Order>> PayOrder(OrderPayArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}