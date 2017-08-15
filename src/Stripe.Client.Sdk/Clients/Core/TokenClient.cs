using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class TokenClient : ITokenClient
    {
        private readonly IStripeClient _client;

        public TokenClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<Token>> GetToken(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Token>
            {
                UrlPath = PathHelper.GetPath(Paths.Tokens, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Token>> CreateCardToken(CardTokenCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Token>
            {
                UrlPath = Paths.Tokens,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Token>> CreateBankAccountToken(BankAccountTokenCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Token>
            {
                UrlPath = Paths.Tokens,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Token>> CreatePiiToken(PiiTokenCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Token>
            {
                UrlPath = Paths.Tokens,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}