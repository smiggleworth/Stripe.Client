using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface ITokenClient
    {
        Task<StripeResponse<Token>> GetToken(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Token>> CreateCardToken(CardTokenCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Token>> CreateBankAccountToken(BankAccountTokenCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Token>> CreatePiiToken(PiiTokenCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken));
    }
}