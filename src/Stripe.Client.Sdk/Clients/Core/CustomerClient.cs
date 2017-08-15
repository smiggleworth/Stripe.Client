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
    public class CustomerClient : ICustomerClient
    {
        private readonly IStripeClient _client;

        public CustomerClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Customer>> GetCustomer(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Customer>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Customer>>> GetCustomers(CustomerListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Pagination<Customer>>
            {
                UrlPath = Paths.Customers,
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Customer>> CreateCustomer(CustomerCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Customer>
            {
                UrlPath = Paths.Customers,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Customer>> UpdateCustomer(CustomerUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Customer>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteCustomer(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, id)
            };
            return await _client.Delete(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> GetBankAccount(string id, string customerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, customerId, Paths.Sources, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<BankAccount>>> GetBankAccounts(CustomerBankAccountListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Pagination<BankAccount>>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, filter.CustomerId, Paths.Sources),
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> CreateBankAccount(CustomerBankAccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> UpdateBankAccount(CustomerBankAccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources, arguments.BankAccountId),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }


        public async Task<StripeResponse<Card>> GetCard(string id, string customerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, customerId, Paths.Sources, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Card>>> GetCards(CustomerCardListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Pagination<Card>>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, filter.CustomerId, Paths.Sources),
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> CreateCard(CustomerCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> UpdateCard(CustomerCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources, arguments.CardId),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteCard(string id, string customerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, customerId, Paths.Sources, id)
            };
            return await _client.Delete(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteDiscount(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, id, Paths.Discount)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}