using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public class RecipientClient : IRecipientClient
    {
        private readonly IStripeClient _client;

        public RecipientClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

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
            var request = new StripeRequest<Pagination<Recipient>>
            {
                UrlPath = Paths.Recipients,
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Recipient>> CreateRecipient(RecipientCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Recipient>
            {
                UrlPath = Paths.Recipients,
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Recipient>> UpdateRecipient(RecipientUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Recipient>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, arguments.Id),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteRecipient(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, id)
            };
            return await _client.Delete(request, cancellationToken);
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
            var request = new StripeRequest<Pagination<Card>>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, filter.RecipientId, Paths.Cards),
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> CreateCard(RecipientCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, arguments.RecipientId, Paths.Cards),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Card>> UpdateCard(RecipientCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Card>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, arguments.RecipientId, Paths.Cards, arguments.CardId),
                Data = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeleteCard(string id, string recipientId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Recipients, recipientId, Paths.Cards, id)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}