using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public interface ICountrySpecClient
    {
        Task<StripeResponse<CountrySpec>> GetCountrySpec(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<CountrySpec>>> GetCountrySpecs(CountrySpecListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}