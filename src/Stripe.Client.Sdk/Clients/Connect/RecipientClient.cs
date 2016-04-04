using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public class RecipientClient : IRecipientClient
    {
        private readonly IStripeClient _client;

        public RecipientClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<Recipient>> GetRecipient(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Recipient>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Recipient>>> GetRecipients(RecipientListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RecipientListFilter, Pagination<Recipient>>
            {
                UrlPath = Paths.Recipients,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Recipient>> CreateRecipient(RecipientCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RecipientCreateArguments, Recipient>
            {
                UrlPath = Paths.Recipients,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Recipient>> UpdateRecipient(RecipientUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RecipientUpdateArguments, Recipient>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, arguments.Id),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> GetCard(string id, string recipientId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, recipientId, Paths.Cards, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Card>>> GetCards(RecipientCardListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RecipientCardListFilter, Pagination<Card>>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, filter.RecipientId, Paths.Cards),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> CreateCard(RecipientCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RecipientCardCreateArguments, Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, arguments.RecipientId, Paths.Cards),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> UpdateCard(RecipientCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<RecipientCardUpdateArguments, Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, arguments.RecipientId, Paths.Cards, arguments.CardId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}