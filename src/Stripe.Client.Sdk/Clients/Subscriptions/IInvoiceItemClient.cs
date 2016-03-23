using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public interface IInvoiceItemClient
    {
        Task<StripeResponse<InvoiceItem>> GetInvoiceItem(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<InvoiceItem>>> GetInvoiceItems(InvoiceItemListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<InvoiceItem>> CreateInvoiceItem(InvoiceItemCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<InvoiceItem>> UpdateInvoiceItem(InvoiceItemUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}