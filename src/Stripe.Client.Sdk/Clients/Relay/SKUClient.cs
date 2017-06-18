using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Relay
{
    public class SkuClient : ISkuClient
    {
        private readonly IStripeClient _client;

        public SkuClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Sku>> GetSku(string skuId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Sku>
            {
                UrlPath = PathHelper.GetPath(Paths.Skus, skuId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Sku>>> GetSkus(SkuListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SkuListFilter, Pagination<Sku>>
            {
                UrlPath = Paths.Skus,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Sku>> CreateSku(SkuCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SkuCreateArguments, Sku>
            {
                UrlPath = Paths.Skus,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Sku>> UpdateSku(SkuUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<SkuUpdateArguments, Sku>
            {
                UrlPath = PathHelper.GetPath(Paths.Skus, arguments.SkuId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteSku(string skuId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Skus, skuId)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}