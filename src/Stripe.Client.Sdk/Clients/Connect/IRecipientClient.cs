using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public interface IRecipientClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Recipient>> GetRecipient(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Recipient>>> GetRecipients(RecipientListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Recipient>> CreateRecipient(RecipientCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Recipient>> UpdateRecipient(RecipientUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> GetCard(string id, string recipientId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Card>>> GetCards(RecipientCardListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> CreateCard(RecipientCardCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Card>> UpdateCard(RecipientCardUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteCard(string id, string recipientId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeleteRecipient(string id,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}