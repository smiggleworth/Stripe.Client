using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Payment
{
    public class BitcoinReceiverClient : IBitcoinReceiverClient
    {
        private readonly IStripeClient _client;

        public BitcoinReceiverClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<BitcoinReceiver>> GetBitcoinReceiver(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BitcoinReceiver>
            {
                UrlPath = PathHelper.GetPath(Paths.Bitcoin, Paths.Receivers, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<BitcoinReceiver>>> GetBitcoinReceivers(
            BitcoinReceiverListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BitcoinReceiverListFilter, Pagination<BitcoinReceiver>>
            {
                UrlPath = PathHelper.GetPath(Paths.Bitcoin, Paths.Receivers),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<BitcoinReceiver>> CreateBitcoinReceiver(
            BitcoinReceiverCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<BitcoinReceiverCreateArguments, BitcoinReceiver>
            {
                UrlPath = PathHelper.GetPath(Paths.Bitcoin, Paths.Receivers),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}