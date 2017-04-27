using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public interface IAccountClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Account>> GetAccount(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Account>>> GetAccounts(AccountListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Account>> CreateAccount(AccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Account>> UpdateAccount(AccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BankAccount>> GetBankAccount(string id, string accountId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<BankAccount>>> GetBankAccounts(AccountBankAccountListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BankAccount>> CreateBankAccount(AccountBankAccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BankAccount>> UpdateBankAccount(AccountBankAccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> GetCard(string id, string accountId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Card>>> GetCards(AccountCardListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> CreateCard(AccountCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> UpdateCard(AccountCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}