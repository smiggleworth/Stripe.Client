using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public class InvoiceClient : IInvoiceClient
    {
        private readonly IStripeClient _client;

        public InvoiceClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Invoice>> GetInvoice(string invoiceId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Invoice>
            {
                UrlPath = PathHelper.GetPath(Paths.Invoices, invoiceId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Invoice>>> GetInvoices(InvoiceListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceListFilter, Pagination<Invoice>>
            {
                UrlPath = Paths.Invoices,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<InvoiceLineItem>>> GetInvoiceLineItems(
            InvoiceLineItemListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceLineItemListFilter, Pagination<InvoiceLineItem>>
            {
                UrlPath = PathHelper.GetPath(Paths.Invoices, filter.InvoiceId, Paths.Lines),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Invoice>> GetUpcomingInvoices(UpcomingInvoiceArguments filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<UpcomingInvoiceArguments, Invoice>
            {
                UrlPath = PathHelper.GetPath(Paths.Invoices, Paths.Upcoming),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Invoice>> CreateInvoice(InvoiceCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceCreateArguments, Invoice>
            {
                UrlPath = Paths.Invoices,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Invoice>> UpdateInvoice(InvoiceUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceUpdateArguments, Invoice>
            {
                UrlPath = PathHelper.GetPath(Paths.Invoices, arguments.InvoiceId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Invoice>> PayInvoice(string invoiceId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Invoice>
            {
                UrlPath = PathHelper.GetPath(Paths.Invoices, invoiceId, Paths.Pay)
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}