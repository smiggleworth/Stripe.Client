using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface IDisputeClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Dispute>> GetDispute(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Dispute>>> GetDisputes(DisputeListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Dispute>> UpdateDispute(DisputeUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Dispute>> CloseDispute(string id,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}