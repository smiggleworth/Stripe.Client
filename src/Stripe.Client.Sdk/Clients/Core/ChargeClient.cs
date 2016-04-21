using System.Collections.Generic;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class ChargeClient : IChargeClient
    {
        private readonly IStripeClient _client;

        public ChargeClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Charge>> GetCharge(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Charge>
            {
                UrlPath = PathHelper.GetPath(Paths.Charges, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Charge>>> GetCharges(ChargeListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ChargeListFilter, Pagination<Charge>>
            {
                UrlPath = Paths.Charges,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Charge>> CreateCharge(ChargeCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ChargeCreateArguments, Charge>
            {
                UrlPath = Paths.Charges,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Charge>> UpdateCharge(ChargeUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ChargeUpdateArguments, Charge>
            {
                UrlPath = PathHelper.GetPath(Paths.Charges, arguments.ChargeId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Charge>> CaptureCharge(ChargeCaptureArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ChargeCaptureArguments, Charge>
            {
                UrlPath = PathHelper.GetPath(Paths.Charges, arguments.ChargeId, Paths.Capture),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}