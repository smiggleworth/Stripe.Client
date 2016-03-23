using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Relay
{
    public class ProductClient : IProductClient
    {
        private readonly IStripeClient _client;

        public ProductClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<Product>> GetProduct(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Product>
            {
                UrlPath = PathHelper.GetPath(Paths.Products, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Product>>> GetProducts(ProductListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ProductListFilter, Pagination<Product>>
            {
                UrlPath = Paths.Products,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Product>> CreateProduct(ProductCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ProductCreateArguments, Product>
            {
                UrlPath = Paths.Products,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Product>> UpdateProduct(ProductUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ProductUpdateArguments, Product>
            {
                UrlPath = PathHelper.GetPath(Paths.Products, arguments.ProductId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteProduct(string productId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Products, productId)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}