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
    public class InvoiceItemClient : IInvoiceItemClient
    {
        private readonly IStripeClient _client;

        public InvoiceItemClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<InvoiceItem>> GetInvoiceItem(string invoiceItemId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceItem>
            {
                UrlPath = PathHelper.GetPath(Paths.InvoiceItems, invoiceItemId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<InvoiceItem>>> GetInvoiceItems(InvoiceItemListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Pagination<InvoiceItem>>
            {
                UrlPath = Paths.InvoiceItems,
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<InvoiceItem>> CreateInvoiceItem(InvoiceItemCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceItem>
            {
                UrlPath = Paths.InvoiceItems,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<InvoiceItem>> UpdateInvoiceItem(InvoiceItemUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceItem>
            {
                UrlPath = PathHelper.GetPath(Paths.InvoiceItems, arguments.InvoiceItemId),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteInvoiceItem(string couponId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.InvoiceItems, couponId)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}