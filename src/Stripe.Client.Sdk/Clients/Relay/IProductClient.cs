using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Relay
{
    public interface IProductClient
    {
        Task<StripeResponse<Product>> GetProduct(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Product>>> GetProducts(ProductListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Product>> CreateProduct(ProductCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Product>> UpdateProduct(ProductUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteProduct(string productId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}