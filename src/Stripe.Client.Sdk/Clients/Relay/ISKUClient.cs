using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Relay
{
    public interface ISkuClient
    {
        Task<StripeResponse<Sku>> GetSku(string skuId, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Sku>>> GetSkus(SkuListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Sku>> CreateSku(SkuCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Sku>> UpdateSku(SkuUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));


        Task<StripeResponse<DeletedObject>> DeleteSku(string skuId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}