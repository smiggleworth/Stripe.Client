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
    public class PayoutClient : IPayoutClient
    {
        private readonly IStripeClient _client;

        public List<string> Expandables { get; set; }

        public PayoutClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public async Task<StripeResponse<Payout>> GetPayout(string subscriptionId, string customerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Payout>
            {
                UrlPath = PathHelper.GetPath(Paths.Payouts, subscriptionId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Payout>>> GetPayouts(
            PayoutListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<PayoutListFilter, Pagination<Payout>>
            {
                UrlPath = PathHelper.GetPath(Paths.Payouts),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Payout>> CreatePayout(PayoutCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<PayoutCreateArguments, Payout>
            {
                UrlPath = PathHelper.GetPath(Paths.Payouts),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Payout>> UpdatePayout(PayoutUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<PayoutUpdateArguments, Payout>
            {
                UrlPath =
                    PathHelper.GetPath(Paths.Payouts, arguments.Id),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Payout>> CancelPayout(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Payout>
            {
                UrlPath = PathHelper.GetPath(Paths.Payouts, id)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}