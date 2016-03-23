using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscription
{
    public class InvoiceItemClient : IInvoiceItemClient
    {
        private readonly IStripeClient _client;
        private readonly string _path = "invoiceitems";

        public InvoiceItemClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<InvoiceItem>> GetInvoiceItem(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<string, InvoiceItem>
            {
                UrlPath = _path + "/" + id,
                Model = id
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<InvoiceItem>>> GetInvoiceItems(InvoiceItemListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceItemListFilter, Pagination<InvoiceItem>>
            {
                UrlPath = _path,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<InvoiceItem>> CreateInvoiceItem(InvoiceItemCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceItemCreateArguments, InvoiceItem>
            {
                UrlPath = _path,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<InvoiceItem>> UpdateInvoiceItem(InvoiceItemUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<InvoiceItemUpdateArguments, InvoiceItem>
            {
                UrlPath = _path + "/" + arguments.InvoiceItemId,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}