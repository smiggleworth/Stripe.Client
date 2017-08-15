using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Clients.Payment {
    public interface ISourceClient {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Source>> GetSource(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Source>> CreateSource(
            SourceCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Source>> UpdateSource(
            SourceUpdateArguments arguments, CancellationToken cancellationToken = default(CancellationToken));
    }
}