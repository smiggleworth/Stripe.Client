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
    public class RefundClient : IRefundClient
    {
        private readonly IStripeClient _client;

        public RefundClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Refund>> GetRefund(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Refund>
            {
                UrlPath = PathHelper.GetPath(Paths.Refunds, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Refund>>> GetRefunds(RefundListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RefundListFilter, Pagination<Refund>>
            {
                UrlPath = Paths.Refunds,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Refund>> CreateRefund(RefundCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RefundCreateArguments, Refund>
            {
                UrlPath = Paths.Refunds,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Refund>> UpdateRefund(RefundUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RefundUpdateArguments, Refund>
            {
                UrlPath = PathHelper.GetPath(Paths.Refunds, arguments.RefundId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}