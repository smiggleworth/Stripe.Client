using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface ICustomerClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Customer>> GetCustomer(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Customer>>> GetCustomers(CustomerListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Customer>> CreateCustomer(CustomerCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Customer>> UpdateCustomer(CustomerUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteCustomer(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BankAccount>> GetBankAccount(string id, string customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<BankAccount>>> GetBankAccounts(CustomerBankAccountListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BankAccount>> CreateBankAccount(CustomerBankAccountCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<BankAccount>> UpdateBankAccount(CustomerBankAccountUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> GetCard(string id, string customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Card>>> GetCards(CustomerCardListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> CreateCard(CustomerCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> UpdateCard(CustomerCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Models.Subscription>> GetSubscription(string subscriptionId, string customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Models.Subscription>>> GetActiveSubscriptions(
            ActiveSubscriptionListFilter filter, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Models.Subscription>> CreateSubscription(SubscriptionCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Models.Subscription>> UpdateSubscription(SubscriptionUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Models.Subscription>> CancelSubscription(SubscriptionCancelArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteDiscount(string id,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}