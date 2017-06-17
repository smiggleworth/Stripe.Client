using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public class CountrySpecClient
    {
        private readonly IStripeClient _client;

        public CountrySpecClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<CountrySpec>> GetCountrySpec(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CountrySpec>
            {
                UrlPath = PathHelper.GetPath(Paths.CountrySpecs, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<CountrySpec>>> GetCountrySpecs(CountrySpecListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<CountrySpecListFilter, Pagination<CountrySpec>>
            {
                UrlPath = Paths.CountrySpecs,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }
    }
}