using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public interface IInvoiceItemClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<InvoiceItem>> GetInvoiceItem(string invoiceItemId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<InvoiceItem>>> GetInvoiceItems(InvoiceItemListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<InvoiceItem>> CreateInvoiceItem(InvoiceItemCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<InvoiceItem>> UpdateInvoiceItem(InvoiceItemUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteInvoiceItem(string couponId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}