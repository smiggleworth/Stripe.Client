using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class BalanceClient : IBalanceClient
    {
        private readonly IStripeClient _client;

        public BalanceClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<Balance>> GetBalance(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Balance>
            {
                UrlPath = Paths.Balance
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<BalanceTransaction>> GetBalanceTranasaction(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BalanceTransaction>
            {
                UrlPath = PathHelper.GetPath(Paths.Balance, Paths.History, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<BalanceTransaction>>> GetBalanceTranasactions(
            BalanceTransactionListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BalanceTransactionListFilter, Pagination<BalanceTransaction>>
            {
                UrlPath = PathHelper.GetPath(Paths.Balance, Paths.History),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }
    }
}