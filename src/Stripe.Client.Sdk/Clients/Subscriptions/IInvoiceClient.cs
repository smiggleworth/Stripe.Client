using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public interface IInvoiceClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Invoice>> GetInvoice(string invoiceId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<InvoiceLineItem>>> GetInvoiceLineItems(InvoiceLineItemListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Invoice>>> GetUpcomingInvoices(UpcomingInvoiceArguments filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Invoice>> CreateInvoice(InvoiceCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Invoice>> UpdateInvoice(InvoiceUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Invoice>> PayInvoice(string invoiceId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}