using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Relay
{
    public class OrderClient : IOrderClient
    {
        private readonly IStripeClient _client;

        public OrderClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<Order>> GetOrder(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Order>
            {
                UrlPath = PathHelper.GetPath(Paths.Orders, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Order>>> GetOrders(OrderListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<OrderListFilter, Pagination<Order>>
            {
                UrlPath = Paths.Orders,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Order>> CreateOrder(OrderCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<OrderCreateArguments, Order>
            {
                UrlPath = Paths.Orders,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Order>> UpdateOrder(OrderUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<OrderUpdateArguments, Order>
            {
                UrlPath = PathHelper.GetPath(Paths.Orders, arguments.OrderId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Order>> PayOrder(OrderPayArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<OrderPayArguments, Order>
            {
                UrlPath = PathHelper.GetPath(Paths.Orders, arguments.OrderId, Paths.Pay),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}