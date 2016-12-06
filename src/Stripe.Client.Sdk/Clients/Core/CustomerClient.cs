using System.Collections.Generic;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

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
            var request = new StripeRequest<CustomerListFilter, Pagination<Customer>>
            {
                UrlPath = Paths.Customers,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Customer>> CreateCustomer(CustomerCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CustomerCreateArguments, Customer>
            {
                UrlPath = Paths.Customers,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Customer>> UpdateCustomer(CustomerUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CustomerUpdateArguments, Customer>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId),
                Model = arguments
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
            var request = new StripeRequest<CustomerBankAccountListFilter, Pagination<BankAccount>>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, filter.CustomerId, Paths.Sources),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> CreateBankAccount(CustomerBankAccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CustomerBankAccountCreateArguments, BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<BankAccount>> UpdateBankAccount(CustomerBankAccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CustomerBankAccountUpdateArguments, BankAccount>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources, arguments.BankAccountId),
                Model = arguments
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
            var request = new StripeRequest<CustomerCardListFilter, Pagination<Card>>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, filter.CustomerId, Paths.Sources),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> CreateCard(CustomerCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CustomerCardCreateArguments, Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> UpdateCard(CustomerCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CustomerCardUpdateArguments, Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Sources, arguments.CardId),
                Model = arguments
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


        public async Task<StripeResponse<Models.Subscription>> GetSubscription(string subscriptionId, string customerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Models.Subscription>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, customerId, Paths.Subscriptions, subscriptionId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Models.Subscription>>> GetActiveSubscriptions(
            ActiveSubscriptionListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ActiveSubscriptionListFilter, Pagination<Models.Subscription>>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, filter.CustomerId, Paths.Subscriptions),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Models.Subscription>> CreateSubscription(SubscriptionCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionCreateArguments, Models.Subscription>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Subscriptions),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Models.Subscription>> UpdateSubscription(SubscriptionUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SubscriptionUpdateArguments, Models.Subscription>
            {
                UrlPath =
                    PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Subscriptions, arguments.SubscriptionId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Models.Subscription>> CancelSubscription(SubscriptionCancelArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Models.Subscription>
            {
                UrlPath = PathHelper.GetPath(Paths.Customers, arguments.CustomerId, Paths.Subscriptions, arguments.SubscriptionId)
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