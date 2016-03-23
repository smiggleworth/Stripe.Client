using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface IBalanceClient
    {
        Task<StripeResponse<Balance>> GetBalance(CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BalanceTransaction>> GetBalanceTranasaction(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<BalanceTransaction>>> GetBalanceTranasactions(
            BalanceTransactionListFilter filter, CancellationToken cancellationToken = default(CancellationToken));
    }
}