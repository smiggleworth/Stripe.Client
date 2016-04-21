using System.Collections.Generic;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public class AccountClient : IAccountClient
    {
        private readonly IStripeClient _client;

        public AccountClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Account>> GetAccount(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Account>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Account>>> GetAccounts(AccountListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountListFilter, Pagination<Account>>
            {
                UrlPath = Paths.Accounts,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Account>> CreateAccount(AccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountCreateArguments, Account>
            {
                UrlPath = Paths.Accounts,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Account>> UpdateAccount(AccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountUpdateArguments, Account>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, arguments.AccountId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> GetBankAccount(string id, string accountId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, accountId, Paths.ExternalAccounts, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<BankAccount>>> GetBankAccounts(AccountBankAccountListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountBankAccountListFilter, Pagination<BankAccount>>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, filter.AccountId, Paths.ExternalAccounts),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> CreateBankAccount(AccountBankAccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountBankAccountCreateArguments, BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, arguments.AccountId, Paths.ExternalAccounts),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> UpdateBankAccount(AccountBankAccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountBankAccountUpdateArguments, BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, arguments.AccountId, Paths.ExternalAccounts, arguments.BankAccountId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> GetCard(string id, string accountId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, accountId, Paths.ExternalAccounts, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Card>>> GetCards(AccountCardListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountCardListFilter, Pagination<Card>>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, filter.AccountId, Paths.ExternalAccounts),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> CreateCard(AccountCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountCardCreateArguments, Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, arguments.AccountId, Paths.ExternalAccounts),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> UpdateCard(AccountCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<AccountCardUpdateArguments, Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Accounts, arguments.AccountId, Paths.ExternalAccounts, arguments.CardId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}